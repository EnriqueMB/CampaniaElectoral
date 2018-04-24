using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DllCampElectoral.Datos
{
   public class GM_CalendarDatos
    {
                public List<GM_CalendarJsn> ObtenerEventosCalendario(GM_Calendar Datos)
        {
            try
            {
                List<GM_CalendarJsn> Lista = new List<GM_CalendarJsn>();
                GM_CalendarJsn Item;
                object[] Parametros = {Datos.FechaInicio, Datos.FechaTermino, Datos.IDTipoEvento };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_CalendarIDC", Parametros);
                while (Dr.Read())
                {
                    Item = new GM_CalendarJsn();
                    Item.id = Dr.GetString(Dr.GetOrdinal("IDEvento"));
                    Item.title = Dr.GetString(Dr.GetOrdinal("NombreEvento"));
                    DateTime FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                    string HoraInicio = Dr.GetString(Dr.GetOrdinal("HoraInicio"));
                    DateTime FechaFin = Dr.GetDateTime(Dr.GetOrdinal("FechaTermino"));
                    string HoraFin = Dr.GetString(Dr.GetOrdinal("HoraTermino"));

                    Item.start = FechaInicio.ToString("yyyy-MM-dd") + "T" + HoraInicio;
                    Item.end = FechaFin.ToString("yyyy-MM-dd") + "T" + HoraFin;
                   // Item.allDay = false;

                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
