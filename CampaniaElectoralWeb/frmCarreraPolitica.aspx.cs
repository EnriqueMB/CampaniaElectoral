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
    public partial class frmCarreraPolitica : System.Web.UI.Page
    {
        public GM_CarreraPolitica DatosAdmin = new GM_CarreraPolitica();
        public List<GM_CarreraPolitica> Lista = new List<GM_CarreraPolitica>();
        protected void Page_Load(object sender, EventArgs e)
        {
            GM_CarreraPolitica DatosAux = new GM_CarreraPolitica { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            GM_CarreraPoliticaNegocio FN = new GM_CarreraPoliticaNegocio();
            Lista = FN.ObtenerListCarreraPolitica(DatosAux);
            DatosAdmin = FN.ObtenerCarrerapoliticaTexto(DatosAux);

        }
    }
}