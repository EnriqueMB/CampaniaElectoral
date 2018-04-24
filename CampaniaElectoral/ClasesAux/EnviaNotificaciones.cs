using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CampaniaElectoral.ClasesAux
{
    public static class EnviaNotificaciones
    {
        private static string ConcatParams(Dictionary<string, string> parameters)
        {
            bool FirstParam = true;
            StringBuilder Parametros = null;

            if (parameters != null)
            {
                Parametros = new StringBuilder();
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    Parametros.Append(FirstParam ? "" : "&");
                    Parametros.Append(param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value));
                    FirstParam = false;
                }
            }

            return Parametros == null ? string.Empty : Parametros.ToString();
        }

        public static string GetResponse_POST(string url, Dictionary<string, string> parameters)
        {
            try
            {
                //Concatenamos los parametros, OJO: NO se añade el caracter "?"
                string parametrosConcatenados = ConcatParams(parameters);

                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                wr.Method = "POST";

                wr.ContentType = "application/x-www-form-urlencoded";

                System.IO.Stream newStream;
                //Codificación del mensaje
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] byte1 = encoding.GetBytes(parametrosConcatenados);
                wr.ContentLength = byte1.Length;
                //Envio de parametros
                newStream = wr.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);

                // Obtiene la respuesta
                System.Net.WebResponse response = wr.GetResponse();
                // Stream con el contenido recibido del servidor
                newStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(newStream);
                // Leemos el contenido
                string responseFromServer = reader.ReadToEnd();

                // Cerramos los streams
                reader.Close();
                newStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (System.Web.HttpException ex)
            {
                if (ex.ErrorCode == 404)
                    throw new Exception("Not found remote service " + url);
                else throw ex;
            }
        }

        public static string EnviarMensaje(string deviceId, string title, string message, int Badge, int IDTipoCelular)
        {
            try
            {
                var applicationID = "AAAABORNVyo:APA91bHjHJlQyLRpRcVnAY8SEMxmS7juHhpDHtEr1qMvhyO-fm7oR7h2JzyworuInN_KCEm1i01AjhI4eg0kULlUoPYNrJLLcOECjDQxiBgGdAL8k2IafRbZEKNmg9-hYBQsU0gcYupe";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = message.ToUpper(),
                        title = title.ToUpper(),
                        sound = "default",
                        badge = Badge,
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                string aux = string.Format("Authorization: key={0}", applicationID);
                tRequest.Headers.Add(string.Format("Authorization:key={0}", applicationID));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                                //Response.Write(sResponseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
