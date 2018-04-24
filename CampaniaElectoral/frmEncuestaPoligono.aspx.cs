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
    public partial class frmEncuestaPoligono : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string ID = Request.QueryString["id"].ToString();
                    CH_Encuesta DatosAux = new CH_Encuesta { Conexion = Comun.Conexion, IDRespuesta = ID };
                    CH_EncuestaNegocio CN = new CH_EncuestaNegocio();
                    CN.ObtenerDatosUbicacionRespuesta(DatosAux);
                    if (DatosAux.Completado)
                    {
                        this.CargarDatos(DatosAux);
                    }
                    else
                    {
                        //Ocurrió un error
                        Response.Redirect("frmRespuestaEncuestaGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                    }
                }
                else
                    Response.Redirect("frmRespuestaEncuestaGrid.aspx");
            }
            else
            {
                if (Request.Form.Count > 0)
                {
                    string IDRespuesta = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    string IDPoligono = Request.Form["ctl00$cph_MasterBody$hfIDPoligono"].ToString();
                    double Latitud = 0, Longitud = 0;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    double.TryParse(Request.Form["ctl00$cph_MasterBody$txtLatitud"].ToString(), NumberStyles.Currency, esMX, out Latitud);
                    double.TryParse(Request.Form["ctl00$cph_MasterBody$txtLongitud"].ToString(), NumberStyles.Currency, esMX, out Longitud);
                    this.Guardar(IDRespuesta, Latitud, Longitud, IDPoligono);
                }
            }
        }

        private void CargarDatos(CH_Encuesta DatosAux)
        {
            try
            {
                //Iniciar el mapa
                string Aux01, Aux02;
                bool Band;
                if (DatosAux.Latitud == 0 && DatosAux.Longitud == 0)
                {
                    Aux01 = DatosAux.LatitudPol.ToString().Replace(",", ".");
                    Aux02 = DatosAux.LongitudPol.ToString().Replace(",", ".");
                    Band = true;
                }
                else
                {
                    Aux01 = DatosAux.Latitud.ToString().Replace(",", ".");
                    Aux02 = DatosAux.Longitud.ToString().Replace(",", ".");
                    Band = false;
                }
                //Si es 0, inicializarlo, sino ejecutar la ubicación por Geolocalización
                string ScriptError =
                @"   jQuery(document).ready(function() {
                        console.log('" + Band.ToString().ToLower() + ", " + Aux01 + ", " + Aux02 + @"');
                        Maps.init('" + Band.ToString().ToLower() + "'," + Aux01 + ", " + Aux02 + @");
                        });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);

                hf.Value = DatosAux.IDRespuesta;
                hfIDPoligono.Value = DatosAux.IDPoligono;
                txtPoligono.Value = DatosAux.PoligonoDesc;
                txtEncuesta.Value = DatosAux.Folio;
                txtLatitud.Value = DatosAux.Latitud != 0 ? Aux01 : string.Empty;
                txtLongitud.Value = DatosAux.Longitud != 0 ? Aux02 : string.Empty;
                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void Guardar(string _ID, double _Latitud, double _Longitud, string IDPoligono)
        {
            try
            {
                CH_Encuesta Datos = new CH_Encuesta
                {
                    IDRespuesta = _ID,
                    Latitud = _Latitud,
                    Longitud = _Longitud,
                    IDPoligono = IDPoligono,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
                EN.AC_UbicacionRespuesta(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmRespuestaEncuestaGrid.aspx", false);
                }
                else
                {
                    string Aux01, Aux02;
                    bool Band;
                    Aux01 = Datos.Latitud.ToString().Replace(",", ".");
                    Aux02 = Datos.Longitud.ToString().Replace(",", ".");
                    Band = false;
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptError +=
                    @"   jQuery(document).ready(function() {
                        console.log('" + Band.ToString().ToLower() + ", " + Aux01 + ", " + Aux02 + @"');
                        Maps.init('" + Band.ToString().ToLower() + "'," + Aux01 + ", " + Aux02 + @");
                        });";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}