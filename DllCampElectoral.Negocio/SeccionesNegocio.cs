using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class SeccionesNegocio
    {
        public List<Secciones> ObtenerSecciones(Secciones _Datos)
        {
            try
            {
                SeccionesDatos Data = new SeccionesDatos();
                return Data.ObtenerSecciones(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Secciones ObtenerSeccionesAJAX(Secciones _Datos)
        {
            try
            {
                SeccionesDatos Datos = new SeccionesDatos();
                return Datos.ObtenerSeccionesAJAX(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Secciones ObtenerDetalleSeccion(Secciones _Datos)
        {
            try
            {
                SeccionesDatos Data = new SeccionesDatos();
                return Data.ObtenerDetalleSeccion(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
