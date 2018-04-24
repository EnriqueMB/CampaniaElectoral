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
    public partial class WebForm6 : System.Web.UI.Page
    {
        public List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
        string IDProyecto = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDFoto = "";
            GM_PlanCampania FN = new GM_PlanCampania { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_PlanCampaniaNegocio PN = new GM_PlanCampaniaNegocio();

            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {   

                if (Request.QueryString["id"] != null)
                {
                    IDFoto = Request.QueryString["id"].ToString();

                    if (Request.QueryString["id"].ToString() == IDFoto)
                    {                      
                        FN.IDPElectoral = Request.QueryString["id2"].ToString();
                        FN.IDFoto = IDFoto;                        
                        PN.CargarFotoPlanCampania(FN);
                        if (FN.Completado)
                        {
                            Response.Redirect("frmProyectoCampania.aspx", false);                            
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro agregado a la página correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "No se puede agregar el registro a la página registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
            }
            else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "4")
            {
                if (Request.QueryString["id"] != null)
                {
                    IDProyecto = Request.QueryString["id"].ToString();
                    FN.IDPElectoral = IDProyecto;
                    Lista = PN.ObtenerCatalogoFotos(FN);
                }
            }            
        }
    }
}