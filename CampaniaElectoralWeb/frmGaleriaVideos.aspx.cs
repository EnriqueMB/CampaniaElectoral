using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoralWeb
{
    public partial class frmGaleriaVideos : System.Web.UI.Page
    {
        public List<GM_VideosLoad> Lista = new List<GM_VideosLoad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarView();
            if (Request.QueryString["errorMessage"] != null)
            {
                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
            }
        }

        public void CargarView()
        {
            try
            {
                GM_VideosLoad Datos = new GM_VideosLoad() { Conexion = Comun.Conexion };
                GM_VideoNegocio GV = new GM_VideoNegocio();
                Lista = GV.ObtenerListStatusVideoPagina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}