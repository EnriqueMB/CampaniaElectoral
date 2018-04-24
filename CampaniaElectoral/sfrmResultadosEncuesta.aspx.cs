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
    public partial class sfrmResultadosEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDEncuesta"] != null && Request.QueryString["IDPregunta"] != null)
            {
                string IDEncuesta = Request.QueryString["IDEncuesta"].ToString();
                string IDPregunta = Request.QueryString["IDPregunta"].ToString();

                CH_Encuesta Datos = new CH_Encuesta();
                Datos.IDEncuesta = IDEncuesta;
                Datos.IDPregunta = IDPregunta;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                CH_EncuestaNegocio CN = new CH_EncuestaNegocio();
                List<CH_ResultadoEncuestaJSON> Lista = CN.ObtenerPoligonosXEncuesta(Datos);

                var json = JsonConvert.SerializeObject(Lista);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }
}