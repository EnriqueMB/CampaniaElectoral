using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_PreguntasNegocio
    {
        public void ACPreguntas(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                PD.ACPreguntas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EM_Preguntas> ObtenerPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                return PD.ObtenerPregutasXIDEncuesta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                PD.ObtenerDetallePreguntaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                PD.EliminarPreguntasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCampoMapaPreguntaXID(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                PD.ObtenerCamposPreguntasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarCamposPreguntasXID(EM_Preguntas Datos)
        {
            try
            {
                EM_PreguntasDatos PD = new EM_PreguntasDatos();
                PD.ActualizacionCamposPreguntasXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
