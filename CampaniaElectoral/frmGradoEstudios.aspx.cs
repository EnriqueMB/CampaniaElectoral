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
    public partial class frmGradoEstudios : System.Web.UI.Page
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
                                RR_GradoEstudios DatosAux = new RR_GradoEstudios() { Conexion = Comun.Conexion, IDGradoEstudios = ID };
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmGradoEstudiosGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmGradoEstudiosGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmGradoEstudiosGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmGradoEstudiosGrid.aspx?errorMessage=3");
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
                if (Request.Form.Count == 6)
                {
                   string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    
                    int IDGradoEstudios = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDGradoEstudios);
                        bool NuevoRegistro = !(IDGradoEstudios > 0);
                        this.Guardar(NuevoRegistro, IDGradoEstudios, txtDescripcion);
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
        private void CargarDatos(RR_GradoEstudios DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDGradoEstudios.ToString();
                txtDescripcion.Value = DatosAux.Descripcion.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegistro, int id, string desc)
        {
            try
            {
                RR_GradoEstudios Datos = new RR_GradoEstudios
                {
                    NuevoRegistro = nuevoRegistro,
                    IDGradoEstudios = id,
                    Descripcion = desc,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoGradoEstudios(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmGradoEstudiosGrid.aspx", false);
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