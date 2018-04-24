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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<GM_VideosLoad> Lista = new List<GM_VideosLoad>();
        protected void Page_Load(object sender, EventArgs e)
        {
       try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {      
                        ID = Request.QueryString["id"];
                        GM_VideosLoad DatosAux = new GM_VideosLoad { Conexion = Comun.Conexion, IDVideo = ID, IDUsuario = Comun.IDUsuario };
                       GM_VideoNegocio  CN = new GM_VideoNegocio();
                        CN.EliminarSVideo(DatosAux);

                        if (DatosAux.Completado)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                }
                if (!IsPostBack)
                {
                    //string ScripSucces = DialogMessage.Show(TipoMensaje.Success, "Los datos se han guardado.", "Correctamente", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    //ScriptManager.RegisterStartupScript(this, typeof(Type), "popup", ScripSucces, true);
                }
                else
                {
                }

               this.CargarView();
                if (Request.QueryString["errorMessage"] != null)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }

        public void CargarView()
        {
            try
            {
                GM_VideosLoad Datos = new GM_VideosLoad() { Conexion = Comun.Conexion };
                GM_VideoNegocio GV = new GM_VideoNegocio();
                Lista = GV.ObtenerListStatusVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}