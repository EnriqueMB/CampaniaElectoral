using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_CatColaborador
    {
        private string _padre;

        public string Padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        private string _suplente;

        public string Sumplente
        {
            get { return _suplente; }
            set { _suplente = value; }
        }

        private int _casilla;

        public int Casilla
        {
            get { return _casilla; }
            set { _casilla = value; }
        }




        private string _IDColaborador;

        public string IDColaborador
        {
            get { return _IDColaborador; }
            set { _IDColaborador = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _ApMaterno;

        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; }
        }
        private string _ApPaterno;

        public string ApPaterno
        {
            get { return _ApPaterno; }
            set { _ApPaterno = value; }
        }
        private string _Correo;

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private DateTime _FechaNac;

        public DateTime FechaNac
        {
            get { return _FechaNac; }
            set { _FechaNac = value; }
        }
        private int _IDGenero;

        public int IDGenero
        {
            get { return _IDGenero; }
            set { _IDGenero = value; }
        }
        private string _CodigoPostal;

        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }
        private int _IDTipoUsu;

        public int IDTipoUsu
        {
            get { return _IDTipoUsu; }
            set { _IDTipoUsu = value; }
        }
        private string _UrlImagen;

        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }
        private string _ColorPerfil;

        public string ColorPerfil
        {
            get { return _ColorPerfil; }
            set { _ColorPerfil = value; }
        }
        private string _Cuidad;

        public string Cuidad
        {
            get { return _Cuidad; }
            set { _Cuidad = value; }
        }
        
        private bool _ImagenGuardada;

        public bool ImagenGuardada
        {
            get { return _ImagenGuardada; }
            set { _ImagenGuardada = value; }
        }

        private string _ExtensionImagen;

        public string ExtrancionImagen
        {
            get { return _ExtensionImagen; }
            set { _ExtensionImagen = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private bool _CambiarImagen;

        public bool CambiarImagen
        {
            get { return _CambiarImagen; }
            set { _CambiarImagen = value; }
        }
        private string _TipoUsuario;

        public string TipoUsuario
        {
            get { return _TipoUsuario; }
            set { _TipoUsuario = value; }
        }

        private string _IDColadoradorAux;

        public string IDColaboradorAux
        {
            get { return _IDColadoradorAux; }
            set { _IDColadoradorAux = value; }
        }

        private int _id_genero;

        public int id_genero
        {
            get { return _id_genero; }
            set { _id_genero = value; }
        }
        private bool _voto;

        public bool voto
        {
            get { return _voto; }
            set { _voto = value; }
        }
        private bool _imgGuardada;

        public bool imgGuardada
        {
            get { return _imgGuardada; }
            set { _imgGuardada = value; }
        }

        private string _IDPoligono;

        public string IDPoligono
        {
            get { return _IDPoligono; }
            set { _IDPoligono = value; }
        }

        private string _NumeroExt;

        public string NumeroExt
        {
            get { return _NumeroExt; }
            set { _NumeroExt = value; }
        }

        private string _NumeroInt;
        public string NumeroInt
        {
            get { return _NumeroInt; }
            set { _NumeroInt = value; }
        }
        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        private string _Colonia;
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }
        private string _Imagen;

        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        private int _Estado;
        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private int _Municipio;
        public int Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }
        private string _ClaveElector;

        public string ClaveElector
        {
            get { return _ClaveElector; }
            set { _ClaveElector = value; }
        }
        #region DatosDeControl
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
