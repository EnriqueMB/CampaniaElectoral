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
    public class EM_NotificacionDatos
    {
        public List<EM_Notificacion> ObtenerNotifiacion(EM_Notificacion Datos)
        {
            try
            {
                List<EM_Notificacion> Lista = new List<EM_Notificacion>();
                EM_Notificacion Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_Notificacion");
                while (Dr.Read())
                {
                    Item = new EM_Notificacion();
                    Item.IDNotificacion = Dr.GetString(Dr.GetOrdinal("IDNotificacion"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.Texto = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Item.Enviar = Dr.GetBoolean(Dr.GetOrdinal("Enviado"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Notificacion> EnviarNotifiacion(EM_Notificacion Datos)
        {
            try
            {
                List<EM_Notificacion> Lista = new List<EM_Notificacion>();
                EM_Notificacion Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_set_EnviarNotificaciones", Datos.IDNotificacion, Datos.IDUsuario);
                while (Dr.Read())
                {
                    Item = new EM_Notificacion();
                    Item.IDNotificacion = Dr.GetString(Dr.GetOrdinal("IDNotificacion"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Texto = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
                    Item.TokenCelular = Dr.GetString(Dr.GetOrdinal("TokenCelular"));
                    Item.IDCelular = Dr.GetInt32(Dr.GetOrdinal("IDTipoCelular"));
                    Item.Badge = Dr.GetInt32(Dr.GetOrdinal("Badge"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarNotificacionesXID(EM_Notificacion Datos)
        {
            object[] Parametro = { Datos.IDNotificacion, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_Notificacion", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }
    }
}
