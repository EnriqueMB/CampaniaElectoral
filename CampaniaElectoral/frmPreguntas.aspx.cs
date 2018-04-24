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
    public partial class frmPreguntas : System.Web.UI.Page
    {
        public List<EM_Preguntas> ListaPregunta = new List<EM_Preguntas>();
        public string IDEncuesta = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "0")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        EM_Preguntas Datos = new EM_Preguntas { Conexion = Comun.Conexion, IDEncuesta = AuxID };
                        EM_PreguntasNegocio PN = new EM_PreguntasNegocio();
                        ListaPregunta = PN.ObtenerPreguntasXID(Datos);
                        this.IDEncuesta = AuxID;
                    }
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null)
                    {
                        string AuxID = Request.QueryString["id"];
                        string AuxID2 = Request.QueryString["id2"];
                        this.IDEncuesta = AuxID2;
                        //int.TryParse(Request.QueryString["id"], out AuxID);
                        EM_Preguntas Datos = new EM_Preguntas { Conexion = Comun.Conexion, IDPreguntas = AuxID, IDEncuesta = AuxID2, IDUsuario = Comun.IDUsuario };
                        EM_PreguntasNegocio CN = new EM_PreguntasNegocio();
                        CN.EliminarPreguntasXID(Datos);
                        if (Datos.Completado)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            Response.Redirect("frmPreguntas.aspx?op=0&id=" + this.IDEncuesta.ToString(), false);
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
    }
}