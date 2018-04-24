using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;

namespace DllCampElectoral.Negocio
{
    public class GM_CarreraPoliticaNegocio
    {
        #region Banner

        public void AGCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos LB = new GM_CarreraPoliticaDatos();
                LB.AGCarreraPolitica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region List CarreraPolitica

        public List<GM_CarreraPolitica> ObtenerListCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos CN = new GM_CarreraPoliticaDatos();
                return CN.ObtenerCarreraPolitica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos CD = new GM_CarreraPoliticaDatos();
                CD.ObtenerDetallCarreraPoliticaID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCarreraPoliticaID(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos PD = new GM_CarreraPoliticaDatos();
                PD.EliminarIDCarreraPolitica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaFotoXID(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos PD = new GM_CarreraPoliticaDatos();
                PD.ImagenSubidaFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_CarreraPolitica> ObtenerListCarreraPolitica1(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos CN = new GM_CarreraPoliticaDatos();
                return CN.ObtenerCarreraPolitica1(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerProyectoCampania(GM_PlanCampania Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos CN = new GM_CarreraPoliticaDatos();
                return CN.ObtenerProyectoCampania(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GM_CarreraPolitica ObtenerCarrerapoliticaTexto(GM_CarreraPolitica Datos)
        {
            try
            {
                GM_CarreraPoliticaDatos CD = new GM_CarreraPoliticaDatos();
                return CD.ObtenerTextoCarreaPolitica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
