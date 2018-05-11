using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmIncidencias : System.Web.UI.Page
    {
        public CH_ZonaRiesgo Datos = new CH_ZonaRiesgo();
        protected void Page_Load(object sender, EventArgs e)
        {
            WN_Usuario u = new WN_Usuario(); 
              u=  (WN_Usuario)Session["Usuario"];
            Datos.Conexion = Comun.Conexion;
            Datos.IDEstado = u.IDEstado;
            Datos.Estado = u.DesEstado;
            CH_ZonaRiesgoNegocio ZRN = new CH_ZonaRiesgoNegocio();
            ZRN.ObtenerCombosZonaDeRiesgo(Datos);
        }
    }
}