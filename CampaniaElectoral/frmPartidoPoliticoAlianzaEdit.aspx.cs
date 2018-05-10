using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System.Drawing.Imaging;
using System.IO;

namespace CampaniaElectoral
{
    public partial class frmPartidoPoliticoAlianzaEdit : System.Web.UI.Page
    {
        private FG_CatPartidoPoliticoAlianza FG;
        private FG_CatPartidoPoliticoAlianzaNegocio FG_Negocio;
        private List<CH_PartidoPolitico> PartidosPoliticos;
        string IDAlianza;
        protected void Page_Load(object sender, EventArgs e)
        {
            IDAlianza = Request["id"];
            if(string.IsNullOrEmpty(IDAlianza))
                Response.Redirect("ErrorPage.aspx?msjError=Verifique los datos de la alianza.", false);

            if (IsPostBack)
            {
                //Editamos
                this.Validate();
                if (this.IsValid)
                {
                    EditarAlianza();
                }
            }
            else
            {
                //Cargamos los datos
                CargarDatosAlianza();
                CargarCombos();
            }
        }
        #region Funciones
        private void CargarDatosAlianza()
        {
            FG = new FG_CatPartidoPoliticoAlianza();
            FG_Negocio = new FG_CatPartidoPoliticoAlianzaNegocio();
            FG.Conexion = Comun.Conexion;
            FG.IDPartidoPoliticoAlianza = int.Parse(IDAlianza);
            FG = FG_Negocio.ObtenerDatosAlianza(FG);

            txtNombre.Text = FG.Nombre;
            txtSigla.Text = FG.Siglas;
            txtIDAlianza.Value = FG.IDPartidoPoliticoAlianza.ToString();
            Logo.Src = "data:" + FG.ExtensionBase64 + ";base64, "+ FG.Logo;
            Logo.Attributes.Add("data-src", FG.Logo);
            imgLogo.Attributes.Add("data-imagenserver", FG.ImagenServer.ToString());
        }
        private void CargarCombos()
        {
            string[] idPartidos = FG.PartidosPoliticos.Split(',');
            PartidosPoliticos = new List<CH_PartidoPolitico>();
            PartidosPoliticos = FG_Negocio.ObtenerListaPartidosPoliticos(FG);

            cmbPartidosPoliticos.DataSource = PartidosPoliticos;
            cmbPartidosPoliticos.DataValueField = "IDPartido";
            cmbPartidosPoliticos.DataTextField = "Nombre";
            cmbPartidosPoliticos.DataBind();

            for (int indexCmb = 0; indexCmb < cmbPartidosPoliticos.Items.Count; indexCmb++)
            {
                for (int indexIDPartido = 0; indexIDPartido < idPartidos.Length; indexIDPartido++)
                {
                    string idItem = cmbPartidosPoliticos.Items[indexCmb].Value.Trim();
                    string idPartido = idPartidos[indexIDPartido].Trim();
                    if (string.Equals(idItem, idPartido))
                    {
                        cmbPartidosPoliticos.Items[indexCmb].Selected = true;
                        idPartidos = idPartidos.Where((val, idx) => idx != indexIDPartido).ToArray();
                        break;
                    }
                    else
                    {
                        cmbPartidosPoliticos.Items[indexCmb].Selected = false;
                    }
                }
            }

        }
        private void EditarAlianza()
        {
            try
            {
                FG = new FG_CatPartidoPoliticoAlianza();
                FG_Negocio = new FG_CatPartidoPoliticoAlianzaNegocio();

                FG = ObtenerFormulario();
                FG = FG_Negocio.EditarAlianza(FG);

                Response.Redirect("frmPartidosPoliticosAlianzasGrid.aspx?resultado=" + FG.Completado + "&mensaje=" + FG.Mensaje + "", false);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                error = error.Replace("\r\n", string.Empty);

                Response.Redirect("frmPartidosPoliticosAlianzasGrid.aspx?resultado=" + FG.Completado + "&mensaje=" + error + "", false);
            }

        }
        private FG_CatPartidoPoliticoAlianza ObtenerFormulario()
        {
            FG_CatPartidoPoliticoAlianza DatosFormulario = new FG_CatPartidoPoliticoAlianza();
            DatosFormulario.IDPartidoPoliticoAlianza = int.Parse(txtIDAlianza.Value);
            DatosFormulario.Nombre = txtNombre.Text;
            DatosFormulario.Siglas = txtSigla.Text;
            DatosFormulario.Usuario = User.Identity.Name;
            DatosFormulario.Conexion = Comun.Conexion;

            foreach (ListItem item in cmbPartidosPoliticos.Items)
            {
                if (item.Selected)
                {
                    DatosFormulario.PartidosPoliticos += item.Value + ",";
                }
            }
            if (imgLogo.HasFile)
            {
                int size = imgLogo.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[size];
                imgLogo.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                Bitmap ImagenOriginalBinaria = new Bitmap(imgLogo.PostedFile.InputStream);
                string extension = Path.GetExtension(imgLogo.FileName);
                ImageFormat imageFormateExtension = FG_Auxiliar.ObtenerExtensionImageFormat(extension);
                if (imageFormateExtension != null)
                    DatosFormulario.Logo = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, imageFormateExtension);
            }
            else
            {
                DatosFormulario.Logo = Logo.Attributes["data-src"];
            }            


            return DatosFormulario;
        }
        #endregion
        #region Validaciones
        protected void ValidarImagenExtension(object source, ServerValidateEventArgs args)
        {
            bool imgServer;
                bool.TryParse(imgLogo.Attributes["data-imagenserver"], out imgServer);

            var archivo = args.Value.Trim();
            valExtensionLogo.ForeColor = Color.Red;

            args.IsValid = false;
            valExtensionLogo.ErrorMessage = "Por favor, seleccione otra imagen formato no válido, solo arhivos png, jpg, jpeg y bmp.";

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
               
            }
            else if (imgServer)
            {
                args.IsValid = true;
            }
        }
        #endregion
    }
}