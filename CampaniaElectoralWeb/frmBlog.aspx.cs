using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class frmBlog : System.Web.UI.Page
    {
        public List<GM_LoadBanner> ListaB = new List<GM_LoadBanner>();
        public List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
        public List<RR_Blog> ListaBlog = new List<RR_Blog>();        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
            }
            this.CargarDescBlog();
            this.CargarTitulos();
            GM_LoadBanner DatosB = new GM_LoadBanner { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_LoadBannerNegocio FN = new GM_LoadBannerNegocio();
            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {
                    
                }
            }
            ListaB = FN.ObtenerListaBanner(DatosB);
            if (Request.QueryString["errorMessage"] != null)
            {
                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
        }

        public void CargarTitulos()
        {
            try
            {
                RR_PropuestaCamapaña Datos = new RR_PropuestaCamapaña { Conexion = Comun.Conexion };
                RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
                Lista = GN.ObtenerTitulosPropuesta(Datos);
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
                ListaBlog = GN.ObtenerDescBlog(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}