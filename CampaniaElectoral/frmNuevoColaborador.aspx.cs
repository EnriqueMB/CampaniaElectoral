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


        int tipoUsu;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            { 

                

            //Reglas de Operacion
            if (Request.QueryString["op"] != null)
            {

                if (Request.QueryString["op"].ToString() == "100")
                {
                    //Si es general, no tiene padre. tiene suplente. no tiene seccion ni casilla
                    txtTipoUsuario.Visible = true;
                    cmbTipoUsuario.Visible = false;
                    cmbTipoUsuario.DataSource = null;



                    if (Request.QueryString["pus"] != null)
                    { //es suplente
                        divSuplente.Visible = true;
                        //LlenarCombo
                        llenarComboSuplente(100);

                        //padre
                        divAsiganado.Visible = false;
                        cmbAsignado.DataSource = null;

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE GENERAL";
                        Session["idtipouser"] = 101;
                    }
                    else
                    { //no es suplente
                        divSuplente.Visible = false;
                        cmbSuplente.DataSource = null;



                        //padre
                        divAsiganado.Visible = false;
                        cmbAsignado.DataSource = null;

                        txtTipoUsuario.Text = "REPRESENTANTE GENERAL";
                        Session["idtipouser"] = 100;
                    }


                    divSeccion.Visible = false;
                    cmbSeccion.DataSource = null;

                    divCasilla.Visible = false;
                    cmbCasilla.DataSource = null;

                }
                else
                 if (Request.QueryString["op"].ToString() == "200")
                {
                    //seccion
                    txtTipoUsuario.Visible = true;
                    cmbTipoUsuario.Visible = false;
                    cmbTipoUsuario.DataSource = null;


                    if (Request.QueryString["pus"] != null)
                    { //es suplente
                        divSuplente.Visible = true;
                        //LlenarCombo
                        llenarComboSuplente(200);

                        //padre
                        divAsiganado.Visible = false;
                        cmbAsignado.DataSource = null;


                        //seccion se llena del padre
                        divSeccion.Visible = false;
                        cmbSeccion.DataSource = null;

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE DE SECCIÓN";
                        Session["idtipouser"] = 201;
                    }
                    else
                    { //no es suplente
                        divSuplente.Visible = false;
                        cmbSuplente.DataSource = null;


                        //padre
                        divAsiganado.Visible = true;
                        //llenar combo
                        llenarComboPadre(100);
                       cmbAsignado.SelectedIndexChanged += null;

                        divSeccion.Visible = true;
                        //llenarcombo
                        llenarComboSecciones();
                        cmbSeccion.SelectedIndexChanged += null;

                        txtTipoUsuario.Text = "REPRESENTANTE DE SECCIÓN";
                        Session["idtipouser"] = 200;
                    }



                    divCasilla.Visible = false;
                    cmbCasilla.DataSource = null;
                }
                else
                 if (Request.QueryString["op"].ToString() == "300")
                {
                    //casilla, 
                    txtTipoUsuario.Visible = true;
                    cmbTipoUsuario.Visible = false;
                    cmbTipoUsuario.DataSource = null;

                    if (Request.QueryString["pus"] != null)
                    { //es suplente
                        divSuplente.Visible = true;
                        //LlenarCombo
                        llenarComboSuplente(300);

                        //padre
                        divAsiganado.Visible = false;
                        cmbAsignado.DataSource = null;

                        //seccion y casilla se toma del padre
                        divSeccion.Visible = false;
                        cmbSeccion.DataSource = false;

                        divCasilla.Visible = false;
                        cmbCasilla.DataSource = null;

                        txtTipoUsuario.Text = "SUPLENTE DE REPRESENTANTE DE CASILLA";
                        Session["idtipouser"] = 301;
                    }
                    else
                    { //no es suplente
                        divSuplente.Visible = false;
                        cmbSuplente.DataSource = null;


                        divAsiganado.Visible = true;
                        //llenar combo
                        llenarComboPadre(200);
                        cmbAsignado.SelectedIndexChanged += CmbAsignado_SelectedIndexChanged;


                        //se llena segun el asignado
                        divSeccion.Visible = true;
                        cmbSeccion.DataSource = null; //se llenara con padre.
                        cmbSeccion.SelectedIndexChanged += CmbSeccion_SelectedIndexChanged;

                        divCasilla.Visible = true;
                        cmbCasilla.DataSource = null; //se llenara segun se seleccione seccion

                        //llenara secciones
                        cmbAsignado.SelectedIndex = 0;

                        //seleccionar el primero
                        cmbSeccion.SelectedIndex = 0;

                        txtTipoUsuario.Text = "REPRESENTANTE DE CASILLA";
                        Session["idtipouser"] = 300;
                    }

                }
                else
                 if (Request.QueryString["op"].ToString() == "400")
                {
                    //operador
                    txtTipoUsuario.Visible = true;
                    cmbTipoUsuario.Visible = false;
                    cmbTipoUsuario.DataSource = null;


                    divAsiganado.Visible = true;
                    //llenar combo
                    llenarComboPadre(300);
                    cmbAsignado.SelectedIndexChanged += null;


                    //sin suplente
                    divSuplente.Visible = false;
                    cmbSuplente.DataSource = null;

                    //seccion y casilla se toma del padre
                    divSeccion.Visible = false;
                    cmbSeccion.DataSource = false;

                    divCasilla.Visible = false;
                    cmbCasilla.DataSource = null;

                    txtTipoUsuario.Text = "OPERADOR POLÍTICO";
                    Session["idtipouser"] = 400;
                }
                else
                {
                    txtTipoUsuario.Visible = false;
                    txtTipoUsuario.Text = "";
                    cmbTipoUsuario.Visible = true;
                    //llenarCombo
                    this.CargarComboTipoUsuario();

                    Session["idtipouser"] = null;
                    //sin padre
                    divAsiganado.Visible = false;
                    cmbAsignado.DataSource = null;
                  

                    //sin suplente
                    divSuplente.Visible = false;
                    cmbSuplente.DataSource = null;

                    //sin seccion y casilla
                    divSeccion.Visible = false;
                    cmbSeccion.DataSource = false;

                    divCasilla.Visible = false;
                    cmbCasilla.DataSource = null;


                }


            }

            }








            this.CargarComboGenero();
            //this.CargarComboTipoUsuario();

           



           if (!IsPostBack)
            {
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

                                   
                                    this.CargarDatos(DatosAux);
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

                //GUARDAR INFORMACION
                if (Request.Form.Count > 13 && Request.Form.Count < 25)
                {

                    //FALTA VALIDAR CAMPOS OBLIGATORIOS************************************************************************************************************************************


                    try
                    {


                        string imagen = "";
                   
                    CultureInfo esMX = new CultureInfo("es-MX");
                    int IDGenero, IDTipoUsuario = -1;
                    DateTime txtFechaNac;
                    bool Band = false;
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
                        Band = true;
                    }


                    //obtener tipo de usuario
                    if (Session["idtipouser"] != null) IDTipoUsuario = Convert.ToInt32(Session["idtipouser"].ToString());
                    else IDTipoUsuario = Convert.ToInt32(cmbTipoUsuario.SelectedValue.ToString());

                        string padre, suplente;
                        int casilla;
                        string id_poligono;

                        //regla de los nuevos campos
                        if (Request.QueryString["op"].ToString() == "100")
                        {
                            padre = "X";
                            casilla = 0;
                            id_poligono = "X";

                            if (Request.QueryString["pus"] != null)
                            {
                                suplente = cmbSuplente.SelectedValue.ToString();
                            }
                            else
                                suplente = "X";

                            

                        }
                        else
                        if (Request.QueryString["op"].ToString() == "200")
                        {

                          
                            casilla = 0;

                           

                            if (Request.QueryString["pus"] != null)
                            {
                                padre = "X";
                                suplente = cmbSuplente.SelectedValue.ToString();
                                id_poligono = "X";
                            }
                            else
                            {
                                suplente = "X";
                                padre = cmbAsignado.SelectedValue.ToString();
                                id_poligono = cmbSeccion.SelectedValue.ToString();
                            }
                               

                        }
                        else
                        if (Request.QueryString["op"].ToString() == "300")
                        {

                            if (Request.QueryString["pus"] != null)
                            {
                                padre = "X";
                                suplente = cmbSuplente.SelectedValue.ToString();
                                id_poligono = "X";
                                casilla = 0;
                            }
                            else
                            {
                                suplente = "X";
                                padre = cmbAsignado.SelectedValue.ToString();
                                id_poligono = cmbSeccion.SelectedValue.ToString();
                                casilla = Convert.ToInt32(cmbCasilla.SelectedValue.ToString());

                            }
                        }
                        else
                        if (Request.QueryString["op"].ToString() == "400")
                        {
                            suplente = "X";
                            padre = cmbAsignado.SelectedValue.ToString();
                            id_poligono = cmbSeccion.SelectedValue.ToString();
                            casilla = Convert.ToInt32(cmbCasilla.SelectedValue.ToString());



                        }
                        else
                        {
                            padre = "X";
                            casilla = 0;
                            id_poligono = "X";
                            suplente = "X";
                        }


                        string txtNomb = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                    string txtApPaterno = Request.Form["ctl00$cph_MasterBody$txtApPaterno"].ToString();
                    string txtApMaterno = Request.Form["ctl00$cph_MasterBody$txtApMaterno"].ToString();
                    string txtCorreo = Request.Form["ctl00$cph_MasterBody$txtCorreo"].ToString();
                    string txtTelefono = Request.Form["ctl00$cph_MasterBody$txtTelefono"].ToString();
                    string txtPassword = Request.Form["ctl00$cph_MasterBody$id_password"].ToString();
                    string txtPasswordConfi = Request.Form["ctl00$cph_MasterBody$id_password_again"].ToString();
                    string FechaNacimi = string.IsNullOrEmpty(Request.Form["ctl00$cph_MasterBody$txtFechaNac"]) ? string.Empty : Request.Form["ctl00$cph_MasterBody$txtFechaNac"];
                    DateTime.TryParseExact(FechaNacimi, "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out txtFechaNac);
                    //DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaNac"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out txtFechaNac);
                    string txtCP = Request.Form["ctl00$cph_MasterBody$txtCodigoPostal"].ToString();
                    int estado=1;
                    int municipio=1;

                   //     string seccion = "X";// Request.Form["cmbSeccion"].ToString();
                    string direccion = Request.Form["ctl00$cph_MasterBody$txtDireccion"].ToString();
                    string numExt = Request.Form["ctl00$cph_MasterBody$txtNumeroExt"].ToString();
                    string numInt = Request.Form["ctl00$cph_MasterBody$txtNumeroInt"].ToString();
                    string colonia = Request.Form["ctl00$cph_MasterBody$txtColonia"].ToString();
                    string clvElector = Request.Form["ctl00$cph_MasterBody$txtClavElector"].ToString();
                    int.TryParse(Request.Form["txtGenero"].ToString(), out IDGenero);
                    //int.TryParse(Request.Form["txtTipoUsuario"].ToString(), out IDTipoUsuario);
                    string txtUrlImg = Band ? imgImagen.PostedFile.FileName : string.Empty;
                    string IDColaborador = "";
                   
                   
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDColaborador = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDColaborador);
                      this.Guardar(NuevoRegistro, IDColaborador, IDTipoUsuario, txtNomb, txtApPaterno, txtApMaterno,estado ,municipio,id_poligono,direccion,numExt,numInt,colonia,txtCP,clvElector,txtCorreo, txtTelefono, txtPassword, IDGenero, 
                              txtFechaNac,imagen,Band,padre,suplente,casilla);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message, false);
                    }

                }
            }
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

            }
            catch (Exception ex)
            {

            }
        }

        private void llenarComboSuplente(int tipusu)
        {
            try
            {
                WN_Combos Datos = new WN_Combos { CadenaConexion = Comun.Conexion };
                WN_CombosNegocio GN = new WN_CombosNegocio();
                cmbSuplente.DataSource = GN.ObtenerComboSuplente(Datos);
                cmbSuplente.DataValueField = "ID";
                cmbSuplente.DataTextField = "Nombre";
                
            }
            catch (Exception ex)
            {
                
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
                cmbSeccion.Enabled = false;

            }
            catch (Exception ex)
            {

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

            }
            catch (Exception ex)
            {

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
                cmbSeccion.Enabled = true;

            }
            catch (Exception ex)
            {

            }
        }


        private void CmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSeccion.SelectedIndex > 0)
                    llenarComboCasillas(cmbSeccion.SelectedValue.ToString());

            }
            catch (Exception)
            {

                
            }
        }

        private void CmbAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAsignado.SelectedIndex > 0)
                    llenarComboSecciones(cmbAsignado.SelectedValue.ToString());


            }
            catch (Exception)
            {

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
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('form-field-select-3').value=" + DatosAux.IDGenero + @";
                        document.getElementById('txtTipoUsuario').value=" + DatosAux.IDTipoUsu + @";
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, int tipoUsu,string Nombre, string ApPat, string ApMat, int estado, int municipio,string IDpoligono,string direccion,string numExt, string numInt,string colonia, string CodigoPostal,string claveElector ,string Correo, string Telefono, string Password, int id_genero,DateTime FechasNac,
                              string imagen, bool BandCambioImagen, string padre, string suplente, int casilla)
        {
            try
            {
                /*string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName) : string.Empty;*/
                EM_CatColaborador Datos = new EM_CatColaborador
                {
                    NuevoRegistro   = NuevoRegistro,
                    IDColaborador   = ID,
                    IDTipoUsu       = tipoUsu,
                    Nombre          = Nombre,
                    ApPaterno       = ApPat,
                    ApMaterno       = ApMat,
                    Estado          = estado,
                    Municipio       = municipio,
                    IDPoligono      = IDpoligono,
                    
                    Direccion       = direccion,
                    NumeroExt       = numExt,
                    NumeroInt       = numInt,
                    Colonia         = colonia,
                    CodigoPostal    = CodigoPostal,
                    ClaveElector    =claveElector,
                    Correo          = Correo,
                    Telefono        = Telefono,
                    Password        = Password,
                    FechaNac        = FechasNac,
                    IDGenero        = id_genero,
                    Imagen          = imagen,
                    imgGuardada     = BandCambioImagen,
                    Conexion        = Comun.Conexion,
                    IDUsuario       = User.Identity.Name,
                    Padre           =padre,
                    Sumplente       =suplente,
                    Casilla         =casilla
                };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoColaboradores(Datos);
                if (Datos.Completado)
                {
                    
                    Response.Redirect("frmColaboradores.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
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
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "";
                txtNombre.Value = string.Empty;
                txtApMaterno.Value = string.Empty;
                txtApPaterno.Value = string.Empty;
                txtCorreo.Value = string.Empty;
                txtCodigoPostal.Value = string.Empty;
                
                txtTelefono.Value = string.Empty;
                id_password.Value = string.Empty;
                id_password_again.Value = string.Empty;
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
                ListaGeneros = GN.ObtenerComboGenero(Datos);
            }
            catch (Exception ex)
            {
              
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

       
    }
}