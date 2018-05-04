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
    public partial class frmColaboradores : System.Web.UI.Page
    {
        public List<EM_CatColaborador> ListaColaboradores = new List<EM_CatColaborador>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var op = Request.QueryString["op"];
                var opw = Request.QueryString["opW"];
                var comp = Request.QueryString["complete"];
                if ( comp == "1")
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else if (comp == "0")
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }

                if (Request.QueryString["opW"] != null && Request.QueryString["opW"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        
                        string AuxID = Request.QueryString["id"].ToString();

                        EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion, IDColaborador = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                        CN.EliminarColaboradorXID(Datos);

                        string complete = "0";
                        string url = "frmColaboradores.aspx?op=" + op + "&complete=" + complete;

                        if (Datos.Completado)
                        {
                            complete = "1";
                            url = "frmColaboradores.aspx?op=" + op + "&complete="+ complete;
                        }
                        Response.Redirect(url, false);
                        
                    }
                }
                

            if ( Request.QueryString["op"] != null )
                this.CargarGridColaboradores(Convert.ToInt32(Request.QueryString["op"].ToString()));
            
            else
                Response.Redirect("PageError.aspx?errorNumber=" + "No existe el tipo de operación");

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

        public void CargarGridColaboradores(int tipoop)
        {
            
                EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion};
                Datos.IDTipoUsu = tipoop;
                    
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaColaboradores = GN.ObtenerCatalogoColaboradores(Datos);
            
        }
    }
}