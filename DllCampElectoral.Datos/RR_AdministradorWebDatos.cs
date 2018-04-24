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
    public class RR_AdministradorWebDatos
    {

    	#region Informacion Candidato
        public void ACInformacionCandidato(RR_InformacionCandidato Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDCandidato, Datos.Nombre, Datos.ApePat, Datos.ApeMat, Datos.PartidoPolitico, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_InfoCandidatos", Parametros);
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
        public List<RR_InformacionCandidato> ObtenerCatalogoInformacionCandidato(RR_InformacionCandidato Datos)
        {
            try
            {
                List<RR_InformacionCandidato> Lista = new List<RR_InformacionCandidato>();
                RR_InformacionCandidato Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_InfoCandidatos");
                while (Dr.Read())
                {
                    Item = new RR_InformacionCandidato();
                    Item.IDCandidato = Dr.GetString(Dr.GetOrdinal(("id_Candidato")));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("nombreCand"));
                    Item.NombrePartido = Dr.GetString(Dr.GetOrdinal("nombre"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCandidatoXID(RR_InformacionCandidato Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCandidato };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_InfoCandidatosDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDCandidato = Dr.GetString(Dr.GetOrdinal("id_Candidato"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    Datos.ApePat = Dr.GetString(Dr.GetOrdinal("apePat"));
                    Datos.ApeMat = Dr.GetString(Dr.GetOrdinal("apeMat"));
                    Datos.PartidoPolitico = Dr.GetInt32(Dr.GetOrdinal("id_partido"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarCandidatoXID(RR_InformacionCandidato Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCandidato, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_InfCandidato", Parametros);
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
        public List<RR_InformacionCandidato> ObtenerComboCandidatos(RR_InformacionCandidato Datos)
        {
            try
            {
                List<RR_InformacionCandidato> Lista = new List<RR_InformacionCandidato>();
                RR_InformacionCandidato Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ComboCandidatos");
                while (Dr.Read())
                {
                    Item = new RR_InformacionCandidato();
                    Item.IDCandidato = Dr.GetString(Dr.GetOrdinal("id_Candidato"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("nombreCompleto"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CH_PartidoPolitico> ObtenerComboPartido(CH_PartidoPolitico Datos)
        {
            try
            {
                List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
                CH_PartidoPolitico Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ComboPartidosPoliticos");
                while (Dr.Read())
                {
                    Item = new CH_PartidoPolitico();
                    Item.IDPartido = Dr.GetInt32(Dr.GetOrdinal("id_partido"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
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


        /*#region Proyectos
        public List<RR_StatusProyecto> ObtenerTitulosProyecto(RR_StatusProyecto Datos)
        {
            try
            {
                List<RR_StatusProyecto> Lista = new List<RR_StatusProyecto>();
                RR_StatusProyecto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TitulosProyectos");
                while (Dr.Read())
                {
                    Item = new RR_StatusProyecto();
                    Item.IDProyecto = Dr.GetInt32(Dr.GetOrdinal(("id_statusProyecto")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion*/

        #region Datos Redes Sociales
        public void ACRedesSociales(RR_DatosRedesSociales Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDRedSocial, Datos.IDTipoRedSocial, Datos.Cuenta, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_RedesSociales", Parametros);
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
        public List<RR_DatosRedesSociales> ObtenerRedesSociales(RR_DatosRedesSociales Datos)
        {
            try
            {
                List<RR_DatosRedesSociales> Lista = new List<RR_DatosRedesSociales>();
                RR_DatosRedesSociales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_RedesSociales");
                while (Dr.Read())
                {
                    Item = new RR_DatosRedesSociales();
                    Item.IDRedSocial = Dr.GetString(Dr.GetOrdinal(("id_redSocial")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.Cuenta = Dr.GetString(Dr.GetOrdinal("cuenta"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_DatosRedesSociales> ObtenerIconosRedes(RR_DatosRedesSociales Datos)
        {
            try
            {
                List<RR_DatosRedesSociales> Lista = new List<RR_DatosRedesSociales>();
                RR_DatosRedesSociales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_RedesSocialesPagina");
                while (Dr.Read())
                {
                    Item = new RR_DatosRedesSociales();
                    Item.Class = Dr.GetString(Dr.GetOrdinal(("class")));
                    Item.Cuenta = Dr.GetString(Dr.GetOrdinal("cuenta"));
                    Item.FaClass = Dr.GetString(Dr.GetOrdinal("faClass"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerRedesSocXID(RR_DatosRedesSociales Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRedSocial };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_RedesSocialesDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDRedSocial = Dr.GetString(Dr.GetOrdinal("id_redSocial"));
                    Datos.IDTipoRedSocial = Dr.GetInt32(Dr.GetOrdinal("id_tipoRedSocial"));
                    Datos.Cuenta = Dr.GetString(Dr.GetOrdinal("cuenta"));                    
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarRedesSocXID(RR_DatosRedesSociales Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRedSocial, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_RedesSoc", Parametros);
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
        public List<RR_DatosRedesSociales> ObtenerComboPartido(RR_DatosRedesSociales Datos)
        {
            try
            {
                List<RR_DatosRedesSociales> Lista = new List<RR_DatosRedesSociales>();
                RR_DatosRedesSociales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ComboRedesSociales");
                while (Dr.Read())
                {
                    Item = new RR_DatosRedesSociales();
                    Item.IDTipoRedSocial = Dr.GetInt32(Dr.GetOrdinal("id_tipoRedSocial"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
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

        #region Publicaciones Blog
        public void ACPublicacionesBlog(RR_Blog Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDPublicacion, Datos.Titulo, Datos.Fecha, Datos.TextoReducido, Datos.TextoHtml, Datos.UrlImagen, Datos.Alt, Datos.Title, Datos.Descripcion, Datos.TipoArchivo, Datos.CambioImagen, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_AC_PublicacionesBlog", Parametros);
                while(Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
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
        public List<RR_Blog> ObtenerPublicacionesBlog(RR_Blog Datos)
        {
            try
            {
                List<RR_Blog> Lista = new List<RR_Blog>();
                RR_Blog Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_Publicaciones");
                while (Dr.Read())
                {
                    Item = new RR_Blog();
                    Item.IDPublicacion = Dr.GetString(Dr.GetOrdinal(("id_publicacion")));
                    Item.Fecha = Dr.GetDateTime(Dr.GetOrdinal("fecha"));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("titulo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerPublicacionesBlogXID(RR_Blog Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPublicacion };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PublicacionesBlogDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDPublicacion = Dr.GetString(Dr.GetOrdinal("id_publicacion"));
                    Datos.Titulo = Dr.GetString(Dr.GetOrdinal("titulo"));
                    Datos.TextoReducido = Dr.GetString(Dr.GetOrdinal("textoReducido"));
                    Datos.TextoHtml = Dr.GetString(Dr.GetOrdinal("textoHTML"));
                    Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("urlImagen"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarPublicacionesBlogXID(RR_Blog Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPublicacion, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_PublicacionesBlog", Parametros);
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

        public List<RR_Blog> ObtenerDescBlog(RR_Blog Datos)
        {
            try
            {
                List<RR_Blog> ListaBlog = new List<RR_Blog>();
                RR_Blog Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PublicacionesBlogPagina");
                while (Dr.Read())
                {
                    Item = new RR_Blog();
                    Item.IDPublicacion = Dr.GetString(Dr.GetOrdinal(("id_publicacion")));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("titulo"));
                    Item.TextoReducido = Dr.GetString(Dr.GetOrdinal("textoReducido"));
                    Item.TextoHtml = Dr.GetString(Dr.GetOrdinal("textoHTML"));
                    Item.UrlImagen = Dr.GetString(Dr.GetOrdinal("urlImagen"));
                    ListaBlog.Add(Item);
                }
                return ListaBlog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_Blog> ObtenerBlogDetallado(RR_Blog Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPublicacion };
                List<RR_Blog> Lista = new List<RR_Blog>();
                RR_Blog Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PublicacionesBlogDetallePagina", Parametros);
                while (Dr.Read())
                {
                    Item = new RR_Blog();                    
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("titulo"));                    
                    Item.TextoHtml = Dr.GetString(Dr.GetOrdinal("textoHTML"));
                    Item.UrlImagen = Dr.GetString(Dr.GetOrdinal("urlImagen"));
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

        #region cargar fotos para pagina web
        public void CargaFotoXID(CH_Foto Datos)
        {
            string id="";
            bool espagina = true;
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, id, Datos.IDFoto, espagina,  Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_FotosPagina", Parametros);
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
        #endregion

        #region cargar videos para pagina web
        public void CargaVideoXID(GM_VideosLoad Datos)
        {
            string id = "";
            bool espagina = true;
            try
            {
                object[] Parametros = { Datos.NuevoVideo, id, Datos.IDVideo, espagina, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_VideosPagina", Parametros);
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
        #endregion

        #region cargar datos pagina home
        public void ACDatosHome(RR_DatosHome Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDHomeText, Datos.DescHacemos, Datos.Afiliate, Datos.DescProxEvent, Datos.DescEquipoTrabajo, Datos.Contactanos, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_DatosPagHome", Parametros);
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

        #region Equipo Trabajo

        public void ACCatalogoMiembrosEquipoTrabajo(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                object[] Parametros = {Datos.NuevoRegistro, Datos.IDMiembroEquipo, Datos.Nombre, Datos.ApePat, Datos.ApeMat,
                Datos.Puesto, Datos.PagWeb, Datos.IsFb, Datos.IsGoo, Datos.IsTw, Datos.IsInst, Datos.IsPrin, Datos.Fb, Datos.Goo,
                Datos.Tw, Datos.Ins, Datos.Print, Datos.ExtrancionImagen, Datos.CambiarImagen, Datos.IDUsuario};
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_AC_MiembrosEquTrab", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                        Datos.IDMiembroEquipo = Dr.GetString(Dr.GetOrdinal("IDMiembroEqu"));
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

        #endregion

        #region Propuesta Campaña

        public void ACPropuestaCampania(RR_PropuestaCamapaña Datos)
        {
            object[] Parametros = { Datos.NuevoRegistro, Datos.IDPropuesta, Datos.NombrePropuesta, Datos.Descripcion1, Datos.Descripcion2, Datos.Descripcion3,
                    Datos.PieDePagina, Datos.IDUsuario };
            Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_PropuestaCamapaña", Parametros);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
                
        }

        public List<RR_PropuestaCamapaña> ObtenerPropuestas(RR_PropuestaCamapaña Datos)
        {
            try
            {
                List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
                RR_PropuestaCamapaña Item;
                DateTime nw = DateTime.Now;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PropuestasCamapaña");
                while (Dr.Read())
                {
                    Item = new RR_PropuestaCamapaña();
                    Item.IDPropuesta = Dr.GetString(Dr.GetOrdinal(("id_PropuestaCamapaña")));
                    Item.NombrePropuesta = Dr.GetString(Dr.GetOrdinal("nombrePropuesta"));
                    Item.Descripcion1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    Item.Fecha = Dr.GetDateTime(Dr.GetOrdinal("fecupd"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("urlFoto"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPropuestaXID(RR_PropuestaCamapaña Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPropuesta };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PropuestasCamapañaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDPropuesta = Dr.GetString(Dr.GetOrdinal("id_PropuestaCamapaña"));
                    Datos.NombrePropuesta = Dr.GetString(Dr.GetOrdinal("nombrePropuesta"));
                    Datos.Descripcion1 = Dr.GetString(Dr.GetOrdinal("Descripcion1"));
                    Datos.Descripcion2 = Dr.GetString(Dr.GetOrdinal("Descripcion2"));
                    Datos.Descripcion3 = Dr.GetString(Dr.GetOrdinal("Descripcion3"));
                    Datos.PieDePagina = Dr.GetString(Dr.GetOrdinal("PieDePagina"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_PropuestaCamapaña> ObtenerPropuestaDetallada(RR_PropuestaCamapaña Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPropuesta };
                List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
                RR_PropuestaCamapaña Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_PropuestasCamapañaDetalle", Parametros);
                while (Dr.Read())
                {
                    Item = new RR_PropuestaCamapaña();
                    Item.IDPropuesta = Dr.GetString(Dr.GetOrdinal(("id_PropuestaCamapaña")));
                    Item.NombrePropuesta = Dr.GetString(Dr.GetOrdinal("nombrePropuesta"));
                    Item.Descripcion1 = Dr.GetString(Dr.GetOrdinal("descripcion1"));
                    Item.Descripcion2 = Dr.GetString(Dr.GetOrdinal("descripcion2"));
                    Item.Descripcion3 = Dr.GetString(Dr.GetOrdinal("descripcion3"));
                    Item.PieDePagina = Dr.GetString(Dr.GetOrdinal("pieDePagina"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_PropuestaCamapaña> ObtenerTitulosPropuesta(RR_PropuestaCamapaña Datos)
        {
            try
            {
                List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
                RR_PropuestaCamapaña Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TitulosPropuestas");
                while (Dr.Read())
                {
                    Item = new RR_PropuestaCamapaña();
                    Item.IDPropuesta = Dr.GetString(Dr.GetOrdinal(("id_PropuestaCamapaña")));
                    Item.NombrePropuesta = Dr.GetString(Dr.GetOrdinal("nombrePropuesta"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPropuestaCampañaXID(RR_PropuestaCamapaña Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPropuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_PropuestaCampaña", Parametros);
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

        public void CargarFotoPropuesta(RR_PropuestaCamapaña Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPropuesta, Datos.IDFoto,Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_PropuestaExtra", Parametros);
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

        public List<RR_PropuestaCamapaña> ObtenerCatalogoFotos(RR_PropuestaCamapaña Datos)
        {
            try
            {
                List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
                RR_PropuestaCamapaña Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_GaleriaFotosXIDPropuesta", Datos.IDPropuesta);
                while (Dr.Read())
                {
                    Item = new RR_PropuestaCamapaña();
                    Item.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.Extension = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Item.IDPropuesta = Dr.GetString(Dr.GetOrdinal("id_Propuesta"));
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

        #region Cargar datos pagina Carrera Politica
        public void ACCarreraPolitica(RR_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDCarreraPolitica, Datos.TituloCarreraPolitica, Datos.DescripcionCarreraPol, Datos.IDUsuario };
                Object result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_DatosCarreraPolText", Parametros);
                int Resultado = 0;
                int.TryParse(result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public void ObtenerTextoCarreraXID(RR_CarreraPolitica Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCarreraPolitica };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TextoCarreraPoliticaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDCarreraPolitica = Dr.GetInt32(Dr.GetOrdinal("id_carreraPText"));
                    Datos.TituloCarreraPolitica = Dr.GetString(Dr.GetOrdinal("tituloCarreraPol"));
                    Datos.DescripcionCarreraPol = Dr.GetString(Dr.GetOrdinal("descCarreraPol"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_CarreraPolitica> ObtenerCarreraPolXID(RR_CarreraPolitica Datos)
        {
            try
            {
                List<RR_CarreraPolitica> Lista = new List<RR_CarreraPolitica>();
                RR_CarreraPolitica Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TextoCarreraPol");
                while (Dr.Read())
                {
                    Item = new RR_CarreraPolitica();
                    Item.IDCarreraPolitica = Dr.GetInt32(Dr.GetOrdinal("id_carreraPText"));
                    Item.TituloCarreraPolitica = Dr.GetString(Dr.GetOrdinal("tituloCarreraPol"));
                    Item.DescripcionCarreraPol = Dr.GetString(Dr.GetOrdinal("descCarreraPol"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /*public void EliminarCarreraPoliticaText(RR_CarreraPolitica Datos)    
        {
            try
            {
                object[] Parametros = { Datos.IDCarreraPolitica, Datos.IDUsuario };
                Object result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_CarreraPolText", Parametros);
                int Resultado = 0;
                int.TryParse(result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }*/

        #endregion

        #region Cargar datos pagina Donate
        public void ACDonateTexto(RR_Donate Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDDonate, Datos.Donate, Datos.IDUsuario };
                Object result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_DatosDonateText", Parametros);
                int Resultado = 0;
                int.TryParse(result.ToString(), out Resultado);
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

        public void ObtenerTextoDonateXID(RR_Donate Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDDonate };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TextoDonateDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDDonate = Dr.GetInt32(Dr.GetOrdinal("id_donateText"));
                    Datos.Donate = Dr.GetString(Dr.GetOrdinal("descDonate"));                    
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_Donate> ObtenerTextoDonate(RR_Donate Datos)
        {
            try
            {
                List<RR_Donate> Lista = new List<RR_Donate>();
                RR_Donate Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TextoDonate");
                while (Dr.Read())
                {
                    Item = new RR_Donate();
                    Item.IDDonate = Dr.GetInt32(Dr.GetOrdinal("id_donateText"));
                    Item.Donate = Dr.GetString(Dr.GetOrdinal("descDonate"));                    
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public void EliminarDonateTexto(RR_Donate Datos)
        {
            {
                try
                {
                    object[] Parametros = { Datos.IDDonate, Datos.IDUsuario };
                    Object result = SqlHelper.ExecuteScalar(Datos.Conexion, "", Parametros);
                    int Resultado = 0;
                    int.TryParse(result.ToString(), out Resultado);
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
        }*/

        #endregion

        #region Proximos Eventos
        public List<GM_Calendar> ObtenerEventosCalendario(GM_Calendar Datos)
        {
            try
            {
                List<GM_Calendar> Lista = new List<GM_Calendar>();
                GM_Calendar Item;                
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_EventosPagHome");
                while (Dr.Read())
                {
                    Item = new GM_Calendar();
                    Item.IDEvento = Dr.GetString(Dr.GetOrdinal("IDEvento"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("NombreEvento"));
                    Item.Observaciones = Dr.GetString(Dr.GetOrdinal("observaciones"));
                    Item.FechaEvento = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                    Item.HoraInicio = Dr.GetString(Dr.GetOrdinal("HoraInicio"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_Calendar> ObtenerEventosCalendario2(GM_Calendar Datos)
        {
            try
            {
                List<GM_Calendar> Lista = new List<GM_Calendar>();
                GM_Calendar Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "JL_spCSLDB_get_OtrosEventosPagDesc");
                while (Dr.Read())
                {
                    Item = new GM_Calendar();
                    Item.IDEvento = Dr.GetString(Dr.GetOrdinal("IDEvento"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("NombreEvento"));
                    Item.Imagen = Dr.GetString(Dr.GetOrdinal("imagen"));
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

        public List<CH_Evento> ObtenerEventosDesc(CH_Evento Datos)
        {
            try
            {
                List<CH_Evento> Lista = new List<CH_Evento>();
                CH_Evento Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "JL_spCSLDB_get_EventosPagDesc", Datos.IDEvento);
                while (Dr.Read())
                {
                    Item = new CH_Evento();
                    Item.TituloPagina = Dr.GetString(Dr.GetOrdinal("NombreEvento"));
                    Item.TextoPagina = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Item.FechaEvento = Dr.GetDateTime(Dr.GetOrdinal("FechaEvento"));
                    Item.HoraEvento = Dr.GetString(Dr.GetOrdinal("HoraEvento"));
                    Item.IDEvento = Dr.GetString(Dr.GetOrdinal("IDEvento"));
                    Item.UrlImagen = Dr.GetString(Dr.GetOrdinal("imagen"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}