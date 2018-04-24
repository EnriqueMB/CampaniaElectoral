<%@ Page Language="C#" ValidateRequest="false" EnableViewState="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoEvento.aspx.cs" Inherits="CampaniaElectoral.frmNuevoEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
		<div class="col-sm-12">
		    <div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title"><span class="text-bold">Eventos</span></h4>
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
                                <label class="control-label" for="cph_MasterBody_txtNombreEvento">
							        Nombre del evento<span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombreEvento" name="txtNombreEvento" placeholder="" maxlength="150" data-original-title="Ingrese el nombre de la actividad." data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbEncargado">
                                    Seleccione al encargado del evento <span class="symbol required"></span>
                                </label>
                                <select id="cmbEncargado" name="cmbEncargado" class="form-control search-select">
                                    <option value=""></option>
                                    <% foreach (var Item in ListaCol)
                                        {
                                            Response.Write("<option value='" + Item.IDColaborador + "'> " + Item.Nombre + "</option>");
                                        }%>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaInicio" >
                                    Fecha de inicio <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-datepicker">
                                    <input id="txtFechaInicio" name="txtFechaInicio" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon add-on"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaTermino">
                                    Fecha de t&eacute;rmino<span class="symbol required"></span>
                                </label>
                                <div class="input-group">
                                    <input id="txtFechaTermino" name="txtFecheTermino" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="cph_MasterBody_txtObservaciones">
                                    Observaciones
                                </label>
                                <textarea maxlength="1500" id="txtObservaciones" runat="server" name="txtObservaciones" class="form-control limited" ></textarea>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtMeta">
                                    Establecer Meta
                                </label>
                                <span class="input-icon">
                                    <input type="number" min="0" id="txtMeta" name="txtMeta" runat="server" class="form-control tooltips" data-placement="top" title="" data-original-title="Si la actividad no cuenta con meta cuantitativa deje este campo vacio" data-rel="tooltip">       
                                    <i class="fa fa-bar-chart-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6"></div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">
                                    Mensaje al encargado
                                </label>
                                <textarea name="txtMensaje" id="txtMensaje" runat="server" class="ckeditor form-control" cols="10" rows="10"></textarea>
                            </div>
                        </div>
                    </div>

                    <%-- Start Datos extra de Eventos --%>

                    <div class="row">            
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtTituloPagina">
							        T&iacute;tulo para p&aacute;gina<span class="symbol required"></span>
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloPagina" name="txtTituloPagina" placeholder="" maxlength="150" data-original-title="Ingrese el título de la página" data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">
                                    Texto para p&aacute;gina
                                </label>
                                <textarea name="txtTextoPagina" id="txtTextoPagina" runat="server" class="ckeditor form-control" cols="10" rows="10"></textarea>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaEvento" >
                                    Fecha de evento <span class="symbol required"></span>
                                </label>
                                <div class="input-group">
                                    <input id="txtFechaEvento" name="txtFechaEvento" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtHoraEvento">
                                    Hora de evento <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-timepicker">
                                    <input id="txtHoraEvento" name="txtHoraEvento" runat="server" type="text" class="form-control time-picker" readonly>
                                    <span class="input-group-addon add-on"><i class="fa fa-clock-o"></i></span>       
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                             <div class="form-group">
                                <label class="control-label" for="cmbEstado">
                                    Estado <span class="symbol required"></span>
                                </label>
                                <select id="cmbEstado" name="cmbEstado" class="form-control search-select">
                                    <option value=""></option>
                                    <% foreach (var Item in ListaEstado)
                                        {
                                            Response.Write("<option value='" + Item.IDEstado + "'> " + Item.EstadoDesc + "</option>");
                                        }%>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbMunicipio">
                                    Municipio <span class="symbol required"></span>
                                </label>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select" >
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <%--<div class="row">            
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombreEvento">
							        Direcci&oacute;n<span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtDireccion" name="txtDireccion" placeholder="" maxlength="150" data-original-title="Ingrese la dirección del evento" data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-location-arrow"></i>
                                </span>
                            </div>
                        </div>
                    </div>--%>

                    <!-- start: BASIC MAP PANEL -->
<%--							<div class="panel panel-white">
								<div class="panel-heading">
									<h4 class="panel-title">Basic <span class="text-bold">Map</span></h4>
								</div>
								<div class="panel-body">
									<div class="map" id="map1"></div>
								</div>
							</div>--%>
							<!-- end: BASIC MAP PANEL -->


                    <div class="row">
						<div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_address">
							        Ingrese la direcci&oacute;n del evento y presione Buscar. Posteriormente, seleccione un punto en el mapa.<span class="symbol required"></span>				
						        </label>
							    <div class="input-group">
								    <input type="text" class="form-control" runat="server" placeholder="" id="address" name="address" data-original-title="Ingrese la dirección del evento" data-rel="tooltip"  title="" data-placement="top">                                    
                                    <input type="hidden" name="hfLatitud" id="hfLatitud" runat="server">
                                    <input type="hidden" name="hfLongitud" id="hfLongitud" runat="server">
								    <span class="input-group-btn">
									    <button id="btnSearchDir" class="btn btn-bricky" type="button">
										    Buscar
									    </button> 
								    </span>
							    </div>
						    </div>
                            <div class="map" id="map1">
							</div>
						</div>
					</div>

                                        
                    <div class="row">            
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input name="chkPublicar" id="chkPublicar" runat="server" type="checkbox" class="flat-grey" value="">
                                       ¿Se publicar&aacute; en la p&aacute;gina Web?
							    </label>
                            </div>
                        </div>
                    </div>



                    <%-- End Datos extra de Eventos --%>

                    <div class="row">
					    <div class="col-md-12">
						    <div>
							    <span class="symbol required"></span> Campos Requeridos
							    <hr>
						    </div>
					    </div>
				    </div>

                    <div class="row ">
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
				                <div class="col-md-6">
                                    <%--<input type="submit" formaction="frmNuevoEvento.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />--%>
                                    <input type="submit" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
        <script src="assets/js/maps.js"></script>
		<!-- end: CORE JAVASCRIPTS  -->

        <script>
			jQuery(document).ready(function() {
			    FormValidator.init(11);
			    Maps.init();
			    $("#cmbEstado").change(function () {
			        $("#cmbEstado option:selected").each(function () {
			            elegido = $(this).val();
			            $("#cmbMunicipio option").remove();
			            // Set the global configs to synchronous 
			            $.ajaxSetup({
			                async: false
			            });

			            // Your $.getJSON() request is now synchronous...
			            $.getJSON('sfrmMunicipios.aspx?estado=' + elegido, function (data) {
			                $("#cmbMunicipio").append('<option value="">&nbsp;</option>');
			                $.each(data, function (key, value) {
			                    $("#cmbMunicipio").append('<option value="' + value.IDMunicipio + '">' + value.Descripcion + '</option>');
			                });
			            });
			            //var $example = $("#cmbMunicipio").select2({ placeholder: " -- Seleccione -- ", allowClear: false });
			            $("#cmbMunicipio").trigger('change.select2');
			            //$('#select2-chosen-3').text(' -- Seleccione -- ');


			            // Set the global configs back to asynchronous 
			            $.ajaxSetup({
			                async: true
			            });

			        });
			    });
			});
		</script>

    

</asp:Content>
