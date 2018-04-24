<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="frmCarreraPolitica.aspx.cs" Inherits="CampaniaElectoralWeb.frmCarreraPolitica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title" style="color: black;">Carrera Política</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li style="color:black;">Carrera Política</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="timeline-area ptb-80">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="what-top line">
                        <div class="section-title">
                            <h1><%=DatosAdmin.Title.ToString()%></h1>
                            <div class="what-icon">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>
                            </div>
                        </div>
                        <p class="up"><%=DatosAdmin.Descripcion.ToString()%></p>
                    </div>
                </div>
                    <% int i = 1;
                       String data = "";
                 foreach (var Item in Lista)
                {  if(i%2==0){ 
                     data = "res-sin";
                    
                    %>

                <div class="timeline-wraper fix">
                    <div class="sin-timeline col-md-6 col-sm-6 text-center  <%=data %> ">
                        <span class="timeline-date"><%=Item.FechaRealizado.ToShortDateString() %></span>
                        <div class="timeline-content">
                            <a class="timeline-img" href="#"><img src="Content/img/banner/26.jpg" alt=""></a>
                            <div class="timeline-text">
                                <h3><a href="#"><%=Item.Title %></a></h3>
                                <p><%=Item.Descripcion %></p>
                                <%Response.Write("<a href='frmVcarreraP.aspx?op=3&id=" + Item.IDCarreraPolitica.ToString() + "' > Ver más </a>"); %>
                            </div>
                        </div>
                    </div>
                       <%}
                         else{%>
                    <div class="timeline-wraper fix">
                        <div class="sin-timeline col-md-6 col-sm-6 text-center ">
                            <%Response.Write("<span class='timeline-date'>"+Item.FechaRealizado.ToShortDateString()+"</span>"); %>                            
                            <div class="timeline-content">
                                <a class="timeline-img" href="#"><img src="Content/img/banner/26.jpg" alt=""></a>
                                <div class="timeline-text">
                                    <%Response.Write("<h3><a href='#'>"+Item.Title+"</a></h3>"); %>                                    
                                    <%Response.Write("<p>"+Item.Descripcion+"</p>"); %>                                    
                                    <%--<%Response.Write("<a href='frmVcarreraP.aspx?op=3&id=" + Item.IDCarreraPolitica.ToString() + "' > Ver más </a>"); %>--%>
                                </div>
                            </div>
                        </div>
                    
                    
                           <% }} %>
                     <div class="read-icon">
                        <a class="re-icon" href="#"><i class="fa fa-ellipsis-h" aria-hidden="true"></i></a>
                        <%--<a href="#">Load More</a>--%>
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
            <li><a class="active" href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a href="frmGaleria.aspx">Galeria </a></li>
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>