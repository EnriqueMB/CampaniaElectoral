﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Negocio;

namespace CampaniaElectoral
{
    public partial class frmMunicipiosGrid : System.Web.UI.Page
    {
        public List<EM_Munucipios> ListaMunicipio = new List<EM_Munucipios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["op"] != null && Request.QueryString["op"] == "3")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int AuxID = 0;
                        int.TryParse(Request.QueryString["id"], out AuxID);
                        EM_Munucipios Datos = new EM_Munucipios { Conexion = Comun.Conexion, IDMunicipio = AuxID, IDUsuario = Comun.IDUsuario };
                        EM_MunicipioNegocio MN = new EM_MunicipioNegocio();
                        MN.EliminarMunicipioXID(Datos);
                        if (Datos.Completado)
                        {
                            //Mostrar mensaje Success
                            string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                        else
                        {
                            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        }
                    }
                }
                if (!IsPostBack)
                {

                }
                else
                {
                }

                this.CargarGridMunicipio();
                if (Request.QueryString["errorMessage"] != null)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
        public void CargarGridMunicipio()
        {
            try
            {
                EM_Munucipios Datos = new EM_Munucipios { Conexion = Comun.Conexion };
                EM_MunicipioNegocio MN = new EM_MunicipioNegocio();
                ListaMunicipio = MN.ObtenerCatalogoMunicipio(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}