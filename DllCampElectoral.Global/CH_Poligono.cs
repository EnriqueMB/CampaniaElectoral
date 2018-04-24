using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Poligono
    {
        private string _IDPoligono;
        public string IDPoligono
        {
            get { return _IDPoligono; }
            set { _IDPoligono = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _PointString;
        public string PointString
        {
            get { return _PointString; }
            set { _PointString = value; }
        }

        private double _Latitud;
        public double Latidud
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

        private int _IDMunicipio;
        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }

        private string _MunicipioDesc;
        public string MunicipioDesc
        {
            get { return _MunicipioDesc; }
            set { _MunicipioDesc = value; }
        }

        private string _Colonia;
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }

        private int _OrdenPunto;
        public int OrdenPunto
        {
            get { return _OrdenPunto; }
            set { _OrdenPunto = value; }
        }

        private string _IDPunto;
        public string IDPunto
        {
            get { return _IDPunto; }
            set { _IDPunto = value; }
        }

        private bool _EsPrincipal;
        public bool EsPrincipal
        {
            get { return _EsPrincipal; }
            set { _EsPrincipal = value; }
        }

        private int _TotalPuntos;
        public int TotalPuntos
        {
            get { return _TotalPuntos; }
            set { _TotalPuntos = value; }
        }

        private string _LatitudLongitud;
        public string LatitudLongitud
        {
            get { return _LatitudLongitud; }
            set { _LatitudLongitud = value; }
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

        private List<CH_Poligono> _ListaPuntos;
        public List<CH_Poligono> ListaPuntos
        {
            get { return _ListaPuntos; }
            set { _ListaPuntos = value; }
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
        private string _seccion;

        public string Seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }
        private DataTable _dataTable;

        public DataTable dataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }
    }
}
