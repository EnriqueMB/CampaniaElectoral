using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class ER_Incidencias
    {
        private string _IDRiesgo;

        public string IDRiesgo
        {
            get { return _IDRiesgo; }
            set { _IDRiesgo = value; }
        }
        private int _municipio;

        public int municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
        }
        private int _IDEstado;

        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        private string   _Descricion;

        public string Descripcion
        {
            get { return _Descricion; }
            set { _Descricion = value; }
        }
        private string _titulo;

        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

    }
}
