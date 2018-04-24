using DllCampElectoral.Datos;
using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
    public class CH_PoligonoNegocio
    {
        #region  Poligonos

        public void ACPoligono(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.ACPoligono(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void APuntosPoligono(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.APuntosPoligono(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Poligono> ObtenerListaPoligonos(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                return PD.ObtenerListaPoligonos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Poligono> ObtenerPuntosPoligonos(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                return PD.ObtenerPuntosPoligonos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerDetallePoligonoXID(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.ObtenerDetallePoligonoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerDetallePoligonoXIDResumen(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.ObtenerDetallePoligonoXIDResumen(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void EliminarPoligonoXID(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.EliminarPoligonoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPuntoPoligonoXID(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.EliminarPuntoPoligonoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Poligono> ObtenerComboPoligonos(CH_Poligono Datos)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                return PD.ObtenerComboPoligonos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboSeccion(CH_Poligono poligono)
        {
            try
            {
                CH_PoligonoDatos PD = new CH_PoligonoDatos();
                PD.ObtenerComboPoligono(poligono);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
