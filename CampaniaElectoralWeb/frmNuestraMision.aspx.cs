using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class frmNuestraMision : System.Web.UI.Page
    {
        public EM_MisionVision Datos;
        protected void Page_Load(object sender, EventArgs e)
        {
            EM_MisionVision DatosAux = new EM_MisionVision { Conexion = Comun.Conexion};
            EM_MisionVisionNegocio MN = new EM_MisionVisionNegocio();
            Datos = MN.MisionWeb(DatosAux);
        }
    }
}