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
    public partial class frmMisionVision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se inicializan campos, datos, valores
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
                                EM_MisionVision DatosAux = new EM_MisionVision { Conexion = Comun.Conexion, IDMisionVision = ID };
                                EM_MisionVisionNegocio MN = new EM_MisionVisionNegocio();
                                MN.ObtenerVisionMisionDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmMisionVisionGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmMisionVisionGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmMisionVisionGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmMisionVisionGrid.aspx?errorMessage=3");
                }
                else
                {
                    Response.Redirect("frmMisionVisionGrid.aspx", false);
                    //this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 16 || Request.Form.Count == 14)
                {
                    bool Band1 = false;
                    bool Band2 = false;
                    if (imgLogoM.HasFile) //Hay cambio de imagen
                    {
                        Band1 = true;
                    }
                    if (imgLogoV.HasFile)
                    {
                        Band2 = true;
                    }
                    string txtTitulo = Request.Form["ctl00$cph_MasterBody$txtTitulo"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    string txtMision = Request.Form["ctl00$cph_MasterBody$txtMision"].ToString();
                    string txtTitleM = Request.Form["ctl00$cph_MasterBody$txtNombreImagenM"].ToString();
                    string txtAltM = Request.Form["ctl00$cph_MasterBody$txtAltM"].ToString();
                    string txtVision = Request.Form["ctl00$cph_MasterBody$txtVision"].ToString();
                    string txtTitleV = Request.Form["ctl00$cph_MasterBody$txtNombreImagenV"].ToString();
                    string txtAltV = Request.Form["ctl00$cph_MasterBody$txtAltV"].ToString();
                    string txtValores = Request.Form["ctl00$cph_MasterBody$txtValores"].ToString();
                    string urlImagenM = Band1 ? imgLogoM.PostedFile.FileName : string.Empty;
                    string urlImagenV = Band2 ? imgLogoV.PostedFile.FileName : string.Empty;
                    HttpPostedFile bannerImageM = imgLogoM.PostedFile as HttpPostedFile;
                    HttpPostedFile bannerImageV = imgLogoV.PostedFile as HttpPostedFile;
                    int IDMisionVision = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDMisionVision);
                        bool NuevoRegistro = !(IDMisionVision > 0);
                        this.Guardar(NuevoRegistro, IDMisionVision, txtTitulo, txtDescripcion, txtMision, txtTitleM, txtAltM, urlImagenM, txtVision,
                            txtTitleV, txtAltV, urlImagenV, txtValores, bannerImageM, Band1, bannerImageV, Band2);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }
        #region Métodos

        private void CargarDatos(EM_MisionVision DatosAux)
        {
            try
            {
                this.hf.Value = DatosAux.IDMisionVision.ToString();
                this.txtTitulo.Value = DatosAux.Titulo;
                this.txtDescripcion.Value = DatosAux.Descripcion;
                this.txtMision.Value = DatosAux.Mision;
                this.txtVision.Value = DatosAux.Vision;
                this.txtNombreImagenM.Value = DatosAux.TituloImagenM;
                this.txtNombreImagenV.Value = DatosAux.TituloImagenV;
                this.txtAltM.Value = DatosAux.AltImagenM;
                this.txtAltV.Value = DatosAux.AltImagenV;
                this.txtValores.Value = DatosAux.Valores;
                string BaseDir = Server.MapPath("");
                if (File.Exists(BaseDir + DatosAux.UrlImagenM))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", DatosAux.UrlImagenM);
                }
                if (File.Exists(BaseDir + DatosAux.UrlImagenV))
                {
                    Logo2.Attributes.Remove("src");
                    Logo2.Attributes.Add("src", DatosAux.UrlImagenV);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string txtTitulo, string txtDesc, string txtMision, string txtTitleM, string txtAltM,
                            string urlImagenM, string txtVision, string txtTitleV, string txtAltV, string urlImagenV, string txtValores,
                            HttpPostedFile PostedImageM, bool BandCambioImagenM, HttpPostedFile PostedImageV, bool BandCambioImagenV)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtensionM = BandCambioImagenM ? Path.GetExtension(urlImagenM) : string.Empty;
                string FileExtensionV = BandCambioImagenV ? Path.GetExtension(urlImagenV) : string.Empty;
                EM_MisionVision Datos = new EM_MisionVision
                {
                    NuevoRegistro = NuevoRegistro,
                    IDMisionVision = ID,
                    Titulo = txtTitulo,
                    Descripcion = txtDesc,
                    Mision = txtMision,
                    TituloImagenM = txtTitleM,
                    AltImagenM = txtAltM,
                    UrlImagenM = FileExtensionM,
                    Vision = txtVision,
                    TituloImagenV = txtTitleV,
                    AltImagenV = txtAltV,
                    UrlImagenV = FileExtensionV,
                    Valores = txtValores,
                    ImagenGuardada = BandCambioImagenM ? BandCambioImagenV : false,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_MisionVisionNegocio MN = new EM_MisionVisionNegocio();
                MN.ACVisionMision(Datos);
                if (Datos.Completado)
                {
                    if (BandCambioImagenM || BandCambioImagenV)
                    {
                        if (PostedImageM != null && PostedImageM.ContentLength > 0 || PostedImageV != null && PostedImageV.ContentLength > 0)
                        {
                            try
                            {
                                Stream S = PostedImageM.InputStream;
                                Stream SV = PostedImageV.InputStream;
                                System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                                System.Drawing.Image ImgV = new System.Drawing.Bitmap(SV);
                                ImgV.Save(BaseDir + Datos.UrlImagenV);
                                Img.Save(BaseDir + Datos.UrlImagenM);
                                MN.ImagenSubidaVisionXID(Datos);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    Response.Redirect("frmMisionVisionGrid.aspx", false);
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
                this.hf.Value = "-1";
                this.txtTitulo.Value = string.Empty;
                this.txtDescripcion.Value = string.Empty;
                this.txtMision.Value = string.Empty;
                this.txtVision.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}