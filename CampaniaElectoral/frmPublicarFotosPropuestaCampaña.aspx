<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmPublicarFotosPropuestaCampaña.aspx.cs" Inherits="CampaniaElectoral.frmPublicarFotosPropuestaCampaña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
		<div class="col-md-12">
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Galer&iacute;a de Fotos</h4>
				</div>                
				<div class="panel-body">
					<hr/>
					<!-- GRID -->
					<ul id="Grid" class="list-unstyled">

						<% foreach (var Item in Lista)
							{
								string HTMLli = string.Format(@"<li class='col-md-3 col-sm-6 col-xs-12 mix category_1 gallery-img' data-cat='1'>
													<div class='portfolio-item'>
														<a class='thumb-info' href='Images/Fotos/{0}' data-lightbox='gallery' data-title='{1}'>
															<img src='Images/Fotos/{0}' class='img-responsive redim' alt='{2}'>
															<span class='thumb-info-title'> {1} </span>
														</a>
														<div class='chkbox'>
														<a href='frmPublicarFotosPropuestaCampaña.aspx?op=2&id={3}'>															
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
																<a href='frmPublicarFotosPropuestaCampaña.aspx?op=3&id={3}&id2={4}' class='btn btn-green add-row' runat='server'>Si</a>
															</div>
														</div>
													</div>
												</div>", Item.NombreArchivo, Item.Title, Item.Alt, Item.IDFoto,Item.IDPropuesta);
								Response.Write(HTMLli);
							} %>
						<li class="gap"></li>
						<!-- "gap" elements fill in the gaps in justified grid -->
					</ul>
				</div>
			</div>
		</div>
	</div>

	<!--[if gte IE 9]><!-->
	<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!--<![endif]-->    
	<script src="assets/js/ui-notifications.js"></script>
	<script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>	
	<script src="assets/js/pages-gallery.js"></script>
	<script>
		jQuery(document).ready(function() {
			PagesGallery.init();
		});
	</script>
    </asp:Content>