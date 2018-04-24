using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmPartidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            int ID = 0;
                            if (int.TryParse(Request.QueryString["id"].ToString(), out ID))
                            {
                                //Obtener los datos y dibujarlos.
                                CH_PartidoPolitico DatosAux = new CH_PartidoPolitico { Conexion = Comun.Conexion, IDPartido = ID };
                                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                                CN.ObtenerDetallePartidoXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmPartidosGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmPartidosGrid.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmPartidosGrid.aspx");
                    }
                    else
                        Response.Redirect("frmPartidosGrid.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 8 || Request.Form.Count == 9)
                {                    
                        bool Band = false;
                        if(imgLogo.HasFile) //Hay cambio de imagen
                        {
                            Band = true;
                        }
                        string txtNomb = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                        string txtSigl = Request.Form["ctl00$cph_MasterBody$txtSigla"].ToString();
                        string txtColo = Request.Form["ctl00$cph_MasterBody$txtColor"].ToString();
                        string txtUrlImg =  Band ? imgLogo.PostedFile.FileName: string.Empty;
                        int IDPartido = -1;
                        HttpPostedFile bannerImage = imgLogo.PostedFile as HttpPostedFile;
                        try
                        {
                            string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                            int.TryParse(AuxID, out IDPartido);
                            bool NuevoRegistro = !(IDPartido > 0);
                            this.Guardar(NuevoRegistro, IDPartido, txtNomb, txtSigl, txtColo, txtUrlImg, bannerImage, Band);
                        }
                        catch (Exception ex)
                        {
                            Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                        }                       
                    
                }
            }            
        }

        #region Métodos

        private void CargarDatos(CH_PartidoPolitico DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDPartido.ToString();
                txtNombre.Value = DatosAux.Nombre;
                txtSigla.Value = DatosAux.Siglas;
                txtColor.Value = DatosAux.RGBColor;
                panelColor.Attributes.Remove("data-color");
                panelColor.Attributes.Add("data-color", DatosAux.RGBColor);
                string BaseDir = Server.MapPath("");
                string BaseDirAux = BaseDir + DatosAux.UrlLogo;
                if (File.Exists(BaseDir + DatosAux.UrlLogo))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", DatosAux.UrlLogo);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Nombre, string Sigla, string Color, string FileName, HttpPostedFile PostedImage, bool BandCambioImagen)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName): string.Empty;
                CH_PartidoPolitico Datos = new CH_PartidoPolitico
                {
                    NuevoRegistro = NuevoRegistro,
                    IDPartido = ID,
                    Nombre = Nombre,
                    Siglas = Sigla,
                    ExtensionLogo = FileExtension,
                    RGBColor = Color,
                    CambioImagen = BandCambioImagen,
                    UrlLogo = FileName,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                CN.ACCatalogoPartidos(Datos);
                if (Datos.Completado)
                {
                    if (BandCambioImagen)
                    {
                        if (PostedImage != null && PostedImage.ContentLength > 0)
                        {
                            try
                            {
                                Stream S = PostedImage.InputStream;
                                System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                                Img.Save(BaseDir + Datos.UrlLogo);
                                CN.ImagenSubidaPartidoXID(Datos);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    Response.Redirect("frmPartidosGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "-1";
                txtNombre.Value = string.Empty;
                txtSigla.Value = string.Empty;
                txtColor.Value = string.Empty;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}