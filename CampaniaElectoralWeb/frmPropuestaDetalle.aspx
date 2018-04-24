<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmPropuestaDetalle.aspx.cs" Inherits="CampaniaElectoralWeb.frmPropuestaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">    
    <section class="breadcrumbs-area ptb-140 Blog-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="breadcrumbs">
                                <h2 class="page-title">Detalle de Propuesta</h2>
                                <ul>
                                    <li><a class="active" href="#">Home</a></li>
                                    <li><a href="#">Propuesta</a></li>
                                    <li>Video start your career</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    <%foreach (var Item in Lista){ %>
            <section class="blog-two-details-area ptb-80">
                <div class="container">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="blog-container-inner">
                                <div class="visual-inner">
                                    <h3 class="blog-title">
                                        <%Response.Write("<h3>"+Item.NombrePropuesta+"</h3>"); %>
                                    </h3>
                                    <div class="blog-meta">
                                        <span class="published3">
                                            <i class="fa fa-calendar" aria-hidden="true"></i> 11 May, 2016 
                                        </span>                                        
                                    </div>
                                    <div class="blog-content">                                      
                                        <%Response.Write("<h3>"+Item.Descripcion1+"</h3>"); %>
                                    </div>
                                    <div class="container blog-content">
                                         <%Response.Write("<p class='col-md-3 text-justify'>"+Item.Descripcion2+"</p>"); %>
                                         <%Response.Write("<p class='col-md-3 text-justify'>"+Item.Descripcion3+"</p>"); %>                                         
                                         <img src="Content/img/blog/12.jpg" class="col-md-3" alt="">
                                    </div>
                                </div>
                                <div class="blog-tag">
                                    <p><i class="fa fa-tags" aria-hidden="true"></i><span class="tag">Tags:</span> Political, <span class="vidos2">Video</span>, Politico, Donate, Blog</p>
                                </div>
                                <div class="blog-share">
                                    <p><i class="fa fa-share-alt" aria-hidden="true"></i><span class="tag">Share:</span></p>
                                    <ul>
                                        <li>
                                            <a href="#">
                                                <i class="fa fa-facebook"></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <i class="fa fa-google-plus"></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <i class="fa fa-twitter" aria-hidden="true"></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <i class="fa fa-instagram" aria-hidden="true"></i>
                                            </a>
                                        </li>
                                    </ul>
                                    
                                </div>
                                <div class="container">
                                    <%Response.Write("<p class='col-md-9'>"+Item.PieDePagina+"</p>"); %>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            
                            <div class="issues-categoris issues-top3">
                                <h3>Otras propuestas</h3>
                                <div class="categori-list1">
                                    <%foreach (var Item2 in ListaB)
                                        {%>
                                    <div class="categori-list-one">
                                        <div class="categori-list-img">                                            
                                            <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id=" + Item2.IDPropuesta + "'></a>"); %>
                                            <%Response.Write("<img src="+Item2.URLImagen+" alt=''>"); %>                                            
                                        </div>
                                        <div class="post-details">
                                            <%Response.Write("<p>"+Item2.NombrePropuesta+"</p>"); %>
                                        </div>
                                    </div>                 
                                    <%} %>                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    <%} %>
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