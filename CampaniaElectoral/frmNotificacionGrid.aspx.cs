using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class frmNotifiacionGrid : System.Web.UI.Page
    {
        public List<EM_Notificacion> ListaNotificaciones = new List<EM_Notificacion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string IDAux = Request.QueryString["id"].ToString();
                        EM_Notificacion Datos = new EM_Notificacion { Conexion = Comun.Conexion, IDNotificacion = IDAux, IDUsuario = Comun.IDUsuario };
                        EM_NotifiacionNegocio MN = new EM_NotifiacionNegocio();
                        MN.EliminarNotificacion(Datos);
                        if (Datos.Completado)
                        {
                            //Mostrar mensaje Success
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "4")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string IDAux = Request.QueryString["id"].ToString();
                        List<EM_Notificacion> ListaEnvia = new List<EM_Notificacion>();
                        EM_Notificacion Datos = new EM_Notificacion { Conexion = Comun.Conexion, IDNotificacion = IDAux, IDUsuario = Comun.IDUsuario };
                        EM_NotifiacionNegocio MN = new EM_NotifiacionNegocio();
                        ListaEnvia = MN.EnviarNotificaciones(Datos);
                        if (ListaEnvia.Count == 0)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Warning, "No se encontro ningún dispostivo registrado.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            foreach (var Item in ListaEnvia)
                            {
                                EnviaNotificaciones.EnviarMensaje(Item.TokenCelular.ToString(), Item.Titulo.ToString(), Item.Texto.ToString(), Item.Badge, Item.IDCelular);
                            }
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Notificaciones enviadas correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
                
                if (!IsPostBack)
                {

                }
                else
                {
                }

                this.CargarGridNotifiacion();
                if (Request.QueryString["errorMessage"] != null)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }

        private void CargarGridNotifiacion()
        {
            try
            {
                EM_Notificacion Datos = new EM_Notificacion { Conexion = Comun.Conexion };
                EM_NotifiacionNegocio NN = new EM_NotifiacionNegocio();
                ListaNotificaciones = NN.ObtenerNotificacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}