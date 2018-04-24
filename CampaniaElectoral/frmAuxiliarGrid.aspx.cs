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
    public partial class frmAuxiliarGrid : System.Web.UI.Page
    {
        public List<EM_CatColaborador> ListaAuxiliar = new List<EM_CatColaborador>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion, IDColaborador = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                        CN.EliminarColaboradorXID(Datos);
                        if (Datos.Completado)
                        {
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
                this.CargarGridColaboradores();

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
        public void CargarGridColaboradores()
        {
            try
            {
                EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion, IDTipoUsu = 3 };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaAuxiliar = GN.ObtenerCatalogoColaboradores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}