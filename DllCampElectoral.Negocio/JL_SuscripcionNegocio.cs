using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class JL_SuscripcionNegocio
    {
        public void GuardarSuscripcion(JL_Suscripcion datos)
        {
            try
            {
                JL_SuscripcionDatos sd = new JL_SuscripcionDatos();
                sd.GuardarSuscripcion(datos);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
