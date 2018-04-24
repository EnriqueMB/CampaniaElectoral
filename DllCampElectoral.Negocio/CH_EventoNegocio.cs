using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_EventoNegocio
    {
        public void ACCatalogoEventos(CH_Evento Datos)
        {
            try
            {
                CH_EventoDatos ED = new CH_EventoDatos();
                ED.ACCatalogoEventos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Evento> ObtenerCatalogoEventos(CH_Evento Datos)
        {
            try
            {
                CH_EventoDatos ED = new CH_EventoDatos();
                return ED.ObtenerCatalogoEventos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleEventoXID(CH_Evento Datos)
        {
            try
            {
                CH_EventoDatos ED = new CH_EventoDatos();
                ED.ObtenerDetalleEventoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEventoXID(CH_Evento Datos)
        {
            try
            {
                CH_EventoDatos ED = new CH_EventoDatos();
                ED.EliminarEventoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CH_EventoJSON> ObtenerEventosCalendario(CH_Evento Datos)
        {
            try
            {
                CH_EventoDatos ED = new CH_EventoDatos();
                return ED.ObtenerEventosCalendario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
