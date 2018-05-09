using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class FG_CatPartidoPoliticoAlianza
    {
        public int IDPartidoPoliticoAlianza { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public string Logo { get; set; }

        public string PartidosPoliticos { get; set; }
        public string ExtensionBase64 { get; set; }

        public string Conexion { get; set; }
        public string Usuario { get; set; }
        public bool Completado { get; set; }
        public string Mensaje { get; set; }
    }
}
