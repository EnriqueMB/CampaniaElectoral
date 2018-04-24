using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class RR_CatalogosNegocio
    {
        #region CatGradoEstudios

        public void ACCatalogoGradoEstudios(RR_GradoEstudios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoGradoEstudios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_GradoEstudios> ObtenerCatalogoGradoEstudios(RR_GradoEstudios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoGradoEstudio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleXID(RR_GradoEstudios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGeneroXID(RR_GradoEstudios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarGradoEstudioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Indicador Encuestas

        public void ACCatalogoIndicadorEncuestas(RR_IndicadorEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoIndicadorEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_IndicadorEncuestas> ObtenerCatalogoIndicadorEncuestas(RR_IndicadorEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoIndicadorEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleEncuestasXID(RR_IndicadorEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleEncuestasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuestasXID(RR_IndicadorEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarEncuestasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region TipoEventoAgenda

        public void ACCatalogoTipoEventoAgenda(RR_TipoEventoAgenda Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoTipoEventoAgenda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_TipoEventoAgenda> ObtenerCatalogoTipoEventoAgenda(RR_TipoEventoAgenda Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoTipoEventoAgenda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleTipoEventoAgendaXID(RR_TipoEventoAgenda Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleTipoEventoAgendaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoEventoAgendaXID(RR_TipoEventoAgenda Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarTipoEventoAgendaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Tipo De Riesgos
        public void ACCatalogoTipoRiesgo(RR_TipoRiesgos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoTipoRiesgo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_TipoRiesgos> ObtenerCatalogoTipoRiesgo(RR_TipoRiesgos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoTipoRiesgo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleTipoRiesgoXID(RR_TipoRiesgos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleTipoRiesgoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoRiesgoXID(RR_TipoRiesgos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarTipoRiesgoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Tipo Gastos

        public void ACCatalogoTipoGasto(RR_TipoGastos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoTipoGasto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_TipoGastos> ObtenerCatalogoTipoGasto(RR_TipoGastos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoTipoGasto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleTipoGastoXID(RR_TipoGastos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleTipoGastoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoGastoXID(RR_TipoGastos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarTipoGastoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region status Proyecto

        public void ACCatalogoStatusProyecto(RR_StatusProyecto Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoStatusProyecto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_StatusProyecto> ObtenerCatalogoStatusProyecto(RR_StatusProyecto Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoStatusProyecto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleStatusProyectoXID(RR_StatusProyecto Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleStatusProyectoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusProyectoXID(RR_StatusProyecto Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarStatusProyectoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Status Colaboradores

        public void ACCatalogoStatusColaborador(RR_StatusColaborador Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoStatusColaborador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_StatusColaborador> ObtenerCatalogoStatusColaborador(RR_StatusColaborador Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoStatusColaborador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleStatusColaboradorXID(RR_StatusColaborador Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleStatusColaboradorXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusColaboradorXID(RR_StatusColaborador Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarStatusColaboradorXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Status Encuesta

        public void ACCatalogoStatusEncuesta(RR_StatusEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoStatusEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_StatusEncuestas> ObtenerCatalogoStatusEncuesta(RR_StatusEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoStatusEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleStatusEncuestaXID(RR_StatusEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleStatusEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusEncuestaXID(RR_StatusEncuestas Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarStatusEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Status Evento
        public void ACCatalogoStatusEvento(RR_StatusEventos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoStatusEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_StatusEventos> ObtenerCatalogoStatusEvento(RR_StatusEventos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoStatusEvento(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleStatusEventoXID(RR_StatusEventos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleStatusEventoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusEventoXID(RR_StatusEventos Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarStatusEventoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Tipo Usuario

        public void ACCatalogoTipoUsuario(RR_TipoUsuarios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_TipoUsuarios> ObtenerCatalogoTipoUsuario(RR_TipoUsuarios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleTipoUsuarioXID(RR_TipoUsuarios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleTipoUsuarioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoUsuarioXID(RR_TipoUsuarios Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarTipoUsuarioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Modulo X Tipo Usuario

        public void ACCatalogoModuloTipoUsuario(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoModuloTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_ModuloXTipoUsuario> ObtenerCatalogoModuloTipoUsuario(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoModuloTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleModuloTipoUsuarioXID(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleModuloTipoUsuarioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarModuloTipoUsuarioXID(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarModuloTipoUsuarioXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Nueva Actividad

        public void ACCatalogoNuevaActividad(RR_NuevaActividad Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoNuevaActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_NuevaActividad> ObtenerCatalogoNuevaActividad(RR_NuevaActividad Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoNuevaActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleNuevaActividadXID(RR_NuevaActividad Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleNuevaActividadXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarNuevaActividadXID(RR_NuevaActividad Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarNuevaActividadXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_TipoEventoAgenda> ObtenerCatalogoActividad(RR_TipoEventoAgenda Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_CatColaborador> ObtenerCatalogoEncargado(EM_CatColaborador Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoEncargado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_NuevaActividad> ObtenerActividadesBusqueda(RR_NuevaActividad Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerBusquedaActividad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Afiliados

        public void ACCatalogoAfiliado(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACCatalogoAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_Afiliados> ObtenerCatalogoAfiliado(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerCatalogoAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleAfiliadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarAfiliadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RatificarAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.RatificarAfiliadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Genero> ObtenerComboGenero(CH_Genero Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerComboGenero(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_Afiliados> ObtenerCatalogoAfiliadoBusqueda(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerBusquedaAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RR_Afiliados ObtenerCount(RR_Afiliados Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObternerCountAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Nueva Respuesta
        public void ACRespuestas(RR_NuevaRespuesta Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ACRespuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_NuevaRespuesta> ObtenerRespuestas(RR_NuevaRespuesta Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                return CD.ObtenerRespuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleRespuestasXID(RR_NuevaRespuesta Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.ObtenerDetalleRespuestasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRespuestasXID(RR_NuevaRespuesta Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.EliminarRespuestasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AEncuestaContestadas(RR_NuevaRespuesta Datos)
        {
            try
            {
                RR_CatalogoDatos CD = new RR_CatalogoDatos();
                CD.AEncuestaContestada(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
