using DllCampElectoral.Global;
using DllCampElectoral.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CampaniaElectoral
{
    /// <summary>
    /// Descripción breve de afiliadosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class afiliadosService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Server Side DataTables support", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Data(object parameters, bool bandDatosComp)
        {
            var req = DataTableParameters.Get(parameters);
            var resultSet = new DataTableResultSet();

            Afiliados Datos = new Afiliados();
            Datos.Start = req.Start;
            Datos.Length = req.Length;
            Datos.SearchValue = req.SearchValue;
            Datos.OrderBy = -1;
            Datos.TipoBusqueda = -1;
            Datos.FechaInicio = DateTime.Today;
            Datos.FechaFin = DateTime.Today;
            Datos.DatosCompletados = bandDatosComp;
            if (req.Order.Count > 0)
            {
                foreach (var aux in req.Order.Keys)
                {
                    Datos.OrderBy = req.Order[aux].Column;
                    Datos.OrderDirection = req.Order[aux].Direction;
                }
            }

            foreach(var busq in req.Columns.Keys)
            {
                if(!string.IsNullOrEmpty(req.Columns[busq].SearchValue))
                {
                    Datos.TipoBusqueda = busq;
                    Datos.SearchValue = req.Columns[busq].SearchValue;
                    break;
                }
            }

            switch(Datos.TipoBusqueda)
            {
                case 2:
                    DateTime Fecha1 = DateTime.Today;
                    DateTime Fecha2 = DateTime.Today;
                    string[] s = Datos.SearchValue.Split('-');
                    if (s.Length == 2)
                    {
                        DateTime.TryParseExact(s[0].Trim(), "MMddyyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha1);
                        DateTime.TryParseExact(s[1].Trim(), "MMddyyyy", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Fecha2);
                        Datos.FechaInicio = Fecha1;
                        Datos.FechaFin = Fecha2;
                    }
                    break;
                case 1:
                    int Ratificado = 0;
                    int.TryParse(Datos.SearchValue, out Ratificado);
                    Datos.Ratificado = (Ratificado == 1);
                    break;
                case 3:
                    int Seccion = 0;
                    int.TryParse(Datos.SearchValue, out Seccion);
                    Datos.Seccion = Seccion;
                    break;
                case -1:
                    if(!string.IsNullOrEmpty(Datos.SearchValue))
                    {
                        Datos.TipoBusqueda = 0;
                    }
                    break;
                default: 
                    break;
            }

            Datos.Conexion = Comun.Conexion;
            AfiliadosNegocio neg = new AfiliadosNegocio();
            neg.ObtenerAfiliadosAJAX(Datos);
            resultSet.draw = req.Draw;
            resultSet.recordsTotal = Datos.RecordTotal;
            resultSet.recordsFiltered = Datos.RecordFilter;

            foreach (Afiliados Item in Datos.ListaAfiliados)
            {
                var columns = new List<string>();
                columns.Add(Item.Nombre);
                columns.Add(Item.FechaAfiliacionString);
                string estatusHtml = Item.Ratificado ? "<span class='label label-sm label-success'>Ratificado</span>" : "<span class='label label-sm label-danger'>No ratificado</span>";
                columns.Add(estatusHtml);
                columns.Add(Item.Seccion.ToString());
                columns.Add(Item.ClaveElector);
                columns.Add(Item.Operador);
                string acciones = @"<div class='visible-md visible-lg hidden-sm hidden-xs'>
                                        <a href='frmSeccionDetalle.aspx?id=" + Item.IDAfiliado + @"' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Ver'> <i class='fa fa-edit'> </i> </a>
									</div>
									<div class='visible-xs visible-sm hidden-md hidden-lg'>
									    <div class='btn-group'>
											<a class='btn btn-green dropdown-toggle btn-sm' data-toggle='dropdown' href='#'>
												<i class='fa fa-cog'></i> <span class='caret'></span>
											</a>
											<ul role = 'menu' class='dropdown-menu pull-right dropdown-dark'>
												<li>														
                                                    <a href='frmSeccionDetalle.aspx?id=" + Item.IDAfiliado + @"' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Ver'><i class='fa fa-edit'></i>Ver</a>
												</li>
											</ul>
										</div>
									</div>";
                columns.Add(acciones);


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
