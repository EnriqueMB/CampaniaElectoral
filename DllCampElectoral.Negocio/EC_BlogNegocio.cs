using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;
namespace DllCampElectoral.Negocio
{
   public class EC_BlogNegocio
    {
        public List<RR_Blog> ObtenerBlogsRecientes(RR_Blog Datos)
        {
            try
            {
                EC_BlogDatos datos = new EC_BlogDatos();
                return datos.ObtenerBlogsRecientes(Datos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
