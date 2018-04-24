<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableViewState="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaPregunta.aspx.cs" Inherits="CampaniaElectoral.frmNuevaPregunta" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><i class="fa fa-edit"></i><span class="text-bold">Captura de pregunta</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="errorHandler alert alert-danger no-display">
                                <i class="fa fa-times-sign"></i>Hay errores en la captura de información. Revise las especificaciones de los campos.
                            </div>
                            <div class="successHandler alert alert-success no-display">
                                <i class="fa fa-ok"></i>La información se guardó correctamente
                            </div>
                        </div>
                        <div class="rows">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtPregunta">
                                        Pregunta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">

                                        <input type="text" class="form-control tooltips" runat="server" id="txtPregunta" name="txtPregunta" data-original-title="Ingrese la Pregunta" data-rel="tooltip" title="" data-placement="top" />

                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="rows">
                            <div class="col-md-10">
                                <div class="form-group">
                                    <span class="input-icon">
                                        <label class="control-label" for="cmb_TipoPregunta">
                                            Tipo de Pregunta <span class="symbol required"></span>
                                        </label>
                                        <select id="cmb_TipoPregunta" name="cmb_TipoPregunta" class="form-control search-select" data-original-title="Seleccione la Pregunta" data-rel="tooltip" title="" data-placement="top">
                                            <% foreach (var Item in Lista)
                                               {
                                                   Response.Write("<option value='" + Item.id_pregunta + "'>" + Item.descripcion.ToString() + "</option>");
                                               } %>
                                        </select>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtOrden">
                                        Orden de Pregunta <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="number" class="form-control tooltips" runat="server" id="txtOrden" name="txtOrden" placeholder="" minlength="1" data-original-title="Ingrese el orden de respuesta" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-6">
                                <input type="submit" formaction="frmNuevaPregunta.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                            </div>
                            <div class="col-md-6">
                                <%Response.Write("<a href='frmPreguntas.aspx?op=0&id=" + IDEncuesta.ToString() + "' class='btn btn-red btn-block' name='btnCancelar'> Cancelar</a>"); %>
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
        jQuery(document).ready(function () {
            FormValidator.init(15);
        });
    </script>
</asp:Content>

