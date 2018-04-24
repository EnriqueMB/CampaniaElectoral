using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Notificacion
    {
        public CH_Notificacion()
        {
            _DatosAuxColab = new CH_Colaborador();
        }

        private string _IDNotificacion;

        public string IDNotificacion
        {
            get { return _IDNotificacion; }
            set { _IDNotificacion = value; }
        }

        private string _NombreNotif;

        public string NombreNotif
        {
            get { return _NombreNotif; }
            set { _NombreNotif = value; }
        }

        private string _TituloNotif;

        public string TituloNotif
        {
            get { return _TituloNotif; }
            set { _TituloNotif = value; }
        }

        private string _Texto;

        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }

        private bool _Todos;

        public bool Todos
        {
            get { return _Todos; }
            set { _Todos = value; }
        }

        private DataTable _TablaColaboradores;

        public DataTable TablaColaboradores
        {
            get { return _TablaColaboradores; }
            set { _TablaColaboradores = value; }
        }


        private CH_Colaborador _DatosAuxColab;

        public CH_Colaborador DatosAuxColab
        {
            get { return _DatosAuxColab; }
            set { _DatosAuxColab = value; }
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

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

    }
}
