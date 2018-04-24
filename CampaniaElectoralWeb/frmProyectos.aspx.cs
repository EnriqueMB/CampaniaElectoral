using CampaniaElectoral.ClasesAux;
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
    public partial class frmProyectos : System.Web.UI.Page
    {
        public List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
        public List<GM_PlanCampania> ListaM = new List<GM_PlanCampania>();
        public List<RR_Blog> ListaB = new List<RR_Blog>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
            }
            CargarProyectosMas();
            CargarDescBlog();
            this.CargarProyectos();
            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {

                }
            }
            if (Request.QueryString["errorMessage"] != null)
            {
                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
        }
        public void CargarProyectos()
        {
            try
            {
                GM_PlanCampania Datos = new GM_PlanCampania { Conexion = Comun.Conexion };
                GM_PlanCampaniaNegocio GN = new GM_PlanCampaniaNegocio();
                Lista = GN.ObtenerListCampania(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarProyectosMas()
        {
            try
            {
                GM_PlanCampania Datos = new GM_PlanCampania { Conexion = Comun.Conexion };
                GM_PlanCampaniaNegocio GN = new GM_PlanCampaniaNegocio();
                ListaM = GN.ObtenerListCampaniaMas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDescBlog()
        {
            try
            {
                RR_Blog Datos = new RR_Blog { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                ListaB = GN.ObtenerDescBlog(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}