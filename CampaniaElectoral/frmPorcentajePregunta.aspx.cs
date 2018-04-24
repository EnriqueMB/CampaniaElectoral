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
    public partial class frmPorcentajePregunta : System.Web.UI.Page
    {
        public string IDPregunta;
        public string IDEncuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            string IDPregu = Request.QueryString["id2"].ToString();
                            this.IDPregunta = IDPregu;
                            string IDEncu = Request.QueryString["id3"].ToString();
                            this.IDEncuesta = IDEncu;
                            //Obtener los datos y dibujarlos.
                            RR_NuevaRespuesta DatosAux = new RR_NuevaRespuesta { Conexion = Comun.Conexion, IDRespuesta = ID, IDPregunta = IDPregu, IDEncuesta = IDEncu };
                            RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                            CN.ObtenerDetalleRespuestasXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                //Ocurrió un error 
                                Response.Redirect("frmPorcentajePreguntaGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas", false);
                    }
                    else if (Request.QueryString["op"] == "1")
                    {
                        if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null )
                        {
                            string ID = Request.QueryString["id"].ToString();
                            this.IDPregunta = ID.ToString();
                            string ID2 = Request.QueryString["id2"].ToString();
                            this.IDEncuesta = ID2.ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                this.IDEncuesta = ID2.ToString();
                                hf3.Value = ID2.ToString();
                                this.IDPregunta = ID.ToString();
                                hf2.Value = ID.ToString();
                            }
                            else
                            {
                                Response.Redirect("frmPorcentajePregunta.aspx?op=0&id=" + this.IDPregunta.ToString(), false);
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas", false);
                    }
                    else
                        Response.Redirect("frmEncuestas", false);
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
                    string Descp = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    int Orden = 0;
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtOrden"].ToString(), out Orden);
                    string Color = Request.Form["ctl00$cph_MasterBody$txtColor"].ToString();
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        string AuxIDPregunta = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                        string AuxIDEncuesta = Request.Form["ctl00$cph_MasterBody$hf3"].ToString();
                        //IDColaborador = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(AuxID);
                        this.Guardar(NuevoRegistro, AuxID, AuxIDPregunta, AuxIDEncuesta, Descp, Color, Orden);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }
        #region Metodo

        private void CargarDatos(RR_NuevaRespuesta DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDRespuesta;
                hf2.Value = DatosAux.IDPregunta;
                txtOrden.Value = Convert.ToString(DatosAux.Orden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool Nuevoregistro, string IDPor, string IDPre, string IDEncuesta, string Descripcion, string Color, int Orden)
        {
            try
            {
                EM_PorcentajePregunta Datos = new EM_PorcentajePregunta()
                {
                    NuevoRegistro = Nuevoregistro,
                    IDPorcentaje = IDPor,
                    IDPregunta = IDPre,
                    IDEncuesta = IDEncuesta,
                    Descripcion = Descripcion,
                    Color = Color,
                    Orden = Orden,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_PorcentajePreguntaNegocio CN = new EM_PorcentajePreguntaNegocio();
                CN.ACPorcentajeP(Datos);
                if (Datos.Completado)
                {
                    this.IDEncuesta = Datos.IDEncuesta;
                    this.IDPregunta = Datos.IDPregunta;
                    hf2.Value = Datos.IDPregunta;
                   
                    Response.Redirect("frmPorcentajePreguntaGrid.aspx?op=5&id=" + Datos.IDPregunta.ToString() + "&id2=" + Datos.IDEncuesta.ToString(), false);
                }
                else
                {
                    if (Datos.Resultado == 3)
                    {
                        this.IDEncuesta = Datos.IDEncuesta;
                        this.IDPregunta = Datos.IDPregunta;
                        hf2.Value = Datos.IDPregunta;
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "El número de orden ya exite para esté porcentaje.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else if (Datos.Resultado == 2)
                    {
                        this.IDEncuesta = Datos.IDEncuesta;
                        this.IDPregunta = Datos.IDPregunta;
                        hf2.Value = Datos.IDPregunta;
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Verifique número de orden ya exite para esté porcentaje.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else
                    {
                        this.IDEncuesta = Datos.IDEncuesta;
                        this.IDPregunta = Datos.IDPregunta;
                        hf2.Value = Datos.IDPregunta;
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
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
                hf.Value = "-1";
                hf.Value = string.Empty;
                txtDescripcion.Value = string.Empty;
                txtOrden.Value = string.Empty;
                txtColor.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}