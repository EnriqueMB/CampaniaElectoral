using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmNuevoAuxiliar : System.Web.UI.Page
    {
        public List<CH_Genero> Lista = new List<CH_Genero>();
        public List<RR_TipoUsuarios> ListaTU = new List<RR_TipoUsuarios>();
        public List<EM_CatColaborador> ListaColaborador = new List<EM_CatColaborador>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarComboGenero();
            //this.CargarComboTipoUsuario();
            this.CargarComboColaboradores();
            if (!IsPostBack)
            {
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
                                EM_CatColaborador DatosAux = new EM_CatColaborador { Conexion = Comun.Conexion, IDColaborador = ID };
                                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                                CN.ObtenerDetalleColaboradoresAuxiliarXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmAuxiliarGrid.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmAuxiliarGrid.aspx", false);
                            }
                        }
                        else
                            Response.Redirect("frmAuxiliarGrid.aspx", false);
                    }
                    else
                        Response.Redirect("frmAuxiliarGrid.aspx", false);
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 15 || Request.Form.Count == 16 || Request.Form.Count == 17 || Request.Form.Count == 18)
                {
                    CultureInfo esMX = new CultureInfo("es-MX");
                    int IDGenero = 0, IDTipoUsuario = 3;
                    DateTime txtFechaNac;
                    bool Band = false;
                    if (imgImagen.HasFile) //Hay cambio de imagen
                    {
                        Band = true;
                    }
                    string txtNomb = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                    string txtApPaterno = Request.Form["ctl00$cph_MasterBody$txtApPaterno"].ToString();
                    string txtApMaterno = Request.Form["ctl00$cph_MasterBody$txtApMaterno"].ToString();
                    string txtCorreo = Request.Form["ctl00$cph_MasterBody$txtCorreo"].ToString();
                    string txtTelefono = Request.Form["ctl00$cph_MasterBody$txtTelefono"].ToString();
                    string txtPassword = Request.Form["ctl00$cph_MasterBody$id_password"].ToString();
                    string txtPasswordConfi = Request.Form["ctl00$cph_MasterBody$id_password_again"].ToString();
                    DateTime.TryParseExact(Request.Form["ctl00$cph_MasterBody$txtFechaNac"].ToString(), "dd-MM-yyyy", esMX, System.Globalization.DateTimeStyles.None, out txtFechaNac);
                    string txtCP = Request.Form["ctl00$cph_MasterBody$txtCodigoPostal"].ToString();
                    string txtCuidad = Request.Form["ctl00$cph_MasterBody$txtCuidad"].ToString();
                    int.TryParse(Request.Form["form-field-select-3"].ToString(), out IDGenero);
                    //int.TryParse(Request.Form["txtTipoUsuario"].ToString(), out IDTipoUsuario);
                    string IDColaboradorAux = Request.Form["cmbEncargado"].ToString();
                    string txtUrlImg = Band ? imgImagen.PostedFile.FileName : string.Empty;
                    string IDColaborador = "";
                    HttpPostedFile bannerImage = imgImagen.PostedFile as HttpPostedFile;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDColaborador = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDColaborador);
                        this.Guardar(NuevoRegistro, IDColaborador, IDColaboradorAux, txtNomb, txtApPaterno, txtApMaterno, txtCorreo, txtTelefono, txtPassword, txtFechaNac,
                            txtCP, txtCuidad, IDGenero, IDTipoUsuario, txtUrlImg, bannerImage, Band);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message, false);
                    }

                }
            }
        }
        #region Métodos

        public void CargarComboColaboradores()
        {
            try
            {
                EM_CatColaborador Datos = new EM_CatColaborador { Conexion = Comun.Conexion };
                EM_CatalagosNegocio GN = new EM_CatalagosNegocio();
                ListaColaborador = GN.ObtenerComboColaboradores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarDatos(EM_CatColaborador DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDColaborador.ToString();
                txtNombre.Value = DatosAux.Nombre;
                txtApPaterno.Value = DatosAux.ApPaterno;
                txtApMaterno.Value = DatosAux.ApMaterno;
                txtCorreo.Value = DatosAux.Correo;
                txtTelefono.Value = DatosAux.Telefono;
                txtFechaNac.Value = DatosAux.FechaNac.ToString("dd-MM-yyyy");
                id_password.Value = DatosAux.Password;
                id_password_again.Value = DatosAux.Password;
                txtCodigoPostal.Value = DatosAux.CodigoPostal;
                txtCuidad.Value = DatosAux.Cuidad;
               
                string BaseDir = Server.MapPath("");
                if (File.Exists(BaseDir + DatosAux.UrlImagen))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", DatosAux.UrlImagen);
                }
                else
                {

                }
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('form-field-select-3').value=" + DatosAux.IDGenero + @";
                        document.getElementById('cmbEncargado').value='" + DatosAux.IDColaboradorAux + @"';
                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string IDColaboradores, string Nombre, string ApPat, string ApMat, string Correo, string Telefono, string Password, DateTime FechasNac,
                            string CodigoPostal, string Cuidad, int IDGenero, int IDTipoUsu, string FileName, HttpPostedFile PostedImage, bool BandCambioImagen)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName) : string.Empty;
                EM_CatColaborador Datos = new EM_CatColaborador
                {
                    NuevoRegistro = NuevoRegistro,
                    IDColaborador = ID,
                    IDColaboradorAux = IDColaboradores,
                    Nombre = Nombre,
                    ApPaterno = ApPat,
                    ApMaterno = ApMat,
                    Correo = Correo,
                    Telefono = Telefono,
                    Password = Password,
                    FechaNac = FechasNac,
                    CodigoPostal = CodigoPostal,
                    Cuidad = Cuidad,
                    IDGenero = IDGenero,
                    IDTipoUsu = IDTipoUsu,
                    ExtrancionImagen = FileExtension,
                    CambiarImagen = BandCambioImagen,
                    UrlImagen = FileName,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                CN.ACCatalogoColaboradoresAUx(Datos);
                if (Datos.Completado)
                {
                    if (BandCambioImagen)
                    {
                        if (PostedImage != null && PostedImage.ContentLength > 0)
                        {
                            try
                            {
                                Stream S = PostedImage.InputStream;
                                System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                                Img.Save(BaseDir + Datos.UrlImagen);
                                CN.ImagenSubidaColaboradroXID(Datos);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    Response.Redirect("frmAuxiliarGrid.aspx", false);
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
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "";
                txtNombre.Value = string.Empty;
                txtApMaterno.Value = string.Empty;
                txtApPaterno.Value = string.Empty;
                txtCorreo.Value = string.Empty;
                txtCodigoPostal.Value = string.Empty;
                txtCuidad.Value = string.Empty;
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
                Lista = GN.ObtenerComboGenero(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarComboTipoUsuario()
        {
            try
            {
                RR_TipoUsuarios Datos = new RR_TipoUsuarios { Conexion = Comun.Conexion };
                EM_CatalagosNegocio CN = new EM_CatalagosNegocio();
                ListaTU = CN.ObtenerComboTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}