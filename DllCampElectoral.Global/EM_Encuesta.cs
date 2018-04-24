using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_Encuesta
    {
        private string _IDEncuesta;

        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }
        private string _NombreEncuesta;

        public string NombreEncuesta
        {
            get { return _NombreEncuesta; }
            set { _NombreEncuesta = value; }
        }
        private string _NombreEstatus;

        public string NombreEstatus
        {
            get { return _NombreEstatus; }
            set { _NombreEstatus = value; }
        }
        private int _CantidadPregunta;

        public int CantidadPregunta
        {
            get { return _CantidadPregunta; }
            set { _CantidadPregunta = value; }
        }

        private string _ColorEstatus;

        public string ColorEstatus
        {
            get { return _ColorEstatus; }
            set { _ColorEstatus = value; }
        }

        private string _TituloGeneral;

        public string TituloGeneral
        {
            get { return _TituloGeneral; }
            set { _TituloGeneral = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _Teoria;

        public string Teoria
        {
            get { return _Teoria; }
            set { _Teoria = value; }
        }

        private List<EM_Preguntas> _ListaPregunta;

        public List<EM_Preguntas> ListaPregunta
        {
            get { return _ListaPregunta; }
            set { _ListaPregunta = value; }
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

        private DataTable _TablaDatosEncuesta;
        public DataTable TablaDatosEncuesta
        {
            get { return _TablaDatosEncuesta; }
            set { _TablaDatosEncuesta = value; }
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
