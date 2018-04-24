<%@ Page Language="C#" Title="" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="frmProyectoCampania.aspx.cs" Inherits="CampaniaElectoral.WebForm4" %>
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
                        <label class="control-label" for="cph_MasterBody_txtNombreProyecto">
                            Titulo de la propuesta<span class="symbol required"></span>             
                        </label>
                        <span class="input-icon">
                            <input type="text" class="form-control tooltips" runat="server" id="txtNombreProyecto" name="txtNombreProyecto" placeholder="" maxlength="300" data-original-title="Ingrese el nombre de la propuesta." data-rel="tooltip"  title="" data-placement="top" />
                            <i class="fa fa-keyboard-o"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="cph_MasteBody_txtProy1">
                            Propuesta Parte 1 <span class="symbol required"></span>
                        </label>
                        <textarea style="max-width: 100%" maxlength="800" id="txtProy1" name="txtProy1" runat="server" class="form-control limited"></textarea>
                    </div>
                </div> 
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="cph_MasteBody_txtProy2">
                            Propuesta Parte 2 <span class="symbol required"></span>
                        </label>
                        <textarea style="max-width: 100%"  maxlength="500" id="txtProy2" name="txtProy2" runat="server" class="form-control limited"></textarea>
                    </div>
                </div> 
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="cph_MasteBody_txtProy3">
                            Propuesta Parte 3 <span class="symbol required"></span>
                        </label>
                        <textarea style="max-width: 100%" maxlength="500" id="txtProy3" name="txtProy3" runat="server" class="form-control limited"></textarea>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="form-group">
                        <label for="cph_MasteBody_txtPropP">
                           Pie de Pagina <span class="symbol required"></span>
                        </label>
                        <textarea style="max-width: 100%" maxlength="450" id="txtPropP" name="txtPropP" runat="server" class="form-control limited"></textarea>
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
                                <input type="submit" formaction="frmProyectoCampania.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                            </div>
                            <div class="col-md-6">
                                <a href="frmViewProyectoCampania.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
        FormValidator.init(43);
    });
</script>

</asp:Content>
