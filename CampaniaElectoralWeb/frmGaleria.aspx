<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmGaleria.aspx.cs" Inherits="CampaniaElectoralWeb.frmGaleria" %>
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
        <ul id="Grid" class="list-unstyled">

						<% foreach (var Item in this.Lista)
							{
								string HTMLli = string.Format(@"<li class='col-md-3 col-sm-6 col-xs-12 mix category_1 gallery-img' data-cat='1'>
													<div class='portfolio-item'>
														<a class='thumb-info' href='Images/Fotos/{0}' data-lightbox='gallery' data-title='{1}'>
															<img src='Images/Fotos/{0}' class='img-responsive redim' alt='{2}'>
															<span class='thumb-info-title'> {1} </span>
														</a>
														<div class='chkbox'>
														<a href='frmPublicarFotos.aspx?op=2&id={3}'>															
														</a>
														<a class='btn btn-transparent data-placement='top' data-target='.bs-example-modal-sm{3}'role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Agregar'><i ></i></a>
													</div>
													</div>
												</li>
												<div class='modal fade bs-example-modal-sm{3}' tabindex='-1' role='dialog' aria-labelledby='mySmallModalLabel' aria-hidden='true'>
													<div class='modal-dialog modal-sm'>
														<div class='modal-content'>
															<div class='modal-header'>
																<button aria-hidden='true' data-dismiss='modal' class='close' type='button'>
																	×
																</button>
																<h4 id='mySmallModalLabel' class='modal-title'>Confirmación</h4>
															</div>
															<div class='modal-body'>
																<p>
																	¿Está seguro de agregar la imagen seleccionada?
																</p>
															</div>
															<div class='modal-footer'>                     
																<button data-dismiss='modal' class='btn btn-red' type='button'>No</button>
																<a href='frmPublicarFotos.aspx?op=3&id={3}' class='btn btn-green add-row' runat='server'>Si</a>
															</div>
														</div>
													</div>
												</div>", Item.NombreArchivo, Item.Title, Item.Alt, Item.IDFoto);
								Response.Write(HTMLli);
							} %>
						<li class="gap"></li>
						<!-- "gap" elements fill in the gaps in justified grid -->
					</ul>
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