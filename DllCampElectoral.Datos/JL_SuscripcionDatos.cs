using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data;

namespace DllCampElectoral.Datos
{
    public class JL_SuscripcionDatos
    {
        public void GuardarSuscripcion(JL_Suscripcion Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "JL_spCSLDB_A_Suscripcion", Datos.correo);
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
