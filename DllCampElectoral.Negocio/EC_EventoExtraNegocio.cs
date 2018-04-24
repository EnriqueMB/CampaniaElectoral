using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;
namespace DllCampElectoral.Negocio
{
    public class EC_EventoExtraNegocio
    {
        public List<EC_EventoExtra> CargarGrid(EC_EventoExtra Datos)
        {
            try
            {
                EC_EventoExtraDatos EED = new EC_EventoExtraDatos();
                return EED.CargarGrid(Datos);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EC_EventoExtra> ObtenerCatalogoFotos(EC_EventoExtra Datos)
        {
            try
            {
                EC_EventoExtraDatos FD = new EC_EventoExtraDatos();
                return FD.ObtenerCatalogoFotos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarFotoXID(EC_EventoExtra Datos)
        {
            try
            {
                EC_EventoExtraDatos FD = new EC_EventoExtraDatos();
                FD.CargaFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
