using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmNuevoColaborador : System.Web.UI.Page
    {
        public List<CH_Genero> ListaGeneros = new List<CH_Genero>();
        public List<RR_TipoUsuarios> ListaTU = new List<RR_TipoUsuarios>();
        public List<CH_Poligono> ListaSeccion = new List<CH_Poligono>();
        public string op;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Para el boton de regresar 
            op = Request.QueryString["op"];

            if (!IsPostBack)
            { 
                //Reglas de Operacion
                if (Request.QueryString["op"] != null)
                {
                    //padre
                    divAsiganado.Visible = false;
                    cmbAsignado.DataSource = null;
                    //municipio
                    divMunicipio.Visible = false;
                    cmbMunicipio.DataSource = null;
                    //suplente
                    divSuplente.Visible = false;
                    cmbSuplente.DataSource = null;
                    //seccion
                    divSeccion.Visible = false;
                    cmbSeccion.DataSource = null;
                    //casilla
                    divCasilla.Visible = false;
                    cmbCasilla.DataSource = null;
                    //tipo de usuario (solo en admin, monitor y capturista)
                    cmbTipoUsuario.Visible = false;
                    cmbTipoUsuario.DataSource = null;

                    if (Request.QueryString["op"].ToString() == "100")
                    {
                        //Si es general, no tiene padre. no tiene suplente. no tiene seccion ni casilla
                        txtTipoUsuario.Visible = true;

                        txtTipoUsuario.Text = "REPRESENTANTE GENERAL";
                        Session["idtipouser"] = 100;
                    }
                    //Suplente de representante general
                    else if (Request.QueryString["op"].ToString() == "101")
                    {
                        //es suplente
                        divSuplente.Visible = true;
                        //LlenarCombo
                        llenarComboSuplente(100);

                        //padre
                        divAsiganado.Visible = false;
                        cmbAsignado.DataSource = null;

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE GENERAL";
                        Session["idtipouser"] = 101;
                    }
                    //representante de seccion
                    else if (Request.QueryString["op"].ToString() == "200")
                    {
                        //seccion
                        txtTipoUsuario.Visible = true;

                        //padre
                        divAsiganado.Visible = true;
                        cmbAsignado.DataSource = null;
                        llenarComboPadre(100);
                        cmbAsignado.SelectedIndexChanged += null;

                        //municipio
                        divMunicipio.Visible = true;
                        llenarComboMunicipios();
                        cmbMunicipio.AutoPostBack = true;

                        //seccion
                        divSeccion.Visible = true;
                        cmbSeccion.SelectedIndexChanged += null;
                        llenarComboSecciones(cmbMunicipio.SelectedIndex.ToString());

                        txtTipoUsuario.Text = "REPRESENTANTE DE SECCIÓN";
                        Session["idtipouser"] = 200;
                    }
                    //suplente de representante de seccion
                    else if (Request.QueryString["op"].ToString() == "201")
                    {
                        //es suplente
                        divSuplente.Visible = true;
                        llenarComboSuplente(200);
                        cmbSuplente.AutoPostBack = true;

                        divSeccion.Visible = true;
                        cmbSeccion.DataSource = null;
                        llenarComboSecciones("0");

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE DE SECCIÓN";
                        Session["idtipouser"] = 201;
                    }
                    //representante de casilla
                    else if (Request.QueryString["op"].ToString() == "300")
                    {
                        txtTipoUsuario.Visible = true;

                        //padre
                        divAsiganado.Visible = true;
                        llenarComboPadre(200);
                        cmbAsignado.AutoPostBack = true;

                        //se llena segun el asignado
                        divSeccion.Visible = true;
                        cmbSeccion.DataSource = null;

                        llenarComboSecciones("0");

                        //OBTENER LAS CASILLAS DE ACUERDO AL REPRESENTANTE DE SECCION
                        divCasilla.Visible = true;
                        cmbCasilla.DataSource = null;
                        llenarComboCasillas("0");

                        txtTipoUsuario.Text = "REPRESENTANTE DE CASILLA";
                        Session["idtipouser"] = 300;
                    }
                    //suplente de representante de casilla
                    else if (Request.QueryString["op"].ToString() == "301")
                    {
                        //es suplente
                        divSuplente.Visible = true;
                        llenarComboSuplente(300);
                        cmbSuplente.AutoPostBack = true;

                        //seccion y casilla se toma del padre
                        divSeccion.Visible = true;
                        cmbSeccion.DataSource = null;
                        llenarComboSecciones("0");

                        divCasilla.Visible = true;
                        cmbCasilla.DataSource = null;
                        llenarComboCasillas("0");

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE DE CASILLA";
                        Session["idtipouser"] = 301;
                    }
                    //operador politico
                    else if (Request.QueryString["op"].ToString() == "400")
                    {
                        //operador
                        txtTipoUsuario.Visible = true;
                        divAsiganado.Visible = true;

                        //llenar combo a partir de casilla al parecer
                        llenarComboPadre(300);
                        cmbAsignado.AutoPostBack = true;

                        //seccion y casilla se toma del padre, seria del jefe de casilla, solo para efecto de muestra
                        divSeccion.Visible = true;
                        cmbSeccion.DataSource = null;
                        llenarComboSecciones("0");

                        //Para efecto de muestra
                        divCasilla.Visible = true;
                        cmbCasilla.DataSource = null;
                        llenarComboCasillas("0");

                        txtTipoUsuario.Text = "OPERADOR POLÍTICO";
                        Session["idtipouser"] = 400;
                    }
                    //administrador, secretaria y monitor
                    else if (Request.QueryString["op"].ToString() == "1" || Request.QueryString["op"].ToString() == "10" || Request.QueryString["op"].ToString() == "11")
                    {
                        //escondemos el input tipo de usuario
                        txtTipoUsuario.Visible = false;
                        txtTipoUsuario.Text = "";
                        divTipoUsuario.Visible = false;
                        //cambiamos a dropdown
                        cmbTipoUsuario.Visible = true;
                        //llenarCombo
                        this.CargarComboTipoUsuario();

                        Session["idtipouser"] = null;
                    }
                }
            }


            if (!IsPostBack)
            {
                this.CargarComboGenero();
                if (Request.QueryString["opW"] != null)
                {//MODIFICAR
                    if (Request.QueryString["opW"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                //Obtener los datos y dibujarlos.
                                EM_CatColaborador DatosAux = new EM_CatColaborador { Conexion = Comun.Conexion, IDColaborador = ID };
                                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                                CN.ObtenerDetalleColaboradoresXID(DatosAux);
                                if (DatosAux.Completado)
                                {

                                    //idGenero = DatosAux.IDGenero;
                                    this.CargarDatos(DatosAux);

                                    //Valores predeterminados para los select por tipo de usuario
                                    if (DatosAux.IDTipoUsu == 200)
                                    {
                                        cmbAsignado.SelectedIndex = -1;
                                        cmbMunicipio.SelectedIndex = -1;
                                        cmbSeccion.SelectedIndex = -1;

                                        cmbAsignado.Items.FindByValue(DatosAux.Padre).Selected = true;
                                        cmbMunicipio.Items.FindByValue(DatosAux.Municipio.ToString()).Selected = true;
                                        llenarComboSecciones(DatosAux.Municipio.ToString());
                                        cmbSeccion.SelectedIndex = -1;

                                        cmbSeccion.Items.FindByValue(DatosAux.Seccion.ToString()).Selected = true;
                                    }
                                    else if (DatosAux.IDTipoUsu == 201)
                                    {
                                        cmbSuplente.Items.FindByValue(DatosAux.Sumplente).Selected = true;
                                        //seccion es directo de la base de datos
                                        cmbSeccion.Items.Insert(0, new ListItem(DatosAux.Seccion.ToString(), DatosAux.Seccion.ToString()));
                                    }
                                    else if (DatosAux.IDTipoUsu == 300)
                                    {
                                        cmbAsignado.SelectedIndex = -1;
                                        cmbSeccion.SelectedIndex = -1;
                                        cmbCasilla.SelectedIndex = -1;

                                        ListItem listItemAsignado = cmbAsignado.Items.FindByValue(DatosAux.Padre);
                                        if (listItemAsignado != null)
                                        {
                                            cmbAsignado.SelectedValue = listItemAsignado.Value;
                                        }
                                        else
                                        {
                                            cmbAsignado.SelectedIndex = -1;
                                        }

                                        //la seccion se llena directo ya que es el mismo id y nombre
                                        cmbSeccion.Items.Insert(0, new ListItem(DatosAux.Seccion.ToString(), DatosAux.Seccion.ToString()));
                                        //llenamos la casilla en relacion a la seccion
                                        llenarComboCasillas(DatosAux.Seccion.ToString());
                                        cmbCasilla.SelectedIndex = -1;

                                        ListItem listItemCasilla = cmbCasilla.Items.FindByValue(DatosAux.Casilla);
                                        if (listItemCasilla != null)
                                        {
                                            cmbCasilla.SelectedValue = listItemCasilla.Value;
                                        }
                                        else
                                        {
                                            cmbCasilla.SelectedIndex = -1;
                                        }
                                    }
                                    else if (DatosAux.IDTipoUsu == 301)
                                    {
                                        cmbSuplente.SelectedIndex = -1;
                                        cmbSeccion.SelectedIndex = -1;
                                        cmbCasilla.SelectedIndex = -1;

                                        ListItem listItemSuplente = cmbSuplente.Items.FindByValue(DatosAux.Sumplente);
                                        if (listItemSuplente != null)
                                        {
                                            cmbSuplente.SelectedValue = listItemSuplente.Value;
                                        }
                                        else
                                        {
                                            cmbSuplente.SelectedIndex = -1;
                                        }

                                        //seccion se obtiene del jefe inmediado
                                        llenarComboSeccionesXIDJefe(DatosAux.Sumplente);
                                        //casilla se obtiene del jefe inmediado
                                        llenarComboCasillaXIDJefe(DatosAux.Sumplente);
                                    }
                                    else if (DatosAux.IDTipoUsu == 400)
                                    {
                                        cmbAsignado.SelectedIndex = -1;
                                        cmbSeccion.SelectedIndex = -1;
                                        cmbCasilla.SelectedIndex = -1;

                                        ListItem listItemAsignado = cmbAsignado.Items.FindByValue(DatosAux.Padre);
                                        if (listItemAsignado != null)
                                        {
                                            cmbAsignado.SelectedValue = listItemAsignado.Value;
                                        }
                                        else
                                        {
                                            cmbAsignado.SelectedIndex = -1;
                                        }

                                        //la seccion se llena directo ya que es el mismo id y nombre
                                        cmbSeccion.Items.Insert(0, new ListItem(DatosAux.Seccion.ToString(), DatosAux.Seccion.ToString()));
                                        //llenamos la casilla en relacion a la seccion
                                        cmbCasilla.Items.Insert(0, new ListItem(DatosAux.Casilla.ToString(), DatosAux.Casilla.ToString()));
                                    }
                                    else if (DatosAux.IDTipoUsu == 1 || DatosAux.IDTipoUsu == 10 || DatosAux.IDTipoUsu == 11)
                                    {
                                        cmbTipoUsuario.SelectedIndex = -1;
                                        ListItem listItemTipoUsuario = cmbTipoUsuario.Items.FindByValue(DatosAux.IDTipoUsu.ToString());
                                        if (listItemTipoUsuario != null)
                                        {
                                            cmbTipoUsuario.SelectedValue = listItemTipoUsuario.Value;
                                        }
                                        else
                                        {
                                            cmbTipoUsuario.SelectedIndex = -1;
                                        }
                                    }
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmColaboradores.aspx?error=" + "Error al cargar los datos&nError=1", false);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmColaboradores.aspx", false);
                            }
                        }
                        else
                            Response.Redirect("frmColaboradores.aspx", false);
                    }
                    else
                        Response.Redirect("frmColaboradores.aspx", false);
                }
                else
                {//NUEVO
                    this.IniciarDatos();
                }
            }
            else
            {
                //al parecer c sera null si es evento del boton submit
                Control c = GetPostBackControl(this.Page);
                if (c == null)
                {
                    try
                    {
                        string imagen = string.Empty;
                        string sBandImgServer = Request.Form["ctl00$cph_MasterBody$inputImgServer"].ToString();
                        bool bandImgServer = (sBandImgServer == "False") ? false : true;

                        CultureInfo esMX = new CultureInfo("es-MX");
                        int IDGenero, IDTipoUsuario = -1;
                        DateTime txtFechaNac;

                        if (imgImagen.HasFile) //Hay cambio de imagen
                        {
                            #region Obtener datos de la imagen
                            int size = imgImagen.PostedFile.ContentLength;
                            byte[] ImagenOriginal = new byte[size];
                            imgImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                            Bitmap ImagenOriginalBinaria = new Bitmap(imgImagen.PostedFile.InputStream);
                            #endregion
                            #region Insertar imagen en la base de datos
                            imagen = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, ImageFormat.Jpeg);
                            #endregion
                            bandImgServer = true;
                        }

                        //obtener tipo de usuario
                        if (Session["idtipouser"] != null)
                            IDTipoUsuario = Convert.ToInt32(Session["idtipouser"].ToString());
                        else
                            IDTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue.ToString());

                        //Valores predeterminados, tanto para el representante general como el administrador
                        string padre = "X", suplente = "X", id_poligono = "X", casilla = "0";
                        int seccion = 0, municipio = 0;

                        //regla de los nuevos campos
                        //checamos el suplente del representante general
                        if (IDTipoUsuario == 101)
                        {
                            suplente = cmbSuplente.SelectedValue.ToString();
                        }
                        //representante de seccion
                        else if (IDTipoUsuario == 200)
                        {
                            padre = cmbAsignado.SelectedValue.ToString();
                            municipio = Int32.Parse(cmbMunicipio.SelectedValue.ToString());
                            seccion = Int32.Parse(cmbSeccion.SelectedValue.ToString());
                        }
                        //suplente de representante de seccion
                        else if (IDTipoUsuario == 201)
                        {
                            suplente = cmbSuplente.SelectedValue.ToString();
                            seccion =  Convert.ToInt32(cmbSeccion.SelectedValue.ToString());
                        }
                        //representate de casilla
                        else if (IDTipoUsuario == 300)
                        {
                            padre = cmbAsignado.SelectedValue.ToString();
                            seccion = Convert.ToInt32(cmbSeccion.SelectedValue.ToString());
                            casilla = cmbCasilla.SelectedValue.ToString();
                        }
                        //suplente representante de casilla
                        else if (IDTipoUsuario == 301)
                        {
                            suplente = cmbSuplente.SelectedValue.ToString();
                            seccion = Convert.ToInt32(cmbSeccion.SelectedValue.ToString());
                            casilla = cmbCasilla.SelectedValue.ToString();
                        }
                        //operador politico
                        else if (IDTipoUsuario == 400)
                        {
                            padre = cmbAsignado.SelectedValue.ToString();
                            seccion = Int32.Parse(cmbSeccion.SelectedValue.ToString());
                            casilla = cmbCasilla.SelectedValue.ToString();
                        }
                        //Administrador | capturista | monitor
                        else if (IDTipoUsuario == 1 || IDTipoUsuario == 10 || IDTipoUsuario == 11)
                        {

                        }

                        //predeterminado 
                        int estado = 7;

                        string txtNomb = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                        string txtApPaterno = Request.Form["ctl00$cph_MasterBody$txtApPaterno"].ToString();
                        string txtApMaterno = Request.Form["ctl00$cph_MasterBody$txtApMaterno"].ToString();
                        string txtCorreo = Request.Form["ctl00$cph_MasterBody$txtCorreo"].ToString();
                        string txtTelefono = Request.Form["ctl00$cph_MasterBody$txtTelefono"].ToString();
                        string txtPassword = Request.Form["ctl00$cph_MasterBody$id_password"].ToString();
                        string txtPasswordConfi = Request.Form["ctl00$cph_MasterBody$id_password_again"].ToString();
                        string FechaNacimi = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtFechaNac"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtFechaNac"];
                        DateTime.TryParseExact(FechaNacimi, "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out txtFechaNac);
                        string txtCP = Request.Form["ctl00$cph_MasterBody$txtCodigoPostal"].ToString();
                        string direccion = Request.Form["ctl00$cph_MasterBody$txtDireccion"].ToString();
                        string numExt = Request.Form["ctl00$cph_MasterBody$txtNumeroExt"].ToString();
                        string numInt = Request.Form["ctl00$cph_MasterBody$txtNumeroInt"].ToString();
                        string colonia = Request.Form["ctl00$cph_MasterBody$txtColonia"].ToString();
                        string clvElector = Request.Form["ctl00$cph_MasterBody$txtClavElector"].ToString();
                        IDGenero = Int32.Parse(cmbGenero.SelectedValue.ToString());
                        string IDColaborador = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        bool bandPassServer = bool.Parse(Request.Form["ctl00$cph_MasterBody$inputPassServer"].ToString());

                        this.Guardar(
                            IDColaborador, IDTipoUsuario, txtNomb, txtApPaterno, txtApMaterno, estado,
                            municipio, id_poligono, direccion, numExt, numInt, colonia,
                            txtCP, clvElector, txtCorreo, txtTelefono, txtPassword, IDGenero,
                            txtFechaNac, imagen, bandPassServer, padre, suplente, casilla,
                            bandImgServer, seccion
                        );
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message, false);
                    }
                }
            }
        }

        public Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }
        private void llenarComboPadre(int tipusu)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion , Parametro01Int=tipusu};
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbAsignado.DataSource = GN.ObtenerComboPadre(Datos);
                cmbAsignado.DataValueField = "ID";
                cmbAsignado.DataTextField = "Nombre";
                cmbAsignado.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboSuplente(int tipusu)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion, Parametro01Int = tipusu };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbSuplente.DataSource = GN.ObtenerComboSuplente(Datos);
                cmbSuplente.DataValueField = "ID";
                cmbSuplente.DataTextField = "Nombre";
                cmbSuplente.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboSecciones(string padre)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion, Parametro01String=padre };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbSeccion.DataSource = GN.ObtenerComboSeccionesXPadre(Datos);
                cmbSeccion.DataValueField = "ID";
                cmbSeccion.DataTextField = "Nombre";
                cmbSeccion.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboSeccionesXIDJefe(string padre)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion, Parametro01String = padre };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbSeccion.DataSource = GN.ObtenerComboSeccionesXJefe(Datos);
                cmbSeccion.DataValueField = "ID";
                cmbSeccion.DataTextField = "Nombre";
                cmbSeccion.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboCasillaXIDJefe(string padre)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion, Parametro01String = padre };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbCasilla.DataSource = GN.ObtenerComboCasillaXIDJefe(Datos);
                cmbCasilla.DataValueField = "ID";
                cmbCasilla.DataTextField = "Nombre";
                cmbCasilla.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboCasillas(string poligono)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion, Parametro01String = poligono };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbCasilla.DataSource = GN.ObtenerComboCasillasXSeccion(Datos);
                cmbCasilla.DataValueField = "ID";
                cmbCasilla.DataTextField = "Nombre";
                cmbCasilla.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboMunicipios()
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbMunicipio.DataSource = GN.ObtenerComboMunicipios(Datos);
                cmbMunicipio.DataValueField = "ID";
                cmbMunicipio.DataTextField = "Nombre";
               
                cmbMunicipio.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarComboSecciones()
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbSeccion.DataSource = GN.ObtenerComboSecciones(Datos);
                cmbSeccion.DataValueField = "ID";
                cmbSeccion.DataTextField = "Nombre";
                cmbSeccion.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSeccion.SelectedIndex > 0)
                    llenarComboCasillas(cmbSeccion.SelectedValue.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CmbAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAsignado.SelectedIndex > 0)
                    llenarComboSecciones(cmbAsignado.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Métodos
        private void CargarDatos(EM_CatColaborador DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDColaborador.ToString();
                txtClavElector.Value = DatosAux.ClaveElector.ToString();
                txtNombre.Value = DatosAux.Nombre;
                txtApPaterno.Value = DatosAux.ApPaterno;
                txtApMaterno.Value = DatosAux.ApMaterno;
                txtDireccion.Value = DatosAux.Direccion;
                txtColonia.Value = DatosAux.Colonia;
                txtNumeroInt.Value = DatosAux.NumeroInt;
                txtNumeroExt.Value = DatosAux.NumeroExt;
                txtCorreo.Value = DatosAux.Correo;
                txtTelefono.Value = DatosAux.Telefono;
                txtFechaNac.Value = DatosAux.FechaNac.ToString("dd-MM-yyyy");
                id_password.Value = DatosAux.Password;
                id_password_again.Value = DatosAux.Password;
                txtCodigoPostal.Value = DatosAux.CodigoPostal;
                
                if (string.IsNullOrEmpty(DatosAux.Imagen))
                {
                    inputImgServer.Value = "False";
                    Logo.Src = "assets/images/NoImage.png";
                }
                else
                {
                    inputImgServer.Value = "True";
                    Logo.Src = "data:image/png;base64, " + DatosAux.Imagen;
                }

                inputPassServer.Value = "True";

                //cargamos el genero
                ListItem listItemGenero = cmbGenero.Items.FindByValue(DatosAux.IDGenero.ToString());
                if (listItemGenero != null)
                {
                    cmbGenero.SelectedValue = listItemGenero.Value;
                }
                else
                {
                    cmbGenero.SelectedIndex = -1;
                }

                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Guardar(string ID,             int tipoUsu,            string Nombre,          string ApPat,           string ApMat,       
                             int estado,            int municipio,          string IDpoligono,      string direccion,       string numExt,      
                             string numInt,         string colonia,         string CodigoPostal,    string claveElector,    string Correo,
                             string Telefono,       string Password,        int id_genero,          DateTime FechasNac,     string imagen,
                             bool bandPassServer,   string padre,           string suplente,        string casilla,            bool bandImgServer, 
                             int seccion
                            )
        {
            try
            {
                EM_CatColaborador Datos = new EM_CatColaborador
                {
                    IDColaborador   = ID,                   IDTipoUsu       = tipoUsu,          Nombre          = Nombre,
                    ApPaterno       = ApPat,                ApMaterno       = ApMat,            Estado          = estado,
                    Municipio       = municipio,            IDPoligono      = IDpoligono,       Direccion       = direccion,
                    NumeroExt       = numExt,               NumeroInt       = numInt,           Colonia         = colonia,
                    CodigoPostal    = CodigoPostal,         ClaveElector    = claveElector,     Correo          = Correo,
                    Telefono        = Telefono,             Password        = Password,         FechaNac        = FechasNac,
                    IDGenero        = id_genero,            Imagen          = imagen,           Conexion        = Comun.Conexion,
                    IDUsuario       = User.Identity.Name,   Padre           = padre,            Sumplente       = suplente,
                    Casilla         = casilla,              BandPassServer  = bandPassServer,   imgGuardada     = bandImgServer,
                    Seccion         = seccion
                };

                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoColaboradores(Datos);
                if (Datos.Completado)
                {
                    
                    Response.Redirect("frmColaboradores.aspx?op=" + Datos.IDTipoUsu + "", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, Datos.MensajeSQL, "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "error", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos: " + ex.Message, "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
        }

       
        private void IniciarDatos()
        {
            try
            {
                hf.Value = "";
                txtNombre.Value = string.Empty;
                txtApMaterno.Value = string.Empty;
                txtApPaterno.Value = string.Empty;
                txtCorreo.Value = string.Empty;
                txtCodigoPostal.Value = string.Empty;
                
                txtTelefono.Value = string.Empty;
                id_password.Value = string.Empty;
                id_password_again.Value = string.Empty;
                inputPassServer.Value = "False";
                inputImgServer.Value = "False";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarComboGenero()
        {
            try
            {
                CH_Genero Datos = new CH_Genero { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                cmbGenero.DataSource = GN.ObtenerComboGenero(Datos);
                cmbGenero.DataValueField = "IDGenero";
                cmbGenero.DataTextField = "Descripcion";
                cmbGenero.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMunicipio.SelectedIndex > 0)
                    llenarComboSecciones(cmbMunicipio.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void cmbAsignado_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (string.Equals(op, "300"))
            {
                llenarComboSeccionesXIDJefe(cmbAsignado.SelectedValue.ToString());
                if(cmbSeccion.DataSource == null)
                {
                    cmbSeccion.Items.Clear();
                    cmbSeccion.Items.Insert(0, new ListItem("0", "0"));
                }
                llenarComboCasillas(cmbSeccion.SelectedValue.ToString());
            }
            else if (string.Equals(op, "400"))
            {
                llenarComboSeccionesXIDJefe(cmbAsignado.SelectedValue.ToString());
                if (cmbSeccion.DataSource == null)
                {
                    cmbSeccion.Items.Clear();
                    cmbSeccion.Items.Insert(0, new ListItem("0", "0"));
                }
                llenarComboCasillaXIDJefe(cmbAsignado.SelectedValue.ToString());
                if (cmbCasilla.DataSource == null)
                {
                    cmbCasilla.Items.Clear();
                    cmbCasilla.Items.Insert(0, new ListItem("0", "0"));
                }
            }
        }
        public void CargarComboTipoUsuario()
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion };
                WN_CombosNegocio CN = new WN_CombosNegocio();

                cmbTipoUsuario.DataSource = CN.ObtenerComboTipoUsuario(Datos);
                cmbTipoUsuario.DataValueField = "ID";
                cmbTipoUsuario.DataTextField = "Nombre";
                cmbTipoUsuario.DataBind();
                cmbTipoUsuario.Items.Insert(0, new ListItem("-Seleccione-", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected void cmbSuplente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(string.Equals(op, "201"))
            {
                llenarComboSeccionesXIDJefe(cmbSuplente.SelectedValue.ToString());
                if (cmbSeccion.DataSource == null)
                {
                    cmbSeccion.Items.Clear();
                    cmbSeccion.Items.Insert(0, new ListItem("0", "0"));
                }
            }
            else if (string.Equals(op, "301"))
            {
                llenarComboSeccionesXIDJefe(cmbSuplente.SelectedValue.ToString());
                if (cmbSeccion.DataSource == null)
                {
                    cmbSeccion.Items.Clear();
                    cmbSeccion.Items.Insert(0, new ListItem("0", "0"));
                }
                llenarComboCasillaXIDJefe(cmbSuplente.SelectedValue.ToString());
                if (cmbCasilla.DataSource == null)
                {
                    cmbSeccion.Items.Clear();
                    cmbSeccion.Items.Insert(0, new ListItem("0", "0"));
                }
            }
        }
    }
}