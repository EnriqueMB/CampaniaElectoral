﻿<%@ Page Language="C#" Title="Catálogo de status Encuesta" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmStatusEncuesta.aspx.cs" Inherits="CampaniaElectoral.frmStatusEncuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
	<div class="row">
		<div class="col-md-12">
		</div>
		<div class="col-sm-12">
			<!-- start: TEXT AREA PANEL -->
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Catálogo <span class="text-bold"> Encuesta </span></h4>
				</div>
				<div class="panel-body">
					<div class="row">
						<asp:HiddenField ID="hf" runat="server" />
						<%--<input type="hidden" id="hf" />--%>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="errorHandler alert alert-danger no-display">
								<i class="fa fa-times-sign"></i> Hay errores en la captura de información. Revise las especificaciones de los campos.
							</div>
							<div class="successHandler alert alert-success no-display">
								<i class="fa fa-ok"></i> Your form validation is successful!
							</div>
						</div>
						<div class="col-md-6">
							<div class="form-group">
								<label class="control-label" for="cph_MasterBody_txtDesc">
									Estatus Encuesta <span class="symbol required"></span>
								</label>
								<span class="input-icon">
									<input type="text" class="form-control tooltips" runat="server" id="txtDesc" name="txtDesc" placeholder="" maxlength="150" data-original-title="Ingrese la descripción" data-rel="tooltip"  title="" data-placement="top" />
									<i class="fa fa-check-square"></i>
								</span>
							</div>
						</div>
						<div class="col-md-6">
							<div class="form-group">
								<label class="control-label" for="cph_MasterBody_txtStatus">
									Color Estatus
								</label>
								<div class="input-group colorpicker-component" data-color="rgb(81, 145, 185)" data-color-format="hex" runat="server" id="PanelColor">
								    <span class="input-group-addon"><i></i></span>
									<input type="text" value="" readonly class="form-control tooltips" runat="server" id="txtStatus" name="txtStatus"  maxlength="20" data-original-title="Ingrese el color del Status" data-rel="tooltip"  title="" data-placement="top"/>
								</div>
							</div>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div>
								<span class="symbol required"></span> Campos Requeridos
								<hr>
							</div>
						</div>
					</div>

					<div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<div class="col-md-6">
									<input type="submit" formaction="frmStatusEncuesta.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmStatusEncuestaGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
								</div>
							</div>
						</div>
						<div class="col-md-6"></div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- start: MAIN JAVASCRIPTS -->
	<!--[if lt IE 9]>
		<script src="assets/plugins/respond.min.js"></script>
		<script src="assets/plugins/excanvas.min.js"></script>
		<script type="text/javascript" src="assets/plugins/jQuery/jquery-1.11.1.min.js"></script>
	<![endif]-->
	<!--[if gte IE 9]><!-->
	<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!--<![endif]-->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<script src="assets/js/form-validation2.js"></script>
	<script src="assets/js/ui-notifications.js"></script>
	<script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
		jQuery(document).ready(function() {
			FormValidator.init(3);
		});
	</script>
</asp:Content>
