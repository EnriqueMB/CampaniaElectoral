using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public class JL_ColaboradorDatos
    {
        public void ObteberComboColaborador(EM_CatColaborador colaborador)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(colaborador.Conexion, "JL_spCSLDB_get_ComboColaboradoresXIDPoligono", colaborador.IDPoligono);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            colaborador.TablaDatos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(colaborador.Conexion, "JL_spCSLDB_get_ComboColaboradoresXIDPoligono-UNO", colaborador.IDPoligono,colaborador.IDColaborador);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            colaborador.TablaDatos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
