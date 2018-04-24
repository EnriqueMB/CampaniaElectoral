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
    public partial class frmRespuestaEncuestaGrid : System.Web.UI.Page
    {
        public List<CH_Encuesta> Lista = new List<CH_Encuesta>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"];
                        CH_Encuesta Datos = new CH_Encuesta { Conexion = Comun.Conexion, IDRespuesta = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
                        EN.EliminarRespuestaXID(Datos);
                        if (Datos.Completado)
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
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }

        private void CargarGrid()
        {
            try
            {
                CH_Encuesta Datos = new CH_Encuesta { Conexion = Comun.Conexion };
                CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
                Lista = EN.ObtenerListaRespuestas(Datos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}