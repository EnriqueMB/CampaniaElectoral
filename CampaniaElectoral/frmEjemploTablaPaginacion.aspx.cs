using CampaniaElectoral.ClasesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmEjemploTablaPaginacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {

            }
            else
            {
                //string shortCutFunction = "error";
                //string msg = "Error al capturar los datos";
                //string title = "Error";
                //int showDuration = 1000;
                //int hideDuration = 1000;
                //int timeOut = 2000;
                //int extendedTimeout = 1000;
                //string showEasing = "swing";
                //string hideEasing = "linear";
                //string showMethod = "fadeIn";
                //string hideMethod = "fadeOut";
                //string position = "toast-bottom-right";
                //int toastIndex = 0;
                //bool btnCerrar = true;
                //string ScriptError =
                //    @"
                //        $(document).ready(
                //           function() { MensajeError('" + shortCutFunction + "', '"
                //                    + msg + "', '"
                //                    + title + "', "
                //                    + showDuration + ", "
                //                    + hideDuration + ", "
                //                    + timeOut + ", "
                //                    + extendedTimeout + ", '"
                //                    + showEasing + "', '"
                //                    + hideEasing + "', '"
                //                    + showMethod + "', '"
                //                    + hideMethod + "', "
                //                    + toastIndex + ", '"
                //                    + btnCerrar.ToString().ToLower() + "', '"
                //                    + position + @"');});";

                //string ScriptMessage =
                //    @"<script>
                //    jQuery(document).ready(function() {
                //            UINotifications.init('"
                //                    + shortCutFunction + "', '"
                //                    + msg + "', '"
                //                    + title + "', "
                //                    + showDuration + ", "
                //                    + hideDuration + ", "
                //                    + timeOut + ", "
                //                    + extendedTimeout + ", '"
                //                    + showEasing + "', '"
                //                    + hideEasing + "', '"
                //                    + showMethod + "', '"
                //                    + hideMethod + "', "
                //                    + toastIndex + ", '"
                //                    + btnCerrar.ToString().ToLower() + @"'
                //                )
                //        });
                //</script> ";

                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                

                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                ///Response.(ScriptMessage);
            }

        }

        

    }
}