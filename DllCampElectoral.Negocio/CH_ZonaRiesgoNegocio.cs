using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_ZonaRiesgoNegocio
    {
        public void ObtenerCombosZonaDeRiesgo(CH_ZonaRiesgo Datos)
        {
            try
            {
                CH_ZonaRiesgoDatos ZRD = new CH_ZonaRiesgoDatos();
                ZRD.ObtenerCombosZonaDeRiesgo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ACRiesgos(CH_ZonaRiesgo Datos)
        {
            try
            {
                CH_ZonaRiesgoDatos ZRD = new CH_ZonaRiesgoDatos();
                ZRD.ACRiesgos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleRiesgoXID(CH_ZonaRiesgo Datos)
        {
            try
            {
                CH_ZonaRiesgoDatos ZRD = new CH_ZonaRiesgoDatos();
                ZRD.ObtenerDetalleRiesgoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void EliminarRiesgoXID(CH_ZonaRiesgo Datos)
        {
            try
            {
                CH_ZonaRiesgoDatos ZRD = new CH_ZonaRiesgoDatos();
                ZRD.EliminarRiesgoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<CH_ZonaRiesgo> ObtenerRiesgosXIDs(CH_ZonaRiesgo Datos)
        {
            try
            {
                CH_ZonaRiesgoDatos ZRD = new CH_ZonaRiesgoDatos();
                return ZRD.ObtenerRiesgosXIDs(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
