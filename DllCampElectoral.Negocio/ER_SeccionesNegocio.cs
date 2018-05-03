﻿using DllCampElectoral.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Negocio
{
   public class ER_SeccionesNegocio
    {
        public List<ER_Secciones> ObtenerComboSecciones(ER_Secciones Datos)
        {
            try
            {
                ER_SeccionesDatos CD = new ER_SeccionesDatos();
                return CD.ObtenerComboSecciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}