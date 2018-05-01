using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CampaniaElectoral
{
    /// <summary>
    /// Descripción breve de seccionesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class seccionesService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Server Side DataTables support", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Data(object parameters)
        {
            var req = DataTableParameters.Get(parameters);
            var resultSet = new DataTableResultSet();

            Secciones Datos = new Secciones();
            Datos.Start = req.Start;
            Datos.Length = req.Length;
            Datos.SearchValue = req.SearchValue;
            Datos.OrderBy = -1;
            if(req.Order.Count > 0)
            {
                foreach(var aux in req.Order.Keys)
                {
                    Datos.OrderBy = req.Order[aux].Column;
                    Datos.OrderDirection = req.Order[aux].Direction;
                }
            }
            Datos.Conexion = Comun.Conexion;
            SeccionesNegocio neg = new SeccionesNegocio();
            neg.ObtenerSeccionesAJAX(Datos);
            resultSet.draw = req.Draw;
            resultSet.recordsTotal = Datos.RecordTotal;
            resultSet.recordsFiltered = Datos.RecordFilter;

            foreach(Secciones Item in Datos.ListaSecciones)
            {
                var columns = new List<string>();
                columns.Add(Item.IDSeccion.ToString());
                columns.Add(Item.TipoSeccion);
                string acciones = @"<div class='visible-md visible-lg hidden-sm hidden-xs'>
                                        <a href='frmSeccionDetalle.aspx?id=" + Item.IDSeccion + @"' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Ver'> <i class='fa fa-edit'> </i> </a>
									</div>
									<div class='visible-xs visible-sm hidden-md hidden-lg'>
									    <div class='btn-group'>
											<a class='btn btn-green dropdown-toggle btn-sm' data-toggle='dropdown' href='#'>
												<i class='fa fa-cog'></i> <span class='caret'></span>
											</a>
											<ul role = 'menu' class='dropdown-menu pull-right dropdown-dark'>
												<li>														
                                                    <a href='frmSeccionDetalle.aspx?id=" + Item.IDSeccion + @"' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Ver'><i class='fa fa-edit'></i>Ver</a>
												</li>
											</ul>
										</div>
									</div>";
                columns.Add(acciones);


                resultSet.data.Add(columns);
            }            
            SendResponse(HttpContext.Current.Response, resultSet);
        }

        [WebMethod(Description = "Server Side DataTables support", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Pruebas(string Name1, string Name2)
        {
            return Name1 + " - " + Name2;
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