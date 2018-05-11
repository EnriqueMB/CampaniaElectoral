using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;

namespace DllCampElectoral.Negocio
{
    public class FG_EstadisticosVotosNegocio
    {
        private FG_EstadisticosVotosDatos FG_Datos;

        public int ObtenerMetaGeneral(FG_EstadisticosVotos FG)
        {
            try
            {
                FG_Datos = new FG_EstadisticosVotosDatos();
                return FG_Datos.ObtenerMetaVotosGeneral(FG);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerTotalVotosRealiazados(FG_EstadisticosVotos FG)
        {
            try
            {
                FG_Datos = new FG_EstadisticosVotosDatos();
                return FG_Datos.ObtenerTotalVotosRealizados(FG);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FG_EstadisticosVotos_MetaXHora> ObtenerListaMetasXHora(FG_EstadisticosVotos FG)
        {
            try
            {
                FG_Datos = new FG_EstadisticosVotosDatos();
                return FG_Datos.ObtenerListaMetasXHora(FG);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
