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
   public class EC_EquipoTrabajoDatos
    {
        public List<EC_EquipoTrabajo> ObtenerMiembrosEquipo(EC_EquipoTrabajo Datos)
        {
            try
            {
                List<EC_EquipoTrabajo> Lista = new List<EC_EquipoTrabajo>();
                EC_EquipoTrabajo Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "RR_spCSLDB_get_MiembrosEquipoTrabajo");
                while (Dr.Read())
                {
                    Item = new EC_EquipoTrabajo();
                    Item.nombreCompleto = Dr.GetString(Dr.GetOrdinal(("nombre")));
                    Item.paginaWeb = Dr.GetString(Dr.GetOrdinal(("paginaWeb")));
                    Item.Puesto = Dr.GetString(Dr.GetOrdinal(("puesto")));
                    Item.urlImagen = Dr.GetString(Dr.GetOrdinal(("urlImagen")));
                    Item.ctaFB = Dr.GetString(Dr.GetOrdinal(("cuenta1")));
                    Item.ctaGoog = Dr.GetString(Dr.GetOrdinal(("cuenta2")));
                    Item.ctaTW= Dr.GetString(Dr.GetOrdinal(("cuenta3"))); 
                    Item.ctaInsta= Dr.GetString(Dr.GetOrdinal(("cuenta4")));
                    Item.ctaPint= Dr.GetString(Dr.GetOrdinal(("cuenta5")));
                    Item.facebook = Dr.GetString(Dr.GetOrdinal(("icono1")));
                    Item.twitter = Dr.GetString(Dr.GetOrdinal(("icono2")));
                    Item.google = Dr.GetString(Dr.GetOrdinal(("icono3")));
                    Item.instagram = Dr.GetString(Dr.GetOrdinal(("icono4")));
                    Item.pinterest = Dr.GetString(Dr.GetOrdinal(("icono5")));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EC_EquipoTrabajo> CargarGrid(EC_EquipoTrabajo Datos)
        {
            try
            {
                List<EC_EquipoTrabajo> Lista = new List<EC_EquipoTrabajo>();
                EC_EquipoTrabajo Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_EquipoTrabajoGrid");
                while (Dr.Read())
                {
                    Item = new EC_EquipoTrabajo();
                    Item.idEquipoTrabajo = Dr.GetString(Dr.GetOrdinal(("id_miembroEquipo")));
                    Item.nombreCompleto = Dr.GetString(Dr.GetOrdinal(("nombre")));
                    Item.fecha = Dr.GetDateTime(Dr.GetOrdinal(("fecha")));
                    Lista.Add(Item);
                }


                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ObtenerDetalleMiembroEquipo(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMiembroEquipo };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EC_spCSLDB_get_MiembroTrabajoDetalle ", Parametros);
                while (Dr.Read())
                {
                    Datos.Nombre = Dr.GetString(Dr.GetOrdinal("nombre"));
                    Datos.ApePat= Dr.GetString(Dr.GetOrdinal("apPaterno"));
                    Datos.ApeMat= Dr.GetString(Dr.GetOrdinal("apMaterno"));
                    Datos.Puesto= Dr.GetString(Dr.GetOrdinal("puesto"));
                    Datos.PagWeb= Dr.GetString(Dr.GetOrdinal("paginaWeb"));
                    Datos.IsFb = Dr.GetBoolean(Dr.GetOrdinal("redSocial1"));
                    Datos.IsGoo= Dr.GetBoolean(Dr.GetOrdinal("redSocial2"));
                    Datos.IsTw= Dr.GetBoolean(Dr.GetOrdinal("redSocial3"));
                    Datos.IsInst= Dr.GetBoolean(Dr.GetOrdinal("redSocial4"));
                    Datos.IsPrin= Dr.GetBoolean(Dr.GetOrdinal("redSocial5"));
                    Datos.Fb= Dr.GetString(Dr.GetOrdinal("cuenta1"));
                    Datos.Goo= Dr.GetString(Dr.GetOrdinal("cuenta2"));
                    Datos.Tw= Dr.GetString(Dr.GetOrdinal("cuenta3"));
                    Datos.Ins= Dr.GetString(Dr.GetOrdinal("cuenta4"));
                    Datos.Print= Dr.GetString(Dr.GetOrdinal("cuenta5"));
                    Datos.UrlImagen= Dr.GetString(Dr.GetOrdinal("urlImagen"));
                    Datos.ImagenGuardada= Dr.GetBoolean(Dr.GetOrdinal("imagenGuardada"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarMiembroEquipo(RR_MiembrosEquipoTrabajo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMiembroEquipo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EC_spCSLDB_del_MiembroEquipo", Parametros);
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
    }
}
