using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
   public class EC_BlogDatos
    {
        public List<RR_Blog> ObtenerBlogsRecientes(RR_Blog Datos)
        {
            try
            {
                List<RR_Blog> Lista = new List<RR_Blog>();
                RR_Blog Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_BlogRecientes");
                while (Dr.Read())
                {
                    Item = new RR_Blog();
                    Item.IDPublicacion = Dr.GetString(Dr.GetOrdinal("id_publicacion"));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal(("titulo")));
                    Item.Fecha = Dr.GetDateTime(Dr.GetOrdinal("fecha"));
                    Item.TextoHtml= Dr.GetString(Dr.GetOrdinal(("textoReducido")));
                    Item.UrlImagen= Dr.GetString(Dr.GetOrdinal(("urlImagen")));
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
