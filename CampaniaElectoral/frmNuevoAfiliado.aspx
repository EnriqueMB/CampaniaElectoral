<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevoAfiliado.aspx.cs" Inherits="CampaniaElectoral.frmNuevoAfiliado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Afiliado</span></h4>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ValidationGroup="AllValidators" />
                    </div>
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
                                    <asp:RequiredFieldValidator ID="rfvClavElector" CssClass="text-danger serv" ControlToValidate="txtClavElector" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese la clave de elector" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="revClavElector" CssClass="text-danger serv" ControlToValidate="txtClavElector" runat="server" Display="Dynamic" ErrorMessage="Las direcciones de correo electrónico deben estar en el formato nombre@dominio.xyz" Text="* Formato no válido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
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
                                    <asp:RequiredFieldValidator ID="rfvNombreAfiliado" CssClass="text-danger serv" ControlToValidate="txtNombreAfiliado" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese el nombre del afiliado" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvApePatAfiliado" CssClass="text-danger serv" ControlToValidate="txtApePatAfiliado" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese el apellido paterno del afiliado." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvApeMatAfiliado" CssClass="text-danger serv" ControlToValidate="txtApeMatAfiliado" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese el apellido materno del afiliado." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvFechaAfiliacion" CssClass="text-danger serv" ControlToValidate="txtFechaAfiliacion" runat="server" Display="Dynamic" ErrorMessage="Por favor, selecciones un fecha de afiliaci&oacute;n." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <input id="txtFechaAfiliacion" name="txtFechaAfiliacion" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly="true"/>
                                    <span class="input-group-addon add-on"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbMunicipio">
                                    Municipio <span class="symbol required"></span>
                                </label>
                                <asp:RequiredFieldValidator ID="rfvMunicipio" CssClass="text-danger serv" ControlToValidate="cmbMunicipio" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un municipio." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvMunicipio" CssClass="text-danger serv" ControlToValidate="cmbMunicipio" OnServerValidate="cvMunicipio_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un municipio." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select" runat="server">
                                     <option value="" runat="server"></option>
                                    
                                    <% foreach (var Item in ListMunicipio)
                                       {
                                           Response.Write("<option runat='server' value='" + Item.IDMunicipio.ToString() + "'> " + Item.MunicipioDesc.ToString() + "</option>");
                                       }%>
                                </select>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <input type="text" class="form-control tooltips" runat="server" id="txtSeccion" name="txtSeccion" hidden="hidden" visible="false"/>
                        <input type="text" class="form-control tooltips" runat="server" id="txtOperador" name="txtOperador" hidden="hidden" visible="false"/>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbSeccion">
                                    Sección <span class="symbol required"></span>
                                </label>
                                <%--<asp:RequiredFieldValidator ID="rfvSeccion" CssClass="text-danger serv" ControlToValidate="txtSeccion" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione una seccion." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvSeccion" CssClass="text-danger serv" ControlToValidate="cmbSeccion" OnServerValidate="cvSeccion_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione una seccion." Text="* Seleccionar" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbSeccion" name="cmbSeccion" class="form-control search-select" runat="server">
                                    <option value=""></option>
                                </select>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbOperador">
                                    Operador político <span class="symbol required"></span>
                                </label>
                                <%--<asp:RequiredFieldValidator ID="rfvOperador" CssClass="text-danger serv" ControlToValidate="txtOperador" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un operador." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvOperador" CssClass="text-danger serv" ControlToValidate="cmbOperador" OnServerValidate="cvOperador_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un operador." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbOperador" name="cmbOperador" class="form-control search-select" runat="server">
                                     <option value="">&nbsp;</option>
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
                                    <asp:RequiredFieldValidator ID="rfvDireccion" CssClass="text-danger serv" ControlToValidate="txtDireccion" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese la direcci&oacute;n del afiliado." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvColonia" CssClass="text-danger serv" ControlToValidate="txtColonia" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese la colonia del afiliado." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvNumeroExt" CssClass="text-danger serv" ControlToValidate="txtNumeroExt" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese un n&uacute;mero exterior valido." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvNumeroInt" CssClass="text-danger serv" ControlToValidate="txtNumeroInt" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese un n&uacute;mero interior valido." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvCodigoP" CssClass="text-danger serv" ControlToValidate="txtCodigoP" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese un c&oacute;digo postal." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvCodigoP" CssClass="text-danger serv" ControlToValidate="txtCodigoP" OnServerValidate="cvCodigoP_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, introduzca al menos 4 caracteres." Text="* Caracteres Insuficientes" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvCorreoElectronico" CssClass="text-danger serv" ControlToValidate="txtCorreoElectronico" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese el correo electr&oacute;nico." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCorreoElectronico" CssClass="text-danger serv" ControlToValidate="txtCorreoElectronico" runat="server" Display="Dynamic" ErrorMessage="Las direcciones de correo electrónico deben estar en el formato nombre@dominio.xyz" Text="* Formato no válido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                                    <asp:RequiredFieldValidator ID="rfvCelular" CssClass="text-danger serv" ControlToValidate="txtCelular" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese un n&uacute;mero valido." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <input type="text" class="form-control tooltips" runat="server" id="txtCelular" name="txtCelular" placeholder="" minlength="10" maxlength="13" data-original-title="Ingrese un número de celular." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbGenero">
                                    Genero <span class="symbol required"></span>
                                </label>
                                    <asp:RequiredFieldValidator ID="rfvGenero" CssClass="text-danger serv" ControlToValidate="cmbGenero" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un genero." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvGenero" CssClass="text-danger serv" ControlToValidate="cmbGenero" OnServerValidate="cvGenero_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un genero." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select class="form-control search-select" id="cmbGenero" name="cmbGenero" runat="server">
                                     <option value=""></option>
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
                                    <a href="frmAfiliados.aspx?op=1" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
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
    <script src="assets/js/NuevoAfiliado.js"></script>
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <!-- start: CORE JAVASCRIPTS  -->
    <script src="assets/js/main.js"></script>
   <%-- <script src="assets/js/maps.js"></script>--%>
    <!-- end: CORE JAVASCRIPTS  -->
    <script>
        jQuery(document).ready(function() {
            NuevoAfiliado.init();
             $("#cph_MasterBody_cmbMunicipio").change(function () {
                $("#cph_MasterBody_cmbMunicipio option:selected").each(function () {
                    elegido = $(this).val();
                    $("#cph_MasterBody_cmbSeccion option").remove();
                    // Set the global configs to synchronous 
                    $.ajaxSetup({
                        async: false
                    });

                    // Your $.getJSON() request is now synchronous...
                    $.getJSON('sfrmSeccionesCmb.aspx?municipio=' + elegido, function (data) {
                        $.each(data, function (key, value) {
                            $("#cph_MasterBody_cmbSeccion").append('<option value="' + value.IDSeccion + '">' + value.seccionDesc + '</option>');
                        });
                    });
                    //var $example = $("#cmbMunicipio").select2({ placeholder: " -- Seleccione -- ", allowClear: false });
                    $("#cph_MasterBody_cmbSeccion").trigger('change.select2');
                    //$('#select2-chosen-3').text(' -- Seleccione -- ');


                    // Set the global configs back to asynchronous 
                    $.ajaxSetup({
                        async: true
                    });

                });
            });
            $("#cph_MasterBody_cmbSeccion").change(function () {
                $("#cph_MasterBody_cmbSeccion option:selected").each(function () {
                    elegido = $(this).val();
                    $("#cph_MasterBody_txtSeccion").val(elegido);
                    $("#cph_MasterBody_cmbOperador option").remove();
                    // Set the global configs to synchronous 
                    $.ajaxSetup({
                        async: false
                    });

                    // Your $.getJSON() request is now synchronous...
                    $.getJSON('sfrmOperadorPolitico.aspx?poligono=' + elegido, function (data) {
                        $.each(data, function (key, value) {
                            $("#cph_MasterBody_cmbOperador").append('<option value="' + value.IDColaborador + '">' + value.Nombre + '</option>');
                        });
                    });
                    //var $example = $("#cmbMunicipio").select2({ placeholder: " -- Seleccione -- ", allowClear: false });
                    $("#cph_MasterBody_cmbOperador").trigger('change.select2');
                    //$('#select2-chosen-3').text(' -- Seleccione -- ');


                    // Set the global configs back to asynchronous 
                    $.ajaxSetup({
                        async: true
                    });

                });
            });
            $("#cph_MasterBody_cmbOperador").change(function () {
                $("#cph_MasterBody_cmbOperador option:selected").each(function () {
                    elegido = $(this).val();
                    $("#cph_MasterBody_txtOperador").val(elegido);

                });
            });
        });
        //$(document).ready(function () {
        //    var now = new Date();

        //    var day = ("0" + now.getDate()).slice(-2);
        //    var month = ("0" + (now.getMonth() + 1)).slice(-2);

        //    var today = now.getFullYear() + "-" + (month) + "-" + (day);
        //    $('#cph_MasterBody_txtFechaAfiliacion').val(today);
        //});
    </script>
    </asp:Content>