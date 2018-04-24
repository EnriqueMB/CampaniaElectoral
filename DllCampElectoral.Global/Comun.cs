using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public static class Comun
    {
        private static string _NameApp;

        public static string NameApp
        {
            get { return _NameApp; }
            set { _NameApp = value; }
        }

        private static string _Conexion;

        public static string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private static string _IDUsuario;

        public static string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

    }
}
