using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;
using System.Data;

namespace DllCampElectoral.Negocio
{
    public class EM_CatalagosNegocio
    {
        #region Catalago Rango Edades Negocios

        public void ACCatalogoRangoEdad(EM_RangoEdad Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACRangoEdades(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_RangoEdad> ObtenerCatalogoRangoEdad(EM_RangoEdad Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalogoRandoEdades(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerRangoDetalleXID(EM_RangoEdad Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObtenerRangoEdadDetalleXID(Datos);
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
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarRangoEdadXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catalogo Actividad Comercial

        public void ACCatalogoActivadadComercial(EM_ActividadComercial Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACActividaComercial(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_ActividadComercial> ObtenerCatalogoActividadComercial(EM_ActividadComercial Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalagoActividaComercial(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerActividadComercialDetalleXID(EM_ActividadComercial Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObternerActivadadDetalleXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarActividadComercialXID(EM_ActividadComercial Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarActividadComercialeXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catalogo Tipo Evento Campaña

        public void ACCatalogoTipoEventoCamp(EM_TipoEventoCampania Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACTipoEventoCampania(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_TipoEventoCampania> ObtenerCatalogoTipoEventoCampania(EM_TipoEventoCampania Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalagoTipoEventoCampania(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerTipoEventoCampaniaDetalleXID(EM_TipoEventoCampania Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObternerTipoEventoCampaniaDetalleXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoEventoCampaniaXID(EM_TipoEventoCampania Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarTipoEventoCampaniaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catalogo Status Afiliate

        public void ACCatalogoStatusAfiliado(EM_StatusAfiliados Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACStatusAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_StatusAfiliados> ObtenerCatalogoStatusAfiliado(EM_StatusAfiliados Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalagoStatusAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerStatusEventoDetalleXID(EM_StatusAfiliados Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObternerStatusAfiliadoDetalleXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusAfiliadoXID(EM_StatusAfiliados Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarStatusAfiliadoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catalogo Tipo Imagen Video

        public void ACCatalogoTipoImagenVideo(EM_TipoImagenVideo Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACTipoImagenVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_TipoImagenVideo> ObtenerCatalogoTipoImagenVideo(EM_TipoImagenVideo Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalagoTipoImagenVideo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerTipoImagenVideoDetalleXID(EM_TipoImagenVideo Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObternerTipoImagenVideoDetalleXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoImagenVideoXID(EM_TipoImagenVideo Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarTipoImagenVideoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catálogo Colaboradores

        public void ACCatalogoColaboradores(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACCatalogoColaboradores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ACCatalogoColaboradoresAUx(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ACCatalogoColaboradoresAuxiliar(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<EM_CatColaborador> ObtenerCatalogoColaboradores(EM_CatColaborador Datos)
        {
            
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerCatalogoColaboradores(Datos);
          
        }

        public void ObtenerDetalleColaboradoresXID(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObtenerDetalleColaboradoresXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleColaboradoresAuxiliarXID(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObtenerDetalleAuxliarColaboradoresXID(Datos);
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
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.EliminarColaboradorXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaColaboradroXID(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ImagenSubidaColaboradorXID(Datos);
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
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerComboGenero(Datos);
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
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerComboTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Combo Estatus General Evento

        public List<EM_StatusGeneralEvento> ObtenerComboStatusGeneralEvento(EM_StatusGeneralEvento Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerComboStatusGeneralEvento(Datos);
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
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                return CD.ObtenerComboColaboradores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Obtener Tipo Usuario Logeado
        public void ObtenerTipoUserLogeado(EM_CatColaborador Datos)
        {
            try
            {
                EM_CatalogosDatos CD = new EM_CatalogosDatos();
                CD.ObtenerTipoUser(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
