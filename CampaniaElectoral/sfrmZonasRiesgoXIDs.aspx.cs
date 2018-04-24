using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class sfrmZonasRiesgoXIDs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDEstado"] != null && Request.QueryString["IDMunicipio"] != null && Request.QueryString["IDPoligono"] != null)
            {
                try
                {
                    int IDEstado = -1, IDMunicipio = -1;
                    int.TryParse(Request.QueryString["IDEstado"].ToString(), out IDEstado);
                    int.TryParse(Request.QueryString["IDMunicipio"].ToString(), out IDMunicipio);
                    string IDPoligono = Request.QueryString["IDPoligono"].ToString();
                    CH_ZonaRiesgo DatosAux = new CH_ZonaRiesgo { IDEstado = IDEstado, IDMunicipio = IDMunicipio, IDPoligono = IDPoligono };
                    DatosAux.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    CH_ZonaRiesgoNegocio ZRN = new CH_ZonaRiesgoNegocio();
                    List<CH_ZonaRiesgo> Lista = ZRN.ObtenerRiesgosXIDs(DatosAux);
                    RiesgosStruct _Aux;
                    CultureInfo esMX = new CultureInfo("es-MX");
                    List<RiesgosStruct> Riesgos = new List<RiesgosStruct>();
                    foreach (CH_ZonaRiesgo Item in Lista)
                    {
                        _Aux = new RiesgosStruct
                        {
                            IDRiesgo = Item.IDZonaRiesgo,
                            Lat = Item.Latitud,
                            Lng = Item.Longitud,
                            Titulo = Item.Titulo,
                            IDTipo = Item.IDTipoRiesgo,
                            Descripcion = Item.Descripcion,
                            UrlIcon = Item.UrlIcon
                        };
                        Riesgos.Add(_Aux);
                    }
                    var json = JsonConvert.SerializeObject(Riesgos);
                    Response.Clear();
                    Response.ContentType = "application/text;";
                    Response.Write(json);
                    Response.End();
                }
                catch (Exception) { }
            }
        }
    }
    
    public struct RiesgosStruct
    {
        public string IDRiesgo { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Titulo { get; set; }
        public int IDTipo { get; set; }
        public string Descripcion { get; set; }
        public string UrlIcon { get; set; }
    }
}