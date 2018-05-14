using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralEstadistica
{
    public partial class sfrmObtenerPoligono : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                int IDSeccion = 0;
                int.TryParse(Request.QueryString["id"].ToString(), out IDSeccion);
                                
                EstadisticosAfiliados_Negocio EstNeg = new EstadisticosAfiliados_Negocio();
                object [] resulta = EstNeg.ObtenerPuntosStringXIDSeccion(Comun.Conexion, IDSeccion);

                //json = Iniciar(json);
                //json = json.Substring(1, json.Length - 1);
                var json = JsonConvert.SerializeObject(resulta);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
            else
            {
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(string.Empty);
                Response.End();
            }
        }


        private static Regex _regexUrl = new Regex(@"\[-?\d+.\d+,-?\d+.\d+\]", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private string Iniciar(string value)
        {
            return _regexUrl.Replace(value, QueryStringMatchEvaluator);
        }

        private string QueryStringMatchEvaluator(Match match)
        {
            try
            {
                string point = match.Groups[0].Value;
                string[] paramPos = point.Split(',');
                if (paramPos.Length == 2)
                {
                    string longitud = paramPos[0];
                    string latitud = paramPos[1];
                    longitud = longitud.Replace("[", "");
                    latitud = latitud.Replace("]", "");
                    string newpoint = string.Format("lat:{0}, lng:{1}", latitud, longitud);
                    newpoint = "{" + newpoint + "}";
                    return match.Value.Replace(point, newpoint);
                }
                return match.Value;
            }
            catch (Exception)
            {
                return match.Value;
            }
        }

    }
}