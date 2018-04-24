using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmStatusAfiliadoGrid : System.Web.UI.Page
    {
        public List<EM_StatusAfiliados> ListaStatus = new List<EM_StatusAfiliados>();
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
                        EM_StatusAfiliados Datos = new EM_StatusAfiliados { Conexion = Comun.Conexion, IDStatusAfiliado = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                        CN.EliminarStatusAfiliadoXID(Datos);
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

                this.CargarGridStatusAfiliados();
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
        public void CargarGridStatusAfiliados()
        {
            try
            {
                EM_StatusAfiliados Datos = new EM_StatusAfiliados { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaStatus = GN.ObtenerCatalogoStatusAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}