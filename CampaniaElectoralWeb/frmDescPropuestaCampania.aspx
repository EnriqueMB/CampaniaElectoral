<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmDescPropuestaCampania.aspx.cs" Inherits="CampaniaElectoralWeb.frmDescPropuestaCampania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title" style="color: black;">Propuesta de Campaña</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li style="color:black;">Propuesta de Campaña</li>
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
                            <%Response.Write("<h1>" + Item.NombrePropuesta + " </h1>"); %>                            
                            <div class="what-icon">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>
                            </div>
                        </div>
                        <h1 > Nuestra Propuesta Consiste en: </h1>
                        <%Response.Write("<p style='text-align: justify;'> " + Item.Descripcion1 + " </p>"); %>
                        <h2 > Gestionaremos la propuesta de la siguente manera:  </h2>
                        <%Response.Write("<p style='text-align: justify;'> " + Item.Descripcion2 + " </p>"); %>
                        <h3 > El presupuesto para nuestra propuesta es de: </h3>
                        <%Response.Write("<p style='text-align: justify;'> $" + Item.Descripcion3 + " </p>"); %>                       
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
            <li><a class="active" href="frmHome.aspx">Home </a></li>
            <li><a href="frmCarreraPolitica.aspx">Carrera Politica</a></li>
            <li><a href="frmGaleria.aspx">Galeria </a></li>
            <li><a href="frmContacto.aspx">Contacto</a></li>
            <li><a href="frmEventos.aspx">Evento</a></li>
            <li><a href="frmBlog.aspx">Blog</a></li>
        </ul>
    </div>
</asp:Content>