using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class NuevoAfiliado2 : System.Web.UI.Page
    {
        public List<CH_Genero> ListaGeneros = new List<CH_Genero>();
        public List<CH_Estados> ListaEstado = new List<CH_Estados>();
        public List<CH_Poligono> ListaSeccion = new List<CH_Poligono>();
        //public List<> ListaEventoAgenda = new List<RR_TipoEventoAgenda>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboGenero();
                CargarComboEstado();
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                //Obtener los datos y dibujarlos.
                                RR_Afiliados DatosAux = new RR_Afiliados { Conexion = Comun.Conexion, IDAfiliado = ID };
                                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                                CN.ObtenerDetalleAfiliadoXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error 
                                    Response.Redirect("frmAfiliadosGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmAfiliadosGrid.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmAfiliadosGrid.aspx");
                    }
                    else

                        Response.Redirect("frmAfiliadosGrid.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 21)
                {
                    int cp = 0, genero = 0;
                    DateTime fecAfiliacion;
                    string operador = Request.Form["cmbOperador"].ToString();
                    string nombre = Request.Form["ctl00$cph_MasterBody$txtNombreAfiliado"].ToString();
                    string apepat = Request.Form["ctl00$cph_MasterBody$txtApePatAfiliado"].ToString();
                    string apemat = Request.Form["ctl00$cph_MasterBody$txtApeMatAfiliado"].ToString();
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaAfiliacion"], "dd/MM/yyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out fecAfiliacion);
                    //int estado = Convert.ToInt32(Request.Form["txtEstadoAfil"]);
                    //int municipio = Convert.ToInt32(Request.Form["txtMunicpioAfil"]);
                    int estado = 1;
                    int municipio = 1;
                    string id_poligono = Request.Form["cmbSeccion"].ToString();
                    string seccion = Request.Form["cmbSeccion"].ToString();
                    string direccion = Request.Form["ctl00$cph_MasterBody$txtDireccion"].ToString();
                    string numExt = Request.Form["ctl00$cph_MasterBody$txtNumeroExt"].ToString();
                    string numInt = Request.Form["ctl00$cph_MasterBody$txtNumeroInt"].ToString();
                    string colonia = Request.Form["ctl00$cph_MasterBody$txtColonia"].ToString();
                    int.TryParse(Request.Form["ctl00$cph_MasterBody$txtCodigoP"].ToString(), out cp);
                    string clvElector = Request.Form["ctl00$cph_MasterBody$txtClavElector"].ToString();
                    string correo = Request.Form["ctl00$cph_MasterBody$txtCorreoElectronico"].ToString();
                    string celular = Request.Form["ctl00$cph_MasterBody$txtCelular"].ToString();
                    int.TryParse(Request.Form["txtGenero"].ToString(), out genero);
                    string observaciones = Request.Form["ctl00$cph_MasterBody$txtObservaciones"].ToString();
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        //IDColaborador = AuxID;
                        bool NuevoRegistro = AuxID == "";
                        this.Guardar(NuevoRegistro, AuxID, operador, nombre, apepat, apemat, fecAfiliacion,
                            estado, municipio, id_poligono, seccion, direccion, numExt, numInt, colonia, cp, clvElector, correo, celular, genero, observaciones);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }
        #region Métodos

        private void CargarDatos(RR_Afiliados DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDAfiliado;
                txtNombreAfiliado.Value = DatosAux.Nombre;
                txtApePatAfiliado.Value = DatosAux.ApePat;
                txtApeMatAfiliado.Value = DatosAux.ApeMat;
                txtFechaAfiliacion.Value = DatosAux.FechaAfiliacion.ToShortDateString();
                txtDireccion.Value = DatosAux.Direccion;
                txtNumeroExt.Value = DatosAux.NumeroExt;
                txtNumeroInt.Value = DatosAux.NumeroInt;
                txtColonia.Value = DatosAux.Colonia;
                txtCodigoP.Value = DatosAux.CodigoPostal.ToString();
                txtClavElector.Value = DatosAux.ClaveElector;
                txtCorreoElectronico.Value = DatosAux.CorreoElect;
                txtCelular.Value = DatosAux.Celular;
                txtObservaciones.Value = DatosAux.Observaciones;
                string ScriptError = @"

                        $(document).ready(
                            function() {
                            document.getElementById('cmbSeccion').value= '" + DatosAux.IDPoligono + @"';
                            $('#cmbSeccion').trigger('change');
                            document.getElementById('cmbOperador').value= '" + DatosAux.IDColaborador + @"';
                            document.getElementById('txtGenero').value= " + DatosAux.Genero + @";                
                        });";
                //$( function($){ 
                //    $('#cmbSeccion').trigger('change');
                //    document.getElementById('cmbSeccion').value= '" + DatosAux.IDPoligono + @"';
                //    document.getElementById('cmbOperador').value= '" + DatosAux.IDColaborador + @"';
                //    document.getElementById('txtGenero').value= " + DatosAux.Genero + @";

                //});";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string AuxID, string IDColaborador, string nombre, string apepat, string apemat, DateTime fecAfiliacion,
            int estado, int municipio, string IDPoligono, string seccion, string direccion, string numExt, string numInt, string colonia, int cp, string clvElector, string correo, string celular,
            int genero, string observaciones)
        {
            try
            {
                RR_Afiliados Datos = new RR_Afiliados()
                {
                    NuevoRegistro = NuevoRegistro,
                    IDAfiliado = AuxID,
                    IDColaborador = IDColaborador,
                    Nombre = nombre,
                    ApePat = apepat,
                    ApeMat = apemat,
                    FechaAfiliacion = fecAfiliacion,
                    Estado = estado,
                    Municipio = municipio,
                    IDPoligono = IDPoligono,
                    Seccion = seccion,
                    Direccion = direccion,
                    NumeroExt = numExt,
                    NumeroInt = numInt,
                    Colonia = colonia,
                    CodigoPostal = cp,
                    ClaveElector = clvElector,
                    CorreoElect = correo,
                    Celular = celular,
                    Genero = genero,
                    Observaciones = observaciones,
                    Ratificacion = false,
                    Conexion = Comun.Conexion,
                    IDUsuario = Comun.IDUsuario
                };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ACCatalogoAfiliado(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmAfiliadosGrid.aspx?op=1", false);
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
                //hf.Value = BC.Encripta("-1");
                hf.Value = "-1";
                hf.Value = string.Empty;
                txtNombreAfiliado.Value = string.Empty;
                txtApePatAfiliado.Value = string.Empty;
                txtApeMatAfiliado.Value = string.Empty;
                txtFechaAfiliacion.Value = string.Empty;
                txtDireccion.Value = string.Empty;
                txtNumeroExt.Value = string.Empty;
                txtNumeroInt.Value = string.Empty;
                txtColonia.Value = string.Empty;
                txtCodigoP.Value = string.Empty;
                txtClavElector.Value = string.Empty;
                txtCorreoElectronico.Value = string.Empty;
                txtCelular.Value = string.Empty;
                txtObservaciones.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboGenero()
        {
            CH_Genero Datos = new CH_Genero() { Conexion = Comun.Conexion };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            ListaGeneros = GN.ObtenerComboGenero(Datos);
        }

        private void CargarComboEstado()
        {
            CH_Poligono Datos = new CH_Poligono() { Conexion = Comun.Conexion, IDEstado = 1, IDMunicipio = 1 };
            EC_CatalogosNegocio PN = new EC_CatalogosNegocio();
            ListaSeccion = PN.ObtenerComboPoligonos(Datos);
        }


        #endregion
    }
}