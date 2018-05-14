using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
   public class ER_IncidenciasNegocio
    {
        public void ObtenerIncidencias(ER_Incidencias Datos)
        {
            try
            {
                ER_IncidenciasDatos CD = new ER_IncidenciasDatos();
                CD.obtenerIncidencias(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
