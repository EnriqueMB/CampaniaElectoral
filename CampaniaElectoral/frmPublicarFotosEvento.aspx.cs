using CampaniaElectoral.ClasesAux;
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
    public partial class frmPublicarFotosEvento : System.Web.UI.Page
    {
        public List<EC_EventoExtra> Lista = new List<EC_EventoExtra>();
        string ID_evento;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string ID_foto = "";
            CH_Foto Datos = new CH_Foto { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario };
            EC_EventoExtra DatosAux = new EC_EventoExtra { Conexion = Comun.Conexion, id_usuario = Comun.IDUsuario };
            EC_EventoExtraNegocio FN = new EC_EventoExtraNegocio();


            if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id2"] != null)
                {
                    ID_foto = Request.QueryString["id"].ToString();
                    
                    if (Request.QueryString["id"].ToString() == ID_foto)
                    {
                        
                        DatosAux.id_actividadEvento = Request.QueryString["id2"].ToString();
                        DatosAux.id_foto = ID_foto;

                        FN.CargarFotoXID(DatosAux);
                        if (DatosAux.Completado)
                        {
                            
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro agregado a la página correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            
                        }
                        else
                        {
                            
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "No se puede agregar el registro a la página registro.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        Response.Redirect("frmEventosExtraGrid.aspx", false);
                    }
                }
            }
            else if (Request.QueryString["op"] != null && Request.QueryString["op"] == "2")
            {
                if (Request.QueryString["id"] != null)
                {
                    ID_evento = Request.QueryString["id"].ToString();
                    DatosAux.id_actividadEvento = ID_evento;
                    Lista = FN.ObtenerCatalogoFotos(DatosAux);

                }
            }
           
        }
    }
}