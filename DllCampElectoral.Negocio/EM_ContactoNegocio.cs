using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_ContactoNegocio
    {
        public EM_Contacto ObtenerContactoWeb(EM_Contacto Datos)
        {
            try
            {
                EM_ContactoDatos MD = new EM_ContactoDatos();
                return MD.ObternerContacto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
