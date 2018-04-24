using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class ZM_CatalogosNegocio
    {
        #region Afiliados

        public List<ZM_ImagenesAfiliados> ObtenerCatalogoImagenes(ZM_ImagenesAfiliados Datos)
        {
            try
            {
                ZM_CatalogosDatos CD = new ZM_CatalogosDatos();
                return CD.ObtenerCatalogoImagenes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CatalogoImagenes(ZM_ImagenesAfiliados Datos)
        {
            try
            {
                ZM_CatalogosDatos CD = new ZM_CatalogosDatos();
                CD.CatalogoImagenes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarImagenAfiliado(ZM_ImagenesAfiliados Datos)
        {
            try
            {
                ZM_CatalogosDatos CD = new ZM_CatalogosDatos();
                CD.EliminarImagenAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
        

        #endregion
 }
