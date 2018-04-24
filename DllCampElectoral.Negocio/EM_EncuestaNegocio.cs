using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class EM_EncuestaNegocio
    {

        public void ACEncuesta(EM_Encuesta Datos)
        {
            try
            {
                EM_EncuestaDatos ED = new EM_EncuestaDatos();
                ED.ACENcuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Encuesta> ObtenerEncueestas(EM_Encuesta Datos)
        {
            try
            {
                EM_EncuestaDatos ED = new EM_EncuestaDatos();
                return ED.ObtenerEncuestas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleEncuestasXID(EM_Encuesta Datos)
        {
            try
            {
                EM_EncuestaDatos ED = new EM_EncuestaDatos();
                ED.ObtenerDetalleEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuestaXID(EM_Encuesta Datos)
        {
            try
            {
                EM_EncuestaDatos ED = new EM_EncuestaDatos();
                ED.EliminarEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarEncuestaXID(EM_Encuesta Datos)
        {
            try
            {
                EM_EncuestaDatos ED = new EM_EncuestaDatos();
                ED.CerrarEncuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
