using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
namespace CampaniaElectoral
{
    public partial class frmNuevaPregunta : System.Web.UI.Page
    {
        public List<EC_TipoPregunta> Lista = new List<EC_TipoPregunta>();
        public string IDEncuesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCombo();
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                //Obtener los datos y dibujarlos.
                                EM_Preguntas DatosAux = new EM_Preguntas { Conexion = Comun.Conexion, IDPreguntas = ID };
                                EM_PreguntasNegocio CN = new EM_PreguntasNegocio();
                                CN.ObtenerDetallePreguntasXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.IDEncuesta = DatosAux.IDEncuesta;
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmPreguntas.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmEncuestas", false);
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas");
                    }
                    else if (Request.QueryString["op"] == "1")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                this.IDEncuesta = ID.ToString();
                                hf2.Value = ID.ToString();
                            }
                            else
                            {
                                Response.Redirect("frmPreguntas.aspx?op=0&id=" + this.IDEncuesta.ToString(), false);
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
                if (Request.Form.Count == 9)
                {
                    int IDTipoPregunta = 0, Orden = 0;
                    string txtNomb = Request.Form["ctl00$cph_MasterBody$txtPregunta"].ToString();
                    int.TryParse(Request.Form["cmb_TipoPregunta"].ToString(), out IDTipoPregunta);
                    string IDEncuestas = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtOrden"].ToString(), out Orden);
                    string IDPregunta = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();

                        IDPregunta = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDPregunta);
                        this.Guardar(NuevoRegistro, IDPregunta, IDEncuestas, txtNomb, IDTipoPregunta, Orden);
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
                hf2.Value = DatosAux.IDEncuesta.ToString();
                txtPregunta.Value = DatosAux.NombrePregunta;
                txtOrden.Value = Convert.ToString(DatosAux.Orden.ToString());
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('cmb_TipoPregunta').value=" + DatosAux.IDTipoPregunta + @";
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string IDEncuesta, string Nombre, int IDTipoPRe, int orden)
        {
            try
            {
                EM_Preguntas Datos = new EM_Preguntas
                {
                    NuevoRegistro = NuevoRegistro,
                    IDPreguntas = ID,
                    IDEncuesta = IDEncuesta,
                    NombrePregunta = Nombre,
                    IDTipoPregunta = IDTipoPRe,
                    Orden = orden,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                EM_PreguntasNegocio EN = new EM_PreguntasNegocio();
                EN.ACPreguntas(Datos);
                if (Datos.Completado)
                {
                    this.IDEncuesta = Datos.IDEncuesta.ToString();
                    hf2.Value = Datos.IDEncuesta.ToString();
                    Response.Redirect("frmPreguntas.aspx?op=0&id=" + Datos.IDEncuesta.ToString(), false);
                }
                else
                {
                    if (Datos.Resultado == 3)
                    {
                        this.IDEncuesta = Datos.IDEncuesta.ToString();
                        hf2.Value = Datos.IDEncuesta.ToString();
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "El número de orden ya exite para esta encuestas.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else if (Datos.Resultado == 2)
                    {
                        this.IDEncuesta = Datos.IDEncuesta.ToString();
                        hf2.Value = Datos.IDEncuesta.ToString();
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Verifique número de orden ya exite para esta encuestas.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else 
                    {
                        this.IDEncuesta = Datos.IDEncuesta.ToString();
                        hf2.Value = Datos.IDEncuesta.ToString();
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
                hf.Value = "";
                txtPregunta.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCombo()
        {
            EC_TipoPregunta Datos = new EC_TipoPregunta { Conexion = Comun.Conexion };
            EC_TipoPreguntaNegocio TP = new EC_TipoPreguntaNegocio();
            Lista = TP.CargarCombo(Datos);
        }
        #endregion
        
    }
}