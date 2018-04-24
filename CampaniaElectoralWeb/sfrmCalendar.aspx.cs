using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class sfrmCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["TypeEvent"] != null &&
                    Request.Form["start"] != null &&
                    Request.Form["end"] != null)
                {
                    CultureInfo LenguageMX = new CultureInfo("es-MX");
                    GM_Calendar  Datos = new GM_Calendar();
                    DateTime FechaStarC, FechaEndC;
                    int TipoE = 0;
                    string Aux = Request.Form["start"].ToString();
                    DateTime.TryParseExact(Request.Form["start"].ToString(), "yyyy-MM-dd", LenguageMX, DateTimeStyles.None, out FechaStarC);
                    DateTime.TryParseExact(Request.Form["end"].ToString(), "yyyy-MM-dd", LenguageMX, DateTimeStyles.None, out FechaEndC);
                    int.TryParse(Request.Form["TypeEvent"].ToString(), out TipoE);
                    Datos.Conexion = Comun.Conexion;
                    Datos.FechaInicio = FechaStarC;
                    Datos.FechaTermino = FechaEndC;
                    Datos.IDTipoEvento = TipoE;

                    GM_CalendarNegocio EN = new GM_CalendarNegocio();
                    List<GM_CalendarJsn> Lista = EN.ObtenerEventosCalendario(Datos);
                    var json = JsonConvert.SerializeObject(Lista);
                    Response.Clear();
                    Response.ContentType = "application/text;";

                    Response.Write(json);
                    Response.End();
                }
            }
        }
    }
}