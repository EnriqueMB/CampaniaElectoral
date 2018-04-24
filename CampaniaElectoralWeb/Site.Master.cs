using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        public EM_Contacto ListaContacto = new EM_Contacto();
        public List<RR_DatosRedesSociales> Lista = new List<RR_DatosRedesSociales>();
        public EM_MisionVision Datos;
        public List<RR_Blog> ListaBlog = new List<RR_Blog>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Comun.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Comun.IDUsuario = "SystemWeb";
            if (!IsPostBack)
            {
            }
            else
            {
            }
            this.CargarIconos();
            CargarDatosContacto();
            SobreNosotros();
            ObtenerBlogRecientes();
        }

        #region metodos
        private void CargarIconos()
        {
            RR_DatosRedesSociales Datos = new RR_DatosRedesSociales { Conexion = Comun.Conexion };
            RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
            Lista = GN.ObtenerIconosRedes(Datos);
        }

        private void CargarDatosContacto()
        {
            EM_Contacto DatosAux = new EM_Contacto { Conexion = Comun.Conexion };
            EM_ContactoNegocio MN = new EM_ContactoNegocio();
            ListaContacto = MN.ObtenerContactoWeb(DatosAux);
        }

        private void SobreNosotros()
        {
            EM_MisionVision DatosAux = new EM_MisionVision { Conexion = Comun.Conexion };
            EM_MisionVisionNegocio MN = new EM_MisionVisionNegocio();
            Datos = MN.MisionWeb(DatosAux);
        }

        private void ObtenerBlogRecientes()
        {
            RR_Blog Datos = new RR_Blog { Conexion = Comun.Conexion };
            EC_BlogNegocio OBR = new EC_BlogNegocio();
            ListaBlog = OBR.ObtenerBlogsRecientes(Datos);
        }

        #endregion
    }
}