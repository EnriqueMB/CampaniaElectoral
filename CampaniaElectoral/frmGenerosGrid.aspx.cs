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
    public partial class frmGenerosGrid : System.Web.UI.Page
    {
        public List<CH_Genero> Lista = new List<CH_Genero>();
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
                        CH_Genero Datos = new CH_Genero { Conexion = Comun.Conexion, IDGenero = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                        CN.EliminarGeneroXID(Datos);
                        if (Datos.Completado)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);                            
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al eliminar el registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
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

                this.CargarGrid();
            }
            catch(Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
        
        public void CargarGrid()
        {
            try
            {
                CH_Genero Datos = new CH_Genero { Conexion = Comun.Conexion };
                CH_CatalogosNegocio GN = new CH_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoGenero(Datos);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}