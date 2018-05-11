using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EstadisticosAfiliados_Negocio
    {
        public EstadisticosAfiliados ObtenerEstadisticosAfiliados(string Conexion)
        {
            try
            {
                EstadisticosAfiliados_Datos Datos = new EstadisticosAfiliados_Datos();
                return Datos.ObtenerEstadisticosAfiliados(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object[] ObtenerPuntosStringXIDSeccion(string Conexion, int IDSeccion)
        {
            try
            {
                EstadisticosAfiliados_Datos Datos = new EstadisticosAfiliados_Datos();
                return Datos.ObtenerPuntosStringXIDSeccion(Conexion, IDSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadisticosAfiliados ObtenerEvaluacionAJAX(EstadisticosAfiliados _Datos)
        {
            try
            {
                EstadisticosAfiliados_Datos Datos = new EstadisticosAfiliados_Datos();
                return Datos.ObtenerEvaluacionAJAX(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
