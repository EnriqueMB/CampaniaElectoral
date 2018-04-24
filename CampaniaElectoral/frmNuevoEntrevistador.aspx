<%@ Page Language="C#"  EnableViewState="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevoEntrevistador.aspx.cs" Inherits="CampaniaElectoral.frmNuevoEntrevistador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Nuevo Afiliado</span></h4>
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
                                <label class="control-label" for="cph_MasterBody_txtNombreAfiliado">
                                    Nombre Entrevistador<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtNombreAfiliado" name="txtNombreAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el nombre del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApePatAfiliado">
                                    Apellido Paterno Entrevistador<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApePatAfiliado" name="txtApePatAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el apellido paterno del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtApeMatAfiliado">
                                    Apellido Materno Entrevistado<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtApeMatAfiliado" name="txtApeMatAfiliado" placeholder="" maxlength="150" data-original-title="Ingrese el apellido materno del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtEdad">
                                    Edad<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtEdad" name="txtEdad" placeholder="" maxlength="3" data-original-title="Ingrese la edad del entrevistado" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                         <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtHabColonia">
                                    Años de habitar en su colonia<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="number" class="form-control tooltips" runat="server" id="txtHabColonia" name="txtHabColonia" placeholder="" maxlength="3" data-original-title="Ingrese los años de habitar en su colonia" data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbGenero">
                                    Genero <span class="symbol required"></span>
                                </label>
                                <select id="cmbGenero" name="cmbGenero" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <option value="1">Femenino</option>
                                    <option value="2">Masculino</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbGradoEstudio">
                                    Grado de Estudio <span class="symbol required"></span>
                                </label>
                                <select id="cmbGradoEstudio" name="cmbGradoEstudio" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <option value="1">Primaria</option>
                                    <option value="2">Secundaria</option>
                                    <option value="3">Preparotoria</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtDireccion">
                                    Dirección <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtDireccion" name="txtDireccion" placeholder="" maxlength="150" data-original-title="Ingrese la dirección." data-rel="tooltip" title="" data-placement="top" />
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbEntrevistador">
                                    Entrevistador <span class="symbol required"></span>
                                </label>
                                <select id="cmbEntrevistador" name="cmbEntrevistador" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <option value="1">Enrique Mendez Ballina</option>
                                    <option value="2">Enrique Mendez Ballina</option>
                                    <option value="3">Enrique Mendez Ballina</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbSupervisor">
                                   Supervisor <span class="symbol required"></span>
                                </label>
                                <select id="cmbSupervisor" name="cmbSupervisor" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <option value="1">Enrique Mendez Ballina</option>
                                    <option value="2">Enrique Mendez Ballina</option>
                                    <option value="3">Enrique Mendez Ballina</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtObservaciones">
                                    Observaciones
                                </label>
                                <span class="input-icon">
                                    <textarea maxlength="1500" id="txtObservaciones" runat="server" name="txtObservaciones" class="form-control limited"></textarea>
                                </span>
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
                                    <input type="submit" formaction="frmNuevoAfiliado.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmAfiliadosGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>