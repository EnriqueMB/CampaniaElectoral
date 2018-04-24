<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmBlog.aspx.cs" Inherits="CampaniaElectoralWeb.frmBlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="breadcrumbs-area ptb-140 Blog-bg">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title">Blog</h2>
                        <ul>
                            <li><a class="active" href="frmBlog.aspx">Inicio</a></li>
                            <li>Blog</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="blog-two-details-area ptb-80">
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <div class="blog-container-inner">
                        <div class="post-for2">
                        </div>
                        <%for (int i = 0; i < ListaBlog.Count; i++)
                          {%>
                        <%if (i % 2 == 0)
                          {%>
                        <%for (int x = 0; x < 1; x++)
                          {%>
                        <div class="row">
                            <div class="col-sm-5">
                                <img src="Content/img/blog/8.jpg">
                            </div>
                            <div class="col-sm-7">
                                <% Response.Write("<h3>" + ListaBlog[i].Titulo + "</h3>"); %><h3></h3>
                                <%Response.Write("<p>" + ListaBlog[i].TextoReducido + " <a href='frmDescBlog.aspx?op=2&id=" + ListaBlog[i].IDPublicacion + "'>Ver más</a></p>"); %>
                            </div>
                        </div>
                        <br />
                        <br />
                        <%} %>
                        <%}%>
                        <%else
                          { %>
                        <%for (int y = 0; y < 1; y++)
                          { %>
                        <div class="row">
                            <div class="col-sm-7">
                                <% Response.Write("<h3>" + ListaBlog[i].Titulo + "</h3>"); %><h3></h3>
                                <%Response.Write("<p>" + ListaBlog[i].TextoReducido + "<a href='frmDescBlog.aspx?op=2&id=" + ListaBlog[i].IDPublicacion + "'>Ver más</a></p>"); %>
                                <%--<p><a href="#">Ver más</a></p>--%>
                            </div>
                            <div class="col-sm-5 hidden-xs">
                                <img style="" src="Content/img/blog/12.jpg">
                            </div>
                        </div>
                        <br />
                        <br />
                        <%} %>
                        <%} %>
                        <%} %>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="issues-categoris issues-top2 two-mrg-two">
                        <h3>Proyectos</h3>
                        <div class="cat-one">
            		<% foreach (var Item in Lista)
                    { %>
            		<ul>
                		<%Response.Write("<li><a href='frmPropuestaDetalle.aspx?op=2&id="+Item.IDPropuesta+"'>"+Item.NombrePropuesta+"</a></li>"); %>                
            		</ul>
                
                		<%} %>            
       				</div>
                    </div>
                    <div class="issues-categoris issues-top3">
				        <h3>Novedades del Blog</h3>
				        <div class="categori-list1">

				            <%foreach (var Item in ListaBlog)
				                    { %>
				            <div class="categori-list-one">                
				                <div class="categori-list-img">
				                    <%Response.Write("<a href='frmDescBlog.aspx?op=2&id="+Item.IDPublicacion+"'><img style='border-radius:0%' src="+Item.UrlImagen+" alt=''</a>"); %>
				                    <%--<a href="#"><img style="border-radius: 0%;" src="Content/img/blog/17.jpg" alt=""></a>--%>
				                </div>
				                <div class="post-details">                    
				                    <%Response.Write("<p>" + Item.Titulo + "</p>");%>                    
				                </div>                
				            </div>
				            <%} %>   
				        </div>
				    </div> 
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolderFooter">
    <div class="footer-menu">
        <ul>
            <li><a href="frmHome.aspx">Home </a></li>
            <li><a href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a href="frmGaleria.aspx">Galeria </a></li>
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a class="active" href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>
