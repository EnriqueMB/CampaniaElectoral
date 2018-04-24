using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Evento
    {
        private string _IDEvento;

        public string IDEvento
        {
            get { return _IDEvento; }
            set { _IDEvento = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _UrlImagen;

        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }
        

        private int _IDTipoEvento;

        public int IDTipoEvento
        {
            get { return _IDTipoEvento; }
            set { _IDTipoEvento = value; }
        }

        private string _TipoEventoDesc;

        public string TipoEventoDesc
        {
            get { return _TipoEventoDesc; }
            set { _TipoEventoDesc = value; }
        }

        private string _IDColaborador;

        public string IDColaborador
        {
            get { return _IDColaborador; }
            set { _IDColaborador = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private string _HoraInicio;

        public string HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private DateTime _FechaTermino;

        public DateTime FechaTermino
        {
            get { return _FechaTermino; }
            set { _FechaTermino = value; }
        }

        private string _HoraTermino;

        public string HoraTermino
        {
            get { return _HoraTermino; }
            set { _HoraTermino = value; }
        }

        private string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private decimal _Meta;

        public decimal Meta
        {
            get { return _Meta; }
            set { _Meta = value; }
        }

        private string _MensajeEncargado;

        public string MensajeEncargado
        {
            get { return _MensajeEncargado; }
            set { _MensajeEncargado = value; }
        }

        private string _TituloPagina;

        public string TituloPagina
        {
            get { return _TituloPagina; }
            set { _TituloPagina = value; }
        }

        private string _TextoPagina;

        public string TextoPagina
        {
            get { return _TextoPagina; }
            set { _TextoPagina = value; }
        }

        private DateTime _FechaEvento;

        public DateTime FechaEvento
        {
            get { return _FechaEvento; }
            set { _FechaEvento = value; }
        }

        private string _HoraEvento;

        public string HoraEvento
        {
            get { return _HoraEvento; }
            set { _HoraEvento = value; }
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

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private decimal _Latitud;

        public decimal Latitud
        {
            get { return _Latitud; }
            set { _Latitud = value; }
        }

        private decimal _Longitud;

        public decimal Longitud
        {
            get { return _Longitud; }
            set { _Longitud = value; }
        }

        private bool _Publicar;

        public bool Publicar
        {
            get { return _Publicar; }
            set { _Publicar = value; }
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
    }
}
