using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DllCampElectoral.Global;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class EM_EncuestaDatos
    {

        public void ACENcuesta(EM_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDEncuesta, Datos.NombreEncuesta, Datos.TituloGeneral, Datos.Descripcion, Datos.Observaciones, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_Encuesta", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
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

        public List<EM_Encuesta> ObtenerEncuestas(EM_Encuesta Datos)
        {
            try
            {
                List<EM_Encuesta> Lista = new List<EM_Encuesta>();
                EM_Encuesta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_Encuesta");
                while (Dr.Read())
                {
                    Item = new EM_Encuesta();
                    Item.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    Item.TituloGeneral = Dr.GetString(Dr.GetOrdinal("TituloGeneral"));
                    Item.NombreEncuesta = Dr.GetString(Dr.GetOrdinal("NombreEncuesta"));
                    Item.NombreEstatus = Dr.GetString(Dr.GetOrdinal("NombreEstatus"));
                    Item.CantidadPregunta = Dr.GetInt32(Dr.GetOrdinal("CantidadPregunta"));
                    Item.ColorEstatus = Dr.GetString(Dr.GetOrdinal("ColorEstatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleEncuestaXID(EM_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_EncuestaDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.NombreEncuesta = Dr.GetString(Dr.GetOrdinal("NombreEncuesta"));
                    Datos.TituloGeneral = Dr.GetString(Dr.GetOrdinal("TituloGeneral"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Observaciones = Dr.GetString(Dr.GetOrdinal("Observacion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuestaXID(EM_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_Encuesta", Parametros);
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

        public void CerrarEncuestaXID(EM_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_set_CerrarEncuesta", Parametros);
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
