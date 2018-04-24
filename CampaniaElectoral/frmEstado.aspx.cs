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
    public partial class frmEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            int ID = 0;
                            if (int.TryParse(Request.QueryString["id"].ToString(), out ID))
                            {
                                //Obtener los datos y dibujarlos.
                                CH_Estados DatosAux = new CH_Estados { Conexion = Comun.Conexion, IDEstado = ID };
                                EM_EstadoNegocio EN = new EM_EstadoNegocio();
                                EN.ObtenerEstadoDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmEstadoGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmEstadoGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmEstadoGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmEstadoGrid.aspx?errorMessage=3");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                //Page.Validate();
                //if (IsValid)
                //{
                if (Request.Form.Count == 7)
                {
                    string txtNombeEstado = Request.Form["ctl00$cph_MasterBody$txtEstado"].ToString();
                    string txtSigla = Request.Form["ctl00$cph_MasterBody$txtSigla"].ToString();
                    int IDEstado = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDEstado);
                        bool NuevoRegistro = !(IDEstado > 0);
                        this.Guardar(NuevoRegistro, IDEstado, txtNombeEstado, txtSigla);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                    //}
                }
            }
        }
        #region Métodos

        private void CargarDatos(CH_Estados DatosAux)
        {
            try
            {
                this.hf.Value = DatosAux.IDEstado.ToString();
                this.txtEstado.Value = DatosAux.EstadoDesc;
                this.txtSigla.Value = DatosAux.Siglas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string NombreEstado, string Siglas)
        {
            try
            {
                CH_Estados Datos = new CH_Estados
                {
                    NuevoRegistro = NuevoRegistro,
                    IDEstado = ID,
                    EstadoDesc = NombreEstado,
                    Siglas = Siglas,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_EstadoNegocio EN = new EM_EstadoNegocio();
                EN.ACEstado(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmEstadoGrid.aspx", false);
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
                this.hf.Value = "-1";
                this.txtEstado.Value = string.Empty;
                this.txtSigla.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}