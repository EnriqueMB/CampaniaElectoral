using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_ModuloXTipoUsuario
    {
        private int _IDModuloXTipoU;

        public int IDModuloXTipoU
        {
            get { return _IDModuloXTipoU; }
            set { _IDModuloXTipoU = value; }
        }

        private int _IDTipoU;

        public int IDTipoU
        {
            get { return _IDTipoU; }
            set { _IDTipoU = value; }
        }

        private string _NombreTipoU;

        public string NombreTipoU
        {
            get { return _NombreTipoU; }
            set { _NombreTipoU = value; }
        }
        
        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
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
    }
}
