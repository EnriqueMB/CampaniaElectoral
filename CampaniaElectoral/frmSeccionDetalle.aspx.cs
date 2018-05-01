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
    public partial class frmSeccionDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    int IDSeccion = 0;
                    int.TryParse(Request.QueryString["id"].ToString(), out IDSeccion);
                    Secciones Datos = new Secciones { IDSeccion = IDSeccion, Conexion = Comun.Conexion };
                    SeccionesNegocio Neg = new SeccionesNegocio();
                    Secciones Result = Neg.ObtenerDetalleSeccion(Datos);
                    if(Result.IDSeccion != -1)
                    {
                        txtEstado.Value = Result.Estado;
                        txtMunicipio.Value = Result.Municipio;
                        hf2.Value = Result.Poligono;
                        hf3.Value = Result.Casillas;
                        spanSeccion.InnerText = Result.IDSeccion.ToString();
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}