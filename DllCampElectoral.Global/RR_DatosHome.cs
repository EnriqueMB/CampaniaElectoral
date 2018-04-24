using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_DatosHome
    {
        private int _IDHomeText;
        public int IDHomeText
        {
            get { return _IDHomeText; }
            set { _IDHomeText = value; }
        }

        private string _TituloHacemos;
        public string TituloHacemos
        {
            get { return _TituloHacemos; }
            set { _TituloHacemos = value; }
        }           

        private string _DescHacemos;
        public string DescHacemos
        {
            get { return _DescHacemos; }
            set { _DescHacemos = value; }
        }

        private string _TituloAfiliate;
        public string TituloAfiliate
        {
            get { return _TituloAfiliate; }
            set { _TituloAfiliate = value; }
        }

        private string _DescAfiliate;
        public string DescAfiliate
        {
            get { return _DescAfiliate; }
            set { _DescAfiliate = value; }
        }

        private string _TituloProxEvent;
        public string TituloProxEvent
        {
            get { return _TituloProxEvent; }
            set { _TituloProxEvent = value; }
        }

        private string _DescProxEvent;
        public string DescProxEvent
        {
            get { return _DescProxEvent; }
            set { _DescProxEvent = value; }
        }

        private string _TituloEquipoTrabajo;
        public string TituloEquipoTrabajo
        {
            get { return _TituloEquipoTrabajo; }
            set { _TituloEquipoTrabajo = value; }
        }

        private string _DescEquipoTrabajo;
        public string DescEquipoTrabajo
        {
            get { return _DescEquipoTrabajo; }
            set { _DescEquipoTrabajo = value; }
        }

        private string _TituloBlog;
        public string TituloBlog
        {
            get { return _TituloBlog; }
            set { _TituloBlog = value; }
        }

        private string _DescBlog;
        public string DescBlog
        {
            get { return _DescBlog; }
            set { _DescBlog = value; }
        }

        private string _TituloContactanos;
        public string TituloContactanos
        {
            get { return _TituloContactanos; }
            set { _TituloContactanos = value; }
        }

        private string _Afiliate;

        public string Afiliate
        {
            get { return _Afiliate; }
            set { _Afiliate = value; }
        }
        

        private string _Contactanos;
        public string Contactanos
        {
            get { return _Contactanos; }
            set { _Contactanos = value; }
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
