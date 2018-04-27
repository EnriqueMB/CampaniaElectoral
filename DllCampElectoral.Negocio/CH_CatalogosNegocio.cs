using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_CatalogosNegocio
    {
        #region CatGénero

        public void ACCatalogoGenero(CH_Genero Datos)
        {
            try
            {
                //if (!string.IsNullOrEmpty(Datos.Descripcion) && !string.IsNullOrEmpty(Datos.Letra))
                //{
                    CH_CatalogosDatos CD = new CH_CatalogosDatos();
                    CD.ACCatalogoGenero(Datos);
                //}
                //throw new Exception("No pasó la validación de servidor");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Genero> ObtenerCatalogoGenero(CH_Genero Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                return CD.ObtenerCatalogoGenero(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerDetalleGeneroXID(CH_Genero Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.ObtenerDetalleGeneroXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGeneroXID(CH_Genero Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.EliminarGeneroXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catálogo Partidos Políticos

        public void ACCatalogoPartidos(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.ACCatalogoPartidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_PartidoPolitico> ObtenerCatalogoPartidos(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                return CD.ObtenerCatalogoPartidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.ObtenerDetallePartidoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComboColaboradoresTipo(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.ObtenerCombosColaborador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarPartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.EliminarPartidoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaPartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                CD.ImagenSubidaPartidoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Catalogo Colaboradores

        public List<CH_Colaborador> ObtenerComboColaborador(CH_Colaborador Datos)
        {
            try
            {
                CH_CatalogosDatos CN = new CH_CatalogosDatos();
                return CN.ObtenerComboColaborador(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catálogo Municipios

        public List<CH_MunicipioJSON> ObtenerMunicipiosXIDEstado(CH_Municipio Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                return CD.ObtenerMunicipiosXIDEstado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_PoligonoJSON> ObtenerPoligonosXIDEstadoMunicipio(CH_Poligono Datos)
        {
            try
            {
                CH_CatalogosDatos CD = new CH_CatalogosDatos();
                return CD.ObtenerPoligonosXIDEstadoMunicipio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
