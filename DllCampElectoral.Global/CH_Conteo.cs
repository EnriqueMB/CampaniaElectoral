using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class CH_Conteo
    {
        public CH_Conteo()
        {
            _ListaPartidos = new List<CH_PartidoPolitico>();
        }

        private string _IDCaptura;

        public string IDCaptura
        {
            get { return _IDCaptura; }
            set { _IDCaptura = value; }
        }

        private string _SFechaHora;

        public string SFechaHora
        {
            get { return _SFechaHora; }
            set { _SFechaHora = value; }
        }

        private DateTime _FechaHora;

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
        }


        private string _Comentarios;

        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private string _Colaborador;

        public string Colaborador
        {
            get { return _Colaborador; }
            set { _Colaborador = value; }
        }

        private string _Casilla;

        public string Casilla
        {
            get { return _Casilla; }
            set { _Casilla = value; }
        }

        private string _UrlImagen;

        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }

        private List<CH_PartidoPolitico> _ListaPartidos;

        public List<CH_PartidoPolitico> ListaPartidos
        {
            get { return _ListaPartidos; }
            set { _ListaPartidos = value; }
        }
        
        private string _Conexion;
        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private bool _NuevoRegistro;
        public bool NuevoRegistro
        {
            get { return _NuevoRegistro; }
            set { _NuevoRegistro = value; }
        }

        private string _IDUsuario;
        public string IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private bool _Completado;
        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private int _Resultado;
        public int Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private int _CasillaGanada;

        public int CasillaGanada
        {
            get { return _CasillaGanada; }
            set { _CasillaGanada = value; }
        }

        private int _CasillaPerdida;

        public int CasillaPerdida
        {
            get { return _CasillaPerdida; }
            set { _CasillaPerdida = value; }
        }

        private int _CantidadVoto;

        public int CantidadVoto
        {
            get { return _CantidadVoto; }
            set { _CantidadVoto = value; }
        }

        private string _SiglasPartido;

        public string SiglasPartido
        {
            get { return _SiglasPartido; }
            set { _SiglasPartido = value; }
        }

        private List<CH_Conteo> _ListaConteo;

        public List<CH_Conteo> ListaConteo
        {
            get { return _ListaConteo; }
            set { _ListaConteo = value; }
        }

    }
}
