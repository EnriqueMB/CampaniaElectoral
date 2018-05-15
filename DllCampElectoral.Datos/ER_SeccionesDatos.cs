using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public class ER_SeccionesDatos
    {
        public List<ER_Secciones> ObtenerComboSecciones(ER_Secciones Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "WN_spCSLDB_get_Combos", Datos.opcion, Datos.IDMunicipio.ToString(),0);
                List<ER_Secciones> Lista = new List<ER_Secciones>();
                ER_Secciones Item;
                while (Dr.Read())
                {
                    Item = new ER_Secciones();
                    int id = 0;
                    int.TryParse(Dr.GetInt32(Dr.GetOrdinal("ID")).ToString(), out id);
                    Item.IDSeccion = id;
                    Item.seccionDesc = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Lista.Add(Item);
                }
                Datos.listaSecciones = Lista;
                return Datos.listaSecciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ER_Casillas> ObtenerComboCasillas(ER_Secciones Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "WN_spCSLDB_get_Combos", Datos.opcion, Datos.IDSeccion, 0);
                List<ER_Casillas> Lista = new List<ER_Casillas>();
                ER_Casillas Item;
                while (Dr.Read())
                {
                    Item = new ER_Casillas();
                  
                    Item.DescCasilla = Dr.GetString(Dr.GetOrdinal("Nombre"));
                    int id = 0;//Dr.GetString(Dr.GetOrdinal("ID"));
                    int.TryParse(Dr.GetInt32(Dr.GetOrdinal("ID")).ToString(), out id);
                    Item.IDCasilla =id.ToString();
                    Lista.Add(Item);
                }
                Datos.listaCasillas = Lista;
                return Datos.listaCasillas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCasillaXID(CH_ZonaRiesgo Datos)
        {
            try
            {
                object[] Parametros = { Datos.IDCasilla };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "CH_spCSLDB_get_CasillaUbicacion", Parametros);
                while (Dr.Read())
                {double lat=0,longi= 0;
                    Datos.IDCasilla = Dr.GetInt32(Dr.GetOrdinal("id_casilla"));
                    double.TryParse(Dr.GetString(Dr.GetOrdinal("Latitud")), out lat);
                    double.TryParse(Dr.GetString(Dr.GetOrdinal("Longitud")), out longi);
                    Datos.Latitud = lat;
                    Datos.Longitud = longi;
                    Datos.Completado = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EM_Munucipios> ObtenerComboMunicipios(ER_Secciones Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "WN_spCSLDB_get_Combos", Datos.opcion,"",0);
                List<EM_Munucipios> Lista = new List<EM_Munucipios>();
                EM_Munucipios Item;
                while (Dr.Read())
                {
                    Item = new EM_Munucipios();
                    int id = 0;//Dr.GetString(Dr.GetOrdinal("ID"));
                    int.TryParse(Dr.GetInt32(Dr.GetOrdinal("ID")).ToString(), out id);
                    Item.IDMunicipio = id;
                    Item.MunicipioDesc = Dr.GetString(Dr.GetOrdinal("Nombre"));
                   
                    Lista.Add(Item);
                }
                Datos.listaMunicipios = Lista;
                return Datos.listaMunicipios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
