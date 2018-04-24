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
    public class CH_PoligonoDatos
    {
        #region  Poligonos

        public void ACPoligono(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPoligono, Datos.Nombre, Datos.Clave,
                                        Datos.IDEstado, Datos.IDMunicipio, Datos.Colonia,
                                        Datos.Latidud, Datos.Longitud, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_Poligonos", Parametros);
               if(Result != null)
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
        
        public void APuntosPoligono(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPoligono, Datos.Latidud, Datos.Longitud, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_A_PuntosPoligonos", Parametros);
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
        public List<CH_Poligono> ObtenerListaPoligonos(CH_Poligono Datos)
        {
            try
            {
                List<CH_Poligono> Lista = new List<CH_Poligono>();
                CH_Poligono Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_Poligonos");
                while (Dr.Read())
                {
                    Item = new CH_Poligono();
                    Item.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Item.EstadoDesc = Dr.GetString(Dr.GetOrdinal("EstadoDesc"));
                    Item.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("MunicipioDesc"));
                    Item.Colonia = Dr.GetString(Dr.GetOrdinal("Colonia"));
                    Item.TotalPuntos = Dr.GetInt32(Dr.GetOrdinal("CantidadPuntos"));
                    Item.Latidud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Item.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Item.LatitudLongitud = Item.Latidud.ToString() + " / " + Item.Longitud.ToString();
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<CH_Poligono> ObtenerPuntosPoligonos(CH_Poligono Datos)
        {
            try
            {
                List<CH_Poligono> Lista = new List<CH_Poligono>();
                CH_Poligono Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_PuntosPoligono", Datos.IDPoligono, Datos.EsPrincipal);
                while (Dr.Read())
                {
                    Item = new CH_Poligono();
                    Item.IDPunto = Dr.GetString(Dr.GetOrdinal("IDPunto"));
                    Item.OrdenPunto = Dr.GetInt32(Dr.GetOrdinal("Orden"));
                    Item.EsPrincipal = Dr.GetBoolean(Dr.GetOrdinal("EsPrincipal"));
                    Item.Latidud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Item.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerDetallePoligonoXID(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPoligono };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_PoligonoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                    Datos.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Datos.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
                    Datos.Colonia = Dr.GetString(Dr.GetOrdinal("Colonia"));
                    Datos.TotalPuntos = Dr.GetInt32(Dr.GetOrdinal("CantidadPuntos"));
                    Datos.Latidud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
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

        public void ObtenerDetallePoligonoXIDResumen(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPoligono };
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_PoligonoDetalleResumen", Parametros);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                            Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                            Datos.Clave = Dr.GetString(Dr.GetOrdinal("Clave"));
                            Datos.EstadoDesc = Dr.GetString(Dr.GetOrdinal("EstadoDesc"));
                            Datos.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("MunicipioDesc"));
                            Datos.Latidud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                            Datos.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                            Datos.Colonia = Dr.GetString(Dr.GetOrdinal("Colonia"));
                            break;
                        }
                        List<CH_Poligono> ListaPuntos = new List<CH_Poligono>();
                        CH_Poligono Punto;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Punto = new CH_Poligono();
                            Punto.IDPunto = Dr2.GetString(Dr2.GetOrdinal("IDPunto"));
                            Punto.OrdenPunto = Dr2.GetInt32(Dr2.GetOrdinal("Orden"));
                            Punto.Latidud = Dr2.GetDouble(Dr2.GetOrdinal("Latitud"));
                            Punto.Longitud = Dr2.GetDouble(Dr2.GetOrdinal("Longitud"));
                            ListaPuntos.Add(Punto);
                        }
                        Datos.ListaPuntos = ListaPuntos;
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void EliminarPoligonoXID(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPoligono, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_Poligono", Parametros);
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


        public void EliminarPuntoPoligonoXID(CH_Poligono Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPunto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_PuntoPoligono", Parametros);
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

        public List<CH_Poligono> ObtenerComboPoligonos(CH_Poligono Datos)
        {
            try
            {
                object[] parametros = { Datos.IDEstado, Datos.IDMunicipio };
                List<CH_Poligono> Lista = new List<CH_Poligono>();
                CH_Poligono Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ComboPoligono", parametros);
                while (Dr.Read())
                {
                    Item = new CH_Poligono();
                    Item.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));

                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboPoligono(CH_Poligono poligono)
        {
            DataSet ds = SqlHelper.ExecuteDataset(poligono.Conexion, "CH_spCSLDB_get_ComboPoligono", "1", "1");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        poligono.dataTable = ds.Tables[0];
                    }
                }
            }
        }
        #endregion
    }
}
