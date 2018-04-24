using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
   public class GM_LoadBanner
    {
        private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _IDBanner;

        public string IDBanner
        {
            get { return _IDBanner; }
            set { _IDBanner = value; }
        }
        private string _IDIBanner;

        public string IDIBanner
        {
            get { return _IDIBanner; }
            set { _IDIBanner = value; }
        }
        private int _IDTBanner;

        public int IDTBanner
        {
            get { return _IDTBanner; }
            set { _IDTBanner = value; }
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


        private string _URLImagen;

        public string URLImagen
        {
            get { return _URLImagen; }
            set { _URLImagen = value; }
        }

        public string ExtrancionImagen
        {
            get { return _ExtensionImagen; }
            set { _ExtensionImagen = value; }
        }

        private string _URLBanner;

        public string URLBanner
        {
            get { return _URLBanner; }
            set { _URLBanner = value; }
        }
        private string _TextoButton;

        public string TextoButton
        {
            get { return _TextoButton; }
            set { _TextoButton = value; }
        }

        private string _Extension;

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        private string _TextoInicial;

        public string TextoInicial
        {
            get { return _TextoInicial; }
            set { _TextoInicial = value; }
        }

        private string _TextoPrincipal;

        public string TextoPrincipal
        {
            get { return _TextoPrincipal; }
            set { _TextoPrincipal = value; }
        }

        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }
        private bool _VerMas;

        public bool  VerMas
        {
            get { return _VerMas; }
            set { _VerMas= value; }
        }
      

        private bool _CambioImagen;

        public bool CambioImagen
        {
            get { return _CambioImagen; }
            set { _CambioImagen = value; }
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

         public string _ExtensionImagen { get; set; }

        public bool CambiarImagen { get; set; }

    }
}
