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
    public class EM_ContactoDatos
    {
        public EM_Contacto ObternerContacto(EM_Contacto Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "EM_spCSLDB_get_ContatoWeb");
                while (Dr.Read())
                {
                    Datos.Titulo = Dr.GetString(Dr.GetOrdinal("Titulo"));
                    Datos.Texto = Dr.GetString(Dr.GetOrdinal("Texto"));
                    Datos.Direccion = Dr.GetString(Dr.GetOrdinal("Direccion"));
                    Datos.Latitud = Dr.GetDouble(Dr.GetOrdinal("Latitud"));
                    Datos.Longitud = Dr.GetDouble(Dr.GetOrdinal("Longitud"));
                    Datos.Telefono = Dr.GetString(Dr.GetOrdinal("Telefono"));
                    Datos.Correo = Dr.GetString(Dr.GetOrdinal("Correo"));
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
