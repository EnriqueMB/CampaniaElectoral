<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmDonate.aspx.cs" Inherits="CampaniaElectoralWeb.frmDonate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="breadcrumbs-area ptb-140 donate-bg">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title">Donate</h2>
                        <ul>
                            <li><a href="#">Home</a></li>
                            <li>Donate</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="donate-area ptb-80">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="donate-top">
                        <div class="blog-container-inner">
                            <div class="post-for">
                                <img src="Content/img/banner/24.jpg" alt="" >
                            </div>
                        </div>
                        <div class="donate-text">
                            <p>The <span>Miata</span> Team runs on a very tight budget. Your donation - no matter how small - will make a big difference to the election of our candidates and the operation of the team.</p>
                            <p class="p-bold">You can donate to us if you like what we do, but you can't donate to us to change what we do.</p>
                            <p>Donations totalling up to $1,500 in a financial year are tax deductible. Donations higher than $13,000 are reported to the Australian Electoral Commission as part of the annual Political Party Disclosure Return and also noted here, together with our view on donation transparency.</p>
                            <p>Cheques can be posted to PO Box 3015, Unley, SA, 5061.</p>
                            <p>* We reserve the right to refuse or return any donations that are not consistent with the aims of the party.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="donate-sidebar">
                                
                        <div class="donate-sidebar-bottom">
                            <h1>Únete como Voluntario</h1>
                            <form action="#">
                                <input class="form-control2" name="name" placeholder="Nombre" type="text">
                                <input class="form-control2" name="name" placeholder="Apellido Paterno" type="text">
                                <input class="form-control2" name="name" placeholder="Apellido Materno" type="text">
                                <input class="form-control2" name="name" placeholder="Calle" type="text">
                                <input class="form-control2" name="name" placeholder="Colonia" type="text">
                                <input class="form-control2" name="name" placeholder="Ciudad" type="text">
                                <input class="form-control2" name="name" placeholder="Código Postal" type="text">
                                <input class="form-control2" name="name" placeholder="Teléfono" type="text">
                                <input class="form-control2" name="name" placeholder="Correo Electronico" type="email">
                                <button class="submit" type="submit">
                                    ¡UNETE AHORA!
                                    <i class="fa fa-check" aria-hidden="true"></i>
                                </button>
                            </form>
                        </div>
                    </div>
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
