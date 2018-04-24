using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_EstadoNegocio
    {
        public void ACEstado(CH_Estados Datos)
        {
            try
            {
                EM_EstadoDatos ED = new EM_EstadoDatos();
                ED.ACEstado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Estados> ObtenerCatalogoEstados(CH_Estados Datos)
        {
            try
            {
                EM_EstadoDatos ED = new EM_EstadoDatos();
                return ED.ObtenerCatalagoEstado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerEstadoDetalleXID(CH_Estados Datos)
        {
            try
            {
                EM_EstadoDatos ED = new EM_EstadoDatos();
                ED.ObternerEstadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEstadosXID(CH_Estados Datos)
        {
            try
            {
                EM_EstadoDatos ED = new EM_EstadoDatos();
                ED.EliminarEstadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Estados> ObtenerComboEstados(CH_Estados Datos)
        {
            try
            {
                EM_EstadoDatos ED = new EM_EstadoDatos();
                return ED.ObtenerComboxEstado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
