<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmHome.aspx.cs" Inherits="CampaniaElectoralWeb.frmHome" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="header-space"></div> 
 <section class="slider-main-area">
    <div class="main-slider an-si">
        <div class="bend niceties preview-2">
           
            <div id="ensign-nivoslider-2" class="slides">	
                <img src="Content/img/slider/3.jpg" alt="" title="#slider-direction-2"  />
                <img src="Content/img/slider/1.jpg" alt="" title="#slider-direction-1"  />
                <img src="Content/img/slider/1.jpg" alt="" title="#slider-direction-3"  />
                <img src="Content/img/slider/1.jpg" alt="" title="#slider-direction-4"  />
            </div>
             <!-- direction 1 -->
             <% int i = 1;
                 foreach (var Item in Lista)
                { %>
                <!-- direction 1 -->
            <div id="slider-direction-<%=i%>" class="t-cn slider-direction Builder">
                <div class="container">
                    <div class="slide-all slide<%=i%>">
                        <!-- layer 1 -->
                        <div class="layer-1">
                            <h3 class="title5"></h3>
                        </div>
                        <!-- layer 2 -->
                        <div class="layer-2">
                            <h1 class="title6"><%=Item.TextoInicial %></h1>
                        </div>
                        <!-- layer 2 -->
                        <div class="layer-2">
                            <h1 class="title6"><%=Item.TextoPrincipal %></h1>
                        </div>
                        <!-- layer 3 -->
                        <%if(Item.URLBanner == string.Empty)
                          { %>
                        <%}
                          else
                          { %>
                        <div class="layer-3">
                            <a class="min1" href="<%=Item.URLBanner%>"><%=Item.TextoButton %></a>
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>
        <%  i++;
                }
           %>
           
        </div>
   </div>
</section>
    <%foreach (var Item in ListaHome)
        {%>
<section class="what-area section-margin ptb-80">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <div class="what-top">
                    <div class="section-title">
                        <%Response.Write("<h1>"+Item.TituloHacemos+"</h1>"); %>                        
                        <div class="what-icon">
                            <i class="fa fa-bookmark" aria-hidden="true"></i>
                        </div>
                    </div>
                    <%Response.Write("<p>" + Item.DescHacemos + "</p>"); %>                    
                </div>
            </div>
        </div>
        <div class="row text-center">
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="what-bottom">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmNuestraMision.aspx">
                                <i class="fa fa-crosshairs" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3 ><a href="frmNuestraMision.aspx" title="">Nuestra Misión</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
            <div  class="col-md-4 col-sm-4 col-xs-12">
                <div  class="what-bottom">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmPropuesta.aspx">
                                <i class="fa fa-volume-up" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3><a href="frmPropuesta.aspx" title="">Nuestra Campaña</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="what-bottom">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmCarreraPolitica.aspx">
                                <i class="fa fa-cog" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3><a href="frmCarreraPolitica.aspx" title="">Carrera politica</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
        </div>
        <div class="row text-center">
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="what-bottom decrease">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmDonate.aspx">
                                <i class="fa fa-street-view" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3 ><a href="frmDonate.aspx" title="">Voluntarios</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="what-bottom decrease">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmProyectos.aspx">
                                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3><a href="frmProyectos.aspx" title="">Nuestros Proyectos</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="what-bottom decrease">
                    <div class="btn-icon">
                        <div class="then-icon">
                            <a href="frmBlog.aspx">
                                <i class="fa fa-star-o" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                    <div class="mission-text">
                        <h3><a href="frmBlog.aspx" title="">Blog</a></h3>
                    </div>
                    <p></p>
                </div>
            </div>
        </div>
    </div>
</section>
<%--<section class="support-area stripe-parallax-bg ptb-95" data-parallax-speed="0.5">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <div class="support-all">
                    <%Response.Write("<h1>" + Item.TituloAfiliate + "</h1>"); %>                    
                    <%Response.Write("<p>" + Item.DescAfiliate + "</p>"); %>                    
                    <div class="support-text">
                        <a class="hs-btn t2" href="#">Afilitate</a>                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>--%>
<section class="event-area ptb-80">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="what-top">
                                <div class="section-title">
                                    <h1>Próximos eventos</h1>
                                    <div class="what-icon">
                                        <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    </div>
                                </div>
                                <p class="up">Nos complace anunciar los eventos en los que estaremos presentes.</p>
                            </div>
                        </div>
                    </div>
  
                    <div class="row">
                        <div class="president">
                        <%int c = 0; %>
                        <%for (int g = 0; g < ListaEventos.Count; g++) %>
                        <%{ %>                  
                           <%if (c % 2 == 0) %>
                            <%{ %>
                            <div class="two-hover">
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="event-img">
                                        <a href="#">
                                            <img src="Content/img/banner/1.jpg" alt="">
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="event-text">
                                        <div class="event-time">
                                            <span class="published">
                                                <i class="fa fa-clock-o"></i>
                                                02d : 11h : 22m : 42s
                                            </span>
                                        </div>
                                        <%Response.Write("<h3><a href='#'>" + ListaEventos[c].Nombre + "</a></h3>"); c++;%>
                                        <div class="event-month">
                                            <span class="published2">
                                                <i class="fa fa-calendar" aria-hidden="true"></i>
                                                <%Response.Write(ListaEventos[c].FechaInicio); %>
                                            </span>                                            
                                        </div>
                                        <%Response.Write("<p>" + ListaEventos[c].Nombre+"</p>"); %>                                                                                
                                    </div>
                                </div>
                            </div>
                            <%} %>
                            <%else if (c %2 != 0) %>
                            <%{ %>
                            <div class="two-hover">
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="event-img">
                                        <a href="#">
                                            <img src="Content/img/banner/1.jpg" alt="">
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6 col-xs-12">
                                    <div class="event-text">
                                        <div class="event-time">
                                            <span class="published">
                                                <i class="fa fa-clock-o"></i>
                                                02d : 11h : 22m : 42s
                                            </span>
                                        </div>
                                        <%Response.Write("<h3><a href='#'>" + ListaEventos[c].Nombre + "</a></h3>"); c++; %> 
                                        <div class="event-month">
                                            <span class="published2">
                                                <i class="fa fa-calendar" aria-hidden="true"></i>
                                                4 May, 2016 
                                            </span>
                                            <span class="published2 comment-left">
                                                <i class="fa fa-comments-o" aria-hidden="true"></i>
                                                02 Comment 
                                            </span>
                                        </div>
                                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>
                                        <a href="#">Read more</a>
                                    </div>
                                </div>
                            </div>
                            <%} %>
                            <%} %>
                        </div>                        
                    </div>
                          
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="event-icon">
                                <a href="#">Load More <i class="fa fa-clock-o"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
<section class="counter_area ptb-70">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="counter-all">
                    <div class="counter-top">
                        <a href="#"><img src="Content/img/icon-img/1.png" alt=""></a>
                    </div>
                    <div class="counter-bottom">
                        <div class="counter-next">
                            <h2>Afiliados</h2>
                        </div>
                        <div class="counter cnt-one res">
                            <h1><%=DatosAux.CountAfiliado%></h1>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <div class="counter-all">
                    <div class="counter-top">
                        <a href="#"><img src="Content/img/icon-img/2.png" alt=""></a>
                    </div>
                    <div class="counter-bottom">
                        <div class="counter-next">
                            <h2>Visitantes</h2>
                        </div>
                        <div class="counter cnt-one res">
                            <h1>4214 </h1>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="meet-area pt-80 mb-80">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <div class="what-top">
                    <div class="section-title">
                        <%Response.Write("<h1>" + Item.TituloEquipoTrabajo + "</h1>"); %>                        
                        <div class="what-icon">
                            <i class="fa fa-users" aria-hidden="true"></i>
                        </div>
                    </div>
                    <%Response.Write("<p class='up'>"+Item.DescEquipoTrabajo+"</p>"); %>
                    <%--<p class="up">Conoce a nuestro equipo, los expertos en campañas politicas</p>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
            <div class="team-slider slider-active indicator-style">
                <%--Codigo Que hace dinamico la parte de equipo de trabajo--%>
                <%foreach (var Item1 in ListaMiembro)
                    {
                     %>
                <div class="col-md-3 text-center">
                    <div class="meet-all">
                        <div class="meet-img">
                            <a href="#"><img src="Content/img/banner/7.jpg" alt=""></a>
                        </div>
                        <div class="product-content">
                            <%Response.Write("<h3>"+Item1.nombreCompleto+"</h3>"); %>
                            <%Response.Write("<p>" + Item1.Puesto + "</p>"); %>                                                        
                        </div>
                        <div class="meet-text-all">
                            <div class="meet-text">
                                <%Response.Write("<h3>" + Item1.nombreCompleto + "</h3>"); %>
                                <%Response.Write("<p>" + Item1.Puesto + "</p>"); %>
                            </div>
                        </div>
                        <div class="meet-icon-all">
                            <div class="meet-icon">
                                <ul>
                                    <%if (Item1.paginaWeb != String.Empty)
                                        {
                                            Response.Write("<li><a href='" + Item1.paginaWeb + "'><i class='fa fa-link' aria-hidden='false'></i></a> </li>");
                                        }
                                        if (Item1.ctaFB != String.Empty && Item1.facebook!= String.Empty)
                                        {
                                            Response.Write("<li><a href='"+Item1.ctaFB+"'><i class='"+"fa " +Item1.facebook+"'></i></a></li>");
                                        }
                                        if (Item1.ctaGoog != String.Empty && Item1.google!= String.Empty)
                                        {
                                            Response.Write("<li><a href='"+Item1.ctaGoog+"'><i class='"+"fa " +Item1.google+"'></i></a></li>");
                                        }
                                        if (Item1.ctaTW != String.Empty && Item1.twitter!= String.Empty)
                                        {
                                            Response.Write("<li><a href='"+Item1.ctaTW+"'><i class='"+"fa " +Item1.twitter+"'></i></a></li>");
                                        }
                                        if (Item1.ctaInsta != String.Empty && Item1.instagram!= String.Empty)
                                        {
                                            Response.Write("<li><a href='"+Item1.ctaInsta+"'><i class='"+"fa " +Item1.instagram+"'></i></a></li>");
                                        }
                                        if (Item1.pinterest != String.Empty && Item1.pinterest!= String.Empty)
                                        {
                                            Response.Write("<li><a href='"+Item1.ctaPint+"'><i class='"+"fa " +Item1.pinterest+"'></i></a></li>");
                                        }%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <%} %>
                <%--Fin del Codigo--%>
            </div>
        </div>
        </div>
    </div>
</section>
<section class="campaign-area pb-80">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <div class="what-top meet campaign">
                    <div class="section-title">
                        <%Response.Write("<h1>"+Item.TituloBlog+"</h1>"); %>
                        <div class="what-icon">
                            <i class="fa fa-newspaper-o" aria-hidden="true"></i>
                        </div>
                    </div>
                    <%Response.Write("<p class='up'>"+ Item.DescBlog+"</p>"); %>                    
                </div>
            </div>
        </div>
        <div class="row">
            <div class="campaign-bottom">
                <%foreach (var item in ListaBlog)
                    {%>
                       <div class="col-md-4 col-sm-4">
                    <div class="blog-container-inner">
                        <div class="post-thumb">
                            <a href="#"><img class="attachment-blog-list" src="Content/img/blog/15.jpg"<%--<%=item.UrlImagen %>--%> alt=""></a>
                            <a class="tb-publish" href="#"><i class="fa fa-file-image-o" aria-hidden="true"></i></a>
                        </div>
                        <div class="visual-inner">
                            <h3 class="blog-title">
                                <%Response.Write("<a href='frmDescBlog.aspx?op=2&id="+item.IDPublicacion+"'>"+item.Title+"</a>");%>                                
                            </h3>
                            <div class="blog-meta">
                                <span class="published3">
                                    <%Response.Write("<iclass='fa fa-calendar' aria-hidden='true'></i>"+item.Fecha.ToShortDateString()+""); %>                                     
                                </span>                                
                            </div>
                            <div class="blog-content">
                                <%Response.Write("<p>"+item.TextoReducido+"</p>"); %>                                
                            </div>
                            <div class="readmore">
                                <%Response.Write("<a href='frmDescBlog.aspx?op=2&id="+item.IDPublicacion+"'>Leer mas</a>"); %>
                            </div>
                        </div>
                    </div>
                </div>
                  <%  }
                     %>
            </div>
        </div>
    </div>
</section>
<section class="contact-area ptb-80">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <div class="what-top meet">
                    <div class="section-title">
                        <%Response.Write("<h1>"+Item.TituloContactanos+"</h1>"); %>                        
                        <div class="what-icon">
                            <i class="fa fa-envelope" aria-hidden="true"></i>
                        </div>
                    </div>
                    <%Response.Write("<p class='up'>"+Item.Contactanos+" </p>"); %>
                    <%--<p class="up">Envianos un mensaje, con gusto te responderemos</p>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <h1 id="Correcto" style="text-align:center; background-color:#ea000d; border-radius: 50px;"></h1>
            <div id="IDContacto" class="all-contact-area contact-form">
                <form id="contact-form" onsubmit="ValidarContacto()">
                    <div class="all-contact-text">
                        <div class="col-md-3 col-sm-6">
                            <div class="di-na">
                                <input class="form-control" id="Nombre" name="Nombre" placeholder="Nombre completo" type="text" />
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="di-na">
                                 <input class="form-control" id="Correo" name="Correo"  placeholder="Correo" type="email">
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="di-na res-1">
                                  <input class="form-control" id="Telefono" name="Telefono" placeholder="Telefono" type="text">
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="di-na res-1">
<%--                                <button class="wpcf7" type="submit">
                                Enviar Mensaje
                            </button>--%>
                                <input class="wpcf7" type="submit" value="Enviar">
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <div class="di-na res-sub">
                                <input class="form-control" id="Asunto" name="Asunto" placeholder="Asunto" type="text">
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <div class="tnm-textarea">
                                <textarea class="form-control" id="Mensaje" name="Mensaje" placeholder="Mensaje"></textarea>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</section>
    <% }%>
<div class="map-area">
    <div class="contact-map">
        <div id="hastech"></div>
    </div>
</div>
    <script src="Content/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="Content/js/form-validation.js"></script>
    <script>
        jQuery(document).ready(function () {
            FormValidator.init();
        });
    </script>
    <script>
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
            <li><a class="active" href="frmHome.aspx">Home </a></li>
            <li><a href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a href="frmGaleria.aspx">Galeria </a></li>
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>