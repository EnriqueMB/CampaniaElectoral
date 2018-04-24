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
    public partial class frmTextoHome : System.Web.UI.Page
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
                            int ID=0;                           
                            if (int.TryParse(Request.QueryString["id"].ToString(), out ID)) 
                            {
                                //Obtener los datos y dibujarlos.
                                RR_DatosHome DatosAux = new RR_DatosHome { Conexion = Comun.Conexion, IDHomeText = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ObtenerTextoHomeXID(DatosAux);
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
                                Response.Redirect("frmTextoHomeGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmTextoHomeGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmTextoHomeGrid.aspx?errorMessage=3");
                }
                else
                {
                    Response.Redirect("frmTextoHomeGrid.aspx?errorMessage=4");
                }
            }
            else
            {
                if (Request.Form.Count == 17)
                {
                    string queTHacemos = Request.Form["ctl00$cph_MasterBody$txtTituloHacemos"].ToString();
                    string queHacemos = Request.Form["ctl00$cph_MasterBody$txtQueHacemos"].ToString();
                    string Tafiliate = Request.Form["ctl00$cph_MasterBody$txtTituloAfiliate"].ToString();
                    string afiliate = Request.Form["ctl00$cph_MasterBody$txtAfiliate"].ToString();
                    string TproxEventos = Request.Form["ctl00$cph_MasterBody$txtTituloProxEventos"].ToString();
                    string proxEventos = Request.Form["ctl00$cph_MasterBody$txtProxEventos"].ToString();
                    string TequipoTrabajo = Request.Form["ctl00$cph_MasterBody$txtTituloEquipoTrabajo"].ToString();
                    string equipoTrabajo = Request.Form["ctl00$cph_MasterBody$txtEquipoTrabajo"].ToString();
                    string Tblog = Request.Form["ctl00$cph_MasterBody$txtTituloBlog"].ToString();
                    string blog = Request.Form["ctl00$cph_MasterBody$txtDescTituloBlog"].ToString();
                    string Tcontacto = Request.Form["ctl00$cph_MasterBody$txtTituloContacto"].ToString();
                    string contacto = Request.Form["ctl00$cph_MasterBody$txtContacto"].ToString();
                    int IDstatus = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDstatus);
                        bool NuevoRegistro = !(IDstatus > 0);
                        this.Guardar(NuevoRegistro, IDstatus, queTHacemos, queHacemos, Tafiliate, afiliate, TproxEventos, proxEventos,
                            TequipoTrabajo, equipoTrabajo, Tblog, blog, Tcontacto, contacto);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }

        #region Métodos

        private void CargarDatos(RR_DatosHome DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDHomeText.ToString();
                txtTituloHacemos.Value = DatosAux.TituloHacemos;
                txtQueHacemos.Value = DatosAux.DescHacemos;
                txtTituloAfiliate.Value = DatosAux.TituloAfiliate;
                txtAfiliate.Value = DatosAux.DescAfiliate;
                txtTituloProxEventos.Value = DatosAux.TituloProxEvent;
                txtProxEventos.Value = DatosAux.DescProxEvent;
                txtTituloEquipoTrabajo.Value = DatosAux.TituloEquipoTrabajo;
                txtEquipoTrabajo.Value = DatosAux.DescEquipoTrabajo;
                txtTituloBlog.Value = DatosAux.TituloBlog;
                txtDescTituloBlog.Value = DatosAux.DescBlog;
                txtTituloContacto.Value = DatosAux.TituloContactanos;
                txtContacto.Value = DatosAux.Contactanos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegitro, int id, string Thacemos, string descHacemos, string Tafiliate, string afiliate, 
            string TproxEvent ,string descProxEventos, string tEquipoTrabajo ,string descEquipoTrabajo, string Tblog, string blog,
            string Tcontactanos, string contacto)
        {
            try
            {

                RR_DatosHome Datos = new RR_DatosHome
                {
                    NuevoRegistro       = nuevoRegitro,
                    IDHomeText          = id,
                    TituloHacemos       = Thacemos,
                    DescHacemos         = descHacemos,
                    TituloAfiliate      = Tafiliate,
                    DescAfiliate        = afiliate,
                    TituloProxEvent     = TproxEvent,
                    DescProxEvent       = descProxEventos,
                    TituloEquipoTrabajo =tEquipoTrabajo,
                    DescEquipoTrabajo   = descEquipoTrabajo,
                    TituloBlog          = Tblog,
                    DescBlog            = blog,
                    TituloContactanos   = Tcontactanos,
                    Contactanos         = contacto,
                    Conexion            = Comun.Conexion,
                    IDUsuario           = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACDatosHome(Datos);
                if (Datos.Completado)
                {
                    Response.Redirect("frmTextoHomeGrid.aspx", false);
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
                hf.Value                    = "-1";
                this.txtEquipoTrabajo.Value = string.Empty;
                this.txtProxEventos.Value   = string.Empty;
                this.txtQueHacemos.Value    = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 
    }
}