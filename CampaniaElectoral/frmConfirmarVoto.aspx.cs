using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System.Drawing;
using System.Drawing.Imaging;
using CampaniaElectoral.ClasesAux;

namespace CampaniaElectoral
{
    public partial class frmConfirmarVoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.cmbAfiliado.Enabled = false;
                CargarComboSeccion();
            }
            if (Request.Form.Count==10)
            {
                if (this.cmbAfiliado.SelectedValue != "0" && this.cmbSeccion.SelectedValue != "0")
                {
                    //Recuperar la Imagen
                    int size = imgLogo.PostedFile.ContentLength;
                    byte[] ImagenOriginal = new byte[size];
                    imgLogo.PostedFile.InputStream.Read(ImagenOriginal, 0, size);
                    Bitmap ImagenOriginalBinaria = new Bitmap(imgLogo.PostedFile.InputStream);
                    //Imsertar Imagen en la Base de Datos
                    string imagenString = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, ImageFormat.Jpeg);
                    RR_Afiliados afiliados = new RR_Afiliados()
                    {
                        IDAfiliado = this.cmbAfiliado.SelectedValue.ToString(),
                        Conexion = Comun.Conexion,
                        ImagenVoto = imagenString,
                        IDUsuario = Comun.IDUsuario
                    };
                    JL_AfiliadosNegocio AN = new JL_AfiliadosNegocio();
                    AN.ConfirmarVoto(afiliados);
                    if (afiliados.Completado)
                    {
                        Response.Redirect("frmConfirmarVoto.aspx", false);
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

        private void CargarComboAfiliado()
        {
            try
            {
                RR_Afiliados afiliados = new RR_Afiliados()
                {
                    Conexion = Comun.Conexion,
                    IDPoligono = this.cmbSeccion.SelectedValue.ToString()
                };
                JL_AfiliadosNegocio AN = new JL_AfiliadosNegocio();
                AN.ObtenerComboAfiliado(afiliados);
                this.cmbAfiliado.DataSource = afiliados.TablaDatos;
                this.cmbAfiliado.DataTextField = "Nombre";
                this.cmbAfiliado.DataValueField = "IDAfiliado";
                this.cmbAfiliado.DataBind();

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
                this.cmbAfiliado.Enabled = true;
                CargarComboAfiliado();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}