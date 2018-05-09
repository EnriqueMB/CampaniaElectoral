using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCampElectoral.Global
{
    public static class FG_Auxiliar
    {
        public static string ObtenerExtensionImagenBase64(string imagen64)
        {
            string extension = string.Empty;
            int position = 0;

            position = imagen64.IndexOf("iVBOR");
            if (position == 0)
                return extension = "image/png";

            position = imagen64.IndexOf("/9j/4");
            if (position == 0)
                return extension = "image/jpeg";

            return extension;
        }
        public static ImageFormat ObtenerExtensionImageFormat(string formato)
        {
            ImageFormat extension = null;

            switch (formato)
            {
                case ".png":
                    extension = ImageFormat.Png;
                    break;
                case ".jpg":
                    extension = ImageFormat.Jpeg;
                    break;
                case ".jpeg":
                    extension = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    extension = ImageFormat.Bmp;
                    break;
            }
            return extension;
        }
        public static Image ImageBase64ToImage(string imageBase64)
        {
            byte[] bytes = Convert.FromBase64String(imageBase64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
    }

}
