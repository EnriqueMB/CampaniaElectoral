using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_CarreraPolitica
    {
        private int _IDCarreraPolitica;
        public int IDCarreraPolitica
        {
            get { return _IDCarreraPolitica; }
            set { _IDCarreraPolitica = value; }
        }

        private string _TitutloCarreraPolitica;
        public string TituloCarreraPolitica
        {
            get { return _TitutloCarreraPolitica; }
            set { _TitutloCarreraPolitica = value; }
        }

        private string _DescripcionCarreraPol;
        public string DescripcionCarreraPol
        {
            get { return _DescripcionCarreraPol; }
            set { _DescripcionCarreraPol = value; }
        }
        
        #region Datos De Control
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
