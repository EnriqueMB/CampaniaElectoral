using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Negocio;
using DllCampElectoral.Global;

namespace CampaniaElectoralEstadistica
{
    public partial class frmObjetivosElecciones : System.Web.UI.Page
    {
        private FG_EstadisticosVotos FG = new FG_EstadisticosVotos();
        private FG_EstadisticosVotosNegocio FG_Negocio = new FG_EstadisticosVotosNegocio();
        protected List<FG_EstadisticosVotos_MetaXHora> listaMetasXHora;

        protected void Page_Load(object sender, EventArgs e)
        {
            FG.Conexion = Comun.Conexion;
            CargarMetaVotosGeneral();
            CargarTotalVotosRealizados();
            CargarTotalVotosFaltantes();
            CargarGraficaAvanceGeneralVotos();
            CargarMetasXHora();
        }

        #region Métodos
        private void CargarMetasXHora()
        {
            listaMetasXHora = FG_Negocio.ObtenerListaMetasXHora(FG);
        }
        private void CargarGraficaAvanceGeneralVotos()
        {
            lblPorcentajeAvanceGeneralVotos.Text = FG.CalcularPorcentajeAvanceGeneralVotos().ToString();
            divAvanceGeneralVotos.Attributes["ui-options"] =
                "{" +
                    "percent: " + FG.CalcularPorcentajeAvanceGeneralVotos() + "," +
                    "lineWidth: 10," +
                    "trackColor: '#e8eff0'," +
                    "barColor: '#27c24c'," +
                    "caleColor: '#e8eff0'," +
                    "size: 188," +
                    "lineCap: 'butt'," +
                    "animate: 1000" +
                "}";
        }
        private void CargarMetaVotosGeneral()
        {
            FG.MetaVotosGeneral = FG_Negocio.ObtenerMetaGeneral(FG);
            lblMetaGeneral.Text = FG.MetaVotosGeneral.ToString();
        }
        private void CargarTotalVotosRealizados()
        {
            FG.TotalVotosRealizados = FG_Negocio.ObtenerTotalVotosRealiazados(FG);
            lblTotalVotosRealizados.Text = FG.TotalVotosRealizados.ToString();
        }
        private void CargarTotalVotosFaltantes()
        {
            lblTotalVotosFaltantes.Text = FG.ObtenerTotalVotosFaltantes().ToString();
        }
        #endregion

    }
}