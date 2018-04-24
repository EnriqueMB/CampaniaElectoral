﻿<%@ Page Title="" Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmObjetivosAfiliados.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmObjetivosAfiliados" %>
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
        <div class="col-lg-4">
      <div class="panel panel-default">
        <div class="panel-heading font-bold">
          Avance General de Afiliados
        </div>
        <div class="panel-body text-center">
          <h4><small>Ultimo Afiliado hace </small>12<small> hrs</small></h4>
          <small class="text-muted block">Fecha de afiliación : 01/04/2018</small>
          <div class="inline">
            <div ui-jq="easyPieChart"  ui-options="{
                      percent: 13,
                      lineWidth: 10,
                      trackColor: '#e8eff0',
                      barColor: '#27c24c',
                      scaleColor: '#e8eff0',
                      size: 188,
                      lineCap: 'butt',
                      animate: 1000
                    }">
              <div>
                <span class="h2 m-l-sm step">13</span>%
                <div class="text text-sm">Inscripción de Afiliados</div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-footer"><small>Promedio de Inscripciones por día: 12</small></div>
      </div>
    </div>
        <div class="col-lg-4">
          <div class="row row-sm text-center">
            <div class="col-xs-6">
              <div class="panel padder-v item">
                <div class="h1 text-info font-thin h1">15210</div>
                <span class="text-muted text-xs">Meta de la Campaña</span>
                <div class="top text-right w-full">
                  <i class="fa fa-caret-down text-warning m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-primary item">
                <span class="text-white font-thin h1 block">1930</span>
                <span class="text-muted text-xs">Afiliados Inscritos</span>
               
              </a>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-info item">
                <span class="text-white font-thin h1 block">432</span>
                <span class="text-muted text-xs">Afiliados Validos</span>
                <span class="top">
                  <i class="fa fa-caret-up text-warning m-l-sm m-r-sm"></i>
                </span>
              </a>
            </div>
            <div class="col-xs-6">
              <div class="panel padder-v bg-danger item">
                <div class="font-thin h1">129</div>
                <span class="text-muted text-xs">Afiliados Rechazados</span>
                <div class="bottom">
                  <i class="fa fa-caret-up text-warning m-l-sm m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <div class="panel padder-v item">
                <div class="h1 text-info font-thin h1">210</div>
                <span class="text-muted text-xs">Secciones Faltantes</span>
                <div class="top text-right w-full">
                  <i class="fa fa-caret-down text-warning m-r-sm"></i>
                </div>
              </div>
            </div>
            <div class="col-xs-6">
              <a href class="block panel padder-v bg-success item">
                <span class="text-white font-thin h1 block">130</span>
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
                      percent: 15,
                      lineWidth: 10,
                      trackColor: '#e8eff0',
                      barColor: '#0fa3e7',
                      scaleColor: '#e8eff0',
                      size: 188,
                      lineCap: 'butt',
                      animate: 1000
                    }">
              <div>
                <span class="h2 m-l-sm step">15</span>%
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
                            <div id="map" style="width:100%; height:500px; border: 5px solid #5E5454;">  
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
              <li class="list-group-item">
                <a href class="thumb-sm m-r">
                  <img src="img/a1.jpg" class="r r-2x">
                </a>
                <span class="pull-right label bg-success inline m-t-sm">60%</span>
                <a href>Damian Parker</a>
              </li>
              <li class="list-group-item">
                <a href class="thumb-sm m-r">
                  <img src="img/a2.jpg" class="r r-2x">
                </a>
                <span class="pull-right label bg-info inline m-t-sm">50%</span>
                <a href>Jose Waston</a>
              </li>
              <li class="list-group-item">
                <a href class="thumb-sm m-r">
                  <img src="img/a3.jpg" class="r r-2x">
                </a>
                <span class="pull-right label bg-primary inline m-t-sm">40%</span>
                <a href>Jannie Dvis</a>
              </li>
              <li class="list-group-item">
                <a href class="thumb-sm m-r">
                  <img src="img/a3.jpg" class="r r-2x">
                </a>
                <span class="pull-right label bg-warning inline m-t-sm">35%</span>
                <a href>Emma Santos</a>
              </li>
                  <li class="list-group-item">
                <a href class="thumb-sm m-r">
                  <img src="img/a4.jpg" class="r r-2x">
                </a>
                <span class="pull-right label bg-danger inline m-t-sm">30%</span>
                <a href>Jose Perez</a>
              </li>
            </ul>
            
          </div>
        </div>
        <div class="col-md-6">            
          <div class="list-group list-group-lg list-group-sp">
            <a herf class="list-group-item clearfix">
                   <span class="pull-left label text-base bg-danger pos-rlt m-r"><i class="arrow right arrow-danger"></i> 0% - 20%</span>
             
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Menor Productividad</small>
              </span>
            </a>
            <a herf class="list-group-item clearfix">
                 <span class="pull-left label text-base bg-warning pos-rlt m-r"><i class="arrow right arrow-warning"></i>21% - 40%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Baja Productividad</small>
              </span>
            </a>
            <a herf class="list-group-item clearfix">
                  <span class="pull-left label text-base bg-info pos-rlt m-r"><i class="arrow right arrow-info"></i>41% - 60%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Media Productividad</small>
              </span>
            </a>
            <a herf class="list-group-item clearfix">
                  <span class="pull-left label text-base bg-primary pos-rlt m-r"><i class="arrow right arrow-primary"></i>61% - 80%</span>
           
              <span class="clear">
                <span>Lista de Representantes de Sección</span>
                <small class="text-muted clear text-ellipsis">Alta Productividad</small>
              </span>
            </a>
            <a herf class="list-group-item clearfix">
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
</asp:Content>
