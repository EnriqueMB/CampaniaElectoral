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
    public partial class sfrmDetallePoligono : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDPoligono"] != null)
            {
                string IDPoligono = Request.QueryString["IDPoligono"].ToString();

                CH_Poligono Datos = new CH_Poligono();
                Datos.IDPoligono = IDPoligono;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                CH_PoligonoNegocio CN = new CH_PoligonoNegocio();
                CN.ObtenerDetallePoligonoXID(Datos);

                CH_PoligonoDetalleJSON DatosAux = new CH_PoligonoDetalleJSON { Latitud = Datos.Latidud, Longitud = Datos.Longitud };

                var json = JsonConvert.SerializeObject(DatosAux);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }
}