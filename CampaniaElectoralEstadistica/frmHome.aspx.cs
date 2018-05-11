using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralEstadistica
{
    public partial class frmHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    DateTime FechaServidor = DateTime.Now;
        //    string centralMexZoneId = "Pacific Standard Time (Mexico)";

        //    //txtHora.Value = string.Format(string.Join("<br>", TimeZoneInfo.GetSystemTimeZones().Select(x => x.Id)));

        //    try
        //    {
        //        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(centralMexZoneId);
        //        TimeZoneInfo ZonaLocal = TimeZoneInfo.Local;
        //        if(!centralMexZoneId.Equals(ZonaLocal.Id))
        //        {
        //            FechaServidor = TimeZoneInfo.ConvertTimeToUtc(FechaServidor, easternZone);
        //        }
        //        txtHora.Value = string.Format("The date and time are {0} UTC.", FechaServidor);
        //    }
        //    catch (TimeZoneNotFoundException)
        //    {
        //        txtHora.Value = string.Format("Unable to find the {0} zone in the registry.", centralMexZoneId);
        //    }
        }
    }
}