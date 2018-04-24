using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmPublicarVideos : System.Web.UI.Page
    {
        public List<GM_VideosLoad> Lista = new List<GM_VideosLoad>();
        protected void Page_Load(object sender, EventArgs e)
        {            
            GM_VideosLoad DatosAux = new GM_VideosLoad { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_VideoNegocio CN = new GM_VideoNegocio();
            RR_AdministradorWebNegocio RN = new RR_AdministradorWebNegocio();
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string ID = Request.QueryString["id"].ToString();
                        if (Request.QueryString["id"].ToString() == ID)
                        {
                            DatosAux.NuevoVideo = true;
                            DatosAux.IDVideo = ID;
                            RN.CargaVideoXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro agregado a la página correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            }
                            else
                            {
                                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "No se puede agregar el registro a la página registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            }
                        }
                    }
                }                                             
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
            Lista = CN.ObtenerListStatusVideo(DatosAux);
        }
    }
}