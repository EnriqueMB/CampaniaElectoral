using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class sfrmContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            EM_Contacto Datos = new EM_Contacto { Conexion = Comun.Conexion };
            Datos.Nombre = Request.Form["Nombre"].ToString();
            Datos.Correo = Request.Form["Correo"].ToString();
            Datos.Telefono = Request.Form["Telefono"].ToString();
            Datos.Asunto = Request.Form["Asunto"].ToString();
            Datos.Mensaje = Request.Form["Mensaje"].ToString();
            if (!string.IsNullOrEmpty(Datos.Correo))
            {
                EnvioCorreo.EnviarCorreo(
                    ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , Datos.Correo
                    , "Mensaje de contacto"
                    , EnvioCorreo.GenerarHtmlContacto(Datos.Nombre, Datos.Correo, Datos.Telefono, Datos.Asunto, Datos.Mensaje)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
            }
        }
    }
}