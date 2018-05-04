using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CampaniaElectoral
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["strConnection"];
            Comun.Conexion = settings.ConnectionString;
            
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e) //EndRequest
        {
            IPrincipal usr = HttpContext.Current.User;
            if (usr.Identity.IsAuthenticated && usr.Identity.AuthenticationType == "Forms")
            {
                //var httpApp = (HttpApplication)sender;
                //string URL = httpApp.Request.FilePath;
                //string[] URLS = System.Text.RegularExpressions.Regex.Split(URL, "/");
                //HttpContext context = HttpContext.Current;
                //if (httpApp.Request.RawUrl.Split('/').Length > 1)
                //{
                //    string URLValida = URLS[1];
                //    if (URLValida == "Login.aspx")
                //    {

                //    }
                //    else
                //    {
                //        if (context != null && context.Session != null)
                //        {
                //            WN_Usuario u = (WN_Usuario)Session["Usuario"];
                //            if (u == null)
                //            {

                //            }
                //            else
                //            {
                //                if (u.ModulosPadres.Exists(x => x.FrmModulo == URLValida))
                //                {

                //                }
                //                else if (u.ModulosHijos.Exists(x => x.FrmModulo == URLValida))
                //                {

                //                }
                //                else if (u.ModuloNietos.Exists(x => x.FrmModulo == URLValida))
                //                {

                //                }
                //                else
                //                {
                //                    if (URLValida == "frmEjemplo.aspx")
                //                    {

                //                    }
                //                    else
                //                    {
                //                        FormsAuthentication.SignOut();
                //                        Response.Redirect("/Login.aspx", true);
                //                    }

                //                }
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}