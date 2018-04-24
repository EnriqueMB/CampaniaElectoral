using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class GM_PlanCampania
    {
        private string _IDPElectoral;

        public string IDPElectoral
        {
            get { return _IDPElectoral; }
            set { _IDPElectoral = value; }
        }

        private string _TituloProyecto;
        public string TituloProyecto
        {
            get { return _TituloProyecto; }
            set { _TituloProyecto = value; }
        }

        private string _Pryecto1;
        public string Proyecto1
        {
            get { return _Pryecto1; }
            set { _Pryecto1 = value; }
        }

        private string _Proyecto2;
        public string Proyecto2
        {
            get { return _Proyecto2; }
            set { _Proyecto2 = value; }
        }

        private string _Proyecto3;
        public string Proyecto3
        {
            get { return _Proyecto3; }
            set { _Proyecto3 = value; }
        }

        private string _ProyectoP;
        public string ProyectoP
        {
            get { return _ProyectoP; }
            set { _ProyectoP = value; }
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
        
        #region Control
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
