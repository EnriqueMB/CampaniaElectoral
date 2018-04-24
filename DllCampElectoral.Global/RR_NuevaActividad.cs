using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class RR_NuevaActividad
    {
        private string _IDNuevaAct;
        public string IDNuevaAct
        {
            get { return _IDNuevaAct; }
            set { _IDNuevaAct = value; }
        }

        private string _NombreActividad;
        public string NombreActividad
        {
            get { return _NombreActividad; }
            set { _NombreActividad = value; }
        }

        private int _IDTipoActividadEvento;
        public int IDTipoActividadEvento
        {
            get { return _IDTipoActividadEvento; }
            set { _IDTipoActividadEvento = value; }
        }

        private string _EncargadoActividad;
        public string EncargadoActividad
        {
            get { return _EncargadoActividad; }
            set { _EncargadoActividad = value; }
        }

        private DateTime _FechaInicio;
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        private string _HoraInicio;
        public string HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        private DateTime _FechaTermino;
        public DateTime FechaTermino
        {
            get { return _FechaTermino; }
            set { _FechaTermino = value; }
        }

        private string _HoraTermino;
        public string HoraTermino
        {
            get { return _HoraTermino; }
            set { _HoraTermino = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private decimal _MetaEstablecida;
        public decimal MetaEstablecida
        {
            get { return _MetaEstablecida; }
            set { _MetaEstablecida = value; }
        }

        private string _MensajeEncargado;
        public string MensajeEncargado
        {
            get { return _MensajeEncargado; }
            set { _MensajeEncargado = value; }
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

        private bool _EsEvento;
        public bool EsEvento
        {
            get { return _EsEvento; }
            set { _EsEvento = value; }
        }

        private int _IDEstatusGeneral;
        public int IDEstatusGeneral
        {
            get { return _IDEstatusGeneral; }
            set { _IDEstatusGeneral = value; }
        }


        private int _IDEstatusVisto;
        public int IDEstatusVisto
        {
            get { return _IDEstatusVisto; }
            set { _IDEstatusVisto = value; }
        }

        private string _EstatusGeneral;
        public string EstatusGeneral
        {
            get { return _EstatusGeneral; }
            set { _EstatusGeneral = value; }
        }

        private string _DescEstatusGrnl;
        public string DescEstatusGrnl
        {
            get { return _DescEstatusGrnl; }
            set { _DescEstatusGrnl = value; }
        }

        private string _EstatusVisto;
        public string EstatusVisto
        {
            get { return _EstatusVisto; }
            set { _EstatusVisto = value; }
        }

        private string _DescEstatusVisto;
        public string DescEstatusVisto
        {
            get { return _DescEstatusVisto; }
            set { _DescEstatusVisto = value; }
        }
        private string _Busqueda;

        public string Busqueda
        {
            get { return _Busqueda; }
            set { _Busqueda = value; }
        }

    }
}
