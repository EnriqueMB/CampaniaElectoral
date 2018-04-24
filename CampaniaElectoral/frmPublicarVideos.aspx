<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmPublicarVideos.aspx.cs" Inherits="CampaniaElectoral.frmPublicarVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <%--<div class="col-md-12">
            </div>--%>
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><i class="fa fa-video-camera" aria-hidden="true"></i><span class="text-bold"> Visualizar Videos</span></h4>
                </div>
                <div class ="pull-right">
                    <%--<button data-original-title="Validar" type="button" data-placement="bottom" class="btn tooltips btn-green"> Validar <i class="fa fa-arrow-circle-right"></i>
                    </button>--%>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                    </div>
                    <div class="row">
                        <% foreach (var ItView in Lista)
                            { %>
                        <ul class="list-unstyled">
                            <li class="col-md-3 col-sm-6 col-xs-12 mix category_1 gallery-img" data-cat="<%=ItView.IDVideo %>">
                                <div class="portfolio-item">
                                    <a class="thumb-info" data-lightbox="gallery" data-title="<%=ItView.Alt %>">
                                        <img src="<%=ItView.Url %>" class="img-responsive" alt="">
                                        <span class="thumb-info-title"><%=ItView.Alt %> </span>
                                    </a>
                                    <div class='chkbox'>                                        
                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + ItView.IDVideo.ToString() + "'class='btn btn-transparent' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Subir a la pagina'><i ></i></a>");%>
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <div class="modal fade bs-example-modal-sm<% = ItView.IDVideo %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                                            ×
                                        </button>
                                        <h4 id="mySmallModalLabel" class="modal-title">Confirmación</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>¿Está seguro de subir a la pagina el elemento seleccionado?</p>
                                    </div>
                                    <div class="modal-footer">
                                        <button data-dismiss="modal" class="btn btn-red" type="button">No</button>
                                        <%Response.Write("<a  href='frmPublicarVideos.aspx?op=3&id=" + ItView.IDVideo.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<script src="assets/js/form-validation2.js"></script>
	<script src="assets/js/ui-notifications.js"></script>
	<script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<script src="assets/js/main.js"></script>	
	<script src="assets/js/pages-gallery.js"></script>	
    <script>
		jQuery(document).ready(function() {
			PagesGallery.init();
		});
	</script>
</asp:Content>