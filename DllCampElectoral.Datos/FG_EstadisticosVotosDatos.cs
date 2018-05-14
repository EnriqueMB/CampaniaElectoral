using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public class FG_EstadisticosVotosDatos
    {
        public int ObtenerMetaVotosGeneral(FG_EstadisticosVotos FG)
        {
            try
            {
                int MetaVotosGeneral = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(FG.Conexion, "FG_spCSLDB_EstadisticoVotos_MetaGeneral");
                while (Dr.Read())
                {
                    MetaVotosGeneral = Dr.GetInt32(Dr.GetOrdinal("TotalMetaVotos"));
                }
                return MetaVotosGeneral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerTotalVotosRealizados(FG_EstadisticosVotos FG)
        {
            try
            {
                int TotalVotosRealizados = 0;
                SqlDataReader Dr = SqlHelper.ExecuteReader(FG.Conexion, "FG_spCSLDB_EstadisticoVotos_TotalVotosRealizados");
                while (Dr.Read())
                {
                    TotalVotosRealizados = Dr.GetInt32(Dr.GetOrdinal("TotalVotosRealizados"));
                }
                return TotalVotosRealizados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FG_EstadisticosVotos_MetaXHora> ObtenerListaMetasXHora(FG_EstadisticosVotos FG)
        {
            try
            {
                List<FG_EstadisticosVotos_MetaXHora> listaMetasXHora = new List<FG_EstadisticosVotos_MetaXHora>();
                FG_EstadisticosVotos_MetaXHora item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(FG.Conexion, "FG_spCSLDB_EstadisticoVotos_MetasXHora");

                while (Dr.Read())
                {
                    item = new FG_EstadisticosVotos_MetaXHora();
                    item.Hora = Dr.GetTimeSpan(Dr.GetOrdinal("horaEstablecida"));
                    item.Meta = Dr.GetDecimal(Dr.GetOrdinal("metaEstablecida"));
                    item.ColorEtiqueta = Dr.GetString(Dr.GetOrdinal("colorEtiqueta"));

                    listaMetasXHora.Add(item);
                }
                return listaMetasXHora;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FG_EstadisticosVotos ObtenerGeneralesEstadisticosVotacion(FG_EstadisticosVotos FG)
        {

            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(FG.Conexion, "FG_spCSLBD_EstadisticoVotos_DatosGenerales");

                while (Dr.Read())
                {
                    FG.MetaVotosGeneral = Dr.GetInt32(Dr.GetOrdinal("totalMetaVotos"));
                    FG.TotalVotosRealizados = Dr.GetInt32(Dr.GetOrdinal("totalVotosRealizados"));
                    FG.PorcentajeAvanceGeneralVotos = Dr.GetDecimal(Dr.GetOrdinal("porcentajeAvanceGeneral"));
                    FG.sMetasXHora = Dr.GetString(Dr.GetOrdinal("xmlMetasXHora"));
                    FG.sTop5Colaboradores = Dr.GetString(Dr.GetOrdinal("xmlTop5Colaboradores"));
                    FG.sMensajAvanceGeneral = Dr.GetString(Dr.GetOrdinal("xlmMensajeAvanceGeneral"));
                }

                return FG;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
