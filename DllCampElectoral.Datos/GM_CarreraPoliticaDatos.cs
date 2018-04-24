using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public  class GM_CarreraPoliticaDatos
    {

        public void AGCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDCarreraPolitica, Datos.Title, Datos.Descripcion,Datos.FechaRealizado, Datos.ExtrancionImagen, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_AG_CarrerPolitica", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDCarreraPolitica = Dr.GetString(Dr.GetOrdinal("IDCarreraPolitica"));
                        Datos.URLImagen = Dr.GetString(Dr.GetOrdinal("URLImagen"));

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
       



        #region List Carrera Politica

        public List<GM_CarreraPolitica> ObtenerCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_ListCarreraPolitica");
                List<GM_CarreraPolitica> Lista = new List<GM_CarreraPolitica>();
                GM_CarreraPolitica Item;
                while (Dr.Read())
                {
                    Item = new GM_CarreraPolitica();
                    Item.IDCarreraPolitica = Dr.GetString(Dr.GetOrdinal("IDCarreraPolitica"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.FechaRealizado = Dr.GetDateTime(Dr.GetOrdinal("FechaRealizado"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallCarreraPoliticaID(GM_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCarreraPolitica };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_IDCarreraPolitica", Parametros);
                while (Dr.Read())
                {
                    Datos.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.FechaRealizado = Dr.GetDateTime(Dr.GetOrdinal("FechaRealizado"));
                    Datos.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarIDCarreraPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCarreraPolitica, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_dlt_CarreraPolitica", Parametros);
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

        public void ImagenSubidaFotoXID(GM_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCarreraPolitica, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_ImagenLoadCarreraPolitica", Parametros);
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

        public List<GM_CarreraPolitica> ObtenerCarreraPolitica1(GM_CarreraPolitica Datos)
        {
            try
            {
                List<GM_CarreraPolitica> Lista = new List<GM_CarreraPolitica>();
                object[] Parametros = { Datos.IDCarreraPolitica };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_IDCarreraPolitica", Parametros);
                GM_CarreraPolitica Item;
                while (Dr.Read())
                {
                    Item = new GM_CarreraPolitica();
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.FechaRealizado = Dr.GetDateTime(Dr.GetOrdinal("fechaRealizado"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerProyectoCampania(GM_PlanCampania Datos)
        {
            try
            {
                List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
                object[] Parametros = { Datos.IDPElectoral };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "GM_spCSLDB_get_ProyectoCampaniaXID", Parametros);
                GM_PlanCampania Item;
                while (Dr.Read())
                {
                    Item = new GM_PlanCampania();
                    Item.TituloProyecto = Dr.GetString(Dr.GetOrdinal("nomrbeProyecto"));
                    Item.Proyecto1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    Item.Proyecto2 = Dr.GetString(Dr.GetOrdinal("descripcion2"));
                    Item.Proyecto3 = Dr.GetString(Dr.GetOrdinal("descripcion3"));
                    Item.ProyectoP = Dr.GetString(Dr.GetOrdinal("pieDePagina"));                    
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GM_CarreraPolitica ObtenerTextoCarreaPolitica(GM_CarreraPolitica Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CarreraPoliticaWeb");
                while (Dr.Read())
                {
                    Datos.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
