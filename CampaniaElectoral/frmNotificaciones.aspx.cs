using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmNotificaciones : System.Web.UI.Page
    {
        public CH_Notificacion DatosGlobales = new CH_Notificacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string IDNotificacion = string.Empty;
                if(Request.QueryString["id"] != null)
                {
                    IDNotificacion = Request.QueryString["id"].ToString();
                }
                DatosGlobales.Conexion = Comun.Conexion;
                DatosGlobales.IDNotificacion = IDNotificacion;
                CH_NotificacionNegocio NN = new CH_NotificacionNegocio();
                NN.ObtenerCombosColaborador(DatosGlobales);


                if (!IsPostBack)
                {
                    if (Request.QueryString["op"] != null)
                    {
                        if (Request.QueryString["op"] == "2")
                        {
                            if (Request.QueryString["id"] != null)
                            {
                                string ID = Request.QueryString["id"].ToString();
                                //Obtener los datos y dibujarlos.
                                CH_Notificacion Datos = new CH_Notificacion { Conexion = Comun.Conexion, IDNotificacion = ID };
                                NN.ObtenerDetalleNotificacion(Datos);
                                if (Datos.Completado)
                                {
                                    this.CargarDatos(Datos);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmNotificacionesGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                                Response.Redirect("frmNotificacionesGrid.aspx");
                        }
                        else
                            Response.Redirect("frmNotificacionesGrid.aspx");
                    }
                }
                else
                {
                    if (Request.Form.Count > 0)
                    {
                        if (Request.Form.Count > 0)
                        {
                            bool NuevoRegistro = string.IsNullOrEmpty(hf.Value);
                            IDNotificacion = string.IsNullOrEmpty(hf.Value) ? string.Empty : hf.Value.ToString();
                            string Colaboradores = Request.Form["cmbColaborador"] != null ? Request.Form["cmbColaborador"].ToString() : string.Empty;
                            string Nombre = Request.Form["ctl00$cph_MasterBody$txtNombre"] != null ? Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString() : string.Empty;
                            string Titulo = Request.Form["ctl00$cph_MasterBody$txtTitulo"] != null ? Request.Form["ctl00$cph_MasterBody$txtTitulo"].ToString() : string.Empty;
                            string Texto = Request.Form["ctl00$cph_MasterBody$txtTexto"] != null ? Request.Form["ctl00$cph_MasterBody$txtTexto"].ToString() : string.Empty;
                            bool Band = false;
                            string Todos = Request.Form["chkTodos"] != null ? Request.Form["chkTodos"].ToString() : string.Empty;
                            bool.TryParse(Todos, out Band);
                            DataTable TablaColabs = this.ObtenerSeleccionados(Colaboradores, Band);
                            this.GuardarDatos(NuevoRegistro, IDNotificacion, Nombre, Titulo, Texto, Band, TablaColabs);
                        }
                    }
                }
            }
            catch(Exception)
            { }
        }
     
        private void GuardarDatos(bool _NuevoRegistro, string _IDNotificacion, string _Nombre, string _Titulo, string _Texto, bool _Todos, DataTable _Tabla)
        {
            try
            {
                CH_Notificacion DatosAux = new CH_Notificacion {
                    NuevoRegistro = _NuevoRegistro,
                    IDNotificacion = _IDNotificacion,
                    NombreNotif = _Nombre,
                    TituloNotif = _Titulo,
                    Texto = _Texto,
                    Todos = _Todos,
                    TablaColaboradores = _Tabla,
                    IDUsuario = Comun.IDUsuario,
                    Conexion = Comun.Conexion
                };
                CH_NotificacionNegocio NN = new CH_NotificacionNegocio();
                NN.ACNotificaciones(DatosAux);
                DatosAux.Completado = true;
                if (DatosAux.Completado)
                {
                    Response.Redirect("frmNotificacionGrid.aspx", false);
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

        private void CargarDatos(CH_Notificacion DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDNotificacion;
                txtNombre.Value = DatosAux.NombreNotif;
                txtTitulo.Value = DatosAux.TituloNotif;
                txtTexto.Value = DatosAux.Texto;
                
                string ScriptError = @"
                    $(document).ready(
                        function() {
                        $('#chkTodos').prop('checked', " + DatosAux.Todos.ToString().ToLower() + @");
                        $('.js-example-disabled-multi').prop('disabled', " + DatosAux.Todos.ToString().ToLower() + @");
                    });";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ObtenerSeleccionados(string Colaboradores, bool Band)
        {
            try
            {
                DataTable TablaAux = new DataTable();
                TablaAux.Columns.Add("IDColaborador", typeof(string));
                if (!Band)
                {
                    string[] Arreglo = Colaboradores.Split(',');
                    for (int i = 0; i < Arreglo.Length; i++)
                    {
                        object[] Fila = { Arreglo[i] };
                        TablaAux.Rows.Add(Fila);
                    }
                }
                return TablaAux;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }   
    }
}