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

namespace CampaniaElectoral
{
    public partial class frmPartidoPoliticoAlianzaCrear : System.Web.UI.Page
    {
        private List<CH_PartidoPolitico> listaPartidosPoliticos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.Validate();
                if (!this.IsValid)
                {
                    string msg = "";
                    // Loop through all validation controls to see which
                    // generated the errors.
                    foreach (IValidator aValidator in this.Validators)
                    {
                        if (!aValidator.IsValid)
                        {
                            msg += "<br />" + aValidator.ErrorMessage;
                        }
                    }
                    //Label1.Text = msg;
                }
                else
                {
                    string nombreAlianza, siglas, stringLogoBase64
                           , listaPartidosSeleccionados = string.Empty;

                    nombreAlianza   = txtNombre.Text;
                    siglas          = txtSigla.Text;

                    foreach (ListItem listItem in cmbPartidosPoliticos.Items)
                    {
                        if (listItem.Selected)
                        {
                            var val = listItem.Value;
                            var txt = listItem.Text;
                            listaPartidosSeleccionados += listItem.Value + ",";
                        }
                    }

                    if (imgLogo.HasFile) //Hay imagen
                    {
                        int size = imgLogo.PostedFile.ContentLength;
                        byte[] ImagenOriginal = new byte[size];
                        imgLogo.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                        Bitmap ImagenOriginalBinaria = new Bitmap(imgLogo.PostedFile.InputStream);
                        string extension = Path.GetExtension(imgLogo.FileName);
                        ImageFormat imageFormateExtension = FG_Auxiliar.ObtenerExtensionImageFormat(extension);
                        if(imageFormateExtension != null)
                            stringLogoBase64 = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, imageFormateExtension);
                    }
                }
            }
            else
            {
                IniciarDatos();
            }
        }

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

                for (int i = 0; i < listaPartidosPoliticos.Count; i++)
                {
                    cmbPartidosPoliticos.Items[i].Attributes.Add("data-thumbnail", "data:" + listaPartidosPoliticos[i].ExtensionLogo + ";base64, " + listaPartidosPoliticos[i].Logo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void ValidarImagenExtension(object source, ServerValidateEventArgs args)
        {
            var archivo = args.Value;
            if (archivo != null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            //args.IsValid = (args.Value.Length >= 8);
        }
    }
}