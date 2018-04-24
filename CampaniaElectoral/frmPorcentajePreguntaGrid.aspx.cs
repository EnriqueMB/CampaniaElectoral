using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class frmPorcentajePreguntaGrid : System.Web.UI.Page
    {
        public List<EM_PorcentajePregunta> ListaPorcentaje = new List<EM_PorcentajePregunta>();
        public string IDPregunta;
        public string IDEncuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "5")
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null )
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        string AuxID2 = Request.QueryString["id2"].ToString();
                        EM_PorcentajePregunta Datos = new EM_PorcentajePregunta { Conexion = Comun.Conexion, IDPregunta = AuxID };
                        EM_PorcentajePreguntaNegocio PG = new EM_PorcentajePreguntaNegocio();
                        ListaPorcentaje = PG.ObtenerPorcentajePregunta(Datos);
                        this.IDPregunta = AuxID;
                        this.IDEncuesta = AuxID2;

                    }
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        string AuxIDPregunta = Request.QueryString["id2"].ToString();
                        string AuxIdEncueta = Request.QueryString["id3"].ToString();
                        EM_PorcentajePregunta Datos = new EM_PorcentajePregunta { Conexion = Comun.Conexion, IDPorcentaje = AuxID, IDPregunta = AuxIDPregunta, IDEncuesta = AuxIdEncueta, IDUsuario = Comun.IDUsuario };
                        EM_PorcentajePreguntaNegocio PPN = new EM_PorcentajePreguntaNegocio();
                        PPN.EliminarPorcentajsXID(Datos);
                        if (Datos.Completado)
                        {
                            this.IDPregunta = Datos.IDPregunta;
                            this.IDEncuesta = Datos.IDEncuesta;
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            Response.Redirect("frmPorcentajePreguntaGrid.aspx?op=5&id=" + Datos.IDPregunta.ToString() + "&id2=" + Datos.IDEncuesta.ToString(), false);
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