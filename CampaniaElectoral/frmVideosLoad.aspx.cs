using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;


namespace CampaniaElectoral
{
    public partial class frmVideosLoad : System.Web.UI.Page
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
                                ID= Request.QueryString["id"];
                                GM_VideosLoad DatosAux = new GM_VideosLoad { Conexion = Comun.Conexion, IDVideo = ID  };
                                GM_VideoNegocio CN = new GM_VideoNegocio();
                                CN.ObtenerDetalleVideo(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    Response.Redirect("frmVideosLoad.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                        else
                            Response.Redirect("frmVideosLoad.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmVideosLoad.aspx?errorMessage=3");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                string txtUrl = Request.Form["ctl00$cph_MasterBody$txtUrl"].ToString();
                string txtAlt = Request.Form["ctl00$cph_MasterBody$txtAlt"].ToString();
                string txtTitle = Request.Form["ctl00$cph_MasterBody$txtTitle"].ToString();
                string txtDescription = Request.Form["ctl00$cph_MasterBody$txtDescription"].ToString();
                string IDVideo = "";
                try
                {
                    string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    
                    IDVideo = AuxID;
                    bool NuevoRegistro = string.IsNullOrEmpty(IDVideo);
                    this.Guardar(NuevoRegistro, IDVideo, txtUrl, txtAlt, txtTitle, txtDescription);
                }
                catch (Exception ex)
                {
                    Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                }

            }
        }

      #region General Methods

      public void Guardar(bool NuevoRegistro, string ID , string Url, string Alt, string Title, string Description)
        {
            try
            {
                GM_VideosLoad Datos = new GM_VideosLoad()
                {
                    NuevoVideo = NuevoRegistro,
                    IDVideo=ID,
                    Url = Url,
                    Alt = Alt,
                    Title = Title,
                    Description = Description,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                GM_VideoNegocio VN = new GM_VideoNegocio();
                VN.ACStatuVideo(Datos);
                 if (Datos.Completado)
                {
                    string ScripSucces = DialogMessage.Show(TipoMensaje.Success, "Los datos se han guardado.", "Correctamente", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Type), "popup", ScripSucces, true);
                    Response.Redirect("frmVideosView.aspx", false);
                                            
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    Response.Redirect("frmVideosView.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      public void IniciarDatos()
        {
            try
            {
                hf.Value = "";
                txtUrl.Value = string.Empty;
                txtAlt.Value = string.Empty;
                txtTitle.Value = string.Empty;
                txtDescription.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      public void CargarDatos(GM_VideosLoad DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDVideo.ToString();
                txtUrl.Value = DatosAux.Url;
                txtAlt.Value = DatosAux.Alt;
                txtTitle.Value=( DatosAux.Title);
                txtDescription.Value=(DatosAux.Description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
      #endregion

    }
}