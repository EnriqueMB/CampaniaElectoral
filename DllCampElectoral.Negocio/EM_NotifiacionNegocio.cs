using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class EM_NotifiacionNegocio
    {
        public List<EM_Notificacion> ObtenerNotificacion(EM_Notificacion Datos)
        {
            try
            {
                EM_NotificacionDatos NN = new EM_NotificacionDatos();
                return NN.ObtenerNotifiacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Notificacion> EnviarNotificaciones(EM_Notificacion Datos)
        {
            try
            {
                EM_NotificacionDatos NN = new EM_NotificacionDatos();
                return NN.EnviarNotifiacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarNotificacion(EM_Notificacion Datos)
        {
            try
            {
                EM_NotificacionDatos NN = new EM_NotificacionDatos();
                NN.EliminarNotificacionesXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
