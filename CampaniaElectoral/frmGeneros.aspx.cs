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
    public partial class frmGeneros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScriptManager CS = Page.ClientScript;
            //CS.RegisterClientScriptInclude("Notifications UI", "/assets/js/ui-notifications.js");
            //ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "Notifications UI", "/assets/js/ui-notifications.js");            

            if (!IsPostBack)
            {
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            int ID = 0;
                            if (int.TryParse(Request.QueryString["id"].ToString(), out ID))
                            {
                                //Obtener los datos y dibujarlos.
                                CH_Genero DatosAux = new CH_Genero { Conexion = Comun.Conexion, IDGenero = ID };
                                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                                CN.ObtenerDetalleGeneroXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmGenerosGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmGenerosGrid.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmGenerosGrid.aspx");
                    }
                    else
                        Response.Redirect("frmGenerosGrid.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                //Page.Validate();
                //if (IsValid)
                //{
                    if (Request.Form.Count == 7)
                    {
                        string txtDesc = Request.Form["ctl00$cph_MasterBody$txtGenero"].ToString();
                        string txtLetr = Request.Form["ctl00$cph_MasterBody$txtLetra"].ToString();
                        int IDGenero = -1;
                        try
                        {
                            //BasicCrypto BC = new BasicCrypto();
                            //string AuxID = BC.Desencripta(Request.Form["ctl00$cph_MasterBody$hf"].ToString());
                            string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                            int.TryParse(AuxID, out IDGenero);
                            bool NuevoRegistro = !(IDGenero > 0);
                            this.Guardar(NuevoRegistro, IDGenero, txtDesc, txtLetr);
                        }
                        catch(Exception ex)
                        {
                            Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                        }
                //}
            }
        }
        }

        #region Métodos

        private void CargarDatos(CH_Genero DatosAux)
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta(DatosAux.IDGenero.ToString());
                hf.Value = DatosAux.IDGenero.ToString();
                txtGenero.Value = DatosAux.Descripcion;
                txtLetra.Value = DatosAux.Letra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, string Descripcion, string Letra)
        {
            try
            {
                CH_Genero Datos = new CH_Genero {   NuevoRegistro = NuevoRegistro, IDGenero=ID, Descripcion=Descripcion,
                                                    Letra = Letra, Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                CN.ACCatalogoGenero(Datos);                
                if (Datos.Completado)
                {
                    Response.Redirect("frmGenerosGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "-1";
                txtGenero.Value = string.Empty;
                txtLetra.Value = string.Empty;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}