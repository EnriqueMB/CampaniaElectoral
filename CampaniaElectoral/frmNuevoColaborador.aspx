<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoColaborador.aspx.cs" Inherits="CampaniaElectoral.frmNuevoColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Colaborador </span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <input id="inputImgServer"  name="inputImgServer"   type="hidden" value="<% Response.Write(imgServer); %>"/>
                        <input id="inputPassServer" name="inputPassServer"  type="hidden" value="<% Response.Write(passServer); %>"/>
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
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtClavElector">
                                        Clave Elector <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtClavElector" name="txtClavElector" placeholder="" data-original-title="Ingrese la clave de elector." data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtClavElector">
                                        Tipo de Usuario <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                            <asp:TextBox ID="txtTipoUsuario" runat="server" class="form-control tooltips" placeholder="" data-original-title="Seleccion un tipo de colaborador." data-rel="tooltip" title="" data-placement="top" ReadOnly="true"></asp:TextBox>
                                            <asp:DropDownList ID="cmbTipoUsuario" runat="server"  class="form-control search-select" ></asp:DropDownList>
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtNombre">
                                        Nombre(s) <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtNombre" name="txtNombre" maxlength="80" data-original-title="Ingrese el nombre" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-circle"></i>
                                    </span>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtApPaterno">
                                        Apellido Paterno <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtApPaterno" name="txtApPaterno" maxlength="70" data-original-title="Ingrese el Apellido Paterno" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-circle"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <dv class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtApMaterno">
                                        Apellido Materno <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtApMaterno" name="txtApMaterno" maxlength="70" data-original-title="Ingrese el Apellido Materno" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-circle"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtFechaNac">
                                        Fecha de nacimiento <span class="symbol required"></span>
                                    </label>
                                    <div class="input-group">
                                        <input id="txtFechaNac" name="txtFechaNac" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-4" id="divAsiganado" runat="server">
                                <div class="form-group">
                                    <label class="control-label" for="cmbSeccion">
                                        Asignado a <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="cmbAsignado" runat="server"  class="form-control search-select"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4"  id="divSuplente" runat="server">
                                <div class="form-group">
                                    <label class="control-label" for="cmbSeccion">
                                       Es suplente de <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="cmbSuplente" runat="server"  class="form-control search-select"></asp:DropDownList>
                                </div>
                            </div>
                        


                            <div class="col-md-4"  id="divSeccion" runat="server">
                                <div class="form-group">
                                    <label class="control-label" for="cmbSeccion">
                                        Sección <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="cmbSeccion" runat="server"  class="form-control search-select"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4" id="divCasilla" runat="server">
                                <div class="form-group">
                                    <label class="control-label" for="cmbSeccion">
                                        Casilla <span class="symbol required"></span>
                                    </label>
                                    <asp:DropDownList ID="cmbCasilla" runat="server"  class="form-control search-select" ></asp:DropDownList>
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
                                        <input type="text" class="form-control tooltips" runat="server" id="txtNumeroInt" name="txtNumeroInt" placeholder="" maxlength="5" data-original-title="Ingrese el número interior." data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-keyboard-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
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
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtCorreo">
                                        Correo Electrónico <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="email" class="form-control contributor-email" runat="server" id="txtCorreo" name="txtCorreo" maxlength="300" data-original-title="Ingrese el Correo Electrónico" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-envelope"></i>
                                    </span>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtGenero">
                                        Genero <span class="symbol required"></span>
                                    </label>
                                    <select class="form-control search-select" id="txtGenero" name="txtGenero">
                                        <option value=""></option>
                                        <% foreach (var Item in ListaGeneros)
                                           { 
                                                if(Item.IDGenero == idGenero)
                                                    Response.Write("<option value='" + Item.IDGenero.ToString() + "' selected='selected'> " + Item.Descripcion.ToString() + "</option>");
                                                else
                                                    Response.Write("<option value='" + Item.IDGenero.ToString() + "'> " + Item.Descripcion.ToString() + "</option>");
                                           }%>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_txtTelefono">
                                        Teléfono <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="text" class="form-control tooltips" runat="server" id="txtTelefono" name="txtTelefono" maxlength="20" data-original-title="Ingrese el Teléfono" data-rel="tooltip" title="" data-placement="top" />
                                        <i class="fa fa-phone-square"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label" for="cph_MasterBody_password">
                                        Password <span class="symbol required"></span>
                                    </label>
                                    <span class="input-icon">
                                        <input type="password" class="form-control" runat="server" name="password" id="id_password" />
                                        <i class="fa fa-unlock"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
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
                        </div>
                        <div class="row">
                            <div class="col-md-6">
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
                                                <asp:FileUpload CssClass="fileupload" name="imgImagen" ID="imgImagen" runat="server"/>
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
                       
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmNuevoColaborador.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar"/>
                                </div>
                                <div class="col-md-6">
                                    <asp:button id="btnRegresar" class="btn btn-red btn-block" name="btnCancelar" 
                                        runat="server" text="Cancelar" 
                                        OnClientClick="JavaScript:window.history.back(1);return false;">
                                    </asp:button>
                                </div>
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
		        FormValidator.init(7);
		    });
		</script>
</asp:Content>
