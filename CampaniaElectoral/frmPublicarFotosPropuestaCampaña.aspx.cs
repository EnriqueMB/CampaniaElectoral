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
    public partial class frmPublicarFotosPropuestaCampaña : System.Web.UI.Page
    {
        public List<RR_PropuestaCamapaña> Lista = new List<RR_PropuestaCamapaña>();
        string IDPropuesta = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDFoto = "";
            RR_PropuestaCamapaña PC = new RR_PropuestaCamapaña { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };            
            RR_AdministradorWebNegocio RN = new RR_AdministradorWebNegocio();

            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null)
                {
                    IDFoto = Request.QueryString["id"].ToString();

                    if (Request.QueryString["id"].ToString() == IDFoto)
                    {
                        PC.IDPropuesta = Request.QueryString["id2"].ToString();
                        PC.IDFoto = IDFoto;
                        RN.CargarFotoPropuesta(PC);
                        if (PC.Completado)
                        {
                            Response.Redirect("frmPropuestaCampañaGrid.aspx", false);
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
            else if(Request.QueryString["op"] != null && Request.QueryString["op"] == "4")
            {
                if (Request.QueryString["id"] != null)
                {
                    IDPropuesta = Request.QueryString["id"].ToString();
                    PC.IDPropuesta = IDPropuesta;
                    Lista = RN.ObtenerCatalogoFotos(PC);
                }
            }                            
        }
    }
}