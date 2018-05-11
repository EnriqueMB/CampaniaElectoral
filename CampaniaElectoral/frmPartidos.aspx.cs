using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                        int IDPartido = -1;
                        string logoPartido = string.Empty;
                        HttpPostedFile bannerImage = imgLogo.PostedFile as HttpPostedFile;
                        try
                        {
                            string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                            int.TryParse(AuxID, out IDPartido);
                            bool NuevoRegistro = !(IDPartido > 0);
                            if (imgLogo.HasFile)
                            {
                                int size = imgLogo.PostedFile.ContentLength;
                                byte[] ImagenOriginal = new byte[size];
                                imgLogo.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                                Bitmap ImagenOriginalBinaria = new Bitmap(imgLogo.PostedFile.InputStream);
                                string extension = Path.GetExtension(imgLogo.FileName);
                                ImageFormat imageFormateExtension = FG_Auxiliar.ObtenerExtensionImageFormat(extension);
                                if (imageFormateExtension != null)
                                logoPartido = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, imageFormateExtension);
                            }
                            else
                        {
                            logoPartido = Logo.Attributes["data-src"];
                        }

                        this.Guardar(NuevoRegistro, IDPartido, txtNomb, txtSigl, txtColo, logoPartido, Band);
                        
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
                Logo.Src = "data:" + DatosAux.ExtensionLogo + ";base64, " + DatosAux.Logo;
                Logo.Attributes.Add("data-src", DatosAux.Logo);
                Logo.Attributes.Add("data-imagenserver", DatosAux.CambioImagen.ToString());
                imgLogo.Attributes.Add("data-imagenserver", DatosAux.CambioImagen.ToString());
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Guardar(bool NuevoRegistro, int ID, string Nombre, string Sigla, string Color, string logo, bool BandCambioImagen)
        {
            try
            {
                CH_PartidoPolitico Datos = new CH_PartidoPolitico
                {
                    NuevoRegistro = NuevoRegistro,
                    IDPartido = ID,
                    Nombre = Nombre,
                    Siglas = Sigla,
                    RGBColor = Color,
                    CambioImagen = BandCambioImagen,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name,
                    Logo = logo
                };
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                CN.ACCatalogoPartidos(Datos);

                Response.Redirect("frmPartidosGrid.aspx?resultado=" + Datos.Completado + "&mensaje=" + Datos.Nombre, false);
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
                Logo.Attributes.Add("data-src", string.Empty);
                Logo.Attributes.Add("data-imagenserver", "0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}