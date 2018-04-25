using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using CampaniaElectoral.ClasesAux;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace CampaniaElectoral
{
    public partial class frmAfiliadosGrid : System.Web.UI.Page
    {
        public List<RR_Afiliados> Lista = new List<RR_Afiliados>();
        public string nombre;
        public string nombre1;
        public string nombre2;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["errorMessage"] != null)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al cargar los datos. Intenté nuevamente", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else
                {
                    int Opcion = 0;
                    string Buscar = string.Empty, AuxID = string.Empty;
                    DateTime Fecha1 = DateTime.Today, Fecha2 = DateTime.Today;
                    if (Request.QueryString["op"] != null) int.TryParse(Request.QueryString["op"].ToString(), out Opcion);
                    if (Request.QueryString["id"] != null) AuxID = Request.QueryString["id"].ToString();
                    if (Request.QueryString["Buscar"] != null) Buscar = Request.QueryString["Buscar"];

                    switch (Opcion)
                    {
                        case 1:
                        case 2:
                            this.CargarGrid(Opcion);
                            break;
                        case 3:
                            if (!string.IsNullOrEmpty(AuxID))
                                EliminarAfiliados(AuxID);
                            break;
                        case 6:
                            if (!string.IsNullOrEmpty(AuxID))
                                RatificarAfiliados(AuxID);
                            break;
                        case 7:
                            if (!string.IsNullOrEmpty(AuxID))
                                GenerarPDF(AuxID);
                            break;
                        case 9:
                            bool Rati;
                            int Ratificacio = 0;
                            int.TryParse(Buscar, out Ratificacio);
                            Rati = Ratificacio == 1;
                            this.BusquedaAfiliado(Opcion, string.Empty, Rati, Fecha1, Fecha2);
                            break;
                        case 10:
                            string[] s = Buscar.Split('-');
                            if (s.Length == 2)
                            {
                                DateTime.TryParseExact(s[0].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha1);
                                DateTime.TryParseExact(s[1].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha2);
                                this.BusquedaAfiliado(Opcion, Buscar, false, Fecha1, Fecha2);
                            }
                            break;
                        case 8:
                        case 11:
                        case 12:
                        case 13:
                            this.BusquedaAfiliado(Opcion, Buscar, false, Fecha1, Fecha2);
                            break;
                        default:
                            this.CargarGrid(1);
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("PageError.aspx?errorNumber=" + ex.HResult);
            }
        }
        
        public void GenerarPDF(string id)
        {
            try
            {
                RR_Afiliados DatosAux = new RR_Afiliados { Conexion = Comun.Conexion, IDAfiliado = id };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.ObtenerDetalleAfiliadoXID(DatosAux);

                Font fuente = new Font();
                DateTime fecha = DateTime.Today;
                string mes = MonthName(fecha.Month);
                int dia = fecha.Day;
                int anio = fecha.Year;
                var doc = new Document();
                nombre = DatosAux.Nombre + DatosAux.ApePat + DatosAux.ApeMat;
                string[] s = nombre.Split(' ');
                if (s.Length == 2)
                {
                    nombre1 = s[0].Trim();
                    nombre2 = s[1].Trim();
                    nombre = nombre1 + nombre2;
                }
                if (DatosAux.Completado)
                {
                    try
                    {

                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Pdf/") + nombre + ".pdf", FileMode.Create)); //Ubicacion del archivo
                        doc.Open();

                        string textoRenuncia =
                            "Por medio de la presente, manifiesto mi deseo de continuar afiliada(o) al " +
                            " " +
                            " y en este acto, renuncio a mi afiliación a cualquier otro Partido Político.\n\n\n";

                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        Font times = new Font(bfTimes, 16);
                        textoRenuncia = textoRenuncia.Replace(Environment.NewLine, String.Empty)
                            .Replace("  ", String.Empty);
                        Chunk beginning = new Chunk(textoRenuncia, times);

                        Chunk c = new Chunk("Anexo 1\n\n\n\n", times);
                        Chunk c1 = new Chunk(DatosAux.Estado + "a " + Convert.ToString(dia) + " de " + mes + " de " + Convert.ToString(anio) + "\n\n\n");
                        Chunk c2 = new Chunk("Instituto Nacional Electoral\n\n\n\n\n", times);
                        Chunk c3 = new Chunk(DatosAux.ApePat + "                                                                            " + DatosAux.ApeMat + "                                    ");
                        Chunk c4 = new Chunk("APELLIDO PATERNO                                                                  APELLIDO MATERNO                    ");
                        c4.SetUnderline(0.5f, 15f);
                        Chunk cn = new Chunk("\n\n\n");
                        Chunk c5 = new Chunk(DatosAux.Nombre);
                        Chunk c6 = new Chunk("                                                              NOMBRE(S)                                                                         ");
                        c6.SetUnderline(0.5f, 15f);
                        Chunk cn1 = new Chunk("\n\n\n");
                        Chunk c7 = new Chunk(DatosAux.Direccion + ", " + "#" + DatosAux.NumeroExt + ", " + DatosAux.NumeroInt + ", " + DatosAux.Colonia + ", " + DatosAux.CodigoPostal + ", " + DatosAux.Estado + ", " + DatosAux.Municipio);
                        Chunk c8 = new Chunk("                     DOMICILIO COMPLETO (Calle,No.Ext, No.Int, Col, C.P., Entidad, Municipio)             ");
                        c8.SetUnderline(0.5f, 15f);
                        Chunk c9 = new Chunk("\nCLAVE DE ELECTOR: " + DatosAux.ClaveElector);
                        Chunk cn2 = new Chunk("\n\n\n");
                        Chunk c10 = new Chunk("                 Firma o Huella digital del afiliado                    ");
                        c10.SetUnderline(0.5f, 15f);
                        Chunk c11 = new Chunk("\n\nCorreo electronico para recibir notificaciones: " + DatosAux.CorreoElect + "\n\n");
                        Chunk c12 = new Chunk("Número telefonico (incluyendo LADA): " + DatosAux.Celular + "\n\n");
                        Chunk c13 = new Chunk("Correo electronico de la Comisión de Afiliación para recibir notificaciones: derechosarcoprd@gmail.com");

                        Phrase p1 = new Phrase(beginning);
                        Phrase pc = new Phrase();
                        Phrase pc1 = new Phrase();
                        Phrase pc2 = new Phrase();
                        Phrase pc3 = new Phrase();
                        Phrase pc4 = new Phrase();
                        Phrase pcn = new Phrase();
                        Phrase pc5 = new Phrase();
                        Phrase pc6 = new Phrase();
                        Phrase pcn1 = new Phrase();
                        Phrase pc7 = new Phrase();
                        Phrase pc8 = new Phrase();
                        Phrase pc9 = new Phrase();
                        Phrase pcn2 = new Phrase();
                        Phrase pc11 = new Phrase();
                        Phrase pc12 = new Phrase();
                        Phrase pc13 = new Phrase();
                        Phrase pc14 = new Phrase();

                        pc.Add(c);
                        pc1.Add(c1);
                        pc2.Add(c2);
                        pc3.Add(c3);
                        pc4.Add(c4);
                        pcn.Add(cn);
                        pc5.Add(c5);
                        pc6.Add(c6);
                        pcn1.Add(cn1);
                        pc7.Add(c7);
                        pc8.Add(c8);
                        pc9.Add(c9);
                        pcn2.Add(cn2);
                        pc11.Add(c10);
                        pc12.Add(c11);
                        pc13.Add(c12);
                        pc14.Add(c13);

                        Paragraph parrafo1 = new Paragraph();
                        Paragraph parrafo2 = new Paragraph();
                        Paragraph parrafo3 = new Paragraph();
                        Paragraph parrafo4 = new Paragraph();
                        Paragraph salto = new Paragraph();
                        Paragraph parrafo5 = new Paragraph();
                        Paragraph parrafo6 = new Paragraph();
                        Paragraph parrafo7 = new Paragraph();
                        Paragraph salto1 = new Paragraph();
                        Paragraph parrafo8 = new Paragraph();
                        Paragraph parrafo9 = new Paragraph();
                        Paragraph parrafo10 = new Paragraph();
                        Paragraph parrafo11 = new Paragraph();
                        Paragraph parrafo12 = new Paragraph();
                        Paragraph parrafo13 = new Paragraph();
                        Paragraph parrafo14 = new Paragraph();
                        Paragraph parrafo15 = new Paragraph();
                        Paragraph parrafo16 = new Paragraph();

                        parrafo1.Add(pc);
                        parrafo1.Alignment = Element.ALIGN_RIGHT;
                        parrafo2.Add(pc1);
                        parrafo2.Alignment = Element.ALIGN_RIGHT;
                        parrafo3.Add(pc2);
                        parrafo4.Add(p1);
                        parrafo5.Add(pc3);
                        parrafo6.Add(pc4);
                        salto.Add(pcn);
                        parrafo7.Add(pc5);
                        parrafo7.Alignment = Element.ALIGN_CENTER;
                        salto1.Add(pcn1);
                        parrafo8.Add(pc6);
                        parrafo8.Alignment = Element.ALIGN_CENTER;
                        parrafo9.Add(pc7);
                        parrafo9.Alignment = Element.ALIGN_CENTER;
                        parrafo10.Add(pc8);
                        parrafo10.Alignment = Element.ALIGN_CENTER;
                        parrafo11.Add(pc9);
                        parrafo12.Add(pcn2);
                        parrafo13.Add(pc11);
                        parrafo13.Alignment = Element.ALIGN_CENTER;
                        parrafo14.Add(pc12);
                        parrafo15.Add(pc13);
                        parrafo16.Add(pc14);

                        doc.Add(parrafo1);
                        doc.Add(parrafo2);
                        doc.Add(parrafo3);
                        doc.Add(parrafo4);
                        doc.Add(parrafo5);
                        doc.Add(parrafo6);
                        doc.Add(salto);
                        doc.Add(parrafo7);
                        doc.Add(parrafo8);
                        doc.Add(salto1);
                        doc.Add(parrafo9);
                        doc.Add(parrafo10);
                        doc.Add(parrafo11);
                        doc.Add(parrafo12);
                        doc.Add(parrafo13);
                        doc.Add(parrafo14);
                        doc.Add(parrafo15);
                        doc.Add(parrafo16);
                    }
                    catch (DocumentException dex)

                    {
                        throw (dex);
                    }
                    catch (IOException ioex)
                    {
                        throw (ioex);
                    }
                    finally
                    {
                        doc.Close();
                        OpenPDF(Server.MapPath("~/Pdf/") + nombre + ".pdf");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarAfiliados(string id)
        {
            try
            {
                //int.TryParse(Request.QueryString["id"], out AuxID);
                RR_Afiliados Datos = new RR_Afiliados { Conexion = Comun.Conexion, IDAfiliado = id, IDUsuario = Comun.IDUsuario };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.EliminarAfiliadoXID(Datos);
                if (Datos.Completado)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void RatificarAfiliados(string id)
        {
            try
            {                
                RR_Afiliados Datos = new RR_Afiliados { Conexion = Comun.Conexion, IDAfiliado = id, IDUsuario = Comun.IDUsuario };
                RR_CatalogosNegocio CN = new RR_CatalogosNegocio();
                CN.RatificarAfiliadoXID(Datos);
                if (Datos.Completado)
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Success, "Registro eliminado correctamente.", "Información", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
                else
                {
                    string ScriptError = DialogMessage.Show(TipoMensaje.Error, "Error al guardar los datos.", "Error", ShowMethod.FadeIn, HideMethod.FadeOut, ToastPosition.TopFullWidth, true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", ScriptError, true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void CargarGrid(int opcion)
        {
            try
            {
                RR_Afiliados Datos = new RR_Afiliados() { Conexion = Comun.Conexion,opcion=opcion};
                RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
                Lista = GN.ObtenerCatalogoAfiliado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BusquedaAfiliado(int Op, string Busq, bool Ratificado, DateTime FechaIni, DateTime FechaFin)
        {
            RR_Afiliados Datos = new RR_Afiliados()
            {
                Resultado = Op,
                Nombre    = Busq,
                Ratificacion = Ratificado,
                Fecha1    = FechaIni,
                Fecha2    = FechaFin,
                Conexion = Comun.Conexion
            };
            RR_CatalogosNegocio GN = new RR_CatalogosNegocio();
            Lista = GN.ObtenerCatalogoAfiliadoBusqueda(Datos);
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private void OpenPDF(string filePath)
        {
            Response.AddHeader("Content-Disposition", "attachment;filename="+nombre+".pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile((filePath));
            //Response.End();
        }
    }
}