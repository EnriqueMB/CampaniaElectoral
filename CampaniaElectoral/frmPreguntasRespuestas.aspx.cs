using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmPreguntasRespuestas : System.Web.UI.Page
    {
        public string NombreEncuesta;
        public List<EM_Preguntas> ListaPregunta = new List<EM_Preguntas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "5")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        EM_Encuesta Datos = new EM_Encuesta { Conexion = Comun.Conexion, IDEncuesta = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_PreguntaRespuestaNegocio CN = new EM_PreguntaRespuestaNegocio();
                        CN.ObtenerEncueestass(Datos);
                        this.NombreEncuesta = Datos.NombreEncuesta;
                        this.ListaPregunta = Datos.ListaPregunta;
                        txtFolioEncuesta.Value = Datos.NombreEncuesta;
                        hf.Value = Datos.IDEncuesta;
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
            else
            {
                if (Request.Form.Count > 0)
                {
                    DataTable TablaRespuestas = new DataTable();
                    TablaRespuestas.Columns.Add("IDPregunta", typeof(string));
                    TablaRespuestas.Columns.Add("IDRespuesta", typeof(string));
                    string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    String [] Cadena = Request.Form.AllKeys;
                    for (int i = 1; i < Cadena.Length; i++)
                    {
                        if (Cadena[i].Length > 3)
                        {
                            string BeginText = Cadena[i].Substring(0, 3);
                            if (BeginText.Equals("cmb") || BeginText.Equals("txt"))
                            {
                                string IDPregunta = Cadena[i].Substring(3, Cadena[i].Length - 3);
                                string Respuesta = Request.Form[Cadena[i]].ToString();
                                TablaRespuestas.Rows.Add(new Object[] { IDPregunta, Respuesta });
                            }
                        }
                    }
                     Guardar(AuxID, TablaRespuestas);
                }
            }
        }

        private void Guardar(string ID, DataTable Tabla)
        {
            try
            {
                RR_NuevaRespuesta Datos = new RR_NuevaRespuesta
                {
                    IDEncuesta = ID,
                    TablaDatos = Tabla,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                RR_CatalogosNegocio EN = new RR_CatalogosNegocio();
                EN.AEncuestaContestadas(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmRespuestaEncuestaGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error el guardar los datos", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}