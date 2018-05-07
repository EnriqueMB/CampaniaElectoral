<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmIncidencias.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmIncidencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&key=AIzaSyDkNWPPOyEHJLxnjlm0q_JqtTZ-rn3VRZ0" type="text/javascript"></script>  
    <script>  
        var mapcode;
        var diag;
        function initialize() {
            mapcode = new google.maps.Geocoder();
            var lnt = new google.maps.LatLng(-12.043333, -77.028333);
            var diagChoice = {
                zoom: 9,
                center: lnt,
                diagId: google.maps.MapTypeId.ROADMAP
            }
            diag = new google.maps.Map(document.getElementById('map'), diagChoice);
        }
        function getmap() {
            var completeaddress = document.getElementById('txt_location').value;
            mapcode.geocode({ 'address': completeaddress }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    diag.setCenter(results[0].geometry.location);
                    var hint = new google.maps.Marker({
                        diag: diag,
                        position: results[0].geometry.location
                    });
                } else {
                    alert('Location Not Tracked. ' + status);
                }
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div id="map" style="width:100%; height:500px; border: 5px solid #5E5454;">  
            </div> 
        </div>
    </div> 

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
                            <th data-breakpoints="xs">Sección</th>
                            <th>Casilla</th>
                            <th>Encargado</th>
                            <th data-breakpoints="xs">Tipo Reporte</th>
                            <th data-breakpoints="xs">Ver Detalle</th>
                          </tr>
                        </thead>
                        <tbody>          
                            <tr data-expanded="true">
                                <td>12</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>          
                            </tr>
                                <tr data-expanded="true">
                                <td>13</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>          
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><a href="#" class="btn m-b-xs w-xs btn-primary">Ver</a></td>
                            </tr>
                            <tr data-expanded="true">
                                <td>1112</td>
                                <td>Centro</td>
                                <td>Jose Perez</td>
                                <td>Pandillerismo</td>
                                <td><button class="btn m-b-xs w-xs btn-primary">Ver</button></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
</asp:Content>
