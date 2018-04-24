using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class WN_Configuracion
    {

        private int _cantidadCasilla;

        public int CantidadCasilla
        {
            get { return _cantidadCasilla; }
            set { _cantidadCasilla = value; }
        }

        private int _cantidadOperador;

        public int CantidadOperador
        {
            get { return _cantidadOperador; }
            set { _cantidadOperador = value; }
        }

        private int _cantidadAfiliados;

        public int CantidadAfiliados
        {
            get { return _cantidadAfiliados; }
            set { _cantidadAfiliados = value; }
        }


        private DateTime _fechaElecciones;

        public DateTime FechaElecciones
        {
            get { return _fechaElecciones; }
            set { _fechaElecciones = value; }
        }


        private int _estado;

        public int Estaod
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int _municipio;

        public int Municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
        }


        private string _latitud;

        public string Latiud
        {
            get { return _latitud; }
            set { _latitud = value; }
        }

        private string _longitud;

        public string Longitud
        {
            get { return _longitud; }
            set { _longitud = value; }
        }



        private string _widget01;

        public string Widget01
        {
            get { return _widget01; }
            set { _widget01 = value; }
        }
        private string _widget02;

        public string Widget02
        {
            get { return _widget02; }
            set { _widget02= value; }
        }
        private string _widget03;

        public string Widget03
        {
            get { return _widget03; }
            set { _widget03 = value; }
        }

        
    }
}
