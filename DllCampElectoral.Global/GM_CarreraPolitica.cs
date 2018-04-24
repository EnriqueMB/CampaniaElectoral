using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class GM_CarreraPolitica
    {
         private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private string _IDCarreraPolitica;

        public string IDCarreraPolitica
        {
            get { return _IDCarreraPolitica; }
            set { _IDCarreraPolitica = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private DateTime _FechaRealizado;

        public DateTime FechaRealizado
        {
            get { return _FechaRealizado; }
            set { _FechaRealizado = value; }
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


        private string _URLCaPo;

        public string URLCaPo
        {
            get { return _URLCaPo; }
            set { _URLCaPo = value; }
        }
        
        private string _Extension;

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
                        
        private bool _NuevoRegistro;

        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
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

