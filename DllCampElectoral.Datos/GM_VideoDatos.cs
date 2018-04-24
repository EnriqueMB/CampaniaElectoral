using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace DllCampElectoral.Datos
{
    public class GM_VideoDatos
    {

      #region Video
       //Agree Video
        public void AGModuloVideo(GM_VideosLoad Datos)
        {
            try
            {
              
                object[] Parametros = { Datos.NuevoVideo, Datos.IDVideo, Datos.Url, Datos.Alt, Datos.Title, Datos.Description, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_AC_ModuloVideo", Parametros);
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
      //View list Video
        public List<GM_VideosLoad> ObtenerDetalleVideo(GM_VideosLoad Datos)
        {
            try
            {
                List<GM_VideosLoad> Lista = new List<GM_VideosLoad>();
                GM_VideosLoad ItView;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_VideosView");
                while (Dr.Read())
                {                  
                    ItView = new GM_VideosLoad();
                    ItView.IDVideo = Dr.GetString(Dr.GetOrdinal("IDVideo"));
                    ItView.Url = Dr.GetString(Dr.GetOrdinal("urlVideo"));
                    string[] tokens = ItView.Url.Split(new[] { "v=" }, StringSplitOptions.None);
                    ItView.Url = "https://img.youtube.com/vi/" + tokens[1] + "/0.jpg";
                    ItView.Alt = Dr.GetString(Dr.GetOrdinal("alt"));
                    ItView.Title = Dr.GetString(Dr.GetOrdinal("title"));
                    ItView.Description = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(ItView);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GM_VideosLoad> ObtenerDetalleVideoPagina(GM_VideosLoad Datos)
        {
            try
            {
                List<GM_VideosLoad> Lista = new List<GM_VideosLoad>();
                GM_VideosLoad ItView;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_VideosPagina");
                while (Dr.Read())
                {
                    ItView = new GM_VideosLoad();
                    ItView.IDVideo = Dr.GetString(Dr.GetOrdinal("IDVideo"));
                    ItView.Url = Dr.GetString(Dr.GetOrdinal("urlVideo"));
                    ItView.Link = ItView.Url;
                    string[] tokens = ItView.Url.Split(new[] { "v=" }, StringSplitOptions.None);
                    ItView.Url = "https://img.youtube.com/vi/" + tokens[1] + "/0.jpg";
                    ItView.Alt = Dr.GetString(Dr.GetOrdinal("alt"));
                    ItView.Title = Dr.GetString(Dr.GetOrdinal("title"));
                    ItView.Description = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    
                    Lista.Add(ItView);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      //Delete Video
        public void EliminarVideoID(GM_VideosLoad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDVideo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_del_ModuloVideo", Parametros);
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
      //Edit Video
        public void ObternerTipoDetalleVideo(GM_VideosLoad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDVideo };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_VideosViewDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Url = Dr.GetString(Dr.GetOrdinal("Url"));
                    Datos.Alt = Dr.GetString(Dr.GetOrdinal("alt"));
                    Datos.Title = Dr.GetString(Dr.GetOrdinal("title"));
                    Datos.Description = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
     }
}
