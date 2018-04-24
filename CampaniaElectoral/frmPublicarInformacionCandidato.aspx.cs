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
    public partial class frmPublicarInformacionCandidato : System.Web.UI.Page
    {
        public List<CH_PartidoPolitico> ListaPartido = new List<CH_PartidoPolitico>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboPartido();
            if (!IsPostBack)
            {
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID;
                            if (Request.QueryString["id"].ToString() != string.Empty)
                            {
                                ID = Request.QueryString["id"].ToString();
                                //Obtener los datos y dibujarlos.
                                RR_InformacionCandidato DatosAux = new RR_InformacionCandidato { Conexion = Comun.Conexion, IDCandidato = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ACInformacionCandidato(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmPublicarInformacionCandidatoGrid.aspx?errorMessage=" + DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmActividadesEventosGrid.aspx?errorMessage=3");
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
                if (Request.Form.Count == 9)
                {
                    string nombre = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                    string ApePat = Request.Form["ctl00$cph_MasterBody$txtApePat"].ToString();                    
                    string ApeMat = Request.Form["ctl00$cph_MasterBody$txtApeMat"].ToString();                    
                    int cmbPartido = 0;
                    int.TryParse(Request.Form["cmbPartido"].ToString(), out cmbPartido);
                    int IDColab = 0;
                    try
                    {                        
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDColab);
                        bool NuevoRegistro = (AuxID == "-1");
                        this.Guardar(NuevoRegistro, AuxID, nombre, ApePat, ApeMat, cmbPartido);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                    //}
                }
            }
        }

        #region Métodos

        private void CargarDatos(RR_InformacionCandidato DatosAux)
        {
            try
            {
                hf.Value         = DatosAux.IDCandidato.ToString();
                txtNombre.Value  = DatosAux.Nombre;
                txtApePat.Value  = DatosAux.ApePat;
                txtApeMat.Value  = DatosAux.ApeMat;
                          
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string nombre, string apePat, string apeMat, int partido)
        {
            try
            {
                RR_InformacionCandidato Datos = new RR_InformacionCandidato
                {
                    NuevoRegistro   = NuevoRegistro,
                    IDCandidato     = ID,
                    Nombre          = nombre,
                    ApePat          = apePat,
                    ApeMat          = apeMat,
                    PartidoPolitico = partido,
                    Conexion        = Comun.Conexion,
                    IDUsuario       = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACInformacionCandidato(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmPublicarInformacionCandidato.aspx", false);
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
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value       = BC.Encripta("-1");
                hf.Value         = "-1";
                txtNombre.Value  = string.Empty;
                txtApePat.Value  = string.Empty;
                txtApeMat.Value  = string.Empty;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        private void CargarComboPartido()
        {
            CH_PartidoPolitico Datos = new CH_PartidoPolitico() { Conexion = Comun.Conexion };
            RR_AdministradorWebNegocio GN = new RR_AdministradorWebNegocio();
            ListaPartido = GN.ObtenerComboPartido(Datos);
        }
        #endregion
    }
}