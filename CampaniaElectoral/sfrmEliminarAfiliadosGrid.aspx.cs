using CampaniaElectoral.ClasesAux;
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
    public partial class sfrmEliminarAfiliadosGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string AuxID = string.Empty;
           
            if (Request.QueryString["id"] != null)
             AuxID = Request.QueryString["id"].ToString();
             RR_Afiliados Datos = new RR_Afiliados { Conexion = Comun.Conexion, IDAfiliado = AuxID, IDUsuario = Comun.IDUsuario };
             RR_CatalogosNegocio CN = new RR_CatalogosNegocio();

            var json="";
           CN.EliminarAfiliadoXID(Datos);
               if (Datos.Completado)
            {
                 json = "Exito";
            }
            else
            {
                json = "Error";
            }
            JsonConvert.SerializeObject(json);
            Response.Clear();
            Response.ContentType = "application/text;";
            Response.Write(json);
            Response.End();

            //}

        }
    }
}