using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CampaniaElectoralEstadistica
{
    /// <summary>
    /// Descripción breve de EvaluacionRep
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class EvaluacionRep : System.Web.Services.WebService
    {

        [WebMethod(Description = "Server Side DataTables support", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Data(object parameters, string css, int tipo)
        {
            var req = DataTableParameters.Get(parameters);
            var resultSet = new DataTableResultSet();

            EstadisticosAfiliados Datos = new EstadisticosAfiliados();
            Datos.Start = req.Start;
            Datos.Length = req.Length;
            Datos.SearchValue = req.SearchValue;
            Datos.OrderBy = -1;
            if (req.Order.Count > 0)
            {
                foreach (var aux in req.Order.Keys)
                {
                    Datos.OrderBy = req.Order[aux].Column;
                    Datos.OrderDirection = req.Order[aux].Direction;
                }
            }
            Datos.Conexion = Comun.Conexion;
            Datos.TipoLista = tipo;
            EstadisticosAfiliados_Negocio neg = new EstadisticosAfiliados_Negocio();
            neg.ObtenerEvaluacionAJAX(Datos);
            resultSet.draw = req.Draw;
            resultSet.recordsTotal = Datos.RecordTotal;
            resultSet.recordsFiltered = Datos.RecordFilter;

            foreach (EstadisticosRepresentantesSeccion Item in Datos.Lista)
            {
                var columns = new List<string>();
                string ColImagen = string.Empty, ColAvance = string.Empty;
                if (!string.IsNullOrEmpty(Item.Imagen))
                    ColImagen = @"<a href='#' class='thumb-sm m-r'><img class='r r-2x' src='data:image/jpg;base64," + Item.Imagen + @"' /></a>";
                else
                    ColImagen = @"<a href='#' class='thumb-sm m-r'><img class='r r-2x' src='img/anonymous.jpg'/></a>";
                ColAvance = @"<div class='progress'>
                                <div class='progress-bar " + css + @"' role='progressbar' aria-valuenow='" + Item.Avance +  @"' aria-valuemin='0' aria-valuemax='100' style='width: " + Item.Avance + @"%'>
                                    <span class=''>" + Item.Avance + @"%</span>
                                </div>
                              </div>";
                columns.Add(ColImagen);
                columns.Add(Item.Seccion.ToString());
                columns.Add(Item.Nombre);
                columns.Add(ColAvance);
                resultSet.data.Add(columns);
            }
            SendResponse(HttpContext.Current.Response, resultSet);
        }



        private void SendResponse(HttpResponse response, DataTableResultSet result)
        {
            response.Clear();
            response.Headers.Add("X-Content-Type-Options", "nosniff");
            response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            response.ContentType = "application/json; charset=utf-8";
            response.Write(result.ToJSON());
            response.Flush();
            response.End();
        }
    }
}
