using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
namespace CampaniaElectoral
{
    public partial class FrmConteoPREP : System.Web.UI.Page
    {
        public List<CH_Poligono> poligonos = new List<CH_Poligono>();

        public List<CH_PartidoPolitico> partidos = new List<CH_PartidoPolitico>();

        public CH_PartidoPolitico DatosGlobales = new CH_PartidoPolitico();

        public List<EM_Munucipios> municipios = new List<EM_Munucipios>();
        protected void Page_Load(object sender, EventArgs e)
        {

                CH_Poligono Datos = new CH_Poligono();
                Datos.Conexion = Comun.Conexion;
                Datos.IDEstado = 1;
                Datos.IDMunicipio = 1;

            ER_Secciones DatosSecciones = new ER_Secciones();
            DatosSecciones.Conexion = Comun.Conexion;
            
                CH_PoligonoNegocio CPN = new CH_PoligonoNegocio();
                poligonos = CPN.ObtenerComboPoligonos(Datos);
            DatosSecciones.opcion = 15;
            ER_SeccionesNegocio ESN = new ER_SeccionesNegocio();
            municipios=ESN.ObtenerComboMunicipios(DatosSecciones);

                CH_PartidoPolitico datos = new CH_PartidoPolitico { Conexion = Comun.Conexion };
                CH_CatalogosNegocio CPPN = new CH_CatalogosNegocio();
                partidos = CPPN.ObtenerCatalogoPartidos(datos);
                CPPN.ObtenerComboColaboradoresTipo(datos);
                 DatosGlobales = datos;

            if (!IsPostBack)
            {
                
            }
            else
            {

                
                   
                

                CH_Conteo conteo = new CH_Conteo();

                string idseccion = Request.Form["CmbSecciones"].ToString();
                string idcasilla = Request.Form["CmbCasilla"].ToString();
                string colaborador= Request.Form["cmbColaboradores"].ToString();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("IDPartido", typeof(int)), new DataColumn("Votos", typeof(int)),new DataColumn("alianza",typeof(bool)) });

                for (int i = 0; i < partidos.Count; i++)
                {
                    int id = Convert.ToInt32(partidos[i].IDPartido);
                    int voto = Convert.ToInt32(Request.Form[partidos[i].Siglas].ToString());
                    bool alianza = Convert.ToBoolean(partidos[i].alianza);
                    object[] FilaDatos = { id, voto,alianza };
                    dt.Rows.Add(id, voto,alianza);
                }

                #region Obtener datos de la imagen
                int size = fuploadImagen.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[size];

                fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, size);

                Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                #endregion

                #region recuperar datos de la vista


                #endregion

                #region Insertar imagen en la base de datos
                string imagenString = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, ImageFormat.Jpeg);

               
                #endregion

                this.Guardar("", dt, idseccion,idcasilla,colaborador, imagenString);
                   
            }

        }

        private void Guardar(string _IDCaptura, DataTable _TablaDatos,string _idSeccion,string _idCasilla,string colaborador,string imagen)
        {
            try
            {
                CH_Conteo DatosAux = new CH_Conteo
                {
                    IDCaptura = _IDCaptura,
                    TablaDatos = _TablaDatos,
                    IDUsuario = Comun.IDUsuario,
                    Conexion = Comun.Conexion,
                    UrlImagen = imagen
                };
                CH_ConteoNegocio CN = new CH_ConteoNegocio();
                CN.ACDetalleCapturaXID(DatosAux, _idSeccion, _idCasilla,colaborador);
                if (DatosAux.Completado)
                {
                    Response.Redirect("frmCapturas.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


    }
}