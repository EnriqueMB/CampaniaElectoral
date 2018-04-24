using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_ContactoNegocio
    {
        public void AC_DatosDeContacto(CH_Contacto Datos)
        {
            try
            {
                CH_ContactoDatos CD = new CH_ContactoDatos();
                CD.AC_DatosDeContacto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerDatosContacto(CH_Contacto Datos)
        {
            try
            {
                CH_ContactoDatos CD = new CH_ContactoDatos();
                CD.ObtenerDatosContacto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
