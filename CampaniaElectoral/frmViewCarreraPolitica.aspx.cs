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
    public partial class WebForm3 : System.Web.UI.Page
    {
   
        public List<GM_CarreraPolitica> Lista = new List<GM_CarreraPolitica>();
        protected void Page_Load(object sender, EventArgs e)
        {

            GM_CarreraPolitica DatosAux = new GM_CarreraPolitica { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_CarreraPoliticaNegocio FN = new GM_CarreraPoliticaNegocio();

            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosAux.IDCarreraPolitica = AuxID;
                    FN.EliminarCarreraPoliticaID(DatosAux);
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
            Lista = FN.ObtenerListCarreraPolitica(DatosAux);
        }
    }
}