<%@ Page Language="C#" Title="Catálogo de géneros" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGeneros.aspx.cs" Inherits="CampaniaElectoral.frmGeneros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    

    <div class="row">
        <div class="col-md-12">
        </div>
		<div class="col-sm-12">
			<!-- start: TEXT AREA PANEL -->
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Catálogo <span class="text-bold"> Géneros </span></h4>
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
						        <label class="control-label" for="cph_MasterBody_txtGenero">
							        Género <span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
							        <%--<asp:TextBox CssClass="form-control tooltips" TextMode="Search" ID="txtGenero" runat="server" data-original-title="Ingrese el género" data-rel="tooltip"  title="" data-placement="top"></asp:TextBox>--%>
                                    <input type="text" class="form-control tooltips" runat="server" id="txtGenero" name="txtGenero" data-original-title="Ingrese el género" data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-users"></i>
                                </span>
                                <%--<asp:RequiredFieldValidator ValidationGroup="CatGenero" ID="rfvGenero" ControlToValidate="txtGenero" Display="Static" ErrorMessage="* Campo requerido" runat="server"></asp:RequiredFieldValidator>--%>
                            </div>
					    </div>
                        <div class="col-md-6"></div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
				            <div class="form-group">
				                <label class="control-label" for="cph_MasterBody_txtLetra">
						            Letra <span class="symbol required"></span>
					            </label>
                                <span class="input-icon">
							        <%--<asp:TextBox CssClass="form-control tooltips" TextMode="Search" MaxLength="1" ID="txtLetra" runat="server" data-original-title="Ingrese una letra para hacer referencia al Género" data-rel="tooltip"  title="" data-placement="top"></asp:TextBox>--%>
                                    <input type="text" class="form-control tooltips" runat="server" id="txtLetra" name="txtLetra" placeholder="" maxlength="1" data-original-title="Ingrese una letra para hacer referencia al Género" data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-bold"></i>
                                   
                                </span>
                                <%--<asp:RequiredFieldValidator ValidationGroup="CatGenero" CssClass="error-details" ID="rfvAbreviatura" ControlToValidate="txtLetra" Display="Static" ErrorMessage="* Campo requerido" runat="server"></asp:RequiredFieldValidator>--%>
					        </div>
                        </div>
                        <div class="col-md-8"></div>
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
                                    <%--<asp:Button CssClass="btn btn-green btn-block" CausesValidation="true" ValidationGroup="CatGenero" ID="btnGuardar" runat="server" Text="Guardar" />--%>
                                    <input type="submit" formaction="frmGeneros.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                    <%--<button class="btn btn-green btn-block" type="submit">
										Guardar <i class="fa fa-arrow-circle-right"></i>
									</button>--%>
                                </div>
                                <div class="col-md-6">
                                    <%--<asp:Button CssClass="btn btn-red btn-block" CausesValidation="false" ID="btnCancelar" runat="server" Text="Cancelar" />--%>
                                    <a href="frmGenerosGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
			    FormValidator.init(1);
			});
		</script>

</asp:Content> 
    
