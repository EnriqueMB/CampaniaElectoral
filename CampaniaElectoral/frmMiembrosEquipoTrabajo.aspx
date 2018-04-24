<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMiembrosEquipoTrabajo.aspx.cs" Inherits="CampaniaElectoral.frmMiembrosEquipoTrabajo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-sm-12">
            <!-- start: TEXT AREA PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title">Catálogo <span class="text-bold">Miembros del equipo </span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <%--<input type="hidden" id="hf" />--%>
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombre">
                                    Nombre <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombre" name="txtNombre" placeholder="" maxlength="80" data-original-title="Ingrese el nombre" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApePat">
                                    Apellido Paterno <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApePat" name="txtApePat" placeholder="" maxlength="70" data-original-title="Ingrese el apellido paterno" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApeMat">
                                    Apellido Materno <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApeMat" name="txtApeMat" placeholder="" maxlength="70" data-original-title="Ingrese el apellido materno" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtOcupacion">
                                    Puesto <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtOcupacion" name="txtOcupacion" placeholder="" maxlength="100" data-original-title="Ingrese el puesto" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtPagWeb">
                                    Pagina Web <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtPagWeb" name="txtPagWeb" placeholder="" maxlength="150" data-original-title="Ingrese la pagina web del colaborador" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-users"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row-6">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline" >                                    
                                    <input type="checkbox" value="true"  id="ckfb" name="ckfb">
                                    Facebook
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <span class="input-icon">
                                <input disabled type="text" class="form-control tooltips" runat="server" id="txtfb" name="txtfb" placeholder="" maxlength="70" data-original-title="Ingrese el perfil de facebook" data-rel="tooltip" title="" data-placement="top" />
                                <i class="fa fa-facebook"></i>
                            </span>
                        </div>
                    </div>
                    <div class="row-6">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" value="true"  id="cktw" name="cktw">
                                    Twitter
                                </label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <span class="input-icon">
                                    <input disabled type="text" class="form-control tooltips" runat="server" id="txtTw" name="txtTw" placeholder="" maxlength="70" data-original-title="Ingrese el perfil de Twitter" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-twitter"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row-6">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" value="true"  id="ckgo" name="ckgo">
                                    Google +
                                </label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <span class="input-icon">
                                    <input  value=" " disabled type="text" class="form-control tooltips" runat="server" id="txtGo" name="txtGo" placeholder="" maxlength="70" data-original-title="Ingrese el perfil de Google +" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-google-plus"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row-6">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" value="true"  id="ckIns" name="ckIns">
                                    Instagram
                                </label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <span class="input-icon">
                                    <input value=" " disabled type="text" class="form-control tooltips" runat="server" id="txtIns" name="txtIns" placeholder="" maxlength="70" data-original-title="Ingrese el perfil de Instagram +" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-instagram"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row-6">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <input type="checkbox" value="true"  id="ckPri" name="ckPri">
                                    Pinterest
                                </label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <span class="input-icon">
                                    <input value=" " disabled type="text" class="form-control tooltips" runat="server" id="txtPri" name="txtPri" placeholder="" maxlength="70" data-original-title="Ingrese el perfil de Pinterest +" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-pinterest"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">
                                    Foto <span class="symbol required"></span>
                                </label>
                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                    <div class="fileupload-new thumbnail">
                                        <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
                                    </div>
                                    <div class="fileupload-preview fileupload-exists thumbnail"></div>
                                    <div>
                                        <span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i>Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                            <%--<input type="file" class="fileupload" id="imgLogo" name="imgLogo" runat="server"/>--%>
                                            <asp:FileUpload CssClass="fileupload" name="imgImagen" ID="imgImagen" runat="server" />
                                        </span>
                                        <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
                                            <i class="fa fa-times"></i>Quitar
                                        </a>
                                    </div>
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

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmMiembrosEquipoTrabajo.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmGradoEstudiosGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6"></div>
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
            FormValidator.init(35);
        });

        $('#ckfb').on('click', function () {
            if (document.getElementById("ckfb").checked) {
                document.getElementById("cph_MasterBody_txtfb").disabled = false;
            }
            else {
                document.getElementById("cph_MasterBody_txtfb").disabled = true;
            }
        });
        $('#cktw').on('click', function () {
            if (document.getElementById("cktw").checked) {
                document.getElementById("cph_MasterBody_txtTw").disabled = false;
            }
            else {
                document.getElementById("cph_MasterBody_txtTw").disabled = true;
            }
        });
        $('#ckgo').on('click', function () {
            if (document.getElementById("ckgo").checked) {
                document.getElementById("cph_MasterBody_txtGo").disabled = false;
            }
            else {
                document.getElementById("cph_MasterBody_txtGo").disabled = true;
            }
        });
        $('#ckIns').on('click', function () {
            if (document.getElementById("ckIns").checked) {
                document.getElementById("cph_MasterBody_txtIns").disabled = false;
            }
            else {
                document.getElementById("cph_MasterBody_txtIns").disabled = true;
            }
        });
        $('#ckPri').on('click', function () {
            if (document.getElementById("ckPri").checked) {
                document.getElementById("cph_MasterBody_txtPri").disabled = false;
            }
            else {
                document.getElementById("cph_MasterBody_txtPri").disabled = true;                
            }
        });


    </script>


</asp:Content>
