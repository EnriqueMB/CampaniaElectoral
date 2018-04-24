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
    public partial class frmModuloXTipoUsuario : System.Web.UI.Page
    {
        public  List<RR_TipoUsuarios> Lista = new List<RR_TipoUsuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
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
                                RR_ModuloXTipoUsuario DatosAux = new RR_ModuloXTipoUsuario() { Conexion = Comun.Conexion, IDModuloXTipoU = ID };
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleModuloTipoUsuarioXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmModuloXTipoUsuarioGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmModuloXTipoUsuarioGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmModuloXTipoUsuarioGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmModuloXTipoUsuarioGrid.aspx?errorMessage=3");
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
                    int IDTipoUsuario = Convert.ToInt32(Request.Form["txtusuario"].ToString());
                    int IDModuloXTipoU = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDModuloXTipoU);
                        bool NuevoRegistro = !(IDModuloXTipoU > 0);
                        this.Guardar(NuevoRegistro, IDModuloXTipoU, txtDescripcion, IDTipoUsuario);
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
        private void CargarDatos(RR_ModuloXTipoUsuario DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDModuloXTipoU.ToString();
                txtDescripcion.Value = DatosAux.Descripcion.ToString();
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('form-field-select-3').value=" + DatosAux.IDTipoU + @";
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboBox()
        {
            RR_TipoUsuarios Datos = new RR_TipoUsuarios { Conexion = Comun.Conexion };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            Lista = GN.ObtenerCatalogoTipoUsuario(Datos);
        }

        private void Guardar(bool nuevoRegistro, int id, string desc, int IDTU)
        {
            try
            {
                RR_ModuloXTipoUsuario Datos = new RR_ModuloXTipoUsuario
                {
                    NuevoRegistro = nuevoRegistro,
                    IDModuloXTipoU = id,
                    Descripcion = desc,
                    IDTipoU = IDTU,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoModuloTipoUsuario(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmModuloXTipoUsuarioGrid.aspx", false);
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