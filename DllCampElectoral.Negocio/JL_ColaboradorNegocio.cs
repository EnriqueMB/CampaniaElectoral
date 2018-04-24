using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class JL_ColaboradorNegocio
    {
        public void ObteberComboColaborador(EM_CatColaborador colaborador)
        {
            try
            {
                JL_ColaboradorDatos CD = new JL_ColaboradorDatos();
                CD.ObteberComboColaborador(colaborador);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ObteberComboColaboradorMenosUno(EM_CatColaborador colaborador)
        {
            try
            {
                JL_ColaboradorDatos CD = new JL_ColaboradorDatos();
                CD.ObteberComboColaboradorMenosUno(colaborador);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
