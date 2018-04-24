using DllCampElectoral.Negocio;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmStatusAfiliados : System.Web.UI.Page
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
                                EM_StatusAfiliados DatosAux = new EM_StatusAfiliados { Conexion = Comun.Conexion, IDStatusAfiliado = ID };
                                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                                CN.ObtenerStatusEventoDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmStatusAfiliadosGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmStatusAfiliadosGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmStatusAfiliadosGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmStatusAfiliadosGrid.aspx?errorMessage=3");
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
                    string txtDesc = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    string txtColorStatus = Request.Form["ctl00$cph_MasterBody$txtColorStatus"].ToString();
                    int IDstatus = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDstatus);
                        bool NuevoRegistro = !(IDstatus > 0);
                        this.Guardar(NuevoRegistro, IDstatus, txtDesc, txtColorStatus);
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

        private void CargarDatos(EM_StatusAfiliados DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                this.hf.Value = DatosAux.IDStatusAfiliado.ToString();
                this.txtDescripcion.Value = DatosAux.Descripcion;
                this.txtColorStatus.Value = DatosAux.ColorStatus;
                this.PanelColor.Attributes.Add("data-color", DatosAux.ColorStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Descripcion, string Color)
        {
            try
            {
                EM_StatusAfiliados Datos = new EM_StatusAfiliados
                {
                    NuevoRegistro = NuevoRegistro,
                    IDStatusAfiliado = ID,
                    Descripcion = Descripcion,
                    ColorStatus = Color,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoStatusAfiliado(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmStatusAfiliadosGrid.aspx", false);
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
                this.txtDescripcion.Value = string.Empty;
                this.txtColorStatus.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}