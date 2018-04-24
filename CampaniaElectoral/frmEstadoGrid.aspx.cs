using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmEstadoGrid : System.Web.UI.Page
    {
        public List<CH_Estados> ListaEstado = new List<CH_Estados>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        CH_Estados Datos = new CH_Estados { Conexion = Comun.Conexion, IDEstado = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_EstadoNegocio EN = new EM_EstadoNegocio();
                        EN.EliminarEstadosXID(Datos);
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
                if (!IsPostBack)
                {

                }
                else
                {
                }

                this.CargarGridEstado();
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
        public void CargarGridEstado()
        {
            try
            {
                CH_Estados Datos = new CH_Estados { Conexion = Comun.Conexion };
                EM_EstadoNegocio EN = new EM_EstadoNegocio();
                ListaEstado = EN.ObtenerCatalogoEstados(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}