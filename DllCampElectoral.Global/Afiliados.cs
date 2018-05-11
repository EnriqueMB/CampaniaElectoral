using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class Afiliados
    {

        private string _IDAfiliado;
        public string IDAfiliado
        {
            get { return _IDAfiliado; }
            set { _IDAfiliado = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private DateTime _FechaAfiliacion;
        public DateTime FechaAfiliacion
        {
            get { return _FechaAfiliacion; }
            set { _FechaAfiliacion = value; }
        }

        public string FechaAfiliacionString
        {
            get { return FechaAfiliacion.ToString("dd/MM/yyyy", new CultureInfo("es-MX")); }

        }

        private string _Estatus;
        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private string _CssClassEstatus;
        public string CssClassEstatus
        {
            get { return _CssClassEstatus; }
            set { _CssClassEstatus = value; }
        }

        private int _Seccion;
        public int Seccion
        {
            get { return _Seccion; }
            set { _Seccion = value; }
        }

        private string _ClaveElector;
        public string ClaveElector
        {
            get { return _ClaveElector; }
            set { _ClaveElector = value; }
        }

        private string _Operador;
        public string Operador
        {
            get { return _Operador; }
            set { _Operador = value; }
        }

        private bool _Ratificado;
        public bool Ratificado
        {
            get { return _Ratificado; }
            set { _Ratificado = value; }
        }

        private bool _DatosCompletados;

        public bool DatosCompletados
        {
            get { return _DatosCompletados; }
            set { _DatosCompletados = value; }
        }


        private List<Afiliados> _ListaAfiliados;
        public List<Afiliados> ListaAfiliados
        {
            get { return _ListaAfiliados; }
            set { _ListaAfiliados = value; }
        }
        
        #region Datos para paginación AJAX

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

        private int _TipoBusqueda;
        public int TipoBusqueda
        {
            get { return _TipoBusqueda; }
            set { _TipoBusqueda = value; }
        }

        private DateTime _FechaInicio;
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private DateTime _FechaFin;
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        #endregion

        #region Datos de control

        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
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

        #endregion
    }
}
