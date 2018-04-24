<%@ Page Language="C#" ValidateRequest="false" EnableViewState="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEncuestaPoligono.aspx.cs" Inherits="CampaniaElectoral.frmEncuestaPoligono" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Ubicaci&oacute;n</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hfIDPoligono" runat="server" />
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
                                <label class="control-label" for="cph_MasterBody_txtEncuesta">
                                   Folio de Encuesta
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtEncuesta" name="txtEncuesta" placeholder="" data-rel="tooltip" title="" data-placement="top" readonly="readonly" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtPoligono">
                                    Pol&iacute;gono
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtPoligono" name="txtPoligono" placeholder="" data-rel="tooltip" title="" data-placement="top" readonly="readonly" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtLatitud">
                                    Latitud<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtLatitud" name="txtLatitud" placeholder="" maxlength="100" data-original-title="Ingrese la latitud" data-rel="tooltip" title="" data-placement="top" readonly="readonly"/>
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtLongitud">
                                    Longitud<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtLongitud" name="txtLongitud" placeholder="" maxlength="100" data-original-title="Ingrese la longitud" data-rel="tooltip" title="" data-placement="top" readonly ="readonly" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="map" id="map1">
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
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <%--<input type="submit" formaction="frmNuevoEvento.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />--%>
                                    <input type="submit" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmRespuestaEncuestaGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
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
        <script src="assets/js/mapsEncuesta.js"></script>
		<!-- end: CORE JAVASCRIPTS  -->

        <script>
            jQuery(document).ready(function () {
                FormValidator.init(34);
            });
		</script>
</asp:Content>