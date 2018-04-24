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
    public partial class frmNuevaRespuestas : System.Web.UI.Page
    {
        public string IDPregunta;
        public string IDEncuesta;
        public int IDTipoPregunta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null && Request.QueryString["id4"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            string IDPregu = Request.QueryString["id2"].ToString();
                            this.IDPregunta = IDPregu;
                            string IDEncu = Request.QueryString["id3"].ToString();
                            this.IDEncuesta = IDEncu;
                            int.TryParse(Request.QueryString["id4"].ToString(), out IDTipoPregunta);
                            //Obtener los datos y dibujarlos.
                            RR_NuevaRespuesta DatosAux = new RR_NuevaRespuesta { Conexion = Comun.Conexion, IDRespuesta = ID, IDPregunta = IDPregu, IDEncuesta = IDEncu, IDTipoPre = IDTipoPregunta };
                            RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                            CN.ObtenerDetalleRespuestasXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                //Ocurrió un error 
                                Response.Redirect("frmNuevaPreguntaGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas", false);
                    }
                    else if (Request.QueryString["op"] == "1")
                    {
                        if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null && Request.QueryString["id3"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            this.IDPregunta = ID.ToString();
                            string ID2 = Request.QueryString["id2"].ToString();
                            this.IDEncuesta = ID2.ToString();
                            int.TryParse(Request.QueryString["id3"].ToString(), out IDTipoPregunta);
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                this.IDEncuesta = ID2.ToString();
                                hf3.Value = ID2.ToString();
                                this.IDPregunta = ID.ToString();
                                hf2.Value = ID.ToString();
                                hf4.Value = Convert.ToString(IDTipoPregunta.ToString());
                            }
                            else
                            {
                                Response.Redirect("frmPreguntas.aspx?op=0&id=" + this.IDPregunta.ToString(), false);
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
                if (Request.Form.Count == 12)
                {
                    string ClavRespuesta = Request.Form["ctl00$cph_MasterBody$txtClaveRespuesta"].ToString();
                    string respuesta = Request.Form["ctl00$cph_MasterBody$txtRespuesta"].ToString();
                    int Orden = 0;
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtOrden"].ToString(),out Orden);
                    Boolean cmbEsMapa;
                    bool.TryParse(Request.Form["CmbGrafica"].ToString(), out cmbEsMapa);
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        string AuxIDPRegunta = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                        string AuxIDEncuesta = Request.Form["ctl00$cph_MasterBody$hf3"].ToString();
                        int.TryParse(Request.Form["ctl00$cph_MasterBody$hf4"].ToString(), out IDTipoPregunta);
                        //IDColaborador = AuxID;
                        bool NuevoRegistro = AuxID == "";
                        this.Guardar(NuevoRegistro, AuxID, AuxIDPRegunta, respuesta, ClavRespuesta, cmbEsMapa, Orden, AuxIDEncuesta);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
                else if (Request.Form.Count == 11)
                {
                    string ClavRespuesta = "";
                    string respuesta = Request.Form["ctl00$cph_MasterBody$txtRespuestas"].ToString();
                    int Orden = 0;
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtOrdens"].ToString(), out Orden);
                    Boolean cmbEsMapa;
                    bool.TryParse(Request.Form["CmbGraficas"].ToString(), out cmbEsMapa);
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        string AuxIDPRegunta = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                        string AuxIDEncuesta = Request.Form["ctl00$cph_MasterBody$hf3"].ToString();
                        int.TryParse(Request.Form["ctl00$cph_MasterBody$hf4"].ToString(), out IDTipoPregunta);
                        //IDColaborador = AuxID;
                        bool NuevoRegistro = AuxID == "";
                        this.Guardar(NuevoRegistro, AuxID, AuxIDPRegunta, respuesta, ClavRespuesta, cmbEsMapa, Orden, AuxIDEncuesta);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }


        private void CargarDatos(RR_NuevaRespuesta DatosAux)
            {
                try
                {
                    if (DatosAux.IDTipoPre == 1)
                    {
                        hf.Value = DatosAux.IDRespuesta;
                        hf2.Value = DatosAux.IDPregunta;
                        hf3.Value = DatosAux.IDEncuesta;
                        hf4.Value = Convert.ToString(DatosAux.IDTipoPre.ToString());
                        txtClaveRespuesta.Value = DatosAux.ClvRespuesta;
                        txtRespuesta.Value = DatosAux.Respuesta;
                        txtOrden.Value = Convert.ToString(DatosAux.Orden);
                        if (DatosAux.EsMapa == true)
                        {
                            string ScriptError = @"
                            $( function($){ 
                                document.getElementById('CmbGrafica').value='true';
                            });";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = @"
                            $( function($){ 
                                document.getElementById('CmbGrafica').value='false';
                            });";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        Response.Cookies.Clear();
                    }
                    else
                    {
                        hf.Value = DatosAux.IDRespuesta;
                        hf2.Value = DatosAux.IDPregunta;
                        hf3.Value = DatosAux.IDEncuesta;
                        hf4.Value = Convert.ToString(DatosAux.IDTipoPre.ToString());
                        txtRespuestas.Value = DatosAux.Respuesta;
                        txtOrdens.Value = Convert.ToString(DatosAux.Orden);
                        if (DatosAux.EsMapa == true)
                        {
                            string ScriptError = @"
                            $( function($){ 
                                document.getElementById('CmbGraficas').value='true';
                            });";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = @"
                            $( function($){ 
                                document.getElementById('CmbGraficas').value='false';
                            });";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        Response.Cookies.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        private void Guardar(bool Nuevoregistro, string IdRespuesta, string IDPre, string respuesa, string Clave, bool Grafica, int Orden, string IDEncuestas)
            {
                try
                {
                    RR_NuevaRespuesta Datos = new RR_NuevaRespuesta()
                    {
                        NuevoRegistro    = Nuevoregistro,                        
                        IDRespuesta      = IdRespuesta,
                        IDPregunta       = IDPre,
                        ClvRespuesta     = Clave,
                        Respuesta        = respuesa,
                        EsMapa           = Grafica,
                        Resultado        = Orden,
                        IDEncuesta       = IDEncuestas,
                        Conexion         = Comun.Conexion,
                        IDUsuario        = Comun.IDUsuario
                    };
                    RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                    CN.ACRespuestas(Datos);
                    if (Datos.Completado)
                    {
                        this.IDEncuesta = Datos.IDEncuesta;
                        hf3.Value = Datos.IDEncuesta;
                        this.IDPregunta = Datos.IDPregunta;
                        hf2.Value = Datos.IDPregunta;
                        hf4.Value = Convert.ToString(this.IDTipoPregunta.ToString());
                        Response.Redirect("frmNuevaRespuestaGrid.aspx?op=0&id=" + Datos.IDPregunta.ToString() + "&id2=" + Datos.IDEncuesta.ToString() + "&id3=" + this.IDTipoPregunta, false);
                    }
                    else
                    {
                        if (Datos.Resultado == 3)
                        {
                            this.IDEncuesta = Datos.IDEncuesta;
                            hf3.Value = Datos.IDEncuesta;
                            this.IDPregunta = Datos.IDPregunta;
                            hf2.Value = Datos.IDPregunta;
                            hf4.Value = Convert.ToString(this.IDTipoPregunta.ToString());
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "El número de orden ya exite para la pregunta", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else if (Datos.Resultado == 2)
                        {
                            this.IDEncuesta = Datos.IDEncuesta;
                            hf3.Value = Datos.IDEncuesta;
                            this.IDPregunta = Datos.IDPregunta;
                            hf2.Value = Datos.IDPregunta;
                            hf4.Value = Convert.ToString(this.IDTipoPregunta.ToString());
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Verifique número de orden ya exite para esta pregunta.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            this.IDEncuesta = Datos.IDEncuesta;
                            hf3.Value = Datos.IDEncuesta;
                            this.IDPregunta = Datos.IDPregunta;
                            hf2.Value = Datos.IDPregunta;
                            hf4.Value = Convert.ToString(this.IDTipoPregunta.ToString());
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
                    hf3.Value = string.Empty;
                    hf4.Value = string.Empty;
                    txtRespuesta.Value = string.Empty;
                    txtClaveRespuesta.Value = string.Empty;                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }        
    }
}