using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public class DA_AutenticarDatos
    {
        public WN_Usuario Autenticar(WN_Usuario user)
        {
            
                //WN_Usuario _datos = new WN_Usuario();
                object[] parametros = {user.Usuario, user.Password};
                DataSet ds = SqlHelper.ExecuteDataset(Comun.Conexion, "CH_spCSLDB_Login3", parametros);
                if(ds != null)
                {
                        DataTableReader Dr = ds.Tables[0].CreateDataReader();//Verificamos que valor trae opcion pare luego comparar
                        while (Dr.Read())
                        {
                        user.Opcion = Dr.GetInt32(Dr.GetOrdinal("Opcion"));
                            break;
                        }
                    if(ds.Tables.Count == 5)
                    {
                        if (user.Opcion == 3)
                        {
                            DataTableReader Dr1 = ds.Tables[1].CreateDataReader(); //DAtos del usuario
                            while (Dr1.Read())
                            {
                                user.IDUsuario = Dr1.GetString(Dr1.GetOrdinal("id_user"));
                                user.Nombre = Dr1.GetString(Dr1.GetOrdinal("nombre"));
                                user.Usuario = Dr1.GetString(Dr1.GetOrdinal("user"));
                                user.Apellidos = Dr1.GetString(Dr1.GetOrdinal("apPaterno")) + " " + Dr1.GetString(Dr1.GetOrdinal("apMaterno"));
                                user.Correo = Dr1.GetString(Dr1.GetOrdinal("correo"));
                                user.Imagen = Dr1.GetString(Dr1.GetOrdinal("Imagen"));
                                user.IDEstado = Dr1.GetInt32(Dr1.GetOrdinal("estado"));
                                user.IDMunicipio = Dr1.GetInt32(Dr1.GetOrdinal("municipio"));
                                user.IDTipoUsuario = Dr1.GetInt32(Dr1.GetOrdinal("id_profile"));
                            break;
                            }
                            List<WN_Permisos> listaIdsPadres = new List<WN_Permisos>(); //Lista de los IDs Padres del usuario logeado
                            WN_Permisos modulosPadre;
                            DataTableReader Dr2 = ds.Tables[2].CreateDataReader();

                            while (Dr2.Read())
                            {
                                modulosPadre = new WN_Permisos();
                                modulosPadre.IdModulo = Dr2.GetString(Dr2.GetOrdinal("id_page"));
                                modulosPadre.IDPadre = Dr2.GetString(Dr2.GetOrdinal("id_padre"));
                                modulosPadre.IdTipo = Dr2.GetInt32(Dr2.GetOrdinal("id_tipopage"));
                                modulosPadre.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                                modulosPadre.NombreModulo = Dr2.GetString(Dr2.GetOrdinal("desc"));
                                modulosPadre.FrmModulo = Dr2.GetString(Dr2.GetOrdinal("url"));
                                modulosPadre.OrdenPadre = Dr2.GetInt32(Dr2.GetOrdinal("ordenPadre"));
                                listaIdsPadres.Add(modulosPadre);
                            }
                            user.ModulosPadres = listaIdsPadres;

                            List<WN_Permisos> listaIdsHijos = new List<WN_Permisos>();//Lista de los IDs Hijos del usuario logeado
                            WN_Permisos modulosHijos;
                            DataTableReader Dr3 = ds.Tables[3].CreateDataReader();

                            while (Dr3.Read())
                            {
                                modulosHijos = new WN_Permisos();
                                modulosHijos.IdModulo = Dr3.GetString(Dr3.GetOrdinal("id_page"));
                                modulosHijos.IDPadre = Dr3.GetString(Dr3.GetOrdinal("id_padre"));
                                modulosHijos.IdTipo = Dr3.GetInt32(Dr3.GetOrdinal("id_tipopage"));
                                modulosHijos.NombreModulo = Dr3.GetString(Dr3.GetOrdinal("desc"));
                                modulosHijos.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                                modulosHijos.FrmModulo = Dr3.GetString(Dr3.GetOrdinal("url"));
                                modulosHijos.OrdenHijo = Dr3.GetInt32(Dr3.GetOrdinal("ordenHijo"));
                                modulosHijos.OrdenPadre = Dr3.GetInt32(Dr3.GetOrdinal("ordenPadre"));
                                modulosHijos.Opc = Dr3.GetInt32(Dr3.GetOrdinal("opc"));
                                listaIdsHijos.Add(modulosHijos);
                            }
                            user.ModulosHijos = listaIdsHijos;
                            List<WN_Permisos> listaIdsNietos = new List<WN_Permisos>();//Lista de los IDs Nietos del usuario logeado
                            WN_Permisos modulosNietos;
                            DataTableReader Dr4 = ds.Tables[4].CreateDataReader();

                            while (Dr4.Read())
                            {
                                modulosNietos = new WN_Permisos();
                                modulosNietos.IdModulo = Dr4.GetString(Dr4.GetOrdinal("id_page"));
                                modulosNietos.IDPadre = Dr4.GetString(Dr4.GetOrdinal("id_padre"));
                                modulosNietos.IdTipo = Dr4.GetInt32(Dr4.GetOrdinal("id_tipopage"));
                                modulosNietos.NombreModulo = Dr4.GetString(Dr4.GetOrdinal("desc"));
                                modulosNietos.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                                modulosNietos.FrmModulo = Dr4.GetString(Dr4.GetOrdinal("url"));
                                modulosNietos.OrdenHijo = Dr4.GetInt32(Dr4.GetOrdinal("ordenHijo"));
                                modulosNietos.OrdenPadre = Dr4.GetInt32(Dr4.GetOrdinal("ordenPadre"));
                                modulosNietos.Nieto = Dr4.GetInt32(Dr4.GetOrdinal("nieto"));
                                listaIdsNietos.Add(modulosNietos);
                            }
                            user.ModuloNietos = listaIdsNietos;
                            user.Band = true;
                        }
                    }
                }
                else
                {
                    user.Band = false;
                }
                return user;
        }

        public WN_Usuario AutenticarSeccion(WN_Usuario user)
        {

            //WN_Usuario _datos = new WN_Usuario();
            object[] parametros = { user.IDUsuario };
            DataSet ds = SqlHelper.ExecuteDataset(Comun.Conexion, "V2_EM_spCSLDB_get_ObnerterDatosUsuarios", parametros);
            if (ds != null)
            {
                if (ds.Tables.Count == 4)
                {
                    DataTableReader Dr1 = ds.Tables[0].CreateDataReader(); //DAtos del usuario
                    while (Dr1.Read())
                    {
                        user.IDUsuario = Dr1.GetString(Dr1.GetOrdinal("id_user"));
                        user.Nombre = Dr1.GetString(Dr1.GetOrdinal("nombre"));
                        user.Usuario = Dr1.GetString(Dr1.GetOrdinal("user"));
                        user.Apellidos = Dr1.GetString(Dr1.GetOrdinal("apPaterno")) + " " + Dr1.GetString(Dr1.GetOrdinal("apMaterno"));
                        user.Correo = Dr1.GetString(Dr1.GetOrdinal("correo"));
                        user.Imagen = Dr1.GetString(Dr1.GetOrdinal("Imagen"));
                        user.IDEstado = Dr1.GetInt32(Dr1.GetOrdinal("estado"));
                        user.IDMunicipio = Dr1.GetInt32(Dr1.GetOrdinal("municipio"));
                        user.IDTipoUsuario = Dr1.GetInt32(Dr1.GetOrdinal("id_profile"));
                        break;
                    }
                    List<WN_Permisos> listaIdsPadres = new List<WN_Permisos>(); //Lista de los IDs Padres del usuario logeado
                    WN_Permisos modulosPadre;
                    DataTableReader Dr2 = ds.Tables[1].CreateDataReader();

                    while (Dr2.Read())
                    {
                        modulosPadre = new WN_Permisos();
                        modulosPadre.IdModulo = Dr2.GetString(Dr2.GetOrdinal("id_page"));
                        modulosPadre.IDPadre = Dr2.GetString(Dr2.GetOrdinal("id_padre"));
                        modulosPadre.IdTipo = Dr2.GetInt32(Dr2.GetOrdinal("id_tipopage"));
                        modulosPadre.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                        modulosPadre.NombreModulo = Dr2.GetString(Dr2.GetOrdinal("desc"));
                        modulosPadre.FrmModulo = Dr2.GetString(Dr2.GetOrdinal("url"));
                        modulosPadre.OrdenPadre = Dr2.GetInt32(Dr2.GetOrdinal("ordenPadre"));
                        listaIdsPadres.Add(modulosPadre);
                    }
                    user.ModulosPadres = listaIdsPadres;

                    List<WN_Permisos> listaIdsHijos = new List<WN_Permisos>();//Lista de los IDs Hijos del usuario logeado
                    WN_Permisos modulosHijos;
                    DataTableReader Dr3 = ds.Tables[2].CreateDataReader();

                    while (Dr3.Read())
                    {
                        modulosHijos = new WN_Permisos();
                        modulosHijos.IdModulo = Dr3.GetString(Dr3.GetOrdinal("id_page"));
                        modulosHijos.IDPadre = Dr3.GetString(Dr3.GetOrdinal("id_padre"));
                        modulosHijos.IdTipo = Dr3.GetInt32(Dr3.GetOrdinal("id_tipopage"));
                        modulosHijos.NombreModulo = Dr3.GetString(Dr3.GetOrdinal("desc"));
                        modulosHijos.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                        modulosHijos.FrmModulo = Dr3.GetString(Dr3.GetOrdinal("url"));
                        modulosHijos.OrdenHijo = Dr3.GetInt32(Dr3.GetOrdinal("ordenHijo"));
                        modulosHijos.OrdenPadre = Dr3.GetInt32(Dr3.GetOrdinal("ordenPadre"));
                        modulosHijos.Opc = Dr3.GetInt32(Dr3.GetOrdinal("opc"));
                        listaIdsHijos.Add(modulosHijos);
                    }
                    user.ModulosHijos = listaIdsHijos;
                    List<WN_Permisos> listaIdsNietos = new List<WN_Permisos>();//Lista de los IDs Nietos del usuario logeado
                    WN_Permisos modulosNietos;
                    DataTableReader Dr4 = ds.Tables[3].CreateDataReader();

                    while (Dr4.Read())
                    {
                        modulosNietos = new WN_Permisos();
                        modulosNietos.IdModulo = Dr4.GetString(Dr4.GetOrdinal("id_page"));
                        modulosNietos.IDPadre = Dr4.GetString(Dr4.GetOrdinal("id_padre"));
                        modulosNietos.IdTipo = Dr4.GetInt32(Dr4.GetOrdinal("id_tipopage"));
                        modulosNietos.NombreModulo = Dr4.GetString(Dr4.GetOrdinal("desc"));
                        modulosNietos.Iconos = Dr2.GetString(Dr2.GetOrdinal("iconos"));
                        modulosNietos.FrmModulo = Dr4.GetString(Dr4.GetOrdinal("url"));
                        modulosNietos.OrdenHijo = Dr4.GetInt32(Dr4.GetOrdinal("ordenHijo"));
                        modulosNietos.OrdenPadre = Dr4.GetInt32(Dr4.GetOrdinal("ordenPadre"));
                        modulosNietos.Nieto = Dr4.GetInt32(Dr4.GetOrdinal("nieto"));
                        listaIdsNietos.Add(modulosNietos);
                    }
                    user.ModuloNietos = listaIdsNietos;
                    user.Band = true;
                }
            }
            return user;
        }
    }
}
