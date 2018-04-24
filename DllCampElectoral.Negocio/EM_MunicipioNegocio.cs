using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_MunicipioNegocio
    {
        public void ACMunicipio(EM_Munucipios Datos)
        {
            try
            {
                EM_MunicipioDatos MD = new EM_MunicipioDatos();
                MD.ACMunicipo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Munucipios> ObtenerCatalogoMunicipio(EM_Munucipios Datos)
        {
            try
            {
                EM_MunicipioDatos MD = new EM_MunicipioDatos();
                return MD.ObtenerCatalagoMunicipio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerMunicipioDetalleXID(EM_Munucipios Datos)
        {
            try
            {
                EM_MunicipioDatos MD = new EM_MunicipioDatos();
                MD.ObternerMunicipioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarMunicipioXID(EM_Munucipios Datos)
        {
            try
            {
                EM_MunicipioDatos MD = new EM_MunicipioDatos();
                MD.EliminarMunicipioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
