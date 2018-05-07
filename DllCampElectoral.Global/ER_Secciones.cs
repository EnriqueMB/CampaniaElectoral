using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
  public class ER_Secciones
    {
        private int _IDEstado;

        public int IDEstados
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        private int _ID_Distrito;

        public int ID_Distrito
        {
            get { return _ID_Distrito; }
            set { _ID_Distrito = value; }
        }
        private int _ID_DistritoLocal;

        public int ID_DistritoLocal
        {
            get { return _ID_DistritoLocal; }
            set { _ID_DistritoLocal = value; }
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
        private int _IDTipo;

        public int IDTipo
        {
            get { return _IDTipo; }
            set { _IDTipo = value; }
        }
        private string _Municipio;

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }
        private string _seccionDesc;

        public string seccionDesc
        {
            get { return _seccionDesc; }
            set { _seccionDesc = value; }
        }

        private string _poligono;

        public string poligono
        {
            get { return _poligono; }
            set { _poligono = value; }
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
        private List<ER_Secciones> _listaSecciones;

        public List<ER_Secciones> listaSecciones
        {
            get { return _listaSecciones; }
            set { _listaSecciones = value; }
        }
        private List<EM_Munucipios> _listaMunicipios;

        public List<EM_Munucipios> listaMunicipios
        {
            get { return _listaMunicipios; }
            set { _listaMunicipios = value; }
        }
        private List<ER_Casillas> _listaCasillas;

        public List<ER_Casillas> listaCasillas
        {
            get { return _listaCasillas; }
            set { _listaCasillas = value; }
        }

        private int _opcion;

        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

    }
}
