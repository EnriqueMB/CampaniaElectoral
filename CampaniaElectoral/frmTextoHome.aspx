<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmTextoHome.aspx.cs" Inherits="CampaniaElectoral.frmTextoHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
                            <div class="col-sm-12">
                                <!-- start: COLOR PICKER PANEL -->
                                <div class="panel panel-white">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><span class="text-bold">Texto Pagina Home</span></h4>
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

                                            <div class="col-md-6">
                                                 <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloHacemos">
                                                       Titulo Que hacemos<span class="symbol required"></span>
                                                    </label>
                                                    <span class="input-icon">
                                                        <input type="text" class="form-control tooltips" runat="server" id="txtTituloHacemos" name="txtTituloHacemos"  maxlength="100" data-original-title="Ingrese el nombre de la cuenta" data-rel="tooltip"  title="" data-placement="top" />
                                                        <i class="fa fa-users"></i>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                 <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtQueHacemos">
                                                       Descripci&oacute;n Que hacemos<span class="symbol required"></span>
                                                    </label>
                                                    <span class="input-icon">
                                                        <input type="text" class="form-control tooltips" runat="server" id="txtQueHacemos" name="txtQueHacemos"  maxlength="100" data-original-title="Ingrese el nombre de la cuenta" data-rel="tooltip"  title="" data-placement="top" />
                                                        <i class="fa fa-users"></i>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloAfiliate">
                                                        Titulo Afiliate <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloAfiliate" name="txtTituloAfiliate" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtAfiliate">
                                                        Descripci&oacute;n Afiliate <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtAfiliate" name="txtAfiliate" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloProxEventos">
                                                        Titulo Pr&oacute;ximos Eventos <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloProxEventos" name="txtTituloProxEventos" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtProxEventos">
                                                        Descripci&oacute;n Pr&oacute;ximos Eventos <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtProxEventos" name="txtProxEventos" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloEquipoTrabajo">
                                                        Titulo Equipo de Trabajo <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloEquipoTrabajo" name="txtTituloEquipoTrabajo" placeholder="" maxlength="150" data-original-title="Ingrese el texto alternativo. " data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtEquipoTrabajo">
                                                        Descripci&oacute;n Equipo de Trabajo <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtEquipoTrabajo" name="txtEquipoTrabajo" placeholder="" maxlength="150" data-original-title="Ingrese el texto alternativo. " data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>
                                            
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloBlog">
                                                        Titulo Blog<span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloBlog" name="txtTituloBlog" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>
                                            
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtDescTituloBlog">
                                                        Descripci&oacute;n Blog<span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtDescTituloBlog" name="txtDescTituloBlog" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>		
                                            

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtTituloContacto">
                                                        Titulo Contactanos <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtTituloContacto" name="txtTituloContacto" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label" for="cph_MasterBody_txtContacto">
                                                        Descripci&oacute;n Contactanos <span class="symbol required"></span>
                                                    </label>
                                                    <input type="text" class="form-control tooltips" runat="server" id="txtContacto" name="txtContacto" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo de la fotograf&iacute;a a subir" data-rel="tooltip" title="" data-placement="top" />
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
                                                            <input type="submit" formaction="frmTextoHome.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                                        </div>
                                                        <div class="col-md-6">
                                                            <a href="frmTextoHomeGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
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
            FormValidator.init(37);
        });
    </script>
    </asp:Content>