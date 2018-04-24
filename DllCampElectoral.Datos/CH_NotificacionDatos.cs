using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class CH_NotificacionDatos
    {
        public void ObtenerCombosColaborador(CH_Notificacion Datos)
        {
            try
            {
                CH_Colaborador DatosResult = new CH_Colaborador();
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_ColaboradoresTipos", Datos.IDNotificacion);
                if(Ds!=null)
                {
                    if(Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        List<RR_TipoUsuarios> ListaTiposUsers = new List<RR_TipoUsuarios>();
                        RR_TipoUsuarios ItemTU;
                        while(Dr.Read())
                        {
                            ItemTU = new RR_TipoUsuarios();
                            ItemTU.IDTUsuario = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                            ItemTU.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                            ListaTiposUsers.Add(ItemTU);
                        }

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<CH_Colaborador> ListaColabs = new List<CH_Colaborador>();
                        CH_Colaborador ItemCo;
                        while(Dr2.Read())
                        {
                            ItemCo = new CH_Colaborador();
                            ItemCo.IDColaborador = Dr2.GetString(Dr2.GetOrdinal("IDColaborador"));
                            ItemCo.Nombre = Dr2.GetString(Dr2.GetOrdinal("Nombre"));
                            ItemCo.Seleccionado = Dr2.GetBoolean(Dr2.GetOrdinal("Seleccionado"));
                            ItemCo.IDTipoUsuario = Dr2.GetInt32(Dr2.GetOrdinal("IDTipoUsuario"));
                            ListaColabs.Add(ItemCo);
                        }
                        DatosResult.ListaUsers = ListaTiposUsers;
                        DatosResult.ListaColaboradores = ListaColabs;
                        Datos.Completado = true;
                        Datos.DatosAuxColab = DatosResult;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ACNotificaciones(CH_Notificacion Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "CH_spCSLDB_AC_Notificaciones",
                    new SqlParameter("NuevoRegistro", Datos.NuevoRegistro),
                    new SqlParameter("IDNotificacion", Datos.IDNotificacion),
                    new SqlParameter("Nombre", Datos.NombreNotif),
                    new SqlParameter("Titulo", Datos.TituloNotif),
                    new SqlParameter("Texto", Datos.Texto),
                    new SqlParameter("Todos", Datos.Todos),
                    new SqlParameter("TablaNotificaciones", Datos.TablaColaboradores),
                    new SqlParameter("IDUsuario", Datos.IDUsuario));
                if(Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleNotificacion(CH_Notificacion Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_NotificacionDetalle", Datos.IDNotificacion);
                while(Dr.Read())
                {
                    Datos.NombreNotif = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.TituloNotif = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Texto = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Datos.Todos = Dr.GetBoolean(Dr.GetOrdinal("Todos"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
