using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class GM_VideoNegocio
    {

        #region Status Video
        public void AGStatuVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                CD.AGModuloVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_VideosLoad> ObtenerListStatusVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                return CD.ObtenerDetalleVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_VideosLoad> ObtenerListStatusVideoPagina(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                return CD.ObtenerDetalleVideoPagina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarSVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                CD.EliminarVideoID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                CD.ObternerTipoDetalleVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Status Video
        public void ACStatuVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CD = new GM_VideoDatos();
                CD.AGModuloVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OObtenerDetalleVideo(GM_VideosLoad Datos)
        {
            try
            {
                GM_VideoDatos CDV = new GM_VideoDatos();
                CDV.ObtenerDetalleVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
