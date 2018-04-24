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
    public partial class frmNuevaEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                                EM_Encuesta DatosAux = new EM_Encuesta { Conexion = Comun.Conexion, IDEncuesta = ID };
                                EM_EncuestaNegocio CN = new EM_EncuestaNegocio();
                                CN.ObtenerDetalleEncuestasXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmEncuestas.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmEncuestas.aspx", false);
                            }
                        }
                        else
                            Response.Redirect("frmEncuestas.aspx", false);
                    }
                    else
                        Response.Redirect("frmEncuestas.aspx", false);
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

                    string txtNomb = Request.Form["ctl00$cph_MasterBody$txtNombreEncuesta"].ToString();
                    string txtTituloGenral = Request.Form["ctl00$cph_MasterBody$txtTituloGeneral"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    string txtObservaciones = Request.Form["ctl00$cph_MasterBody$txtObservaciones"].ToString();
                    string IDEncuesta = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDEncuesta = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDEncuesta);
                        this.Guardar(NuevoRegistro, IDEncuesta, txtNomb, txtTituloGenral, txtDescripcion, txtObservaciones);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }
        #region Métodos

        private void CargarDatos(EM_Encuesta DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDEncuesta.ToString();
                txtNombreEncuesta.Value = DatosAux.NombreEncuesta;
                txtTituloGeneral.Value = DatosAux.TituloGeneral;
                txtDescripcion.Value = DatosAux.Descripcion;
                txtObservaciones.Value = DatosAux.Observaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string Nombre, string tituloGeneral, string Descripcion, string Observacion)
        {
            try
            {
                EM_Encuesta Datos = new EM_Encuesta
                {
                    NuevoRegistro       = NuevoRegistro,
                    IDEncuesta          = ID,
                    NombreEncuesta      = Nombre,
                    TituloGeneral       = tituloGeneral,
                    Descripcion         = Descripcion,
                    Observaciones       = Observacion,
                    Conexion            = Comun.Conexion,
                    IDUsuario           = User.Identity.Name
                };
                EM_EncuestaNegocio EN = new EM_EncuestaNegocio();
                EN.ACEncuesta(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmEncuestas.aspx", false);
                }
                else
                {
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
                txtNombreEncuesta.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}