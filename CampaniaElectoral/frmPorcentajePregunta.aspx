<%@ Page Language="C#" Title="Porcentaje de preguntas" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPorcentajePregunta.aspx.cs" Inherits="CampaniaElectoral.frmPorcentajePregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Porcentaje de Pregunta</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                        <asp:HiddenField ID="hf3" runat="server" />
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
                                <label class="control-label" for="cph_MasterBody_txtOrden">
                                    Orden<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtOrden" name="txtOrden" placeholder="" data-original-title="Ingrese el orden del porcentaje" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtDescripcion">
                                   Descripcion<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtDescripcion" name="txtDescripcion" placeholder="" maxlength="80" data-original-title="Ingrese la descripción del porcentaje" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
					        <div class="form-group">
					            <label class="control-label" for="cph_MasterBody_txtColor">
					                Color del Porcentaje
					            </label>
					            <div class="input-group colorpicker-component" data-color="rgb(81, 145, 185)" data-color-format="hex" runat="server" id="PanelColor">
					                <span class="input-group-addon"><i></i></span>
					                <input type="text" value="" readonly class="form-control tooltips" runat="server" id="txtColor" name="txtColor"  maxlength="20" data-original-title="Ingrese el color del porcentaje" data-rel="tooltip"  title="" data-placement="top"/>
					            </div>
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
                                    <input type="submit" formaction="frmPorcentajePregunta.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <%Response.Write("<a href='frmPorcentajePreguntaGrid.aspx?op=5&id=" + IDPregunta.ToString() + "&id2=" + IDEncuesta.ToString() + "' class='btn btn-red btn-block' name='btnCancelar'> Cancelar</a>"); %>
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
        jQuery(document).ready(function () {
            FormValidator.init(29);
        });
    </script>

</asp:Content>