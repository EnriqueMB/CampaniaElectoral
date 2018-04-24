using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using Newtonsoft.Json;

namespace CampaniaElectoral
{
    public partial class sfrmOperadorPolitico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["poligono"] != null)
            {
                string IDSeccion = Request.QueryString["poligono"];

                CH_Poligono Datos = new CH_Poligono();
                Datos.IDPoligono = IDSeccion;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                EC_CatalogosNegocio CN = new EC_CatalogosNegocio();
                List<EC_ColaboradorJSON> Lista = CN.ObtenerColaboradorXIDPoligono(Datos);
                var json = JsonConvert.SerializeObject(Lista);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }
}