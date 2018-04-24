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
    public partial class frmDatosMapa : System.Web.UI.Page
    {
        public string IDEncuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "4")
                    {
                        if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            string ID2 = Request.QueryString["id2"].ToString();
                            this.IDEncuesta = ID2;
                            hf2.Value = ID2.ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                //Obtener los datos y dibujarlos.
                                EM_Preguntas DatosAux = new EM_Preguntas { Conexion = Comun.Conexion, IDPreguntas = ID };
                                EM_PreguntasNegocio CN = new EM_PreguntasNegocio();
                                CN.ObtenerCampoMapaPreguntaXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmDatosMapa.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmEncuestas.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas.aspx");
                    }
                    else
                        Response.Redirect("frmEncuestas.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 10)
                {

                    string txtTituloRespuesta = Request.Form["ctl00$cph_MasterBody$txtTituloRespuesta"].ToString();
                    string txtPeriodoDatos = Request.Form["ctl00$cph_MasterBody$txtPeriodoDatos"].ToString();
                    string txtTituloPorcentaje = Request.Form["ctl00$cph_MasterBody$txtTituloPorcentaje"].ToString();
                    string txtExplicacion = HttpUtility.HtmlDecode(this.txtExplicacion.InnerHtml);
                    string IDPregunta = "";
                    string IDEn = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        string AuxIDEncuesta = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                        IDPregunta = AuxID;
                        IDEn = AuxIDEncuesta;
                        this.Guardar(IDEn, IDPregunta, txtTituloRespuesta, txtPeriodoDatos, txtTituloPorcentaje, txtExplicacion);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }

        #region Métodos

        private void CargarDatos(EM_Preguntas DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDPreguntas.ToString();
                txtTituloRespuesta.Value = DatosAux.TituloRespuesta;
                txtPeriodoDatos.Value = DatosAux.PeriodoDatos;
                txtTituloPorcentaje.Value = DatosAux.TituloPorcentaje;
                txtExplicacion.Value = DatosAux.Explicacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(string ID2, string ID, string Titulores, string periodoDatos, string tituloporcen, string explicacion)
        {
            try
            {
                EM_Preguntas Datos = new EM_Preguntas
                {
                    IDEncuesta = ID2,
                    IDPreguntas = ID,
                    TituloRespuesta = Titulores,
                    PeriodoDatos = periodoDatos,
                    TituloPorcentaje = tituloporcen,
                    Explicacion = explicacion,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                EM_PreguntasNegocio EN = new EM_PreguntasNegocio();
                EN.ActualizarCamposPreguntasXID(Datos);
                if (Datos.Completado)
                {
                    this.IDEncuesta = Datos.IDEncuesta;
                    hf2.Value = Datos.IDEncuesta;
                    Response.Redirect("frmPreguntas.aspx?op=0&id=" + Datos.IDEncuesta, false);
                }
                else
                {
                    this.IDEncuesta = Datos.IDEncuesta;
                    hf2.Value = Datos.IDEncuesta;
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "";
                txtTituloRespuesta.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}