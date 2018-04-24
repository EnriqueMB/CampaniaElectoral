using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class sfrmPoligonos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["estado"] != null && Request.QueryString["municipio"] != null)
            {
                int IDEstado = 0, IDMunicipio = 0;
                int.TryParse(Request.QueryString["estado"], out IDEstado);
                int.TryParse(Request.QueryString["municipio"], out IDMunicipio);

                CH_Poligono Datos = new CH_Poligono();
                Datos.IDEstado = IDEstado;
                Datos.IDMunicipio = IDMunicipio;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                List<CH_PoligonoJSON> Lista = CN.ObtenerPoligonosXIDEstadoMunicipio(Datos);
                var json = JsonConvert.SerializeObject(Lista);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }
}