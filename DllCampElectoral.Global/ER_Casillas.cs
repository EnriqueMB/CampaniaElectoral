using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class ER_Casillas
    {
        private string _IDCasilla;

        public string IDCasilla
        {
            get { return _IDCasilla; }
            set { _IDCasilla = value; }
        }
        private string _DescCasilla;

        public string DescCasilla
        {
            get { return _DescCasilla; }
            set { _DescCasilla = value; }
        }

    }
}
