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
    public class SeccionesDatos
    {
        public List<Secciones> ObtenerSecciones(Secciones _Datos)
        {
            try
            {
                List<Secciones> Lista = new List<Secciones>();
                Secciones Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(_Datos.Conexion, "spCSLDB_get_CatSecciones", _Datos.IDSeccion);
                while(Dr.Read())
                {
                    Item = new Secciones();
                    Item.IDSeccion = !Dr.IsDBNull(Dr.GetOrdinal("id_seccion")) ? Dr.GetInt32(Dr.GetOrdinal("id_seccion")) : 0;
                    Item.TipoSeccion = !Dr.IsDBNull(Dr.GetOrdinal("descripcion")) ? Dr.GetString(Dr.GetOrdinal("descripcion")) : string.Empty;
                    Lista.Add(Item); 
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Secciones ObtenerSeccionesAJAX(Secciones _Datos)
        {
            try
            {
                List<Secciones> Lista = new List<Secciones>();
                Secciones Item;
                object[] Parametros = { _Datos.Start, _Datos.Length, _Datos.SearchValue, _Datos.OrderBy, _Datos.OrderDirection ?? string.Empty};
                DataSet Ds = SqlHelper.ExecuteDataset(_Datos.Conexion, "spCSLDB_get_SeccionesAjax", Parametros);

                if(Ds != null)
                {
                    if(Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr2 = Ds.Tables[0].CreateDataReader();
                        while(Dr2.Read())
                        {
                            _Datos.RecordTotal = !Dr2.IsDBNull(Dr2.GetOrdinal("TotalRecords")) ? Dr2.GetInt32(Dr2.GetOrdinal("TotalRecords")) : 0;
                            _Datos.RecordFilter = !Dr2.IsDBNull(Dr2.GetOrdinal("SearchRecords")) ? Dr2.GetInt32(Dr2.GetOrdinal("SearchRecords")) : 0;
                            break;
                        }

                        DataTableReader Dr = Ds.Tables[1].CreateDataReader();
                        while (Dr.Read())
                        {
                            Item = new Secciones();
                            Item.IDSeccion = !Dr.IsDBNull(Dr.GetOrdinal("id_seccion")) ? Dr.GetInt32(Dr.GetOrdinal("id_seccion")) : 0;
                            Item.TipoSeccion = !Dr.IsDBNull(Dr.GetOrdinal("descripcion")) ? Dr.GetString(Dr.GetOrdinal("descripcion")) : string.Empty;
                            Lista.Add(Item);
                        }
                        _Datos.ListaSecciones = Lista;
                    }
                }
                return _Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Secciones ObtenerDetalleSeccion(Secciones _Datos)
        {
            try
            {
                Secciones Result = new Secciones();
                SqlDataReader Dr = SqlHelper.ExecuteReader(_Datos.Conexion, "INE_spCSLDB_get_SeccionXID", _Datos.IDSeccion);
                _Datos.IDSeccion = -1;
                while(Dr.Read())
                {
                    Result.IDSeccion = !Dr.IsDBNull(Dr.GetOrdinal("IDSeccion")) ? Dr.GetInt32(Dr.GetOrdinal("IDSeccion")) : -1;
                    Result.Estado = !Dr.IsDBNull(Dr.GetOrdinal("Estado")) ? Dr.GetString(Dr.GetOrdinal("Estado")) : string.Empty;
                    Result.Municipio = !Dr.IsDBNull(Dr.GetOrdinal("Municipio")) ? Dr.GetString(Dr.GetOrdinal("Municipio")) : string.Empty;
                    Result.Poligono = !Dr.IsDBNull(Dr.GetOrdinal("Poligono")) ? Dr.GetString(Dr.GetOrdinal("Poligono")) : string.Empty;
                    Result.Casillas = !Dr.IsDBNull(Dr.GetOrdinal("Casillas")) ? Dr.GetString(Dr.GetOrdinal("Casillas")) : string.Empty;
                }
                return Result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
