using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;
namespace DllCampElectoral.Negocio
{
    public class EC_TipoPreguntaNegocio
    {
        public List<EC_TipoPregunta> CargarCombo(EC_TipoPregunta Datos)
        {
            EC_TipoPreguntaDatos datos = new EC_TipoPreguntaDatos();
           return datos.ObtenerCatalogoTipoUsuario(Datos);
        }
    }
}
