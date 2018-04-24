using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmCapturaPREP : System.Web.UI.Page
    {
        public CH_Conteo Datos = new CH_Conteo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string ID = Request.QueryString["id"].ToString();
                    CH_Conteo DatosAux = new CH_Conteo { Conexion = Comun.Conexion, IDCaptura = ID };
                    CH_ConteoNegocio CN = new CH_ConteoNegocio();
                    CN.ObtenerDetalleCapturaXID(DatosAux);
                    if (DatosAux.Completado)
                    {
                        Datos = DatosAux;
                        hf.Value = Datos.IDCaptura;
                    }
                    else
                    {
                        //Ocurrió un error
                        Response.Redirect("frmCapturas.aspx?error=" + "Error al cargar los datos&nError=1");
                    }
                }
                else
                {
                    Response.Redirect("frmCapturas.aspx");
                }
            }
            else
            {
                if (Request.Form.Count > 0)
                {
                    string[] KeysForm = Request.Form.AllKeys;
                    DataTable TablaAux = new DataTable();
                    TablaAux.Columns.Add("IDPartido", typeof(int));
                    TablaAux.Columns.Add("Votos", typeof(int));
                    for (int i=0; i<KeysForm.Length; i++)
                    {
                        if(KeysForm[i].StartsWith("txtPartido"))
                        {
                            int IDPartido = 0, Votos = 0;
                            int.TryParse(KeysForm[i].Substring(10, KeysForm[i].Length - 10), out IDPartido);
                            int.TryParse(Request.Form[KeysForm[i]], out Votos);
                            object[] FilaDatos = { IDPartido, Votos };
                            TablaAux.Rows.Add(FilaDatos);
                        }
                    }
                    string IDCaptura = string.IsNullOrEmpty(hf.Value) ? string.Empty : hf.Value.ToString();
                    //this.Guardar(IDCaptura, TablaAux);
                }
            }
        }


        private void CargarDatos(CH_Conteo DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDCaptura;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //private void Guardar(string _IDCaptura, DataTable _TablaDatos)
        //{
        //    try
        //    {
        //        CH_Conteo DatosAux = new CH_Conteo
        //        {
        //            IDCaptura = _IDCaptura,
        //            TablaDatos = _TablaDatos,
        //            IDUsuario = Comun.IDUsuario,
        //            Conexion = Comun.Conexion
        //        };
        //        CH_ConteoNegocio CN = new CH_ConteoNegocio();
        //        CN.ACDetalleCapturaXID(DatosAux);
        //        if (DatosAux.Completado)
        //        {
        //            Response.Redirect("frmCapturas.aspx", false);
        //        }
        //        else
        //        {
        //            CN.ObtenerDetalleCapturaXID(DatosAux);
        //            Datos = DatosAux;
        //            string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void IniciarDatos()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}