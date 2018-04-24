<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoAuxiliar.aspx.cs" Inherits="CampaniaElectoral.frmNuevoAuxiliar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
        <div class="col-md-12">
        </div>
        <div class="col-sd-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Auxiliar </span></h4>
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
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombre">
                                    Nombre(s) <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombre" name="txtNombre" maxlength="80" data-original-title="Ingrese el nombre" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-circle"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApPaterno">
                                    Apellido Paterno <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApPaterno" name="txtApPaterno" maxlength="70" data-original-title="Ingrese el Apellido Paterno" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-circle"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApMaterno">
                                    Apellido Materno <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApMaterno" name="txtApMaterno" maxlength="70" data-original-title="Ingrese el Apellido Materno" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-circle"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtCorreo">
                                    Correo Electrónico <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="email" class="form-control contributor-email" runat="server" id="txtCorreo" name="txtCorreo" maxlength="300" data-original-title="Ingrese el Correo Electrónico" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-envelope"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtTelefono">
                                    Teléfono <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtTelefono" name="txtTelefono" maxlength="20" data-original-title="Ingrese el Teléfono" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-phone-square"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_password">
                                    Password <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="password" class="form-control" runat="server" name="password"  id="id_password" />
                                    <i class="fa fa-unlock"></i>
                                </span>
                            </div>
                            
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_password_again">
                                    Confirmar Password <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="password" class="form-control" runat="server" id="id_password_again" name="password_again" />
                                    <i class="fa fa-unlock-alt"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaNac" >
                                    Fecha de nacimiento <span class="symbol required"></span>
                                </label>
                                <div class="input-group">
                                    <input id="txtFechaNac" name="txtFechaNac" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                             <div class="form-group">
                                 <span class="input-icon">
                                     <label class="control-label" for="form-field-select-3">
                                         Genero <span class="symbol required"></span>
                                     </label>
                                     <select class="form-control search-select" id="form-field-select-3" name="form-field-select-3">
                                         <% foreach (var Item in Lista)
                                            {
                                                Response.Write("<option value='" + Item.IDGenero.ToString() + "'>" + Item.Descripcion.ToString() + "</option>");
                                            } %>
                                     </select>
                                 </span>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label" for="cph_MasterBody_txtCodigoPostal">
                                            Código Postal <span class="symbol required"></span>
                                        </label>
                                        <span class="input-icon">
                                            <input type="text" class="form-control tooltips" runat="server" id="txtCodigoPostal" name="txtCodigoPostal" maxlength="6" data-original-title="Ingrese el código postal" data-rel="tooltip" title="" data-placement="top" />
                                            <i class="fa fa-thumb-tack"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label class="control-label" for="cph_MasterBody_txtCuidad">
                                            Cuidad <span class="symbol required"></span>
                                        </label>
                                        <span class="input-icon">
                                            <input type="text" class="form-control tooltips" runat="server" id="txtCuidad" name="txtCuidad" maxlength="100" data-original-title="Ingrese la cuidad" data-rel="tooltip" title="" data-placement="top" />
                                            <i class="fa fa-globe"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="control-label" for="cmbEncargado">
                                            Seleccione el colaborador<span class="symbol required"></span>
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
                            </div>
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
                                <span class="symbol required"></span>Campos Obligatorios
								<hr>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmNuevoAuxiliar.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar"/>
                                </div>
                                <div class="col-md-6">
                                    <a href="frmAuxiliarGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
		</script>
</asp:Content>
