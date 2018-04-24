using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        public List<GM_PlanCampania> ListaC = new List<GM_PlanCampania>();
        protected void Page_Load(object sender, EventArgs e)
        {

            GM_PlanCampania DatosAux = new GM_PlanCampania { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_PlanCampaniaNegocio FN = new GM_PlanCampaniaNegocio();

            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosAux.IDPElectoral = AuxID;
                    FN.EliminarIdCampania(DatosAux);
                    if (DatosAux.Completado)
                    {
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
            ListaC = FN.ObtenerListCampania(DatosAux);
        }
    }
}