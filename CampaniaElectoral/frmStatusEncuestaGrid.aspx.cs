using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class frmStatusEncuestaGrid : System.Web.UI.Page
    {
        public List<RR_StatusEncuestas> Lista = new List<RR_StatusEncuestas>();
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
                        RR_StatusEncuestas Datos = new RR_StatusEncuestas { Conexion = Comun.Conexion, IDEncuesta = AuxID, IDUsuario = Comun.IDUsuario };
                        RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                        CN.EliminarStatusEncuestaXID(Datos);
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
                RR_StatusEncuestas Datos = new RR_StatusEncuestas { Conexion = Comun.Conexion };
                RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoStatusEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}