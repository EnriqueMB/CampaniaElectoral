using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_InformacionCandidato
    {
        private string _IDCandidato;
        public string IDCandidato
        {
            get { return _IDCandidato; }
            set { _IDCandidato = value; }
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

        private int _PartidoPolitico;
        public int PartidoPolitico
        {
            get { return _PartidoPolitico; }
            set { _PartidoPolitico = value; }
        }

        private string _NombrePartido;
        public string NombrePartido
        {
            get { return _NombrePartido; }
            set { _NombrePartido = value; }
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
