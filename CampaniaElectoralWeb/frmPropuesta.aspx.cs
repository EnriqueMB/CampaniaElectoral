using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class frmPropuesta : System.Web.UI.Page
    {
        public List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
            }
            this.CargarPropuestas();            
            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {

                }
            }          
            if (Request.QueryString["errorMessage"] != null)
            {
                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
        }
        public void CargarPropuestas()
        {
            try
            {
                RR_PropuestaCamapaña Datos = new RR_PropuestaCamapaña { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                Lista = GN.ObtenerPropuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}