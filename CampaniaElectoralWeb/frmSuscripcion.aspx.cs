using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoralWeb
{
    public partial class frmSuscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JL_Suscripcion datos = new JL_Suscripcion { Conexion = Comun.Conexion };
            if (Request.Form["correo"] != null)
            {
                datos.correo = Request.Form["correo"].ToString();
                JL_SuscripcionNegocio SN = new JL_SuscripcionNegocio();
                SN.GuardarSuscripcion(datos);
                if (datos.Completado)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Suscripcion Completa", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "No se puedo Realizar la Suscripcion", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
        }
    }
}