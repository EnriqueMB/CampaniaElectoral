<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNotificaciones.aspx.cs" Inherits="CampaniaElectoral.frmNotificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
	<div class="row">
		<div class="col-md-12">
		</div>
		<div class="col-sm-12">
			<!-- start: TEXT AREA PANEL -->
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Nueva <span class="text-bold"> Notificaci&oacute;n </span></h4>
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
                        <div class="col-md-9">
                            <div class="form-group">
                                <label class="control-label" for="cmbColaborador">
                                    Colaborador <span class="symbol required"></span>
                                </label>                                                                         
                                <select multiple="multiple"  id="cmbColaborador" name="cmbColaborador" class="form-control search-select js-example-disabled-multi Multiselector">
                                    <option value="">&nbsp;</option>
                                <% foreach (var TipoUser in DatosGlobales.DatosAuxColab.ListaUsers)
                                    {
                                        Response.Write("<optgroup label='" + TipoUser.Descripcion + "'>");

                                        foreach(var ItemColab in DatosGlobales.DatosAuxColab.ListaColaboradores.Where(x => x.IDTipoUsuario == TipoUser.IDTUsuario ))
                                        {
                                            if (ItemColab.Seleccionado)
                                                Response.Write("<option selected='selected' value='" + ItemColab.IDColaborador + "'>" + ItemColab.Nombre+ "</option>");
                                            else
                                                Response.Write("<option value='" + ItemColab.IDColaborador + "'>" + ItemColab.Nombre+ "</option>");
                                        }
                                        Response.Write("</optgroup>");
                                    } %>

                                </select>
                            </div>
						</div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline" style="vertical-align:middle;">
									<input name="chkTodos" id="chkTodos" type="checkbox" value="false" class="grey checkbox-callback">
									Enviar a todos
								</label>
                            </div>
                        </div>
					</div>
                    <div class="row">
                        <div class="col-md-12">
							    <div class="form-group">
								    <label class="control-label" for="cph_MasterBody_txtNombre">
									    Nombre de la notificaci&oacute;n <span class="symbol required"></span>
								    </label>
								    <span class="input-icon">
									    <input type="text" class="form-control tooltips" runat="server" id="txtNombre" name="txtNombre" placeholder="" maxlength="150" data-original-title="Ingrese el nombre de la notificaci&oacute;n" data-rel="tooltip"  title="" data-placement="top" />
									    <i class="fa fa-text-height"></i>
								    </span>
							    </div>
						    </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
							<div class="form-group">
								<label class="control-label" for="cph_MasterBody_txtTitulo">
									T&iacute;tulo de la notificaci&oacute;n <span class="symbol required"></span>
								</label>
								<span class="input-icon">
									<input type="text" class="form-control tooltips" runat="server" id="txtTitulo" name="txtTitulo" placeholder="" maxlength="180" data-original-title="Ingrese el t&iacute;tulo de la notificaci&oacute;n" data-rel="tooltip"  title="" data-placement="top" />
									<i class="fa fa-text-height"></i>
								</span>
							</div>
						</div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtTexto">
                                    Texto a enviar <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <textarea maxlength="1024" id="txtTexto" runat="server" name="txtTexto" class="form-control limited"></textarea>
                                </span>
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
									<input type="submit" formaction="frmNotificaciones.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmNotificacionGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
	        FormValidator.init(45);
	        
	    });
      </script>
	</asp:Content>