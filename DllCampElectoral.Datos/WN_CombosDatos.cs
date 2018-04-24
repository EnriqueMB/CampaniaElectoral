using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using Microsoft.ApplicationBlocks.Data; 

namespace DllCampElectoral.Datos
{
    public class WN_CombosDatos
    {

        public DataTable ObtenerComboPadre(WN_Combos Datos)
        {
            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos",1, "",Datos.Parametro01Int);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];

            return null;

        }

        public DataTable ObtenerComboSuplente(WN_Combos Datos)
        {
            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos", 2, "", Datos.Parametro01Int);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
            return null;

        }


        public DataTable ObtenerComboSeccionesXPadre(WN_Combos Datos)
        {
            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos", 3,Datos.Parametro01String,0);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
            return null;


        }



        public DataTable ObtenerComboSecciones(WN_Combos Datos)
        {

            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos", 4,"",0);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
            return null;


        }

        public DataTable ObtenerComboCasillasXSeccion(WN_Combos Datos)
        {
            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos", 5, Datos.Parametro01String,0);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
            return null;


        }

        public DataTable ObtenerComboTipoUsuario(WN_Combos Datos)
        {
            DataSet ds;

            ds = SqlHelper.ExecuteDataset(Datos.CadenaConexion, "WN_spCSLDB_get_Combos", 6, "", 0);
            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                        return ds.Tables[0];
            return null;


        }


    }
}
