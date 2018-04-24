﻿<%@ Page Language="C#" Title="Cargar Banner" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLoadBanner.aspx.cs" Inherits="CampaniaElectoral.frmLoadBanner" %>

<asp:Content ID="Content01" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
		<div class="col-sm-12">
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title"> Agregar Banner <span class="text-bold">  </span></h4>
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
					    </div>
                    </div>
                   
                    <div class="row">   
                        <div class="col-md-6">
					        <div class="form-group">
						        <label class="control-label" for="cph_MasterBody_txtNombreInicial">
							       Texto inicial <span class="symbol required"></span>				
						        </label>
                                <input type="text" class="form-control tooltips" runat="server" id="txtNombreInicial" name="txtNombreInicial" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo del Banner" data-rel="tooltip"  title="" data-placement="top" />
                            </div>
					    </div>
                        <div class="col-md-6">
					        <div class="form-group">
						        <label class="control-label" for="cph_MasterBody_txtNombreBanner">
							        Texto principal<span class="symbol required"></span>
						        </label>
						        <input type="text" class="form-control tooltips" runat="server" id="txtNombreBanner" name="txtNombreBanner" placeholder="" maxlength="150" data-original-title="Ingrese el texto principal para el Banner. " data-rel="tooltip"  title="" data-placement="top" />
                            </div>
					    </div>
                    </div>
                   
                    <div class="row">   
                        <div class="col-md-6">
					        <div class="form-group">
						        <label class="control-label" for="cph_MasterBody_txtNombre">
							        T&iacute;tulo de la imagen <span class="symbol required"></span>				
						        </label>
                                <input type="text" class="form-control tooltips" runat="server" id="txtTitle" name="txtTitle" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip"  title="" data-placement="top" />
                            </div>
					    </div>
                        <div class="col-md-6">
					        <div class="form-group">
						        <label class="control-label" for="cph_MasterBody_txtNombre">
							        Texto alternativo (Alt) <span class="symbol required"></span>
						        </label>
						        <input type="text" class="form-control tooltips" runat="server" id="txtAlt" name="txtAlt" placeholder="" maxlength="150" data-original-title="Ingrese el texto alternativo. " data-rel="tooltip"  title="" data-placement="top" />
                            </div>
					    </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
							    <label for="cph_MasteBody_txtDescripcion">
								    Descripción de la imagen <span class="symbol required"></span>
							    </label>
							    <textarea maxlength="1000" id="txtDescripcion" runat="server" class="form-control limited"></textarea>
							</div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-lg-4">
                            <input type="checkbox" runat="server" name="txtverMas" id="txtverMas" value="0" >Ver más
                        </div>
                        <div class="col-lg-8"></div>
                    </div>
                   
                     <div class="row">
                       <div class="col-md-1"></div>
                        <div class="col-md-5" runat="server" id="mostrar"  style="display: none;"> 
                            <div class="form-group" >
							    <label for="cph_MasteBody_txtUrlBanner">
								    Url <span class="symbol required"></span>
							    </label>
							    <input type="text" class="form-control tooltips" runat="server" id="txtUrlBanner" name="txtUrlBanner" placeholder="" maxlength="150" data-original-title="Ingrese una Url para insertar al Banner. " data-rel="tooltip"  title="" data-placement="top" />
							</div>
                            <div class="form-group">
							    <label for="cph_MasteBody_txtButton">
								    Nombre para el botón del banner <span class="symbol required"></span>
							    </label>
							    <input type="text" class="form-control tooltips" runat="server" id="txtButton" name="txtButton" placeholder="" maxlength="150" data-original-title="Ingrese el nombre para el botón Banner. " data-rel="tooltip"  title="" data-placement="top" />
							</div>
                        </div>
                       
                         <div class="col-lg-5"></div>
                        
                        <div class="col-md-6">
                            <div class="form-group">
								<label class="control-label" >
									Fotografía a subir <span class="symbol required"></span>
								</label>
								<div class="fileupload fileupload-new" data-provides="fileupload">
									<div class="fileupload-new thumbnail">
                                        <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
									</div>                                            
									<div class="fileupload-preview fileupload-exists thumbnail"></div>
									<div>
										<span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i> Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                            <asp:FileUpload CssClass="fileupload" name="imgLogo" ID="imgLogo" runat="server" accept="image/jpeg" />
										</span>
										<a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
											<i class="fa fa-times"></i> Quitar
										</a>
									</div>
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
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
				                <div class="col-md-6">
                                    <input type="submit" formaction="frmLoadBanner.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmLoadBanner.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
        jQuery(document).ready(function () {
            FormValidator.init(36);
        });
	</script>


</asp:Content>