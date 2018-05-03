using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DllCampElectoral.Datos
{
    public class EM_CatalogosDatos
    {
        #region Catalago Rango de Edades
        public void ACRangoEdades(EM_RangoEdad Datos)
        {
            try 
	        {	        
		        object[] Parametros = { Datos.NuevoRegistro, Datos.IDEdad, Datos.Descripcion, Datos.EdadInicio, Datos.EdadFin, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_RangoEdades", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if(Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
	        }
	        catch (Exception Ex)
	        {
		        throw Ex;
	        }
        }

        public List<EM_RangoEdad> ObtenerCatalogoRandoEdades(EM_RangoEdad Datos)
        {
            try
            {
                List<EM_RangoEdad> Lista = new List<EM_RangoEdad>();
                EM_RangoEdad Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_RangoEdades");
                while (Dr.Read())
                {
                    Item = new EM_RangoEdad();
                    Item.IDEdad = Dr.GetInt32(Dr.GetOrdinal("IDEdad"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.EdadInicio = Dr.GetInt32(Dr.GetOrdinal("EdadInicio"));
                    Item.EdadFin = Dr.GetInt32(Dr.GetOrdinal("EdadFin"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerRangoEdadDetalleXID(EM_RangoEdad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEdad };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_RangoEdadesDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.EdadInicio = Dr.GetInt32(Dr.GetOrdinal("EdadInicio"));
                    Datos.EdadFin = Dr.GetInt32(Dr.GetOrdinal("EdadFin"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRangoEdadXID(EM_RangoEdad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEdad, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_RangoEdades", Parametros);
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

        #region Catalago Activida Comercial

        public void ACActividaComercial(EM_ActividadComercial Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDActividadComercial, Datos.Descripcion, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_ActividadComercial", Parametros);
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

        public List<EM_ActividadComercial> ObtenerCatalagoActividaComercial(EM_ActividadComercial Datos)
        {
            try
            {
                List<EM_ActividadComercial> Lista = new List<EM_ActividadComercial>();
                EM_ActividadComercial Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ActividadComercial");
                while(Dr.Read())
                {
                    Item = new EM_ActividadComercial();
                    Item.IDActividadComercial = Dr.GetInt32(Dr.GetOrdinal("IDActividad"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("DescripcionActividad"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerActivadadDetalleXID(EM_ActividadComercial Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDActividadComercial };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ActividadComercialDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarActividadComercialeXID(EM_ActividadComercial Datos)
        {
            object[] Parametro = { Datos.IDActividadComercial, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_ActividadComercial", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }
        
        #endregion

        #region Catalago Tipo Evento Campania

        public void ACTipoEventoCampania(EM_TipoEventoCampania Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTipoEventoCampania, Datos.Descripcion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_TipoEventoCampania", Parametros);
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

        public List<EM_TipoEventoCampania> ObtenerCatalagoTipoEventoCampania(EM_TipoEventoCampania Datos)
        {
            try
            {
                List<EM_TipoEventoCampania> Lista = new List<EM_TipoEventoCampania>();
                EM_TipoEventoCampania Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_TipoEventoCampania");
                while (Dr.Read())
                {
                    Item = new EM_TipoEventoCampania();
                    Item.IDTipoEventoCampania = Dr.GetInt32(Dr.GetOrdinal("IDTipoEventoCampania"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("DescripcionTipo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerTipoEventoCampaniaDetalleXID(EM_TipoEventoCampania Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoEventoCampania };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_TipoEventoCampaniaDetallaXID", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("DescripcionTipo"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoEventoCampaniaXID(EM_TipoEventoCampania Datos)
        {
            object[] Parametro = { Datos.IDTipoEventoCampania, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_TipoEventoCampania", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }

        #endregion

        #region Catalago Status Afiliado

        public void ACStatusAfiliado(EM_StatusAfiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDStatusAfiliado, Datos.Descripcion, Datos.ColorStatus, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_StatusAfiliado", Parametros);
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

        public List<EM_StatusAfiliados> ObtenerCatalagoStatusAfiliado(EM_StatusAfiliados Datos)
        {
            try
            {
                List<EM_StatusAfiliados> Lista = new List<EM_StatusAfiliados>();
                EM_StatusAfiliados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_StatusAfiliado");
                while (Dr.Read())
                {
                    Item = new EM_StatusAfiliados();
                    Item.IDStatusAfiliado = Dr.GetInt32(Dr.GetOrdinal("IDStatusAfiliado"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.ColorStatus = Dr.GetString(Dr.GetOrdinal("ColorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerStatusAfiliadoDetalleXID(EM_StatusAfiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDStatusAfiliado };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_StatusAfiliadoDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.ColorStatus = Dr.GetString(Dr.GetOrdinal("ColorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusAfiliadoXID(EM_StatusAfiliados Datos)
        {
            object[] Parametro = { Datos.IDStatusAfiliado, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_StatusAfiliado", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }

        #endregion

        #region Catalago Tipo Imagen Video

        public void ACTipoImagenVideo(EM_TipoImagenVideo Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTipoImagenVideo, Datos.Descripcion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_TipoImagenVideo", Parametros);
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

        public List<EM_TipoImagenVideo> ObtenerCatalagoTipoImagenVideo(EM_TipoImagenVideo Datos)
        {
            try
            {
                List<EM_TipoImagenVideo> Lista = new List<EM_TipoImagenVideo>();
                EM_TipoImagenVideo Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_TipoImagenVideo");
                while (Dr.Read())
                {
                    Item = new EM_TipoImagenVideo();
                    Item.IDTipoImagenVideo = Dr.GetInt32(Dr.GetOrdinal("IDImagenVideo"));
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

        public void ObternerTipoImagenVideoDetalleXID(EM_TipoImagenVideo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoImagenVideo };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_TipoImagenVideoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoImagenVideoXID(EM_TipoImagenVideo Datos)
        {
            object[] Parametro = { Datos.IDTipoImagenVideo, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_TipoImagenVideo", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }

        #endregion

        #region Catálogo Colaboradores

        public void ACCatalogoColaboradores(EM_CatColaborador Datos)
        {
            
                object[] Parametros = { Datos.IDColaborador,    Datos.IDTipoUsu,    Datos.Nombre,       Datos.ApPaterno,    Datos.ApMaterno,
                                        Datos.Estado,           Datos.Municipio,    Datos.IDPoligono,   Datos.Direccion,    Datos.NumeroExt,
                                        Datos.NumeroInt,        Datos.Colonia,      Datos.CodigoPostal, Datos.ClaveElector, Datos.Correo,
                                        Datos.Telefono,         Datos.Password,     Datos.IDGenero,     Datos.FechaNac,     Datos.Imagen,
                                        Datos.IDUsuario,        Datos.Padre,        Datos.Sumplente,    Datos.Casilla,      Datos.BandPassServer,
                                        Datos.imgGuardada,      Datos.Seccion.ToString()
                                    };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_AC_Colaboradores", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    string Mesaje = Dr.GetString(Dr.GetOrdinal("Mensaje"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
                    }
                    Datos.Resultado = Resultado;
                    Datos.MensajeSQL = Mesaje;
                    break;
                }
           
        }
        //public void ACCatalogoColaboradores(EM_CatColaborador Datos)
        //{
        //    try
        //    {
        //        object[] Parametros = { Datos.NuevoRegistro, Datos.IDColaborador, Datos.IDColaboradorAux, Datos.Nombre, Datos.ApPaterno, Datos.ApMaterno, Datos.Correo,
        //                                Datos.Telefono, Datos.Password, Datos.FechaNac, Datos.IDGenero, Datos.CodigoPostal, Datos.IDTipoUsu,
        //                                Datos.Cuidad, Datos.ExtrancionImagen, Datos.CambiarImagen, Datos.IDUsuario };
        //        SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_Colaboradores", Parametros);
        //        while (Dr.Read())
        //        {
        //            int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
        //            if (Resultado == 1)
        //            {
        //                Datos.Completado = true;
        //                Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
        //                Datos.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
        //            }
        //            Datos.Resultado = Resultado;
        //            break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void ACCatalogoColaboradoresAuxiliar(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDColaborador, Datos.IDColaboradorAux, Datos.Nombre, Datos.ApPaterno, Datos.ApMaterno, Datos.Correo,
                                        Datos.Telefono, Datos.Password, Datos.FechaNac, Datos.IDGenero, Datos.CodigoPostal, Datos.IDTipoUsu,
                                        Datos.Cuidad, Datos.ExtrancionImagen, Datos.CambiarImagen, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_AC_ColaboradoresAuxiliar", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                        Datos.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
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

        public List<EM_CatColaborador> ObtenerCatalogoColaboradores(EM_CatColaborador Datos)
        {
            
                List<EM_CatColaborador> Lista = new List<EM_CatColaborador>();
                EM_CatColaborador Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_Colaboradores", Datos.IDTipoUsu);
                while (Dr.Read())
                {
                    Item = new EM_CatColaborador();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador")).Trim();
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.ApPaterno = Dr.GetString(Dr.GetOrdinal("ApPaterno"));
                    Item.ApMaterno = Dr.GetString(Dr.GetOrdinal("ApMaterno"));
                    Item.TipoUsuario = Dr.GetString(Dr.GetOrdinal("TipoUsuario"));
                    Item.ColorPerfil = Dr.GetString(Dr.GetOrdinal("ColorTipoUsuario"));
                    Item.IDTipoUsu   = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                Lista.Add(Item);
                }
                return Lista;
           
        }

        public void ObtenerDetalleColaboradoresXID(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ColaboradorDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.ClaveElector  = Dr.GetString(Dr.GetOrdinal("ClaveElector"));
                    Datos.Nombre        = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.ApPaterno     = Dr.GetString(Dr.GetOrdinal("ApPaterno"));
                    Datos.ApMaterno     = Dr.GetString(Dr.GetOrdinal("ApMaterno"));
                    Datos.Estado        = Dr.GetInt32(Dr.GetOrdinal("Estado"));
                    Datos.Municipio     = Dr.GetInt32(Dr.GetOrdinal("Municipio"));
                    Datos.IDPoligono    = Dr.GetString(Dr.GetOrdinal("Id_poligono"));
                    Datos.Seccion       = Int32.Parse(Dr.GetString(Dr.GetOrdinal("Seccion")));
                    Datos.Correo        = Dr.GetString(Dr.GetOrdinal("Correo"));
                    Datos.Telefono      = Dr.GetString(Dr.GetOrdinal("Telefono"));
                    Datos.FechaNac      = Dr.GetDateTime(Dr.GetOrdinal("FechaNac"));
                    Datos.Direccion     = Dr.GetString(Dr.GetOrdinal("Direccion"));
                    Datos.Colonia       = Dr.GetString(Dr.GetOrdinal("Colonia"));
                    Datos.NumeroExt     = Dr.GetString(Dr.GetOrdinal("numExt"));
                    Datos.NumeroInt     = Dr.GetString(Dr.GetOrdinal("numInt"));
                    Datos.IDGenero      = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
                    Datos.CodigoPostal  = Dr.GetString(Dr.GetOrdinal("CP"));
                    Datos.IDTipoUsu     = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                    Datos.Imagen        = Dr.GetString(Dr.GetOrdinal("Imagen"));
                    Datos.Padre         = Dr.GetString(Dr.GetOrdinal("IDPadre"));
                    Datos.Sumplente     = Dr.GetString(Dr.GetOrdinal("IDSuplente"));
                    Datos.Casilla       = Dr.GetInt32(Dr.GetOrdinal("Casilla"));
                    Datos.NomCasilla    = Dr.GetString(Dr.GetOrdinal("NomCasilla"));
                    Datos.NomMunicipio  = Dr.GetString(Dr.GetOrdinal("NomMunicipio"));

                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void ObtenerDetalleColaboradoresXID(EM_CatColaborador Datos)
        //{
        //    try
        //    {
        //        object[] Parametros = { Datos.IDColaborador };
        //        SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ColaboradorDetalle", Parametros);
        //        while (Dr.Read())
        //        {
        //            Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
        //            Datos.ApPaterno = Dr.GetString(Dr.GetOrdinal("ApPaterno"));
        //            Datos.ApMaterno = Dr.GetString(Dr.GetOrdinal("ApMaterno"));
        //            Datos.Correo = Dr.GetString(Dr.GetOrdinal("Correo"));
        //            Datos.Telefono = Dr.GetString(Dr.GetOrdinal("Telefono"));
        //            Datos.FechaNac = Dr.GetDateTime(Dr.GetOrdinal("FechaNac"));
        //            Datos.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
        //            Datos.CodigoPostal = Dr.GetString(Dr.GetOrdinal("CP"));
        //            Datos.IDTipoUsu = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
        //            Datos.Cuidad = Dr.GetString(Dr.GetOrdinal("Cuidad"));
        //            Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
        //            Datos.Completado = true;
        //            break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
       public void ObtenerDetalleAuxliarColaboradoresXID(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ColaboradorAuxiliarDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.ApPaterno = Dr.GetString(Dr.GetOrdinal("ApPaterno"));
                    Datos.ApMaterno = Dr.GetString(Dr.GetOrdinal("ApMaterno"));
                    Datos.Correo = Dr.GetString(Dr.GetOrdinal("Correo"));
                    Datos.Telefono = Dr.GetString(Dr.GetOrdinal("Telefono"));
                    Datos.FechaNac = Dr.GetDateTime(Dr.GetOrdinal("FechaNac"));
                    Datos.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
                    Datos.CodigoPostal = Dr.GetString(Dr.GetOrdinal("CP"));
                    Datos.IDTipoUsu = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                    Datos.Cuidad = Dr.GetString(Dr.GetOrdinal("Cuidad"));
                    Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                    Datos.IDColaboradorAux = Dr.GetString(Dr.GetOrdinal("IDColaboradorAux"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarColaboradorXID(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_Colaboradores", Parametros);
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

        public void ImagenSubidaColaboradorXID(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_set_ImagenSubidaColaborador", Parametros);
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

        #region Combo Género
        public List<CH_Genero> ObtenerComboGenero(CH_Genero Datos)
        {
            try
            {
                List<CH_Genero> Lista = new List<CH_Genero>();
                CH_Genero Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboGeneros");
                while (Dr.Read())
                {
                    Item = new CH_Genero();
                    Item.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
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

        #region Combo Tipo Usuario
        public List<RR_TipoUsuarios> ObtenerComboTipoUsuario(RR_TipoUsuarios Datos)
        {
            try
            {
                List<RR_TipoUsuarios> Lista = new List<RR_TipoUsuarios>();
                RR_TipoUsuarios Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboTipoUsuario");
                while (Dr.Read())
                {
                    Item = new RR_TipoUsuarios();
                    Item.IDTUsuario = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
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

        #region Combo Estaus General Eveto

        public List<EM_StatusGeneralEvento> ObtenerComboStatusGeneralEvento(EM_StatusGeneralEvento Datos)
        {
            try
            {
                List<EM_StatusGeneralEvento> Lista = new List<EM_StatusGeneralEvento>();
                EM_StatusGeneralEvento Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboEstatuGeneralEvento");
                while (Dr.Read())
                {
                    Item = new EM_StatusGeneralEvento();
                    Item.IDStatusGeneralEvento = Dr.GetInt32(Dr.GetOrdinal("IDStatusGeneral"));
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

        #region Combo Colaboradores

        public List<EM_CatColaborador> ObtenerComboColaboradores(EM_CatColaborador Datos)
        {
            try
            {
                List<EM_CatColaborador> Lista = new List<EM_CatColaborador>();
                EM_CatColaborador Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboColaboradores");
                while (Dr.Read())
                {
                    Item = new EM_CatColaborador();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
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

        #endregion

        #region Obtener Tipo Usuario Logeado

       public void ObtenerTipoUser(EM_CatColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_TipoUser", Parametros);
                while (Dr.Read())
                {
                    Datos.IDTipoUsu = Dr.GetInt32(Dr.GetOrdinal("IDTipoUser"));
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
