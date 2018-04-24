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
    public class CH_EncuestaDatos
    {

        public void ObtenerCombosResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_CombosResponderEncuesta");
                if(Ds != null)
                {
                    if (Ds.Tables.Count == 6)
                    {
                        Datos.ListaEstados = ObtenerComboEstados(Ds.Tables[0]);
                        Datos.ListaEncuestas = ObtenerComboEncuestas(Ds.Tables[1]);
                        Datos.ListaGeneros = ObtenerComboGeneros(Ds.Tables[2]);
                        Datos.ListaGradosEstudio = ObtenerComboGradosEstudio(Ds.Tables[3]);
                        Datos.ListaEntrevistador = ObtenerComboColaborador(Ds.Tables[4]);
                        Datos.ListaSupervisor = ObtenerComboColaborador(Ds.Tables[5]);
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void AC_ResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDRespuesta, Datos.IDEncuesta, Datos.FechaEncuesta,
                    Datos.HoraInicio, Datos.HoraTermino, Datos.IDEstado, Datos.IDMunicipio, Datos.IDPoligono, Datos.Nombre,
                    Datos.ApellidoPat, Datos.ApellidoMat, Datos.Edad, Datos.AniosColonia, Datos.IDGenero, Datos.IDGradoEstudio,
                    Datos.Direccion, Datos.IDEntrevistador, Datos.IDSupervisor, Datos.Observaciones, Datos.IDUsuario};
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_ResponderEncuesta", Parametros);
                if(Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if(Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleResponderEncuesta(CH_Encuesta Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ResponderEncuestaDetalle", Datos.IDRespuesta);
                while(Dr.Read())
                {
                    Datos.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    //Datos.Folio = Dr.GetString(Dr.GetOrdinal("Folio"));
                    Datos.FechaEncuesta = Dr.GetDateTime(Dr.GetOrdinal("FechaEncuesta"));
                    Datos.HoraInicio = Dr.GetString(Dr.GetOrdinal("HoraInicio"));
                    Datos.HoraTermino = Dr.GetString(Dr.GetOrdinal("HoraTermino"));
                    Datos.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Datos.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
                    Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.ApellidoPat = Dr.GetString(Dr.GetOrdinal("ApellidoPat"));
                    Datos.ApellidoMat = Dr.GetString(Dr.GetOrdinal("ApellidoMat"));
                    Datos.Edad = Dr.GetInt32(Dr.GetOrdinal("Edad"));
                    Datos.AniosColonia = Dr.GetInt32(Dr.GetOrdinal("AniosColonia"));
                    Datos.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
                    Datos.IDGradoEstudio = Dr.GetInt32(Dr.GetOrdinal("IDGradoEstudio"));
                    Datos.Direccion = Dr.GetString(Dr.GetOrdinal("Direccion"));
                    Datos.IDEntrevistador = Dr.GetString(Dr.GetOrdinal("IDEntrevistador"));
                    Datos.IDSupervisor = Dr.GetString(Dr.GetOrdinal("IDSupervisor"));
                    Datos.Observaciones = Dr.GetString(Dr.GetOrdinal("Observaciones"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Encuesta> ObtenerListaRespuestas(CH_Encuesta Datos)
        {            
            try
            {
                List<CH_Encuesta> Lista = new List<CH_Encuesta>();
                CH_Encuesta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_RespuestasEncuesta");
                while (Dr.Read())
                {
                    Item = new CH_Encuesta();
                    Item.IDRespuesta = Dr.GetString(Dr.GetOrdinal("IDRespuesta"));
                    Item.EncuestaDesc = Dr.GetString(Dr.GetOrdinal("EncuestaDesc"));
                    Item.Folio = Dr.GetString(Dr.GetOrdinal("Folio"));
                    Item.PoligonoDesc = Dr.GetString(Dr.GetOrdinal("PoligonoDesc"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRespuestaXID(CH_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRespuesta, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_RespuestaEncuesta", Parametros);
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

        public void ObtenerDatosUbicacionRespuesta(CH_Encuesta Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ResponderEncuestaUbicacion", Datos.IDRespuesta);
                while (Dr.Read())
                {
                    Datos.Latitud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Datos.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Datos.LatitudPol = Dr.GetDouble(Dr.GetOrdinal("LatitudPol"));
                    Datos.LongitudPol = Dr.GetDouble(Dr.GetOrdinal("LongitudPol"));
                    Datos.Folio = Dr.GetString(Dr.GetOrdinal("Folio"));
                    Datos.PoligonoDesc = Dr.GetString(Dr.GetOrdinal("PoligonoDesc"));
                    Datos.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AC_UbicacionRespuesta(CH_Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDRespuesta, Datos.Latitud, Datos.Longitud, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_RespuestaEncuestaUbicacion", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_ResultadoEncuestaJSON> ObtenerPoligonosXEncuesta(CH_Encuesta Datos)
        {
            try
            {
                List<CH_ResultadoEncuestaJSON> Lista = new List<CH_ResultadoEncuestaJSON>();
                CH_ResultadoEncuestaJSON Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ResultadosPreguntaEncuesta", Datos.IDEncuesta, Datos.IDPregunta);
                while (Dr.Read())
                {
                    Item = new CH_ResultadoEncuestaJSON();
                    Item.Color = Dr.GetString(Dr.GetOrdinal("Color"));
                    Item.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosMapaResultado(CH_Encuesta Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_DatosResultadoEncuesta", Datos.IDPregunta);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Nombre = Dr.GetString(Dr.GetOrdinal("NombreEncuesta"));
                            Datos.TituloRespuesta = Dr.GetString(Dr.GetOrdinal("TituloRespuesta"));
                            Datos.PeriodoDatos = Dr.GetString(Dr.GetOrdinal("PeriodoDatos"));
                            Datos.TituloPorcentaje = Dr.GetString(Dr.GetOrdinal("TituloPorcentaje"));
                            Datos.Explicacion = Dr.GetString(Dr.GetOrdinal("Explicacion"));
                            Datos.EstadoDesc = Dr.GetString(Dr.GetOrdinal("EstadoDesc"));
                            Datos.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("MunicipioDesc"));
                            Datos.Completado = true;
                        }
                        if (Datos.Completado)
                        {
                            Datos.Completado = false;
                            List<CH_Encuesta> Lista = new List<CH_Encuesta>();
                            CH_Encuesta Item;
                            DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                            while (Dr2.Read())
                            {
                                Item = new CH_Encuesta();
                                Item.DescripcionPorcentaje = Dr2.GetString(Dr2.GetOrdinal("Descripcion"));
                                Item.Color = Dr2.GetString(Dr2.GetOrdinal("Color"));
                                Lista.Add(Item);
                            }
                            Datos.ListaValoresRespuesta = Lista;
                            Datos.Completado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos Auxiliares para llenado de combos

        public List<CH_Estados> ObtenerComboEstados(DataTable Tabla)
        {
            try
            {
                List<CH_Estados> Lista = new List<CH_Estados>();
                CH_Estados Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while(Dr.Read())
                {
                    Item = new CH_Estados();
                    Item.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Item.EstadoDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Encuesta> ObtenerComboEncuestas(DataTable Tabla)
        {
            try
            {
                List<CH_Encuesta> Lista = new List<CH_Encuesta>();
                CH_Encuesta Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_Encuesta();
                    Item.IDEncuesta = Dr.GetString(Dr.GetOrdinal("IDEncuesta"));
                    Item.EncuestaDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Genero> ObtenerComboGeneros(DataTable Tabla)
        {
            try
            {
                List<CH_Genero> Lista = new List<CH_Genero>();
                CH_Genero Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_Genero();
                    Item.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
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

        public List<CH_GradoEstudio> ObtenerComboGradosEstudio(DataTable Tabla)
        {
            try
            {
                List<CH_GradoEstudio> Lista = new List<CH_GradoEstudio>();
                CH_GradoEstudio Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_GradoEstudio();
                    Item.IDGradoEstudio = Dr.GetInt32(Dr.GetOrdinal("IDGradoEstudios"));
                    Item.GradoEstudioDesc = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Colaborador> ObtenerComboColaborador(DataTable Tabla)
        {
            try
            {
                List<CH_Colaborador> Lista = new List<CH_Colaborador>();
                CH_Colaborador Item;
                DataTableReader Dr = Tabla.CreateDataReader();
                while (Dr.Read())
                {
                    Item = new CH_Colaborador();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
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
    }
}
