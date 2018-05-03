using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class ER_SeccionesDatos
    {
        public List<ER_Secciones> ObtenerComboSecciones(ER_Secciones Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "ER_spCSLDB_get_ComboSecciones");
                List<ER_Secciones> Lista = new List<ER_Secciones>();
                ER_Secciones Item;
                while (Dr.Read())
                {
                    Item = new ER_Secciones();
                    Item.IDSeccion = Convert.ToInt32(Dr.GetString(Dr.GetOrdinal("id_seccion")));
                    Item.IDMunicipio = Convert.ToInt32(Dr.GetString(Dr.GetOrdinal("id_municipio")));
                    Item.ID_Distrito = Convert.ToInt32(Dr.GetString(Dr.GetOrdinal("id_distrito")));
                    Item.Municipio = Dr.GetString(Dr.GetOrdinal("municipio"));
                    Lista.Add(Item);
                }
                return Datos.listaSecciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
