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
    public partial class frmPuntosPoligono : System.Web.UI.Page
    {
        public List<CH_Poligono> Lista = new List<CH_Poligono>();
        public string IDPoligono = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["op"] != null)
                    {
                        if(Request.QueryString["op"] == "3")
                        {
                            string ID = Request.QueryString["id"].ToString();
                            CH_Poligono Punto = new CH_Poligono { IDPunto = ID, Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
                            CH_PoligonoNegocio PolNeg = new CH_PoligonoNegocio();
                            PolNeg.EliminarPuntoPoligonoXID(Punto);
                            IDPoligono = Request.QueryString["idP"].ToString();
                            if (Punto.Completado)
                            {
                                string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Eliminación completa.", "Informacion", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                                Response.Redirect("frmPuntosPoligono.aspx?id=" + this.IDPoligono, true);
                            }
                            else
                            {
                                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al eliminar el registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            }
                        }
                        else
                        {
                            Response.Redirect("frmPoligonosGrid.aspx?error=" + "Parametros incorrectos");
                        }
                    }
                    else
                    {
                        string ID = Request.QueryString["id"].ToString();
                        CH_Poligono DatosAux = new CH_Poligono { Conexion = Comun.Conexion, IDPoligono = ID };
                        CH_PoligonoNegocio CN = new CH_PoligonoNegocio();
                        IDPoligono = ID;
                        CN.ObtenerDetallePoligonoXIDResumen(DatosAux);
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
                }
                else
                    Response.Redirect("frmPoligonosGrid.aspx");
            }
            else
            {
                if(Request.Form.Count > 0)
                {
                    string IDPoligono = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    double Latitud = 0, Longitud = 0, LatitudIni = 0, LongitudIni = 0;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    double.TryParse(Request.Form["hfLatitud"].ToString(), NumberStyles.Currency, esMX, out Latitud);
                    double.TryParse(Request.Form["hfLongitud"].ToString(), NumberStyles.Currency, esMX, out Longitud);
                    this.Guardar(IDPoligono, Latitud, Longitud, Latitud, Longitud);
                }
            }
        }

        private void CargarDatos(CH_Poligono DatosAux)
        {
            try
            {
                //Iniciar el mapa
                string Aux01 = DatosAux.Latidud.ToString().Replace(",", ".");
                string Aux02 = DatosAux.Longitud.ToString().Replace(",", ".");
                string ScriptError =
                @"   jQuery(document).ready(function() {
                        Maps.init(" + Aux01 + ", " + Aux02 + @");
                            console.log(" + Aux01 + ", " + Aux02 + @")
                        });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);

                hf.Value = DatosAux.IDPoligono;
                txtNombrePoligono.Value = DatosAux.Nombre;
                txtEstado.Value = DatosAux.EstadoDesc;
                txtMunicipio.Value = DatosAux.MunicipioDesc;
                txtClave.Value = DatosAux.Clave;
                txtColonia.Value = DatosAux.Colonia;
                Lista = DatosAux.ListaPuntos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void Guardar(string _ID, double _Latitud, double _Longitud, double _LatitudIni, double _LongitudIni)
        {
            try
            {
                CH_Poligono Datos = new CH_Poligono
                {
                    IDPoligono = _ID,
                    Latidud = _Latitud,
                    Longitud = _Longitud,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                CH_PoligonoNegocio PolN = new CH_PoligonoNegocio();
                PolN.APuntosPoligono(Datos);
                if (Datos.Completado)
                {
                    Datos.EsPrincipal = false;
                    Lista = PolN.ObtenerPuntosPoligonos(Datos);
                    //string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Datos guardados correctamente.", "Success", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    string Aux01 = _LatitudIni.ToString().Replace(",", ".");
                    string Aux02 = _LongitudIni.ToString().Replace(",", ".");
                    string ScriptError =
                    @"   jQuery(document).ready(function() {
                        Maps.init(" + Aux01 + ", " + Aux02 + @");
                            console.log(" + Aux01 + ", " + Aux02 + @")
                        });";
                    ScriptError += DialogMessage.Show(TipoMensaje.Success, "Datos guardados correctamente.", "Success", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true); 
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
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


    }
}