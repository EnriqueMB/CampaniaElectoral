using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class EM_PreguntaRespuestaNegocio
    {
        public void ObtenerEncueestass(EM_Encuesta Datos)
        {
            try
            {
                EM_PreguntasRespuestaDatos ED = new EM_PreguntasRespuestaDatos();
                ED.ObtenerPreguntaRespuestaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
