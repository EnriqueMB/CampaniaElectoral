<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmProyectos.aspx.cs" Inherits="CampaniaElectoralWeb.frmProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="breadcrumbs-area ptb-140 Blog-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="breadcrumbs">
                                <h2 class="page-title">Proyectos</h2>
                                <ul>
                                    <li><a class="active" href="#">Inicio</a></li>
                                    <li>Proyectos</li>
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
                        <%foreach(var Item in Lista) { %>
                        <div class="visual-inner">
                            <h3 class="blog-title"><%Response.Write(Item.TituloProyecto); %>
                            </h3>
                            <div class="blog-content">
                                <%Response.Write("<p style='text-align: justify;'>"+Item.Proyecto1+"</p>"); %>
                                <%Response.Write("<p style='text-align: justify;'>"+Item.Proyecto2+"</p>"); %>
                                <%Response.Write("<p class='blog-paragraph' style='text-align: justify; margin-bottom: 2vh;'>"+Item.Proyecto3+"</p>"); %>                                
                            </div>
                        </div>
                        <%} %>
                        <div class="issues-details-bottom">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="issues-details-title">
                                        <h3>Otros Proyectos</h3>
                                    </div>
                                </div>
                                <%foreach (var Item4 in ListaM)
                                    { %>
                                <div class="col-md-4 col-sm-4">
                                    <div class="issues-bottom">
                                        <a href="#">
                                            <img alt="" src="Content/img/blog/8.jpg"></a>
                                        <%Response.Write("<h3>"+Item4.TituloProyecto+"</h3>"); %>
                                        <div class="blog-meta tnm">
                                            <%Response.Write("<p>"+Item4.Proyecto1.Substring(0,15)+"<a href='frmProyectoDetalle.aspx?op=2&id="+Item4.IDPElectoral+"'>Ver más</a></p>"); %>                                                                                 
                                        </div>
                                    </div>
                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-md-3">
                    <div class="issues-categoris issues-top2 two-mrg-two">
                        <h3>Otros Proyectos</h3>
                        <div class="cat-one">
                            <ul>
                                <%foreach (var Item1 in Lista){ %>
                                <%Response.Write("<li><a href='frmProyectoDetalle.aspx?op=2&id="+Item1.IDPElectoral+"'>"+Item1.TituloProyecto+"</a></li>"); %>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                    <div class="issues-categoris issues-top3">
                        <h3>Novedades del BLog</h3>
                        <div class="categori-list1">
                            <%foreach(var Item2 in ListaB) {%>
                            <div class="categori-list-one">
                                <div class="categori-list-img">                                    
                                    <%Response.Write("<a href='frmDescBlog.aspx?op=2&id="+Item2.IDPublicacion+"'><img src='Content/img/blog/14.jpg' alt=''></a>"); %>                                        
                                </div>
                                <div class="post-details">
                                    <%Response.Write("<p>"+Item2.Titulo+"</p>"); %>                                    
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
