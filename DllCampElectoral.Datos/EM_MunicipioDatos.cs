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
   public class EM_MunicipioDatos
    {
        public void ACMunicipo(EM_Munucipios Datos)
        {
            try
            {
                object[] Parametros = { Datos.NuevoRegistro, Datos.IDMunicipio, Datos.IDEstado, Datos.MunicipioDesc, Datos.Sigla, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_AC_CatMunicipio", Parametros);
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

        public List<EM_Munucipios> ObtenerCatalagoMunicipio(EM_Munucipios Datos)
        {
            try
            {
                List<EM_Munucipios> Lista = new List<EM_Munucipios>();
                EM_Munucipios Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CatMunicipio");
                while (Dr.Read())
                {
                    Item = new EM_Munucipios();
                    Item.IDMunicipio = Dr.GetInt32(Dr.GetOrdinal("IDMunicipio"));
                    Item.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("MunicipioDesc"));
                    Item.Sigla = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    Item.DescripcionEstado = Dr.GetString(Dr.GetOrdinal("EstadoDesc"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObternerMunicipioXID(EM_Munucipios Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDMunicipio };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_CatMunicipioDetalleXID", Parametros);
                while (Dr.Read())
                {
                    Datos.IDEstado = Dr.GetInt32(Dr.GetOrdinal("IDEstado"));
                    Datos.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("MunicipioDesc"));
                    Datos.Sigla = Dr.GetString(Dr.GetOrdinal("Siglas"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarMunicipioXID(EM_Munucipios Datos)
        {
            object[] Parametro = { Datos.IDMunicipio, Datos.IDUsuario };
            object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "EM_spCSLDB_del_CatMunicipio", Parametro);
            int Resultado = 0;
            int.TryParse(Result.ToString(), out Resultado);
            if (Resultado == 1)
            {
                Datos.Completado = true;
            }
            Datos.Resultado = Resultado;
        }
    }
}
