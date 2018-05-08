using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmPartidoPoliticoAlianzaCrear : System.Web.UI.Page
    {
        private List<CH_PartidoPolitico> listaPartidosPoliticos;
        private FG_CatPartidoPoliticoAlianzaNegocio FG_Negocio = new FG_CatPartidoPoliticoAlianzaNegocio();
        private FG_CatPartidoPoliticoAlianza FG = new FG_CatPartidoPoliticoAlianza();

        protected void Page_Load(object sender, EventArgs e)
        {
            var resultado = Request.QueryString["resultado"];
            var mensaje = Request.QueryString["mensaje"];

            if (!(string.IsNullOrEmpty(resultado) && string.IsNullOrEmpty(mensaje)))
                Mensaje(mensaje, resultado);

            if (this.IsPostBack)
            {
                this.Validate();
                if (!this.IsValid)
                {
                    string msg = "";
                    // Loop through all validation controls to see which generated the errors.
                    foreach (IValidator aValidator in this.Validators)
                    {
                        if (!aValidator.IsValid)
                        {
                            msg += "<br />" + aValidator.ErrorMessage;
                        }
                    }
                }
                else
                {
                    //creamos la alianza
                    //Obtenemos los datos del formulario
                    //Guardamos la alianza   
                    try
                    {
                        ObtenerDatos();
                        FG = FG_Negocio.CrearAlianza(FG);
                        Response.Redirect("frmPartidosPoliticosAlianzasGrid.aspx?resultado=" + FG.Completado+"&mensaje=" + FG.Mensaje + "" ,false);
                    }
                    catch(Exception ex)
                    {
                        string mensajeEx;
                        mensajeEx = ex.Message.Replace("\r\n", string.Empty);
                        Response.Redirect("frmPartidoPoliticoAlianzaCrear.aspx?resultado=0&mensaje=" + mensajeEx);
                    }
                    
                }
            }
            else
            {
                IniciarDatos();
            }
        }
        #region Funciones
        private void IniciarDatos()
        {
            try
            {
                LoadCmbPartidosPoliticos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadCmbPartidosPoliticos()
        {
            try
            {

                FG_CatPartidoPoliticoAlianza Datos = new FG_CatPartidoPoliticoAlianza { Conexion = Comun.Conexion };
                FG_CatPartidoPoliticoAlianzaNegocio FG = new FG_CatPartidoPoliticoAlianzaNegocio();
                listaPartidosPoliticos = FG.ObtenerListaPartidosPoliticos(Datos);
                cmbPartidosPoliticos.DataSource = listaPartidosPoliticos;
                cmbPartidosPoliticos.DataValueField = "IDPartido";
                cmbPartidosPoliticos.DataTextField = "Nombre";
                cmbPartidosPoliticos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ObtenerDatos()
        {
            string PartidosSeleccionados = string.Empty;

            foreach (ListItem listItem in cmbPartidosPoliticos.Items)
            {
                if (listItem.Selected)
                {
                    var val = listItem.Value;
                    var txt = listItem.Text;
                    PartidosSeleccionados += listItem.Value + ",";
                }
            }
            this.FG.Nombre = txtNombre.Text;
            this.FG.Siglas = txtSigla.Text;
            this.FG.PartidosPoliticos = PartidosSeleccionados;
            this.FG.Usuario = User.Identity.Name;
            this.FG.Conexion = Comun.Conexion;

            if (imgLogo.HasFile) //Hay imagen
            {
                int size = imgLogo.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[size];
                imgLogo.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                Bitmap ImagenOriginalBinaria = new Bitmap(imgLogo.PostedFile.InputStream);
                string extension = Path.GetExtension(imgLogo.FileName);
                ImageFormat imageFormateExtension = FG_Auxiliar.ObtenerExtensionImageFormat(extension);
                if (imageFormateExtension != null)
                    this.FG.Logo = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, imageFormateExtension);
            }
        }
        #endregion
        #region Validaciones
        protected void ValidarImagenExtension(object source, ServerValidateEventArgs args)
        {
            var archivo = args.Value.Trim();
            valExtensionLogo.ForeColor = Color.Red;

            args.IsValid = false;

            if (!string.IsNullOrEmpty(archivo))
            {
                string[] substring = archivo.Split('.');
                int cantSubstring = substring.Count();
                string[] extensiones =
                {
                "png"
                ,"PNG"
                ,"jpg"
                ,"JPG"
                ,"jpeg"
                ,"JPEG"
                ,"bmp"
                ,"BMP"
            };

                string extensionArchivo = substring[cantSubstring - 1];

                for (int i = 0; i < extensiones.Count(); i++)
                {
                    if (string.Equals(extensiones[i], extensionArchivo))
                    {
                        args.IsValid = true;
                        break;
                    }
                }
                valExtensionLogo.ErrorMessage = "Por favor, seleccione otra imagen formato no válido, solo arhivos png, jpg, jpeg y bmp.";
            }
            else
            {
                valExtensionLogo.ErrorMessage = "Por favor, seleccione una imagen, solo arhivos png, jpg, jpeg y bmp.";
                args.IsValid = false;
            }
        }
        #endregion
        #region mostrar mensaje
        private void Mensaje(string mensaje, string resultado)
        {
            switch (resultado)
            {
                case "1":
                        MensajeValido(mensaje);
                        break;
                case "True":
                    MensajeValido(mensaje);
                    break;
                case "0":
                        MensajeError(mensaje);
                        break;
                case "False":
                    MensajeError(mensaje);
                    break;
            }
        }
        private void MensajeError(string mensaje)
        {
            string ScriptError = DialogMessage.Show(TipoMensaje.Error, mensaje, "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "error", ScriptError, true);
        }
        private void MensajeValido(string mensaje)
        {
            string ScriptError = DialogMessage.Show(TipoMensaje.Success, mensaje, "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "valido", ScriptError, true);
        }
        #endregion
    }
}