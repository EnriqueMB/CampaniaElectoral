using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

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
            IDAlianza = Request.QueryString["id"];
            if(string.IsNullOrEmpty(IDAlianza))
                Response.Redirect("ErrorPage.aspx?msjError=Verifique los datos de la alianza.", false);

            if (IsPostBack)
            {
                //Editamos
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
            Logo.Src = "data:" + FG.ExtensionBase64 + ";base64, "+ FG.Logo;
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
    }
}