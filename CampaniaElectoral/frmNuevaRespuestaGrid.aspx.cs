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
    public partial class frmNuevaRespuestaGrid : System.Web.UI.Page
    {
        public List<RR_NuevaRespuesta> Lista = new List<RR_NuevaRespuesta>();
        public string IDPregunta;
        public string IDEncuesta;
        public int IDTipoPregunta;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "0")
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        string AuxID2 = Request.QueryString["id2"].ToString();
                        int.TryParse(Request.QueryString["id3"].ToString(), out IDTipoPregunta);
                        RR_NuevaRespuesta Datos = new RR_NuevaRespuesta { Conexion = Comun.Conexion, IDPregunta = AuxID };
                        RR_CatalogosNegocio PN = new RR_CatalogosNegocio();
                        Lista = PN.ObtenerRespuestas(Datos);
                        this.IDPregunta = AuxID;
                        this.IDEncuesta = AuxID2;
                    }
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null && Request.QueryString["id4"] != null)
                    {
                        string AuxID = "";
                        AuxID = Request.QueryString["id"].ToString();
                        string IDPregu = Request.QueryString["id2"].ToString();
                        this.IDPregunta = IDPregu;
                        string IDEncu = Request.QueryString["id3"].ToString();
                        this.IDEncuesta = IDEncu;
                        int.TryParse(Request.QueryString["id4"].ToString(), out IDTipoPregunta);
                        RR_NuevaRespuesta Datos = new RR_NuevaRespuesta { Conexion = Comun.Conexion, IDRespuesta = AuxID, IDPregunta = IDPregu, IDEncuesta =  IDEncu, IDTipoPre = IDTipoPregunta, IDUsuario = Comun.IDUsuario };
                        RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                        CN.EliminarRespuestasXID(Datos);
                        if (Datos.Completado)
                        {
                            this.IDPregunta = Datos.IDPregunta;
                            this.IDEncuesta = Datos.IDEncuesta;
                            this.IDTipoPregunta = Datos.IDTipoPre;
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            Response.Redirect("frmNuevaRespuestaGrid.aspx?op=0&id=" + Datos.IDPregunta.ToString() + "&id2=" + Datos.IDEncuesta.ToString() + "&id3=" + this.IDTipoPregunta, false);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al eliminar el registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
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