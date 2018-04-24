<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaRespuesta.aspx.cs" Inherits="CampaniaElectoral.frmNuevaRespuesta" %>
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cmbEncuesta">
                                    Encuesta <span class="symbol required"></span>
                                </label>
                                <select id="cmbEncuestas" name="cmbEncuestas" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemEncuesta in DatosEncuesta.ListaEncuestas)
                                        {
                                            Response.Write("<option value='" + ItemEncuesta.IDEncuesta + "'> " + ItemEncuesta.EncuestaDesc + "</option>");
                                        } %>
                                </select>
                            </div>
						</div>
					</div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaInicio">
                                    Fecha de Encuesta <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-datepicker">
                                    <input id="txtFechaEncuesta" name="txtFechaEncuesta" runat="server" type="text" data-date-format="dd-mm-yyyy" placeholder="DD/MM/YYYY" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon add-on"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtHoraInicio">
                                    Hora de inicio <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-timepicker">
                                    <input id="txtHoraInicio" runat="server" name="txtHoraInicio" type="text" class="form-control time-picker" readonly>
                                    <span class="input-group-addon add-on"><i class="fa fa-clock-o"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtHoraTermino">
                                    Hora de t&eacute;rmino<span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-timepicker">
                                    <input id="txtHoraTermino" name="txtHoraTermino" runat="server" type="text" class="form-control time-picker">
                                    <span class="input-group-addon add-on"><i class="fa fa-clock-o"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cmbEstados">
                                    Estado <span class="symbol required"></span>
                                </label>
                                <select id="cmbEstados" name="cmbEstados" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemEstado in DatosEncuesta.ListaEstados)
                                        {
                                            Response.Write("<option value='" + ItemEstado.IDEstado + "'> " + ItemEstado.EstadoDesc + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cmbMunicipio">
                                    Municipio <span class="symbol required"></span>
                                </label>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cmbPoligono">
                                    Pol&iacute;gono <span class="symbol required"></span>
                                </label>
                                <select id="cmbPoligono" name="cmbPoligono" class="form-control search-select">
                                    <option value="">&nbsp</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
							<div class="form-group">
								<label class="control-label" for="cph_MasterBody_txtNomEntrevistado">
									Nombre del entrevistado <span class="symbol required"></span>				
								</label>
								<span class="input-icon">
									<input type="text" class="form-control tooltips" runat="server" id="txtNomEntrevistado" name="txtNomEntrevistado" placeholder="" maxlength="150" data-original-title="Ingrese el nombre del entrevistado" data-rel="tooltip"  title="" data-placement="top" />
									<i class="fa fa-users"></i>
								</span>
							</div>
						</div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApPaterno">
                                    Apellido paterno del entrevistado <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApPaterno" name="txtApPaterno" placeholder="" maxlength="150" data-original-title="Ingrese el apellido paterno del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApMaterno">
                                   Apellido materno de entrevistado
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApMaterno" name="txtApMaterno" placeholder="" maxlength="150" data-original-title="Ingrese el apellido materno del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtEdad">
                                    Edad<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtEdad" name="txtEdad" placeholder="" maxlength="3" data-original-title="Ingrese la edad del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtHabColonia">
                                    Años de habitar en su colonia<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtHabColonia" name="txtHabColonia" placeholder="" maxlength="3" data-original-title="Ingrese los años de habitar en su colonia" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cmbGenero">
                                    Genero <span class="symbol required"></span>
                                </label>
                                <select id="cmbGenero" name="cmbGenero" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemGenero in DatosEncuesta.ListaGeneros)
                                        {
                                            Response.Write("<option value='" + ItemGenero.IDGenero + "'> " + ItemGenero.Descripcion + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cmbGradoEstudio">
                                    Grado de Estudio <span class="symbol required"></span>
                                </label>
                                <select id="cmbGradoEstudio" name="cmbGradoEstudio" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemGradoEstudio in DatosEncuesta.ListaGradosEstudio)
                                        {
                                            Response.Write("<option value='" + ItemGradoEstudio.IDGradoEstudio + "'> " + ItemGradoEstudio.GradoEstudioDesc + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtDireccion">
                                    Dirección <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtDireccion" name="txtDireccion" placeholder="" maxlength="150" data-original-title="Ingrese la dirección." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbEntrevistador">
                                    Entrevistador <span class="symbol required"></span>
                                </label>
                                <select id="cmbEntrevistador" name="cmbEntrevistador" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemEntrevistador in DatosEncuesta.ListaEntrevistador)
                                        {
                                            Response.Write("<option value='" + ItemEntrevistador.IDColaborador + "'> " + ItemEntrevistador.Nombre + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbSupervisor">
                                   Supervisor <span class="symbol required"></span>
                                </label>
                                <select id="cmbSupervisor" name="cmbSupervisor" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemEntrevistador in DatosEncuesta.ListaSupervisor)
                                        {
                                            Response.Write("<option value='" + ItemEntrevistador.IDColaborador + "'> " + ItemEntrevistador.Nombre + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtObservaciones">
                                    Observaciones
                                </label>
                                <span class="input-icon">
                                    <textarea maxlength="1500" id="txtObservaciones" runat="server" name="txtObservaciones" class="form-control limited"></textarea>
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
									<input type="submit" formaction="frmNuevaRespuesta.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmRespuestaEncuestaGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
	        FormValidator.init(33);
	        $("#cmbEstados").change(function () {
	            $("#cmbEstados option:selected").each(function () {
	                elegido = $(this).val();
	                $("#cmbMunicipio option").remove();
	                $.ajaxSetup({
	                    async: false
	                });

	                $.getJSON('sfrmMunicipios.aspx?estado=' + elegido, function (data) {
	                    $("#cmbMunicipio").append('<option value="">&nbsp;</option>');
	                    $.each(data, function (key, value) {
	                        $("#cmbMunicipio").append('<option value="' + value.IDMunicipio + '">' + value.Descripcion + '</option>');
	                    });
	                });
	                $("#cmbMunicipio").trigger('change');
	                $("#cmbPoligono").trigger('change.select2');
	                // Set the global configs back to asynchronous 
	                $.ajaxSetup({
	                    async: true
	                });
	            })
	        });
	        $("#cmbMunicipio").change(function () {
	            $("#cmbMunicipio option:selected").each(function () {
	                elegido = $(this).val();
	                estado = $('#cmbEstados').val();
	                $("#cmbPoligono option").remove();
	                $.ajaxSetup({
	                    async: false
	                });
	                console.log("estado: " + estado + ", municipio: " + elegido);
	                $.getJSON('sfrmPoligonos.aspx?estado=' + estado + '&municipio=' + elegido, function (data) {
	                    $("#cmbPoligono").append('<option value="">&nbsp;</option>');
	                    $.each(data, function (key, value) {
	                        $("#cmbPoligono").append('<option value="' + value.IDPoligono + '">' + value.Descripcion + '</option>');
	                    });
	                });
	                $("#cmbPoligono").trigger('change.select2');
	                // Set the global configs back to asynchronous 
	                $.ajaxSetup({
	                    async: true
	                });
	            })
	        });
	    });
      </script>
	</asp:Content>