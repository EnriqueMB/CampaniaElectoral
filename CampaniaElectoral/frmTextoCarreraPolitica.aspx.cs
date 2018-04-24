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
    public partial class frmTextoCarreraPolitica : System.Web.UI.Page
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
                                RR_CarreraPolitica DatosAux = new RR_CarreraPolitica { Conexion = Comun.Conexion, IDCarreraPolitica = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ObtenerTextoCarreraXID(DatosAux);
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
                                Response.Redirect("frmTextoCarreraPoliticaGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmTextoCarreraPoliticaGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmTextoCarreraPoliticaGrid.aspx?errorMessage=3");
                }
                else
                {
                    Response.Redirect("frmTextoCarreraPoliticaGrid.aspx", false);
                }
            }
            else
            {
                if (Request.Form.Count == 7)
                {
                    string titulo = Request.Form["ctl00$cph_MasterBody$txttitulo"].ToString();
                    string desc = Request.Form["ctl00$cph_MasterBody$txtdescr"].ToString();                    
                    int IDTexto = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDTexto);
                        bool NuevoRegistro = !(IDTexto > 0);
                        this.Guardar(NuevoRegistro, IDTexto, titulo, desc);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }
        #region Métodos

        private void CargarDatos(RR_CarreraPolitica DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDCarreraPolitica.ToString();
                txttitulo.Value = DatosAux.TituloCarreraPolitica;
                txtdescr.Value = DatosAux.DescripcionCarreraPol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegitro, int id, string titulo, string desc)
        {
            try
            {

                RR_CarreraPolitica Datos = new RR_CarreraPolitica
                {
                    NuevoRegistro = nuevoRegitro,
                    IDCarreraPolitica = id,
                    TituloCarreraPolitica = titulo,
                    DescripcionCarreraPol = desc,                    
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACCarreraPolitica(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmTextoCarreraPoliticaGrid.aspx", false);
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
        #endregion
    }
}