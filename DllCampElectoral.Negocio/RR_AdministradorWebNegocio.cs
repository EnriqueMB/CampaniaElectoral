using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class RR_AdministradorWebNegocio
    {
    	#region Informacion candidato

        public void ACInformacionCandidato (RR_InformacionCandidato Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACInformacionCandidato(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerCatalogoInformacionCandidato(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerCandidatoXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.EliminarCandidatoXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerComboCandidatos(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerComboPartido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        #endregion

        #region Datos Redes Sociales

        public void ACRedesSociales(RR_DatosRedesSociales Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACRedesSociales(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerRedesSociales(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerRedesSocXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerIconosRedes(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.EliminarRedesSocXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_DatosRedesSociales> ObtenerComboRedes(RR_DatosRedesSociales Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerComboPartido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  Proyectos
         public List<RR_PropuestaCamapaña> ObtenerTitulosPropuesta(RR_PropuestaCamapaña Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerTitulosPropuesta(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACPublicacionesBlog(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerPublicacionesBlog(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerPublicacionesBlogXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.EliminarPublicacionesBlogXID(Datos);
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
                RR_AdministradorWebDatos AWD = new RR_AdministradorWebDatos();
                return AWD.ObtenerDescBlog(Datos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<RR_Blog> ObtenerBlogDetallado(RR_Blog Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerBlogDetallado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Cargar Fotos Para Pagina Web

        public void CargarFotoXID(CH_Foto Datos)
        {
            try
            {
                RR_AdministradorWebDatos FD = new RR_AdministradorWebDatos();
                FD.CargaFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargaVideoXID(GM_VideosLoad Datos)
        {
            try
            {
                RR_AdministradorWebDatos FD = new RR_AdministradorWebDatos();
                FD.CargaVideoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Datos pagina home

        public void ACDatosHome(RR_DatosHome Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACDatosHome(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region

        public void ACCatalogoMiembrosEquipoTrabajo(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACCatalogoMiembrosEquipoTrabajo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Propuesta Camapaña

        public void ACPropuestaCampania(RR_PropuestaCamapaña Datos)
        {
            try
            {
                RR_AdministradorWebDatos AWD = new RR_AdministradorWebDatos();
                AWD.ACPropuestaCampania(Datos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_PropuestaCamapaña> ObtenerPropuestas(RR_PropuestaCamapaña Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerPropuestas(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerPropuestaXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerPropuestaDetallada(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.EliminarPropuestaCampañaXID(Datos);
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
                RR_AdministradorWebDatos FD = new RR_AdministradorWebDatos();
                FD.CargarFotoPropuesta(Datos);
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
                RR_AdministradorWebDatos FD = new RR_AdministradorWebDatos();
                return FD.ObtenerCatalogoFotos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Datos Pagina Carrera Politica
        public void ACCarreraPolitica(RR_CarreraPolitica Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACCarreraPolitica(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerTextoCarreraXID(RR_CarreraPolitica Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerTextoCarreraXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerCarreraPolXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Datos Pagina Donate
        public void ACDonateTexto(RR_Donate Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ACDonateTexto(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                CD.ObtenerTextoDonateXID(Datos);
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
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerTextoDonate(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Proximos Eventos Campaña
        public List<GM_Calendar> ObtenerEventosCalendario(GM_Calendar Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerEventosCalendario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Evento
        public List<GM_Calendar> ObtenerEventosCalendario2(GM_Calendar Datos)
        {
            try
            {
                RR_AdministradorWebDatos CD = new RR_AdministradorWebDatos();
                return CD.ObtenerEventosCalendario2(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CH_Evento> ObtenerEventosDesc(CH_Evento Datos)
        {
            try
            {
                RR_AdministradorWebDatos AWD = new RR_AdministradorWebDatos();
                return AWD.ObtenerEventosDesc(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
