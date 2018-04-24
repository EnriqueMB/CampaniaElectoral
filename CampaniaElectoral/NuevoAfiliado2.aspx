<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoAfiliado2.aspx.cs" Inherits="CampaniaElectoral.NuevoAfiliado2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Afiliado</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="errorHandler alert alert-danger no-display">
                                <i class="fa fa-times-sign"></i>Hay errores en la captura de información. Revise las especificaciones de los campos.
                            </div>
                            <div class="successHandler alert alert-success no-display">
                                <i class="fa fa-ok"></i>Your form validation is successful!
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtClavElector">
                                    Clave Elector <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtClavElector" name="txtClavElector" placeholder="" minlength="18" data-original-title="Ingrese la clave de elector." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombreAfiliado">
                                    Nombre<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombreAfiliado" name="txtNombreAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el nombre del afiliado." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApePatAfiliado">
                                    Apellido Paterno<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApePatAfiliado" name="txtApePatAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el apellido paterno del afiliado." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApeMatAfiliado">
                                    Apellido Materno<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApeMatAfiliado" name="txtApeMatAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el apellido materno del afiliado." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaAfiliacion">
                                    Fecha de afiliación <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-datepicker">
                                    <input id="txtFechaAfiliacion" name="txtFechaAfiliacion" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker"/>
                                    <span class="input-group-addon add-on"><i class="fa fa-calendar"></i></span>
                                </div>
                                <div class="input-group">
											<input type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker">
											<span class="input-group-addon"> <i class="fa fa-calendar"></i> </span>
										</div>
                                <div class="input-group">
                                     <span class="input-group-addon"> <i class="fa fa-calendar"></i> </span>
                                    <input type="text" id="fecha" class="form-control date-range" readonly style="cursor:pointer;">
                                    <span class="input-group-addon">
                                        <a href="#" onclick="javascript:SubminFecha()" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbSeccion">
                                    Sección <span class="symbol required"></span>
                                </label>
                                <select id="cmbSeccion" name="cmbSeccion" class="form-control">
                                    <% foreach (var Item in ListaSeccion)
                                       {
                                           Response.Write("<option value='" + Item.IDPoligono.ToString() + "'> " + Item.Nombre.ToString() +"("+Item.Seccion.ToString()+")"+ "</option>");
                                       }%>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbOperador">
                                    Operador político <span class="symbol required search-select"></span>
                                </label>
                                <select id="cmbOperador" name="cmbOperador" class="form-control">
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtDireccion">
                                    Dirección <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtDireccion" name="txtDireccion" placeholder="" maxlength="500" data-original-title="Ingrese la dirección." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtColonia">
                                    Colonia <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtColonia" name="txtColonia" placeholder="" maxlength="150" data-original-title="Ingrese la colonia." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNumeroExt">
                                    Número Exterior
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNumeroExt" name="txtNumeroExt" placeholder="" maxlength="5" data-original-title="Ingrese el número exterior." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNumeroInt">
                                    Número Interior
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNumeroInt" name="txtNumeroInt" placeholder="" maxlength="5" data-original-title="Ingrese el número interior." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtCodigoP">
                                    Código Postal<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtCodigoP" name="txtCodigoP" placeholder="" maxlength="5" data-original-title="Ingrese el código postal" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtCorreoElectronico">
                                    Correo Electrónico<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="email" class="form-control tooltips" runat="server" id="txtCorreoElectronico" name="txtCorreoElectronico" placeholder="" maxlength="200" data-original-title="Ingrese un correo electronico." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtCelular">
                                    Celular
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtCelular" name="txtCelular" placeholder="" minlength="10" maxlength="13" data-original-title="Ingrese un número de celular." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtGenero">
                                    Genero <span class="symbol required"></span>
                                </label>
                                <select class="form-control" id="txtGenero" name="txtGenero">
                                    <% foreach (var Item in ListaGeneros)
                                       {
                                           Response.Write("<option value='" + Item.IDGenero.ToString() + "'> " + Item.Descripcion.ToString() + "</option>");
                                       }%>
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
                                <span class="symbol required"></span>Campos Requeridos
                                <hr>
                            </div>
                        </div>
                    </div>
                    <div class="row ">
                        <%--<div class="col-md-12"></div>--%>
                        <div class="col-md-12">
                            <div class="form-group pull-right">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmNuevoAfiliado.aspx?op=1" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmAfiliadosGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
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
   <%-- <script src="assets/js/maps.js"></script>--%>
    <!-- end: CORE JAVASCRIPTS  -->
    <script>
        jQuery(document).ready(function () {
            FormValidator.init(26);
            $("#cmbSeccion").change(function () {
                $("#cmbSeccion option:selected").each(function () {
                    elegido = $(this).val();
                    $("#cmbOperador option").remove();
                    // Set the global configs to synchronous 
                    $.ajaxSetup({
                        async: false
                    });

                    // Your $.getJSON() request is now synchronous...
                    $.getJSON('sfrmOperadorPolitico.aspx?poligono=' + elegido, function (data) {
                        $.each(data, function (key, value) {
                            $("#cmbOperador").append('<option value="' + value.IDColaborador + '">' + value.Nombre + '</option>');
                        });
                    });
                    //var $example = $("#cmbMunicipio").select2({ placeholder: " -- Seleccione -- ", allowClear: false });
                    $("#cmbOperador").trigger('change.select2');
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