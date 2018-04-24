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
    public partial class frmCredencialImagen : System.Web.UI.Page
    {
        public RR_Afiliados img = new RR_Afiliados();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "1")
                {
                    int opcion = 1;
                    if (Request.QueryString["id"] != null)
                    {
                        id = Request.QueryString["id"];
                        this.Cargar(opcion);
                        txtTexto.Value = img.CredencialFrente;
                    }
                }
                else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "2")
                {
                    int opcion = 2;
                    if (Request.QueryString["id"] != null)
                    {
                        id = Request.QueryString["id"];
                        this.Cargar(opcion);
                        txtTexto.Value = img.CredencialFrente;
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
            
            
        }

        private void Cargar(int opcion)
        {
            try
            {
                img.Conexion = Comun.Conexion;
                img.IDAfiliado = id;
                img.opcion = opcion;
                EC_CatalogosNegocio CN = new EC_CatalogosNegocio();
                CN.GetImagenesAfiliados(img);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}