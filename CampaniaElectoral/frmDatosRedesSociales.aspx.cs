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
    public partial class frmDatosRedesSociales : System.Web.UI.Page
    {
        public List<RR_DatosRedesSociales> ListaRedesSoc = new List<RR_DatosRedesSociales>();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                CargarComboRedes();
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID;
                            if (Request.QueryString["id"].ToString() != string.Empty)
                            {
                                ID = Request.QueryString["id"].ToString();
                                //Obtener los datos y dibujarlos.
                                RR_DatosRedesSociales DatosAux = new RR_DatosRedesSociales { Conexion = Comun.Conexion, IDRedSocial = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ObtenerRedesSocXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmDatosRedesSocialesGrid.aspx?errorMessage=" + DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmDatosRedesSocialesGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmDatosRedesSocialesGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmDatosRedesSocialesGrid.aspx?errorMessage=3");
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
                    string Cuenta = Request.Form["ctl00$cph_MasterBody$txtCuenta"].ToString();                    
                    int redSocial = Convert.ToInt32(Request.Form["cmbRedSocial"].ToString());
                    //int cmbPartido = 0;
                    //int.TryParse(Request.Form["cmbPartidos"].ToString(), out cmbPartido);
                    int IDColab = 0;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDColab);
                        bool NuevoRegistro = (AuxID == "-1");
                        this.Guardar(NuevoRegistro, AuxID, redSocial, Cuenta);
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

        private void CargarDatos(RR_DatosRedesSociales DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDRedSocial.ToString();
                txtCuenta.Value = DatosAux.Cuenta;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, int idRed, string Cuenta)
        {
            try
            {
                RR_DatosRedesSociales Datos = new RR_DatosRedesSociales
                {
                    NuevoRegistro = NuevoRegistro,
                    IDRedSocial = ID,
                    IDTipoRedSocial = idRed,
                    Cuenta = Cuenta,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACRedesSociales(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmDatosRedesSocialesGrid.aspx", false);
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
                //hf.Value       = BC.Encripta("-1");
                hf.Value = "-1";
                txtCuenta.Value = string.Empty;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarComboRedes()
        {
            RR_DatosRedesSociales Datos = new RR_DatosRedesSociales() { Conexion = Comun.Conexion };
            RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
            ListaRedesSoc = GN.ObtenerComboRedes(Datos);
        }
        #endregion
    }
}