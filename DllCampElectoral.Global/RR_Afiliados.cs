using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_Afiliados
    {
        private int _opcion;

        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }


        private string _IDAfiliado;
        public string IDAfiliado
        {
            get { return _IDAfiliado; }
            set { _IDAfiliado = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _ApePat;
        public string ApePat
        {
            get { return _ApePat; }
            set { _ApePat = value; }
        }

        private string _ApeMat;
        public string ApeMat
        {
            get { return _ApeMat; }
            set { _ApeMat = value; }
        }

        private DateTime _FechaAfiliacion = DateTime.Now;
        public DateTime FechaAfiliacion
        {
            get { return _FechaAfiliacion; }
            set { _FechaAfiliacion = value; }
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

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
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

        private string _Colonia;
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }

        private int _CodigoPostal;
        public int CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }

        private string _ClaveElector;
        public string ClaveElector
        {
            get { return _ClaveElector; }
            set { _ClaveElector = value; }
        }

        private string _CorreoElect;
        public string CorreoElect
        {
            get { return _CorreoElect; }
            set { _CorreoElect = value; }
        }

        private string _Celular;
        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        private int _Genero;
        public int Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private bool _Ratificacion;
        public bool Ratificacion
        {
            get { return _Ratificacion; }
            set { _Ratificacion = value; }
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

        private DateTime _Fecha1;

        public DateTime Fecha1
        {
            get { return _Fecha1; }
            set { _Fecha1 = value; }
        }
        private DateTime _Fecha2;

        public DateTime Fecha2
        {
            get { return _Fecha2; }
            set { _Fecha2 = value; }
        }
        private int _CountAfiliado;

        public int CountAfiliado
        {
            get { return _CountAfiliado; }
            set { _CountAfiliado = value; }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private string _CredencialFrente;
        public string CredencialFrente
        {
            get { return _CredencialFrente; }
            set { _CredencialFrente = value; }
        }
        private string _CredencialPosterior;
        public string CredencialPosterior
        {
            get { return _CredencialPosterior; }
            set { _CredencialPosterior = value; }
        }
        private int _Seccion;

        public int Seccion
        {
            get { return _Seccion; }
            set { _Seccion = value; }
        }
        private string _IDPoligono;

        public string IDPoligono
        {
            get { return _IDPoligono; }
            set { _IDPoligono = value; }
        }
        private string _IDColaborador;
        public string IDColaborador
        {
            get { return _IDColaborador; }
            set { _IDColaborador = value; }
        }
        private string _ImagenVoto;
        public string ImagenVoto
        {
            get { return _ImagenVoto; }
            set { _ImagenVoto = value; }
        }
    }
}
