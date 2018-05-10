using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmPartidosPoliticosAlianzasGrid : System.Web.UI.Page
    {
        public List<FG_CatPartidoPoliticoAlianza> listaAlianzas = new List<FG_CatPartidoPoliticoAlianza>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var op = Request.QueryString["op"];
            var resultado = Request.QueryString["resultado"];
            var mensaje = Request.QueryString["mensaje"];

            if (!(string.IsNullOrEmpty(resultado) && string.IsNullOrEmpty(mensaje)))
                Mensaje(mensaje, resultado);

            switch (op)
            {
                case "1":
                    eliminarAlianza();
                    break;
                default:
                    cargarGrid();
                    break;
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
        
        private void cargarGrid()
        {
            try
            {
                FG_CatPartidoPoliticoAlianza Datos = new FG_CatPartidoPoliticoAlianza { Conexion = Comun.Conexion };
                FG_CatPartidoPoliticoAlianzaNegocio FG = new FG_CatPartidoPoliticoAlianzaNegocio();
                listaAlianzas = FG.ObtenerListaPartidosPoliticosAlianza(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void eliminarAlianza()
        {
            try
            {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        FG_CatPartidoPoliticoAlianza Datos = new FG_CatPartidoPoliticoAlianza
                        {
                            Conexion = Comun.Conexion
                            ,IDPartidoPoliticoAlianza = AuxID
                            ,Usuario = User.Identity.Name
                        };
                        FG_CatPartidoPoliticoAlianzaNegocio FG = new FG_CatPartidoPoliticoAlianzaNegocio();

                        Datos = FG.EliminarAlianza(Datos);
                        
                        Response.Redirect("frmPartidosPoliticosAlianzasGrid.aspx?resultado="+Datos.Completado+"&mensaje=" + Datos.Mensaje, false);
                    }
            }
            catch (Exception ex)
            {
                string mensajeEx;
                mensajeEx = ex.Message.Replace("\r\n", string.Empty);
                Response.Redirect("frmPartidosPoliticosAlianzasGrid.aspx?resultado=False&mensaje=" + mensajeEx, false);
            }
        }
    }
}