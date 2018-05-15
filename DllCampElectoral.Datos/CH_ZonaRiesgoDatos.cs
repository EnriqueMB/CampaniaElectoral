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
    public class CH_ZonaRiesgoDatos
    {
        public void ObtenerCombosZonaDeRiesgo(CH_ZonaRiesgo Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_CombosZonaDeRiesgo",Datos.IDEstado);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        Datos.ListaMunicipio = ObtenerComboMunicipios(Ds.Tables[0]);
                        Datos.ListaTipoRiesgos = ObtenerComboTipoRiesgos(Ds.Tables[1]);
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ACRiesgos(CH_ZonaRiesgo Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDZonaRiesgo, Datos.Titulo, Datos.Descripcion,
                                        Datos.IDTipoRiesgo, Datos.IDEstado, Datos.IDMunicipio, Datos.IDSeccion,Datos.IDCasilla,
                                        Datos.Latitud, Datos.Longitud, Datos.IDUsuario,Datos.IDColaborador };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_Riesgos", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerDetalleRiesgoXID(CH_ZonaRiesgo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDZonaRiesgo };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_RiesgoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDZonaRiesgo = Dr.GetString(Dr.GetOrdinal("IDRiesgo"));
                    Datos.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.IDTipoRiesgo = Dr.GetInt32(Dr.GetOrdinal("IDTipoRiesgo"));
                    Datos.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Datos.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
                    Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Datos.Latitud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Datos.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRiesgoXID(CH_ZonaRiesgo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDZonaRiesgo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_Riesgo", Parametros);
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

        public List<CH_ZonaRiesgo> ObtenerRiesgosXIDs(CH_ZonaRiesgo Datos)
        {
            try
            {
                List<CH_ZonaRiesgo> Lista = new List<CH_ZonaRiesgo>();
                CH_ZonaRiesgo Item;
                object[] Parametros = { Datos.IDEstado, Datos.IDMunicipio, Datos.IDPoligono };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ZonasRiesgoXID", Parametros);
                while(Dr.Read())
                {
                    Item = new CH_ZonaRiesgo();
                    Item.IDZonaRiesgo = Dr.GetString(Dr.GetOrdinal("IDRiesgo"));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.IDTipoRiesgo = Dr.GetInt32(Dr.GetOrdinal("IDTipo"));
                    Item.Latitud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Item.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.UrlIcon = Dr.GetString(Dr.GetOrdinal("UrlIcon"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos Auxiliares para llenado de combos

        private List<CH_Estados> ObtenerComboEstados(DataTable Tabla)
        {
            try
            {
                List<CH_Estados> Lista = new List<CH_Estados>();
                CH_Estados Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_Estados();
                    Item.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Item.EstadoDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<CH_Municipio> ObtenerComboMunicipios(DataTable Tabla)
        {
            try
            {
                List<CH_Municipio> Lista = new List<CH_Municipio>();
                CH_Municipio Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_Municipio();
                    Item.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
                    Item.Descripcion= Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<CH_TipoRiesgo> ObtenerComboTipoRiesgos(DataTable Tabla)
        {
            try
            {
                List<CH_TipoRiesgo> Lista = new List<CH_TipoRiesgo>();
                CH_TipoRiesgo Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_TipoRiesgo();
                    Item.IDTipoRiesgo = Dr.GetInt32(Dr.GetOrdinal("IDTipoRiesgo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        #endregion

    }
}
