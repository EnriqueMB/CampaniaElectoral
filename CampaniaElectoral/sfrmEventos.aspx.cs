using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class sfrmEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["TypeEvent"] != null && 
                    Request.Form["start"] != null && 
                    Request.Form["end"] != null)
                {
                    CultureInfo esMX = new CultureInfo("es-MX");
                    CH_Evento DatosAux = new CH_Evento();
                    DateTime FechaInicioMaps, FechaFinMaps;
                    int TipoEvento = 0;
                    string Aux = Request.Form["start"].ToString();
                    DateTime.TryParseExact(Request.Form["start"].ToString(), "yyyy-MM-dd", esMX, DateTimeStyles.None, out FechaInicioMaps);
                    DateTime.TryParseExact(Request.Form["end"].ToString(), "yyyy-MM-dd", esMX, DateTimeStyles.None, out FechaFinMaps);
                    int.TryParse(Request.Form["TypeEvent"].ToString(), out TipoEvento);
                    DatosAux.Conexion = Comun.Conexion;
                    DatosAux.IDColaborador = User.Identity.Name;
                    DatosAux.FechaInicio = FechaInicioMaps;
                    DatosAux.FechaTermino = FechaFinMaps;
                    DatosAux.IDTipoEvento = TipoEvento;

                    CH_EventoNegocio EN = new CH_EventoNegocio();
                    List<CH_EventoJSON> Lista = EN.ObtenerEventosCalendario(DatosAux);
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