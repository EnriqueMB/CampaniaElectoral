using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaniaElectoralEstadistica.ClaseAux
{
    public class Autenticacion
    {
        public static WN_Usuario Autenticar(WN_Usuario user)
        {
            DA_AutenticarNegocio autnegocio = new DA_AutenticarNegocio();
            return autnegocio.Autenticar(user);
        }
    }
}