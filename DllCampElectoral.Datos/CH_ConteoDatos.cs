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
    public class CH_ConteoDatos
    {
        public void ObtenerDetalleCapturaXID(CH_Conteo Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "ER_spCSLDB_get_CapturaPREPDetalleV2", Datos.IDCaptura);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.Casilla = Dr.GetString(Dr.GetOrdinal("Casilla"));
                            Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
                            Datos.Colaborador = Dr.GetString(Dr.GetOrdinal("Colaborador"));
                            Datos.Comentarios = Dr.GetString(Dr.GetOrdinal("Comentarios"));
                            Datos.Completado = true;
                            break;
                        }
                        List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
                        CH_PartidoPolitico Item;
                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        while (Dr2.Read())
                        {
                            Item = new CH_PartidoPolitico();
                            Item.IDPartido = Dr2.GetInt32(Dr2.GetOrdinal("IDPartido"));
                            Item.Nombre = Dr2.GetString(Dr2.GetOrdinal("Partido"));
                            Item.Siglas = Dr2.GetString(Dr2.GetOrdinal("Siglas"));
                            Item.UrlLogo = Dr2.GetString(Dr2.GetOrdinal("LogoPartido"));
                            Item.Votos = Dr2.GetInt32(Dr2.GetOrdinal("Votos"));

                            Lista.Add(Item);
                        }
                        Datos.ListaPartidos = Lista;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void ObtenerDetalleCapturaXID(CH_Conteo Datos)
        //{
        //    try
        //    {
        //        DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "CH_spCSLDB_get_CapturaPREPDetalle", Datos.IDCaptura);
        //        if (Ds != null)
        //        {
        //            if (Ds.Tables.Count == 2)
        //            {
        //                DataTableReader Dr = Ds.Tables[0].CreateDataReader();
        //                while (Dr.Read())
        //                {
        //                    Datos.Casilla = Dr.GetString(Dr.GetOrdinal("Casilla"));
        //                    Datos.UrlImagen = Dr.GetString(Dr.GetOrdinal("UrlImagen"));
        //                    Datos.Colaborador = Dr.GetString(Dr.GetOrdinal("Colaborador"));
        //                    Datos.Comentarios = Dr.GetString(Dr.GetOrdinal("Comentarios"));
        //                    Datos.Completado = true;
        //                    break;
        //                }
        //                List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
        //                CH_PartidoPolitico Item;
        //                DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
        //                while (Dr2.Read())
        //                {
        //                    Item = new CH_PartidoPolitico();
        //                    Item.IDPartido = Dr2.GetInt32(Dr2.GetOrdinal("IDPartido"));
        //                    Item.Nombre = Dr2.GetString(Dr2.GetOrdinal("Partido"));
        //                    Item.Siglas = Dr2.GetString(Dr2.GetOrdinal("Siglas"));
        //                    Item.UrlLogo = Dr2.GetString(Dr2.GetOrdinal("LogoPartido"));
        //                    Item.Votos = Dr2.GetInt32(Dr2.GetOrdinal("Votos"));

        //                    Lista.Add(Item);
        //                }
        //                Datos.ListaPartidos = Lista;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void ACDetalleCapturaXID(CH_Conteo Datos, string seccion,string casilla,string colaborador)
        {
            try
            {
                object[] Parametros = { Datos.IDCaptura, Datos.TablaDatos, Datos.IDUsuario, seccion,casilla ,"" };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "ER_spCSLDB_AC_CapturaDetalleResultados2",
                new SqlParameter("@IDCaptura", Datos.IDCaptura),
                new SqlParameter("@TablaVotos", Datos.TablaDatos),
                new SqlParameter("@IDUsuario", Datos.IDUsuario),
                new SqlParameter("@IdSeccion", seccion),
                new SqlParameter("@IdCasilla", casilla),
                 new SqlParameter("@IdColaborador", colaborador),
                new SqlParameter("@Imagen", Datos.UrlImagen)
                );
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Validarconteo(CH_Conteo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCaptura, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_C_CapturaPREPValidacion", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void ACDetalleCapturaXID(CH_Conteo Datos)
        //{
        //    try
        //    {
        //        object[] Parametros = { Datos.IDCaptura, Datos.TablaDatos, Datos.IDUsuario };
        //        object Result = SqlHelper.ExecuteScalar(Datos.Conexion, CommandType.StoredProcedure, "CH_spCSLDB_AC_CapturaDetalleResultados",
        //        new SqlParameter("@IDCaptura", Datos.IDCaptura),
        //        new SqlParameter("@TablaVotos", Datos.TablaDatos),
        //        new SqlParameter("@IDUsuario", Datos.IDUsuario));
        //        if (Result != null)
        //        {
        //            int Resultado = 0;
        //            int.TryParse(Result.ToString(), out Resultado);
        //            if (Resultado == 1)
        //                Datos.Completado = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<CH_Conteo> ObtenerCapturasParaValidar(CH_Conteo Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_CapturaPREPValidacion");
                List<CH_Conteo> Lista = new List<CH_Conteo>();
                CH_Conteo Item;
                while (Dr.Read())
                {
                    Item = new CH_Conteo();
                    Item.IDCaptura = Dr.GetString(Dr.GetOrdinal("IDCaptura"));
                    Item.Casilla = Dr.GetString(Dr.GetOrdinal("Casilla"));
                    Item.Colaborador = Dr.GetString(Dr.GetOrdinal("Colaborador"));
                    Item.FechaHora = Dr.GetDateTime(Dr.GetOrdinal("FechaCaptura"));
                    Item.SFechaHora = Item.FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CH_Conteo> ObtenerCapturas(CH_Conteo Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "ER_spCSLDB_get_CapturaPREPv2");
                List<CH_Conteo> Lista = new List<CH_Conteo>();
                CH_Conteo Item;
                while (Dr.Read())
                {
                    Item = new CH_Conteo();
                    Item.IDCaptura = Dr.GetString(Dr.GetOrdinal("IDCaptura"));
                    Item.Casilla = Dr.GetString(Dr.GetOrdinal("Casilla"));
                    Item.Colaborador = Dr.GetString(Dr.GetOrdinal("Colaborador"));
                    Item.FechaHora = Dr.GetDateTime(Dr.GetOrdinal("FechaCaptura"));
                    Item.SFechaHora = Item.FechaHora.ToString("dd/MM/yyyy HH:mm:ss");
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCaptura(CH_Conteo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCaptura, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_CapturaPREP", Parametros);
                if(Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
