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
        private string _municipio;

        public string municipio
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
        private int _IDMunicipio;

        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        private int _IDTipoRiesgo;

        public int IDTipoRiesgo
        {
            get { return _IDTipoRiesgo; }
            set { _IDTipoRiesgo = value; }
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
        private float _latitud;

        public float latitud
        {
            get { return _latitud; }
            set { _latitud = value; }
        }
        private float _longitud;

        public float longitud
        {
            get { return _longitud; }
            set { _longitud = value; }
        }
        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private int _Resultado;
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private bool _Completado;
        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        private List<ER_Incidencias> _listaIncidencias;

        public List<ER_Incidencias> listaIncidencias
        {
            get { return _listaIncidencias; }
            set { _listaIncidencias = value; }
        }
        private string _Riesgos;

        public string Riesgos
        {
            get { return _Riesgos; }
            set { _Riesgos = value; }
        }

        public string tipoRiesgo { get; set; }
        public string estado { get; set; }
        public string casilla { get; set; }
        public string domicilio { get; set; }
        public string referencia { get; set; }
    }
}
