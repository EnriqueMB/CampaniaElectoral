using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class WN_Usuario
    {
        private string _image;

        public string Imagen
        {
            get { return _image; }
            set { _image = value; }
        }

        private string _IDUsuario;

        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellidos;

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        private string _foto;

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        
        private WN_Permisos[] _modulosUsuario;
        public WN_Permisos[] ModulosUsuario
        {
            get { return _modulosUsuario; }
            set { _modulosUsuario = value; }
        }

        private WN_Permisos[] _menuPrincipalUsuario;

        public WN_Permisos[] MenuPrincipalUsuario
        {
            get { return _menuPrincipalUsuario; }
            set { _menuPrincipalUsuario = value; }
        }

        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private int _opcion;

        public int Opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        private List<WN_Permisos> _modulosPadres;
        public List<WN_Permisos> ModulosPadres
        {
            get { return _modulosPadres; }
            set { _modulosPadres = value; }
        }

        private List<WN_Permisos> _modulosHijos;

        public List<WN_Permisos> ModulosHijos
        {
            get { return _modulosHijos; }
            set { _modulosHijos = value; }
        }
        private List<WN_Permisos> _modulosNietos;

        public List<WN_Permisos> ModuloNietos
        {
            get { return _modulosNietos; }
            set { _modulosNietos = value; }
        }

        private bool _band;

        public bool Band
        {
            get { return _band; }
            set { _band = value; }
        }

        private int _IDMunicipio;

        public int IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }

        private int _IDEstado;

        public int IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }

    }
}
