using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
   public  class WN_Combos
    {

        private string _parametro01;

        public string Parametro01String
        {
            get { return _parametro01; }
            set { _parametro01 = value; }
        }

        private int _parametro01Int;

        public int Parametro01Int
        {
            get { return _parametro01Int; }
            set { _parametro01Int = value; }
        }

        private string _cadenacoexion;

        public string CadenaConexion
        {
            get { return _cadenacoexion; }
            set { _cadenacoexion = value; }
        }

        private DataTable _satos;

        public DataTable Datos
        {
            get { return _satos; }
            set { _satos = value; }
        }




    }
}
