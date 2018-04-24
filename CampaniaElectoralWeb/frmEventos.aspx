<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmEventos.aspx.cs" Inherits="CampaniaElectoralWeb.frmEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="breadcrumbs-area ptb-140 issues-bg9">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title">Eventos</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li>Eventos</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="events-two-ara ptb-80">
        <div class="container">
            <div class="calender-title">
                <h1>Political Events Calendar</h1>
                <p>Calendarario de información <span></span></p>
            </div>
            <div id='calendar'></div>
        </div>
    </section>
    <section class="subscribe-area ptb-80 subscribe2">
        <div class="container">
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center">
                    <div class="subscribe">
                        <div class="subscribe-text">
                            <p>TU PUEDES SEGUIRNO POR E-MAIL</p>
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
    <script src="Content/js/vendor/jquery-1.12.4.min.js"></script>
    <!-- bootstrap JS
    ============================================ -->		
    <script src="Content/js/bootstrap.min.js"></script>
    <!-- ajax mails JS
    ============================================ -->
    <script src="Content/js/ajax-mail.js"></script>
    <!-- wow JS
    ============================================ -->		
    <script src="Content/js/wow.min.js"></script>
    <!-- Nivo slider js
    ============================================ --> 		
    <script src="Content/lib/js/jquery.nivo.slider.js" type="text/javascript"></script>
    <script src="Content/lib/home.js" type="text/javascript"></script>
    <!-- plugins JS
    ============================================ -->
    <script src="Content/js/plugins.js"></script>
    <!-- calender JS
    ============================================ -->		
    <script src="Content/js/active-calendar.js"></script>
    <script src="Content/js/fullcalendar/lang/es.js"></script>
    <!-- main JS
    ============================================ -->		
   <%-- <script src="Content/js/main.js"></script>--%>
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
                        document.getElementById('TextoSus').innerHTML = "Gracias por suscribirte";
                    },
                    error: function () {
                        document.getElementById('TextoSus').innerHTML = "No se pudo realizar la suscripcion";
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
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a class="active" href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>