using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_Preguntas
    {
        private string _IDPreguntas;

        public string IDPreguntas
        {
            get { return _IDPreguntas; }
            set { _IDPreguntas = value; }
        }

        private int _IDTipoPregunta;

        public int IDTipoPregunta
        {
            get { return _IDTipoPregunta; }
            set { _IDTipoPregunta = value; }
        }
        private string _IDEncuesta;

        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }
        private string _NombrePregunta;

        public string NombrePregunta
        {
            get { return _NombrePregunta; }
            set { _NombrePregunta = value; }
        }
        private int _Orden;

        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        private DateTime _FechaCaptura;

        public DateTime FechaCaptura
        {
            get { return _FechaCaptura; }
            set { _FechaCaptura = value; }
        }
        private int _CantidadRespuesta;

        public int CantidadRespuesta
        {
            get { return _CantidadRespuesta; }
            set { _CantidadRespuesta = value; }
        }
        private string _NombreTipoPre;

        public string NombreTipoPre
        {
            get { return _NombreTipoPre; }
            set { _NombreTipoPre = value; }
        }

        private string _TituloRespuesta;

        public string TituloRespuesta
        {
            get { return _TituloRespuesta; }
            set { _TituloRespuesta = value; }
        }

        private string _PeriodoDatos;

        public string PeriodoDatos
        {
            get { return _PeriodoDatos; }
            set { _PeriodoDatos = value; }
        }

        private string _TituloPorcentaje;

        public string TituloPorcentaje
        {
            get { return _TituloPorcentaje; }
            set { _TituloPorcentaje = value; }
        }

        private string _Explicacion;

        public string Explicacion
        {
            get { return _Explicacion; }
            set { _Explicacion = value; }
        }

        private List<RR_NuevaRespuesta> _ListaRespuesta;

        public List<RR_NuevaRespuesta> ListaRespuesta
        {
            get { return _ListaRespuesta; }
            set { _ListaRespuesta = value; }
        }

        private string _IDRespuestaContestada;

        public string IDRespuestaContestada
        {
            get { return _IDRespuestaContestada; }
            set { _IDRespuestaContestada = value; }
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
