using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class AfiliadosDatos
    {

        public Afiliados ObtenerAfiliadosAJAX(Afiliados _Datos)
        {
            try
            {
                List<Afiliados> Lista = new List<Afiliados>();
                Afiliados Item;
                object[] Parametros = { _Datos.Start,
                                        _Datos.Length,
                                        _Datos.SearchValue,
                                        _Datos.OrderBy,
                                        _Datos.OrderDirection ?? string.Empty,
                                        _Datos.TipoBusqueda,
                                        _Datos.Seccion,
                                        _Datos.FechaInicio,
                                        _Datos.FechaFin,
                                        _Datos.Ratificado,
                                        _Datos.DatosCompletados};
                DataSet Ds = SqlHelper.ExecuteDataset(_Datos.Conexion, "spCSLDB_get_AfiliadosAjax", Parametros);

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
                            Item = new Afiliados();
                            Item.IDAfiliado = !Dr.IsDBNull(Dr.GetOrdinal("IDAfiliado")) ? Dr.GetString(Dr.GetOrdinal("IDAfiliado")) : string.Empty;
                            Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? Dr.GetString(Dr.GetOrdinal("Nombre")) : string.Empty;
                            Item.FechaAfiliacion = !Dr.IsDBNull(Dr.GetOrdinal("FechaAfiliacion")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaAfiliacion")) : DateTime.Today;
                            Item.Ratificado = !Dr.IsDBNull(Dr.GetOrdinal("Estatus")) ? Dr.GetBoolean(Dr.GetOrdinal("Estatus")) : false;
                            Item.Seccion = !Dr.IsDBNull(Dr.GetOrdinal("Seccion")) ? Dr.GetInt32(Dr.GetOrdinal("Seccion")) : 0;
                            Item.ClaveElector = !Dr.IsDBNull(Dr.GetOrdinal("ClaveElector")) ? Dr.GetString(Dr.GetOrdinal("ClaveElector")) : string.Empty;
                            Item.Operador = !Dr.IsDBNull(Dr.GetOrdinal("Colaborador")) ? Dr.GetString(Dr.GetOrdinal("Colaborador")) : string.Empty;
                            Lista.Add(Item);
                        }
                        _Datos.ListaAfiliados = Lista;
                    }
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
