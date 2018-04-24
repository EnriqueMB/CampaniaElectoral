<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmDescBlog.aspx.cs" Inherits="CampaniaElectoralWeb.frmDescBlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title" style="color: black;">Blog</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li style="color:black;">Blog</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="service-area pb-80 elements3">
        <div class="container">
            <div class="col-md-12 text-center">
                 <% foreach (var Item in Lista)
                     {%>
                    <div class="what-top line">
                        <div class="section-title">                           
                            <%Response.Write("<h1>" + Item.Titulo + " </h1>"); %>                            
                            <div class="what-icon">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>
                            </div>
                        </div>                       
                        <%Response.Write("<p style='text-align: justify;'> " + Item.TextoHtml + " </p>"); %>                                                
                        <%Response.Write("<img> src=" + Item.UrlImagen + " </img>"); %>                        
                    </div>
                <%} %>
                </div>
            <div class="row">

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

