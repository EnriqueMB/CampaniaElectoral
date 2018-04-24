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
    public partial class frmNuevoEvento : System.Web.UI.Page
    {
        public List<CH_Colaborador> ListaCol = new List<CH_Colaborador>();
        public List<CH_Estados> ListaEstado = new List<CH_Estados>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string Mensaje = Server.HtmlEncode("id_object");
            
            if (!IsPostBack)
            {
                CH_Colaborador DA = new CH_Colaborador { Conexion = Comun.Conexion };
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                ListaCol = CN.ObtenerComboColaborador(DA);
                this.CargarComboEstado();

                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            //Obtener los datos y dibujarlos.
                            CH_Evento DatosAux = new CH_Evento { Conexion = Comun.Conexion, IDEvento = ID };
                            CH_EventoNegocio EN = new CH_EventoNegocio();
                            EN.ObtenerDetalleEventoXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                //this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                //Ocurrió un error
                                Response.Redirect("frmDefault.aspx?error=" + "Error al obtener los datos.");
                            }
                        }
                        else
                            Response.Redirect("frmDefault.aspx");
                    }
                    else
                        Response.Redirect("frmDefault.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count < 50 )
                {
                    int IDEstado = 0, IDMunicipio = 0;
                    decimal Meta = 0, Latitud = 0, Longitud = 0;
                    DateTime FechaInicio, FechaTermino, FechaEvento;

                    CultureInfo esMX = new CultureInfo("es-MX");
                    string IDEvento = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                    bool NuevoRegistro = (string.IsNullOrEmpty(IDEvento));
                    string NombreEvento = Request.Form["ctl00$cph_MasterBody$txtNombreEvento"].ToString();
                    string IDColaborador = Request.Form["cmbEncargado"].ToString();
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaInicio"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out FechaInicio);
                    string SFechaInicio = Request.Form["ctl00$cph_MasterBody$txtFechaInicio"].ToString();
                    string HoraInicio = Request.Form["ctl00$cph_MasterBody$txtHoraInicio"].ToString();
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaTermino"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out FechaTermino);
                    string HoraTermino = Request.Form["ctl00$cph_MasterBody$txtHoraTermino"].ToString();
                    string Observaciones = Request.Form["ctl00$cph_MasterBody$txtObservaciones"].ToString();
                    decimal.TryParse(Request.Form["ctl00$cph_MasterBody$txtMeta"].ToString(), out Meta);
                    string HTMLMensaje = HttpUtility.HtmlDecode(this.txtMensaje.InnerHtml);
                    string Titulo = Request.Form["ctl00$cph_MasterBody$txtTituloPagina"].ToString();
                    string HTMLTextoPagina = HttpUtility.HtmlDecode(this.txtTextoPagina.InnerHtml);
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaEvento"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out FechaEvento);
                    string HoraEvento = Request.Form["ctl00$cph_MasterBody$txtHoraEvento"].ToString();
                    int.TryParse(Request.Form["cmbEstado"].ToString(), out IDEstado);
                    int.TryParse(Request.Form["cmbMunicipio"].ToString(), out IDMunicipio);
                    string Direccion = Request.Form["ctl00$cph_MasterBody$address"].ToString();
                    bool BandPublicar = this.chkPublicar.Checked;
                    string sLatitud = Request.Form["ctl00$cph_MasterBody$hfLatitud"].ToString();
                    string sLongitud = Request.Form["ctl00$cph_MasterBody$hfLongitud"].ToString();
                    decimal.TryParse(Request.Form["ctl00$cph_MasterBody$hfLatitud"], NumberStyles.Currency, esMX, out Latitud);
                    decimal.TryParse(Request.Form["ctl00$cph_MasterBody$hfLongitud"], NumberStyles.Currency, esMX, out Longitud);
                    this.Guardar(NuevoRegistro, IDEvento, NombreEvento, IDColaborador, FechaInicio, HoraInicio, FechaTermino, HoraTermino, Observaciones, Meta, HTMLMensaje, Titulo, HTMLTextoPagina,
                                 FechaEvento, HoraEvento, IDEstado, IDMunicipio, Direccion, Latitud, Longitud, BandPublicar);
                }
            }
        }

        private void Guardar(bool NuevoRegistro, string IDEvento, string Nombre, string IDColaborador, DateTime FechaInicio, string HoraInicio, DateTime FechaTermino, string HoraTermino, 
                            string Observaciones, decimal Meta, string MensajeEncargado, string TituloPagina, string TextoPagina, DateTime FechaEvento, string HoraEvento, int IDEstado, int IDMunicipio,
                            string Direccion, decimal Latitud, decimal Longitud, bool Publicar)
        {
            try
            {
                CH_Evento Datos = new CH_Evento
                {
                    NuevoRegistro    = NuevoRegistro,
                    IDEvento         = IDEvento,
                    Nombre           = Nombre,
                    IDColaborador    = IDColaborador,
                    FechaInicio      = FechaInicio,
                    HoraInicio       = HoraInicio,
                    FechaTermino     = FechaTermino,
                    HoraTermino      = HoraTermino,
                    Observaciones    = Observaciones,
                    Meta             = Meta,
                    MensajeEncargado = MensajeEncargado,
                    TituloPagina     = TituloPagina,
                    TextoPagina      = TextoPagina,
                    FechaEvento      = FechaEvento,
                    HoraEvento       = HoraEvento,
                    IDEstado         = IDEstado,
                    IDMunicipio      = IDMunicipio,
                    Direccion        = Direccion,
                    Latitud          = Latitud,
                    Longitud         = Longitud,
                    Publicar         = Publicar,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                CH_EventoNegocio CHE = new CH_EventoNegocio();
                CHE.ACCatalogoEventos(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmNuevoEvento.aspx", false);
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

        public void IniciarDatos()
        {
            try
            {
                hf.Value = "";
                txtNombreEvento.Value = string.Empty;
                txtFechaTermino.Value = DateTime.Now.ToShortDateString();
                txtHoraTermino.Value = DateTime.Now.ToShortTimeString();
                txtObservaciones.Value = string.Empty;
                txtMeta.Value = "0";
                txtMensaje.Value = string.Empty;
                txtTituloPagina.Value = string.Empty;
                txtTextoPagina.Value = string.Empty;
                txtHoraEvento.Value = DateTime.Now.ToShortTimeString();
                hfLatitud.Value = string.Empty;
                hfLongitud.Value = string.Empty;
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
    }
}