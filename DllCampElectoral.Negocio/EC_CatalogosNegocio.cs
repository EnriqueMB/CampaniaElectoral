using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Datos;
using DllCampElectoral.Global;

namespace DllCampElectoral.Negocio
{
   public class EC_CatalogosNegocio
    {
        public List<EC_ColaboradorJSON> ObtenerColaboradorXIDPoligono(CH_Poligono Datos)
        {
            try
            {
                EC_CatalogoDatos CD = new EC_CatalogoDatos();
                return CD.ObtenerColaboradorXIDPoligono(Datos);
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
                EC_CatalogoDatos PD = new EC_CatalogoDatos();
                return PD.ObtenerComboPoligonos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerPoligonoAfiliados(CH_Poligono Datos)
        {
            try
            {
                EC_CatalogoDatos PD = new EC_CatalogoDatos();
                PD.ObtenerPoligonoAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetImagenesAfiliados(RR_Afiliados Datos)
        {
            try
            {
                EC_CatalogoDatos PD = new EC_CatalogoDatos();
                PD.GetImagenesAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
