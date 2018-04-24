using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System.Data;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmTransferirAfiliados : System.Web.UI.Page
    {
        public  List<RR_Afiliados> afiliados = new List<RR_Afiliados>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.cmbOperadorDestino.Enabled = false;
                this.cmbOperadorOrigen.Enabled = true;
                CargarComboSeccion();
            }

            if (Request.Form.Count > 0)
            {
                if (cmbSeccion.SelectedValue!="0" && cmbOperadorDestino.SelectedValue != "0"  && cmbOperadorOrigen.SelectedValue!="0")
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("IDAfiliado", typeof(string));
                    table.Columns.Add("nombreCompleto", typeof(string));
                    CargarListaAfiliados();
                    foreach (var item in afiliados)
                    {
                        if (Request.Form["check" + item.IDAfiliado.ToString()]!=null)
                        {
                            string IDAfiliado = item.IDAfiliado.ToString();
                            string nombreCompleto = item.Nombre.ToString();

                            table.Rows.Add(new object[] { IDAfiliado, nombreCompleto });
                        }
                    }
                    RR_Afiliados afiliadosDatos = new RR_Afiliados()
                    {
                        Conexion=Comun.Conexion,
                        IDColaborador=this.cmbOperadorDestino.SelectedValue.ToString()
                    };
                    JL_AfiliadosNegocio AN = new JL_AfiliadosNegocio();
                    AN.TransferirAfiliados(afiliadosDatos, table);
                    if (afiliadosDatos.Completado)
                    {
                        Response.Redirect("frmTransferirAfiliados.aspx", false);
                    }
                    else
                    {
                        string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                        CargarComboSeccion();
                    }
                }
            }
        }
        private void CargarComboSeccion()
        {
            try
            {
                CH_Poligono poligono = new CH_Poligono();
                poligono.Conexion = Comun.Conexion;
                CH_PoligonoNegocio PN = new CH_PoligonoNegocio();
                PN.ObtenerComboSeccion(poligono);
                this.cmbSeccion.DataSource = poligono.dataTable;
                this.cmbSeccion.DataTextField = "Nombre";
                this.cmbSeccion.DataValueField = "IDPoligono";
                this.cmbSeccion.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
         
        private void CargarComboOperadorOrigen()
        {
            try
            {
                EM_CatColaborador colaborador = new EM_CatColaborador()
                {
                        Conexion = Comun.Conexion,
                        IDPoligono = this.cmbSeccion.SelectedValue.ToString()
                };

                JL_ColaboradorNegocio CN = new JL_ColaboradorNegocio();
                CN.ObteberComboColaborador(colaborador);
                this.cmbOperadorOrigen.DataSource = colaborador.TablaDatos;
                this.cmbOperadorOrigen.DataTextField = "Nombre";
                this.cmbOperadorOrigen.DataValueField = "IDColaborador";
                this.cmbOperadorOrigen.DataBind();

             }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarComboOperadorOrigenMenosUno()
        {
            try
            {
                EM_CatColaborador colaborador = new EM_CatColaborador()
                {
                    Conexion = Comun.Conexion,
                    IDPoligono = this.cmbSeccion.SelectedValue.ToString(),
                    IDColaborador = this.cmbOperadorOrigen.SelectedValue.ToString()
                };
                JL_ColaboradorNegocio CN = new JL_ColaboradorNegocio();
                CN.ObteberComboColaboradorMenosUno(colaborador);
                this.cmbOperadorDestino.DataSource = colaborador.TablaDatos;
                this.cmbOperadorDestino.DataTextField = "Nombre";
                this.cmbOperadorDestino.DataValueField = "IDColaborador";
                this.cmbOperadorDestino.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarListaAfiliados()
        {
            try
            {
                RR_Afiliados afiliadosDatos = new RR_Afiliados()
                {
                    Conexion = Comun.Conexion,
                    IDColaborador=this.cmbOperadorOrigen.SelectedValue.ToString()
                };
                JL_AfiliadosNegocio AN = new JL_AfiliadosNegocio();
                afiliados = AN.ObtenerListaAfiliados(afiliadosDatos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbOperadorOrigen.Enabled = true;
                this.CargarComboOperadorOrigen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void cmbOperadorOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbOperadorDestino.Enabled = true;
                CargarListaAfiliados();
                CargarComboOperadorOrigenMenosUno();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}