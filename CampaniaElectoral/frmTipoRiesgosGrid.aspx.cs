﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmTipoRiesgosGrid : System.Web.UI.Page
    {
        public List<RR_TipoRiesgos> Lista = new List<RR_TipoRiesgos>();
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
                        RR_TipoRiesgos Datos =
                            new RR_TipoRiesgos
                            {
                                Conexion = Comun.Conexion,
                                IDTipoRiesgo = AuxID,
                                IDUsuario = Comun.IDUsuario
                            };
                        RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                        CN.EliminarTipoRiesgoXID(Datos);
                        if (Datos.Completado)
                        {
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
                this.CargarGrid();

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

        public void CargarGrid()
        {
            try
            {
                RR_TipoRiesgos Datos = new RR_TipoRiesgos() { Conexion = Comun.Conexion };
                RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoTipoRiesgo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}