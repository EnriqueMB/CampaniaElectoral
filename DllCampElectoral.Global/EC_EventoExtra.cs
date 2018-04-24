using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EC_EventoExtra
    {
        private string _IDFoto;

        public string IDFoto
        {
            get { return _IDFoto; }
            set { _IDFoto = value; }
        }

        private string _URLImagen;

        public string URLImagen
        {
            get { return _URLImagen; }
            set { _URLImagen = value; }
        }

        private string _Extension;

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Alt;

        public string Alt
        {
            get { return _Alt; }
            set { _Alt = value; }
        }
        private bool _CambioImagen;

        public bool CambioImagen
        {
            get { return _CambioImagen; }
            set { _CambioImagen = value; }
        }
        private string _NombreArchivo;

        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; }
        }

        private string _id_actividadEvento;

        public string id_actividadEvento
        {
            get { return _id_actividadEvento; }
            set { _id_actividadEvento = value; }
        }
        private string _tituloPagina;

        public string tituloPagina
        {
            get { return _tituloPagina; }
            set { _tituloPagina = value; }
        }
        private string _textoPagina;

        public string textoPagina
        {
            get { return _textoPagina; }
            set { _textoPagina = value; }
        }
        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private DateTime _hora;

        public DateTime hora
        {
            get { return _hora; }
            set { _hora = value; }
        }
        private int _idEstado;

        public int idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }
        private int _idMunicipio;

        public int idMunicipio
        {
            get { return _idMunicipio; }
            set { _idMunicipio = value; }
        }
        private string _direccion;

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
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
        private bool _publicar;

        public bool publicar
        {
            get { return _publicar; }
            set { _publicar = value; }
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
        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
        private string _id_usuario;

        public string id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }
        private string _id_Foto;

        public string id_foto
        {
            get { return _id_Foto; }
            set { _id_Foto = value; }
        }
        private bool _nuevoRegistro;

        public bool nuevoRegistro
        {
            get { return _nuevoRegistro; }
            set { _nuevoRegistro = value; }
        }


    }
}
