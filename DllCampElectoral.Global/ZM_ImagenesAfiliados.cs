using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class ZM_ImagenesAfiliados
    {
        private int _option;
        public int Option
        {
            get { return _option; }
            set { _option = value; }
        }

        private string _idAfiliado;
        public string IdAfiliado
        {
            get { return _idAfiliado; }
            set { _idAfiliado = value; }
        }

        private string _idImagenAfiliado;
        public string IdImagenAfiliado
        {
            get { return _idImagenAfiliado; }
            set { _idImagenAfiliado = value; }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private DateTime _fechaImagen;
        public DateTime FechaImagen
        {
            get { return _fechaImagen; }
            set { _fechaImagen = value; }
        }

        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private bool _completado;
        public bool Completado
        {
            get { return _completado; }
            set { _completado = value; }
        }

        private int _resultado;
        public int Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }


        public string getImagen()
        {
            return Imagen;
        }
    }
}
