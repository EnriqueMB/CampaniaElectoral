using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public class EC_EventoExtraDatos
    {
        public List<EC_EventoExtra> CargarGrid(EC_EventoExtra Datos)
        {
            try
            {
                List<EC_EventoExtra> Lista = new List<EC_EventoExtra>();
                EC_EventoExtra Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_EventoExtra");
                while (Dr.Read())
                {
                    Item = new EC_EventoExtra();
                    Item.id_actividadEvento = Dr.GetString(Dr.GetOrdinal(("id_actividadEvento")));
                    Item.tituloPagina = Dr.GetString(Dr.GetOrdinal("nombreEvento"));
                    Item.fecha = Dr.GetDateTime(Dr.GetOrdinal("fecha"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<EC_EventoExtra> ObtenerCatalogoFotos(EC_EventoExtra Datos)
        {
            try
            {
                List<EC_EventoExtra> Lista = new List<EC_EventoExtra>();
                EC_EventoExtra Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_GaleriaFotosXIDEventoExtra",Datos.id_actividadEvento);
                while (Dr.Read())
                {
                    Item = new EC_EventoExtra();
                    Item.IDFoto = Dr.GetString(Dr.GetOrdinal("IDFoto"));
                    Item.URLImagen = Dr.GetString(Dr.GetOrdinal("UrlFoto"));
                    Item.Alt = Dr.GetString(Dr.GetOrdinal("TextoAlternativo"));
                    Item.Title = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.NombreArchivo = Dr.GetString(Dr.GetOrdinal("NombreArchivo"));
                    Item.Extension = Dr.GetString(Dr.GetOrdinal("TipoArchivo"));
                    Item.id_actividadEvento= Dr.GetString(Dr.GetOrdinal("id_Evento"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargaFotoXID(EC_EventoExtra Datos)
        {
            
            
            try
            {
                object[] Parametros = { Datos.id_actividadEvento, Datos.id_foto,Datos.id_usuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EC_spCSLDB_AC_EventoExtra", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                else
                {
                    Datos.Completado = false;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
