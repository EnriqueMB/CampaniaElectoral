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
    public class EM_GastosDatos
    {
        public void ACGastos(EM_Gastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDGastos, Datos.IDMotivo, Datos.IDSubMotivo, Datos.Nombre, Datos.Descripcion, Datos.Monto, Datos.IDResponsable, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_Gastos", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDGastos = Dr.GetString(Dr.GetOrdinal("IDGastos"));
                    }
                    Datos.Resultado = Resultado;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Gastos> ObtenerGastos(EM_Gastos Datos)
        {
            try
            {
                List<EM_Gastos> Lista = new List<EM_Gastos>();
                EM_Gastos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_Gastos");
                while (Dr.Read())
                {
                    Item = new EM_Gastos();
                    Item.IDGastos = Dr.GetString(Dr.GetOrdinal("IDGastos"));
                    Item.IDMotivo = Dr.GetInt32(Dr.GetOrdinal("IDMotivo"));
                    Item.IDSubMotivo = Dr.GetInt32(Dr.GetOrdinal("IDSubMotivo"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("NombreGasto"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Monto = Dr.GetDecimal(Dr.GetOrdinal("Monto"));
                    Item.IDResponsable = Dr.GetString(Dr.GetOrdinal("IDResponsable"));
                    Item.NombreResponsable = Dr.GetString(Dr.GetOrdinal("NombreColaborador"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleGastosXID(EM_Gastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDGastos };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_GastosDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDGastos = Dr.GetString(Dr.GetOrdinal("IDGastos"));
                    Datos.IDMotivo = Dr.GetInt32(Dr.GetOrdinal("IDMotivo"));
                    Datos.IDSubMotivo = Dr.GetInt32(Dr.GetOrdinal("IDSubMotivo"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("NombreGasto"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Monto = Dr.GetDecimal(Dr.GetOrdinal("Monto"));
                    Datos.IDResponsable = Dr.GetString(Dr.GetOrdinal("IDResponsable"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGastosXID(EM_Gastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDGastos, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_Gastos", Parametros);
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

     
    }
}
