using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class sfrmMunicipios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["estado"] != null)
            {
                int IDEstado = 0;
                int.TryParse(Request.QueryString["estado"], out IDEstado);
                CH_Municipio Datos = new CH_Municipio();
                Datos.IDEstado = IDEstado;
                Datos.Conexion = "Server=tcp:serv-campaniaelectoral.database.windows.net,1433;Initial Catalog=CSLDB_CAMPANIAELECTORAL;Persist Security Info=False;User ID=campaniaAdmin;Password=C4mp4n14373C;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                CH_CatalogosNegocio CN = new CH_CatalogosNegocio();
                List<CH_MunicipioJSON> Lista = CN.ObtenerMunicipiosXIDEstado(Datos);
                //List<CH_MunicipioJSON> Lista = new List<CH_MunicipioJSON>();
                var json = JsonConvert.SerializeObject(Lista);
                Response.Clear();
                Response.ContentType = "application/text;";
                Response.Write(json);
                Response.End();
            }
        }


        //public struct Municipios
        //{
        //    public int IDMunicipio { get; set; }
        //    public string Descripcion { get; set; }
        //}


        //public List<Municipios> ObtenerMunicipiosXIDEstado(int IDEstado)
        //{
        //    List<Municipios> Lista = new List<Municipios>();
        //    switch(IDEstado)
        //    {
        //        case 1:
        //            Lista.Add(new Municipios { IDMunicipio = 201, Descripcion = "Tuxtla Gutierrez" });
        //            Lista.Add(new Municipios { IDMunicipio = 202, Descripcion = "Tonalá" });
        //            Lista.Add(new Municipios { IDMunicipio = 203, Descripcion = "Tapachula" });
        //            Lista.Add(new Municipios { IDMunicipio = 204, Descripcion = "Comitan" });
        //            break;
        //        case 2:
        //            Lista.Add(new Municipios { IDMunicipio = 300, Descripcion = "QR01" });
        //            Lista.Add(new Municipios { IDMunicipio = 301, Descripcion = "QR02" });
        //            Lista.Add(new Municipios { IDMunicipio = 302, Descripcion = "QR03" });
        //            Lista.Add(new Municipios { IDMunicipio = 303, Descripcion = "QR04" });
        //            break;
        //        case 3:
        //            Lista.Add(new Municipios { IDMunicipio = 400, Descripcion = "SLP01" });
        //            Lista.Add(new Municipios { IDMunicipio = 401, Descripcion = "SLP02" });
        //            Lista.Add(new Municipios { IDMunicipio = 402, Descripcion = "SLP03" });
        //            Lista.Add(new Municipios { IDMunicipio = 403, Descripcion = "SLP04" });
        //            break;
        //    }
        //    return Lista;
        //}
    }
}