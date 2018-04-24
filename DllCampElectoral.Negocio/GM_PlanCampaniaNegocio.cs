using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using DllCampElectoral.Datos;

namespace DllCampElectoral.Negocio
{
    public class GM_PlanCampaniaNegocio
    {
        public void AGPlanCampania(GM_PlanCampania Data)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                PC.AGPlanCampania(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerListCampania(GM_PlanCampania Data)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                return PC.ObtenerPlanCampania(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GM_PlanCampania> ObtenerListCampaniaMas(GM_PlanCampania Data)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                return PC.ObtenerListCampaniaMas(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerIdPlanCampania(GM_PlanCampania Data)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                PC.ObtenerDetallePlanCampania(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarIdCampania(GM_PlanCampania Datos)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                PC.EliminarPlanCampaniaID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Extra Web
        public List<GM_PlanCampania> ObtenerListCampania1(GM_PlanCampania Data)
        {
            try
            {
                GM_PlanCampaniaDatos PC = new GM_PlanCampaniaDatos();
                return PC.ObtenerPlanCampania1(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarImagenID(CH_Foto Datos)
        {
            try
            {
                GM_PlanCampaniaDatos FD = new GM_PlanCampaniaDatos();
                FD.CargaImageID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
        #endregion

        #region Fotos Plan Camapaña

        public void CargarFotoPlanCampania(GM_PlanCampania Datos)
        {
            try
            {
                GM_PlanCampaniaDatos FD = new GM_PlanCampaniaDatos();
                FD.CargarFotoPlanCampania(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GM_PlanCampania> ObtenerCatalogoFotos(GM_PlanCampania Datos)
        {
            try
            {
                GM_PlanCampaniaDatos FD = new GM_PlanCampaniaDatos();
                return FD.ObtenerCatalogoFotos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
