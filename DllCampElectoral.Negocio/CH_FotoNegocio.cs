using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_FotoNegocio
    {

        #region Catálogo Fotos de Galería

        public void ACFoto(CH_Foto Datos)
        {
            try
            {
                CH_FotosDatos FD = new CH_FotosDatos();
                FD.ACFoto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Foto> ObtenerCatalogoFotos(CH_Foto Datos)
        {
            try
            {
                CH_FotosDatos FD = new CH_FotosDatos();
                return FD.ObtenerCatalogoFotos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleFotoXID(CH_Foto Datos)
        {
            try
            {
                CH_FotosDatos FD = new CH_FotosDatos();
                FD.ObtenerDetalleFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFotoXID(CH_Foto Datos)
        {
            try
            {
                CH_FotosDatos FD = new CH_FotosDatos();
                FD.EliminarFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImagenSubidaFotoXID(CH_Foto Datos)
        {
            try
            {
                CH_FotosDatos FD = new CH_FotosDatos();
                FD.ImagenSubidaFotoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
