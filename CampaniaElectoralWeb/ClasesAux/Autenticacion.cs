using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaniaElectoral.ClasesAux
{
    public static class Autenticacion
    {

        public static bool Autenticar(string Usuario, string Password)
        {
            bool Band = false;

            if (Usuario.Equals("root") && Password.Equals("123456"))
                Band = true;

            return Band;
        }
    }
}