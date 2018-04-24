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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                GM_PlanCampania DatosAux = new GM_PlanCampania { Conexion = Comun.Conexion, IDPElectoral = ID };
                                GM_PlanCampaniaNegocio CN = new GM_PlanCampaniaNegocio();
                                CN.ObtenerIdPlanCampania(DatosAux);
                                if (DatosAux.Completado)
                                {
                                   
                                    
                                    this.LoadData(DatosAux);
                                }
                                else
                                {
                                    Response.Redirect("frmProyectoCampania.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmProyectoCampania.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmProyectoCampania.aspx");
                    }
                    else
                        Response.Redirect("frmProyectoCampania.aspx");
                }
                else
                {
                    //this.runC();
                }
            }
            else
            {
                string txtTitulo = Request.Form["ctl00$cph_MasterBody$txtNombreProyecto"].ToString();
                string txtProy1 = Request.Form["ctl00$cph_MasterBody$txtNombreProyecto"].ToString();
                string txtProy2 = Request.Form["ctl00$cph_MasterBody$txtNombreProyecto"].ToString();
                string txtProy3 = Request.Form["ctl00$cph_MasterBody$txtNombreProyecto"].ToString();
                string txtProyP = Request.Form["ctl00$cph_MasterBody$txtNombreProyecto"].ToString();
                string IDPElectoral = "";
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDPElectoral = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDPElectoral);
                       this.Save(NuevoRegistro, IDPElectoral,txtTitulo, txtProy1, txtProy2, txtProy3, txtProyP);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
            }
        }

       

        private void LoadData(GM_PlanCampania DatosAux)
        {
            hf.Value = DatosAux.IDPElectoral;
            txtNombreProyecto.Value = DatosAux.TituloProyecto;
            txtProy1.Value = DatosAux.Proyecto1;
            txtProy2.Value = DatosAux.Proyecto2;
            txtProy3.Value = DatosAux.Proyecto3;
            txtPropP.Value = DatosAux.ProyectoP;
        }

        private void Save(bool NuevoRegistro, string IDPElectoral, string titulo, string proyec1, string proyec2, string proyec3, string proyecp)
        {
            try
            {
                GM_PlanCampania Data = new GM_PlanCampania
                {
                NuevoRegistro= NuevoRegistro,
                IDPElectoral =IDPElectoral,
                TituloProyecto = titulo,
                Proyecto1 = proyec1,
                Proyecto2 = proyec2,
                Proyecto3 = proyec3,
                ProyectoP = proyecp,
                Conexion     = Comun.Conexion,
                IDUsuario    = User.Identity.Name

                };
                GM_PlanCampaniaNegocio CN = new GM_PlanCampaniaNegocio();
                CN.AGPlanCampania(Data);
                if (Data.Completado)
                {
                    string ScripSucces = DialogMessage.Show(TipoMensaje.Success, "Los datos se han guardado.", "Correctamente", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Type), "popup", ScripSucces, true);
                    Response.Redirect("frmViewProyectoCampania.aspx", false);

                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    Response.Redirect("frmViewProyectoCampania.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
               // Response.Redirect("frmPlanCampania.aspx", false);
            }
        }
        private void RunData() 
        {
            try
            {
                hf.Value = "";
                txtNombreProyecto.Value = string.Empty;
                txtProy1.Value = string.Empty;
                txtProy2.Value = string.Empty;
                txtProy3.Value = string.Empty;
                txtPropP.Value = string.Empty;                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}