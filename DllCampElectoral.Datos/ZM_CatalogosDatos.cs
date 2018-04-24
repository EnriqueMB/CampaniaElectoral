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
    public class ZM_CatalogosDatos
    {
        public List<ZM_ImagenesAfiliados> ObtenerCatalogoImagenes(ZM_ImagenesAfiliados Datos)
        {
            
            try
            {
                object[] Parametros = { Datos.IdAfiliado };
                List<ZM_ImagenesAfiliados> Lista = new List<ZM_ImagenesAfiliados>();
                ZM_ImagenesAfiliados Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "ZM_spCSLDB_getImagenesAfiliados", Parametros);
                while (Dr.Read())
                {
                    Item = new ZM_ImagenesAfiliados();
                    Item.IdImagenAfiliado = Dr.GetString(Dr.GetOrdinal(("id_imagenAfiliado")));
                    Item.IdAfiliado = Dr.GetString(Dr.GetOrdinal(("id_afiliado")));
                    Item.Titulo = Dr.GetString(Dr.GetOrdinal("titulo"));
                    Item.Imagen = Dr.GetString(Dr.GetOrdinal("Imagen"));
                    Item.FechaImagen = Dr.GetDateTime(Dr.GetOrdinal("fecins"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CatalogoImagenes(ZM_ImagenesAfiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.Option, Datos.IdAfiliado, Datos.Imagen, Datos.Usuario, Datos.Titulo };
                Object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "ZM_spCSLDB_setImagenAfiliados", Parametros);
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

        public void EliminarImagenAfiliado(ZM_ImagenesAfiliados Datos)
        {
            try
            {
                object[] Parametros = { Datos.IdImagenAfiliado };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "ZM_spCSLDB_quitImagenAfiliados", Parametros);
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
