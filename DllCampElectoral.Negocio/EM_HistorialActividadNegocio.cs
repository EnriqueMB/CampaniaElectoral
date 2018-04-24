using DllCampElectoral.Global;
using DllCampElectoral.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_HistorialActividadNegocio
    {
        public List<RR_NuevaActividad> ObtenerHistorialActividad(RR_NuevaActividad Datos)
        {
            try
            {
                EM_HistorialActividadDatos CD = new EM_HistorialActividadDatos();
                return CD.ObtenerHistorialActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
