using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CampaniaElectoral.ClasesAux
{
    public class CustomAuthenticationModule : IHttpModule
    {
        public CustomAuthenticationModule()
        {
        }
        /// <summary> 
        /// Inicializa el HTTPModule y asigna los EventHandlers a cada Evento 
        /// Esta es la parte donde se define a que eventos va a atender el HttpModule 
        /// </summary> 
        /// <param name="oHttpApp"></param> 
        public void Init(HttpApplication oHttpApp)
        {
            // Se Registran los Manejadores de Evento que nos interesa 
            oHttpApp.AuthorizeRequest += new EventHandler(this.AuthorizaRequest);
            oHttpApp.AuthenticateRequest += new EventHandler(this.AuthenticateRequest);
        }
        public void Dispose()
        {
        }
        /// <summary> 
        /// Administra la autorización por Request 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void AuthorizaRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                //Si el usuario esta Autenticado 
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User is ClasesAux.Auth)
                    {
                        ClasesAux.Auth principal =
                                                (ClasesAux.Auth)HttpContext.Current.User;
                        if (!principal.IsPageEnabled(HttpContext.Current.Request.Path))
                            HttpContext.Current.Server.Transfer("Login.aspx");
                    }
                }
            }
        }
        /// <summary> 
        /// Autentica en Cada Request 
        /// </summary> 
        /// <param name="sender"> HttpApplication </param> 
        /// <param name="e"></param> 
        private void AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                //Si el usuario esta Autenticado 
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        //Traigo el Rol que esta guardado en una Cookie encriptada 
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        string cookieName =
                              System.Web.Security.FormsAuthentication.FormsCookieName;

                        string userData =
                              System.Web.HttpContext.Current.Request.Cookies[cookieName].Value;

                        ticket = FormsAuthentication.Decrypt(userData);

                        string rol = "";
                        if (userData.Length > 0)
                            rol = ticket.UserData;

                        //Se crea la clase Principal  y se asigna al CurrenUser del Contexto
                        //HttpContext.Current.User = new ClasesAux.Auth(_identity, perfil);
                    }
                }
            }
        }//AuthenticateRequest 
    } //class 
}