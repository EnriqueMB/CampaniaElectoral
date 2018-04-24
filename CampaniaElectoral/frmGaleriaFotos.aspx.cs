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
    public partial class frmGaleriaFotos : System.Web.UI.Page
    {
        public List<CH_Foto> Lista = new List<CH_Foto>();
        protected void Page_Load(object sender, EventArgs e)
        {

            CH_Foto DatosAux = new CH_Foto { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            CH_FotoNegocio FN = new CH_FotoNegocio();

            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosAux.IDFoto = AuxID;
                    FN.EliminarFotoXID(DatosAux);
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
            Lista = FN.ObtenerCatalogoFotos(DatosAux);
        }
    }
}