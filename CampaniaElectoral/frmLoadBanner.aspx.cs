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
    public partial class frmLoadBanner : System.Web.UI.Page
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
                            GM_LoadBanner DatosAux = new GM_LoadBanner { Conexion = Comun.Conexion, IDBanner = ID };
                            GM_LoadBannerNegocio CN = new GM_LoadBannerNegocio();
                            CN.ObtenerDetalleIDBanner(DatosAux);
                            if (DatosAux.Completado)
                            {
                                //this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                Response.Redirect("frmLoadBanner.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmLoadBanner.aspx");
                    }
                    else
                        Response.Redirect("frmLoadBanner.aspx");
                }
                else
                {
                    this.IniciarDatos();
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
                    
                    string txtNombreInicial = Request.Form["ctl00$cph_MasterBody$txtNombreInicial"].ToString();
                    string txtNombreBanner = Request.Form["ctl00$cph_MasterBody$txtNombreBanner"].ToString();
                    bool verMas = false;
                    if (Request.Form["ctl00$cph_MasterBody$txtverMas"] != null)
                    {
                        string txtverMas = Request.Form["ctl00$cph_MasterBody$txtverMas"].ToString();
                        bool.TryParse(txtverMas, out verMas);
                    }
                    string txtUrlBanner = Request.Form["ctl00$cph_MasterBody$txtUrlBanner"].ToString();
                    string txtButton = Request.Form["ctl00$cph_MasterBody$txtButton"].ToString();
                    string txtUrlImg = Band ? imgLogo.PostedFile.FileName : string.Empty;
                    string txtAlt = Request.Form["ctl00$cph_MasterBody$txtAlt"].ToString();
                    string txtTitle = Request.Form["ctl00$cph_MasterBody$txtTitle"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    string IDIBanner = "";
                    string IDBanner = "";
                    int IDTBanner = 1;
                    try
                    {

                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDIBanner = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDIBanner);
                        

                        this.Save(NuevoRegistro, IDIBanner, IDBanner, IDTBanner, txtNombreInicial, txtNombreBanner, verMas, txtUrlBanner, txtButton, txtUrlImg, txtTitle, txtAlt, txtDescripcion, Band);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }

     
        #region Methods

        private void CargarDatos(GM_LoadBanner DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDBanner;
                txtNombreInicial.Value = DatosAux.TextoInicial;
                txtNombreBanner.Value = DatosAux.TextoPrincipal;
                txtTitle.Value = DatosAux.Title;
                txtAlt.Value = DatosAux.Alt;
                txtDescripcion.Value = DatosAux.Descripcion;
                //verMas.Value = DatosAux.VerMas;
                txtUrlBanner.Value = DatosAux.URLBanner;
                txtButton.Value = DatosAux.TextoButton;

                string BaseDir = Server.MapPath("~/Images/Fotos/");
                if (File.Exists(BaseDir + DatosAux.NombreArchivo))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", "Images/Fotos/" + DatosAux.NombreArchivo);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save(bool NuevoRegistro, string IDIBanner, string IDBanner, int IDTBanner, string TextoInicial, string TextoPrincipal, bool verMas, string URLBanner, string TextoButtton, string UrlImg, string Title, string Alt, string Descripcion, bool Band)
        {
            try
            {
                GM_LoadBanner Datos = new GM_LoadBanner
                {
                    NuevoRegistro = NuevoRegistro,
                    IDIBanner =IDIBanner,
                    IDBanner = IDBanner,
                    IDTBanner= IDTBanner,
                    TextoInicial= TextoInicial,
                    TextoPrincipal= TextoPrincipal,
                    VerMas = verMas,
                    URLBanner = URLBanner,
                    TextoButton = TextoButtton,
                    URLImagen = UrlImg,
                    Alt = Alt,
                    Title = Title,
                    Descripcion = Descripcion,
                    CambioImagen = Band,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                GM_LoadBannerNegocio LB= new GM_LoadBannerNegocio();
                LB.AGBanner(Datos);
                if (Datos.Completado)
                {
                    string ScripSucces = DialogMessage.Show(TipoMensaje.Success, "Los datos se han guardado.", "Correctamente", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Type), "popup", ScripSucces, true);
                    Response.Redirect("frmLoadBanner.aspx", false);
                    
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
                txtTitle.Value = string.Empty;
                txtDescripcion.Value = string.Empty;
                txtAlt.Value = string.Empty;
                txtNombreInicial.Value = string.Empty;
                txtNombreBanner.Value = string.Empty;
                txtUrlBanner.Value = string.Empty;
                txtButton.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     }
}
        #endregion