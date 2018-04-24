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
    public partial class frmTextoCarreraPoliticaGrid : System.Web.UI.Page
    {
        public List<RR_CarreraPolitica> Lista = new List<RR_CarreraPolitica>();
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
                RR_CarreraPolitica Datos = new RR_CarreraPolitica { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                Lista = GN.ObtenerCarreraPolXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}