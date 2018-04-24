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
    public partial class frmBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se inicializan campos, datos, valores
                if (Request.QueryString["op"] != null)
                {
                    if (Request.QueryString["op"] == "2")
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            string ID;
                            ID = Request.QueryString["id"];
                            if (ID != null) //(int.TryParse(Request.QueryString["id"].ToString(), out ID))
                            {
                                ID = Request.QueryString["id"];
                                //Obtener los datos y dibujarlos.
                                RR_Blog DatosAux = new RR_Blog { Conexion = Comun.Conexion, IDPublicacion = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                CN.ObtenerPublicacionesBlogXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmBlogGrid.aspx?errorMessage=" + DatosAux.Completado);
                                }
                            }
                            else
                            {
                                Response.Redirect("frmBlogGrid.aspx?errorMessage=1");
                            }
                        }
                        else
                            Response.Redirect("frmBlogGrid.aspx?errorMessage=2");
                    }
                    else
                        Response.Redirect("frmBlogGrid.aspx?errorMessage=3");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 10)
                {
                    bool Band = false;
                    if (imgLogo.HasFile) //Hay cambio de imagen
                    {
                        Band = true;
                    }
                    string Titulo = Request.Form["ctl00$cph_MasterBody$txtTituloBlog"].ToString();
                    string Tittle = Request.Form["ctl00$cph_MasterBody$txtNombreImagen"].ToString();
                    string Alt = Request.Form["ctl00$cph_MasterBody$txtAlt"].ToString();
                    string Descripcion = Request.Form["ctl00$cph_MasterBody$txtDescripcion"].ToString(); 
                    string TextoHtml = Request.Form["ctl00$cph_MasterBody$txtBlog"].ToString();
                    string txtUrlImg = Band ? imgLogo.PostedFile.FileName : string.Empty;
                    HttpPostedFile bannerImage = imgLogo.PostedFile as HttpPostedFile;
                    int IDColab = -1;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        int.TryParse(AuxID, out IDColab);
                        bool NuevoRegistro = (AuxID == "-1");
                        this.Guardar(NuevoRegistro, AuxID, Titulo, Tittle, Alt, Descripcion, txtUrlImg, bannerImage, Band, TextoHtml);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
            }
        }

        #region Métodos

        private void CargarDatos(RR_Blog DatosAux)
        {
            try
            {
                hf.Value              = DatosAux.IDPublicacion.ToString();
                txtTituloBlog.Value   = DatosAux.Titulo;
                txtNombreImagen.Value = DatosAux.Title;
                txtAlt.Value          = DatosAux.Alt;
                txtDescripcion.Value  = DatosAux.Descripcion;
                txtBlog.InnerHtml     = DatosAux.TextoHtml;
                string BaseDir        = Server.MapPath("~/Images/FotosBlog/");
                if (File.Exists(DatosAux.UrlImagen))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", DatosAux.UrlImagen);
                }
                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool NuevoRegistro, string id, string titulo, string tittle, string alt, string descripcion, string FileName, HttpPostedFile PostedImage, bool BandCambioImagen, string textoHtml)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName) : string.Empty;
                RR_Blog Datos = new RR_Blog
                {
                    NuevoRegistro = NuevoRegistro,
                    IDPublicacion = ID,
                    Titulo        = titulo,
                    Fecha         = DateTime.Today,
                    TextoReducido = textoHtml.Substring(0,50),
                    TextoHtml     = textoHtml,
                    UrlImagen     = BaseDir,
                    CambioImagen  = BandCambioImagen,
                    Alt           = alt,
                    Title         = tittle,
                    Descripcion   = descripcion,
                    TipoArchivo   = FileExtension,                    
                    Conexion      = Comun.Conexion,
                    IDUsuario     = Comun.IDUsuario
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACPublicacionesBlog(Datos);
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
                                    Img.Save(Datos.UrlImagen);                                    
                                }
                                else
                                {
                                    throw new Exception("No existe la imagen.");
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                                string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Ocurrió un error al guardar la imagen.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                            }
                        }
                    }
                    Response.Redirect("frmBlogGrid.aspx", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error",
                        ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
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
                //BasicCrypto BC = new BasicCrypto();
                //hf.Value = BC.Encripta("-1");
                hf.Value = "-1";                
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        #endregion
    }
}