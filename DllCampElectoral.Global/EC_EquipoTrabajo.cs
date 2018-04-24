using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
   public class EC_EquipoTrabajo
    {
        /*A.[nombreCompleto] AS nombre,
			A.[paginaWeb],
			A.[puesto],
			A.[urlImagen],
			A.[cuenta1],
			A.[cuenta2],
			A.[cuenta3],
			A.[cuenta4],
			A.[cuenta5],*/

        private string _idEquipoTrabajo;
        public string idEquipoTrabajo
        {
            get { return _idEquipoTrabajo; }
            set { _idEquipoTrabajo = value; }
        }

        private DateTime _fecha;
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        private string _nombreCompleto;

        public string nombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }
        private string _paginaWeb;

        public string  paginaWeb
        {
            get { return _paginaWeb; }
            set { _paginaWeb = value; }
        }

        private string _puesto;

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; }
        }
        private string _urlImagen;

        public string urlImagen
        {
            get { return _urlImagen; }
            set { _urlImagen = value; }
        }
        private string _ctaFB;

        public string ctaFB
        {
            get { return _ctaFB; }
            set { _ctaFB = value; }
        }
        private string _ctaTW;

        public string ctaTW
        {
            get { return _ctaTW; }
            set { _ctaTW = value; }
        }
        private string _ctaGoog;

        public  string ctaGoog
        {
            get { return _ctaGoog; }
            set { _ctaGoog = value; }
        }

        private string _ctaInsta;

        public string ctaInsta 
        {
            get { return _ctaInsta; }
            set { _ctaInsta = value; }
        }
        private string _ctaPint;

        public string ctaPint
        {
            get { return _ctaPint; }
            set { _ctaPint = value; }
        }
    
        private string _facebook;

        public string facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }
        private string _twitter;

        public string twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }
        private string _google;

        public string google
        {
            get { return _google; }
            set { _google = value; }
        }
        private string _instagram;

        public string instagram
        {
            get { return _instagram; }
            set { _instagram = value; }
        }

        private string _pinterest;

        public string pinterest
        {
            get { return _pinterest; }
            set { _pinterest = value; }
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
        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }
    }
}
