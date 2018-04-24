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
    public class EM_MisionVisionDatos
    {
        public void ACMisionVision(EM_MisionVision Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDMisionVision, Datos.Titulo, Datos.Descripcion, Datos.Mision, 
                                          Datos.Vision, Datos.UrlImagenM, Datos.AltImagenM, Datos.TituloImagenM, Datos.UrlImagenV, 
                                          Datos.AltImagenV, Datos.TituloImagenV, Datos.Valores, Datos.ImagenGuardada, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_MisionVision", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.UrlImagenM = Dr.GetString(Dr.GetOrdinal("UrlLogoM"));
                        Datos.UrlImagenV = Dr.GetString(Dr.GetOrdinal("UrlLogoV"));
                        Datos.IDMisionVision = Dr.GetInt32(Dr.GetOrdinal("IDMisionVision"));
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
        /*,[urlImagenM]
			,[altM]
			,[titleM]
			,[urlImagenV]
			,[altV]
			,[titleV]
			,[valores]*/
        public List<EM_MisionVision> ObtenerCatalagoMisionVision(EM_MisionVision Datos)
        {
            try
            {
                List<EM_MisionVision> Lista = new List<EM_MisionVision>();
                EM_MisionVision Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_MisionVision");
                while (Dr.Read())
                {
                    Item = new EM_MisionVision();
                    Item.IDMisionVision = Dr.GetInt32(Dr.GetOrdinal("IDMisionVision"));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Mision = Dr.GetString(Dr.GetOrdinal("Mision"));
                    Item.Vision = Dr.GetString(Dr.GetOrdinal("Vision"));
                    //Item.UrlImagenM = Dr.GetString(Dr.GetOrdinal("urlImagenM"));
                    //Item.AltImagenM = Dr.GetString(Dr.GetOrdinal("altM"));
                    //Item.TituloImagenM = Dr.GetString(Dr.GetOrdinal("titleM"));
                    //Item.UrlImagenV = Dr.GetString(Dr.GetOrdinal("urlImagenV"));
                    //Item.AltImagenV = Dr.GetString(Dr.GetOrdinal("altV"));
                    //Item.TituloImagenV = Dr.GetString(Dr.GetOrdinal("titleV"));
                    //Item.Valores = Dr.GetString(Dr.GetOrdinal("valores"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerMisionVisionXID(EM_MisionVision Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMisionVision };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_MisionVisionDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Mision = Dr.GetString(Dr.GetOrdinal("Mision"));
                    Datos.Vision = Dr.GetString(Dr.GetOrdinal("Vision"));
                    Datos.UrlImagenM = Dr.GetString(Dr.GetOrdinal("urlImagenM"));
                    Datos.AltImagenM = Dr.GetString(Dr.GetOrdinal("altM"));
                    Datos.TituloImagenM = Dr.GetString(Dr.GetOrdinal("titleM"));
                    Datos.UrlImagenV = Dr.GetString(Dr.GetOrdinal("urlImagenV"));
                    Datos.AltImagenV = Dr.GetString(Dr.GetOrdinal("altV"));
                    Datos.TituloImagenV = Dr.GetString(Dr.GetOrdinal("titleV"));
                    Datos.Valores = Dr.GetString(Dr.GetOrdinal("valores"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EM_MisionVision ObtenerMisionVision(EM_MisionVision datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.Conexion, "EM_spCSLDB_get_MisionVisionWeb");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaDatos = ds.Tables[0];
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarMisionVisionXID(EM_MisionVision Datos)
        {
            object[] Parametro = { Datos.IDMisionVision, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_MisionVision", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }

        public void ImagenSubidMisionVisionXID(EM_MisionVision Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMisionVision, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_set_ImagenSubidaMisionVison", Parametros);
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
