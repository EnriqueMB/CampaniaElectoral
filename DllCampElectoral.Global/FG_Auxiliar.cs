using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public static class FG_Auxiliar
    {
        public static string ObtenerExtension(string imagen64)
        {
            string extension = string.Empty;
            int position = 0;

            position = imagen64.IndexOf("IVBOR");
            if (position > 0)
                return extension = "image/png";

            position = imagen64.IndexOf("/9J/4");
            if (position > 0)
                return extension = "image/jpeg";

            return extension;
        }
    }
}
