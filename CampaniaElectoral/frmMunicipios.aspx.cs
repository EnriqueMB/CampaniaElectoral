using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmMunicipios : System.Web.UI.Page
    {
        public List<CH_Estados> ListaEstado = new List<CH_Estados>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
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
                                EM_Munucipios DatosAux = new EM_Munucipios { Conexion = Comun.Conexion, IDMunicipio = ID };
                                EM_MunicipioNegocio MN = new EM_MunicipioNegocio();
                                MN.ObtenerMunicipioDetalleXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmMunicipiosGrid.aspx?errorMessage=" + DatosAux.Resultado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmMunicipiosGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmMunicipiosGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmMunicipiosGrid.aspx?errorMessage=3");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 8)
                {
                    string txtNombeEstado = Request.Form["ctl00$cph_MasterBody$txtMunicipio"].ToString();
                    string txtSigla = Request.Form["ctl00$cph_MasterBody$txtSigla"].ToString();
                    int IDEstado = 0;
                    int.TryParse(Request.Form["cmbEstado"].ToString(), out IDEstado);
                    int IDMunicipio = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDMunicipio);
                        bool NuevoRegistro = !(IDMunicipio > 0);
                        this.Guardar(NuevoRegistro, IDMunicipio, IDEstado, txtNombeEstado, txtSigla);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }

        #region Métodos

        private void CargarComboBox()
        {
            CH_Estados Datos = new CH_Estados { Conexion = Comun.Conexion };
            EM_EstadoNegocio EN = new EM_EstadoNegocio();
            ListaEstado = EN.ObtenerComboEstados(Datos);
        }

        private void CargarDatos(EM_Munucipios DatosAux)
        {
            try
            {
                this.hf.Value = DatosAux.IDMunicipio.ToString();
                this.txtMunicipio.Value = DatosAux.MunicipioDesc;
                this.txtSigla.Value = DatosAux.Sigla;
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('cmbEstado').value=" + DatosAux.IDEstado + @";
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, int ID, int ID2, string NombreEstado, string Siglas)
        {
            try
            {
                EM_Munucipios Datos = new EM_Munucipios
                {
                    NuevoRegistro = NuevoRegistro,
                    IDMunicipio = ID,
                    IDEstado = ID2,
                    MunicipioDesc = NombreEstado,
                    Sigla = Siglas,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                EM_MunicipioNegocio MN = new EM_MunicipioNegocio();
                MN.ACMunicipio(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmMunicipiosGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
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
                this.hf.Value = "-1";
                this.txtMunicipio.Value = string.Empty;
                this.txtSigla.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}