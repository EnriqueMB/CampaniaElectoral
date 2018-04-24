using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_MisionVisionNegocio
    {
        public void ACVisionMision(EM_MisionVision Datos)
        {
            try
            {
                EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                MD.ACMisionVision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_MisionVision> ObtenerCatalogoVisionMision(EM_MisionVision Datos)
        {
            try
            {
                EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                return MD.ObtenerCatalagoMisionVision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EM_MisionVision MisionWeb(EM_MisionVision Datos)
        {
            try
            {
                 EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                return MD.ObtenerMisionVision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerVisionMisionDetalleXID(EM_MisionVision Datos)
        {
            try
            {
                EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                MD.ObternerMisionVisionXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarVisionMisionXID(EM_MisionVision Datos)
        {
            try
            {
                EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                MD.EliminarMisionVisionXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaVisionXID(EM_MisionVision Datos)
        {
            try
            {
                EM_MisionVisionDatos MD = new EM_MisionVisionDatos();
                MD.ImagenSubidMisionVisionXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
