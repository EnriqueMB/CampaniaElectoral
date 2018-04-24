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
    public partial class frmHistorialActividades : System.Web.UI.Page
    {
        public List<RR_NuevaActividad> ListaActividad = new List<RR_NuevaActividad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        //int AuxID = 0;
                        //int.TryParse(Request.QueryString["id"], out AuxID);
                        //RR_NuevaActividad Datos = new RR_NuevaActividad { Conexion = Comun.Conexion, IDNuevaAct = AuxID.ToString(), IDUsuario = Comun.IDUsuario };
                        //RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                        //CN.EliminarNuevaActividadXID(Datos);
                        //if (Datos.Completado)
                        //{
                        //    string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        //}
                        //else
                        //{
                        //    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        //}
                    }
                }
                if (!IsPostBack)
                {

                }
                else
                {
                }

                this.CargarGrid();
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
        public void CargarGrid()
        {
            try
            {
                RR_NuevaActividad Datos = new RR_NuevaActividad() { Conexion = Comun.Conexion };
                EM_HistorialActividadNegocio GN = new EM_HistorialActividadNegocio();
                ListaActividad = GN.ObtenerHistorialActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}