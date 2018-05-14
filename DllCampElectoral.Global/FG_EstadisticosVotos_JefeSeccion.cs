using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class FG_EstadisticosVotos_JefeSeccion
    {
        public string  IDColaborador { get; set; }
        public int IDSeccion { get; set; }
        public int MetaXSeccion { get; set; }
        public string NombreJefeSeccion { get; set; }
        public string Imagen { get; set; }
        public int VotosColaborador { get; set; }
        public int VotosAfiliados { get; set; }
        public decimal Porcentaje { get; set; }
        public string  Mensaje { get; set; }
        public string Etiqueta { get; set; }
    }
}
