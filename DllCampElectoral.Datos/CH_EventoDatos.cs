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
    public class CH_EventoDatos
    {


        public void ACCatalogoEventos(CH_Evento Datos)
        {
            try
            {
                object[] Parametros = {
                    Datos.NuevoRegistro, Datos.IDEvento, Datos.Nombre, Datos.IDColaborador, Datos.FechaInicio,
                    Datos.HoraInicio, Datos.FechaTermino, Datos.HoraTermino, Datos.Observaciones, Datos.Meta,
                    Datos.MensajeEncargado, Datos.TituloPagina, Datos.TextoPagina, Datos.FechaEvento, Datos.HoraEvento,
                    Datos.IDEstado, Datos.IDMunicipio, Datos.Direccion, Datos.Latitud, Datos.Longitud, Datos.Publicar,
                    Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_Eventos", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Evento> ObtenerCatalogoEventos(CH_Evento Datos)
        {
            try
            {
                List<CH_Evento> Lista = new List<CH_Evento>();
                CH_Evento Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_PartidosPoliticos");
                while (Dr.Read())
                {
                    Item = new CH_Evento();
                    //Item.IDPartido = Dr.GetInt32(Dr.GetOrdinal("IDPartido"));
                    //Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    //Item.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    //Item.UrlLogo = Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                    //Item.RGBColor = Dr.GetString(Dr.GetOrdinal("Color"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleEventoXID(CH_Evento Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEvento };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "", Parametros);
                while (Dr.Read())
                {
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    //Datos.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    //Datos.UrlLogo = Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                    //Datos.RGBColor = Dr.GetString(Dr.GetOrdinal("Color"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEventoXID(CH_Evento Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEvento, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_Evento", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if (Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<CH_EventoJSON> ObtenerEventosCalendario(CH_Evento Datos)
        {
            try
            {
                List<CH_EventoJSON> Lista = new List<CH_EventoJSON>();
                CH_EventoJSON Item;
                object[] Parametros = { Datos.IDColaborador, Datos.FechaInicio, Datos.FechaTermino, Datos.IDTipoEvento };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_EventosXIDColaborador", Parametros);
                while(Dr.Read())
                {
                    Item = new CH_EventoJSON();
                    Item.id = Dr.GetString(Dr.GetOrdinal("IDEvento"));
                    Item.title = Dr.GetString(Dr.GetOrdinal("NombreEvento"));
                    DateTime FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("FechaInicio"));
                    string HoraInicio = Dr.GetString(Dr.GetOrdinal("HoraInicio"));
                    DateTime FechaFin = Dr.GetDateTime(Dr.GetOrdinal("FechaTermino"));
                    string HoraFin = Dr.GetString(Dr.GetOrdinal("HoraTermino"));

                    Item.start = FechaInicio.ToString("yyyy-MM-dd") + "T" + HoraInicio;
                    Item.end = FechaFin.ToString("yyyy-MM-dd") + "T" + HoraFin;
                    Item.allDay = false;
                    
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
