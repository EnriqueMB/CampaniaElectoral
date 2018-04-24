using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class SiteMaster : MasterPage
    {
        public List<WN_Permisos> listaPadres;
        public List<WN_Permisos> listaHijos;
        public List<WN_Permisos> listaNietos;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //Comun.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //Comun.IDUsuario = "SystemWeb";

            //if (Session["Usuario"] == null)
            //    Response.Redirect("Login.aspx?idE='La sesión ha concluido, debe ingresar de nuevo su usuario y contraseña'");

            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx?idE='La sesión ha concluido, debe ingresar de nuevo su usuario y contraseña'");
            else
            {
                WN_Usuario u = (WN_Usuario)Session["Usuario"];
                listaPadres = u.ModulosPadres;
                listaHijos = u.ModulosHijos;
                listaNietos = u.ModuloNietos;
                Comun.IDUsuario = u.IDUsuario;
            }
        }
    }
}