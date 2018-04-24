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
    public partial class frmDatosContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CH_Contacto DatosAux = new CH_Contacto { Conexion = Comun.Conexion };
                CH_ContactoNegocio CN = new CH_ContactoNegocio();
                CN.ObtenerDatosContacto(DatosAux);
                if(DatosAux.Completado)
                {
                    CargarDatos(DatosAux);
                }
                else
                {
                    IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count > 0)
                {
                    string Telefonos = Request.Form["ctl00$cph_MasterBody$txtTelefonos"].ToString();
                    CultureInfo esMX = new CultureInfo("es-MX");
                    double Latitud = 0, Longitud = 0;
                    double.TryParse(Request.Form["ctl00$cph_MasterBody$hfLatitud"].ToString().Replace(",", "."), NumberStyles.Currency, esMX, out Latitud);
                    double.TryParse(Request.Form["ctl00$cph_MasterBody$hfLongitud"].ToString().Replace(",", "."), NumberStyles.Currency, esMX, out Longitud);
                    string Direccion = Request.Form["ctl00$cph_MasterBody$address"].ToString();
                    string Correo = Request.Form["ctl00$cph_MasterBody$txtCorreo"].ToString();
                    string Texto = Request.Form["ctl00$cph_MasterBody$txtTexto"].ToString();
                    string Titulo = Request.Form["ctl00$cph_MasterBody$txtTitulo"].ToString();
                    this.GuardarDatos(Telefonos, Direccion, Correo, Latitud, Longitud, Titulo, Texto);
                }
            }
        }


        private void CargarDatos(CH_Contacto DatosAux)
        {
            try
            {
                string Aux01 = DatosAux.Latitud.ToString().Replace(",", ".");
                string Aux02 = DatosAux.Longitud.ToString().Replace(",", ".");
                string ScriptError =
                @"   jQuery(document).ready(function() {
                        Maps.init(false," + Aux01 + ", " + Aux02 + @");
                            console.log(" + Aux01 + ", " + Aux02 + @")
                        });";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);

                txtCorreo.Value = DatosAux.Correo;
                txtTelefonos.Value = DatosAux.Telefono;
                address.Value = DatosAux.Direccion;
                txtTitulo.Value = DatosAux.TituloContacto;
                txtTexto.Value = DatosAux.TextoContacto;
                hfLatitud.Value = DatosAux.Latitud.ToString();
                hfLongitud.Value = DatosAux.Longitud.ToString();
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
                txtCorreo.Value = string.Empty;
                txtTelefonos.Value = string.Empty;
                txtTitulo.Value = string.Empty;
                txtTexto.Value = string.Empty;
                address.Value = string.Empty;
                hfLatitud.Value = string.Empty;
                hfLongitud.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void GuardarDatos(string _Telefonos, string _Direccion, string _Correo, double _Latitud, double _Longitud, string _Titulo, string _Texto)
        {
            try
            {
                CH_Contacto DatosAux = new CH_Contacto
                    { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario, Telefono = _Telefonos,
                    Direccion = _Direccion, Correo = _Correo, Latitud = _Latitud, Longitud = _Longitud,
                    TituloContacto = _Titulo, TextoContacto = _Texto};
                CH_ContactoNegocio CN = new CH_ContactoNegocio();
                CN.AC_DatosDeContacto(DatosAux);
                if (DatosAux.Completado)
                {
                    string Aux01 = DatosAux.Latitud.ToString().Replace(",", ".");
                    string Aux02 = DatosAux.Longitud.ToString().Replace(",", ".");
                    string ScriptError =
                    @"   jQuery(document).ready(function() {
                        Maps.init(false," + Aux01 + ", " + Aux02 + @");
                            console.log(" + Aux01 + ", " + Aux02 + @")
                        });";
                    ScriptError += DialogMessage.Show(TipoMensaje.Success, "Datos actualizados.", "Confirmaci&oacute;n", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    //Response.Redirect("frmDatosContacto.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}