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
    public partial class frmNuevoGastos : System.Web.UI.Page
    {
        public List<EM_CatColaborador> ListaColaborador = new List<EM_CatColaborador>();
        public int IDTipoUsuario = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            InciarFormulario();
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
                                EM_Gastos DatosAux = new EM_Gastos { Conexion = Comun.Conexion, IDGastos = ID };
                                EM_GastosNegocio CN = new EM_GastosNegocio();
                                CN.ObtenerDetalleGastosXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmGastosGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmGastosGrid.aspx", false);
                            }
                        }
                        else
                            Response.Redirect("frmGastosGrid.aspx", false);
                    }
                    else
                        Response.Redirect("frmGastosGrid.aspx", false);
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
                    string txtNomb = Request.Form["ctl00$cph_MasterBody$txtGastos"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    decimal Monto;
                    decimal.TryParse(Request.Form["ctl00$cph_MasterBody$txtMonto"].ToString(), out Monto);
                    string IDColaboradorAux = Request.Form["cmbEncargado"].ToString();
                    string IDGastos = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDGastos = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDGastos);
                        this.Guardar(NuevoRegistro, IDGastos, txtNomb, txtDescripcion, Monto, IDColaboradorAux);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
                else if (Request.Form.Count == 10)
                {
                    string txtNomb = Request.Form["ctl00$cph_MasterBody$txtGastos"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    decimal Monto;
                    decimal.TryParse(Request.Form["ctl00$cph_MasterBody$txtMonto"].ToString(), out Monto);
                    string IDColaboradorAux = Request.Form["ctl00$cph_MasterBody$hf2"].ToString();
                    string Vacio = Request.Form["ctl00$cph_MasterBody$hf3"].ToString();
                    string IDGastos = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDGastos = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDGastos);
                        this.Guardar(NuevoRegistro, IDGastos, txtNomb, txtDescripcion, Monto, IDColaboradorAux);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }
        #region Métodos
        public void CargarComboColaboradores()
        {
            try
            {
                EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaColaborador = GN.ObtenerComboColaboradores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatos(EM_Gastos DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDGastos.ToString();
                txtGastos.Value = DatosAux.Nombre.ToString();
                txtDescripcion.Value = DatosAux.Descripcion.ToString();
                txtMonto.Value = DatosAux.Monto.ToString();
                if (this.IDTipoUsuario == 1 || this.IDTipoUsuario == 3)
                {
                    string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('cmbEncargado').value='" + DatosAux.IDResponsable + @"';
                    });";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else
                {
                    hf2.Value = DatosAux.IDResponsable.ToString();
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string Nombre, string Descrip, decimal monto, string IDColaboradorAux)
        {
            try
            {
                EM_Gastos Datos = new EM_Gastos
                {
                    NuevoRegistro = NuevoRegistro,
                    IDGastos = ID,
                    IDMotivo = 0,
                    IDSubMotivo = 0,
                    Nombre = Nombre,
                    Descripcion = Descrip,
                    Monto = monto,
                    IDResponsable = IDColaboradorAux,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                EM_GastosNegocio EN = new EM_GastosNegocio();
                EN.ACGastos(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmGastosGrid.aspx", false);
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
                hf3.Value = "";
                txtGastos.Value = string.Empty;
                txtDescripcion.Value = string.Empty;
                txtMonto.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InciarFormulario()
        {
            try
            {
                EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion, IDUsuario = User.Identity.Name };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                GN.ObtenerTipoUserLogeado(Datos);
                if (Datos.IDTipoUsu == 1 || Datos.IDTipoUsu == 3)
                {
                    this.IDTipoUsuario = Datos.IDTipoUsu;
                    this.CargarComboColaboradores();
                }
                else
                {
                    this.hf2.Value = User.Identity.Name;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}