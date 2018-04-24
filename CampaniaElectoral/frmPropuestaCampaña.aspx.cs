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
    public partial class frmPropuestaCampaña : System.Web.UI.Page
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
                            RR_PropuestaCamapaña Datos = new RR_PropuestaCamapaña { Conexion = Comun.Conexion, IDPropuesta = ID };
                            RR_AdministradorWebNegocio AWN = new RR_AdministradorWebNegocio();
                            AWN.ObtenerPropuestaXID(Datos);
                            if (Datos.Completado)
                            {
                                CargarDatos(Datos);
                            }
                            else
                            {
                                Response.Redirect("frmPropuestaCampañaGrid.aspx?errorMessage=" + "Error al cargar los datos&nError=1");
                            }                                          
                        }
                        else
                        {
                            Response.Redirect("frmPropuestaCampañaGrid.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("frmPropuestaCampañaGrid.aspx");
                    }
                }
                else
                {
                    IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 10)
                {
                    string txtNombre      = Request.Form["ctl00$cph_MasterBody$txtPropuesta"].ToString();
                    string txtDesc1       = Request.Form["ctl00$cph_MasterBody$txtProp1"].ToString();
                    string txtDesc2       = Request.Form["ctl00$cph_MasterBody$txtProp2"].ToString();
                    string txtDesc3       = Request.Form["ctl00$cph_MasterBody$txtProp3"].ToString();
                    string txtPiePag      = Request.Form["ctl00$cph_MasterBody$txtPiePag"].ToString();



                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        //IDColaborador = AuxID;
                        bool NuevoRegistro = AuxID == "";
                        this.Guardar(NuevoRegistro, AuxID, txtNombre, txtDesc1, txtDesc2, txtDesc3, txtPiePag);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }           
        }

        #region metodos

        private void Guardar(bool nuevoRegistro, string id, string nombre, string desc1, string desc2, string desc3, string piePag)
        {
            try
            {
                RR_PropuestaCamapaña DatosAux = new RR_PropuestaCamapaña()
                {
                    NuevoRegistro   = nuevoRegistro,
                    IDPropuesta     = id,
                    NombrePropuesta = nombre,
                    Descripcion1    = desc1,
                    Descripcion2    = desc2,
                     Descripcion3   = desc3,
                     PieDePagina    = piePag,
                    Conexion        = Comun.Conexion,
                    IDUsuario       = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio AWN = new RR_AdministradorWebNegocio();
                AWN.ACPropuestaCampania(DatosAux);
                if (DatosAux.Completado)
                {
                    Response.Redirect("frmPropuestaCampañaGrid.aspx", false);
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
                //BasicCrypto BC   = new BasicCrypto();
                //hf.Value         = BC.Encripta("-1");
                hf.Value           = "-1";
                hf.Value           = string.Empty;
                txtPropuesta.Value = string.Empty;
                txtProp1.Value     = string.Empty;
                txtProp2.Value     = string.Empty;
                txtProp3.Value     = string.Empty;
                txtPiePag.Value    = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatos(RR_PropuestaCamapaña DatosAux)
        {
            try
            {
                hf.Value           = DatosAux.IDPropuesta.ToString();
                txtPropuesta.Value = DatosAux.NombrePropuesta;
                txtProp1.Value     = DatosAux.Descripcion1;
                txtProp2.Value     = DatosAux.Descripcion2;
                txtProp3.Value     = DatosAux.Descripcion3;
                txtPiePag.Value    = DatosAux.PieDePagina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}