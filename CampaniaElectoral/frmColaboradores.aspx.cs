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
                //if (Request.QueryString["op"] != null && Request.QueryString["op"] == "1")
                //{
                //    //REPRESENTANTE GENERAL 

                //}
                //if (Request.QueryString["op"] != null && Request.QueryString["op"] == "2")
                //{
                //    //REPRESENTANTE GENERAL DE LA CASILLA 

                //} 
                //if (Request.QueryString["op"] != null && Request.QueryString["op"] == "4")
                //{
                //    //PERADORES POLITICOS

                //}
                //if (Request.QueryString["op"] != null && Request.QueryString["op"] == "5")
                //{
                //    //ADMINISTRADOR Y CAPTURISTAS

                //}
                if (Request.QueryString["opW"] != null && Request.QueryString["opW"] == "3")
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

               if( Request.QueryString["op"] != null)
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