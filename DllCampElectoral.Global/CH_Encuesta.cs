using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Encuesta
    {
        public CH_Encuesta()
        {
            ListaEstados = new List<CH_Estados>();
            ListaEncuestas = new List<CH_Encuesta>();
            ListaGeneros = new List<CH_Genero>();
            ListaGradosEstudio = new List<CH_GradoEstudio>();
            ListaEntrevistador = new List<CH_Colaborador>();
            ListaSupervisor = new List<CH_Colaborador>();
        }
        private string _Folio;

        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private string _IDRespuesta;

        public string IDRespuesta
        {
            get { return _IDRespuesta; }
            set { _IDRespuesta = value; }
        }

        private string _IDEncuesta;
        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }
        private string _IDPregunta;

        public string IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }
        
        private string _EncuestaDesc;
        public string EncuestaDesc
        {
            get { return _EncuestaDesc; }
            set { _EncuestaDesc = value; }
        }

        private DateTime _FechaEncuesta;

        public DateTime FechaEncuesta
        {
            get { return _FechaEncuesta; }
            set { _FechaEncuesta = value; }
        }

        private string _HoraInicio;

        public string HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private string _HoraTermino;

        public string HoraTermino
        {
            get { return _HoraTermino; }
            set { _HoraTermino = value; }
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
        private string _IDPoligono;

        public string IDPoligono
        {
            get { return _IDPoligono; }
            set { _IDPoligono = value; }
        }

        private string _PoligonoDesc;

        public string PoligonoDesc
        {
            get { return _PoligonoDesc; }
            set { _PoligonoDesc = value; }
        }


        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _ApellidoPat;

        public string ApellidoPat
        {
            get { return _ApellidoPat; }
            set { _ApellidoPat = value; }
        }

        private string _ApellidoMat;

        public string ApellidoMat
        {
            get { return _ApellidoMat; }
            set { _ApellidoMat = value; }
        }

        private int _Edad;

        public int Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }

        private int _AniosColonia;

        public int AniosColonia
        {
            get { return _AniosColonia; }
            set { _AniosColonia = value; }
        }

        private int _IDGenero;

        public int IDGenero
        {
            get { return _IDGenero; }
            set { _IDGenero = value; }
        }

        private int _IDGradoEstudio;

        public int IDGradoEstudio
        {
            get { return _IDGradoEstudio; }
            set { _IDGradoEstudio = value; }
        }

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _IDEntrevistador;

        public string IDEntrevistador
        {
            get { return _IDEntrevistador; }
            set { _IDEntrevistador = value; }
        }

        private string _IDSupervisor;

        public string IDSupervisor
        {
            get { return _IDSupervisor; }
            set { _IDSupervisor = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
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

        private List<CH_Estados> _ListaEstados;

        public List<CH_Estados> ListaEstados
        {
            get { return _ListaEstados; }
            set { _ListaEstados = value; }
        }

        private List<CH_Encuesta> _ListaEncuestas;

        public List<CH_Encuesta> ListaEncuestas
        {
            get { return _ListaEncuestas; }
            set { _ListaEncuestas = value; }
        }

        private List<CH_Genero> _ListaGeneros;

        public List<CH_Genero> ListaGeneros
        {
            get { return _ListaGeneros; }
            set { _ListaGeneros = value; }
        }

        private List<CH_GradoEstudio> _ListaGradosEstudio;

        public List<CH_GradoEstudio> ListaGradosEstudio
        {
            get { return _ListaGradosEstudio; }
            set { _ListaGradosEstudio = value; }
        }

        private List<CH_Colaborador> _ListaEntrevistador;

        public List<CH_Colaborador> ListaEntrevistador
        {
            get { return _ListaEntrevistador; }
            set { _ListaEntrevistador = value; }
        }

        private List<CH_Colaborador> _ListaSupervisor;

        public List<CH_Colaborador> ListaSupervisor
        {
            get { return _ListaSupervisor; }
            set { _ListaSupervisor = value; }
        }
        private double _Latitud;

        public double Latitud
        {
            get { return _Latitud; }
            set { _Latitud = value; }
        }

        private string _sLatitud;

        public string sLatitud
        {
            get { return _sLatitud; }
            set { _sLatitud = value; }
        }

        private double _Longitud;

        public double Longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }

        private string _sLongitud;

        public string sLongitud
        {
            get { return _sLongitud; }
            set { _sLongitud = value; }
        }

        private double _LatitudPol;

        public double LatitudPol
        {
            get { return _LatitudPol; }
            set { _LatitudPol = value; }
        }

        private double _LongitudPol;

        public double LongitudPol
        {
            get { return _LongitudPol; }
            set { _LongitudPol = value; }
        }
        private string _Color;

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        #region Datos de Respuesta para graficar poligonos en mapas

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

        private string _DescripcionPorcentaje;

        public string DescripcionPorcentaje
        {
            get { return _DescripcionPorcentaje; }
            set { _DescripcionPorcentaje = value; }
        }

        private List<CH_Encuesta> _ListaValoresRespuesta;

        public List<CH_Encuesta> ListaValoresRespuesta
        {
            get { return _ListaValoresRespuesta; }
            set { _ListaValoresRespuesta = value; }
        }

        #endregion
    }
}
