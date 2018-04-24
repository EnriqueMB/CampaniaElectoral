using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CampaniaElectoralWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public List<GM_PlanCampania> Lista = new List<GM_PlanCampania>();
        protected void Page_Load(object sender, EventArgs e)
        {
            GM_PlanCampania DatosAux = new GM_PlanCampania { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_CarreraPoliticaNegocio FN = new GM_CarreraPoliticaNegocio();    
              
                if (Request.QueryString["id"] != null)
                {
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosAux.IDPElectoral = AuxID;
                    Lista = FN.ObtenerProyectoCampania(DatosAux);
                }
        }
    }
}