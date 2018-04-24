using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmStatusProyecto : System.Web.UI.Page
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
                                RR_StatusProyecto DatosAux = new RR_StatusProyecto() { Conexion = Comun.Conexion, IDProyecto = ID };
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleStatusProyectoXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmStatusProyectoGrid.aspx?errorMessage="+ DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmStatusProyectoGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmStatusProyectoGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmStatusProyectoGrid.aspx?errorMessage=3");
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
                   string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                   string txtColor = Request.Form["ctl00$cph_MasterBody$txtColor"].ToString();

                    int IDStatusPro = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDStatusPro);
                        bool NuevoRegistro = !(IDStatusPro > 0);
                        this.Guardar(NuevoRegistro, IDStatusPro, txtDescripcion, txtColor);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                    //}
                }
            }
        }
        #region Metodos
        private void CargarDatos(RR_StatusProyecto DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDProyecto.ToString();
                txtDescripcion.Value = DatosAux.Descripcion.ToString();
                txtColor.Value = DatosAux.ColorStatus;
                PanelColor.Attributes.Add("data-color", DatosAux.ColorStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegistro, int id, string desc, string color)
        {
            try
            {
                RR_StatusProyecto Datos = new RR_StatusProyecto
                {
                    NuevoRegistro = nuevoRegistro,
                    IDProyecto = id,
                    Descripcion = desc,
                    ColorStatus = color,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoStatusProyecto(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmStatusProyectoGrid.aspx", false);
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
                hf.Value = "-1";
                txtDescripcion.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}