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
    public partial class frmTextoDonate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                                RR_Donate DatosAux = new RR_Donate { Conexion = Comun.Conexion, IDDonate = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ObtenerTextoDonateXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmTextoHomeGrid.aspx?errorMessage=" + DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmTextoDonateGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmTextoDonateGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmTextoDonateGrid.aspx?errorMessage=3");
                }
                else
                {
                    Response.Redirect("frmTextoDonateGrid.aspx", false);
                }
            }
            else
            {
                if (Request.Form.Count == 6)
                {
                    string donate = Request.Form["ctl00$cph_MasterBody$txtDon"].ToString();                    
                    int IDTexto = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDTexto);
                        bool NuevoRegistro = !(IDTexto > 0);
                        this.Guardar(NuevoRegistro, IDTexto, donate);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }

        #region Métodos

        private void CargarDatos(RR_Donate DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDDonate.ToString();
                txtDon.Value = DatosAux.Donate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegitro, int id, string donate)
        {
            try
            {

                RR_Donate Datos = new RR_Donate
                {
                    NuevoRegistro = nuevoRegitro,
                    IDDonate = id,
                    Donate = donate,                    
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACDonateTexto(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmTextoDonateGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error",
                        ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                //BasicCrypto BC            = new BasicCrypto();
                //hf.Value                  = BC.Encripta("-1");
                hf.Value = "-1";
                this.txtDon.Value = string.Empty;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}