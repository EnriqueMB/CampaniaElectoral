using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class GM_VideosLoad
    {
        private int _IDE;
        public int IDE
        {
            get { return _IDE;}
            set { _IDE = value; }
        }
        
        
        private string _IDVideo;
        public string IDVideo
        {
            get { return _IDVideo; }
            set { _IDVideo = value; }
        }

        private string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        private string _Alt;
        public string Alt
        {
            get { return _Alt; }
            set { _Alt = value; }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Link;
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
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

        private bool _NuevoVideo;
        public bool NuevoVideo
        {
            get { return _NuevoVideo; }
            set { _NuevoVideo = value; }
        }

    }
}
