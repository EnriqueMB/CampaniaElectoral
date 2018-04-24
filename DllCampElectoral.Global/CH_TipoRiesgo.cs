using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_TipoRiesgo
    {
        private int _IDTipoRiesgo;

        public int IDTipoRiesgo
        {
            get { return _IDTipoRiesgo; }
            set { _IDTipoRiesgo = value; }
        }

        private string _Descripcion;
            
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _CssIcon;

        public string CssIcon
        {
            get { return _CssIcon; }
            set { _CssIcon = value; }
        }

        private string _UrlIcon;

        public string UrlIcon
        {
            get { return _UrlIcon; }
            set { _UrlIcon = value; }
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
    }
}
