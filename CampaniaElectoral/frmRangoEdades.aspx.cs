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
    public partial class frmRangoEdades : System.Web.UI.Page
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
                                EM_RangoEdad DatosAux = new EM_RangoEdad { Conexion = Comun.Conexion, IDEdad = ID };
                                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                                CN.ObtenerRangoDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmRangoEdadesGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmRangoEdadesGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmRangoEdadesGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmRangoEdadesGrid.aspx?errorMessage=3");
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
                if (Request.Form.Count == 8)
                {
                    string txtDesc = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    int txtEdadInicial = Convert.ToInt32(Request.Form["ctl00$cph_MasterBody$txtEdadInicial"].ToString());
                    int txtEdadFin = Convert.ToInt32(Request.Form["ctl00$cph_MasterBody$txtEdadFin"].ToString());
                    int IDGenero = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDGenero);
                        bool NuevoRegistro = !(IDGenero > 0);
                        this.Guardar(NuevoRegistro, IDGenero, txtDesc, txtEdadInicial, txtEdadFin);
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

        private void CargarDatos(EM_RangoEdad DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                this.hf.Value = DatosAux.IDEdad.ToString();
                this.txtDescripcion.Value = DatosAux.Descripcion;
                this.txtEdadInicial.Value = Convert.ToString(DatosAux.EdadInicio);
                this.txtEdadFin.Value = Convert.ToString(DatosAux.EdadFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Descripcion, int EdadI, int EdadF)
        {
            try
            {
                EM_RangoEdad Datos = new EM_RangoEdad
                {
                    NuevoRegistro = NuevoRegistro,
                    IDEdad = ID,
                    Descripcion = Descripcion,
                    EdadInicio = EdadI,
                    EdadFin = EdadF,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoRangoEdad(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmRangoEdadesGrid.aspx", false);
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
                this.hf.Value = "-1";
                this.txtDescripcion.Value = string.Empty;
                this.txtEdadFin.Value = string.Empty;
                this.txtEdadInicial.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}