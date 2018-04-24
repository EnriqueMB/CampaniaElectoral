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
    public partial class frmMiembrosEquipoTrabajo : System.Web.UI.Page
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
                            if (Request.QueryString["id"].ToString() == ID)
                            {
                                //Obtener los datos y dibujarlos.
                                RR_MiembrosEquipoTrabajo DatosAux = new RR_MiembrosEquipoTrabajo { Conexion = Comun.Conexion, IDMiembroEquipo = ID };
                                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                                //CN.ObtenerDetalleColaboradoresXID(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.CargarDatos(DatosAux);
                                }
                                else
                                {
                                    //Ocurrió un error
                                    Response.Redirect("frmColaboradores.aspx?error=" + "Error al cargar los datos&nError=1");
                                }
                            }
                            else
                            {
                                Response.Redirect("frmColaboradores.aspx");
                            }
                        }
                        else
                            Response.Redirect("frmColaboradores.aspx");
                    }
                    else
                        Response.Redirect("frmColaboradores.aspx");
                }
                else
                {
                    this.IniciarDatos();
                }
            }
            else
            {
                if (Request.Form.Count == 10 || Request.Form.Count == 12 || Request.Form.Count == 14 || Request.Form.Count == 16
                    || Request.Form.Count == 18 || Request.Form.Count == 20)
                {
                    bool isfacebook = false;
                    bool isinstagram = false;
                    bool isgoogle = false;
                    bool isprinterest = false;
                    bool istwitter = false;
                    bool Band = false;
                    string IDMiembroEquipo = "";
                    if (imgImagen.HasFile) //Hay cambio de imagen
                    {
                        Band = true;
                    }
                    string txtNomb                              = Request.Form["ctl00$cph_MasterBody$txtNombre"].ToString();
                    string txtApePat                            = Request.Form["ctl00$cph_MasterBody$txtApePat"].ToString();
                    string txtApeMat                            = Request.Form["ctl00$cph_MasterBody$txtApeMat"].ToString();
                    string txtPuesto                            = Request.Form["ctl00$cph_MasterBody$txtOcupacion"].ToString();
                    string txtPagWeb                            = Request.Form["ctl00$cph_MasterBody$txtPagWeb"].ToString();
                    string txtFb                                = Request.Form["ctl00$cph_MasterBody$txtfb"] != null ? Request.Form["ctl00$cph_MasterBody$txtfb"].ToString() : string.Empty;
                    string txtTw                                = Request.Form["ctl00$cph_MasterBody$txtTw"] != null ? Request.Form["ctl00$cph_MasterBody$txtTw"].ToString() : string.Empty;
                    string txtGo                                = Request.Form["ctl00$cph_MasterBody$txtGo"] != null ? Request.Form["ctl00$cph_MasterBody$txtGo"].ToString() : string.Empty;
                    string txtInst                              = Request.Form["ctl00$cph_MasterBody$txtIns"] != null ? Request.Form["ctl00$cph_MasterBody$txtIns"].ToString() : string.Empty;
                    string txtPrint                             = Request.Form["ctl00$cph_MasterBody$txtPri"] != null ? Request.Form["ctl00$cph_MasterBody$txtPri"].ToString() : string.Empty;
                    string facebook                             = Request.Form["ckfb"] != null ? Request.Form["ckfb"].ToString() : string.Empty;
                    string twitter                              = Request.Form["cktw"] != null ? Request.Form["cktw"].ToString() : string.Empty;
                    string google                               = Request.Form["ckgo"] != null ? Request.Form["ckgo"].ToString() : string.Empty;
                    string instagram                            = Request.Form["ckIns"] != null ? Request.Form["ckIns"].ToString() : string.Empty;
                    string pinterest                            = Request.Form["ckPri"] != null ? Request.Form["ckPri"].ToString() : string.Empty;
                    if (bool.TryParse(facebook, out isfacebook) == true)
                    {
                        isfacebook = true;
                    }
                    if (bool.TryParse(twitter, out istwitter) == true)
                    {
                        istwitter = true;
                    }
                    if (bool.TryParse(instagram, out isinstagram) == true)
                    {
                        isinstagram = true;
                    }
                    if (bool.TryParse(google, out isgoogle) == true)
                    {
                        isgoogle = true;
                    }
                    if (bool.TryParse(pinterest, out isprinterest) == true)
                    {
                        isprinterest = true;
                    }
                    string txtUrlImg = Band ? imgImagen.PostedFile.FileName : string.Empty;
                    HttpPostedFile bannerImage = imgImagen.PostedFile as HttpPostedFile;
                    try
                    {
                        string AuxID = Request.Form["ctl00$cph_MasterBody$hf"].ToString();
                        IDMiembroEquipo = AuxID;
                        bool NuevoRegistro = string.IsNullOrEmpty(IDMiembroEquipo);
                        this.Guardar(NuevoRegistro, IDMiembroEquipo, txtNomb, txtApePat, txtApeMat, txtPuesto, txtPagWeb, isfacebook, istwitter, isinstagram, isgoogle, isprinterest,
                            txtFb, txtTw, txtGo, txtInst, txtPrint, txtUrlImg, bannerImage, Band);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("ErrorPage.aspx?msjError=" + ex.Message);
                    }
                }
                else
                {

                }
            }
        }


        #region Métodos

        private void CargarDatos(RR_MiembrosEquipoTrabajo DatosAux)
        {
            try
            {
                hf.Value           = DatosAux.IDMiembroEquipo.ToString();
                txtNombre.Value    = DatosAux.Nombre;
                txtApePat.Value    = DatosAux.ApePat;
                txtApeMat.Value    = DatosAux.ApeMat;
                txtOcupacion.Value = DatosAux.Puesto;
                txtPagWeb.Value    = DatosAux.PagWeb;
                txtfb.Value        = DatosAux.Fb;
                txtTw.Value        = DatosAux.Tw;
                txtGo.Value        = DatosAux.Goo;
                txtIns.Value       = DatosAux.Ins;
                string ScriptError = @"
                    $(document).ready(
                        function() {                        
                        document.getElementById('ckfb').value  =" + DatosAux.IsFb + @";                        
                        document.getElementById('cktw').value  =" + DatosAux.IsTw + @";                        
                        document.getElementById('ckgo').value  =" + DatosAux.IsGoo + @";                        
                        document.getElementById('ckIns').value =" + DatosAux.IsInst + @";                        
                        document.getElementById('ckPri').value =" + DatosAux.IsPrin + @";
                        document.getElementById('txtPri').value=" + DatosAux.Print + @";

                    });";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                Response.Cookies.Clear();                
                string BaseDir     = Server.MapPath("~/Images/MiembrosEquipo/");
                if (File.Exists(BaseDir + DatosAux.UrlImagen))
                {
                    Logo.Attributes.Remove("src");
                    Logo.Attributes.Add("src", "Images/MiembrosEquipo/" + DatosAux.UrlImagen);
                }
                else
                {

                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Guardar(bool nuevoRegistro, string id, string nombre, string apPat, string apMat, string puesto, string pagWeb, bool isFb, bool isTw, bool isGoo,
            bool isInst, bool isPrint, string txtFb, string txtTw, string txtGoo, string txtInst, string txtPrint, string FileName, HttpPostedFile PostedImage, bool BandCambioImagen)
        {
            try
            {
                string BaseDir = Server.MapPath("");
                string FileExtension = BandCambioImagen ? Path.GetExtension(FileName) : string.Empty;
                RR_MiembrosEquipoTrabajo Datos = new RR_MiembrosEquipoTrabajo
                {
                    NuevoRegistro    = nuevoRegistro,
                    IDMiembroEquipo  = id,
                    Nombre           = nombre,
                    ApePat           = apPat,
                    ApeMat           = apMat,
                    Puesto           = puesto,
                    PagWeb           = pagWeb,
                    IsFb             = isFb,
                    IsGoo            = isGoo,
                    IsInst           = isInst,
                    IsTw             = isTw,
                    IsPrin           = isPrint,
                    Fb               = txtFb,
                    Goo              = txtGoo,
                    Ins              = txtInst,
                    Tw               = txtTw,
                    Print            = txtPrint,                 
                    ExtrancionImagen = FileExtension,
                    CambiarImagen    = BandCambioImagen,
                    UrlImagen        = BaseDir,
                    Conexion         = Comun.Conexion,
                    IDUsuario        = User.Identity.Name
                };
                RR_AdministradorWebNegocio CN = new RR_AdministradorWebNegocio();
                CN.ACCatalogoMiembrosEquipoTrabajo(Datos);
                Datos.Completado = true;
                if (Datos.Completado)
                {
                    if (BandCambioImagen)
                    {
                        if (PostedImage != null && PostedImage.ContentLength > 0)
                        {
                            try
                            {
                                Stream S = PostedImage.InputStream;
                                System.Drawing.Image Img = new System.Drawing.Bitmap(S);
                                Img.Save(BaseDir + Datos.UrlImagen);
                                //CN.ImagenSubidaColaboradroXID(Datos);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    Response.Redirect("frmMiembrosEquipoTrabajo.aspx", false);
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
                //BasicCrypto BC   = new BasicCrypto();
                //hf.Value         = BC.Encripta("-1");
                string txt         = string.Empty;
                hf.Value           = "";
                txtNombre.Value    = string.Empty;
                txtApePat.Value    = string.Empty;
                txtApeMat.Value    = string.Empty;
                txtOcupacion.Value = string.Empty;
                txtPagWeb.Value    = string.Empty;
                txtfb.Value        = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}