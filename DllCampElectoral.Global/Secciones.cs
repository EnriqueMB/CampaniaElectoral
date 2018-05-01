using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class Secciones
    {

        private int _IDSeccion;

        public int IDSeccion
        {
            get { return _IDSeccion; }
            set { _IDSeccion = value; }
        }

        private string _TipoSeccion;

        public string TipoSeccion
        {
            get { return _TipoSeccion; }
            set { _TipoSeccion = value; }
        }


        private int _RecordTotal;

        public int RecordTotal
        {
            get { return _RecordTotal; }
            set { _RecordTotal = value; }
        }

        private int _RecordFilter;

        public int RecordFilter
        {
            get { return _RecordFilter; }
            set { _RecordFilter = value; }
        }

        private int _Start;

        public int Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        private int _Length;

        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        private string _SearchValue;

        public string SearchValue
        {
            get { return _SearchValue; }
            set { _SearchValue = value; }
        }

        private string _Casillas;

        public string Casillas
        {
            get { return _Casillas; }
            set { _Casillas = value; }
        }


        private List<Secciones> _ListaSecciones;

        public List<Secciones> ListaSecciones
        {
            get { return _ListaSecciones; }
            set { _ListaSecciones = value; }
        }

        private int _OrderBy;

        public int OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        private string _OrderDirection;

        public string OrderDirection
        {
            get { return _OrderDirection; }
            set { _OrderDirection = value; }
        }

        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Municipio;

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }

        private string _Poligono;

        public string Poligono
        {
            get { return _Poligono; }
            set { _Poligono = value; }
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
