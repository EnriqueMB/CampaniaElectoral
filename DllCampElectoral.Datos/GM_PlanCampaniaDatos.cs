using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using System.Data.SqlClient;

namespace DllCampElectoral.Datos
{
    public class GM_PlanCampaniaDatos
    {
        public void AGPlanCampania(GM_PlanCampania Data)
        {
            try
            {
                object[] Parametros = { Data.NuevoRegistro, Data.IDPElectoral,Data.TituloProyecto, Data.Proyecto1, Data.Proyecto2, Data.Proyecto3, Data.ProyectoP ,Data.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Data.Conexion, "GM_spCSLDB_AG_ProyectoCampania", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Data.Completado = true;
                    }
                    Data.Resultado = Resultado;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerPlanCampania(GM_PlanCampania Data)
        {
            try
            {
                List<GM_PlanCampania> ListaC = new List<GM_PlanCampania>();
                GM_PlanCampania It;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Data.Conexion, "GM_spCSLDB_getList_ProyectoCampania");
                while (Dr.Read())
                {
                    It = new GM_PlanCampania();
                    It.IDPElectoral = Dr.GetString(Dr.GetOrdinal("id_PElectoral"));
                    It.TituloProyecto =Dr.GetString(Dr.GetOrdinal("nombreProyecto"));
                    It.Proyecto1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    It.Proyecto2 = Dr.GetString(Dr.GetOrdinal("descripcion2"));
                    It.Proyecto3 = Dr.GetString(Dr.GetOrdinal("descripcion3"));
                    It.ProyectoP = Dr.GetString(Dr.GetOrdinal("pieDePagina"));                    
                    ListaC.Add(It);
                }
                return ListaC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public List<GM_PlanCampania> ObtenerListCampaniaMas(GM_PlanCampania Data)
        {
            try
            {
                List<GM_PlanCampania> ListaC = new List<GM_PlanCampania>();
                GM_PlanCampania It;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Data.Conexion, "RR_spCSLDB_get_ProyectoCampaniaMas");
                while (Dr.Read())
                {
                    It = new GM_PlanCampania();
                    It.IDPElectoral = Dr.GetString(Dr.GetOrdinal("id_PElectoral"));
                    It.TituloProyecto = Dr.GetString(Dr.GetOrdinal("nombreProyecto"));
                    It.Proyecto1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    It.URLImagen = Dr.GetString(Dr.GetOrdinal("urlFoto"));
                    ListaC.Add(It);
                }
                return ListaC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePlanCampania(GM_PlanCampania Data)
        {
            try
            {
                object[] Parametros = { Data.IDPElectoral };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Data.Conexion, "GM_spCSLDB_get_IDProyectoCampania", Parametros);
                while (Dr.Read())
                {
                    Data.TituloProyecto = Dr.GetString(Dr.GetOrdinal("nombreProyecto"));
                    Data.Proyecto1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    Data.Proyecto2 = Dr.GetString(Dr.GetOrdinal("descripcion2"));
                    Data.Proyecto3 = Dr.GetString(Dr.GetOrdinal("descripcion3"));
                    Data.ProyectoP = Dr.GetString(Dr.GetOrdinal("pieDePagina"));                   
                    Data.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPlanCampaniaID(GM_PlanCampania Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPElectoral, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "GM_spCSLDB_dtl_ProyectoCampania", Parametros);
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
        
        public List<GM_PlanCampania> ObtenerPlanCampania1(GM_PlanCampania Data)
        {
            try
            {
                
               
                List<GM_PlanCampania> ListaC = new List<GM_PlanCampania>();
                GM_PlanCampania It;
                object[] Parametros = { Data.IDPElectoral };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Data.Conexion, "GM_spCSLDB_get_IDProyectoCampania", Parametros);
                while (Dr.Read())
                {
                    It = new GM_PlanCampania();
                    It.TituloProyecto = Dr.GetString(Dr.GetOrdinal("nombreProyecto"));
                    It.Proyecto1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    It.Proyecto2 = Dr.GetString(Dr.GetOrdinal("descripcion2"));
                    It.Proyecto3 = Dr.GetString(Dr.GetOrdinal("descripcion3"));
                    It.ProyectoP = Dr.GetString(Dr.GetOrdinal("pieDePagina"));                    
                    ListaC.Add(It);
                }
                return ListaC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Load Image/ Web
        public void CargaImageID(CH_Foto Datos)
        {
            
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDFoto,Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "", Parametros); 
                int Resultado = 0;//GM_spCSLDB_AG_ImageWp
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                else
                {
                    Datos.Completado = false;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  

        #region Plan Campaña
        public void CargarFotoPlanCampania(GM_PlanCampania Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPElectoral, Datos.IDFoto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_ProyectoExtra", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                else
                {
                    Datos.Completado = false;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerCatalogoFotos(GM_PlanCampania Datos)
        {
            try
            {
                List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
                GM_PlanCampania Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_GaleriaFotosXIDProyectoCampania", Datos.IDPElectoral);
                while (Dr.Read())
                {
                    Item = new GM_PlanCampania();
                    Item.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.Extension = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Item.IDPElectoral = Dr.GetString(Dr.GetOrdinal("id_Proyecto"));
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
