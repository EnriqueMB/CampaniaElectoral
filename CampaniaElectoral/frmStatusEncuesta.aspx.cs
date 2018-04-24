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
    public partial class frmStatusEncuesta : System.Web.UI.Page
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
                                RR_StatusEncuestas DatosAux =
                                    new RR_StatusEncuestas {Conexion = Comun.Conexion, IDEncuesta = ID};
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleStatusEncuestaXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmStatusEncuestaGrid.aspx?errorMessage="+ DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmStatusEncuestaGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmStatusEncuestaGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmStatusEncuestaGrid.aspx?errorMessage=3");
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
                    string txtDescr = Request.Form["ctl00$cph_MasterBody$txtDesc"].ToString();
                    string txtstatus = Request.Form["ctl00$cph_MasterBody$txtStatus"].ToString();
                    int IDColab = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDColab);
                        bool NuevoRegistro = !(IDColab > 0);
                        this.Guardar(NuevoRegistro, IDColab, txtDescr, txtstatus);
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

        private void CargarDatos(RR_StatusEncuestas DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDEncuesta.ToString();
                txtDesc.Value = DatosAux.Descripcion;
                txtStatus.Value = DatosAux.ColorStatus;
                PanelColor.Attributes.Add("data-color", DatosAux.ColorStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Descripcion, string status)
        {
            try
            {
                RR_StatusEncuestas Datos = new RR_StatusEncuestas
                {
                    NuevoRegistro = NuevoRegistro,
                    IDEncuesta = ID,
                    Descripcion = Descripcion,
                    ColorStatus = status,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoStatusEncuesta(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmStatusEncuestaGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error",
                        ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
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
                hf.Value = "-1";
                txtDesc.Value = string.Empty;
                txtStatus.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            #endregion
        }
    }
}