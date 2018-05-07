using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmAfiliados : System.Web.UI.Page
    {
        public bool BandDatosCompletados = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["op"] != null)
                {
                    int Opcion = 0;
                    int.TryParse(Request.QueryString["op"], out Opcion);
                    if(Opcion == 1 || Opcion == 2)
                        BandDatosCompletados = (Opcion == 1);
                    else
                        Response.Redirect("ErrorPage.aspx?ErrorMessage=Pagina no disponible");
                }
                else
                    Response.Redirect("ErrorPage.aspx?ErrorMessage=Pagina no disponible");
            }
        }
    }
}