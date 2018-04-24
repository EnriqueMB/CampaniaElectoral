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
    public partial class frmPoligonosGrid : System.Web.UI.Page
    {
        public List<CH_Poligono> Lista = new List<CH_Poligono>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"].ToString();
                        CH_Poligono Datos = new CH_Poligono { Conexion = Comun.Conexion, IDPoligono = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_PoligonoNegocio CN = new CH_PoligonoNegocio();
                        CN.EliminarPoligonoXID(Datos);
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
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?errorNumber=" + ex.HResult);
            }
        }

        public void CargarGrid()
        {
            try
            {
                CH_Poligono Datos = new CH_Poligono { Conexion = Comun.Conexion };
                CH_PoligonoNegocio PolNeg = new CH_PoligonoNegocio();
                Lista = PolNeg.ObtenerListaPoligonos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}