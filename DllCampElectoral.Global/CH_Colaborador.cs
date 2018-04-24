using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Colaborador
    {
        public CH_Colaborador()
        {
            ListaUsers = new List<RR_TipoUsuarios>();
            ListaColaboradores = new List<CH_Colaborador>();
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
        private int _IDTipoUsuario;

        public int IDTipoUsuario
        {
            get { return _IDTipoUsuario; }
            set { _IDTipoUsuario = value; }
        }
        private bool _Seleccionado;

        public bool Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        private List<RR_TipoUsuarios> _ListaUsers;
        public List<RR_TipoUsuarios> ListaUsers
        {
            get { return _ListaUsers; }
            set { _ListaUsers = value; }
        }

        private List<CH_Colaborador> _ListaColaboradores;

        public List<CH_Colaborador> ListaColaboradores
        {
            get { return _ListaColaboradores; }
            set { _ListaColaboradores = value; }
        }
    }
}
