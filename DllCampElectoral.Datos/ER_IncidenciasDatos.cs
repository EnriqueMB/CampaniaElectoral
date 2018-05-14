using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class ER_IncidenciasDatos
    {
        public void obtenerIncidencias(ER_Incidencias Datos) {
            try
            {
                
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "ER_spCSLDB_get_Riesgos");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        
                        while (Dr.Read())
                        {
                            
                            Datos.Riesgos = Dr.GetString(Dr.GetOrdinal("Riesgos"));
                            
                        }
                       
                       DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<ER_Incidencias> Lista = new List<ER_Incidencias>();
                        ER_Incidencias Item;
                        while (Dr2.Read())
                            {
                                Item = new ER_Incidencias();
                                Item.titulo = Dr2.GetString(Dr2.GetOrdinal("titulo"));
                                Item.tipoRiesgo = Dr2.GetString(Dr2.GetOrdinal("tipoRiesgo"));
                            Item.estado = Dr2.GetString(Dr2.GetOrdinal("Estado"));
                            Item.municipio = Dr2.GetString(Dr2.GetOrdinal("Municipio"));
                            Item.casilla = Dr2.GetString(Dr2.GetOrdinal("casilla"));
                            Item.domicilio = Dr2.GetString(Dr2.GetOrdinal("domicilio"));
                                Item.referencia = Dr2.GetString(Dr2.GetOrdinal("referencia"));
                            Item.encargado = Dr2.GetString(Dr2.GetOrdinal("encargado"));
                         
                                
                                Lista.Add(Item);
                            }
                            Datos.listaIncidencias = Lista;
                        
                        Datos.Completado = true;
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
