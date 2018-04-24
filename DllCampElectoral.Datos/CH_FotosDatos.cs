using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class CH_FotosDatos
    {

        #region Catálogo Fotos de Galería

        public void ACFoto(CH_Foto Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDFoto, Datos.URLImagen, Datos.Alt, Datos.Title,
                                        Datos.Descripcion, Datos.NombreArchivo, Datos.Extension, Datos.CambioImagen, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_AC_Fotos", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                        Datos.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
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

        public List<CH_Foto> ObtenerCatalogoFotos(CH_Foto Datos)
        {
            try
            {
                List<CH_Foto> Lista = new List<CH_Foto>();
                CH_Foto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_GaleriaFotos");
                while (Dr.Read())
                {
                    Item = new CH_Foto();
                    Item.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.Extension = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleFotoXID(CH_Foto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDFoto };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_GaleriaFotosDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
                    Datos.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                    Datos.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Datos.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Datos.Extension = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFotoXID(CH_Foto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDFoto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_Foto", Parametros);
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

        public void ImagenSubidaFotoXID(CH_Foto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDFoto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_set_ImagenSubidaFoto", Parametros);
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

        #endregion

    }
}
