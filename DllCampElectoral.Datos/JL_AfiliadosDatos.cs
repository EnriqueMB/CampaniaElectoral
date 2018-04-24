using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace DllCampElectoral.Datos
{
    public class JL_AfiliadosDatos
    {
        public List<RR_Afiliados> ObtenerListaAfiliados(RR_Afiliados afiliadosDatos)
        {
            List<RR_Afiliados> afiliados = new List<RR_Afiliados>();

            RR_Afiliados item;
            SqlDataReader Dr = SqlHelper.ExecuteReader(afiliadosDatos.Conexion, "JL_spCSLDB_get_AfiliadosXIDOperador", afiliadosDatos.IDColaborador);
            while (Dr.Read())
            {
                item = new RR_Afiliados();
                item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                item.IDAfiliado = Dr.GetString(Dr.GetOrdinal("IDAfiliado"));
                afiliados.Add(item);
            }

            return afiliados;
        }

        public void TransferirAfiliados(RR_Afiliados afiliados, DataTable dataTable)
        {
            try
            {
                object result = SqlHelper.ExecuteScalar(afiliados.Conexion,
                    CommandType.StoredProcedure, "JL_spCSLDB_set_catAfiliados",
                    new SqlParameter("@IDColaborador", afiliados.IDColaborador),
                    new SqlParameter("@TablaTemp", dataTable));
                if (result != null)
                {
                    afiliados.Completado = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ObtenerComboAfiliados(RR_Afiliados afiliados)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(afiliados.Conexion, "JL_spCSLDB_get_ComboAfiliados", afiliados.IDPoligono);
                if (ds!=null)
                {
                    if (ds.Tables.Count>0)
                    {
                        if (ds.Tables[0]!=null)
                        {
                            afiliados.TablaDatos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(afiliados.Conexion, "JL_spCSLDB_A_tblvotosConfirmados", afiliados.IDColaborador, afiliados.IDAfiliado, afiliados.ImagenVoto, afiliados.IDUsuario);
                if (ds!=null)
                {
                    if (ds.Tables.Count>0)
                    {
                        if (ds.Tables[0]!=null)
                        {
                            afiliados.Completado = true;
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
