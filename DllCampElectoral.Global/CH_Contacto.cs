using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Contacto
    {
        private string _Telefono;
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _Correo;
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        
        private double _Latitud;
        public double Latitud
        {
            get { return _Latitud; }
            set { _Latitud = value; }
        }

        private double _Longitud;
        public double Longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }
        
        private string _sLatitud;
        public string sLatitud
        {
            get { return _sLatitud; }
            set { _sLatitud = value; }
        }

        private string _sLongitud;
        public string sLongitud
        {
            get { return _sLongitud; }
            set { _sLongitud = value; }
        }

        private string _TituloContacto;

        public string TituloContacto
        {
            get { return _TituloContacto; }
            set { _TituloContacto = value; }
        }

        private string _TextoContacto;

        public string TextoContacto
        {
            get { return _TextoContacto; }
            set { _TextoContacto = value; }
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
