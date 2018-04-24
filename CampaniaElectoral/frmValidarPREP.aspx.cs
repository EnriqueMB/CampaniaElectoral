using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmValidarPREP : System.Web.UI.Page
    {
        CH_ConteoNegocio CHN = new CH_ConteoNegocio();
       public  List<CH_Conteo> lista = new List<CH_Conteo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            CH_Conteo datos = new CH_Conteo();
            datos.Conexion = Comun.Conexion;

            lista = CHN.ObtenerCapturaPrepValidacion(datos);


            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    CH_Conteo DatosConteo = new CH_Conteo();
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosConteo.IDCaptura = AuxID;
                    DatosConteo.IDUsuario = Comun.IDUsuario;
                    DatosConteo.Conexion = Comun.Conexion;
                    CH_ConteoNegocio CN = new CH_ConteoNegocio();
                    CN.Validarconteo(DatosConteo);
                    if (DatosConteo.Completado)
                    {
                        Response.Redirect("frmValidarPREP.aspx");
                        string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else
                    {
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al eliminar el registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                }
            }
            else
            {

            }


        }
    }
}