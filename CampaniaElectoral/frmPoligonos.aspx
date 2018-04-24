<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPoligonos.aspx.cs" Inherits="CampaniaElectoral.frmPoligonos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
		<div class="col-sm-12">
		    <div class="panel panel-white">
				<div class="panel-heading">
					<h4 class="panel-title"><span class="text-bold">Polígonos</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                    </div>
                    <%-- Mensajes de Error --%>
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
                    <%-- Nombre y clave del polígono --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombrePoligono">
							        Nombre del pol&iacute;gono<span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombrePoligono" name="txtNombrePoligono" placeholder="" maxlength="150" data-original-title="Ingrese el nombre del pol&iacute;gono." data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombreEvento">
                                    Clave del pol&iacute;gono <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtClave" name="txtClave" placeholder="" maxlength="10" data-original-title="Ingrese la clave del pol&iacute;gono." data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <%-- Estado y municipio --%>
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
                                           Response.Write("<option value='" + Item.IDEstado.ToString() + "'> " + Item.EstadoDesc.ToString() + "</option>");
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
                    <%-- Colonia --%>
                    <div class="row">            
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtColonia">
							        Colonia<span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtColonia" name="txtColonia" placeholder="" maxlength="150" data-original-title="Ingrese una colonia" data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-map-marker"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    
                    <%-- Mapa --%>
                    <div class="row">
						<div class="col-md-12">
                            <%--<div class="form-group">
                                <label class="control-label" for="cph_MasterBody_address">
							        Ingrese una direcci&oacute;n y presione Buscar. Posteriormente, seleccione un punto en el mapa.<span class="symbol required"></span>
						        </label>
							    <div class="input-group">
								    <input type="text" class="form-control" runat="server" placeholder="" id="address" name="address" data-original-title="Ingrese la dirección del evento" data-rel="tooltip"  title="" data-placement="top">
								    <span class="input-group-btn">
									    <button id="btnSearchDir" class="btn btn-bricky" type="button">
										    Buscar
									    </button> 
								    </span>
							    </div>
						    </div>--%>
                            <%-- LAtitud y longitud --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label" for="cph_MasterBody_txtLatitud" >
                                            Latitud Inicial <span class="symbol required"></span>
                                        </label>
                                        <span class="input-icon">
                                            <input readonly type="text" class="form-control tooltips" runat="server" id="txtLatitud" name="txtLatitud" placeholder="" />
							                <i class="fa fa-map-marker"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label" for="cph_MasterBody_txtLongitud" >
                                            Longitud Inicial <span class="symbol required"></span>
                                        </label>
                                        <span class="input-icon">
                                            <input readonly type="text" class="form-control tooltips" runat="server" id="txtLongitud" name="txtLongitud" placeholder="" />
							                <i class="fa fa-map-marker"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="map" id="map1">
							</div>
						</div>
					</div>
                    <%-- Texto datos requeridos ** --%> 
                    <div class="row">
					    <div class="col-md-12">
						    <div>
							    <span class="symbol required"></span> Campos Requeridos
							    <hr>
						    </div>
					    </div>
				    </div>
                    <%-- Área de botones enviar o cancelar --%>
                    <div class="row ">
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
				                <div class="col-md-6">
                                    <input type="submit" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmPoligonosGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
        <%--<script src="assets/plugins/select2/select2.min.js"></script>--%>
		<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
		<script src="assets/js/form-validation2.js"></script>   
        <script src="assets/js/ui-notifications.js"></script>     
        <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
		<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
		<!-- start: CORE JAVASCRIPTS  -->
		<script src="assets/js/main.js"></script>
        <script src="assets/js/mapsPoligono.js"></script>
		<!-- end: CORE JAVASCRIPTS  -->

        <script>
			jQuery(document).ready(function() {
			    FormValidator.init(31);
			    if ((document.getElementById("cph_MasterBody_txtLongitud").value === ''))
			        Maps.init(true, 0, 0);
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
