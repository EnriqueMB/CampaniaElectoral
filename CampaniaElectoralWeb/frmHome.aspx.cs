using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CampaniaElectoralWeb
{
    public partial class frmHome : System.Web.UI.Page
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConection");
        public List<RR_Blog> ListaBlog = new List<RR_Blog>();
        public List<GM_LoadBanner> Lista = new List<GM_LoadBanner>();
        public List<RR_DatosHome> ListaHome = new List<RR_DatosHome>();
        public List<EC_EquipoTrabajo> ListaMiembro = new List<EC_EquipoTrabajo>();
        public List<GM_Calendar> ListaEventos = new List<GM_Calendar>();
        public RR_Afiliados DatosAux = new RR_Afiliados();
        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerMiembrosEquipo();
            ObtenerBlogRecientes();
            ObtenerEventos();
            CountAfliado();
            GM_LoadBanner DatosAux = new GM_LoadBanner { Conexion = this.Conexion, IDUsuario = Comun.IDUsuario };
            RR_DatosHome Datos = new RR_DatosHome { Conexion = this.Conexion };
            GM_LoadBannerNegocio FN = new GM_LoadBannerNegocio();
            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null)
                {
                    string AuxID = Request.QueryString["id"].ToString();
                    DatosAux.IDBanner = AuxID;
                    FN.EliminarBannerID(DatosAux);
                    if (DatosAux.Completado)
                    {
                       
                     
                    }
                    else
                    {
                       
                    }
                }
            }
            Lista = FN.ObtenerListaBanner(DatosAux);
            ListaHome = FN.ObtenerListaTextos(Datos);
        }

        private void ObtenerBlogRecientes()
        {
            RR_Blog Datos = new RR_Blog { Conexion = this.Conexion };
            EC_BlogNegocio OBR = new EC_BlogNegocio();
            ListaBlog = OBR.ObtenerBlogsRecientes(Datos);
        }

        private void ObtenerMiembrosEquipo()
        {
            EC_EquipoTrabajo Datos = new EC_EquipoTrabajo { Conexion = this.Conexion };
            EC_EquipoTrabajoNegocio OME = new EC_EquipoTrabajoNegocio();
            ListaMiembro = OME.ObtenerMiembrosEquipo(Datos);
        }
        private void ObtenerEventos()
        {
            GM_Calendar Datos = new GM_Calendar { Conexion = this.Conexion };
            RR_AdministradorWebNegocio AW = new RR_AdministradorWebNegocio();
            ListaEventos = AW.ObtenerEventosCalendario(Datos);
        }
        private void CountAfliado()
        {
            RR_Afiliados Datos = new RR_Afiliados { Conexion = this.Conexion };
            RR_CatalogosNegocio EM = new RR_CatalogosNegocio();
            DatosAux = EM.ObtenerCount(Datos);
        }
    }
}
