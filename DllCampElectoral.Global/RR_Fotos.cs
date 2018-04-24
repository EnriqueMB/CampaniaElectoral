using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_Fotos
    {
        private string _IDFoto;
        public string IDFoto
        {
            get { return _IDFoto; }
            set { _IDFoto = value; }
        }

        private string _UrlFoto;
        public string UrlFoto
        {
            get { return _UrlFoto; }
            set { _UrlFoto = value; }
        }

        private string _Alt;
        public string Alt
        {
            get { return _Alt; }
            set { _Alt = value; }
        }

        private string _Tittle;
        public string Tittle
        {
            get { return _Tittle; }
            set { _Tittle = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _NombreArc;
        public string NombreArc
        {
            get { return _NombreArc; }
            set { _NombreArc = value; }
        }

        private string _TipoArc;
        public string TipoArc
        {
            get { return _TipoArc; }
            set { _TipoArc = value; }
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
