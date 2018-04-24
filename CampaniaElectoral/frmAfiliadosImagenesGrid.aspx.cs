using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace CampaniaElectoral
{
    public partial class frmAfiliadosImagenesGrid : System.Web.UI.Page
    {
        public List<ZM_ImagenesAfiliados> Lista = new List<ZM_ImagenesAfiliados>();
        public string nombre;
        public string nombre1;
        public string nombre2;

        private static string _idAfiliado;

        public static string IdAfiliado
        {
            get { return _idAfiliado; }
            set { _idAfiliado = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string AuxID = Request.QueryString["id"];
                        //int.TryParse(Request.QueryString["id"], out AuxID);
                        ZM_ImagenesAfiliados Datos = new ZM_ImagenesAfiliados { Conexion = Comun.Conexion, IdImagenAfiliado = AuxID};
                        ZM_CatalogosNegocio CN = new ZM_CatalogosNegocio();
                        CN.EliminarImagenAfiliado(Datos);
                        if (Datos.Completado)
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            Response.Redirect("frmAfiliadosImagenesGrid.aspx?id=" + IdAfiliado + "", false);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
               
                if (!IsPostBack)
                {
                    
                }
                else
                {
                    
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
                ZM_ImagenesAfiliados Datos = new ZM_ImagenesAfiliados() { Conexion = Comun.Conexion };
                ZM_CatalogosNegocio GN = new ZM_CatalogosNegocio();
                if (Request.QueryString["id"] != null)
                {
                    IdAfiliado = Request.QueryString["id"];
                    Datos.IdAfiliado = Request.QueryString["id"];
                    Lista = GN.ObtenerCatalogoImagenes(Datos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}