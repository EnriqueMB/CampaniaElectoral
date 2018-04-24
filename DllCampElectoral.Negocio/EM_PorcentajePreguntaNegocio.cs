using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class EM_PorcentajePreguntaNegocio
    {
        public void ACPorcentajeP(EM_PorcentajePregunta Datos)
        {
            try
            {
                EM_PorcentajePreguntaDatos PD = new EM_PorcentajePreguntaDatos();
                PD.ACPorcentaje(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_PorcentajePregunta> ObtenerPorcentajePregunta(EM_PorcentajePregunta Datos)
        {
            try
            {
                EM_PorcentajePreguntaDatos PD = new EM_PorcentajePreguntaDatos();
                return PD.ObtenerPorcentajePregunta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePorcentajXID(EM_PorcentajePregunta Datos)
        {
            try
            {
                EM_PorcentajePreguntaDatos PD = new EM_PorcentajePreguntaDatos();
                PD.ObtenerDetallePordentajePreguntaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPorcentajsXID(EM_PorcentajePregunta Datos)
        {
            try
            {
                EM_PorcentajePreguntaDatos PD = new EM_PorcentajePreguntaDatos();
                PD.EliminarPorcentajePreguntaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
