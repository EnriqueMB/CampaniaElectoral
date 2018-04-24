using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_EncuestaNegocio
    {
        public void ObtenerCombosResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.ObtenerCombosResponderEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AC_ResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.AC_ResponderEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerDetalleResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.ObtenerDetalleResponderEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CH_Encuesta> ObtenerListaRespuestas(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                return ED.ObtenerListaRespuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarRespuestaXID(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.EliminarRespuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosUbicacionRespuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.ObtenerDatosUbicacionRespuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AC_UbicacionRespuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.AC_UbicacionRespuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_ResultadoEncuestaJSON> ObtenerPoligonosXEncuesta(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                return ED.ObtenerPoligonosXEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosMapaResultado(CH_Encuesta Datos)
        {
            try
            {
                CH_EncuestaDatos ED = new CH_EncuestaDatos();
                ED.ObtenerDatosMapaResultado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
