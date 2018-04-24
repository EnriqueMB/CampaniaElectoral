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
    public class EC_TipoPreguntaDatos
    {
        public List<EC_TipoPregunta> ObtenerCatalogoTipoUsuario(EC_TipoPregunta Datos)
        {
            try
            {
                List<EC_TipoPregunta> Lista = new List<EC_TipoPregunta>();
                EC_TipoPregunta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_TipoPregunta");
                while (Dr.Read())
                {
                    Item = new EC_TipoPregunta();
                    Item.id_pregunta = Dr.GetInt32(Dr.GetOrdinal(("id_tipoPregunta")));
                    Item.descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
