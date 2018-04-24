using CampaniaElectoral.ClasesAux;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmNuevaImagen : System.Web.UI.Page
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if(!fuploadImagen.HasFile)
            {
                
            }
            else
            {
                #region Obtener datos de la imagen
                int size = fuploadImagen.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[size];

                fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, size);

                Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                #endregion
                
                #region Insertar imagen en la base de datos
                string imagenString = ZM_ConversionBS.ToBase64String(ImagenOriginalBinaria, ImageFormat.Jpeg);

                string titulo = txtTituloImagenViewA.Text;
                if (titulo == string.Empty)
                    titulo ="Sin titulo";
                if (Request.QueryString["id"] != null)
                {
                    string IDusuario = Request.QueryString["id"];
                    Guardar(IDusuario, imagenString , titulo);
                }
                
                #endregion

                //string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                //imagPreview.ImageUrl = ImagenDataURL64;
            }

        }

        private void Guardar(string id_afiliado, string imagen, string titulo)
        {
            try
            {
                ZM_ImagenesAfiliados Datos = new ZM_ImagenesAfiliados()
                {
                    Option = 1,
                    IdAfiliado = id_afiliado,
                    Imagen = imagen,
                    Usuario = Comun.IDUsuario,
                    Titulo = titulo,
                    Conexion = Comun.Conexion
                    
                };
                ZM_CatalogosNegocio CN = new ZM_CatalogosNegocio();
                CN.CatalogoImagenes(Datos);
                if (Datos.Completado)
                {
                    
                    Response.Redirect("frmAfiliadosImagenesGrid.aspx?id="+ Request.QueryString["id"] +"", false);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar la imagen.", "Error",
                        ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image imagenOriginal, int alto)
        {
            var radio = (double)alto / imagenOriginal.Height;
            var nuevoAncho = (int)(imagenOriginal.Width * radio);
            var nuevoAlto = (int)(imagenOriginal.Height * radio);
            var nuevaImagenRedimencionada = new Bitmap(nuevoAncho, nuevoAlto);
            var g = Graphics.FromImage(nuevaImagenRedimencionada);
            g.DrawImage(imagenOriginal, 0, 0, nuevoAncho, nuevoAlto);
            return nuevaImagenRedimencionada;
        }

        public byte[] RedimencionarImagen(Bitmap ImagenOriginalBinaria)
        {
            System.Drawing.Image imtThumbnail;
            int tamanioThumbnail = 200;
            imtThumbnail = RedimencionarImagen(ImagenOriginalBinaria, tamanioThumbnail);
            byte[] bImagenThumbnail = new byte[tamanioThumbnail];
            ImageConverter convertidor = new ImageConverter();
            return (byte[])convertidor.ConvertTo(imtThumbnail, typeof(byte[]));

        }
        
    }
}