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
        protected List<FG_EstadisticosVotos_MensajeAvanceGeneral> listaMensajeAvanceGeneral;

        protected void Page_Load(object sender, EventArgs e)
        {
            FG.Conexion = Comun.Conexion;
            ObtenerGeneralesEstadisticosVotacion();
        }

        #region Métodos
        private void ObtenerGeneralesEstadisticosVotacion()
        {
            FG = FG_Negocio.ObtenerGeneralesEstadisticosVotacion(FG);
            CargarDatos();
        }
        private void CargarDatos()
        {
            lblMetaGeneral.Text = FG.MetaVotosGeneral.ToString();
            lblTotalVotosRealizados.Text = FG.TotalVotosRealizados.ToString();
            lblTotalVotosFaltantes.Text = FG.ObtenerTotalVotosFaltantes().ToString();
            CargarGraficaAvanceGeneralVotos();
            CargarMetasXHora();
            CargarMensajeAvanceGeneral();
        }
        private void CargarGraficaAvanceGeneralVotos()
        {
            lblPorcentajeAvanceGeneralVotos.Text = FG.PorcentajeAvanceGeneralVotos.ToString();
            divAvanceGeneralVotos.Attributes["ui-options"] =
                "{" +
                    "percent: " + FG.PorcentajeAvanceGeneralVotos.ToString().Replace(',','.') + "," +
                    "lineWidth: 10," +
                    "trackColor: '#e8eff0'," +
                    "barColor: '#27c24c'," +
                    "caleColor: '#e8eff0'," +
                    "size: 188," +
                    "lineCap: 'butt'," +
                    "animate: 1000" +
                "}";
        }
        private void CargarMetasXHora()
        {
            listaMetasXHora = FG.listaMetasXHora();
        }
        private void CargarMensajeAvanceGeneral()
        {
            listaMensajeAvanceGeneral = FG.listaMensajeAvanceGeneral();
        }
        #endregion

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}