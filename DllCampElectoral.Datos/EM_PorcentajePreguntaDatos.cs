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
    public class EM_PorcentajePreguntaDatos
    {
        public void ACPorcentaje(EM_PorcentajePregunta Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPorcentaje, Datos.IDPregunta, Datos.Descripcion, Datos.Orden, Datos.Color, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_PorcentajePreguntas", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDPorcentaje = Dr.GetString(Dr.GetOrdinal("IDPorcentaje"));
                        Datos.IDPregunta = Dr.GetString(Dr.GetOrdinal("IDPregunta"));
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

        public List<EM_PorcentajePregunta> ObtenerPorcentajePregunta(EM_PorcentajePregunta Datos)
        {
            try
            {
                List<EM_PorcentajePregunta> Lista = new List<EM_PorcentajePregunta>();
                EM_PorcentajePregunta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ProcentajeXIDPregunta", Datos.IDPregunta);
                while (Dr.Read())
                {
                    Item = new EM_PorcentajePregunta();
                    Item.IDPorcentaje = Dr.GetString(Dr.GetOrdinal("IDPorcentaje"));
                    Item.IDPregunta = Dr.GetString(Dr.GetOrdinal("IDPregunta"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Orden = Dr.GetInt32(Dr.GetOrdinal("Orden"));
                    Item.Color = Dr.GetString(Dr.GetOrdinal("Color"));
                    Item.PorcentaleInicial = Dr.GetDecimal(Dr.GetOrdinal("PorcentajeInicial"));
                    Item.PorcentajeFinal = Dr.GetDecimal(Dr.GetOrdinal("PorcentajeFinal"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePordentajePreguntaXID(EM_PorcentajePregunta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPorcentaje };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_PreguntaDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Color = Dr.GetString(Dr.GetOrdinal("Color"));
                    Datos.Orden = Dr.GetInt32(Dr.GetOrdinal("Orden"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPorcentajePreguntaXID(EM_PorcentajePregunta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPorcentaje, Datos.IDPregunta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_PorcentaXIDPreguntas", Parametros);
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
