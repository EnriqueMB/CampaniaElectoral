using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_Notificacion
    {
        private string _IDNotificacion;

        public string IDNotificacion
        {
            get { return _IDNotificacion; }
            set { _IDNotificacion = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Texto;

        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }

        private string _Titulo;

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        
        private bool _Visto;

        public bool Visto
        {
            get { return _Visto; }
            set { _Visto = value; }
        }

        private bool _Enviar;

        public bool Enviar
        {
            get { return _Enviar; }
            set { _Enviar = value; }
        }

        private string _IDColaborador;

        public string IDColaborador
        {
            get { return _IDColaborador; }
            set { _IDColaborador = value; }
        }
    
        private string _TokenCelular;

        public string TokenCelular
        {
            get { return _TokenCelular; }
            set { _TokenCelular = value; }
        }
        private int _IDCelular;

        public int IDCelular
        {
            get { return _IDCelular; }
            set { _IDCelular = value; }
        }

        private int _Badge;

        public int Badge
        {
            get { return _Badge; }
            set { _Badge = value; }
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
