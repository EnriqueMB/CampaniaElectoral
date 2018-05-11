using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

namespace CampaniaElectoralEstadistica
{
    public partial class frmConteoPrep : System.Web.UI.Page
    {
        public CH_Conteo ConteoPagina = new CH_Conteo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            CH_Conteo Conteo = new CH_Conteo();
            Conteo.Conexion = Comun.Conexion;
            CH_ConteoNegocio ConteoN = new CH_ConteoNegocio();
            ConteoN.GraficaDeConteoPrep(Conteo);
            ConteoPagina = Conteo;
        }
    }
}