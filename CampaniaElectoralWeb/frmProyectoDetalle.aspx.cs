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
    public partial class frmProyectoDetalle : System.Web.UI.Page
    {
        public List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
        public List<GM_PlanCampania> ListaB = new List<GM_PlanCampania>();
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
                            GM_PlanCampania Datos = new GM_PlanCampania { Conexion = Comun.Conexion, IDPElectoral = ID };
                            GM_PlanCampaniaNegocio AWN = new GM_PlanCampaniaNegocio();
                            Lista = AWN.ObtenerListCampania1(Datos);
                            CargarProyectos();
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
        public void CargarProyectos()
        {
            GM_PlanCampania Datos = new GM_PlanCampania { Conexion = Comun.Conexion };
            GM_PlanCampaniaNegocio PCN = new GM_PlanCampaniaNegocio();
            ListaB = PCN.ObtenerListCampaniaMas(Datos);
        }
    }
}