using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class AfiliadosNegocio
    {
        public Afiliados ObtenerAfiliadosAJAX(Afiliados _Datos)
        {
            try
            {
                AfiliadosDatos Datos = new AfiliadosDatos();
                return Datos.ObtenerAfiliadosAJAX(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
