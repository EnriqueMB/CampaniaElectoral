using CampaniaElectoral.ClasesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;

namespace CampaniaElectoral
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form.Count > 0)
            {
                //string Usuario = Request.Form["username"].ToString();
                //string Password = Request.Form["password"].ToString();

                string RememberMe = string.Empty;
                if (Request.Form["remember"] != null)
                    Request.Form["remember"].ToString();
                bool BandRememberMe = RememberMe.Equals("on");

                WN_Usuario user = new WN_Usuario();
                user.Usuario = Request.Form["username"].ToString();
                user.Password = Request.Form["password"].ToString();
                WN_Configuracion confg = new WN_Configuracion();
                Autenticacion.Autenticar(user);
                if (user.Opcion == 3)
                {
                    Session["Usuario"] = user;
                    Session["Configuracion"] = confg;
                    FormsAuthentication.RedirectFromLoginPage(user.IDUsuario, BandRememberMe);
                }
                else if (user.Opcion == 1)
                {
                    DialogMessage.Show(TipoMensaje.Error, "El usuario no existe", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 2)
                {
                    DialogMessage.Show(TipoMensaje.Error, "No tiene permisos para acceder a la página", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 4)
                {
                    DialogMessage.Show(TipoMensaje.Error, "La cuenta no está activa", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 5)
                {
                    DialogMessage.Show(TipoMensaje.Error, "La cuenta está caducada", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 6)
                {
                    DialogMessage.Show(TipoMensaje.Error, "La cuenta está bloqueada", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 7)
                {
                    DialogMessage.Show(TipoMensaje.Error, "La cuenta no está validada", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 8)
                {
                    DialogMessage.Show(TipoMensaje.Error, "Contraseña incorrecta", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                else if (user.Opcion == 9)
                {
                    DialogMessage.Show(TipoMensaje.Error, "La cuenta no existe", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                }
                //if (Autenticacion.Autenticar(user))
                //{

                    //Session["Usuario"] = user;
                    //Session["Configuracion"] = confg;



                    //string IDUsuario = "AA2C1EF1-2AB7-4E41-9739-B9B1CFCD9154";
                    ////Inicia la validación de Two factor Authentication
                    //FormsAuthentication.RedirectFromLoginPage(IDUsuario, BandRememberMe);
                    
                //}
                //else
                //{
                //    DialogMessage.Show(TipoMensaje.Error, "Error en credenciales", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, false);
                //}
            }
        }
    }
}