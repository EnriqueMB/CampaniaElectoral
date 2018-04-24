using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_NotificacionNegocio
    {
        public void ObtenerCombosColaborador(CH_Notificacion Datos)
        {
            try
            {
                CH_NotificacionDatos ND = new CH_NotificacionDatos();
                ND.ObtenerCombosColaborador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ACNotificaciones(CH_Notificacion Datos)
        {
            try
            {
                CH_NotificacionDatos ND = new CH_NotificacionDatos();
                ND.ACNotificaciones(Datos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerDetalleNotificacion(CH_Notificacion Datos)
        {
            try
            {
                CH_NotificacionDatos ND = new CH_NotificacionDatos();
                ND.ObtenerDetalleNotificacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
