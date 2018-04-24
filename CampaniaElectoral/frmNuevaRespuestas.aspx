<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaRespuestas.aspx.cs" Inherits="CampaniaElectoral.frmNuevaRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
	<div class="row">
		<div class="col-md-12">
		</div>
		<div class="col-sm-12">
			<!-- start: TEXT AREA PANEL -->
			<div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title">Nueva <span class="text-bold"> Respuesta </span></h4>
				</div>
				<div class="panel-body">
					<div class="row">
						<asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                        <asp:HiddenField ID="hf3" runat="server" />
                        <asp:HiddenField ID="hf4" runat="server" />
						<%--<input type="hidden" id="hf" />--%>
					</div>
                    <%if(IDTipoPregunta == 1)
                      { %>
					<div class="row">
						<div class="col-md-12">
							<div class="errorHandler alert alert-danger no-display">
								<i class="fa fa-times-sign"></i> Hay errores en la captura de información. Revise las especificaciones de los campos.
							</div>
							<div class="successHandler alert alert-success no-display">
								<i class="fa fa-ok"></i> Your form validation is successful!
							</div>
						</div>
                        <div class="rows">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtClaveRespuesta">
                                        Clave Respuesta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtClaveRespuesta" name="txtClaveRespuesta" placeholder="" maxlength="5" data-original-title="Escriba la clave de respuesta( A), B) )" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-users"></i>
                                    </span>
                                </div>
                            </div>
                             <div class="col-md-10">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtRespuesta">
                                        Respuesta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtRespuesta" name="txtRespuesta" placeholder="" maxlength="150" data-original-title="Ingrese la respuesta" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-users"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class ="rows">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtOrden">
                                        Orden de Respuesta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="number" class="form-control tooltips" runat="server" id="txtOrden" name="txtOrden" placeholder="" minlength="1" data-original-title="Ingrese el orden de respuesta" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="control-label" for="CmbGrafica">
                                        ¿Esta respuesta grafica? <span class="symbol required"></span>
                                    </label>
                                    <select id="CmbGrafica" name="CmbGrafica" class="form-control search-select">
                                        <option value="false">No</option>
                                        <option value="true">Si</option>
                                    </select>
                                </div>
                            </div>
                        </div>
					</div>
                    <%} else
                      { %>
                    <div class="row">
						<div class="col-md-12">
							<div class="errorHandler alert alert-danger no-display">
								<i class="fa fa-times-sign"></i> Hay errores en la captura de información. Revise las especificaciones de los campos.
							</div>
							<div class="successHandler alert alert-success no-display">
								<i class="fa fa-ok"></i> Your form validation is successful!
							</div>
						</div>
                        <div class="rows">
                             <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtRespuestas">
                                        Respuesta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtRespuestas" name="txtRespuestas" placeholder="" maxlength="150" data-original-title="Ingrese la respuesta" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-users"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class ="rows">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtOrdens">
                                        Orden de Respuesta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="number" class="form-control tooltips" runat="server" id="txtOrdens" name="txtOrdens" placeholder="" minlength="1" data-original-title="Ingrese el orden de respuesta" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="control-label" for="CmbGraficas">
                                        ¿Esta respuesta grafica? <span class="symbol required"></span>
                                    </label>
                                    <select id="CmbGraficas" name="CmbGraficas" class="form-control search-select">
                                        <option value="false">No</option>
                                        <option value="true">Si</option>
                                    </select>
                                </div>
                            </div>
                        </div>
					</div>
                    <%} %>
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
									<input type="submit" formaction="frmNuevaRespuestas.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
                                     <%Response.Write("<a href='frmNuevaRespuestaGrid.aspx?op=0&id=" + IDPregunta.ToString() + "&id2=" + IDEncuesta.ToString() + "&id3=" + IDTipoPregunta + "' class='btn btn-red btn-block' name='btnCancelar'> Cancelar</a>"); %>
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
	<%if(IDTipoPregunta == 1) 
   {%>
    <script>
		jQuery(document).ready(function() {
			FormValidator.init(16);
		});
	</script>
    <%}
      else
      { %>
    <script>
        jQuery(document).ready(function () {
            FormValidator.init(18);
        });
	</script>
    <%} %>
	</asp:Content>