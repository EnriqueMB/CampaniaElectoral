<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGaleriaVideos.aspx.cs" Inherits="CampaniaElectoralWeb.frmGaleriaVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title">Galeria</h2>
                        <ul>
                            <li><a href="frmHome.aspx">Home</a></li>
                            <li>Galeria</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="elements-video-area bg-off-white ptb-80">
        <div class="container">
            <div class="row">
                <div class="elements-video-one">
                    <% foreach (var ItView in Lista)
                        { %>                    
                    <div class="col-md-3 col-lg-3 col-sm-6 col-xs-12">
                        <div class="banner-img mrg-video-elements mrg-video-elements2">
                            <a href="<%=ItView.Link %>"><img src="<%=ItView.Url %>" alt=""></a>                            
                        </div>
                        <br/>
                    </div>                    
                    <% } %>
                </div>                
            </div>
        </div>
    </div>    
    </asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolderFooter">
    <div class="footer-menu">
        <ul>
            <li><a href="frmHome.aspx">Home </a></li>
            <li><a href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a  class="active" href="frmGaleria.aspx">Galeria </a></li>
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>