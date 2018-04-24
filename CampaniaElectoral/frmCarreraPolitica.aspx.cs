using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CampaniaElectoral
{
    public partial class WebForm2 : System.Web.UI.Page
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
                            string ID = Request.QueryString["id"].ToString();
                            GM_CarreraPolitica DatosAux = new GM_CarreraPolitica { Conexion = Comun.Conexion, IDCarreraPolitica= ID };
                            GM_CarreraPoliticaNegocio CP = new GM_CarreraPoliticaNegocio();
                            CP.ObtenerDetalleCarreraPolitica(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                Response.Redirect("frmViewCarreraPolitica.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmViewCarreraPolitica.aspx");
                    }
                    else
                        Response.Redirect("frmViewCarreraPolitica.aspx");
                }
                else
                {
                }
            }
            else
            {
                
                if (Request.Form.Count > 0)
                {
                    bool Band = false;
                    if (imgLogo.HasFile)
                    {
                        Band = true;
                    }
                    DateTime FechaInicio;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    string txtTitulo = Request.Form["ctl00$cph_MasterBody$txtTitulo"].ToString();
                    string txtDescription = Request.Form["ctl00$cph_MasterBody$txtDescription"].ToString();
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaRealizado"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out FechaInicio);
                    string zFechaRealizado = Request.Form["ctl00$cph_MasterBody$txtFechaRealizado"].ToString();
                    string txtUrlImg = Band ? imgLogo.PostedFile.FileName : string.Empty;
                    HttpPostedFile bannerImage = imgLogo.PostedFile as HttpPostedFile;
                    string IDCarreraPolitica= "";

                    try
                    {

                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDCarreraPolitica = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDCarreraPolitica);


                        this.Save(NuevoRegistro, IDCarreraPolitica, txtTitulo, txtDescription, FechaInicio, txtUrlImg, bannerImage, Band);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }

     
        #region Methods

        private void CargarDatos(GM_CarreraPolitica DatosAux)
        {
            try
            {

                hf.Value = DatosAux.IDCarreraPolitica;
                txtTitulo.Value = DatosAux.Title;
                txtDescription.Value = DatosAux.Descripcion;
                txtFechaRealizado.Value = Convert.ToString(DatosAux.FechaRealizado);
                string BaseDir = Server.MapPath("~/Images/CarreraPolitica");
                if (File.Exists(BaseDir + DatosAux.URLImagen))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", "Images/CarreraPolitica/" + DatosAux.URLImagen);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save(bool NuevoRegistro, string IDCarreraPolitica, string Titulo, string Descripcion, DateTime FechaInicio, string UrlImg, HttpPostedFile bannerImage, bool Band)
        {
            try
            {
                string BDir = Server.MapPath("~/Images/CarreraPolitica/");
                string FileExtension = Band ? Path.GetExtension(UrlImg) : string.Empty;
                GM_CarreraPolitica Datos = new GM_CarreraPolitica
                {
                    NuevoRegistro = NuevoRegistro,
                    IDCarreraPolitica = IDCarreraPolitica,
                    Title = Titulo ,
                    Descripcion = Descripcion,
                    FechaRealizado=FechaInicio,
                    ExtrancionImagen = FileExtension,
                    URLImagen = UrlImg,
                    CambioImagen = Band,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                GM_CarreraPoliticaNegocio CP = new GM_CarreraPoliticaNegocio();
                CP.AGCarreraPolitica(Datos);
                Datos.Completado = true;
                if (Datos.Completado)
                {
                    if (bannerImage != null && bannerImage.ContentLength > 0)
                    {
                        try
                        {
                            Stream S = bannerImage.InputStream;
                            System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                            Img.Save(BDir + Datos.URLImagen);
                            CP.ImagenSubidaFotoXID(Datos);

                        }
                        catch (Exception)
                        {
                        }

                    }
                    Response.Redirect("frmViewCarreraPolitica.aspx", false);
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
                hf.Value = "";
                txtTitulo.Value = string.Empty;
                txtDescription.Value = string.Empty;
                //txtFecchaRealizado.Value = string.Empty;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
        #endregion