using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Estados
    {
        
        private int _IDEstado;
        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }

        private string _EstadoDesc;
        public string EstadoDesc
        {
            get { return _EstadoDesc; }
            set { _EstadoDesc = value; }
        }

        private string _Siglas;

        public string Siglas
        {
            get { return _Siglas; }
            set { _Siglas = value; }
        }
        
        
        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private bool _NuevoRegistro;
        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private bool _Completado;
        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private int _Resultado;
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }
    }
}
