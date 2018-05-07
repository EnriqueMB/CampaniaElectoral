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
            var realizado = Request.QueryString["realizado"];
            var tipoMsj = Request.QueryString["tipoMsj"];
            var mensaje = Request.QueryString["mensaje"];

            if (!(string.IsNullOrEmpty(tipoMsj) && string.IsNullOrEmpty(tipoMsj) && string.IsNullOrEmpty(tipoMsj)))
                Mensaje(tipoMsj, mensaje, realizado);

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
        private void Mensaje(string tipoMensaje, string mensaje, string realizado)
        {
            switch (realizado)
            {
                case "1":
                    switch (tipoMensaje)
                    {
                        case "Eliminado":
                            MensajeValido(mensaje);
                            break;
                        default:
                            break;
                    }
                    break;
                case "0":
                    switch (tipoMensaje)
                    {
                        case "Eliminado":
                            MensajeError(mensaje);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
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
                        CH_PartidoPolitico Datos = new CH_PartidoPolitico { Conexion = Comun.Conexion, IDPartido = AuxID, IDUsuario = Comun.IDUsuario };
                        CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                        CN.EliminarPartidoXID(Datos);
                        if (Datos.Completado)
                        {
                            //Mostrar mensaje Success
                        }
                        else
                        {
                            //Mostrar Mensaje de error
                        }
                    }
                
                
                
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
    }
}