using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class JL_Suscripcion
    {
        private string _correo;

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private string _conexion;

        public string Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _fecha;

        public string fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private bool _baja;

        public bool baja
        {
            get { return _baja; }
            set { _baja = value; }
        }
        private bool _completado;

        public bool Completado
        {
            get { return _completado; }
            set { _completado = value; }
        }
        private int _resultado;

        public int Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }


    }
}
