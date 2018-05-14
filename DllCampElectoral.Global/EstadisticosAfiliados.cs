using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class EstadisticosAfiliados
    {

        private DateTime _FechaUltimoAfiliado;

        public DateTime FechaUltimoAfiliado
        {
            get { return _FechaUltimoAfiliado; }
            set { _FechaUltimoAfiliado = value; }
        }

        public string FechaUltimoAfiliadoString
        {
            get
            {
                return _FechaUltimoAfiliado == DateTime.MinValue ? "SIN DATOS" : _FechaUltimoAfiliado.ToString("dd/MM/yyyy");
            }
        }
        
        private int _TiempoTranscurridoUAHoras;

        public int TiempoTranscurridoUAHoras
        {
            get { return _TiempoTranscurridoUAHoras; }
            set { _TiempoTranscurridoUAHoras = value; }
        }

        private int _PorcentajeAfiliados;

        public int PorcentajeAfiliados
        {
            get { return _PorcentajeAfiliados; }
            set { _PorcentajeAfiliados = value; }
        }

        private int _PromedioInscripcionXDia;

        public int PromedioInscripcionXDia
        {
            get { return _PromedioInscripcionXDia; }
            set { _PromedioInscripcionXDia = value; }
        }

        private int _MetaCampania;

        public int MetaCampania
        {
            get { return _MetaCampania; }
            set { _MetaCampania = value; }
        }

        private int _AfiliadosInscritos;

        public int AfiliadosInscritos
        {
            get { return _AfiliadosInscritos; }
            set { _AfiliadosInscritos = value; }
        }

        private int _AfiliadosValidos;

        public int AfiliadosValidos
        {
            get { return _AfiliadosValidos; }
            set { _AfiliadosValidos = value; }
        }
        private int _AfiliadosRechazados;

        public int AfiliadosRechazados
        {
            get { return _AfiliadosRechazados; }
            set { _AfiliadosRechazados = value; }
        }

        private int _SeccionesConcluidas;

        public int SeccionesConcluidas
        {
            get { return _SeccionesConcluidas; }
            set { _SeccionesConcluidas = value; }
        }

        private int _SeccionesFaltantes;

        public int SeccionesFaltantes
        {
            get { return _SeccionesFaltantes; }
            set { _SeccionesFaltantes = value; }
        }

        private int _PorcentajeAvanceSeccion;

        public int PorcentajeAvanceSeccion
        {
            get { return _PorcentajeAvanceSeccion; }
            set { _PorcentajeAvanceSeccion = value; }
        }

        private List<EstadisticosRepresentantesSeccion> _Lista;

        public List<EstadisticosRepresentantesSeccion> Lista
        {
            get { return _Lista; }
            set { _Lista = value; }
        }

        private DataTable _TablaSecciones;

        public DataTable TablaSecciones
        {
            get { return _TablaSecciones; }
            set { _TablaSecciones = value; }
        }

        public string ObtenerJsonSecciones()
        {
            return JsonConvert.SerializeObject(_TablaSecciones);
        }

        private int _TipoLista;

        public int TipoLista
        {
            get { return _TipoLista; }
            set { _TipoLista = value; }
        }


        private int _Start;

        public int Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        private int _Length;

        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        private string _SearchValue;

        public string SearchValue
        {
            get { return _SearchValue; }
            set { _SearchValue = value; }
        }

        private int _OrderBy;

        public int OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        private string _OrderDirection;

        public string OrderDirection
        {
            get { return _OrderDirection; }
            set { _OrderDirection = value; }
        }

        private int _RecordTotal;

        public int RecordTotal
        {
            get { return _RecordTotal; }
            set { _RecordTotal = value; }
        }

        private int _RecordFilter;

        public int RecordFilter
        {
            get { return _RecordFilter; }
            set { _RecordFilter = value; }
        }

        private string _SeccionesMayorAvance;

        public string SeccionesMayorAvance
        {
            get { return _SeccionesMayorAvance; }
            set { _SeccionesMayorAvance = value; }
        }

        private string _SeccionesMenorAvance;

        public string SeccionesMenorAvance
        {
            get { return _SeccionesMenorAvance; }
            set { _SeccionesMenorAvance = value; }
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


    }

    public class EstadisticosRepresentantesSeccion
    {
        public int Seccion { get; set; }
        public string Nombre { get; set; }
        public int Avance { get; set; }
        public string CssClass { get; set; }
        public string Imagen { get; set; }
    }
}
