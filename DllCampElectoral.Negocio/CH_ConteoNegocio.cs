using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_ConteoNegocio
    {
        public void ObtenerDetalleCapturaXID(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                CD.ObtenerDetalleCapturaXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACDetalleCapturaXID(CH_Conteo Datos, string id_seccion,string id_casilla,string id_colaborador)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                CD.ACDetalleCapturaXID(Datos, id_seccion,id_casilla,id_colaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void ACDetalleCapturaXID(CH_Conteo Datos)
        //{
        //    try
        //    {
        //        CH_ConteoDatos CD = new CH_ConteoDatos();
        //        CD.ACDetalleCapturaXID(Datos);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        public List<CH_Conteo> ObtenerCapturas(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                return CD.ObtenerCapturas(Datos);   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCaptura(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                CD.EliminarCaptura(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validarconteo(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                CD.Validarconteo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Conteo> ObtenerCapturaPrepValidacion(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                return CD.ObtenerCapturasParaValidar(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GraficaDeConteoPrep(CH_Conteo Datos)
        {
            try
            {
                CH_ConteoDatos CD = new CH_ConteoDatos();
                CD.ObtenerDatosGraficaConteoPrep(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
