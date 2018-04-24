<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmTextoDonate.aspx.cs" Inherits="CampaniaElectoral.frmTextoDonate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
                            <div class="col-sm-12">
                                <!-- start: COLOR PICKER PANEL -->
                                <div class="panel panel-white">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><span class="text-bold">Textos Donate</span></h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <asp:HiddenField ID="hf" runat="server" />
                                            <%--<input type="hidden" id="hf" />--%>
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
                                                    <label class="control-label" for="cph_MasterBody_txtDonate">
                                                       Texto Descriptivo <span class="symbol required"></span>
                                                    </label>
                                                    <span class="input-icon">                                                        
                                                        <textarea style="max-width:100%" maxlength="1000" id="txtDon" runat="server" class="form-control limited"></textarea>
                                                        <i class="fa fa-users"></i>
                                                    </span>
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
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <div class="col-md-6">
                                                            <input type="submit" formaction="frmTextoDonate.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                                        </div>
                                                        <div class="col-md-6">
                                                            <a href="frmTextoDonateGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6"></div>
                                            </div>
                                    </div>
                                </div>
                                <!-- end: COLOR PICKER PANEL -->
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
        jQuery(document).ready(function () {
            FormValidator.init();
        });
    </script>
    </asp:Content>