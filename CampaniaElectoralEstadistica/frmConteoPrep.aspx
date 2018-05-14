<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmConteoPrep.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmConteoPrep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

       <div class="row">
    
        <div class="col-lg-4">
          <div class="row row-sm text-center">
              <div class="col-xs-12">
                  <div class="col-xs-6">
                      <a href class="block panel padder-v item">
                          <span class="h1 text-info font-thin h1 block"><%=ConteoPagina.CasillaGanada%></span>
                          <span class="text-muted text-xs">Casillas Ganadas</span>
                        <%--  <div class="top text-right w-full">
                              <i class="fa fa-caret-down text-warning m-r-sm"></i>
                          </div>--%>
                      </a>
                      </div>
                  <div class="col-xs-6">
                      <a href class="block panel padder-v bg-dark item">
                          <span class="text-white font-thin h1 block"><%=ConteoPagina.CasillaEmpatada%></span>
                          <span class="text-muted text-xs">Casillas Empatadas</span>
                      </a>
                  </div>
              </div>
            <div class="col-xs-12">
              <a href class="block panel padder-v bg-danger item">
                <span class="text-white font-thin h1 block"><%=ConteoPagina.CasillaPerdida%></span>
                <span class="text-muted text-xs">Casillas Perdidas</span>
              </a>
            </div>
            
          
          </div>
        </div>
       
   
      </div>

     <div class="row">
     <div class="col-md-12">
        <div class="panel panel-default">
          <div class="panel-heading font-bold">Resultados Conteo</div>
          <div class="panel-body">
            <div ui-jq="plot" ui-options="
              [
                <%int cont = 0;%>
               <%foreach (var item in ConteoPagina.ListaConteo)
                {%>
                    { data: [ [<%=cont %>,<%=item.CantidadVoto.ToString("0") %> ] ], label: '<%=item.SiglasPartido %>', bars: { show: true, barWidth: 0.5, fillColor: { colors: [{ opacity: 0.2 }, { opacity: 0.4}] } } },
                <%cont++;%>
                 <%} %>
                 { data: [ [<%=cont %>,0 ] ], label: '', bars: { display:false, show: false, barWidth: 0.5, fillColor: { colors: [{ opacity: 0.2 }, { opacity: 0.4}] } } }
              ],
              {                
                colors: [ '#23b7e5','#27c24c','#ff001d','#0c0c0c','#06ef02','#662e2e','#0438f4','#ff00f6','#ffffff'],
                series: { shadowSize: 2 },
                xaxis:{ font: { color: '#ccc' } },
                yaxis:{ font: { color: '#ccc' } },
                grid: { hoverable: true, clickable: true, borderWidth: 0, color: '#ccc' },
                tooltip: true,
                tooltipOpts: { content: '%s  con %y.2 votos',  defaultTheme: false, shifts: { x: 0, y: 20 } }
              }
            " style="height:340px"></div>
          </div>                  
        </div>
      </div>
     
     </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
</asp:Content>
