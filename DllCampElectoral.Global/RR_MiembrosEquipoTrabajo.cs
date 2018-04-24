using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_MiembrosEquipoTrabajo
    {
        private string _IDMiembroEquipo;
        public string IDMiembroEquipo
        {
            get { return _IDMiembroEquipo; }
            set { _IDMiembroEquipo = value; }
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

        private string _Puesto;
        public string Puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }

        private string _PagWeb;
        public string PagWeb
        {
            get { return _PagWeb; }
            set { _PagWeb = value; }
        }

        private bool _IsFb;
        public bool IsFb
        {
            get { return _IsFb; }
            set { _IsFb = value; }
        }

        private bool _IsTw;
        public bool IsTw
        {
            get { return _IsTw; }
            set { _IsTw = value; }
        }

        private bool _IsInst;
        public bool IsInst
        {
            get { return _IsInst; }
            set { _IsInst = value; }
        }

        private bool _IsGoo;
        public bool IsGoo
        {
            get { return _IsGoo; }
            set { _IsGoo = value; }
        }

        private bool _IsPrin;
        public bool IsPrin
        {
            get { return _IsPrin; }
            set { _IsPrin = value; }
        }

        private string _Fb;
        public string Fb
        {
            get { return _Fb; }
            set { _Fb = value; }
        }

        private string _Tw;
        public string Tw
        {
            get { return _Tw; }
            set { _Tw = value; }
        }

        private string _Ins;
        public string Ins
        {
            get { return _Ins; }
            set { _Ins = value; }
        }

        private string _Goo;
        public string Goo
        {
            get { return _Goo; }
            set { _Goo = value; }
        }

        private string _Prin;
        public string Print
        {
            get { return _Prin; }
            set { _Prin = value; }
        }

        private string _UrlImagen;
        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }

        private bool _ImagenGuardada;
        public bool ImagenGuardada
        {
            get { return _ImagenGuardada; }
            set { _ImagenGuardada = value; }
        }

        private string _ExtensionImagen;
        public string ExtrancionImagen
        {
            get { return _ExtensionImagen; }
            set { _ExtensionImagen = value; }
        }

        private bool _CambiarImagen;
        public bool CambiarImagen
        {
            get { return _CambiarImagen; }
            set { _CambiarImagen = value; }
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
