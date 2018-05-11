using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralEstadistica
{
    public partial class frmObjetivosAfiliados : System.Web.UI.Page
    {
        public EstadisticosAfiliados Datos = new EstadisticosAfiliados();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EstadisticosAfiliados_Negocio EstNeg = new EstadisticosAfiliados_Negocio();
                    Datos = EstNeg.ObtenerEstadisticosAfiliados(Comun.Conexion);
                    if(!Datos.Completado)
                    {
                        Response.Redirect("ErrorPage.aspx?Message=No_se_pudo_cargar_la_información.");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?Message=" + ex.Message);
            }
        }
    }
}