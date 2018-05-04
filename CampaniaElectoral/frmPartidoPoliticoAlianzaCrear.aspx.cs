using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class frmPartidoPoliticoAlianzaCrear : System.Web.UI.Page
    {
        protected List<CH_PartidoPolitico> listaPartidosPoliticos = new List<CH_PartidoPolitico>();

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
            }
        }

        private void LoadTablePartidosPoliticos()
        {
            try
            {
                FG_CatPartidoPoliticoAlianza Datos = new FG_CatPartidoPoliticoAlianza { Conexion = Comun.Conexion };
                FG_CatPartidoPoliticoAlianzaNegocio FG = new FG_CatPartidoPoliticoAlianzaNegocio();
                listaPartidosPoliticos = FG.ObtenerListaPartidosPoliticos(Datos);
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