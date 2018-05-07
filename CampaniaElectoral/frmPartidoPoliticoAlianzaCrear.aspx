<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPartidoPoliticoAlianzaCrear.aspx.cs" Inherits="CampaniaElectoral.frmPartidoPoliticoAlianzaCrear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

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
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
					                <div class="form-group">
						                <label class="control-label" for="cph_MasterBody_txtNombre">
							                Nombre <span class="symbol required"></span>				
						                </label>
						                <span class="input-icon">
                                            <asp:TextBox ID="txtNombre" runat="server" class="form-control tooltips" data-original-title="Ingrese el nombre del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top" maxlength="150"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valNombre" runat="server" 
                                                ErrorMessage="Por favor, ingrese un nombre de la alianza." 
                                                ControlToValidate="txtNombre" 
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
							                <i class="fa fa-building-o"></i>
                                        </span>
                                    </div>
					            </div>
                            </div>                            
                            <div class="row">
                                <div class="col-md-12">
				                    <div class="form-group">
				                        <label class="control-label" for="cph_MasterBody_txtSigla">
						                    Sigla <span class="symbol required"></span>
					                    </label>
                                        <span class="input-icon">
                                            <asp:TextBox ID="txtSigla" runat="server" class="form-control tooltips" maxlength="10" data-original-title="Ingrese la sigla del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valSigla" runat="server" 
                                                ErrorMessage="Por favor, ingrese unas siglas para la alianza." 
                                                ControlToValidate="txtSigla" 
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
							                <i class="fa fa-file-text"></i>
                                        </span>
					                </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
								        <label class="control-label">
									        Logo de la alianza <span class="symbol required"></span>
								        </label>
								        <div class="fileupload fileupload-new" data-provides="fileupload">
									        <div class="fileupload-new thumbnail">
                                                <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
									        </div>                                            
									        <div class="fileupload-preview fileupload-exists thumbnail"></div>
									        <div>
										        <span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i> Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                                    <asp:FileUpload CssClass="fileupload form-control" name="imgLogo" accept=".png,.jpg,.jpeg" ID="imgLogo" runat="server" />
                                                    <asp:CustomValidator id="valLogo" runat="server" 
                                                      OnServerValidate="ValidarImagenExtension" 
                                                      ControlToValidate="imgLogo" 
                                                      ErrorMessage="Por favor, seleccione otra imagen, formato no válido.">
                                                    </asp:CustomValidator>
										        </span>
										        <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
											        <i class="fa fa-times"></i> Quitar
										        </a>
									        </div>
								        </div>
						            </div>                                    
                                </div>
                            </div>
                        </div>
                    </div>                    
                    <div class="row">
                        <div class="col-md-12" id="divPartidoPolitico" runat="server">
                            <div class="form-group">
                                <label class="control-label" for="cmbPartidosPoliticos">
                                    Partidos Políticos <span class="symbol required"></span>
                                </label>
                                <asp:ListBox SelectionMode="Multiple" ID="cmbPartidosPoliticos" runat="server"  class="form-control selectpicker" multiple data-live-search="true" data-none-selected-text="--Seleccione--"></asp:ListBox>
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
                                    <input type="submit" formaction="frmPartidoPoliticoAlianzaCrear.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmPartidosPoliticosAlianzasGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
                                </div>
					        </div>
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
	<script src="assets/js/form-validation2.js"></script>   
    <script src="assets/js/ui-notifications.js"></script>     
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
		<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
    <!--New Select-->
    <%--<script src="assets/plugins/bootstrap-select/bootstrap-select-new.js"></script>--%>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        //$('#cph_MasterBody_cmbPartidosPoliticos').selectpicker();
	        FormValidator.init(10);
		});
	</script>

</asp:Content>