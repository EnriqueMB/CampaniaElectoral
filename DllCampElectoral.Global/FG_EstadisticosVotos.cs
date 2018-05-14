using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DllCampElectoral.Global
{
    public class FG_EstadisticosVotos
    {
        public int MetaVotosGeneral { get; set; }
        public int TotalVotosRealizados { get; set; }
        private int TotalVotosFaltantes { get; set; }
        private decimal _PorcentajeAvanceGeneralVotos;
        public string  sMetasXHora { get; set; }
        public string sTop5Colaboradores { get; set; }
        public string sMensajAvanceGeneral { get; set; }

        public string Conexion { get; set; }
        private CultureInfo cultureinfo = new CultureInfo("es-MX");

        #region SetGet
        public decimal PorcentajeAvanceGeneralVotos
        {
            get { return _PorcentajeAvanceGeneralVotos; }
            set { _PorcentajeAvanceGeneralVotos = Convert.ToDecimal(value, cultureinfo); }
        }
        #endregion
        #region Metodos

        public int ObtenerTotalVotosFaltantes()
        {
            TotalVotosFaltantes = MetaVotosGeneral - TotalVotosRealizados;
            return TotalVotosFaltantes;
        }
        public List<FG_EstadisticosVotos_MetaXHora> listaMetasXHora()
        {
            List<FG_EstadisticosVotos_MetaXHora> listaMetasXHora = new List<FG_EstadisticosVotos_MetaXHora>();
            FG_EstadisticosVotos_MetaXHora item;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sMetasXHora);

            XmlNodeList horario = xDoc.GetElementsByTagName("horario");
            XmlNodeList lista = ((XmlElement)horario[0]).GetElementsByTagName("item");

            foreach (XmlElement nodo in lista)
            {
                XmlNodeList nHoraEstablecida = nodo.GetElementsByTagName("horaEstablecida");
                XmlNodeList nMetaEstablecida = nodo.GetElementsByTagName("metaEstablecida");
                XmlNodeList nColorEtiqueta = nodo.GetElementsByTagName("colorEtiqueta");
                item = new FG_EstadisticosVotos_MetaXHora();
                item.Hora = TimeSpan.Parse(nHoraEstablecida[0].InnerText);
                item.Meta = decimal.Parse(nMetaEstablecida[0].InnerText, cultureinfo);
                item.ColorEtiqueta = nColorEtiqueta[0].InnerText;

                listaMetasXHora.Add(item);
            }
            return listaMetasXHora;
        }

        public List<FG_EstadisticosVotos_MensajeAvanceGeneral> listaMensajeAvanceGeneral()
        {
            List<FG_EstadisticosVotos_MensajeAvanceGeneral> listaMensajeAvanceGeneral = new List<FG_EstadisticosVotos_MensajeAvanceGeneral>();
            FG_EstadisticosVotos_MensajeAvanceGeneral item;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sMensajAvanceGeneral);

            XmlNodeList mensajeAvanceGeneral = xDoc.GetElementsByTagName("mensajeAvanceGeneral");
            XmlNodeList lista = ((XmlElement)mensajeAvanceGeneral[0]).GetElementsByTagName("item");

            foreach (XmlElement nodo in lista)
            {
                XmlNodeList nMensaje = nodo.GetElementsByTagName("mensaje");
                XmlNodeList nEtiqueta = nodo.GetElementsByTagName("etiqueta");

                item = new FG_EstadisticosVotos_MensajeAvanceGeneral();
                item.sMensaje = nMensaje[0].InnerText;
                item.sEtiqueta  = nEtiqueta[0].InnerText;

                listaMensajeAvanceGeneral.Add(item);
            }
            return listaMensajeAvanceGeneral;
        }

        public List<FG_EstadisticosVotos_JefeSeccion> listaJefeSeccion()
        {
            List<FG_EstadisticosVotos_JefeSeccion> listaJefeSeccion = new List<FG_EstadisticosVotos_JefeSeccion>();
            FG_EstadisticosVotos_JefeSeccion item;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sTop5Colaboradores);

            XmlNodeList mensajeAvanceGeneral = xDoc.GetElementsByTagName("colaboradores");
            XmlNodeList lista = ((XmlElement)mensajeAvanceGeneral[0]).GetElementsByTagName("row");

            foreach (XmlElement nodo in lista)
            {
                XmlNodeList nIDColaborador = nodo.GetElementsByTagName("id_colaborador");
                XmlNodeList nIDSeccion = nodo.GetElementsByTagName("id_seccion");
                XmlNodeList nNombreJefeSeccion = nodo.GetElementsByTagName("nombreJefeSeccion");
                XmlNodeList nImagen = nodo.GetElementsByTagName("Imagen");
                XmlNodeList nPorcentaje = nodo.GetElementsByTagName("porcentaje");
                XmlNodeList nMensaje = nodo.GetElementsByTagName("mensaje");
                XmlNodeList nEtiqueta = nodo.GetElementsByTagName("etiqueta");
                
                item = new FG_EstadisticosVotos_JefeSeccion();
                item.IDColaborador = nIDColaborador[0].InnerText;
                item.IDSeccion = int.Parse(nIDSeccion[0].InnerText);
                item.NombreJefeSeccion = nNombreJefeSeccion[0].InnerText;
                item.Imagen = nImagen[0].InnerText;
                item.Porcentaje = decimal.Parse(nPorcentaje[0].InnerText);
                item.Mensaje = nMensaje[0].InnerText;
                item.Etiqueta = nEtiqueta[0].InnerText;

                listaJefeSeccion.Add(item);
            }
            return listaJefeSeccion;
        }

        #endregion

    }
}
