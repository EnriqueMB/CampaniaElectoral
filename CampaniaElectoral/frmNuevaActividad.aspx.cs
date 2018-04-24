using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using Microsoft.Ajax.Utilities;

namespace CampaniaElectoral
{
    public partial class frmNuevaActividad : System.Web.UI.Page
    {
        public List<EM_CatColaborador> ListaColaboradores = new List<EM_CatColaborador>();
        public  List<RR_TipoEventoAgenda> ListaEventoAgenda = new List<RR_TipoEventoAgenda>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarComboEncargado();
                this.CargarComboActividad();
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID;
                            if(true) //(int.TryParse(Request.QueryString["id"].ToString(), out ID))
                            {
                                ID= Request.QueryString["id"];
                                //Obtener los datos y dibujarlos.
                                RR_NuevaActividad DatosAux =new RR_NuevaActividad { Conexion = Comun.Conexion, IDNuevaAct = ID};
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleNuevaActividadXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=" + DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=3");
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
                if (Request.Form.Count == 18)
                {
                    decimal meta;
                    string txtNombEve = Request.Form["ctl00$cph_MasterBody$txtNombreActividad"].ToString();
                    int cmbTipoAct = 0;
                    int.TryParse(Request.Form["cmbTipoActividad"].ToString(), out cmbTipoAct);
                    string encargado = Request.Form["cmbEncargado"].ToString();
                    DateTime txtFecIni =  Convert.ToDateTime(Request.Form["ctl00$cph_MasterBody$txtFechaInicio"]);
                    string txtHoraIni = Request.Form["ctl00$cph_MasterBody$txtHoraInicio"].ToString();
                    DateTime txtFecFin = Convert.ToDateTime(Request.Form["ctl00$cph_MasterBody$txtFechaTermino"]);
                    string txtHoraFin = Request.Form["ctl00$cph_MasterBody$txtHoraTermino"].ToString();
                    string txtObser = Request.Form["ctl00$cph_MasterBody$txtObservaciones"].ToString();
                    if (txtMeta.Value == null)
                    {
                        meta = 0;
                    }
                    else
                    {
                        meta = Convert.ToDecimal(Request.Form["ctl00$cph_MasterBody$txtMeta"]);
                    }
                    string txtMsjEncargado = HttpUtility.HtmlEncode(this.Check.InnerText);
                    int IDColab = -1;
                    try
                    {
                        //BasicCrypto BC = new BasicCrypto();
                        //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDColab);
                        bool NuevoRegistro = (AuxID == "-1");
                        this.Guardar(NuevoRegistro, AuxID, txtNombEve, cmbTipoAct, encargado, txtFecIni, 
                            txtHoraIni, txtFecFin, txtHoraFin, txtObser, meta, txtMsjEncargado);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message, false);
                    }
                    //}
                }
            }
        }
        #region Métodos

        private void CargarDatos(RR_NuevaActividad DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDNuevaAct.ToString();
                txtNombreActividad.Value = DatosAux.NombreActividad;
                // = DatosAux.ColorStatus;
                txtFechaInicio.Value = DatosAux.FechaInicio.ToShortDateString();
                txtHoraInicio.Value = DatosAux.HoraInicio;
                txtFechaTermino.Value = DatosAux.FechaTermino.ToShortDateString();
                txtHoraTermino.Value = DatosAux.HoraTermino;
                txtObservaciones.Value = DatosAux.Observaciones;
                txtMeta.Value = DatosAux.MetaEstablecida.ToString();
                Check.InnerHtml = DatosAux.MensajeEncargado;
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('cmbTipoActividad').value=" + DatosAux.IDTipoActividadEvento + @";
                        document.getElementById('cmbEncargado').value=" + DatosAux.EncargadoActividad + @";
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string NombreActividad, int tipoActividadEvento, string TipoEncargado, DateTime fechaInicio,
             string HoraInicio, DateTime fechaFinal, string horaFinal, string observacionesm, decimal Meta, string msjEncargado)
        {
            try
            {
                RR_NuevaActividad Datos = new RR_NuevaActividad
                {
                    NuevoRegistro = NuevoRegistro,
                    IDNuevaAct = ID,
                    EsEvento = true,
                    NombreActividad = NombreActividad,
                    IDTipoActividadEvento = tipoActividadEvento,
                    EncargadoActividad = TipoEncargado,
                    IDEstatusGeneral = 1,
                    IDEstatusVisto = 1,
                    FechaInicio =  fechaInicio,
                    HoraInicio = HoraInicio,
                    FechaTermino = fechaFinal,
                    HoraTermino = horaFinal,
                    Observaciones = observacionesm,
                    MetaEstablecida = Meta,
                    MensajeEncargado = msjEncargado,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoNuevaActividad(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmActividadesEventosGrid.aspx", false);
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
                //hf.Value = BC.Encripta("-1");
                hf.Value = "-1";
                txtNombreActividad.Value = string.Empty;
                txtFechaInicio.Value = string.Empty;
                txtHoraInicio.Value = string.Empty;
                txtFechaTermino.Value = string.Empty;
                txtObservaciones.Value = string.Empty;
                txtMeta.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            #endregion
        }

        private void CargarComboActividad()
        {
            RR_TipoEventoAgenda Datos = new RR_TipoEventoAgenda() { Conexion = Comun.Conexion };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            ListaEventoAgenda = GN.ObtenerCatalogoActividad(Datos);
        }

        private void CargarComboEncargado()
        {
            EM_CatColaborador Datos = new EM_CatColaborador() { Conexion = Comun.Conexion };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            ListaColaboradores = GN.ObtenerCatalogoEncargado(Datos);
        }
    }
}