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
    public partial class frmPartidosGrid : System.Web.UI.Page
    {
        public List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        CH_PartidoPolitico Datos = new CH_PartidoPolitico { Conexion = Comun.Conexion, IDPartido = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                        CN.EliminarPartidoXID(Datos);
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
                CH_PartidoPolitico Datos = new CH_PartidoPolitico { Conexion = Comun.Conexion };
                CH_CatalogosNegocio GN = new CH_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoPartidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}