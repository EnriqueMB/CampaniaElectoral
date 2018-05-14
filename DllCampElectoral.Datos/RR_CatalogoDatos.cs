using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace DllCampElectoral.Datos
{
    public class RR_CatalogoDatos
    {
        #region Catalogo Grado Estudios

        public void ACCatalogoGradoEstudios(RR_GradoEstudios Datos)
        {
            try
            {
                object[] Parametros = {Datos.NuevoRegistro, Datos.IDGradoEstudios, Datos.Descripcion, Datos.IDUsuario};
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_GradoEstudios", Parametros);
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

        public List<RR_GradoEstudios> ObtenerCatalogoGradoEstudio(RR_GradoEstudios Datos)
        {
            try
            {
                List<RR_GradoEstudios> Lista = new List<RR_GradoEstudios>();
                RR_GradoEstudios Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_GradoEstudios");
                while (Dr.Read())
                {
                    Item = new RR_GradoEstudios();
                    Item.IDGradoEstudios = Dr.GetInt32(Dr.GetOrdinal(("IDGradoEstudios")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void ObtenerDetalleXID(RR_GradoEstudios Datos)
        {
            try
            {
                object[] Parametros = {Datos.IDGradoEstudios};
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_GradoEstdDetalle",Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGradoEstudioXID(RR_GradoEstudios Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDGradoEstudios, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_GradoEstudios", Parametros);
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

        #endregion

        #region Indicador Encuestas

        public void ACCatalogoIndicadorEncuestas(RR_IndicadorEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDIndicadorEncuesta, Datos.Descripcion, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_IndicadorEncuestas", Parametros);
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

        public List<RR_IndicadorEncuestas> ObtenerCatalogoIndicadorEncuestas(RR_IndicadorEncuestas Datos)
        {
            try
            {
                List<RR_IndicadorEncuestas> Lista = new List<RR_IndicadorEncuestas>();
                RR_IndicadorEncuestas Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_IndicadorEncuestas");
                while (Dr.Read())
                {
                    Item = new RR_IndicadorEncuestas();
                    Item.IDIndicadorEncuesta = Dr.GetInt32(Dr.GetOrdinal(("IDIndicadorEncuesta")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleEncuestasXID(RR_IndicadorEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDIndicadorEncuesta };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_IndicadorEncuestaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuestasXID(RR_IndicadorEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDIndicadorEncuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_IndicadorEncuestas", Parametros);
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

        #endregion

        #region Tipo Eveto Agenda

        public void ACCatalogoTipoEventoAgenda(RR_TipoEventoAgenda Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTipoEventoAgenda, Datos.Descripcion, Datos.Siglas, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_TipoEventosAgendas", Parametros);
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

        public List<RR_TipoEventoAgenda> ObtenerCatalogoTipoEventoAgenda(RR_TipoEventoAgenda Datos)
        {
            try
            {
                List<RR_TipoEventoAgenda> Lista = new List<RR_TipoEventoAgenda>();
                RR_TipoEventoAgenda Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoEventoAgenda");
                while (Dr.Read())
                {
                    Item = new RR_TipoEventoAgenda();
                    Item.IDTipoEventoAgenda = Dr.GetInt32(Dr.GetOrdinal(("IDTipoEvento")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleTipoEventoAgendaXID(RR_TipoEventoAgenda Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoEventoAgenda };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoEventoAgendaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Siglas = Dr.GetString(Dr.GetOrdinal("siglas"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoEventoAgendaXID(RR_TipoEventoAgenda Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoEventoAgenda, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_TipoEventosAgenda", Parametros);
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

        #endregion

        #region Tipo Riesgo

        public void ACCatalogoTipoRiesgo(RR_TipoRiesgos Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTipoRiesgo, Datos.Descripcion, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_TipoRiesgos", Parametros);
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

        public List<RR_TipoRiesgos> ObtenerCatalogoTipoRiesgo(RR_TipoRiesgos Datos)
        {
            try
            {
                List<RR_TipoRiesgos> Lista = new List<RR_TipoRiesgos>();
                RR_TipoRiesgos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoRiesgo");
                while (Dr.Read())
                {
                    Item = new RR_TipoRiesgos();
                    Item.IDTipoRiesgo = Dr.GetInt32(Dr.GetOrdinal(("IDTipoRiesgo")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleTipoRiesgoXID(RR_TipoRiesgos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoRiesgo };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoRiesgoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoRiesgoXID(RR_TipoRiesgos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoRiesgo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_TipoRiesgo", Parametros);
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

        #endregion

        #region Tipo Gasto

        public void ACCatalogoTipoGasto(RR_TipoGastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTipoGasto, Datos.Descripcion, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_TipoGastos", Parametros);
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

        public List<RR_TipoGastos> ObtenerCatalogoTipoGasto(RR_TipoGastos Datos)
        {
            try
            {
                List<RR_TipoGastos> Lista = new List<RR_TipoGastos>();
                RR_TipoGastos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoGastos");
                while (Dr.Read())
                {
                    Item = new RR_TipoGastos();
                    Item.IDTipoGasto = Dr.GetInt32(Dr.GetOrdinal(("IDTipoGastos")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleTipoGastoXID(RR_TipoGastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoGasto };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoGastosDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoGastoXID(RR_TipoGastos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTipoGasto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_TipoGastos", Parametros);
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

        #endregion

        #region Status Proyecto

        public void ACCatalogoStatusProyecto(RR_StatusProyecto Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDProyecto, Datos.Descripcion, Datos.ColorStatus, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_StatusProyecto", Parametros);
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

        public List<RR_StatusProyecto> ObtenerCatalogoStatusProyecto(RR_StatusProyecto Datos)
        {
            try
            {
                List<RR_StatusProyecto> Lista = new List<RR_StatusProyecto>();
                RR_StatusProyecto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusProyecto");
                while (Dr.Read())
                {
                    Item = new RR_StatusProyecto();
                    Item.IDProyecto = Dr.GetInt32(Dr.GetOrdinal(("id_statusProyecto")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleStatusProyectoXID(RR_StatusProyecto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDProyecto };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusProyectoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusProyectoXID(RR_StatusProyecto Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDProyecto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_StatusProyecto", Parametros);
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

        #endregion

        #region Status Colaborador

        public void ACCatalogoStatusColaborador(RR_StatusColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDColaborador, Datos.Descripcion, Datos.ColorStatus, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_StatusColaborador", Parametros);
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

        public List<RR_StatusColaborador> ObtenerCatalogoStatusColaborador(RR_StatusColaborador Datos)
        {
            try
            {
                List<RR_StatusColaborador> Lista = new List<RR_StatusColaborador>();
                RR_StatusColaborador Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusColaborador");
                while (Dr.Read())
                {
                    Item = new RR_StatusColaborador();
                    Item.IDColaborador = Dr.GetInt32(Dr.GetOrdinal(("id_statusColaborador")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleStatusColaboradorXID(RR_StatusColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusColaboradorDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusColaboradorXID(RR_StatusColaborador Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDColaborador, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_StatusColaborador", Parametros);
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

        #endregion

        #region status Encuesta

        public void ACCatalogoStatusEncuesta(RR_StatusEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDEncuesta, Datos.Descripcion, Datos.ColorStatus, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_StatusEncuestas", Parametros);
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

        public List<RR_StatusEncuestas> ObtenerCatalogoStatusEncuesta(RR_StatusEncuestas Datos)
        {
            try
            {
                List<RR_StatusEncuestas> Lista = new List<RR_StatusEncuestas>();
                RR_StatusEncuestas Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusEncuesta");
                while (Dr.Read())
                {
                    Item = new RR_StatusEncuestas();
                    Item.IDEncuesta = Dr.GetInt32(Dr.GetOrdinal(("id_statusEncuesta")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleStatusEncuestaXID(RR_StatusEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusEncuestaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusEncuestaXID(RR_StatusEncuestas Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEncuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_StatusEncuesta", Parametros);
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

        #endregion

        #region status Evento

        public void ACCatalogoStatusEncuesta(RR_StatusEventos Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDEvento, Datos.Descripcion, Datos.ColorStatus, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_StatusEventos", Parametros);
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

        public List<RR_StatusEventos> ObtenerCatalogoStatusEvento(RR_StatusEventos Datos)
        {
            try
            {
                List<RR_StatusEventos> Lista = new List<RR_StatusEventos>();
                RR_StatusEventos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusEvento");
                while (Dr.Read())
                {
                    Item = new RR_StatusEventos();
                    Item.IDEvento = Dr.GetInt32(Dr.GetOrdinal(("id_statusEvento")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleStatusEventoXID(RR_StatusEventos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEvento };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_StatusEventoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.ColorStatus = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarStatusEventoXID(RR_StatusEventos Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDEvento, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_StatusEventos", Parametros);
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

        #endregion

       #region Tipo Usuario

        public void ACCatalogoTipoUsuario(RR_TipoUsuarios Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDTUsuario, Datos.Descripcion, Datos.Color, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_TipoUsuarios", Parametros);
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

        public List<RR_TipoUsuarios> ObtenerCatalogoTipoUsuario(RR_TipoUsuarios Datos)
        {
            try
            {
                List<RR_TipoUsuarios> Lista = new List<RR_TipoUsuarios>();
                RR_TipoUsuarios Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoUsuarios");
                while (Dr.Read())
                {
                    Item = new RR_TipoUsuarios();
                    Item.IDTUsuario = Dr.GetInt32(Dr.GetOrdinal(("id_tipoUsuario")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.Color = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleTipoUsuarioXID(RR_TipoUsuarios Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_TipoUsuariosDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Color = Dr.GetString(Dr.GetOrdinal("colorStatus"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoUsuarioXID(RR_TipoUsuarios Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDTUsuario, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_TipoUsuarios", Parametros);
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

        #endregion

        #region Modulo x tipo usuario
        public void ACCatalogoModuloTipoUsuario(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDModuloXTipoU, Datos.Descripcion, Datos.IDTipoU, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_ModuloXTipoUsuarip", Parametros);
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

        public List<RR_ModuloXTipoUsuario> ObtenerCatalogoModuloTipoUsuario(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                List<RR_ModuloXTipoUsuario> Lista = new List<RR_ModuloXTipoUsuario>();
                RR_ModuloXTipoUsuario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ModuloXTipoUsuario");
                while (Dr.Read())
                {
                    Item = new RR_ModuloXTipoUsuario();
                    Item.IDModuloXTipoU = Dr.GetInt32(Dr.GetOrdinal(("IDModuloXTipo")));
                    Item.NombreTipoU = Dr.GetString(Dr.GetOrdinal("TipoUsuario"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Modulo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleModuloTipoUsuarioXID(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDModuloXTipoU };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ModuloXTipoUsuarioXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDTipoU = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarModuloTipoUsuarioXID(RR_ModuloXTipoUsuario Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDModuloXTipoU, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_ModuloXTipoUsuario", Parametros);
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
        #endregion

        #region nuevo evento

        public void ACCatalogoNuevaActividad(RR_NuevaActividad Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDNuevaAct, Datos.EsEvento, Datos.NombreActividad, Datos.IDTipoActividadEvento,
                    Datos.EncargadoActividad, Datos.IDEstatusGeneral, Datos.IDEstatusVisto, Datos.FechaInicio, Datos.HoraInicio, Datos.FechaTermino, Datos.HoraTermino,
                    Datos.Observaciones, Datos.MetaEstablecida, Datos.MensajeEncargado, Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_ActividaesEventos", Parametros);
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

        public List<RR_NuevaActividad> ObtenerCatalogoNuevaActividad(RR_NuevaActividad Datos)
        {
            try
            {
                List<RR_NuevaActividad> Lista = new List<RR_NuevaActividad>();
                RR_NuevaActividad Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ActividadesEventos");
                while (Dr.Read())
                {
                    Item = new RR_NuevaActividad();
                    Item.IDNuevaAct = Dr.GetString(Dr.GetOrdinal("id_actividadEvento"));
                    Item.NombreActividad = Dr.GetString(Dr.GetOrdinal("nombreEvento"));
                    Item.EncargadoActividad = Dr.GetString(Dr.GetOrdinal("nombreCompleto"));
                    Item.FechaTermino = Dr.GetDateTime(Dr.GetOrdinal("fechaTermino"));
                    Item.MetaEstablecida = Dr.GetDecimal(Dr.GetOrdinal("meta"));
                    Item.EstatusGeneral = Dr.GetString(Dr.GetOrdinal("estatusGrnl"));
                    Item.DescEstatusGrnl = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.IDTipoActividadEvento = Dr.GetInt32(Dr.GetOrdinal("id_tipoEvento"));
                    Item.EstatusVisto = Dr.GetString(Dr.GetOrdinal("estatusVisto"));
                    Item.DescEstatusVisto = Dr.GetString(Dr.GetOrdinal("icono"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ObtenerDetalleNuevaActividadXID(RR_NuevaActividad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDNuevaAct };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ActividadEventoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDNuevaAct = Dr.GetString(Dr.GetOrdinal("id_actividadEvento"));
                    Datos.NombreActividad = Dr.GetString(Dr.GetOrdinal("nombreEvento"));
                    Datos.IDTipoActividadEvento = Dr.GetInt32(Dr.GetOrdinal("id_tipoEvento"));
                    Datos.EncargadoActividad = Dr.GetString(Dr.GetOrdinal("id_colaborador"));
                    Datos.FechaInicio = Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")); 
                    Datos.HoraInicio = Dr.GetString(Dr.GetOrdinal("horaInicio")); 
                    Datos.FechaTermino = Dr.GetDateTime(Dr.GetOrdinal("fechaTermino")); 
                    Datos.HoraTermino = Dr.GetString(Dr.GetOrdinal("horaTermino")); 
                    Datos.Observaciones = Dr.GetString(Dr.GetOrdinal("observaciones"));
                    Datos.MetaEstablecida = Dr.GetDecimal(Dr.GetOrdinal("meta"));
                    Datos.MensajeEncargado = Dr.GetString(Dr.GetOrdinal("mensajeEncargado"));
                    Datos.Completado = true; 
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarNuevaActividadXID(RR_NuevaActividad Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDNuevaAct, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "", Parametros);
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

        public List<RR_TipoEventoAgenda> ObtenerCatalogoActividad(RR_TipoEventoAgenda Datos)
        {
            try
            {
                List<RR_TipoEventoAgenda> Lista = new List<RR_TipoEventoAgenda>();
                RR_TipoEventoAgenda Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ComboEventos");
                while (Dr.Read())
                {
                    Item = new RR_TipoEventoAgenda();
                    Item.IDTipoEventoAgenda = Dr.GetInt32(Dr.GetOrdinal("id_tipoEventoAgenda"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<EM_CatColaborador> ObtenerCatalogoEncargado(EM_CatColaborador Datos)
        {
            try
            {
                List<EM_CatColaborador> Lista = new List<EM_CatColaborador>();
                EM_CatColaborador Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_ComboColaboradores");
                while (Dr.Read())
                {
                    Item = new EM_CatColaborador();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal(("id_colaborador")));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("nombreCompleto"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<RR_NuevaActividad> ObtenerBusquedaActividad(RR_NuevaActividad Datos)
        {
            try
            {
                List<RR_NuevaActividad> Lista = new List<RR_NuevaActividad>();
                RR_NuevaActividad Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ActividadesEventosBusqueda", Datos.Resultado, Datos.Busqueda, Datos.IDEstatusGeneral, Datos.FechaInicio, Datos.FechaTermino);
                while (Dr.Read())
                {
                    Item = new RR_NuevaActividad();
                    Item.IDNuevaAct = Dr.GetString(Dr.GetOrdinal("id_actividadEvento"));
                    Item.NombreActividad = Dr.GetString(Dr.GetOrdinal("nombreEvento"));
                    Item.EncargadoActividad = Dr.GetString(Dr.GetOrdinal("nombreCompleto"));
                    Item.FechaTermino = Dr.GetDateTime(Dr.GetOrdinal("fechaTermino"));
                    Item.MetaEstablecida = Dr.GetDecimal(Dr.GetOrdinal("meta"));
                    Item.EstatusGeneral = Dr.GetString(Dr.GetOrdinal("estatusGrnl"));
                    Item.DescEstatusGrnl = Dr.GetString(Dr.GetOrdinal("descripcion"));
                    Item.IDTipoActividadEvento = Dr.GetInt32(Dr.GetOrdinal("id_tipoEvento"));
                    Item.EstatusVisto = Dr.GetString(Dr.GetOrdinal("estatusVisto"));
                    Item.DescEstatusVisto = Dr.GetString(Dr.GetOrdinal("icono"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

         #region Afiliados

        public void ACCatalogoAfiliado(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDAfiliado,Datos.IDColaborador, Datos.Nombre, Datos.ApePat, Datos.ApeMat,
                        Datos.FechaAfiliacion, Datos.Estado, Datos.Municipio,Datos.IDPoligono,Datos.Seccion ,Datos.Direccion, Datos.NumeroExt, Datos.NumeroInt,
                    Datos.Colonia, Datos.CodigoPostal, Datos.ClaveElector, Datos.CorreoElect, Datos.Celular, Datos.Genero, Datos.Observaciones,Datos.CredencialFrente,Datos.CredencialPosterior,Datos.IDUsuario };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_AC_Afiliados", Parametros);
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

        public List<RR_Afiliados> ObtenerCatalogoAfiliado(RR_Afiliados Datos)
        {
            try
            {

                List<RR_Afiliados> Lista = new List<RR_Afiliados>();
                RR_Afiliados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_Afiliados", Datos.opcion);
                while (Dr.Read())
                {
                    Item = new RR_Afiliados();
                    Item.IDAfiliado = Dr.GetString(Dr.GetOrdinal(("id_afiliado")));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    Item.FechaAfiliacion = Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion"));
                    Item.Observaciones = Dr.GetString(Dr.GetOrdinal("observaciones"));
                    Item.Ratificacion = Dr.GetBoolean(Dr.GetOrdinal("ratificacion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDAfiliado };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_AfiliadosDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDAfiliado = !Dr.IsDBNull(Dr.GetOrdinal("id_afiliado")) ? Dr.GetString(Dr.GetOrdinal("id_afiliado")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_afiliado"));
                    Datos.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("nombre")) ? Dr.GetString(Dr.GetOrdinal("nombre")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("nombre"));
                    Datos.ApePat = !Dr.IsDBNull(Dr.GetOrdinal("apePat")) ? Dr.GetString(Dr.GetOrdinal("apePat")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("apePat"));
                    Datos.ApeMat = !Dr.IsDBNull(Dr.GetOrdinal("apeMat")) ? Dr.GetString(Dr.GetOrdinal("apeMat")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("apeMat"));
                    Datos.FechaAfiliacion = !Dr.IsDBNull(Dr.GetOrdinal("fechaAfiliacion")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion")) : DateTime.Now;//Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion"));
                    Datos.Estado = !Dr.IsDBNull(Dr.GetOrdinal("estado")) ? Dr.GetInt32(Dr.GetOrdinal("estado")) : 0;//Dr.GetInt32(Dr.GetOrdinal("estado"));
                    Datos.Municipio = !Dr.IsDBNull(Dr.GetOrdinal("municipio")) ? Dr.GetInt32(Dr.GetOrdinal("municipio")) : 0;//Dr.GetInt32(Dr.GetOrdinal("municipio"));
                    Datos.Direccion = !Dr.IsDBNull(Dr.GetOrdinal("direccion")) ? Dr.GetString(Dr.GetOrdinal("direccion")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("direccion"));
                    Datos.NumeroExt = !Dr.IsDBNull(Dr.GetOrdinal("numeroExt")) ? Dr.GetString(Dr.GetOrdinal("numeroExt")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("numeroExt"));
                    Datos.NumeroInt = !Dr.IsDBNull(Dr.GetOrdinal("numeroInt")) ? Dr.GetString(Dr.GetOrdinal("numeroInt")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("numeroInt"));
                    Datos.Seccion = !Dr.IsDBNull(Dr.GetOrdinal("seccion")) ? Dr.GetInt32(Dr.GetOrdinal("seccion")) : 0;//Dr.GetString(Dr.GetOrdinal("seccion"));
                    Datos.Colonia = !Dr.IsDBNull(Dr.GetOrdinal("colonia")) ? Dr.GetString(Dr.GetOrdinal("colonia")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("colonia"));
                    Datos.CodigoPostal = !Dr.IsDBNull(Dr.GetOrdinal("codigoPostal")) ? Dr.GetInt32(Dr.GetOrdinal("codigoPostal")) : 0;//Dr.GetInt32(Dr.GetOrdinal("codigoPostal"));
                    Datos.ClaveElector = !Dr.IsDBNull(Dr.GetOrdinal("claveElector")) ? Dr.GetString(Dr.GetOrdinal("claveElector")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("claveElector"));
                    Datos.CorreoElect = !Dr.IsDBNull(Dr.GetOrdinal("correoElec")) ? Dr.GetString(Dr.GetOrdinal("correoElec")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("correoElec"));
                    Datos.Celular = !Dr.IsDBNull(Dr.GetOrdinal("celular")) ? Dr.GetString(Dr.GetOrdinal("celular")) : string.Empty; //Dr.GetString(Dr.GetOrdinal("celular"));
                    Datos.Genero = !Dr.IsDBNull(Dr.GetOrdinal("genero")) ? Dr.GetInt32(Dr.GetOrdinal("genero")) : 0;//Dr.GetInt32(Dr.GetOrdinal("genero"));
                    Datos.Observaciones = !Dr.IsDBNull(Dr.GetOrdinal("observaciones")) ? Dr.GetString(Dr.GetOrdinal("observaciones")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("observaciones"));
                    //Datos.IDPoligono = !Dr.IsDBNull(Dr.GetOrdinal("id_poligono")) ? Dr.GetString(Dr.GetOrdinal("id_poligono")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_poligono"));
                    Datos.IDColaborador = !Dr.IsDBNull(Dr.GetOrdinal("id_colaboradorasignado")) ? Dr.GetString(Dr.GetOrdinal("id_colaboradorasignado")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_colaborador"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleAfiliadOCompletarXID(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDAfiliado };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_AfiliadosCompletarDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDAfiliado = !Dr.IsDBNull(Dr.GetOrdinal("id_afiliado")) ? Dr.GetString(Dr.GetOrdinal("id_afiliado")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_afiliado"));
                    Datos.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("nombre")) ? Dr.GetString(Dr.GetOrdinal("nombre")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("nombre"));
                    Datos.ApePat = !Dr.IsDBNull(Dr.GetOrdinal("apePat")) ? Dr.GetString(Dr.GetOrdinal("apePat")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("apePat"));
                    Datos.ApeMat = !Dr.IsDBNull(Dr.GetOrdinal("apeMat")) ? Dr.GetString(Dr.GetOrdinal("apeMat")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("apeMat"));
                    Datos.FechaAfiliacion = !Dr.IsDBNull(Dr.GetOrdinal("fechaAfiliacion")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion")) : DateTime.Now;//Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion"));
                    Datos.Estado = !Dr.IsDBNull(Dr.GetOrdinal("estado")) ? Dr.GetInt32(Dr.GetOrdinal("estado")) : 0;//Dr.GetInt32(Dr.GetOrdinal("estado"));
                    Datos.Municipio = !Dr.IsDBNull(Dr.GetOrdinal("municipio")) ? Dr.GetInt32(Dr.GetOrdinal("municipio")) : 0;//Dr.GetInt32(Dr.GetOrdinal("municipio"));
                    Datos.Direccion = !Dr.IsDBNull(Dr.GetOrdinal("direccion")) ? Dr.GetString(Dr.GetOrdinal("direccion")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("direccion"));
                    Datos.NumeroExt = !Dr.IsDBNull(Dr.GetOrdinal("numeroExt")) ? Dr.GetString(Dr.GetOrdinal("numeroExt")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("numeroExt"));
                    Datos.NumeroInt = !Dr.IsDBNull(Dr.GetOrdinal("numeroInt")) ? Dr.GetString(Dr.GetOrdinal("numeroInt")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("numeroInt"));
                    Datos.Seccion = !Dr.IsDBNull(Dr.GetOrdinal("seccion")) ? Dr.GetInt32(Dr.GetOrdinal("seccion")) : 0;//Dr.GetString(Dr.GetOrdinal("seccion"));
                    Datos.Colonia = !Dr.IsDBNull(Dr.GetOrdinal("colonia")) ? Dr.GetString(Dr.GetOrdinal("colonia")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("colonia"));
                    Datos.CodigoPostal = !Dr.IsDBNull(Dr.GetOrdinal("codigoPostal")) ? Dr.GetInt32(Dr.GetOrdinal("codigoPostal")) : 0;//Dr.GetInt32(Dr.GetOrdinal("codigoPostal"));
                    Datos.ClaveElector = !Dr.IsDBNull(Dr.GetOrdinal("claveElector")) ? Dr.GetString(Dr.GetOrdinal("claveElector")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("claveElector"));
                    Datos.CorreoElect = !Dr.IsDBNull(Dr.GetOrdinal("correoElec")) ? Dr.GetString(Dr.GetOrdinal("correoElec")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("correoElec"));
                    Datos.Celular = !Dr.IsDBNull(Dr.GetOrdinal("celular")) ? Dr.GetString(Dr.GetOrdinal("celular")) : string.Empty; //Dr.GetString(Dr.GetOrdinal("celular"));
                    Datos.Genero = !Dr.IsDBNull(Dr.GetOrdinal("genero")) ? Dr.GetInt32(Dr.GetOrdinal("genero")) : 0;//Dr.GetInt32(Dr.GetOrdinal("genero"));
                    Datos.Observaciones = !Dr.IsDBNull(Dr.GetOrdinal("observaciones")) ? Dr.GetString(Dr.GetOrdinal("observaciones")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("observaciones"));
                    //Datos.IDPoligono = !Dr.IsDBNull(Dr.GetOrdinal("id_poligono")) ? Dr.GetString(Dr.GetOrdinal("id_poligono")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_poligono"));
                    Datos.IDColaborador = !Dr.IsDBNull(Dr.GetOrdinal("id_colaborador")) ? Dr.GetString(Dr.GetOrdinal("id_colaborador")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("id_colaborador"));
                    Datos.CredencialFrente = !Dr.IsDBNull(Dr.GetOrdinal("textoCredencialFrente")) ? Dr.GetString(Dr.GetOrdinal("textoCredencialFrente")) : string.Empty;
                    Datos.CredencialPosterior = !Dr.IsDBNull(Dr.GetOrdinal("textCredencialPosterior")) ? Dr.GetString(Dr.GetOrdinal("textCredencialPosterior")) : string.Empty;
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDAfiliado, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_Afiliados", Parametros);
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

        public void RatificarAfiliadoXID(RR_Afiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDAfiliado, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_A_AfiliadosRatificar", Parametros);
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

        public List<CH_Genero> ObtenerComboGenero(CH_Genero Datos)
        {
            try
            {
                List<CH_Genero> Lista = new List<CH_Genero>();
                CH_Genero Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ComboGeneros");
                while (Dr.Read())
                {
                    Item = new CH_Genero();
                    Item.IDGenero = Dr.GetInt32(Dr.GetOrdinal(("IDGenero")));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Municipio> ObtenerComboMunicipio(CH_Municipio Datos)
        {
            try
            {
                List<CH_Municipio> Lista = new List<CH_Municipio>();
                CH_Municipio Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_CombosMunicipio",Datos.IDEstado);
                while (Dr.Read())
                {
                    Item = new CH_Municipio();
                    Item.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal(("IDMunicipio")));
                    Item.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<RR_Afiliados> ObtenerBusquedaAfiliado(RR_Afiliados Datos)
        {
            try
            {
                List<RR_Afiliados> Lista = new List<RR_Afiliados>();
                RR_Afiliados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_AfiliadosBusqueda", Datos.Resultado, Datos.Nombre, Datos.Ratificacion, Datos.Fecha1, Datos.Fecha2);
                while (Dr.Read())
                {
                    Item = new RR_Afiliados();
                    Item.IDAfiliado = Dr.GetString(Dr.GetOrdinal(("id_afiliado")));
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("nombre")) ? Dr.GetString(Dr.GetOrdinal("nombre")) : string.Empty;//Dr.GetString(Dr.GetOrdinal("nombre"));
                    Item.FechaAfiliacion = !Dr.IsDBNull(Dr.GetOrdinal("fechaAfiliacion")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion")) : DateTime.Now;//Dr.GetDateTime(Dr.GetOrdinal("fechaAfiliacion"));
                    Item.Observaciones = Dr.GetString(Dr.GetOrdinal("observaciones"));
                    Item.Ratificacion = !Dr.IsDBNull(Dr.GetOrdinal("ratificacion")) ? Dr.GetBoolean(Dr.GetOrdinal("ratificacion")) : false;//Dr.GetBoolean(Dr.GetOrdinal("ratificacion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RR_Afiliados ObternerCountAfiliado(RR_Afiliados Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CountAfiliado");
                while (Dr.Read())
                {
                    Datos.CountAfiliado = Dr.GetInt32(Dr.GetOrdinal("CountAfiliado"));
                    Datos.Completado = true;
                    break;
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Nueva respuesta
        public void ACRespuestas(RR_NuevaRespuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDRespuesta, Datos.IDPregunta, Datos.Respuesta, Datos.ClvRespuesta, Datos.EsMapa, Datos.Resultado, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_AC_NuevaRespuesta", Parametros);
                while (Dr.Read())
                {
                    int Resultado = Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDRespuesta = Dr.GetString(Dr.GetOrdinal("IDRespuesta"));
                        Datos.IDPregunta = Dr.GetString(Dr.GetOrdinal("IDPregunta"));
                    }
                    Datos.Resultado = Resultado;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RR_NuevaRespuesta> ObtenerRespuestas(RR_NuevaRespuesta Datos)
        {
            try
            {
                List<RR_NuevaRespuesta> Lista = new List<RR_NuevaRespuesta>();
                RR_NuevaRespuesta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_Respuestas", Datos.IDPregunta);
                while (Dr.Read())
                {
                    Item = new RR_NuevaRespuesta();
                    Item.IDRespuesta = Dr.GetString(Dr.GetOrdinal("IDRespuesta"));
                    Item.Respuesta = Dr.GetString(Dr.GetOrdinal("Respuesta"));
                    Item.ClvRespuesta = Dr.GetString(Dr.GetOrdinal("ClvRespuesta"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleRespuestasXID(RR_NuevaRespuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRespuesta };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_RespuestaDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.IDRespuesta = Dr.GetString(Dr.GetOrdinal("IDRespuesta"));
                    Datos.Respuesta = Dr.GetString(Dr.GetOrdinal("Respuesta"));
                    Datos.ClvRespuesta = Dr.GetString(Dr.GetOrdinal("ClvRespuesta"));
                    Datos.Orden = Dr.GetInt32(Dr.GetOrdinal("Orden"));
                    Datos.EsMapa = Dr.GetBoolean(Dr.GetOrdinal("Grafica"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRespuestasXID(RR_NuevaRespuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRespuesta, Datos.IDPregunta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "RR_spCSLDB_del_Respuestas", Parametros);
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

        public void AEncuestaContestada(RR_NuevaRespuesta Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "EM_spCSLDB_AC_EncuestaContestada",
                     new SqlParameter("@IDRespuestaEncuesta", Datos.IDEncuesta.Trim()),
                     new SqlParameter("@TablaRespuesta", Datos.TablaDatos),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDEncuesta = dr.GetString(dr.GetOrdinal("IDRespuestaEncuesta"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        throw new Exception(dr.GetString(dr.GetOrdinal("Mensaje")));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}