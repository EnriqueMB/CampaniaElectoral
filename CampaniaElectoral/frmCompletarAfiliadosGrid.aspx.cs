using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace CampaniaElectoral
{
    public partial class frmCompletarAfiliadosGrid : System.Web.UI.Page
    {
        public List<RR_Afiliados> Lista = new List<RR_Afiliados>();
        public string nombre;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "1")
                {
                    int opcion = 1;
                    this.CargarGrid(opcion);
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "2")
                {
                    int opcion = 2;
                    this.CargarGrid(opcion);
                }
              


                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "8")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0;
                        DateTime Fecha1 = DateTime.Now, Fecha2 = DateTime.Now;
                        string AuxID = Request.QueryString["Buscar"];
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        this.BusquedaAfiliado(OP, AuxID, false, Fecha1, Fecha2);
                    }
                }
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "10")
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
                            this.BusquedaAfiliado(OP, Busqueda, false, Fecha1, Fecha2);
                        }
                    }
                }
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "9")
                {
                    if (Request.QueryString["Buscar"] != null)
                    {
                        int OP = 0;
                        bool Rati;
                        int Ratificacio = 0;
                        string Busqueda = "";
                        DateTime Fecha1 = DateTime.Now, Fecha2 = DateTime.Now;
                        int.TryParse(Request.QueryString["Buscar"].ToString(), out Ratificacio);
                        if (Ratificacio == 1)
                        {
                            Rati = true;
                        }
                        else
                        {
                            Rati = false;
                        }
                        int.TryParse(Request.QueryString["op"].ToString(), out OP);
                        this.BusquedaAfiliado(OP, Busqueda, Rati, Fecha1, Fecha2);
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
        public void CargarGrid(int opcion)
        {
            try
            {
                RR_Afiliados Datos = new RR_Afiliados() { Conexion = Comun.Conexion, opcion = opcion };
                RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaAfiliado(int Op, string Busq, bool Ratificado, DateTime FechaIni, DateTime FechaFin)
        {
            RR_Afiliados Datos = new RR_Afiliados()
            {
                Resultado = Op,
                Nombre = Busq,
                Ratificacion = Ratificado,
                Fecha1 = FechaIni,
                Fecha2 = FechaFin,
                Conexion = Comun.Conexion
            };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            Lista = GN.ObtenerCatalogoAfiliadoBusqueda(Datos);
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

       
    }
}