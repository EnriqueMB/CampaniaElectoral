using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class WN_CombosNegocio
    {

        #region CombosWill

        public DataTable ObtenerComboPadre(WN_Combos Datos)
        {
            
                WN_CombosDatos CD = new WN_CombosDatos();
                return CD.ObtenerComboPadre(Datos);
           
        }

        public DataTable ObtenerComboSuplente(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboSuplente(Datos);

        }


        public DataTable ObtenerComboSeccionesXPadre(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboSeccionesXPadre(Datos);

        }
        public DataTable ObtenerComboSeccionesXJefe(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboSeccionesXJefe(Datos);

        }
        public DataTable ObtenerComboCasillaXIDJefe(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboCasillaXIDJefe(Datos);

        }

        public DataTable ObtenerComboMunicipios(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboMunicipios(Datos);

        }

        public DataTable ObtenerComboSecciones(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboSecciones(Datos);

        }

        public DataTable ObtenerComboCasillasXSeccion(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboCasillasXSeccion(Datos);

        }


        public DataTable ObtenerComboTipoUsuario(WN_Combos Datos)
        {

            WN_CombosDatos CD = new WN_CombosDatos();
            return CD.ObtenerComboTipoUsuario(Datos);

        }

        #endregion
    }
}
