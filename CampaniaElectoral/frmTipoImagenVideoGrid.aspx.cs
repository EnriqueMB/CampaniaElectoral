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
    public partial class frmTipoImagenVideoGrid : System.Web.UI.Page
    {
        public List<EM_TipoImagenVideo> ListaImagenVideo = new List<EM_TipoImagenVideo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        EM_TipoImagenVideo Datos = new EM_TipoImagenVideo { Conexion = Comun.Conexion, IDTipoImagenVideo = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                        CN.EliminarTipoImagenVideoXID(Datos);
                        if (Datos.Completado)
                        {
                            //Response.Redirect("frmActividadComercialGrid.aspx");
                            //Mostrar mensaje Success
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
                if (!IsPostBack)
                {

                }
                else
                {
                }

                this.CargarGridTipoImagenVideo();
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

        public void CargarGridTipoImagenVideo()
        {
            try
            {
                EM_TipoImagenVideo Datos = new EM_TipoImagenVideo { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaImagenVideo = GN.ObtenerCatalogoTipoImagenVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}