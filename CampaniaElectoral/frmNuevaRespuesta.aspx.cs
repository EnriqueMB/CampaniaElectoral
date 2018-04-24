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
    public partial class frmNuevaRespuesta : System.Web.UI.Page
    {
        public CH_Encuesta DatosEncuesta = new CH_Encuesta();

        protected void Page_Load(object sender, EventArgs e)
        {
            DatosEncuesta.Conexion = Comun.Conexion;
            CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
            EN.ObtenerCombosResponderEncuesta(DatosEncuesta);

            if(!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {

                            string ID = Request.QueryString["id"].ToString();
                            //Obtener los datos y dibujarlos.
                            CH_Encuesta Datos = new CH_Encuesta { Conexion = Comun.Conexion, IDRespuesta = ID };
                            EN.ObtenerDetalleResponderEncuesta(Datos);
                            if (Datos.Completado)
                            {
                                this.CargarDatos(Datos);
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
                        Response.Redirect("frmRespuestaEncuestaGrid.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if(Request.Form.Count > 0)
                {
                    bool NuevoRegistro = string.IsNullOrEmpty(hf.Value);
                    string IDRespuesta = string.IsNullOrEmpty(hf.Value) ? string.Empty : hf.Value.ToString();
                    string IDEncuesta = string.IsNullOrEmpty(Request.Form["cmbEncuestas"]) ? string.Empty : Request.Form["cmbEncuestas"];
                    string FechaEncuesta = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtFechaEncuesta"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtFechaEncuesta"];
                    string HoraInicio = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtHoraInicio"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtHoraInicio"];
                    string HoraFin = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtHoraTermino"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtHoraTermino"];
                    int IDEstado = 0, IDMunicipio = 0, Edad = 0, AniosColonia = 0, IDGenero = 0, IDGradoEstudio = 0;
                    int.TryParse(Request.Form["cmbEstados"], out IDEstado);
                    int.TryParse(Request.Form["cmbMunicipio"], out IDMunicipio);
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtEdad"], out Edad);
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtHabColonia"], out AniosColonia);
                    int.TryParse(Request.Form["cmbGenero"], out IDGenero);
                    int.TryParse(Request.Form["cmbGradoEstudio"], out IDGradoEstudio);

                    string IDPoligono = string.IsNullOrEmpty(Request.Form["cmbPoligono"]) ? string.Empty : Request.Form["cmbPoligono"];
                    string NombreEntrevistado = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtNomEntrevistado"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtNomEntrevistado"];
                    string ApPaterno = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtApPaterno"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtApPaterno"];
                    string ApMaterno = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtApMaterno"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtApMaterno"];
                    string Direccion = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtDireccion"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtDireccion"];
                    string IDEntrevistador = string.IsNullOrEmpty(Request.Form["cmbEntrevistador"]) ? string.Empty : Request.Form["cmbEntrevistador"];
                    string IDSupervisor = string.IsNullOrEmpty(Request.Form["cmbSupervisor"]) ? string.Empty : Request.Form["cmbSupervisor"];
                    string Observaciones = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtObservaciones"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtObservaciones"];
                    DateTime FechaEnc;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    DateTime.TryParseExact(FechaEncuesta, "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out FechaEnc);
                    this.Guardar(NuevoRegistro, IDRespuesta, IDEncuesta, FechaEnc, HoraInicio, HoraFin, IDEstado, IDMunicipio, IDPoligono, NombreEntrevistado, ApPaterno, ApMaterno, Edad, AniosColonia, IDGenero, IDGradoEstudio, Direccion, IDEntrevistador, IDSupervisor, Observaciones);
                }
            }
        }


        private void CargarDatos(CH_Encuesta DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDRespuesta;
                txtFechaEncuesta.Value = DatosAux.FechaEncuesta.ToString("dd-MM-yyyy");
                txtHoraInicio.Value = DatosAux.HoraInicio;
                txtHoraTermino.Value = DatosAux.HoraTermino;
                txtNomEntrevistado.Value = DatosAux.Nombre;
                txtApPaterno.Value = DatosAux.ApellidoPat;
                txtApMaterno.Value = DatosAux.ApellidoMat;
                txtEdad.Value = DatosAux.Edad.ToString();
                txtHabColonia.Value = DatosAux.AniosColonia.ToString();
                txtDireccion.Value = DatosAux.Direccion;
                txtObservaciones.Value = DatosAux.Observaciones;

                string ScriptError = @"
                    $(document).ready(
                        function() {
                        $.ajaxSetup({ async: false });
                        document.getElementById('cmbEncuestas').value='" + DatosAux.IDEncuesta + @"';
                        document.getElementById('cmbEstados').value=" + DatosAux.IDEstado + @";
                        $('#cmbEstados').trigger('change');
                        document.getElementById('cmbMunicipio').value=" + DatosAux.IDMunicipio + @";
                        $('#cmbMunicipio').trigger('change');
                        document.getElementById('cmbPoligono').value='" + DatosAux.IDPoligono + @"';
                        document.getElementById('cmbGenero').value=" + DatosAux.IDGenero + @";
                        document.getElementById('cmbGradoEstudio').value=" + DatosAux.IDGradoEstudio + @";
                        document.getElementById('cmbEntrevistador').value='" + DatosAux.IDEntrevistador + @"';
                        document.getElementById('cmbSupervisor').value='" + DatosAux.IDSupervisor + @"';
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



        private void Guardar(bool _Nuevoregistro, string _IDRespuesta, string _IDEncuesta, DateTime _FechaEncuesta, string _HoraInicio,
                            string _HoraTermino, int _IDEstado, int _IDMunicipio, string _IDPoligono, string _Nombre, string _ApPaterno,
                            string _ApMaterno, int _Edad, int _NumAniosColonia, int _IDGenero, int _IDGradoEstudios, string _Direccion,
                            string _IDEntrevistador, string _IDSupervisor, string _Observaciones)
        {
            try
            {
                CH_Encuesta DatosAux = new CH_Encuesta {
                    NuevoRegistro = _Nuevoregistro, IDRespuesta = _IDRespuesta, IDEncuesta = _IDEncuesta, FechaEncuesta = _FechaEncuesta,
                    HoraInicio = _HoraInicio, HoraTermino = _HoraTermino, IDEstado = _IDEstado, IDMunicipio = _IDMunicipio, IDPoligono = _IDPoligono,
                    Nombre = _Nombre, ApellidoPat = _ApPaterno, ApellidoMat = _ApMaterno, Edad = _Edad, AniosColonia = _NumAniosColonia,
                    IDGenero = _IDGenero, IDGradoEstudio = _IDGradoEstudios, Direccion = _Direccion, IDEntrevistador = _IDEntrevistador,
                    IDSupervisor = _IDSupervisor, Observaciones = _Observaciones, IDUsuario = Comun.IDUsuario, Conexion = Comun.Conexion
                };
                CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
                EN.AC_ResponderEncuesta(DatosAux);
                if (DatosAux.Completado)
                {
                    Response.Redirect("frmRespuestaEncuestaGrid.aspx", false);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

    }
}