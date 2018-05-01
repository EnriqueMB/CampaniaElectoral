<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSeccionDetalle.aspx.cs" Inherits="CampaniaElectoral.frmSeccionDetalle" %>
<asp:Content runat="server" ContentPlaceHolderID="cph_MasterBody">
    <div class="row">
	    <div class="col-md-12">
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title">Sección <span class="text-bold" runat="server" id="spanSeccion"></span></h4>
				</div>
				<div class="panel-body">
					<div class="row">
                        <asp:HiddenField ID="hf2" runat="server" />
                        <asp:HiddenField ID="hf3" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtEstado">
							        Estado
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control" readonly runat="server" id="txtEstado" name="txtEstado" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtMunicipio">
							        Municipio
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control" readonly runat="server" id="txtMunicipio" name="txtMunicipio" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="map" id="map1"></div>
                        </div>
					</div>	
				</div>
			</div>
		</div>
	</div>
      <!-- start: MAIN JAVASCRIPTS -->
		<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!-- end: MAIN JAVASCRIPTS -->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<script type="text/javascript" src="assets/js/table-data.js"></script>
    <script src="assets/js/form-validation2.js"></script>   
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>     
    <script src="assets/js/mapsSeccion.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        Maps.init();
	    });
	</script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cphScripts">
  
</asp:Content>