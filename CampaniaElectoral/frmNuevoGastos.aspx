<%@ Page Language="C#" Title="Nuevo Gasto" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoGastos.aspx.cs" Inherits="CampaniaElectoral.frmNuevoGastos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Gasto</span></h4>
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
                                <label class="control-label" for="cph_MasterBody_txtGastos">
                                    Titulo Gastos<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtGastos" name="txtGastos" placeholder="" maxlength="150" data-original-title="Ingrese el título del gasto" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtDescripcion">
                                   Descripción
                                </label>
                                <span class="input-icon">
                                    <textarea maxlength="500" id="txtDescripcion" runat="server" name="txtDescripcion" class="form-control limited"></textarea>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtMonto">
                                   Monto<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtMonto" name="txtMonto" placeholder="" data-original-title="Ingrese el monto correspondiente del gasto" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <%if(this.IDTipoUsuario == 1 || this.IDTipoUsuario == 3)
                          { %>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbEncargado">
                                    Seleccione el encargador del gasto<span class="symbol required"></span>
                                </label>
                                <select id="cmbEncargado" name="cmbEncargado" class="form-control search-select">
                                    <option value=""></option>
                                    <% foreach (var Item in ListaColaborador)
                                       {
                                           Response.Write("<option value='" + Item.IDColaborador + "'> " + Item.Nombre + "</option>");
                                       }%>
                                </select>
                            </div>
                        </div>
                        <%} 
                          else{%>
                        <div class="row">
                            <asp:HiddenField ID="hf2" runat="server" />
                            <asp:HiddenField ID="hf3" runat="server" />
                        </div>
                        <%} %>
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
                                    <input type="submit" formaction="frmNuevoGastos.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmGastosGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
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
            FormValidator.init(37);
        });
    </script>

</asp:Content>