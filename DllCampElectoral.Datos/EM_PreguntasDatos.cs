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
    public class EM_PreguntasDatos
    {
        public void ACPreguntas(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPreguntas, Datos.IDTipoPregunta, Datos.IDEncuesta, Datos.NombrePregunta, Datos.Orden, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_Preguntas", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDPreguntas = Dr.GetString(Dr.GetOrdinal("IDPRegunta"));
                        Datos.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
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

        public List<EM_Preguntas> ObtenerPregutasXIDEncuesta(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta };
                List<EM_Preguntas> Lista = new List<EM_Preguntas>();
                EM_Preguntas Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_PreguntaXIDEncuesta", Parametros);
                while (Dr.Read())
                {
                    Item = new EM_Preguntas();
                    Item.IDPreguntas = Dr.GetString(Dr.GetOrdinal("IDPregunta"));
                    Item.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    Item.NombrePregunta = Dr.GetString(Dr.GetOrdinal("NombrePregunta"));
                    Item.FechaCaptura = Dr.GetDateTime(Dr.GetOrdinal("FechaCaptura"));
                    Item.CantidadRespuesta = Dr.GetInt32(Dr.GetOrdinal("CantidadRespuesta"));
                    Item.NombreTipoPre = Dr.GetString(Dr.GetOrdinal("TipoPregunta"));
                    Item.Resultado = Dr.GetInt32(Dr.GetOrdinal("Orden"));
                    Item.IDTipoPregunta = Dr.GetInt32(Dr.GetOrdinal("IDTipoRespuesta"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePreguntaXID(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPreguntas };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_PreguntaDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    Datos.NombrePregunta = Dr.GetString(Dr.GetOrdinal("NombrePregunta"));
                    Datos.IDTipoPregunta = Dr.GetInt32(Dr.GetOrdinal("IDTipoPregunta"));
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

        public void EliminarPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPreguntas, Datos.IDEncuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_Preguntas", Parametros);
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

        public void ObtenerCamposPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPreguntas };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_PreguntaDetalleCamposMapaXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    Datos.TituloRespuesta = Dr.GetString(Dr.GetOrdinal("TituloRespuesta"));
                    Datos.PeriodoDatos = Dr.GetString(Dr.GetOrdinal("PeriodoDatos"));
                    Datos.TituloPorcentaje = Dr.GetString(Dr.GetOrdinal("TituloPorcentaje"));
                    Datos.Explicacion = Dr.GetString(Dr.GetOrdinal("Explicacion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizacionCamposPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPreguntas, Datos.TituloRespuesta, Datos.PeriodoDatos, Datos.TituloPorcentaje, Datos.Explicacion, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_set_PreguntasActualizacion", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDPreguntas = Dr.GetString(Dr.GetOrdinal("IDPregunta"));
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
    }
}
