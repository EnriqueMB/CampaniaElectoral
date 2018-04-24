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
    public partial class frmTipoEventoCampania : System.Web.UI.Page
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
                                EM_TipoEventoCampania DatosAux = new EM_TipoEventoCampania { Conexion = Comun.Conexion, IDTipoEventoCampania = ID };
                                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                                CN.ObtenerTipoEventoCampaniaDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmTipoEventoCampaniaGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmTipoEventoCampaniaGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmTipoEventoCampaniaGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmTipoEventoCampaniaGrid.aspx?errorMessage=3");
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
                    string txtDesc = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    int IDTipoEvento = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDTipoEvento);
                        bool NuevoRegistro = !(IDTipoEvento > 0);
                        this.Guardar(NuevoRegistro, IDTipoEvento, txtDesc);
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

        private void CargarDatos(EM_TipoEventoCampania DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDTipoEventoCampania.ToString();
                txtDescripcion.Value = DatosAux.Descripcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Descripcion)
        {
            try
            {
                EM_TipoEventoCampania Datos = new EM_TipoEventoCampania
                {
                    NuevoRegistro = NuevoRegistro,
                    IDTipoEventoCampania = ID,
                    Descripcion = Descripcion,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoTipoEventoCamp(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmTipoEventoCampaniaGrid.aspx", false);
                }
                else
                {
                    //Que aparezca el panel error
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