using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCampElectoral.Global;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Xml;

namespace DllCampElectoral.Datos
{
    public class EM_PreguntasRespuestaDatos
    {
        public EM_Encuesta ObtenerPreguntaRespuestaXID(EM_Encuesta Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "EM_spCSLDB_get_PreguntasRespuestaXID", Datos.IDEncuesta);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            Datos.IDEncuesta = !Dr.IsDBNull(Dr.GetOrdinal("IDRespuesta")) ? Dr.GetString(Dr.GetOrdinal("IDRespuesta")) : string.Empty;
                            Datos.NombreEncuesta = !Dr.IsDBNull(Dr.GetOrdinal("Folio")) ? Dr.GetString(Dr.GetOrdinal("Folio")) : string.Empty;
                            Datos.ListaPregunta = new List<EM_Preguntas>();
                        }
                        List<EM_Preguntas> ListaPreguntas = new List<EM_Preguntas>();
                        EM_Preguntas Item;
                        DataTableReader DTR = Ds.Tables[1].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[1];
                        while (DTR.Read())
                        {
                            Item = new EM_Preguntas();
                            Item.ListaRespuesta = new List<RR_NuevaRespuesta>();
                            Item.IDPreguntas = !DTR.IsDBNull(DTR.GetOrdinal("IDPregunta")) ? DTR.GetString(DTR.GetOrdinal("IDPregunta")) : string.Empty;
                            Item.NombrePregunta = !DTR.IsDBNull(DTR.GetOrdinal("NombrePregunta")) ? DTR.GetString(DTR.GetOrdinal("NombrePregunta")) : string.Empty;
                            Item.IDTipoPregunta = !DTR.IsDBNull(DTR.GetOrdinal("IDTipoPregunta")) ? DTR.GetInt32(DTR.GetOrdinal("IDTipoPregunta")) : 0;
                            string Aux = !DTR.IsDBNull(DTR.GetOrdinal("TablaRespuestas")) ? DTR.GetString(DTR.GetOrdinal("TablaRespuestas")) : string.Empty;
                            Item.IDRespuestaContestada = !DTR.IsDBNull(DTR.GetOrdinal("Respuesta")) ? DTR.GetString(DTR.GetOrdinal("Respuesta")) : string.Empty;
                            Aux = string.Format("<Main>{0}</Main>", Aux);
                            XmlDocument xm = new XmlDocument();
                            xm.LoadXml(Aux);
                            XmlNodeList Registros = xm.GetElementsByTagName("Main");
                            XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("E");
                            List<RR_NuevaRespuesta> ListaRespuesta = new List<RR_NuevaRespuesta>();
                            RR_NuevaRespuesta ItemAux;
                            foreach (XmlElement Nodo in Lista)
                            {
                                ItemAux = new RR_NuevaRespuesta();
                                XmlNodeList IDRespuesta = Nodo.GetElementsByTagName("IDRespuesta");
                                XmlNodeList ClaveRespuesta = Nodo.GetElementsByTagName("ClaveRespuesta");
                                XmlNodeList Respuesta = Nodo.GetElementsByTagName("Respuesta");
                                ItemAux.IDRespuesta = IDRespuesta[0].InnerText;
                                ItemAux.ClvRespuesta = ClaveRespuesta[0].InnerText;
                                ItemAux.Respuesta = Respuesta[0].InnerText;
                                Item.ListaRespuesta.Add(ItemAux);
                            }
                            ListaPreguntas.Add(Item);
                        }
                        Datos.ListaPregunta = ListaPreguntas;
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
