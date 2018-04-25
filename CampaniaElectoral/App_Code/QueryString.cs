using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CampaniaElectoral.App_Code
{
    public class QueryString : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }

        private void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Response.ContentType.ToLower() == "text/html" && !app.Request.Path.ToLower().EndsWith(".asmx"))
            {
                app.Response.Filter = new QueryStringEncryptionResponseFilter(app.Response.Filter);
            }
        }

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            NameValueCollection queryCollection = app.Request.QueryString;
            PropertyInfo isReadOnly = typeof(NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            isReadOnly.SetValue(queryCollection, false, null);
            string queryName = QueryStringName;
            //string pwd = Password;
            string encQuery = queryCollection[queryName];
            if (!string.IsNullOrEmpty(encQuery))
            {
                try
                {
                    string query = Decrypt(encQuery);
                    MethodInfo fillFromString;
                    fillFromString = queryCollection.GetType().GetMethod("FillFromString", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(String), typeof(Boolean), typeof(System.Text.Encoding) }, null);
                    fillFromString.Invoke(queryCollection, new object[] { query, false, System.Text.Encoding.UTF8 });
                    queryCollection.Remove(queryName);
                }
                catch (Exception ex)
                {
                    if (app.User != null && app.User.Identity.IsAuthenticated)
                    {
                        throw ex;
                    }
                }
            }
            isReadOnly.SetValue(queryCollection, true, null);
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "183A4DD5D88A4AA";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "183A4DD5D88A4AA";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string QueryStringName
        {
            get { return "enc"; }
        }
        
        public static string EncryptQueryString(string query)
        {
            return String.Format("{0}={1}", QueryStringName, HttpUtility.UrlEncode(Encrypt(query)));
        }
        
        private class QueryStringEncryptionResponseFilter : Stream
        {
            private String _qsName;
            private Stream _stream;
            private static Regex _regexUrl = new Regex(@"(action|a href|location)=[""']?([^""'>]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

            public QueryStringEncryptionResponseFilter(Stream baseStream)
            {
                _stream = baseStream;
                _qsName = QueryString.QueryStringName;
            }

            #region Propiedades

            public override bool CanRead
            {
                get
                {
                    return _stream.CanRead;
                }
            }

            public override bool CanSeek
            {
                get
                {
                    return _stream.CanSeek;
                }
            }

            public override bool CanWrite
            {
                get
                {
                    return _stream.CanWrite;
                }
            }

            public override long Length
            {
                get
                {
                    return _stream.Length;
                }
            }

            public override long Position
            {
                get
                {
                    return _stream.Position;
                }
                set
                {
                    _stream.Position = value;
                }
            }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                string html = System.Text.Encoding.UTF8.GetString(buffer, offset, count);
                html = _regexUrl.Replace(html, QueryStringMatchEvaluator);
                Byte[] buffer2 = System.Text.Encoding.UTF8.GetBytes(html);
                _stream.Write(buffer2, 0, buffer2.Length);
            }

            #endregion
            
            private string QueryStringMatchEvaluator(System.Text.RegularExpressions.Match match)
            {
                try
                {
                    string url = match.Groups[2].Value;
                    int paramPos = url.IndexOf("?");
                    if (paramPos != -1)
                    {
                        string parametros = url.Substring(paramPos + 1);
                        if (parametros.Length > 0 && !parametros.StartsWith(_qsName))
                        {
                            if (parametros.IndexOf("&amp") != -1)
                            {
                                return match.Value.Replace(parametros, EncryptQueryString(parametros.Replace("&amp", "&")));
                            }
                            else
                            {
                                return match.Value.Replace(parametros, EncryptQueryString(parametros));
                            }
                        }
                    }
                    return match.Value;
                }
                catch (Exception)
                {
                    return match.Value;
                }
            }

        }

    }
}