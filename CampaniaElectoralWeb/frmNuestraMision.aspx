<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuestraMision.aspx.cs" Inherits="CampaniaElectoralWeb.frmNuestraMision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="elements-area ptb-140">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="breadcrumbs">
                        <h2 class="page-title" style="color: black;">Misión y Visión</h2>
                        <ul>
                            <li><a href="#">Inicio</a></li>
                            <li style="color:black;">Misión y Visión</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="tab-accordion-area bg-off-white ptb-80 elements-tab-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="what-top line">
                        <div class="section-title">
                            <h1><%=Datos.TablaDatos.Rows[0]["Titulo"].ToString()%></h1>
                            <div class="what-icon">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>
                            </div>
                        </div>
                        <p class="up"><%=Datos.TablaDatos.Rows[0]["Descripcion"].ToString()%></p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div class="tab-content fix">
                        <%--<%=Datos.TablaDatos.Rows[0]["UrlImagenM"].ToString()%>--%>
                        <img src="Content/img/blog/12.jpg" class="col-md-4 img-responsive" alt="<%=Datos.TablaDatos.Rows[0]["AltM"].ToString()%>" title="<%=Datos.TablaDatos.Rows[0]["TitleM"].ToString()%>">
                        <br>
                        <br>
                        <p class="col-md-8">
                           <%=Datos.TablaDatos.Rows[0]["Mision"].ToString()%>
                        </p>

                    </div>
                    <br>
                    <br>
                    <br>
                    <div class="row">
                        <div class="container hidden-md-up">
                            <%--<%=Datos.TablaDatos.Rows[0]["UrlImagenV"].ToString()%>--%>
                            <img src="Content/img/blog/12.jpg" class="col-sm-4 col-sm-push-8   img-responsive" alt="<%=Datos.TablaDatos.Rows[0]["AltV"].ToString()%>" title="<%=Datos.TablaDatos.Rows[0]["TitleV"].ToString()%>">
                            <br>
                            <br>
                            <p class=" col-sm-8 col-sm-pull-4">
                               <%=Datos.TablaDatos.Rows[0]["Vision"].ToString()%>
                            </p>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br><br><br> 
        <div class="row">
            <div class="container">
                <div class="col-md-12 " style="background-color: #333333;">

                    <br>
                    <br>
                    <br>
                    <br>
                </div>

            </div>

        </div>
        <br><br><br>
        <div class="row">
            <div class="container">
                <div class="col-md-12">
                    <p><%=Datos.TablaDatos.Rows[0]["Valores"].ToString()%>
                    </p>
                </div>

            </div>

        </div>
        <%--<div class="container-fluid qut-pad">
            <section class="slider-main-area">
                <div class="main-slider an-si">
                    <div class="bend niceties preview-2">
                        <div id="ensign-nivoslider-2" class="slides">
                            <img src="Content/img/slider/3.jpg" alt="" title="#slider-direction-2" />
                            <img src="Content/img/slider/3.jpg" alt="" title="#slider-direction-1" />
                        </div>
                        <div id="slider-direction-1" class="t-cn slider-direction Builder">
                            <div class="container">
                                <div class="slide-all slide-1">
                                    <!-- layer 2 -->
                                    <div class="layer-2 text-center">
                                        <h1 class="title6">Misión</h1>
                                    </div>
                                    <!-- layer 2 -->
                                    <div class="layer-2 alinear">
                                        <h1 class="title5 text-center"><%=Datos.TablaDatos.Rows[0]["Mision"].ToString()%></h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="slider-direction-2" class="t-cn slider-direction Builder">
                            <div class="container">
                                <div class="slide-all slide-2">
                                    <!-- layer 2 -->
                                    <div class="layer-2 text-center">
                                        <h1 class="title6">Visión</h1>
                                    </div>
                                    <!-- layer 2 -->
                                    <div class="layer-2 alinear">
                                        <h1 class="title5 text-center"><%=Datos.TablaDatos.Rows[0]["Vision"].ToString()%></h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>--%>
    </div>
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