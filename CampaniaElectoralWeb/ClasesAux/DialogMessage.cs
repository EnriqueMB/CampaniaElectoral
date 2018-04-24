using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaniaElectoral.ClasesAux
{

    public enum TipoMensaje
    {
        Error = 1,
        Success = 2,
        Warning = 3,
        Info = 4
    }

    public enum ShowMethod
    {        
        FadeIn = 1,
        SlideDown = 2,
        Show = 3
    }

    public enum HideMethod
    {
        FadeOut = 1
    }

    public enum ShowEasing
    {        
        Swing = 1,
        Linear = 2
    }
    
    public enum HideEasing
    {
        Swing = 1,
        Linear = 2
    }
    
    public enum ToastPosition
    {
        //toast-top-right
        TopRight = 1,
        //toast-bottom-right
        BottomRight = 2,
        //toast-bottom-left
        BottomLeft = 3,
        //toast-top-left" 
        TopLeft = 4,
        //toast-top-full-width
        TopFullWidth = 5,
        //toast-bottom-full-width
        BottomFullWidth = 6
    }

    public class DialogMessage
    {
        public static string Show(TipoMensaje Tipo, string msg, string title, int showDuration, 
            int hideDuration, int timeOut, int extendedTimeout, ShowMethod sMethod, HideMethod hMethod, 
            ShowEasing sEasing, HideEasing hEasing, ToastPosition tPosition, bool btnCerrar)
        {
            string shortCutFunction = GetTipo(Tipo);
            string showEasing = GetShowEasing(sEasing); 
            string hideEasing = GetHideEasing(hEasing);
            string showMethod = GetShowMethod(sMethod);
            string hideMethod = GetHideMethod(hMethod);
            string position = GetPosition(tPosition);
            int toastIndex = 0;

            string ScriptError =
                   @"
                    $(document).ready(
                        function() { MensajeError('" + shortCutFunction + "', '"
                                + msg + "', '"
                                + title + "', "
                                + showDuration + ", "
                                + hideDuration + ", "
                                + timeOut + ", "
                                + extendedTimeout + ", '"
                                + showEasing + "', '"
                                + hideEasing + "', '"
                                + showMethod + "', '"
                                + hideMethod + "', "
                                + toastIndex + ", '"
                                + btnCerrar.ToString().ToLower() + "', '"
                                + position + @"');});";
            return ScriptError;
        }

        public static string Show(TipoMensaje Tipo, string msg, string title, ShowMethod sMethod, HideMethod hMethod,
            ShowEasing sEasing, HideEasing hEasing, ToastPosition tPosition, bool btnCerrar)
        {
            string shortCutFunction = GetTipo(Tipo);
            string showEasing = GetShowEasing(sEasing);
            string hideEasing = GetHideEasing(hEasing);
            string showMethod = GetShowMethod(sMethod);
            string hideMethod = GetHideMethod(hMethod);
            string position = GetPosition(tPosition);
            int toastIndex = 0;
            int showDuration = 1000;
            int hideDuration = 1000;
            int timeOut = 2000;
            int extendedTimeout = 1000;

            string ScriptError =
                   @"
                    $(document).ready(
                        function() { MensajeError('" + shortCutFunction + "', '"
                                + msg + "', '"
                                + title + "', "
                                + showDuration + ", "
                                + hideDuration + ", "
                                + timeOut + ", "
                                + extendedTimeout + ", '"
                                + showEasing + "', '"
                                + hideEasing + "', '"
                                + showMethod + "', '"
                                + hideMethod + "', "
                                + toastIndex + ", '"
                                + btnCerrar.ToString().ToLower() + "', '"
                                + position + @"');});";
            return ScriptError;
        }

        public static string Show(TipoMensaje Tipo, string msg, string title, ShowMethod sMethod, HideMethod hMethod, ToastPosition tPosition, bool btnCerrar)
        {
            string shortCutFunction = GetTipo(Tipo);
            string showMethod = GetShowMethod(sMethod);
            string hideMethod = GetHideMethod(hMethod);
            string position = GetPosition(tPosition);
            int toastIndex = 0;
            int showDuration = 1000;
            int hideDuration = 1000;
            int timeOut = 2000;
            int extendedTimeout = 1000;
            string showEasing = "swing";
            string hideEasing = "linear";

            string ScriptError =
                   @"
                    $(document).ready(
                        function() { MensajeError('" + shortCutFunction + "', '"
                                + msg + "', '"
                                + title + "', "
                                + showDuration + ", "
                                + hideDuration + ", "
                                + timeOut + ", "
                                + extendedTimeout + ", '"
                                + showEasing + "', '"
                                + hideEasing + "', '"
                                + showMethod + "', '"
                                + hideMethod + "', "
                                + toastIndex + ", '"
                                + btnCerrar.ToString().ToLower() + "', '"
                                + position + @"');});";
            return ScriptError;
        }

        private static string GetTipo(TipoMensaje t)
        {
            string Tipo = "";
            switch(t)
            {
                case TipoMensaje.Error:
                    Tipo = "error";
                    break;
                case TipoMensaje.Success:
                    Tipo = "success";
                    break;
                case TipoMensaje.Warning:
                    Tipo = "warning";
                    break;
                case TipoMensaje.Info:
                    Tipo = "info";
                    break;
            }
            return Tipo;
        }
        
        private static string GetShowMethod(ShowMethod t)
        {
            string Tipo = "";
            switch (t)
            {
                case ShowMethod.FadeIn:
                    Tipo = "fadeIn";
                    break;
                case ShowMethod.SlideDown:
                    Tipo = "slideDown";
                    break;
                case ShowMethod.Show:
                    Tipo = "show";
                    break;
            }
            return Tipo;
        }
        
        private static string GetHideMethod(HideMethod t)
        {
            string Tipo = "";
            switch (t)
            {
                case HideMethod.FadeOut:
                    Tipo = "fadeOut";
                    break;
            }
            return Tipo;
        }
        
        private static string GetShowEasing(ShowEasing t)
        {
            string Tipo = "";
            switch (t)
            {
                case ShowEasing.Swing:
                    Tipo = "swing";
                    break;
                case ShowEasing.Linear:
                    Tipo = "linear";
                    break;
            }
            return Tipo;
        }
        
        private static string GetHideEasing(HideEasing t)
        {
            string Tipo = "";
            switch (t)
            {
                case HideEasing.Swing:
                    Tipo = "swing";
                    break;
                case HideEasing.Linear:
                    Tipo = "linear";
                    break;
            }
            return Tipo;
        }
        
        private static string GetPosition(ToastPosition t)
        {
            string Tipo = "";
            switch (t)
            {
                case ToastPosition.TopRight:
                    Tipo = "toast-top-right";
                    break;
                case ToastPosition.BottomRight:
                    Tipo = "toast-bottom-right";
                    break;
                case ToastPosition.BottomLeft:
                    Tipo = "toast-bottom-left";
                    break;
                case ToastPosition.TopLeft:
                    Tipo = "toast-top-left";
                    break;
                case ToastPosition.TopFullWidth:
                    Tipo = "toast-top-full-width";
                    break;
                case ToastPosition.BottomFullWidth:
                    Tipo = "toast-bottom-full-width";
                    break;
            }
            return Tipo;
        }
    }
}