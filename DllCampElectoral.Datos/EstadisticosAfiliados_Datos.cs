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
    public class EstadisticosAfiliados_Datos
    {
        public EstadisticosAfiliados ObtenerEstadisticosAfiliados(string Conexion)
        {
            try
            {
                EstadisticosAfiliados Result = new EstadisticosAfiliados();
                DataSet Ds = SqlHelper.ExecuteDataset(Conexion, "INE_spCSLDB_get_EstadisticosAfiliados");
                if(Ds!= null)
                {
                    if(Ds.Tables.Count == 3)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Result.Completado = true;
                            Result.FechaUltimoAfiliado = !Dr.IsDBNull(Dr.GetOrdinal("FechaUltimoAfiliado")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaUltimoAfiliado")) : DateTime.MinValue;
                            Result.TiempoTranscurridoUAHoras = !Dr.IsDBNull(Dr.GetOrdinal("TiempoTranscurridoUAHoras")) ? Dr.GetInt32(Dr.GetOrdinal("TiempoTranscurridoUAHoras")) : 0;
                            Result.PorcentajeAfiliados = !Dr.IsDBNull(Dr.GetOrdinal("PorcentajeAfiliados")) ? Dr.GetInt32(Dr.GetOrdinal("PorcentajeAfiliados")) : 0;
                            Result.PromedioInscripcionXDia = !Dr.IsDBNull(Dr.GetOrdinal("PromedioInscripcionXDia")) ? Dr.GetInt32(Dr.GetOrdinal("PromedioInscripcionXDia")) : 0;
                            Result.MetaCampania = !Dr.IsDBNull(Dr.GetOrdinal("MetaCampania")) ? Dr.GetInt32(Dr.GetOrdinal("MetaCampania")) : 0;
                            Result.AfiliadosInscritos = !Dr.IsDBNull(Dr.GetOrdinal("AfiliadosInscritos")) ? Dr.GetInt32(Dr.GetOrdinal("AfiliadosInscritos")) : 0;
                            Result.AfiliadosValidos = !Dr.IsDBNull(Dr.GetOrdinal("AfiliadosValidos")) ? Dr.GetInt32(Dr.GetOrdinal("AfiliadosValidos")) : 0;
                            Result.AfiliadosRechazados = !Dr.IsDBNull(Dr.GetOrdinal("AfiliadosRechazados")) ? Dr.GetInt32(Dr.GetOrdinal("AfiliadosRechazados")) : 0;
                            Result.SeccionesConcluidas = !Dr.IsDBNull(Dr.GetOrdinal("SeccionesConcluidas")) ? Dr.GetInt32(Dr.GetOrdinal("SeccionesConcluidas")) : 0;
                            Result.SeccionesFaltantes = !Dr.IsDBNull(Dr.GetOrdinal("SeccionesFaltantes")) ? Dr.GetInt32(Dr.GetOrdinal("SeccionesFaltantes")) : 0;
                            Result.PorcentajeAvanceSeccion = !Dr.IsDBNull(Dr.GetOrdinal("PorcentajeSecciones")) ? Dr.GetInt32(Dr.GetOrdinal("PorcentajeSecciones")) : 0;
                            break;
                        }

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<EstadisticosRepresentantesSeccion> Lista = new List<EstadisticosRepresentantesSeccion>();
                        EstadisticosRepresentantesSeccion Item;
                        while(Dr2.Read())
                        {
                            Item = new EstadisticosRepresentantesSeccion();
                            Item.Seccion = !Dr2.IsDBNull(Dr2.GetOrdinal("id_seccion")) ? Dr2.GetInt32(Dr2.GetOrdinal("id_seccion")) : 0;
                            Item.Nombre = !Dr2.IsDBNull(Dr2.GetOrdinal("Representante")) ? Dr2.GetString(Dr2.GetOrdinal("Representante")) : string.Empty;
                            Item.Imagen = !Dr2.IsDBNull(Dr2.GetOrdinal("Imagen")) ? Dr2.GetString(Dr2.GetOrdinal("Imagen")) : string.Empty;
                            Item.Avance = !Dr2.IsDBNull(Dr2.GetOrdinal("Avance")) ? Dr2.GetInt32(Dr2.GetOrdinal("Avance")) : 0;
                            Item.CssClass = !Dr2.IsDBNull(Dr2.GetOrdinal("CssClass")) ? Dr2.GetString(Dr2.GetOrdinal("CssClass")) : string.Empty;
                            Lista.Add(Item);
                        }
                        Result.Lista = Lista;

                        Result.TablaSecciones = Ds.Tables[2];
                    }
                }
                
                return Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public object[] ObtenerPuntosStringXIDSeccion(string Conexion, int IDSeccion)
        {
            try
            {

                SqlDataReader Dr = SqlHelper.ExecuteReader(Conexion, "INE_spCSLDB_get_PuntosSeccion", IDSeccion);
                string Poligono = string.Empty;
                int Avance = 0;
                while(Dr.Read())
                {
                    Poligono = !Dr.IsDBNull(Dr.GetOrdinal("Poligono")) ? Dr.GetString(Dr.GetOrdinal("Poligono")) : string.Empty;
                    Avance = !Dr.IsDBNull(Dr.GetOrdinal("Avance")) ? Dr.GetInt32(Dr.GetOrdinal("Avance")) : 0;
                }
                Dr.Close();
                return new object[] { Poligono, Avance};
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public EstadisticosAfiliados ObtenerEvaluacionAJAX(EstadisticosAfiliados _Datos)
        {
            try
            {
                List<EstadisticosRepresentantesSeccion> Lista = new List<EstadisticosRepresentantesSeccion>();
                EstadisticosRepresentantesSeccion Item;
                object[] Parametros = { _Datos.TipoLista, _Datos.Start, _Datos.Length, _Datos.SearchValue, _Datos.OrderBy, _Datos.OrderDirection ?? string.Empty };
                DataSet Ds = SqlHelper.ExecuteDataset(_Datos.Conexion, "INE_spCSLDB_get_RepresentantesXTipoAvance", Parametros);

                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr2 = Ds.Tables[0].CreateDataReader();
                        while (Dr2.Read())
                        {
                            _Datos.RecordTotal = !Dr2.IsDBNull(Dr2.GetOrdinal("TotalRecords")) ? Dr2.GetInt32(Dr2.GetOrdinal("TotalRecords")) : 0;
                            _Datos.RecordFilter = !Dr2.IsDBNull(Dr2.GetOrdinal("SearchRecords")) ? Dr2.GetInt32(Dr2.GetOrdinal("SearchRecords")) : 0;
                            break;
                        }

                        DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                        while (Dr.Read())
                        {
                            Item = new EstadisticosRepresentantesSeccion();
                            Item.Seccion = !Dr.IsDBNull(Dr.GetOrdinal("id_seccion")) ? Dr.GetInt32(Dr.GetOrdinal("id_seccion")) : 0;
                            Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Representante")) ? Dr.GetString(Dr.GetOrdinal("Representante")) : string.Empty;
                            Item.Imagen = !Dr.IsDBNull(Dr.GetOrdinal("Imagen")) ? Dr.GetString(Dr.GetOrdinal("Imagen")) : string.Empty;
                            Item.Avance = !Dr.IsDBNull(Dr.GetOrdinal("Avance")) ? Dr.GetInt32(Dr.GetOrdinal("Avance")) : 0;
                            Lista.Add(Item);
                        }
                        
                    }
                    _Datos.Lista = Lista;
                }
                return _Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
