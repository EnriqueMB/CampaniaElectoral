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
    public partial class frmActividadComercialGrid : System.Web.UI.Page
    {
       public List<EM_ActividadComercial> ListaActividad = new List<EM_ActividadComercial>();
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
                        EM_ActividadComercial Datos = new EM_ActividadComercial { Conexion = Comun.Conexion, IDActividadComercial = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                        CN.EliminarActividadComercialXID(Datos);
                        if (Datos.Completado)
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
                }
                if (!IsPostBack)
                {

                }
                else
                {
                }
                this.CargarGridActivadadComercial();

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
        public void CargarGridActivadadComercial()
        {
            try
            {
                EM_ActividadComercial Datos = new EM_ActividadComercial { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaActividad = GN.ObtenerCatalogoActividadComercial(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}