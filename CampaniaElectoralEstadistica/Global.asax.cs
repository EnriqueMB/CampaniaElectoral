using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CampaniaElectoralEstadistica
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["strConnection"];
            Comun.Conexion = settings.ConnectionString;
        }
    }
}