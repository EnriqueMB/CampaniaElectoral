using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmEquipoTrabajoGrid : System.Web.UI.Page
    {
        public List<EC_EquipoTrabajo> ListaMiembro = new List<EC_EquipoTrabajo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {

                        string ID = Request.QueryString["id"].ToString();
                        RR_MiembrosEquipoTrabajo Datos = new RR_MiembrosEquipoTrabajo { Conexion = Comun.Conexion, IDMiembroEquipo = ID, IDUsuario = Comun.IDUsuario };
                        EC_EquipoTrabajoNegocio CN = new EC_EquipoTrabajoNegocio();
                        CN.EliminarMiembroTrabajo(Datos);
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
                CargarGrid();
            }
            catch (Exception ex)
            {

                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
        private void CargarGrid()
        {
            try
            {
                EC_EquipoTrabajo Datos = new EC_EquipoTrabajo { Conexion = Comun.Conexion };
                EC_EquipoTrabajoNegocio Lista = new EC_EquipoTrabajoNegocio();
                ListaMiembro = Lista.CargarGrid(Datos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}