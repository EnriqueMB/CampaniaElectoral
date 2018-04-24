using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
   public class GM_LoadBannerDatos
    {
        #region Banner 

        public void AGBanner(GM_LoadBanner Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDIBanner, Datos.IDBanner, Datos.IDTBanner, Datos.TextoInicial, Datos.TextoPrincipal, Datos.VerMas, Datos.URLBanner,  Datos.TextoButton, Datos.URLImagen, Datos.Alt, Datos.Title, Datos.Descripcion, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_AG_Banner", Parametros);
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

        public List<GM_LoadBanner> ObtenerListBanner(GM_LoadBanner Datos)
        {
            try
            {
                
                List<GM_LoadBanner> Lista = new List<GM_LoadBanner>();
                GM_LoadBanner Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_listBanner");
                while (Dr.Read())
                {
                    
                    Item = new GM_LoadBanner();
                    Item.IDBanner = Dr.GetString(Dr.GetOrdinal("IDBanner"));
                    Item.TextoInicial = Dr.GetString(Dr.GetOrdinal("TextoInicial"));
                    Item.TextoPrincipal = Dr.GetString(Dr.GetOrdinal("TextoPrincipal"));
                    Item.VerMas = Dr.GetBoolean(Dr.GetOrdinal("verMas"));
                    Item.URLBanner = Dr.GetString(Dr.GetOrdinal("UrlDestino"));
                    Item.TextoButton= Dr.GetString(Dr.GetOrdinal("TextButton"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
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

        public List<RR_DatosHome> ObtenerListaTextos(RR_DatosHome Datos)
        {
            try
            {

                List<RR_DatosHome> Lista = new List<RR_DatosHome>();
                RR_DatosHome Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TextoHome");
                while (Dr.Read())
                {

                    Item = new RR_DatosHome();
                    Item.TituloHacemos = Dr.GetString(Dr.GetOrdinal("tituloHacemos"));
                    Item.DescHacemos = Dr.GetString(Dr.GetOrdinal("descHacemos"));
                    Item.TituloAfiliate = Dr.GetString(Dr.GetOrdinal("tituloAfiliate"));
                    Item.DescAfiliate = Dr.GetString(Dr.GetOrdinal("descAfiliate"));
                    Item.TituloProxEvent = Dr.GetString(Dr.GetOrdinal("tituloProxEvent"));                    
                    Item.DescProxEvent = Dr.GetString(Dr.GetOrdinal("descProxEvent"));
                    Item.TituloEquipoTrabajo = Dr.GetString(Dr.GetOrdinal("tituloEquipoTrabajo"));
                    Item.DescEquipoTrabajo = Dr.GetString(Dr.GetOrdinal("descEquipoTrabajo"));
                    Item.TituloBlog = Dr.GetString(Dr.GetOrdinal("tituloBlog"));
                    Item.DescBlog = Dr.GetString(Dr.GetOrdinal("descBlog"));
                    Item.TituloContactanos = Dr.GetString(Dr.GetOrdinal("tituloContactanos"));
                    Item.Contactanos = Dr.GetString(Dr.GetOrdinal("descContactanos"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleBannerID(GM_LoadBanner Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDBanner };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_DetalleBanner", Parametros);
                while (Dr.Read())
                {
                    Datos.IDBanner = Dr.GetString(Dr.GetOrdinal("IDBanner"));
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

        public void EliminarIDBanner(GM_LoadBanner Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDBanner, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_ID_Banner", Parametros);
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

        public void ImagenSubidaFotoXID(GM_LoadBanner Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDBanner, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_ImagenLoadFoto", Parametros);
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
