using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;
using System.Data;

namespace DllCampElectoral.Negocio
{
    public class JL_AfiliadosNegocio
    {
        public List<RR_Afiliados> ObtenerListaAfiliados(RR_Afiliados afiliados)
        {
            try
            {
                JL_AfiliadosDatos AD = new JL_AfiliadosDatos();
                return AD.ObtenerListaAfiliados(afiliados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void TransferirAfiliados(RR_Afiliados afiliados, DataTable dataTable)
        {
            try
            {
                JL_AfiliadosDatos AD = new JL_AfiliadosDatos();
                AD.TransferirAfiliados(afiliados,dataTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ObtenerComboAfiliado(RR_Afiliados afiliados)
        {
            try
            {
                JL_AfiliadosDatos AD = new JL_AfiliadosDatos();
                AD.ObtenerComboAfiliados(afiliados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ConfirmarVoto(RR_Afiliados afiliados)
        {
            try
            {
                JL_AfiliadosDatos AD = new JL_AfiliadosDatos();
                AD.ConfirmarVoto(afiliados);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
