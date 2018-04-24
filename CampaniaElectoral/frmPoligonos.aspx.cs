using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmPoligonos : System.Web.UI.Page
    {
        public List<CH_Estados> ListaEstado = new List<CH_Estados>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarComboEstado();
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            CH_Poligono DatosAux = new CH_Poligono { Conexion = Comun.Conexion, IDPoligono = ID };
                            CH_PoligonoNegocio CN = new CH_PoligonoNegocio();
                            CN.ObtenerDetallePoligonoXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                //Ocurrió un error
                                Response.Redirect("frmPoligonosGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmPoligonosGrid.aspx");
                    }
                    else
                        Response.Redirect("frmPoligonosGrid.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count > 0)
                {

                    string txtNombre = Request.Form["ctl00$cph_MasterBody$txtNombrePoligono"].ToString();
                    string txtClave = Request.Form["ctl00$cph_MasterBody$txtClave"].ToString();
                    string Estado = Request.Form["cmbEstado"].ToString();
                    string Municipio = Request.Form["cmbMunicipio"].ToString();
                    int IDEstado = 0, IDMunicipio = 0;
                    int.TryParse(Estado, out IDEstado);
                    int.TryParse(Municipio, out IDMunicipio);
                    string Colonia = Request.Form["ctl00$cph_MasterBody$txtColonia"].ToString();
                    string sLatitud = Request.Form["ctl00$cph_MasterBody$txtLatitud"].ToString();
                    string sLongitud = Request.Form["ctl00$cph_MasterBody$txtLongitud"].ToString();
                    double Latitud = 0, Longitud = 0;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    double.TryParse(sLatitud, NumberStyles.Currency, esMX, out Latitud);
                    double.TryParse(sLongitud, NumberStyles.Currency, esMX, out Longitud);
                    //Latitud = Convert.ToDouble(sLatitud);
                    //Longitud = Convert.ToDouble(sLongitud);

                    //decimal Aux01 = 0, aux02 = 0;
                    //decimal.TryParse(sLatitud, NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux01);
                    //decimal.TryParse(sLongitud, NumberStyles.Currency, CultureInfo.CurrentCulture, out aux02);

                    //Latitud = (double)Aux01;
                    //Longitud = (double)aux02;
                    string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    bool NuevoRegistro = string.IsNullOrEmpty(AuxID);
                    this.Guardar(NuevoRegistro, AuxID, txtNombre, txtClave, IDEstado, IDMunicipio, Colonia, Latitud, Longitud);
                    
                }
            }
        }

        #region Métodos

        private void CargarDatos(CH_Poligono DatosAux)
        {
            try
            {
                string Aux01 = DatosAux.Latidud.ToString().Replace(",", ".");
                string Aux02 = DatosAux.Longitud.ToString().Replace(",", ".");
                string ScriptError =
                @"   jQuery(document).ready(function() {
                        document.getElementById('cmbEstado').value=" + DatosAux.IDEstado + @";
                        $('#cmbEstado').trigger('change');
                        $('#cmbMunicipio option[value="+ DatosAux.IDMunicipio + @"]').attr('selected',true);
                        Maps.init(false," + Aux01 + ", " + Aux02 + @");
                            console.log(" + Aux01 + ", " + Aux02 + @")
                        });";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);

                hf.Value = DatosAux.IDPoligono;
                txtNombrePoligono.Value = DatosAux.Nombre;
                txtClave.Value = DatosAux.Clave;
                txtColonia.Value = DatosAux.Colonia;
                txtLatitud.Value = DatosAux.Latidud.ToString();
                txtLongitud.Value = DatosAux.Longitud.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void Guardar(bool _NuevoRegistro, string _ID, string _Nombre, string _Clave, int _IDEstado, int _IDMunicipio, string _Colonia, double _Latitud, double _Longitud)
        {
            try
            {
                CH_Poligono Datos = new CH_Poligono
                {
                    NuevoRegistro = _NuevoRegistro,
                    IDPoligono = _ID,
                    Nombre = _Nombre,
                    Clave = _Clave,
                    IDEstado = _IDEstado,
                    IDMunicipio = _IDMunicipio,
                    Colonia = _Colonia,
                    Latidud = _Latitud,
                    Longitud = _Longitud,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                CH_PoligonoNegocio PolN = new CH_PoligonoNegocio();
                PolN.ACPoligono(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmPoligonosGrid.aspx", false);
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
                hf.Value = string.Empty;
                txtNombrePoligono.Value = string.Empty;
                txtClave.Value = string.Empty;
                txtColonia.Value = string.Empty;
                txtLatitud.Value = string.Empty;
                txtLongitud.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboEstado()
        {
            CH_Estados Datos = new CH_Estados() { Conexion = Comun.Conexion };
            EM_EstadoNegocio EN = new EM_EstadoNegocio();
            ListaEstado = EN.ObtenerComboEstados(Datos);
        }

        #endregion
    }
}