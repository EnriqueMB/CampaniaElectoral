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
    public partial class frmDescBlog : System.Web.UI.Page
    {
        public List<RR_Blog> Lista = new List<RR_Blog>();
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
                            RR_Blog Datos = new RR_Blog { Conexion = Comun.Conexion, IDPublicacion = ID };
                            RR_AdministradorWebNegocio AWN = new RR_AdministradorWebNegocio();
                            Lista = AWN.ObtenerBlogDetallado(Datos);
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