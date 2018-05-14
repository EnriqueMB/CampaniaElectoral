<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaIncidencia.aspx.cs" Inherits="CampaniaElectoral.frmNuevaIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Incidencias</span></h4>
                </div>
                <div class="panel-body">
                     <div class="form-group">
                        <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ValidationGroup="AllValidators" />
                    </div>
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

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="txtTitulo">
                                    T&iacute;tulo <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <asp:RequiredFieldValidator ID="rfvtxtTitulo" CssClass="text-danger serv" ControlToValidate="txtTitulo" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese el titulo" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
									<input type="text" class="form-control tooltips" runat="server" id="txtTitulo" name="txtTitulo" placeholder="" maxlength="150" data-original-title="Ingrese el t&iacute;tulo del riesgo." data-rel="tooltip"  title="" data-placement="top" />
									<i class="fa fa-users"></i>
								</span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="txtDescripcion">
                                    Descripci&oacute;n <span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <asp:RequiredFieldValidator ID="rfvtxtDescripcion" CssClass="text-danger serv" ControlToValidate="txtDescripcion" runat="server" Display="Dynamic" ErrorMessage="Por favor, ingrese la descripcion de la incidencia" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <textarea maxlength="1500" id="txtDescripcion" runat="server" name="txtDescripcion" class="form-control limited"></textarea>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbTipoRiesgo">
                                    Tipo de riesgo <span class="symbol required"></span>
                                </label>
                               <%-- <asp:RequiredFieldValidator ID="rfvTRiesgo" CssClass="text-danger serv" ControlToValidate="cmbTipoRiesgo" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un tipo de riesgo." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvTRiesgo" CssClass="text-danger serv" ControlToValidate="cmbTipoRiesgo" OnServerValidate="cvTRiesgo_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un tipo de riesgo." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                               --%> <select id="cmbTipoRiesgo" name="cmbTipoRiesgo" class="form-control search-select" runat="server">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemTR in Datos.ListaTipoRiesgos)
                                        {
                                            Response.Write("<option value='" + ItemTR.IDTipoRiesgo + "'> " + ItemTR.Descripcion + "</option>");
                                        } %>
                                </select>
                            </div>
                        </div>
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbMunicipio">
                                    Municipio <span class="symbol required"></span>
                                </label>
                                <asp:RequiredFieldValidator ID="rfvcmbMunicipio" CssClass="text-danger serv" ControlToValidate="cmbMunicipio" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un municipio." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvcmbMunicipio" CssClass="text-danger serv" ControlToValidate="cmbTipoRiesgo" OnServerValidate="cvcmbMunicipio_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione un tipo de riesgo." Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select" runat="server">
                                    <option value="" runat="server">&nbsp;</option>
                                     <%  foreach (var ItemMunicipio in Datos.ListaMunicipio)
                                        {
                                            Response.Write("<option runat='server' value='" + ItemMunicipio.IDEstado + "'> " + ItemMunicipio.Descripcion + "</option>");
                                        } %>
                                </select>
                            </div>
						</div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbPoligono">
                                    Seccion <span class="symbol required"></span>
                                </label>
                               <%-- <asp:RequiredFieldValidator ID="rfvcmbPoligono" CssClass="text-danger serv" ControlToValidate="cmbPoligono" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione la sección" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvcmbPoligono" CssClass="text-danger serv" ControlToValidate="cmbPoligono" OnServerValidate="cvcmbPoligono_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione la sección" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbPoligono" name="cmbPoligono" class="form-control search-select" runat="server">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                          <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cmbSeccion">
                                    Casilla
                                </label>
                               <%-- <asp:RequiredFieldValidator ID="rfvcmbSeccion" CssClass="text-danger serv" ControlToValidate="cmbSeccion" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione la casilla" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvcmbSeccion" CssClass="text-danger serv" ControlToValidate="cmbSeccion" OnServerValidate="cvcmbSeccion_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione la casilla" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                <select id="cmbSeccion" name="cmbSeccion" class="form-control search-select" runat="server">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                    </div>
                    <div class="row">
                                        <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label" for="cmbColaboradores">
                                            Colaboradores
                                        </label>
                                        <%--<asp:RequiredFieldValidator ID="rfvcmbColaboradores" CssClass="text-danger serv" ControlToValidate="cmbColaboradores" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione al colaborador" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvcmbColaboradores" CssClass="text-danger serv" ControlToValidate="cmbColaboradores" OnServerValidate="cvcmbColaboradores_ServerValidate" runat="server" Display="Dynamic" ErrorMessage="Por favor, seleccione al colaborador" Text="* Requerido" ValidationGroup="AllValidators" EnableClientScript="false" SetFocusOnError="true"></asp:CustomValidator>
                                        <select id="cmbColaboradores" name="cmbColaboradores" class="form-control search-select" required runat="server">
                                                  <option value="">&nbsp;</option>
                                                <% foreach (var TipoUser in DatosGlobales.DatosAuxColab.ListaUsers)
                                                    {
                                                        Response.Write("<optgroup label='" + TipoUser.Descripcion + "'>");

                                                        foreach(var ItemColab in DatosGlobales.DatosAuxColab.ListaColaboradores.Where(x => x.IDTipoUsuario == TipoUser.IDTUsuario ))
                                                        {
                                                                Response.Write("<option value='" + ItemColab.IDColaborador + "'>" + ItemColab.Nombre+ "</option>");
                                                        }
                                                        Response.Write("</optgroup>");
                                                    } %>
                                        </select>
                                    </div>
                                     </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="map1">
                                    Seleccione un punto dentro del pol&iacute;gono <span class="symbol required"></span>
                                </label>
                                <input type="hidden" value="" id="hfLatitud" name="hfLatitud" />
                                <input type="hidden" value="" id="hfLongitud" name="hfLongitud" />
                                <div class="map" id="map1">
                                </div>
                            </div>
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

					<div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<div class="col-md-6">
									<input type="submit" formaction="frmNuevaIncidencia.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmIncidencias.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
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
		<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!-- end: MAIN JAVASCRIPTS -->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="assets/js/form-validation2.js"></script>
	<script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
    <script src="assets/js/mapsNZonaRiesgo.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        FormValidator.init(35);
	        //if (document.getElementById('hfLatitud').value === '') {
	        //    Maps.init(1);
	        //    console.log("Inicializó en blanco");
	        //}
	        //$("#cmbEstado").change(function () {
	        //    if (document.getElementById('hfLatitud').value === '') {
	        //        Maps.init(1);
	        //    }
	        //    $("#cmbEstado option:selected").each(function () {
	        //        elegido = $(this).val();
	        //        $("#cmbMunicipio option").remove();
	        //        $.ajaxSetup({
	        //            async: false
	        //        });

	        //        $.getJSON('sfrmMunicipios.aspx?estado=' + elegido, function (data) {
	        //            $("#cmbMunicipio").append('<option value="">&nbsp;</option>');
	        //            $.each(data, function (key, value) {
	        //                $("#cmbMunicipio").append('<option value="' + value.IDMunicipio + '">' + value.Descripcion + '</option>');
	        //            });
	        //        });
	        //        $("#cmbMunicipio").trigger('change');
	        //        $("#cmbPoligono").trigger('change.select2');
	        //        // Set the global configs back to asynchronous 
	        //        $.ajaxSetup({
	        //            async: true
	        //        });
	        //    })
	        //});
          
	        $("#cph_MasterBody_cmbMunicipio").change(function () {
	            $("#cph_MasterBody_cmbMunicipio option:selected").each(function () {
	                elegido = $(this).val();
	                estado = <%=Datos.IDEstado%>;
	                $("#cph_MasterBody_cmbPoligono option").remove();
	                $.ajaxSetup({
	                    async: false
	                });
	                console.log("estado: " + estado + ", municipio: " + elegido);
	                $.getJSON('sfrmSeccionesCmb.aspx?municipio=' + elegido, function (data) {
	                    $("#cph_MasterBody_cmbPoligono").append('<option value="">&nbsp;</option>');
	                    $.each(data, function (key, value) {
	                        $("#cph_MasterBody_cmbPoligono").append('<option value="' + value.IDSeccion + '">' + value.seccionDesc + '</option>');
	                    });
	                });
	                $("#cph_MasterBody_cmbPoligono").trigger('change.select2');
	                // Set the global configs back to asynchronous 
	                $.ajaxSetup({
	                    async: true
	                });
	            })
	        });
          
	        $("#cmbMunicipio").change(function () {
	            elegido = $(this).val();
	            //console.log("Municipio elegido : " + elegido);
	            if (!(elegido === '')){
	                if (document.getElementById('hfLatitud').value === '') {
	                    Maps.init(1,<%=Datos.IDEstado%>,'<%=Datos.Estado%>');
	                }}});
	                
	            $("#cmbPoligono").change(function () {
	                $("#cmbPoligono option:selected").each(function () {
	                    elegido = $(this).val();
	                
	                    $("#cmbPoligono option").remove();
	                    $.ajaxSetup({
	                        async: false
	                    });
	              
	                    $.getJSON('sfrmCasillasCmb.aspx?seccion=' + elegido, function (data) {
	                        $("#cmbSeccion").append('<option value="">&nbsp;</option>');
	                        $.each(data, function (key, value) {
	                            $("#cmbSeccion").append('<option value="' + value.IDCasilla + '">' + value.DescCasilla + '</option>');
	                        });
	                    });
	                    $("#cmbSeccion").trigger('change.select2');
	                    // Set the global configs back to asynchronous 
	                    $.ajaxSetup({
	                        async: true
	                    });
	                })
	            });      
	      
	            $("#cmbPoligono").change(function () {
	                elegido = $(this).val();
	                //console.log("Poligono elegido : " + elegido);
	                if (!(elegido === '')){
	                    if (document.getElementById('hfLatitud').value === '') {
	                        Maps.init(1,<%=Datos.IDEstado%>,'<%=Datos.Estado%>');
	                    }}});
	                    
	           
	        });
	</script>
</asp:Content>