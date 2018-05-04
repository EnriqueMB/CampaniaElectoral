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
    public partial class sfrmSeccionesCmb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Request.QueryString["municipio"] != null)
            {
                int  IDMunicipio = 0;
                
                int.TryParse(Request.QueryString["municipio"], out IDMunicipio);

                ER_Secciones Datos = new ER_Secciones();
               
                Datos.IDMunicipio = IDMunicipio;
                Datos.opcion = 9;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                ER_SeccionesNegocio CN = new ER_SeccionesNegocio();
                List<ER_Secciones> Lista = CN.ObtenerComboSecciones(Datos);
                var json = JsonConvert.SerializeObject(Lista);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }
}