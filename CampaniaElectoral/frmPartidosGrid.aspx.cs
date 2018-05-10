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
    public partial class frmPartidosGrid : System.Web.UI.Page
    {
        public List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var op = Request.QueryString["op"];
                var resultado = Request.QueryString["resultado"];
                var mensaje = Request.QueryString["mensaje"];

                if (!(string.IsNullOrEmpty(resultado) && string.IsNullOrEmpty(mensaje)))
                    Mensaje(mensaje, resultado);


                if (op != null && op == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        CH_PartidoPolitico Datos = new CH_PartidoPolitico { Conexion = Comun.Conexion, IDPartido = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                        CN.EliminarPartidoXID(Datos);
                        Response.Redirect("frmPartidosGrid.aspx?resultado=" + Datos.Completado + "&mensaje=" + Datos.Nombre, false);
                    }
                }

                this.CargarGrid();
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }

        public void CargarGrid()
        {
            try
            {
                CH_PartidoPolitico Datos = new CH_PartidoPolitico { Conexion = Comun.Conexion };
                CH_CatalogosNegocio GN = new CH_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoPartidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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