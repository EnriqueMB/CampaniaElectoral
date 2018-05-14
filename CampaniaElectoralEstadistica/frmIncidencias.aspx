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
                                            <%= item.tipoRiesgo%>
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
   <%-- <script>  
        jQuery(document).ready(function () {
            alert($('#puntos-riesgos').val());
            var arrayPoints2d = JSON.parse($('#puntos-riesgos').val());
            console.log(arrayPoints2d);
        });
        
        var mapcode;
        var diag;
        function initialize() {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(16.6634247,-92.551164);
            var diagChoice = {
                zoom: 7,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map'), diagChoice);



            //var oms = new OverlappingMarkerSpiderfier(map, {
            //    markersWontMove: true,
            //    markersWontHide: true,
            //    keepSpiderfied: true,
            //    circleSpiralSwitchover: 40
            //});
            var infowindows = new google.maps.InfoWindow();
            var marker;
            for (var k = 0; k < arrayPoints2d.length; k++) {
                //map.addMarker({
                //    lat: arrayPoints2d[k][1],
                //    lng: arrayPoints2d[k][2],
                //    title: arrayPoints2d[k][0],
                //    infoWindow: {
                //        content:  '<p> Casilla: ' + arrayPoints2d[k][0] + '</p>'
                //                + '<p> Dirección: ' + arrayPoints2d[k][3] + '</p>'
                //                + '<p> Referencias: ' + arrayPoints2d[k][4] + '</p>'
                //    }
                //});

                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(arrayPoints2d[k][3], arrayPoints2d[k][4]),
                    map: map,
                    title: arrayPoints2d[k][0]
                });

                google.maps.event.addListener(marker, 'click', (function (marker, k) {
                    return function () {
                        var contentString =
                                  '<p> Incidente: ' + arrayPoints2d[k][0] + '</p>'
                                + '<p> Tipo de Riesgo: ' + arrayPoints2d[k][1] + '</p>'
                                + '<p> Casilla: ' + arrayPoints2d[k][2] + '</p>'
                                 + '<p> Dirección: ' + arrayPoints2d[k][5] + '</p>'
                                + '<p> Referencia: ' + arrayPoints2d[k][6] + '</p>';
                        infowindows.setContent(contentString);
                        infowindows.open(map, marker);
                    }
                })(marker, k));
                //oms.addMarker(marker)
            }
        }
      
        google.maps.event.addDomListener(window, 'load', initialize);

    </script>--%>
</asp:Content>
