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
    public partial class frmResultadoPregunta : System.Web.UI.Page
    {
        public CH_Encuesta DatosAux = new CH_Encuesta();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null)
                {
                    string IDEncuesta = Request.QueryString["id2"].ToString();
                    string IDPregunta = Request.QueryString["id"].ToString();
                    this.hf.Value = IDPregunta;
                    this.hfIDEncuesta.Value = IDEncuesta;
                    DatosAux.Conexion = Comun.Conexion;
                    DatosAux.IDPregunta = IDPregunta;                    
                    CH_EncuestaNegocio EN = new CH_EncuestaNegocio();
                    EN.ObtenerDatosMapaResultado(DatosAux);
                    string Estado = DatosAux.EstadoDesc;
                    string Municipio = DatosAux.MunicipioDesc;
                    if (DatosAux.Completado)
                    {
                        string ScriptError =
                           @"   jQuery(document).ready(function() {
                        Maps.init('" + Estado + "', '" + Municipio + @"');
                        });";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                    }
                    else
                    {
                        Response.Redirect("frmPreguntas.aspx", false);
                    }
                }
            }
            catch(Exception)
            {

            }
        }
    }
}