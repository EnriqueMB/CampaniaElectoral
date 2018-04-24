<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmRGeneral.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmRGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

    <div class="row">

         <div class="col-lg-4">
      <div class="panel panel-default">
        <div class="panel-body">
          <div class="clearfix text-center m-t">
            <div class="inline">
              <div ui-jq="easyPieChart" ui-options="{
                    percent: 75,
                    lineWidth: 5,
                    trackColor: '#e8eff0',
                    barColor: '#23b7e5',
                    scaleColor: false,
                    color: '#3a3f51',
                    size: 134,
                    lineCap: 'butt',
                    rotate: -90,
                    animate: 1000
                  }">
                <div class="thumb-xl">
                  <img src="img/a8.jpg" class="img-circle" alt="...">
                </div>
              </div>
              <div class="h4 m-t m-b-xs">John.Smith</div>
              <small class="text-muted m-b">Representante General</small>
            </div>                      
          </div>
        </div>
        <footer class="panel-footer bg-info text-center no-padder">
          <div class="row no-gutter">
            <div class="col-xs-4">
              <div class="wrapper">
                <span class="m-b-xs h3 block text-white">245</span>
                <small class="text-muted">R. Casillas</small>
              </div>
            </div>
            <div class="col-xs-4 dk">
              <div class="wrapper">
                <span class="m-b-xs h3 block text-white">55</span>
                <small class="text-muted">O. Políticos</small>
              </div>
            </div>
            <div class="col-xs-4">
              <div class="wrapper">
                <span class="m-b-xs h3 block text-white">2,035</span>
                <small class="text-muted">Votantes</small>
              </div>
            </div>
          </div>
        </footer>
      </div>
    </div>


    <div class="col-lg-8">
      <div class="row">
        <div class="col-sm-6">
          <div class="panel panel-default">
            <div class="panel-heading">
              <div class="clearfix">
                <a href class="pull-left thumb-md avatar b-3x m-r">
                  <img src="img/a2.jpg" alt="...">
                </a>
                <div class="clear">
                  <div class="h3 m-t-xs m-b-xs">
                    Jose Perez
                    <i class="fa fa-circle text-success pull-right text-xs m-t-sm"></i>
                  </div>
                  <small class="text-muted">Suplente R. Casilla</small>
                </div>
              </div>
            </div>
         
          </div>
          <div class="panel panel-info">
            <div class="panel-body" >
            

               
              <div class="r bg-light dker item hbox no-border">
                <div class="col w-xs v-middle hidden-md"  style="text-align:center;">
                  <div ng-init="d3_3=[60,40]" ui-jq="sparkline" ui-options="[60,40], {type:'pie', height:40, sliceColors:['#fad733','#fff']}" class="sparkline inline"></div>
                </div>
                <div class="col dk padder-v r-r" style="text-align:center;">
                  <div class="text-primary-dk font-thin h1"><span>12,670</span></div>
                  <span class="text-muted text-xs">Afiliados, 60% del Objetivo</span>
                </div>
              </div>
        


               
              <div class="r bg-light dker item hbox no-border">
                <div class="col w-xs v-middle hidden-md"  style="text-align:center;">
                  <div ng-init="d3_3=[60,40]" ui-jq="sparkline" ui-options="[60,40], {type:'pie', height:40, sliceColors:['#fad733','#fff']}" class="sparkline inline"></div>
                </div>
                <div class="col dk padder-v r-r"  style="text-align:center;">
                  <div class="text-primary-dk font-thin h1"><span>12,670</span></div>
                  <span class="text-muted text-xs">Votantes, 60% del Objetivo</span>
                </div>
              </div>
          

              
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="panel panel-default">
            <a href class="text-muted m-t-sm m-l inline"  ng-click="data=[40, 40, 20]"><i class="icon-pie-chart"></i></a>
            <div class="text-center wrapper m-b-sm">              
              <div ui-refresh="data" ui-jq="sparkline" ui-options="
              [55, 45], 
              {
                type:'pie', 
                height:126, 
                sliceColors:['#7266ba','#23b7e5']
              }
              " class="sparkline inline"></div>
            </div>
            <ul class="list-group no-radius">
              <li class="list-group-item">
                <span class="pull-right">45,000</span>
                <span class="label bg-primary">1</span>
               Usa la aplicación móvil
              </li>
              <li class="list-group-item">
                <span class="pull-right">23,200</span>
                <span class="label bg-info">2</span>
               No usa la aplicación móvil
              
              
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
   

  </div>

     <div class="row">
                        <div class="col-md-12">
                            <div id="map" style="width:100%; height:500px; border: 5px solid #5E5454;">  
    </div> 
                        </div>
                    </div> 


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">


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

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
    		
		


</asp:Content>