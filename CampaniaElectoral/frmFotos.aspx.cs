using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmFotos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID = Request.QueryString["id"].ToString();
                            CH_Foto DatosAux = new CH_Foto { Conexion = Comun.Conexion, IDFoto = ID };
                            CH_FotoNegocio CN = new CH_FotoNegocio();
                            CN.ObtenerDetalleFotoXID(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarDatos(DatosAux);
                            }
                            else
                            {
                                //Ocurrió un error
                                Response.Redirect("frmGaleriaFotos.aspx?error=" + "Error al cargar los datos&nError=1");
                            }
                        }
                        else
                            Response.Redirect("frmGaleriaFotos.aspx");
                    }
                    else
                        Response.Redirect("frmGaleriaFotos.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count > 0)
                {
                    bool Band = false;
                    if (imgLogo.HasFile) //Hay cambio de imagen
                    {
                        Band = true;
                    }
                    string txtTitle = Request.Form["ctl00$cph_MasterBody$txtTitle"].ToString();
                    string txtAlt = Request.Form["ctl00$cph_MasterBody$txtAlt"].ToString();
                    string txtDescripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString();
                    string txtUrlImg = Band ? imgLogo.PostedFile.FileName : string.Empty;
                    HttpPostedFile bannerImage = imgLogo.PostedFile as HttpPostedFile;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        bool NuevoRegistro = string.IsNullOrEmpty(AuxID);
                        this.Guardar(NuevoRegistro, AuxID, txtTitle, txtAlt, txtDescripcion, txtUrlImg, bannerImage, Band);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }

                }
            }
        }

        #region Métodos

        private void CargarDatos(CH_Foto DatosAux)
        {
            try
            {
                hf.Value = DatosAux.IDFoto;
                txtDescripcion.Value = DatosAux.Descripcion;
                txtTitle.Value = DatosAux.Title;
                txtAlt.Value = DatosAux.Alt;
                string BaseDir = Server.MapPath("");
               // BaseDir = BaseDir + DatosAux.URLImagen;
                if (File.Exists(BaseDir + DatosAux.URLImagen))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", DatosAux.URLImagen);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string ID, string Title, string Alt, string Descripcion, string FileName, HttpPostedFile PostedImage, bool BandCambioImagen)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName) : string.Empty;
                CH_Foto Datos = new CH_Foto
                {
                    NuevoRegistro = NuevoRegistro,
                    IDFoto = ID,
                    Title = Title,
                    Alt = Alt,
                    Descripcion = Descripcion,
                    Extension = FileExtension,
                    NombreArchivo = FileName,
                    CambioImagen = BandCambioImagen,
                    URLImagen = BaseDir,
                    Conexion = Comun.Conexion,
                    IDUsuario = User.Identity.Name
                };
                CH_FotoNegocio FN = new CH_FotoNegocio();
                FN.ACFoto(Datos);
                if (Datos.Completado)
                {
                    if (BandCambioImagen)
                    {
                        if (PostedImage != null && PostedImage.ContentLength > 0)
                        {
                            try
                            {
                                string BaseDirMarca = Server.MapPath("~/Images/MarcaAgua/watermark_final.png");
                                if (File.Exists(BaseDirMarca))
                                {
                                    Stream S = PostedImage.InputStream;
                                    System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                                    Img = UtilImagen.ResizeImageW(Img, 1024);
                                    Img = UtilImagen.ResizeImageH(Img, 700);
                                    System.Drawing.Image Marca = System.Drawing.Image.FromFile(BaseDirMarca);
                                    Img = UtilImagen.SetWaterMark("", Img, Marca);
                                    Img.Save(BaseDir + Datos.URLImagen);
                                    FN.ImagenSubidaFotoXID(Datos);
                                }
                                else
                                {
                                    throw new Exception("No existe la imagen.");
                                }
                            }
                            catch (Exception)
                            {
                                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Ocurrió un error al guardar la imagen.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            }
                        }
                    }
                    Response.Redirect("frmGaleriaFotos.aspx", false);
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

        private void IniciarDatos()
        {
            try
            {
                hf.Value = "";
                txtTitle.Value = string.Empty;
                txtDescripcion.Value = string.Empty;
                txtAlt.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}