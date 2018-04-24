using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace CampaniaElectoral.ClasesAux
{
    public static class UtilImagen
    {
        public static Image ResizeImageW(Image srcImage, int newWidth)
        {
            try
            {
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newWidth * 100) / Width;
                int newHeight = (int)(Heigth * (Porc / 100));
                Bitmap imagen = new Bitmap(srcImage);
                Bitmap nuevaImagen = new Bitmap(newWidth, newHeight);
                nuevaImagen.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);
                Graphics gr = Graphics.FromImage(nuevaImagen);
                //DIBUJAMOS LA NUEVA IMAGEN
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);
                //LIBERAMOS RECURSOS
                gr.Dispose();
                return nuevaImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image ResizeImageH(Image srcImage, int newHeight)
        {
            try
            {
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newHeight * 100) / Heigth;
                int newWidth = (int)(Width * (Porc / 100));
                Bitmap imagen = new Bitmap(srcImage);
                Bitmap nuevaImagen = new Bitmap(newWidth, newHeight);
                nuevaImagen.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);
                Graphics gr = Graphics.FromImage(nuevaImagen);
                //DIBUJAMOS LA NUEVA IMAGEN
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);
                //LIBERAMOS RECURSOS
                gr.Dispose();
                return nuevaImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            try
            {
                //Primero, se reduce el ancho y largo de la imagen a las proporciones dadas por y, 
                int Width = srcImage.Width;
                int Heigth = srcImage.Height;
                decimal Porc = (newWidth * 100) / Width;
                int auxHeight = (int)(Heigth * (Porc / 100));
                // Si el nuevo y es menor 
                if(auxHeight > newHeight)
                {
                    Porc = (newHeight * 100) / auxHeight;
                    newWidth = (int)(newWidth * (Porc / 100));
                }
                else
                {
                    newHeight = auxHeight;
                }
                Bitmap imagen = new Bitmap(srcImage);
                Bitmap nuevaImagen = new Bitmap(newWidth, newHeight);
                nuevaImagen.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);
                Graphics gr = Graphics.FromImage(nuevaImagen);
                //DIBUJAMOS LA NUEVA IMAGEN
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);
                //LIBERAMOS RECURSOS
                gr.Dispose();
                return nuevaImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image SetWaterMark(string Copyright, Image imgPhoto, Image imgWatermark)
        {
            try
            {
                int phWidth = imgPhoto.Width;
                int phHeight = imgPhoto.Height;

                Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(72, 72);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.DrawImage(
                    imgPhoto,
                    new Rectangle(0, 0, phWidth, phHeight),
                    0,
                    0,
                    phWidth,
                    phHeight,
                    GraphicsUnit.Pixel);

                int wmWidth = imgWatermark.Width;
                int wmHeight = imgWatermark.Height;
                Bitmap bmWatermark = new Bitmap(bmPhoto);
                bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                Graphics grWatermark = Graphics.FromImage(bmWatermark);
                ImageAttributes imageAttributes = new ImageAttributes();
                ColorMap colorMap = new ColorMap();
                colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                ColorMap[] remapTable = { colorMap };

                imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
                float[][] colorMatrixElements =
                    { new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                    new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                    new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                    new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                    new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f} };

                ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

                imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                int xPosOfWm = ((phWidth - wmWidth) - 30);
                int yPosOfWm = 30;

                grWatermark.DrawImage
                    (imgWatermark,
                    new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight),
                    0,
                    0,
                    wmWidth,
                    wmHeight,
                    GraphicsUnit.Pixel,
                    imageAttributes);

                imgPhoto = bmWatermark;
                grWatermark.Dispose();
                //if (imgPhoto.Width > 1024)
                //    imgPhoto = UtilImagen.ResizeImageW(imgPhoto, 1024);
                return imgPhoto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static ImageFormat GetFormatImage(string Extension)
        {
            try
            {
                ImageFormat Format = ImageFormat.Jpeg;
                switch (Extension.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        Format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        Format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        Format = ImageFormat.Png;
                        break;
                    case ".icon":
                        Format = ImageFormat.Icon;
                        break;
                    case ".gif":
                        Format = ImageFormat.Gif;
                        break;
                }
                return Format;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}