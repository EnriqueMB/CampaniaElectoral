using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class EM_EstadoDatos
    {
        public void ACEstado (CH_Estados Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDEstado, Datos.EstadoDesc, Datos.Siglas, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_CatEstado", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Estados> ObtenerCatalagoEstado(CH_Estados Datos)
        {
            try
            {
                List<CH_Estados> Lista = new List<CH_Estados>();
                CH_Estados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CatEstado");
                while (Dr.Read())
                {
                    Item = new CH_Estados();
                    Item.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Item.EstadoDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerEstadoXID(CH_Estados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEstado };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CatEstadoDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.EstadoDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEstadoXID(CH_Estados Datos)
        {
            object[] Parametro = { Datos.IDEstado, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_CatEstado", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }

        public List<CH_Estados> ObtenerComboxEstado(CH_Estados Datos)
        {
            try
            {
                List<CH_Estados> Lista = new List<CH_Estados>();
                CH_Estados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboCatEstado");
                while (Dr.Read())
                {
                    Item = new CH_Estados();
                    Item.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Item.EstadoDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
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
