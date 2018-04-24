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
    public partial class frmContacto : System.Web.UI.Page
    {
        public EM_Contacto ListaContacto = new EM_Contacto();
        protected void Page_Load(object sender, EventArgs e)
        {
            EM_Contacto DatosAux = new EM_Contacto { Conexion = Comun.Conexion };
            EM_ContactoNegocio MN = new EM_ContactoNegocio();
            ListaContacto = MN.ObtenerContactoWeb(DatosAux);
        }
    }
}