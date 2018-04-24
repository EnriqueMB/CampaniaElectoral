<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmConteoPrep.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmConteoPrep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

       <div class="row">
    
        <div class="col-lg-4">
          <div class="row row-sm text-center">
            <div class="col-xs-12">
              <div class="panel padder-v item">
                <div class="h1 text-info font-thin h1">210</div>
                <span class="text-muted text-xs">Casillas Ganadas</span>
                <div class="top text-right w-full">
                  <i class="fa fa-caret-down text-warning m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-12">
              <a href class="block panel padder-v bg-danger item">
                <span class="text-white font-thin h1 block">930</span>
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
                { data: [ [0,7],[1,6.5],[2,12.5],[3,7],[4,9],[5,6],[6,11],[7,6.5],[8,8],[9,7] ], label: 'Unique Visits', points: { show: true } }, 
                { data: [ [0,4],[1,4.5],[2,7],[3,4.5],[4,3],[5,3.5],[6,6],[7,3],[8,4],[9,3] ], label: 'Page Views', bars: { show: true, barWidth: 0.6, fillColor: { colors: [{ opacity: 0.2 }, { opacity: 0.4}] } } }
              ],
              {                
                colors: [ '#23b7e5','#27c24c' ],
                series: { shadowSize: 2 },
                xaxis:{ font: { color: '#ccc' } },
                yaxis:{ font: { color: '#ccc' } },
                grid: { hoverable: true, clickable: true, borderWidth: 0, color: '#ccc' },
                tooltip: true,
                tooltipOpts: { content: '%s of %x.1 is %y.4',  defaultTheme: false, shifts: { x: 0, y: 20 } }
              }
            " style="height:240px"></div>
          </div>                  
        </div>
      </div>
     
     </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
</asp:Content>
