using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class WN_Permisos
    {

        private string _iconos;

        public string Iconos
        {
            get { return _iconos; }
            set { _iconos = value; }
        }

        private string _idmodulo;

        public string IdModulo
        {
            get { return _idmodulo; }
            set { _idmodulo = value; }
        }

        private int _idTipo;

        public int IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }

        private string _IdPadre;

        public string IDPadre
        {
            get { return _IdPadre; }
            set { _IdPadre = value; }
        }

        //private int _IdPadre;

        //public int IDPadre
        //{
        //    get { return _IdPadre; }
        //    set { _IdPadre = value; }
        //}
        
        private string _NombreModulo;

        public string NombreModulo
        {
            get { return _NombreModulo; }
            set { _NombreModulo = value; }
        }
        
        private string _frmModulo;

        public string FrmModulo
        {
            get { return _frmModulo; }
            set { _frmModulo = value; }
        }

        private int _orden;

        public int Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

        private int _opc;

        public int Opc
        {
            get { return _opc; }
            set { _opc = value; }
        }
        private int _ordenPadre;

        public int OrdenPadre
        {
            get { return _ordenPadre; }
            set { _ordenPadre = value; }
        }

        private int _ordenHijo;

        public int OrdenHijo
        {
            get { return _ordenHijo; }
            set { _ordenHijo = value; }
        }
        private int _nieto;

        public int Nieto
        {
            get { return _nieto; }
            set { _nieto = value; }
        }
    }
}
