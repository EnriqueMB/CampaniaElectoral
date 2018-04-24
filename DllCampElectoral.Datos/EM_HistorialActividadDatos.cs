using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Datos
{
    public class EM_HistorialActividadDatos
    {
        public List<RR_NuevaActividad> ObtenerHistorialActividad(RR_NuevaActividad Datos)
        {
            try
            {
                List<RR_NuevaActividad> Lista = new List<RR_NuevaActividad>();
                RR_NuevaActividad Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_HistorialActividad");
                while (Dr.Read())
                {
                    Item = new RR_NuevaActividad();
                    Item.IDNuevaAct = Dr.GetString(Dr.GetOrdinal("id_actividadEvento"));
                    Item.NombreActividad = Dr.GetString(Dr.GetOrdinal("nombreEvento"));
                    Item.EncargadoActividad = Dr.GetString(Dr.GetOrdinal("nombreCompleto"));
                    Item.EstatusGeneral = Dr.GetString(Dr.GetOrdinal("estatusGrnl"));
                    Item.DescEstatusGrnl = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.IDTipoActividadEvento = Dr.GetInt32(Dr.GetOrdinal("id_tipoEvento"));
                    Item.EstatusVisto = Dr.GetString(Dr.GetOrdinal("estatusVisto"));
                    Item.DescEstatusVisto = Dr.GetString(Dr.GetOrdinal("icono"));
                    Item.FechaTermino = Dr.GetDateTime(Dr.GetOrdinal("FechaEntrega"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
