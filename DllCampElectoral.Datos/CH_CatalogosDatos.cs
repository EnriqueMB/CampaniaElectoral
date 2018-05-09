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
    public class CH_CatalogosDatos
    {

        #region Catálogo Géneros

        public void ACCatalogoGenero(CH_Genero Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDGenero, Datos.Descripcion, Datos.Letra, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_Generos", Parametros);
                int Resultado = 0;
                int.TryParse(Result.ToString(), out Resultado);
                if(Resultado == 1)
                {
                    Datos.Completado = true;
                }
                Datos.Resultado = Resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_Genero> ObtenerCatalogoGenero(CH_Genero Datos)
        {
            try
            {
                List<CH_Genero> Lista = new List<CH_Genero>();
                CH_Genero Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_Generos");
                while (Dr.Read())
                {
                    Item = new CH_Genero();
                    Item.IDGenero = Dr.GetInt32(Dr.GetOrdinal("IDGenero"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Letra = Dr.GetString(Dr.GetOrdinal("Letra"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetalleGeneroXID(CH_Genero Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDGenero };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_GeneroDetalle", Parametros);
                while(Dr.Read())
                {
                    Datos.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Datos.Letra = Dr.GetString(Dr.GetOrdinal("Letra"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGeneroXID(CH_Genero Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDGenero, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_del_Genero", Parametros);
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

        #region Catálogo Partidos Políticos

        public void ACCatalogoPartidos(CH_PartidoPolitico Datos)
        {
            try
            {
                object[] Parametros = {
                    Datos.NuevoRegistro,    Datos.IDPartido,    Datos.Nombre,
                    Datos.Siglas,           Datos.RGBColor,     Datos.CambioImagen,
                    Datos.IDUsuario,        Datos.Logo
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_AC_PartidosPoliticos", Parametros);
                while(Dr.Read())
                {
                    Datos.Completado = Dr.GetBoolean(Dr.GetOrdinal("completado"));
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("resultado"));
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CH_PartidoPolitico> ObtenerCatalogoPartidos(CH_PartidoPolitico Datos)
        {
            try
            {
                List<CH_PartidoPolitico> Lista = new List<CH_PartidoPolitico>();
                CH_PartidoPolitico Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_PartidosPoliticos");
                while (Dr.Read())
                {
                    Item = new CH_PartidoPolitico();
                    Item.IDPartido = Dr.GetInt32(Dr.GetOrdinal("IDPartido"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Item.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    //Item.UrlLogo = Dr.GetString(Dr.GetOrdinal("UrlLogo"));
                    Item.RGBColor = Dr.GetString(Dr.GetOrdinal("Color"));
                    Item.Logo = Dr.GetString(Dr.GetOrdinal("Logo"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDetallePartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPartido };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_PartidoPoliticoDetalle", Parametros);
                while (Dr.Read())
                {
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Datos.Siglas = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    Datos.Logo = Dr.GetString(Dr.GetOrdinal("Logo"));
                    Datos.RGBColor = Dr.GetString(Dr.GetOrdinal("Color"));
                    Datos.CambioImagen = Dr.GetBoolean(Dr.GetOrdinal("imagenGuardada"));

                    if (string.IsNullOrEmpty(Datos.Logo))
                        Datos.Logo = FG_Auxiliar.ImagenPredeterminada();

                    Datos.ExtensionLogo = FG_Auxiliar.ObtenerExtensionImagenBase64(Datos.Logo);

                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPartido, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_del_PartidoPolitico", Parametros);

                while (Dr.Read())
                {
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("mensaje"));
                    Datos.Completado = Dr.GetBoolean(Dr.GetOrdinal("resultado"));
                    break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ImagenSubidaPartidoXID(CH_PartidoPolitico Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDPartido, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_set_ImagenSubidaPartido", Parametros);
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

        public void ObtenerCombosColaborador(CH_PartidoPolitico Datos)
        {
            try
            {
                CH_Colaborador DatosResult = new CH_Colaborador();
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "EM_spCSLDB_get_ColaboradoresTipos");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        List<RR_TipoUsuarios> ListaTiposUsers = new List<RR_TipoUsuarios>();
                        RR_TipoUsuarios ItemTU;
                        while (Dr.Read())
                        {
                            ItemTU = new RR_TipoUsuarios();
                            ItemTU.IDTUsuario = Dr.GetInt32(Dr.GetOrdinal("IDTipoUsuario"));
                            ItemTU.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"));
                            ListaTiposUsers.Add(ItemTU);
                        }

                        DataTableReader Dr2 = Ds.Tables[1].CreateDataReader();
                        List<CH_Colaborador> ListaColabs = new List<CH_Colaborador>();
                        CH_Colaborador ItemCo;
                        while (Dr2.Read())
                        {
                            ItemCo = new CH_Colaborador();
                            ItemCo.IDColaborador = Dr2.GetString(Dr2.GetOrdinal("IDColaborador"));
                            ItemCo.Nombre = Dr2.GetString(Dr2.GetOrdinal("Nombre"));
                            ItemCo.IDTipoUsuario = Dr2.GetInt32(Dr2.GetOrdinal("IDTipoUsuario"));
                            ListaColabs.Add(ItemCo);
                        }
                        DatosResult.ListaUsers = ListaTiposUsers;
                        DatosResult.ListaColaboradores = ListaColabs;
                        Datos.Completado = true;
                        Datos.DatosAuxColab = DatosResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Catalogo Colaboradores

        public List<CH_Colaborador> ObtenerComboColaborador(CH_Colaborador Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ComboColaboradores");
                List<CH_Colaborador> Lista = new List<CH_Colaborador>();
                CH_Colaborador Item;
                while(Dr.Read())
                {
                    Item = new CH_Colaborador();
                    Item.IDColaborador = Dr.GetString(Dr.GetOrdinal("IDColaborador"));
                    Item.Nombre = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Catálogo Municipios

        public List<CH_MunicipioJSON> ObtenerMunicipiosXIDEstado(CH_Municipio Datos)
        {
            try
            {
                List<CH_MunicipioJSON> Lista = new List<CH_MunicipioJSON>();
                CH_MunicipioJSON Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_CombosMunicipio", Datos.IDEstado);
                while (Dr.Read())
                {
                    Item = new CH_MunicipioJSON();
                    Item.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
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

        public List<CH_PoligonoJSON> ObtenerPoligonosXIDEstadoMunicipio(CH_Poligono Datos)
        {
            try
            {
                List<CH_PoligonoJSON> Lista = new List<CH_PoligonoJSON>();
                CH_PoligonoJSON Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_ComboPoligono", Datos.IDEstado, Datos.IDMunicipio);
                while (Dr.Read())
                {
                    Item = new CH_PoligonoJSON();
                    Item.IDPoligono = Dr.GetString(Dr.GetOrdinal("IDPoligono"));
                    Item.Descripcion = Dr.GetString(Dr.GetOrdinal("Nombre"));
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
