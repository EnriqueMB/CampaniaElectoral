using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_ZonaRiesgo
    {
        public CH_ZonaRiesgo()
        {
            _ListaEstados = new List<CH_Estados>();
            _ListaTipoRiesgos = new List<CH_TipoRiesgo>();
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _IDZonaRiesgo;

        public string IDZonaRiesgo
        {
            get { return _IDZonaRiesgo; }
            set { _IDZonaRiesgo = value; }
        }

        private string _UrlIcon;

        public string UrlIcon
        {
            get { return _UrlIcon; }
            set { _UrlIcon = value; }
        }


        private string _Titulo;

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IDTipoRiesgo;

        public int IDTipoRiesgo
        {
            get { return _IDTipoRiesgo; }
            set { _IDTipoRiesgo = value; }
        }

        private int _IDEstado;

        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }

        private int _IDMunicipio;

        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        private int _IDSeccion;

        public int IDSeccion
        {
            get { return _IDSeccion; }
            set { _IDSeccion = value; }
        }
        private int _IDCasilla;

        public int IDCasilla
        {
            get { return _IDCasilla; }
            set { _IDCasilla = value; }
        }


        private string _IDPoligono;

        public string IDPoligono
        {
            get { return _IDPoligono; }
            set { _IDPoligono = value; }
        }
        private string _IDColaborador;

        public string IDColaborador
        {
            get { return _IDColaborador; }
            set { _IDColaborador = value; }
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

        private List<CH_TipoRiesgo> _ListaTipoRiesgos;

        public List<CH_TipoRiesgo> ListaTipoRiesgos
        {
            get { return _ListaTipoRiesgos; }
            set { _ListaTipoRiesgos = value; }
        }



        private List<CH_Estados> _ListaEstados;

        public List<CH_Estados> ListaEstados
        {
            get { return _ListaEstados; }
            set { _ListaEstados = value; }
        }
        private List<CH_Municipio> _ListaMunicipio;

        public List<CH_Municipio> ListaMunicipio
        {
            get { return _ListaMunicipio; }
            set { _ListaMunicipio = value; }
        }
    }
}
