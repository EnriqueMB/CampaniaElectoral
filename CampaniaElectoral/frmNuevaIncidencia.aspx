<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaIncidencia.aspx.cs" Inherits="CampaniaElectoral.frmNuevaIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Incidencias</span></h4>
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
                            <div class="form-group">
                                <label class="control-label" for="txtTitulo">
                                    T&iacute;tulo <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
									<input type="text" class="form-control tooltips" runat="server" id="txtTitulo" name="txtTitulo" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo del riesgo." data-rel="tooltip"  title="" data-placement="top" />
									<i class="fa fa-users"></i>
								</span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="txtDescripcion">
                                    Descripci&oacute;n <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <textarea maxlength="1500" id="txtDescripcion" runat="server" name="txtDescripcion" class="form-control limited"></textarea>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbTipoRiesgo">
                                    Tipo de riesgo <span class="symbol required"></span>
                                </label>
                                <select id="cmbTipoRiesgo" name="cmbTipoRiesgo" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemTR in Datos.ListaTipoRiesgos)
                                        {
                                            Response.Write("<option value='" + ItemTR.IDTipoRiesgo + "'> " + ItemTR.Descripcion + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbEstado">
                                    Estado <span class="symbol required"></span>
                                </label>
                                <select id="cmbEstado" name="cmbEstado" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemEstado in Datos.ListaEstados)
                                        {
                                            Response.Write("<option value='" + ItemEstado.IDEstado + "'> " + ItemEstado.EstadoDesc + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbMunicipio">
                                    Municipio <span class="symbol required"></span>
                                </label>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbPoligono">
                                    Casilla <span class="symbol required"></span>
                                </label>
                                <select id="cmbPoligono" name="cmbPoligono" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="map1">
                                    Seleccione un punto dentro del pol&iacute;gono <span class="symbol required"></span>
                                </label>
                                <input type="hidden" value="" id="hfLatitud" name="hfLatitud" />
                                <input type="hidden" value="" id="hfLongitud" name="hfLongitud" />
                                <div class="map" id="map1">
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
									<input type="submit" formaction="frmNuevaZonaRiesgo.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmZonasRiesgo.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
		<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!-- end: MAIN JAVASCRIPTS -->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="assets/js/form-validation2.js"></script>
	<script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
    <script src="assets/js/mapsNZonaRiesgo.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        FormValidator.init(35);
	        //if (document.getElementById('hfLatitud').value === '') {
	        //    Maps.init(1);
	        //    console.log("Inicializó en blanco");
	        //}
	        $("#cmbEstado").change(function () {
	            if (document.getElementById('hfLatitud').value === '') {
	                Maps.init(1);
	            }
	            $("#cmbEstado option:selected").each(function () {
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
	            elegido = $(this).val();
	            //console.log("Municipio elegido : " + elegido);
	            if (!(elegido === ''))
	                if (document.getElementById('hfLatitud').value === '') {
	                    Maps.init(1);
	                }
	            $("#cmbMunicipio option:selected").each(function () {
	                elegido = $(this).val();
	                estado = $('#cmbEstado').val();
	                $("#cmbPoligono option").remove();
	                $.ajaxSetup({
	                    async: false
	                });
	                //console.log("estado: " + estado + ", municipio: " + elegido);
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

	        $("#cmbPoligono").change(function () {
	            elegido = $(this).val();
	            //console.log("Poligono elegido : " + elegido);
	            if (!(elegido === ''))
	                if (document.getElementById('hfLatitud').value === '') {
	                    Maps.init(1);
	                }
	        });


	    });
	</script>
</asp:Content>