using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DllCampElectoral.Datos
{
    public class FG_CatPartidoPoliticoAlianzaDatos
    {
        public List<CH_PartidoPolitico> ObtenerListaPartidosPoliticos(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                List<CH_PartidoPolitico> lista = new List<CH_PartidoPolitico>();
                CH_PartidoPolitico item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_get_ListadosCatPartidoPoliticoAlianza", 1);
                while (Dr.Read())
                {
                    item = new CH_PartidoPolitico();
                    item.IDPartido = Dr.GetInt32(Dr.GetOrdinal("id_partido"));
                    item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    item.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    item.Logo = Dr.GetString(Dr.GetOrdinal("logo"));
                    item.ExtensionLogo = FG_Auxiliar.ObtenerExtensionImagenBase64(item.Logo);

                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FG_CatPartidoPoliticoAlianza> ObtenerListaPartidosPoliticosAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                List<FG_CatPartidoPoliticoAlianza> lista = new List<FG_CatPartidoPoliticoAlianza>();
                FG_CatPartidoPoliticoAlianza item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_get_ListadosCatPartidoPoliticoAlianza", 2);
                while (Dr.Read())
                {
                    item = new FG_CatPartidoPoliticoAlianza();
                    item.IDPartidoPoliticoAlianza = Dr.GetInt32(Dr.GetOrdinal("id_CatPoliticoAlianza"));
                    item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    item.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    item.Logo = Dr.GetString(Dr.GetOrdinal("logo"));
                    item.ExtensionBase64 = FG_Auxiliar.ObtenerExtensionImagenBase64(item.Logo);
                    item.PartidosPoliticos = Dr.GetString(Dr.GetOrdinal("partidos"));
                    
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FG_CatPartidoPoliticoAlianza ObtenerDatosAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                object[] Parametros =
                {
                    Datos.IDPartidoPoliticoAlianza
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_get_DatosAlianzaXIDAlianza", Parametros);
                while (Dr.Read())
                {

                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    Datos.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    Datos.Logo = Dr.GetString(Dr.GetOrdinal("logo"));
                    if (string.IsNullOrEmpty(Datos.Logo))
                    {
                        Datos.Logo = FG_Auxiliar.ImagenPredeterminada();
                        Datos.ImagenServer = false;
                    }
                    else
                    {
                        Datos.ImagenServer = true;
                    }
                    Datos.ExtensionBase64 = FG_Auxiliar.ObtenerExtensionImagenBase64(Datos.Logo);
                    Datos.PartidosPoliticos = Dr.GetString(Dr.GetOrdinal("partidos"));
                    break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FG_CatPartidoPoliticoAlianza CrearAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                object[] Parametros = 
                {
                    1
                    ,Datos.IDPartidoPoliticoAlianza
                    ,Datos.Nombre
                    ,Datos.Siglas
                    ,Datos.Logo
                    ,Datos.PartidosPoliticos
                    ,Datos.Usuario
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_ac_CatPartidoPoliticoAlianza", Parametros);
                while (Dr.Read())
                {
                    Datos.Completado = Dr.GetBoolean(Dr.GetOrdinal("completado")); ;
                    Datos.Mensaje = Dr.GetString(Dr.GetOrdinal("mensaje")); ;
                    break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FG_CatPartidoPoliticoAlianza EditarAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                object[] Parametros =
                {
                     2
                    ,Datos.IDPartidoPoliticoAlianza
                    ,Datos.Nombre
                    ,Datos.Siglas
                    ,Datos.Logo
                    ,Datos.PartidosPoliticos
                    ,Datos.Usuario
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_ac_CatPartidoPoliticoAlianza", Parametros);
                while (Dr.Read())
                {
                    Datos.Completado = Dr.GetBoolean(Dr.GetOrdinal("completado")); ;
                    Datos.Mensaje = Dr.GetString(Dr.GetOrdinal("mensaje")); ;
                    break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FG_CatPartidoPoliticoAlianza EliminarAlianza(FG_CatPartidoPoliticoAlianza Datos)
        {
            try
            {
                object[] Parametros =
                {
                     Datos.IDPartidoPoliticoAlianza
                    ,Datos.Usuario
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "FG_spCSLDB_del_CatPartidoPoliticoAlianzaXIDAlianza", Parametros);
                while (Dr.Read())
                {
                    Datos.Completado = Dr.GetBoolean(Dr.GetOrdinal("completado")); 
                    Datos.Mensaje = Dr.GetString(Dr.GetOrdinal("mensaje")); 
                    break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

