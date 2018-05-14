﻿using CampaniaElectoral.ClasesAux;
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
    public partial class frmNuevaIncidencia : System.Web.UI.Page
    {
        public CH_ZonaRiesgo Datos = new CH_ZonaRiesgo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CH_ZonaRiesgoNegocio ZRN = new CH_ZonaRiesgoNegocio();
                Datos.Conexion = Comun.Conexion;
                WN_Usuario u = new WN_Usuario();
                u = (WN_Usuario)Session["Usuario"];
                Datos.IDEstado = u.IDEstado;
                Datos.Estado = u.DesEstado;
                ZRN.ObtenerCombosZonaDeRiesgo(Datos);
                if (!IsPostBack)
                {
                    if (Request.QueryString["op"] != null)
                    {
                        if (Request.QueryString["op"] == "2")
                        {
                            if (Request.QueryString["id"] != null)
                            {

                                string ID = Request.QueryString["id"].ToString();
                                //Obtener los datos y dibujarlos.
                                CH_ZonaRiesgo Datos = new CH_ZonaRiesgo { Conexion = Comun.Conexion, IDZonaRiesgo = ID };
                                ZRN.ObtenerDetalleRiesgoXID(Datos);
                                if (Datos.Completado)
                                {
                                    this.CargarDatos(Datos);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmIncidencias.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                                Response.Redirect("frmIncidencias.aspx");
                        }
                        else
                            Response.Redirect("frmIncidencias.aspx");
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
                        bool NuevoRegistro = string.IsNullOrEmpty(hf.Value);
                        string IDRiesgo = string.IsNullOrEmpty(hf.Value) ? string.Empty : hf.Value.ToString();
                        string Titulo = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtTitulo"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtTitulo"];
                        string Descripcion = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtDescripcion"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtDescripcion"];
                        int IDEstado = 0, IDMunicipio = 0, IDTipoRiesgo = 0;
                        int.TryParse(Request.Form["cmbEstado"], out IDEstado);
                        int.TryParse(Request.Form["cmbMunicipio"], out IDMunicipio);
                        int.TryParse(Request.Form["cmbTipoRiesgo"], out IDTipoRiesgo);
                        string IDPoligono = string.IsNullOrEmpty(Request.Form["cmbPoligono"]) ? string.Empty : Request.Form["cmbPoligono"];
                        string sLatitud = Request.Form["hfLatitud"].ToString();
                        string sLongitud = Request.Form["hfLongitud"].ToString();
                        double Latitud = 0, Longitud = 0;
                        CultureInfo esMX = new CultureInfo("es-MX");
                        double.TryParse(sLatitud, NumberStyles.Currency, esMX, out Latitud);
                        double.TryParse(sLongitud, NumberStyles.Currency, esMX, out Longitud);
                        this.Guardar(NuevoRegistro, IDRiesgo, Titulo, Descripcion, IDTipoRiesgo, Datos.IDEstado, IDMunicipio, IDPoligono, Latitud, Longitud);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void CargarDatos(CH_ZonaRiesgo DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDZonaRiesgo;
                txtDescripcion.Value = DatosAux.Descripcion;
                txtTitulo.Value = DatosAux.Titulo;
                string Latitud = DatosAux.Latitud.ToString().Replace(",", ".");
                string Longitud = DatosAux.Longitud.ToString().Replace(",", ".");
                string ScriptError = @"
                    $(document).ready(
                        function() {
                        $.ajaxSetup({ async: false });
                        document.getElementById('hfLatitud').value=" + Latitud + @";
                        document.getElementById('hfLongitud').value=" + Longitud + @";
                        document.getElementById('cmbTipoRiesgo').value=" + DatosAux.IDTipoRiesgo + @";
                        document.getElementById('cmbEstado').value=" + DatosAux.IDEstado + @";
                        $('#cmbEstado').trigger('change');
                        document.getElementById('cmbMunicipio').value=" + DatosAux.IDMunicipio + @";
                        $('#cmbMunicipio').trigger('change');
                        document.getElementById('cmbPoligono').value='" + DatosAux.IDPoligono + @"';
                        Maps.init(2);
                        $.ajaxSetup({ async: true });
                    });";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void Guardar(bool _Nuevoregistro, string _IDRiesgo, string _Titulo, string _Descripcion,
                                int _IDTipoRiesgo, int _IDEstado, int _IDMunicipio, string _IDPoligono,
                                double _Latitud, double _Longitud)
        {
            try
            {
                CH_ZonaRiesgo DatosAux = new CH_ZonaRiesgo
                {
                    NuevoRegistro = _Nuevoregistro,
                    IDZonaRiesgo = _IDRiesgo,
                    Titulo = _Titulo,
                    Descripcion = _Descripcion,
                    IDTipoRiesgo = _IDTipoRiesgo,
                    IDEstado = _IDEstado,
                    IDMunicipio = _IDMunicipio,
                    IDPoligono = _IDPoligono,
                    Latitud = _Latitud,
                    Longitud = _Longitud,
                    IDUsuario = Comun.IDUsuario,
                    Conexion = Comun.Conexion
                };
                CH_ZonaRiesgoNegocio ZRN = new CH_ZonaRiesgoNegocio();
                ZRN.ACRiesgos(DatosAux);
                if (DatosAux.Completado)
                {
                    Response.Redirect("frmIncidencias.aspx", false);
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
                string ScriptError = @"
                    $(document).ready(
                        function() {
                        Maps.init(1);
                    });";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}