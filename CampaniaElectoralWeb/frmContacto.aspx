<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmContacto.aspx.cs" Inherits="CampaniaElectoralWeb.frmContacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="map-area map-area-two">
        <div class="contact-map">
            <div id="hastech2"></div>
            <div class="communication">
                <div class="single-communication">
                    <div class="communication-icon">
                        <i class="fa fa-home" aria-hidden="true"></i>
                    </div>
                    <div class="communication-text">
                        <h3>Dirección:</h3>
                        <p><%=ListaContacto.Direccion.ToString()%></p>
                    </div>
                </div>
                <div class="single-communication">
                    <div class="communication-icon">
                        <i class="fa fa-phone" aria-hidden="true"></i>
                    </div>
                    <div class="communication-text">
                        <h3>Telefono:</h3>
                        <p><%=ListaContacto.Telefono.ToString()%></p>
                    </div>
                </div>
                <div class="single-communication">
                    <div class="communication-icon">
                        <i class="fa fa-envelope" aria-hidden="true"></i>
                    </div>
                    <div class="communication-text">
                        <h3>Correo:</h3>
                        <p><a href="#"><%=ListaContacto.Correo.ToString()%></a></p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="contact-area" class=" map-area-two-text pt-160 pb-80">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="contact-heading">
                        <h3><%=ListaContacto.Titulo.ToString()%></h3>
                        <p><%=ListaContacto.Texto.ToString()%></p>
                    </div>
                </div>
            </div>
            <div class="row">
                <h1 id="Correcto" style="text-align:center; background-color:#ea000d; border-radius: 50px;"></h1>
                <div id="IDContacto" class="map-input-contact-area">
                    <form id="contact-form" class="contact-form" onsubmit="ValidarContacto()">
                        <div class="col-md-4">
                            <input class="form-control2" id="Nombre" name="Nombre" placeholder="Nombre completo" type="text">
                        </div>
                        <div class="col-md-4">
                            <input class="form-control2" id="Correo" name="Correo"  placeholder="Correo" type="email">
                        </div>
                        <div class="col-md-4">
                            <input class="form-control2" id="Telefono" name="Telefono" placeholder="Telefono" type="text">
                        </div>
                        <div class="col-md-12">
                            <input class="form-control2" id="Asunto" name="Asunto" placeholder="Asunto" type="text">
                        </div>
                        <div class="col-md-12 text-center">
                            <div class="home-2-text-area">
                                <textarea class="form-control2" id="Mensaje" name="Mensaje" placeholder="Mensaje"></textarea>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <button class="submit" type="submit">
                                Send Message 
                                <i class="fa fa-paper-plane" aria-hidden="true"></i>
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
   <section class="subscribe-area ptb-80 subscribe2">
        <div class="container">
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center">
                    <div class="subscribe">
                        <div class="subscribe-text">
                            <p>TU PUEDES SEGUIRNOS POR E-MAIL</p>
                            <h3 id="TextoSus">SUSCRIBETE</h3>
                        </div>
                        <div id="Padre" class="subscribe-input">
                            <form id="form" class="mc-form" onsubmit="Validar2()">
                                <input id="txtCorreo" autocomplete="off" placeholder="Escribe tu correo aqui" name="txtCorreo" type="email" required="">
                                <button class="submit" id="G1234">
                                    suscribete
                                    <i class="fa fa-paper-plane" aria-hidden="true"></i>
                                </button>
                            </form>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_qDiT4MyM7IxaGPbQyLnMjVUsJck02N0"></script>
    <script>
        var Latitud = '<%=ListaContacto.Latitud.ToString()%>';
        var Longitud = '<%=ListaContacto.Longitud.ToString()%>'
        var myCenter = new google.maps.LatLng(Latitud, Longitud);
        function initialize() {
            var mapProp = {
                center: myCenter,
                scrollwheel: false,
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById('hastech2'), mapProp);
            var marker = new google.maps.Marker({
                position: myCenter,
                animation: google.maps.Animation.BOUNCE,
                //icon: 'Content/img/logo-icon.png',
                map: map,
            });
            var styles = [
                {
                    stylers: [
                        { hue: '#c5c5c5' },
                        { saturation: -100 }
                    ]
                },
            ];
            map.setOptions({ styles: styles });

            marker.setMap(map);
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
    <script src="Content/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="Content/js/form-validation.js"></script>
    <script>
        jQuery(document).ready(function() {
            FormValidator.init();
        });
    </script>
    
     <script >

         function Validar2() {
             $(this).submit(function (e) {
                 e.preventDefault();
                 var titulouno = $('#txtCorreo').val();
                 var data = new FormData();
                 data.append('correo', titulouno);
                 $.ajax({
                     type: 'POST',
                     url: 'frmSuscripcion.aspx',
                     contentType: false,
                     data: data,
                     processData: false,
                     cache: false,
                     success: function () {
                         var padre = document.getElementById('Padre');
                         var hijo = document.getElementById('form');
                         padre.removeChild(hijo);
                        // document.getElementById('form').style.display = "none";
                         document.getElementById('TextoSus').innerHTML="Gracias por suscribirte";
                     },
                     error: function () {
                         document.getElementById('TextoSus').innerHTML = "No se pudo realizar la suscripcion";
                     }
                 });
                 return false;
             });
         }
         function ValidarContacto() {
             $(this).submit(function (e) {
                 e.preventDefault();
                 var Nombre = $('#Nombre').val();
                 var Correo = $('#Correo').val();
                 var Telefono = $('#Telefono').val();
                 var Asunto = $('#Asunto').val();
                 var Mensaje = $('#Mensaje').val();
                 var data = new FormData();
                 data.append('Nombre', Nombre);
                 data.append('Correo', Correo);
                 data.append('Telefono', Telefono);
                 data.append('Asunto', Asunto);
                 data.append('Mensaje', Mensaje);
                 $.ajax({
                     type: 'POST',
                     url: 'sfrmContacto.aspx',
                     contentType: false,
                     data: data,
                     processData: false,
                     cache: false,
                     success: function () {
                         var padre = document.getElementById('IDContacto');
                         var hijo = document.getElementById('contact-form');
                         padre.removeChild(hijo);
                         // document.getElementById('form').style.display = "none";
                         document.getElementById('Correcto').innerHTML = "Gracias por contactarnos";
                     },
                     error: function () {
                         document.getElementById('Correcto').innerHTML = "Error al enviar los datos .Intente mas tarde";
                     }
                 });
                 return false;
             });
         }
		</script>
    </asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolderFooter">
    <div class="footer-menu">
        <ul>
            <li><a href="frmHome.aspx">Home </a></li>
            <li><a href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a href="frmGaleria.aspx">Galeria </a></li>
            <li><a class="active" href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>