using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EM_Gastos
    {

        private string _IDGastos;

        public string IDGastos
        {
            get { return _IDGastos; }
            set { _IDGastos = value; }
        }
        private int _IDMotivo;

        public int IDMotivo
        {
            get { return _IDMotivo; }
            set { _IDMotivo = value; }
        }
        private int _IDSubMotivo;

        public int IDSubMotivo
        {
            get { return _IDSubMotivo; }
            set { _IDSubMotivo = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private string _IDResponsable;

        public string IDResponsable
        {
            get { return _IDResponsable; }
            set { _IDResponsable = value; }
        }
        private string _NombreResponsable;

        public string NombreResponsable
        {
            get { return _NombreResponsable; }
            set { _NombreResponsable = value; }
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

        private DataTable _TablaDatosEncuesta;
        public DataTable TablaDatosEncuesta
        {
            get { return _TablaDatosEncuesta; }
            set { _TablaDatosEncuesta = value; }
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
