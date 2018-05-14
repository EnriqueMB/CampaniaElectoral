<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmIncidencias.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div id="map" style="width:100%; height:500px; border: 5px solid #5E5454;">  
            </div> 
        </div>
    </div> 
    <textarea id="puntos-riesgos" style="display:none"><%=Datos.Riesgos %></textarea>
    <div class="row">
        <div class="wrapper-md">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Lista de Casillas y su información
                </div>
                <div>
                    <table class="table" ui-jq="footable" ui-options='{
                        "paging": {
                                    "enabled": true
                                },
                        "filtering": {
                                        "enabled": true        
                                    },
                        "sorting": {
                                        "enabled": true
                                    }}'>
                        <thead>
                          <tr>
                            <th data-breakpoints="xs">Incidente</th>
                              <th data-breakpoints="xs">Tipo Riesgo</th>
                            <th>Casilla</th>
                            <th>Encargado</th>
                            <th data-breakpoints="xs">Dirección</th>
                            
                          </tr>
                        </thead>
                        <tbody>          
                            
                              <%  foreach (var item in Datos.listaIncidencias)
                                        {
                                    %>
                                    <tr>
                                        <td>
                                          <%= item.titulo%>
                                        </td>
                                         <td>
                                          <%= item.tipoRiesgo%>
                                        </td>
                                        <td>
                                           <%= item.casilla%>
                                        </td>
                                        <td>
                                            <%= item.encargado%>
                                        </td>
                                        <td>
                                            <%= item.domicilio%>
                                        </td>
                                       
                            </tr>
                                    <% } %>
                            
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&key=AIzaSyDkNWPPOyEHJLxnjlm0q_JqtTZ-rn3VRZ0" type="text/javascript"></script>  
    <script src="assets/js/mapIncidentes.js"></script>
     <script> jQuery(document).ready(function () {
    
     
     Maps.init();
 });</script>
   
</asp:Content>
