using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;

namespace DllCampElectoral.Negocio
{
    public class FG_CatPartidoPoliticoAlianzaNegocio
    {
        public List<FG_CatPartidoPoliticoAlianza> ObtenerListaPartidosPoliticosAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                FG_CatPartidoPoliticoAlianzaDatos FG = new FG_CatPartidoPoliticoAlianzaDatos();
                return FG.ObtenerListaPartidosPoliticosAlianza(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CH_PartidoPolitico> ObtenerListaPartidosPoliticos(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                FG_CatPartidoPoliticoAlianzaDatos FG = new FG_CatPartidoPoliticoAlianzaDatos();
                return FG.ObtenerListaPartidosPoliticos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
