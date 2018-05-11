<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPartidos.aspx.cs" Inherits="CampaniaElectoral.frmPartidos" %>

<asp:Content ID="Content01" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
		<div class="col-sm-12">
			<!-- start: TEXT AREA PANEL -->
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Cat&aacute;logo <span class="text-bold"> Partidos Pol&iacute;ticos </span></h4>
				</div>
				<div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
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
                    </div>

                    <div class="row">   
                             
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
					                <div class="form-group">
						                <label class="control-label" for="cph_MasterBody_txtNombre">
							                Nombre <span class="symbol required"></span>				
						                </label>
						                <span class="input-icon">
                                            <input type="text" class="form-control tooltips" runat="server" id="txtNombre" name="txtNombre" placeholder="" maxlength="150" data-original-title="Ingrese el nombre del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top" />
							                <i class="fa fa-building-o"></i>
                                        </span>
                                    </div>
					            </div>
                            </div>                            
                            <div class="row">
                                <div class="col-md-6">
				                    <div class="form-group">
				                        <label class="control-label" for="cph_MasterBody_txtSigla">
						                    Sigla <span class="symbol required"></span>
					                    </label>
                                        <span class="input-icon">
                                            <input type="text" class="form-control tooltips" runat="server" id="txtSigla" name="txtSigla" placeholder="" maxlength="10" data-original-title="Ingrese la sigla del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top" />
							                <i class="fa fa-file-text"></i>
                                        </span>
					                </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
				                    <div class="form-group">
				                        <label class="control-label" for="cph_MasterBody_txtColor">
						                    Color <span class="symbol required"></span>
					                    </label>
                                        <%--<div class="input-group colorpicker-component" data-color="#000000" data-color-format="hex" runat="server" id="panelColor">--%>
                                            <div class="input-group colorpicker-component" data-color="#000000" data-color-format="hex" runat="server" id="panelColor">    
                                            <%--<span class="input-append icon">--%>
									            <input type="text" value="" readonly class="form-control tooltips" id="txtColor" runat="server" data-original-title="Seleccione un color para identificar al partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top">
                                                <span class="input-group-addon">
                                                    <i></i>
                                                </span>
                                            <%--</span>--%>
								            </div>
                                        </div>
					                </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>

                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
								        <label class="control-label">
									        Logo del partido pol&iacute;tico <span class="symbol required"></span>
								        </label>
								        <div class="fileupload fileupload-new" data-provides="fileupload">
									        <div class="fileupload-new thumbnail">
                                                <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
									        </div>                                            
									        <div class="fileupload-preview fileupload-exists thumbnail"></div>
									        <div>
										        <span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i> Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
											        <%--<input type="file" class="fileupload" id="imgLogo" name="imgLogo" runat="server"/>--%>
                                                    <asp:FileUpload CssClass="fileupload" name="imgLogo" accept="png,jpg,jpeg,bmp" ID="imgLogo" runat="server" />
										        </span>
										        <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
											        <i class="fa fa-times"></i> Quitar
										        </a>
									        </div>
								        </div>
						            </div>                                    
                                </div>
                                <div class="col-md-6"></div>
                                <%--<div class="col-md-5 hidden" id="PanelImgActual" runat="server">
                                    <div class="form-group">
								        <label class="control-label">
									        Logo actual<span class="symbol required"></span>
								        </label>
                                        <div class="input-group">
                                            <div class="fileupload-new thumbnail">
                                                <img class="" src="assets/images/NoImage.png" alt="" id="Img1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
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
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
				                <div class="col-md-6">
                                    <input type="submit" formaction="frmPartidos.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmPartidosGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
                                </div>
					        </div>
                        </div>
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
			    FormValidator.init(10);
			});
		</script>


</asp:Content>