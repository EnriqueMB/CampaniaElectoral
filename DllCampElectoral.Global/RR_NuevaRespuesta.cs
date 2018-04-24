using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_NuevaRespuesta
    {
        private string _IDRespuesta;
        public string IDRespuesta
        {
            get { return _IDRespuesta; }
            set { _IDRespuesta = value; }
        }

        private string _IDPregunta;
        public string IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }

        private string _IndiceRespuesta;
        public string IndiceRespuesta
        {
            get { return _IndiceRespuesta; }
            set { _IndiceRespuesta = value; }
        }

        private string _ClvRespuesta;

        public string ClvRespuesta
        {
            get { return _ClvRespuesta; }
            set { _ClvRespuesta = value; }
        }
        
        private string _Respuesta;
        public string Respuesta
        {
            get { return _Respuesta; }
            set { _Respuesta = value; }
        }

        private int _Orden;

        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }
        
        private bool _EsMapa;
        public bool EsMapa
        {
            get { return _EsMapa; }
            set { _EsMapa = value; }
        }

        private string _IDEncuesta;

        public string IDEncuesta
        {
            get { return _IDEncuesta; }
            set { _IDEncuesta = value; }
        }

        private int _IDTipoPre;

        public int IDTipoPre
        {
            get { return _IDTipoPre; }
            set { _IDTipoPre = value; }
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
