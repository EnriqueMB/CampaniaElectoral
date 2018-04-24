using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;

namespace CampaniaElectoralWeb
{
    public partial class frmDescEvento : System.Web.UI.Page
    {
        public List<CH_Evento> Lista = new List<CH_Evento>();
        public List<GM_Calendar> ListaEventos = new List<GM_Calendar>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            ObtenerEventos();
                            string ID = Request.QueryString["id"].ToString();
                            CH_Evento Datos = new CH_Evento { Conexion = Comun.Conexion, IDEvento = ID };
                            RR_AdministradorWebNegocio AWN = new RR_AdministradorWebNegocio();
                            Lista = AWN.ObtenerEventosDesc(Datos);
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {
            }
        }
        private void ObtenerEventos()
        {
            GM_Calendar Datos = new GM_Calendar { Conexion = Comun.Conexion };
            RR_AdministradorWebNegocio AW = new RR_AdministradorWebNegocio();
            ListaEventos = AW.ObtenerEventosCalendario2(Datos);
        }
    }
}