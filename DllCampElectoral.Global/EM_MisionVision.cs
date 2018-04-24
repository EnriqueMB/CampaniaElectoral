using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DllCampElectoral.Global
{
    public class EM_MisionVision
    {
        private int _IDMisionVision;

        public int IDMisionVision
        {
            get { return _IDMisionVision; }
            set { _IDMisionVision = value; }
        }

        private string _Titulo;

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Mision;

        public string Mision
        {
            get { return _Mision; }
            set { _Mision = value; }
        }
        private string _TituloImagenM;

        public string TituloImagenM
        {
            get { return _TituloImagenM; }
            set { _TituloImagenM = value; }
        }
        private string _AltImagenM;

        public string AltImagenM
        {
            get { return _AltImagenM; }
            set { _AltImagenM = value; }
        }
        private string _DescImagenM;

        public string DescImagenM
        {
            get { return _DescImagenM; }
            set { _DescImagenM = value; }
        }
        private string _UrlImagenM;

        public string UrlImagenM
        {
            get { return _UrlImagenM; }
            set { _UrlImagenM = value; }
        }
        
        private string _Vision;

        public string Vision
        {
            get { return _Vision; }
            set { _Vision = value; }
        }
        private string _TituloImagenV;
        public string TituloImagenV
        {
            get { return _TituloImagenV; }
            set { _TituloImagenV = value; }
        }
        private string _AltImagenV;

        public string AltImagenV
        {
            get { return _AltImagenV; }
            set { _AltImagenV = value; }
        }
        private string _DescImagenV;

        public string DescImagenV
        {
            get { return _DescImagenV; }
            set { _DescImagenV = value; }
        }
        private string _UrlImagenV;

        public string UrlImagenV
        {
            get { return _UrlImagenV; }
            set { _UrlImagenV = value; }
        }
        private string _Valores;

        public string Valores
        {
            get { return _Valores; }
            set { _Valores = value; }
        }
        private bool _ImagenGuardada;

        public bool ImagenGuardada
        {
            get { return _ImagenGuardada; }
            set { _ImagenGuardada = value; }
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
