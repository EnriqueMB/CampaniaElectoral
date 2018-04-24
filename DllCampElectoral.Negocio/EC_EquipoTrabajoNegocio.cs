using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;
namespace DllCampElectoral.Negocio
{
   public class EC_EquipoTrabajoNegocio
    {
        public List<EC_EquipoTrabajo> ObtenerMiembrosEquipo(EC_EquipoTrabajo Datos)
        {
            try
            {
                EC_EquipoTrabajoDatos Lista = new EC_EquipoTrabajoDatos();
                return Lista.ObtenerMiembrosEquipo(Datos);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EC_EquipoTrabajo> CargarGrid(EC_EquipoTrabajo Datos)
        {
            try
            {
                EC_EquipoTrabajoDatos Lista = new EC_EquipoTrabajoDatos();
                return Lista.CargarGrid(Datos);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ObtenerMiembroDetalle(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                EC_EquipoTrabajoDatos ETD = new EC_EquipoTrabajoDatos();
                ETD.ObtenerDetalleMiembroEquipo(Datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void EliminarMiembroTrabajo(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                EC_EquipoTrabajoDatos ETD = new EC_EquipoTrabajoDatos();
                ETD.EliminarMiembroEquipo(Datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
