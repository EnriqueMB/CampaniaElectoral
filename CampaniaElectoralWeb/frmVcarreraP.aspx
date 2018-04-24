<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="frmVcarreraP.aspx.cs" Inherits="CampaniaElectoralWeb.WebForm3" %>
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
                    <% foreach (var Item in Lista)
                        { %>
                    <div class="col-md-12 text-center">
                        <div class="what-top line">
                            <div class="section-title">
                                <h1>
                                    <%=Item.TituloProyecto %>
                                </h1>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="two-hover">
                    <div class="col-md-5 col-sm-6 col-xs-12">
                        <div class="event-img">
                            <a href="#">
                                <img src="Content/img/banner/26.jpg <%--<%=Item.URLImagen%> --%> " alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="event-text">
                            <h3><a href="#"></a></h3>
                            <div class="event-month">
                                <span class="published2">
                                    <i class="fa fa-calendar" aria-hidden="true"></i>
                                    <%=Item.Proyecto1 %>
                                </span>

                            </div>
                            <p><%=Item.Proyecto2%></p>
                        </div>
                    </div>
                </div>
                <%} %>
            </div>
        </section>
    </asp:Content>