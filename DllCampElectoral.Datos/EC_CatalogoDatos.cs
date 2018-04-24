using System;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DllCampElectoral.Global;
namespace DllCampElectoral.Datos
{
   public class EC_CatalogoDatos
    {
        public List<EC_ColaboradorJSON> ObtenerColaboradorXIDPoligono(CH_Poligono Datos)
        {
            try
            {
                List<EC_ColaboradorJSON> Lista = new List<EC_ColaboradorJSON>();
                EC_ColaboradorJSON Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "JL_spCSLDB_get_ComboColaboradoresXIDPoligono", Datos.IDPoligono);
                while (Dr.Read())
                {
                    Item = new EC_ColaboradorJSON();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CH_Poligono> ObtenerComboPoligonos(CH_Poligono Datos)
        {
            try
            {
                List<CH_Poligono> Lista = new List<CH_Poligono>();
                CH_Poligono Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_ComboPoligono", Datos.IDEstado, Datos.IDMunicipio);
                while (Dr.Read())
                {
                    Item = new CH_Poligono();
                    Item.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.Seccion = Dr.GetString(Dr.GetOrdinal("Seccion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerPoligonoAfiliado(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEstado,Datos.IDMunicipio,Datos.Clave };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_PoligonoAfiliados", Parametros);
                while (Dr.Read())
                {
                    Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetImagenesAfiliado(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.opcion, Datos.IDAfiliado };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_AfiliadosImagen", Parametros);
                while (Dr.Read())
                {
                    Datos.Imagen = Dr.GetString(Dr.GetOrdinal("Imagen"));
                    Datos.CredencialFrente = Dr.GetString(Dr.GetOrdinal("textoCredencial"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
