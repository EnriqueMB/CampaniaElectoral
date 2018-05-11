<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmObjetivosAfiliados.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmObjetivosAfiliados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
     <div class="row">
        <div class="col-lg-4">
      <div class="panel panel-default">
        <div class="panel-heading font-bold">
          Avance General de Afiliados
        </div>
        <div class="panel-body text-center">
          <h4><small>Ultimo Afiliado hace </small><%=Datos.TiempoTranscurridoUAHoras %><small> hr<%=(Datos.TiempoTranscurridoUAHoras != 1 ? "s":"") %></small></h4>
          <small class="text-muted block">Fecha de afiliación : <%=Datos.FechaUltimoAfiliadoString %></small>
          <div class="inline">
            <div ui-jq="easyPieChart"  ui-options="{
                      percent: <%=Datos.PorcentajeAfiliados %>,
                      lineWidth: 10,
                      trackColor: '#e8eff0',
                      barColor: '#27c24c',
                      scaleColor: '#e8eff0',
                      size: 188,
                      lineCap: 'butt',
                      animate: 1000
                    }">
              <div>
                <span class="h2 m-l-sm step"><%=Datos.PorcentajeAfiliados %></span>%
                <div class="text text-sm">Inscripción de Afiliados</div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-footer"><small>Promedio de Inscripciones por día: <%=Datos.PromedioInscripcionXDia %></small></div>
      </div>
    </div>
        <div class="col-lg-4">
          <div class="row row-sm text-center">
            <div class="col-xs-6">
              <div class="panel padder-v item">
                <div class="h1 text-info font-thin h1"><%=Datos.MetaCampania %></div>
                <span class="text-muted text-xs">Meta de la Campaña</span>
                <div class="top text-right w-full">
                  <i class="fa fa-caret-down text-warning m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-primary item">
                <span class="text-white font-thin h1 block"><%=Datos.AfiliadosInscritos %></span>
                <span class="text-muted text-xs">Afiliados Inscritos</span>
               
              </a>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-info item">
                <span class="text-white font-thin h1 block"><%=Datos.AfiliadosValidos %></span>
                <span class="text-muted text-xs">Afiliados Validos</span>
                <span class="top">
                  <i class="fa fa-caret-up text-warning m-l-sm m-r-sm"></i>
                </span>
              </a>
            </div>
            <div class="col-xs-6">
              <div class="panel padder-v bg-danger item">
                <div class="font-thin h1"><%=Datos.AfiliadosRechazados %></div>
                <span class="text-muted text-xs">Afiliados Rechazados</span>
                <div class="bottom">
                  <i class="fa fa-caret-up text-warning m-l-sm m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <div class="panel padder-v item">
                <div class="h1 text-info font-thin h1"><%=Datos.SeccionesFaltantes %></div>
                <span class="text-muted text-xs">Secciones Faltantes</span>
                <div class="top text-right w-full">
                  <i class="fa fa-caret-down text-warning m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-success item">
                <span class="text-white font-thin h1 block"><%=Datos.SeccionesConcluidas %></span>
                <span class="text-muted text-xs">Secciones concluidas</span>
              </a>
            </div>
          </div>
        </div>
        <div class="col-lg-4">
      <div class="panel panel-default">
        <div class="panel-heading font-bold">
          Avance de Afiliados por Sección
        </div>
        <div class="panel-body text-center">
            <h4><small>Sección o Secciones con menor avance:</small></h4>
          <small class="text-muted block">(1100) (2123) (1233)</small>
          <div class="inline">
            <div ui-jq="easyPieChart"  ui-options="{
                      percent: <%=Datos.PorcentajeAvanceSeccion %>,
                      lineWidth: 10,
                      trackColor: '#e8eff0',
                      barColor: '#0fa3e7',
                      scaleColor: '#e8eff0',
                      size: 188,
                      lineCap: 'butt',
                      animate: 1000
                    }">
              <div>
                <span class="h2 m-l-sm step"><%=Datos.PorcentajeAvanceSeccion %></span>%
                <div class="text text-sm">Secciones Concluidas</div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-footer"><small>Sección con mayor avance: (2341)</small></div>
      </div>
    </div>
   
      </div>

      <div class="row">
                        <div class="col-md-12">
                            <div id="map1" style="width:100%; height:500px; border: 5px solid #5E5454;">  
                            </div> 
                        </div>
      </div> 
    
      <div class="row" style="margin-top:30px;">
        <div class="col-md-6">
          <div class="panel no-border">
            <div class="panel-heading wrapper b-b b-light">
            
              <h4 class="font-thin m-t-none m-b-none text-muted">TOP 5 REPRESENTANTES DE SECCIÓN</h4>              
            </div>
            <ul class="list-group list-group-lg m-b-none">
                <% foreach (var Item in Datos.Lista)
                    { %>
                        <li class="list-group-item">
                            <% if (!string.IsNullOrEmpty(Item.Imagen))
                                { %>
                                    <a href="#" class="thumb-sm m-r">
                                        <img class="r r-2x" src="data:image/jpg;base64,<%=Item.Imagen %>" />
                                    </a>
                                <%}
                                else
                                {%>
                                    <a href="#" class="thumb-sm m-r">
                                        <img class="r r-2x" src="img/anonymous.jpg" />
                                    </a>
                                <%}
                            %>
                            <%--
                                <img src="img/a1.jpg" class="r r-2x">
                            --%>
                            <span class="pull-right label <%=Item.CssClass %> inline m-t-sm"><%=Item.Avance %>%</span>
                            <a href="#"><%=Item.Nombre %> (<%=Item.Seccion %>)</a><br />                            
                        </li> 
              <%} %>
            </ul>
            
          </div>
        </div>
        <div class="col-md-6">            
          <div class="list-group list-group-lg list-group-sp">
            <a href="/frmEvaluacionRepresentantes.aspx?tipo=1" class="list-group-item clearfix">
                   <span class="pull-left label text-base bg-danger pos-rlt m-r"><i class="arrow right arrow-danger"></i> 0% - 20%</span>
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Menor Productividad</small>
              </span>
            </a>
            <a href="/frmEvaluacionRepresentantes.aspx?tipo=2" class="list-group-item clearfix">
                 <span class="pull-left label text-base bg-warning pos-rlt m-r"><i class="arrow right arrow-warning"></i>21% - 40%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Baja Productividad</small>
              </span>
            </a>
            <a href="/frmEvaluacionRepresentantes.aspx?tipo=3" class="list-group-item clearfix">
                  <span class="pull-left label text-base bg-info pos-rlt m-r"><i class="arrow right arrow-info"></i>41% - 60%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Media Productividad</small>
              </span>
            </a>
            <a href="/frmEvaluacionRepresentantes.aspx?tipo=4" class="list-group-item clearfix">
                  <span class="pull-left label text-base bg-primary pos-rlt m-r"><i class="arrow right arrow-primary"></i>61% - 80%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Alta Productividad</small>
              </span>
            </a>
            <a href="/frmEvaluacionRepresentantes.aspx?tipo=5" class="list-group-item clearfix">
                 <span class="pull-left label text-base bg-success pos-rlt m-r"><i class="arrow right arrow-success"></i>81% - 100%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Excelente Productividad</small>
              </span>
            </a>
          </div>
        </div>
      </div>

    
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&key=AIzaSyDkNWPPOyEHJLxnjlm0q_JqtTZ-rn3VRZ0" type="text/javascript"></script>
    <script src="js/EstadisticosAfiliados.js"></script>
    <script>
        jQuery(document).ready(function () {
            Estadisticos.init(<%=Datos.ObtenerJsonSecciones()%>);
        });
    </script>
</asp:Content>
