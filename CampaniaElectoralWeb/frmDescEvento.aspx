<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmDescEvento.aspx.cs" Inherits="CampaniaElectoralWeb.frmDescEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title" style="color: black;">Eventos</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li style="color:black;">Evento</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="service-area pb-80 elements3">
        <div class="container">
            <div class="col-md-9 text-center">
                 <% foreach (var Item in Lista) { %>
                    <div class="what-top line">
                        <div class="section-title"> 
                            <%Response.Write("<h1>" + Item.TituloPagina + " </h1>"); %>
                            <div class="event-time">
                            <span class="published">
                                <i class="fa fa-clock-o"></i>
                                <%Response.Write(Item.FechaEvento.ToShortDateString() + ' ' + Item.HoraEvento); %>
                            </span>
                        </div>
                            <div class="what-icon">
                                <i class="fa fa-line-chart"></i>
                            </div>
                        </div>
                        <%Response.Write("<p style='text-align: justify;'> " + Item.TextoPagina + " </p>"); %>
                        <%Response.Write("<img src='" + Item.UrlImagen + "'></img>"); %>
                        </div>   
                <%} %>
                </div>
            <div class="col-md-3">
                            <div class="issues-categoris issues-top3">
                                <h3>Otros Eventos</h3>
                                <div class="categori-list1">
                                    <%foreach(var iten in ListaEventos) {%>
                                    <div class="categori-list-one">
                                        <div class="categori-list-img">
                                            <%Response.Write("<a href='frmDescEvento.aspx?op=2&id="+ iten.IDEvento +"'> <img src='" +iten.Imagen+"' alt=''></a>"); %>
                                        </div>
                                        <div class="post-details">
                                            <%Response.Write("<p>"+iten.Nombre+ "</p>"); %>
                                        </div>
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                        </div>
            <div class="row">

            </div>
        </div>
    </section>
    </asp:Content>


