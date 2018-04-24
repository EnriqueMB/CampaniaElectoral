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
    public partial class sfrmPuntosPoligono : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string ID = Request.QueryString["id"].ToString();
                CH_Poligono DatosAux = new CH_Poligono { IDPoligono = ID, Conexion = Comun.Conexion, EsPrincipal= true };
                CH_PoligonoNegocio PN = new CH_PoligonoNegocio();
                List<CH_Poligono> Lista = PN.ObtenerPuntosPoligonos(DatosAux);
                Puntos _Aux;
                CultureInfo esMX = new CultureInfo("es-MX");
                List<Puntos> Puntos = new List<Puntos>();
                foreach (CH_Poligono Item in Lista)
                {
                    _Aux = new Puntos {
                        //IDPunto = Item.IDPunto,
                        //LatLng = Item.Latidud.ToString().Replace(",",".") + ", " + Item.Longitud.ToString().Replace(",", ".")//,
                        lat=Item.Latidud,
                        lng=Item.Longitud
                        //Orden = Item.OrdenPunto
                    };
                    Puntos.Add(_Aux);
                }

                //Polygon _DatosAux = new Polygon { type="Polygon", coordinates = Puntos};

                var json = JsonConvert.SerializeObject(Puntos);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }
    }

    public struct Polygon
    {
        public string type { get; set; }
        public List<Puntos> coordinates { get; set; }
    }

    public struct Puntos
    {
        //public string IDPunto { get; set; }
        //public string LatLng { get; set; }
        //public int Orden { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}