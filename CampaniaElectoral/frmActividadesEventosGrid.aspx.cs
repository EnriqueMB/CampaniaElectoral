using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using System.Globalization;

namespace CampaniaElectoral
{
    public partial class frmActividadesEventosGrid : System.Web.UI.Page
    {
        public List<RR_NuevaActividad> Lista = new List<RR_NuevaActividad>();
        public List<RR_TipoEventoAgenda> ListaEventoAgenda = new List<RR_TipoEventoAgenda>();
        public List<EM_StatusGeneralEvento> ListaStatusGeneral = new List<EM_StatusGeneralEvento>();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                this.CargarComboActividad();
                this.CargarComboEstatus();
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"];
                        //int.TryParse(Request.QueryString["id"], out AuxID);
                        RR_NuevaActividad Datos = new RR_NuevaActividad { Conexion = Comun.Conexion, IDNuevaAct = AuxID, IDUsuario = Comun.IDUsuario };
                        RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                        CN.EliminarNuevaActividadXID(Datos);
                        if (Datos.Completado)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
                
                if (!IsPostBack)
                {

                }
                else
                {
                }
                this.CargarGrid();
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "4")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0;
                        DateTime Fecha1 = DateTime.Now, Fecha2 = DateTime.Now;
                        string AuxID = Request.QueryString["Buscar"];
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        this.Busqueda(OP, AuxID, 0, Fecha1, Fecha2); 
                    }
                }
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "5")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0, IDTipo = 0;
                        DateTime Fecha1 = DateTime.Now, Fecha2 = DateTime.Now;
                        string Busqueda = "";
                        int.TryParse(Request.QueryString["Buscar"].ToString(), out IDTipo);
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        this.Busqueda(OP, Busqueda, IDTipo, Fecha1, Fecha2); 
                    }
                }
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "6")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0, IDTipo = 0;
                        string Busqueda = "";
                        DateTime Fecha1 = DateTime.Now, Fecha2 = DateTime.Now;
                        int.TryParse(Request.QueryString["Buscar"].ToString(), out IDTipo);
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        this.Busqueda(OP, Busqueda, IDTipo, Fecha1, Fecha2);
                    }
                }
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "7")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0;
                        DateTime Fecha1, Fecha2;
                        string Busqueda = Request.QueryString["Buscar"].ToString();
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        string[] s = Busqueda.Split('-');
                        if (s.Length == 2)
                        {
                            DateTime.TryParseExact(s[0].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha1);
                            DateTime.TryParseExact(s[1].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha2);
                            this.Busqueda(OP, Busqueda, 0, Fecha1, Fecha2);
                        }
                    }
                }
                if (Request.QueryString["errorMessage"] != null)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
        public void CargarGrid()
        {
            try
            {
                RR_NuevaActividad Datos = new RR_NuevaActividad() { Conexion = Comun.Conexion };
                RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoNuevaActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboActividad()
        {
            RR_TipoEventoAgenda Datos = new RR_TipoEventoAgenda() { Conexion = Comun.Conexion };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            ListaEventoAgenda = GN.ObtenerCatalogoActividad(Datos);
        }

        private void CargarComboEstatus()
        {
            try
            {
                EM_StatusGeneralEvento DatosE = new EM_StatusGeneralEvento() { Conexion = Comun.Conexion };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                ListaStatusGeneral = CN.ObtenerComboStatusGeneralEvento(DatosE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Busqueda(int op,  string txtBusqueda, int IDSta, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                RR_NuevaActividad DatosA = new RR_NuevaActividad()
                {
                    Resultado = op,
                    Busqueda = txtBusqueda,
                    IDEstatusGeneral = IDSta,
                    FechaInicio = FechaInicio,
                    FechaTermino = FechaFin,
                    Conexion = Comun.Conexion
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                Lista = CN.ObtenerActividadesBusqueda(DatosA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}