using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;

namespace DllCampElectoral.Negocio
{
    public class DA_AutenticarNegocio
    {
        public WN_Usuario Autenticar(WN_Usuario user)
        {
            DA_AutenticarDatos autdatos = new DA_AutenticarDatos();
           return autdatos.Autenticar(user);
        }
    }
}
