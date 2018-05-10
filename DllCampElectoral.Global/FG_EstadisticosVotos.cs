using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class FG_EstadisticosVotos
    {
        public int MetaVotosGeneral { get; set; }
        public int TotalVotosRealizados { get; set; }
        private int TotalVotosFaltantes { get; set; }
        private double PorcentajeAvanceGeneralVotos { get; set; }

        public string Conexion { get; set; }

        #region Metodos
        public int ObtenerTotalVotosFaltantes()
        {
            TotalVotosFaltantes = MetaVotosGeneral - TotalVotosFaltantes;
            return TotalVotosFaltantes;
        }

        public double CalcularPorcentajeAvanceGeneralVotos()
        {
            PorcentajeAvanceGeneralVotos = (TotalVotosRealizados * 100) / MetaVotosGeneral;
            return PorcentajeAvanceGeneralVotos;
        }


        #endregion
    }
}
