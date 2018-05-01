using DllCampElectoral.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CampaniaElectoral
{
    public partial class sfrmSecciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["data"] != null)
                {
                    string data = Request.Form["data"].ToString();
                    var req = DataTableParameters.Get(data);
                    var resultSet = new DataTableResultSet();
                    
                    resultSet.draw = req.Draw;
                    resultSet.recordsTotal = 20;
                    resultSet.recordsFiltered = 20;

                    //foreach (var recordFromDb in queryDb)
                    //{ /* this is pseudocode */
                    //    var columns = new List<string>();
                    //    columns.Add("first column value");
                    //    columns.Add("second column value");
                    //    columns.Add("third column value");
                    //    /* you may add as many columns as you need. Each column is a string in the List<string> */
                    //    resultSet.data.Add(columns);
                    //}
                    SendResponse(HttpContext.Current.Response, resultSet);
                }
            }
        }

        private static void SendResponse(HttpResponse response, DataTableResultSet result)
        {
            response.Clear();
            response.Headers.Add("X-Content-Type-Options", "nosniff");
            response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            response.ContentType = "application/json; charset=utf-8";
            response.Write(result.ToJSON());
            response.Flush();
            response.End();
        }

    }
}