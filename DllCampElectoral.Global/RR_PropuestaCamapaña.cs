using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_PropuestaCamapaña
    {
        private string _IDPropuesta;
        public string IDPropuesta
        {
            get { return _IDPropuesta; }
            set { _IDPropuesta = value; }
        }

        private string _NombrePropuesta;
        public string NombrePropuesta
        {
            get { return _NombrePropuesta; }
            set { _NombrePropuesta = value; }
        }

        private string _Descripcion1;
        public string Descripcion1
        {
            get { return _Descripcion1; }
            set { _Descripcion1 = value; }
        }

        private string _Descripcion2;
        public string Descripcion2
        {
            get { return _Descripcion2; }
            set { _Descripcion2 = value; }
        }

        private string _Descripcion3;
        public string Descripcion3
        {
            get { return _Descripcion3; }
            set { _Descripcion3 = value; }
        }

        private string _PieDePagina;
        public string PieDePagina
        {
            get { return _PieDePagina; }
            set { _PieDePagina = value; }
        }

        private DateTime _Fecha;
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        
        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

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
