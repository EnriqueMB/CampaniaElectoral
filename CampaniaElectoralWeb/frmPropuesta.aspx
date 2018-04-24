<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmPropuesta.aspx.cs" Inherits="CampaniaElectoralWeb.frmPropuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">                  
            <section class="elements-area ptb-140">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="breadcrumbs">
                                <h2 class="page-title" style="color: #ea000d;">Propuestas</h2>
                                <ul>
                                    <li><a href="#">Home</a></li>
                                    <li>service</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    <section class="event-area-three bg-gray ptb-80">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="what-top event3 even4">
                                <div class="section-title">
                                    <h1>Propuestas</h1>
                                    <div class="what-icon">
                                        <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    </div>
                                </div>
                                <strong><p class="up">Me complace anunciar las siguientes propuestas para el pueblo de Tuxtla Gutiérrez.</p></strong>
                            </div>
                        </div>
                    </div>
                    <br><br>
                    <%int z = Lista.Count / 2; %>
                    <%for (int x = 0; x < z; x++) %>
                    <%{ %>
                    <%if (x < 2) %>
                    <%{ %>
                    <div class="row">
                        <%for (int i = 0; i <= 1; i++) %>
                        <%{ %>
                        <%int c = 0; %>
                        <%if (i % 2 == 0) %>
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four res-4">
                                <div class="event-img3">
                                    <img src="Content/img/banner/47.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>
                                        <span class="published4-four">                                            
                                        </span>
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>                                    
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>                        
                        <%} %>
                        <%else %>                      
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four rest">
                                <div class="event-img3">
                                    <img src="Content/img/banner/48.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>                                        
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%c++; %>                      
                        <%} %>
                    </div>
                    <br><br>
                    <%} %>
                    <%else if (x < 4) %>
                    <%{ %>
                    <div class="row" id="div2" style="display:none">
                        <%for (int i = 0; i <= 1; i++) %>
                        <%{ %>
                        <%int c = 0; %>
                        <%if (i % 2 == 0) %>
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four res-4">
                                <div class="event-img3">
                                    <img src="Content/img/banner/47.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>
                                        <span class="published4-four">                                            
                                        </span>
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>                                    
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>                        
                        <%} %>
                        <%else %>                      
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four rest">
                                <div class="event-img3">
                                    <img src="Content/img/banner/48.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>                                        
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%c++; %>                      
                        <%} %>
                    </div>
                    <br><br>
                    <%} %>
                    <%else if (x < 6) %>
                    <%{ %>
                    <div class="row" id="div2" style="display:none">
                        <%for (int i = 0; i <= 1; i++) %>
                        <%{ %>
                        <%int c = 0; %>
                        <%if (i % 2 == 0) %>
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four res-4">
                                <div class="event-img3">
                                    <img src="Content/img/banner/47.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>
                                        <span class="published4-four">                                            
                                        </span>
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>                                    
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>                        
                        <%} %>
                        <%else %>                      
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four rest">
                                <div class="event-img3">
                                    <img src="Content/img/banner/48.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>                                        
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%c++; %>                      
                        <%} %>
                    </div>
                    <br><br>
                    <%} %>
                    <%else if (x < 8) %>
                    <%{ %>
                    <div class="row" id="div2" style="display:none">
                        <%for (int i = 0; i <= 1; i++) %>
                        <%{ %>
                        <%int c = 0; %>
                        <%if (i % 2 == 0) %>
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four res-4">
                                <div class="event-img3">
                                    <img src="Content/img/banner/47.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>
                                        <span class="published4-four">                                            
                                        </span>
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>                                    
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>                        
                        <%} %>
                        <%else %>                      
                        <%{ %>
                        <div class="col-md-6 col-sm-12">
                            <div class="event-text-img-four rest">
                                <div class="event-img3">
                                    <img src="Content/img/banner/48.jpg" alt="">
                                    <a class="tb-publish" href="">
                                        <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                    </a>
                                </div>
                                <div class="visual-inner-four">
                                    <h3 class="blog-title-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>" + Lista[c].NombrePropuesta + "</a>"); %>
                                    </h3>
                                    <div class="blog-meta-four">
                                        <span class="published3-four">
                                            <i class="fa fa-calendar" aria-hidden="true"></i>
                                            <%Response.Write(Lista[c].Fecha.ToShortDateString()); %>
                                        </span>                                        
                                    </div>
                                    <div class="blog-content">
                                        <%Response.Write("<p>" + Lista[c].Descripcion1 + "<p>"); %>
                                    </div>
                                    <div class="readmore-four">
                                        <%Response.Write("<a href='frmPropuestaDetalle.aspx?op=2&id="+Lista[c].IDPropuesta+"'>Leer mas</a>"); %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%c++; %>                      
                        <%} %>
                    </div>
                    <br><br>
                    <%} %>
                    <%} %>
                         
                    <div class="row">
                        <div class="col-md-12">
                            <div class="loadmore">
                                <span onclick="vermas()" class="current 0">Load more</span>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <script type="text/javascript">
    function vermas() {
        var eldiv = document.getElementById("div2");
    eldiv.style.display="block";   
    }
    </script>
</asp:Content>