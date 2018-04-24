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
    public partial class frmTextoDonateGrid : System.Web.UI.Page
    {
        public List<RR_Donate> Lista = new List<RR_Donate>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridTipoEventoCampania();
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
        public void CargarGridTipoEventoCampania()
        {
            try
            {
                RR_Donate Datos = new RR_Donate { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                Lista = GN.ObtenerTextoDonate(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}