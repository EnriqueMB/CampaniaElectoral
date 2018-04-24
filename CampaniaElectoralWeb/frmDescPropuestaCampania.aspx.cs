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
    public partial class frmDescPropuestaCampania : System.Web.UI.Page
    {
        public List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            RR_PropuestaCamapaña Datos = new RR_PropuestaCamapaña { Conexion = Comun.Conexion, IDPropuesta = ID };
                            RR_AdministradorWebNegocio AWN = new RR_AdministradorWebNegocio();
                            Lista = AWN.ObtenerPropuestaDetallada(Datos);                            
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {                
            }
        }       
    }
}