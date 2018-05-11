using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralEstadistica
{
    public partial class frmEvaluacionRepresentantes : System.Web.UI.Page
    {
        public string CssClass = string.Empty;
        public int Tipo = 0;
        public string Texto = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["tipo"] != null)
                {
                    int.TryParse(Request.QueryString["tipo"], out Tipo);
                    if (Tipo > 0 && Tipo <= 5)
                    {
                        CssClass = ObtenerClass(Tipo);
                        Texto = ObtenerTextoTítulo(Tipo);
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx?ErrorMessage=Parametros_Incorrectos");
                    }
                }
                else
                    Response.Redirect("ErrorPage.aspx?ErrorMessage=Pagina no disponible");
            }
        }

        private string ObtenerClass(int Tipo)
        {
            try
            {
                string cssStyleClass = string.Empty;
                switch(Tipo)
                {
                    case 1:
                        cssStyleClass = "progress-bar-danger";
                        break;
                    case 2:
                        cssStyleClass = "progress-bar-warning";
                        break;
                    case 3:
                        cssStyleClass = "progress-bar-info";
                        break;
                    case 4:
                        cssStyleClass = "progress-bar-primary";
                        break;
                    case 5:
                        cssStyleClass = "progress-bar-success";
                        break;
                    default:
                        break;
                }
                return cssStyleClass;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerTextoTítulo(int Tipo)
        {
            try
            {
                string textoTitulo = string.Empty;
                switch (Tipo)
                {
                    case 1:
                        textoTitulo = "menor productividad";
                        break;
                    case 2:
                        textoTitulo = "baja productividad";
                        break;
                    case 3:
                        textoTitulo = "media productividad";
                        break;
                    case 4:
                        textoTitulo = "alta productividad";
                        break;
                    case 5:
                        textoTitulo = "excelente productividad";
                        break;
                    default:
                        break;
                }
                return textoTitulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}