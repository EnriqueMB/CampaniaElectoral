using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_GastosNegocio
    {
        public void ACGastos(EM_Gastos Datos)
        {
            try
            {
                EM_GastosDatos GD = new EM_GastosDatos();
                GD.ACGastos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Gastos> ObtenerGastos(EM_Gastos Datos)
        {
            try
            {
                EM_GastosDatos GD = new EM_GastosDatos();
                return GD.ObtenerGastos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleGastosXID(EM_Gastos Datos)
        {
            try
            {
                EM_GastosDatos GD = new EM_GastosDatos();
                GD.ObtenerDetalleGastosXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGastosXID(EM_Gastos Datos)
        {
            try
            {
                EM_GastosDatos GD = new EM_GastosDatos();
                GD.EliminarGastosXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
