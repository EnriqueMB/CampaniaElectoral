using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DllCampElectoral.Negocio
{
    public class GM_CalendarNegocio
    {
        public List<Global.GM_CalendarJsn> ObtenerEventosCalendario(Global.GM_Calendar Datos)
        {
            try
            {
                GM_CalendarDatos CD = new GM_CalendarDatos();
                return CD.ObtenerEventosCalendario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
