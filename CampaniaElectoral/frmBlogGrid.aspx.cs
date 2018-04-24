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
    public partial class frmBlogGrid : System.Web.UI.Page
    {
        public List<RR_Blog> Lista = new List<RR_Blog>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"];
                        RR_Blog Datos = new RR_Blog { Conexion = Comun.Conexion, IDPublicacion = AuxID, IDUsuario = Comun.IDUsuario };
                        RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                        CN.EliminarPublicacionesBlogXID(Datos);
                        if (Datos.Completado)
                        {
                            //Mostrar mensaje Success
                        }
                        else
                        {
                            //Mostrar Mensaje de error
                        }
                    }
                }
                if (!IsPostBack)
                {

                }
                else
                {
                }
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }

        public void CargarGrid()
        {
            try
            {
                RR_Blog Datos = new RR_Blog { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                Lista = GN.ObtenerPublicacionesBlog(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}