<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGaleriaFotos.aspx.cs" Inherits="CampaniaElectoral.frmGaleriaFotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
		<div class="col-md-12">
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Galer&iacute;a de Fotos</h4>
				</div>
                <div class="controls" style="padding-left:10px;">
                    <a href="frmFotos.aspx" class="btn btn-green">Agregar <i class="fa fa-plus"></i></a>
                </div>
				<div class="panel-body">
					<hr/>
					<ul id="Grid" class="list-unstyled">
                        <% foreach (var Item in this.Lista)
                            {
                                string HTMLli = string.Format(@"<li class='col-md-3 col-sm-6 col-xs-12 mix category_1 gallery-img' data-cat='1'>
							                        <div class='portfolio-item'>
								                        <a class='thumb-info' href='{0}' data-lightbox='gallery' data-title='{1}'>
									                        <img src='{0}' class='img-responsive redim' alt='{2}'>
									                        <span class='thumb-info-title'> {1} </span>
								                        </a>
                                                        <div class='tools tools-bottom'>
														<a href='frmFotos.aspx?op=2&id={3}'>
															<i class='fa fa-pencil'></i>
														</a>
														<a data-placement='top' data-target='.bs-example-modal-sm{3}'role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-trash-o'></i></a>
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
					                                                ¿Está seguro de eliminar la imagen seleccionada?
				                                                </p>
			                                                </div>
			                                                <div class='modal-footer'>                     
				                                                <button data-dismiss='modal' class='btn btn-red' type='button'>No</button>
                                                                <a href='frmGaleriaFotos.aspx?op=3&id={3}' class='btn btn-green add-row' runat='server'>Si</a>
                                                            </div>
		                                                </div>
	                                                </div>
                                                </div>", Item.URLImagen, Item.Title, Item.Alt, Item.IDFoto);
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
