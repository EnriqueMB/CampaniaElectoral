using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_PartidoPolitico
    {
        private int _IDPartido;
        public int IDPartido
        {
            get { return _IDPartido; }
            set { _IDPartido = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Siglas;
        public string Siglas
        {
            get { return _Siglas; }
            set { _Siglas = value; }
        }

        private string _UrlLogo;
        public string UrlLogo
        {
            get { return _UrlLogo; }
            set { _UrlLogo = value; }
        }

        private string _ExtensionLogo;
        public string ExtensionLogo
        {
            get { return _ExtensionLogo; }
            set { _ExtensionLogo = value; }
        }

        private bool _CambioImagen;
        public bool CambioImagen
        {
            get { return _CambioImagen; }
            set { _CambioImagen = value; }
        }

        private string _RGBColor;
        public string RGBColor
        {
            get { return _RGBColor; }
            set { _RGBColor = value; }
        }
        private int _Votos;

        public int Votos
        {
            get { return _Votos; }
            set { _Votos = value; }
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
