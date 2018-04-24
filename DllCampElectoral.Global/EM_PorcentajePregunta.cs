using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_PorcentajePregunta
    {
        private string  _IDPorcentaje;

        public string  IDPorcentaje
        {
            get { return _IDPorcentaje; }
            set { _IDPorcentaje = value; }
        }

        private string _IDPregunta;

        public string IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }

        private string _IDEncuesta;

        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }
        
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Color;

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private decimal _PorcentajeInicial;

        public decimal PorcentaleInicial
        {
            get { return _PorcentajeInicial; }
            set { _PorcentajeInicial = value; }
        }

        private decimal _PorcentajeFinal;

        public decimal PorcentajeFinal
        {
            get { return _PorcentajeFinal; }
            set { _PorcentajeFinal = value; }
        }

        private int _Orden;

        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        #region DatosDeControl

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

        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        #endregion
    }
}
