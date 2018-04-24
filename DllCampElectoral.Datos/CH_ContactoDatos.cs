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
    public class CH_ContactoDatos
    {
        public void AC_DatosDeContacto(CH_Contacto Datos)
        {
            try
            {
                object[] Parametros = { Datos.Direccion, Datos.Latitud, Datos.Longitud, Datos.Telefono, Datos.Correo, Datos.TituloContacto, Datos.TextoContacto, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "CH_spCSLDB_AC_DatosContacto", Parametros);
                if(Result !=  null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                    }
                    Datos.Resultado = Resultado;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosContacto(CH_Contacto Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_DatosContacto");
                while(Dr.Read())
                {
                    Datos.Direccion = Dr.GetString(Dr.GetOrdinal("Direccion"));
                    Datos.Correo = Dr.GetString(Dr.GetOrdinal("Correo"));
                    Datos.Telefono = Dr.GetString(Dr.GetOrdinal("Telefonos"));
                    Datos.Latitud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Datos.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Datos.TituloContacto = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.TextoContacto = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Datos.Completado = true;
                    break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
