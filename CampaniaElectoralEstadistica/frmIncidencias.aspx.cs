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
    public partial class frmIncidencias : System.Web.UI.Page
    {
        public ER_Incidencias Datos = new ER_Incidencias();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ER_Incidencias DatosAux = new ER_Incidencias { Conexion = Comun.Conexion };
                ER_IncidenciasNegocio IN = new ER_IncidenciasNegocio();
                IN.ObtenerIncidencias(DatosAux);
                if (DatosAux.Completado)
                {
                    Datos = DatosAux;
                   
                }
                else
                {
                    //Ocurrió un error
                    Response.Redirect("frmCapturas.aspx?error=" + "Error al cargar los datos&nError=1");
                }

            }
        }
    }
}