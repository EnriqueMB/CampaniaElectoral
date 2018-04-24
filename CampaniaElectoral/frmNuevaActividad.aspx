<%@ Page  Language="C#" ValidateRequest="false"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevaActividad.aspx.cs" Inherits="CampaniaElectoral.frmNuevaActividad" %>
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
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="cph_MasterBody_txtNombreEvento">
                            Nombre de la actividad<span class="symbol required"></span>             
                        </label>
                        <span class="input-icon">
                            <input type="text" class="form-control tooltips" runat="server" id="txtNombreActividad" name="txtNombreActividad" placeholder="" maxlength="150" data-original-title="Ingrese el nombre de la actividad." data-rel="tooltip"  title="" data-placement="top" />
                            <i class="fa fa-keyboard-o"></i>
                        </span>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <span class="input-icon">
                                <label class="control-label" for="cmbTipoActividad">
                                    Seleccione el tipo de actividad <span class="symbol required"></span>
                                </label>
                                <select id="cmbTipoActividad" name="cmbTipoActividad" class="form-control search-select" >
                                    <option value=""></option>
                                    <% foreach (var Item in ListaEventoAgenda)
                                       {
                                           Response.Write("<option value='" + Item.IDTipoEventoAgenda + "'>" + Item.Descripcion + "</option>");
                                       
                                       } %>
                                </select>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label" for="cmbEncargado">
                                Seleccione al encargado de la actividad <span class="symbol required"></span>
                            </label>
                            <select id="cmbEncargado" name="cmbEncargado" class="form-control search-select">
                                <option value=""></option>
                                <% foreach (var Item in ListaColaboradores)
                                   {
                                       Response.Write("<option value='" + Item.IDColaborador + "'>" + Item.Nombre + "</option>");
                                   } %>
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
                            <div class="input-group">
                                <input id="txtFechaInicio" name="txtFechaInicio" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly/>
                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="control-label" for="cph_MasterBody_txtHoraInicio">
                                Hora de inicio <span class="symbol required"></span>
                            </label>
                            <div class="input-group input-append bootstrap-timepicker">
                                <input id="txtHoraInicio" name="txtHoraInicio" runat="server" type="text" class="form-control time-picker" readonly/>
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
                                <input id="txtFechaTermino" name="txtFecheTermino" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker"/>
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
                                <input id="txtHoraTermino" name="txtHoraTermino" runat="server" type="text" class="form-control time-picker"/>
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
                            <textarea maxlength="200" id="txtObservaciones" name="txtObservaciones" runat="server" class="form-control limited"></textarea>
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
                                <input type="number" min="0" id="txtMeta" name="txtMeta" runat="server" class="form-control tooltips" data-placement="top" title="" data-original-title="Si la actividad no cuenta con meta cuantitativa deje este campo vacio" data-rel="tooltip"/>       
                                <i class="fa fa-bar-chart-o"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-6"></div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group">
                            <label class="control-label">
                                Mensaje al encargado
                            </label>
                            <textarea id="Check" runat="server" class="ckeditor form-control" cols="10" rows="10"></textarea>
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

                <div class="row ">
                    <%--<div class="col-md-12"></div>--%>
                    <div class="col-md-12">
                        <div class="form-group pull-right">
                            <div class="col-md-6">
                                <input type="submit" formaction="frmNuevaActividad.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                            </div>
                            <div class="col-md-6">
                                <a href="frmActividadesEventosGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
<!-- end: CORE JAVASCRIPTS  -->

<script>
    jQuery(document).ready(function() {
        FormValidator.init(12);
    });
</script>

</asp:Content>