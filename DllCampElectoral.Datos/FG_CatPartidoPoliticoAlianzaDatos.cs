using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DllCampElectoral.Datos
{
    public class FG_CatPartidoPoliticoAlianzaDatos
    {
        public List<CH_PartidoPolitico> ObtenerListaPartidosPoliticos(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                List<CH_PartidoPolitico> lista = new List<CH_PartidoPolitico>();
                CH_PartidoPolitico item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_get_ListadosCatPartidoPoliticoAlianza", 1);
                while (Dr.Read())
                {
                    item = new CH_PartidoPolitico();
                    item.IDPartido = Dr.GetInt32(Dr.GetOrdinal("id_partido"));
                    item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    item.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    item.Logo = Dr.GetString(Dr.GetOrdinal("logo"));
                    item.ExtensionLogo = FG_Auxiliar.ObtenerExtensionImagenBase64(item.Logo);

                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FG_CatPartidoPoliticoAlianza> ObtenerListaPartidosPoliticosAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                List<FG_CatPartidoPoliticoAlianza> lista = new List<FG_CatPartidoPoliticoAlianza>();
                FG_CatPartidoPoliticoAlianza item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_get_ListadosCatPartidoPoliticoAlianza", 2);
                while (Dr.Read())
                {
                    item = new FG_CatPartidoPoliticoAlianza();
                    item.IDPartidoPoliticoAlianza = Dr.GetInt32(Dr.GetOrdinal("id_CatPoliticoAlianza"));
                    item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    item.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    item.Logo = Dr.GetString(Dr.GetOrdinal("logo"));
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
