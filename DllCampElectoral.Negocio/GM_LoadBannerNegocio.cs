using DllCampElectoral.Global;
using DllCampElectoral.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
     public class GM_LoadBannerNegocio
    {
          #region Banner

        public void AGBanner(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos LB = new GM_LoadBannerDatos();
                LB.AGBanner(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_LoadBanner> ObtenerListaBanner(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos LD = new GM_LoadBannerDatos();
                return LD.ObtenerListBanner(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_DatosHome> ObtenerListaTextos(RR_DatosHome Datos)
        {
            try
            {
                GM_LoadBannerDatos LD = new GM_LoadBannerDatos();
                return LD.ObtenerListaTextos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleIDBanner(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos BD = new GM_LoadBannerDatos();
                BD.ObtenerDetalleBannerID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public void EliminarFotoXID(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos FD = new GM_LoadBannerDatos();
                FD.EliminarIDBanner(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public void EliminarBannerID(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos FD = new GM_LoadBannerDatos();
                FD.EliminarIDBanner(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaFotoXID(GM_LoadBanner Datos)
        {
            try
            {
                GM_LoadBannerDatos FD = new GM_LoadBannerDatos();
                FD.ImagenSubidaFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
