<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="frmIncidencias.aspx.cs" Inherits="CampaniaElectoral.frmIncidencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"> <span class="text-bold">Incidencias</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
						<div class="col-md-12 space20">
                            <a href="frmNuevaIncidencia.aspx" class="btn btn-green">
                                Nuevo
                                <i class="fa fa-plus"></i>
                            </a>
						</div>
					</div>

                    <div class="row bootstrap-switch-container">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cmbMunicipio">
                                    Municipio
                                </label>
                                <select id="cmbMunicipio" name="cmbMunicipio" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                    <%  foreach (var ItemMunicipio in Datos.ListaMunicipio)
                                        {
                                            Response.Write("<option value='" + ItemMunicipio.IDEstado + "'> " + ItemMunicipio.Descripcion + "</option>");
                                        } %>
                                </select>
                            </div>
						</div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cmbPoligono">
                                    Seccion
                                </label>
                                <select id="cmbPoligono" name="cmbPoligono" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                         <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="cmbSeccion">
                                    Casilla
                                </label>
                                <select id="cmbSeccion" name="cmbSeccion" class="form-control search-select">
                                    <option value="">&nbsp;</option>
                                </select>
                            </div>
						</div>
                        <div class="col-md-3 "><br />
                            <a id="btnFiltrar" href="#" class="btn btn-blue">Ver Incidencias</a>
						</div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="map" id="map1">
                            </div>
                        </div>
                    </div> 
                </div>
            </div>
        </div>
    </div>



    <!-- start: MAIN JAVASCRIPTS -->
		<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!-- end: MAIN JAVASCRIPTS -->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
    <script src="assets/js/mapsZonaRiesgo.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        Maps.init(<%=Datos.IDEstado%>,'<%=Datos.Estado%>');

	        //$("#cmbEstado").change(function () {
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
	        $("#cmbMunicipio").change(function () {
	            $("#cmbMunicipio option:selected").each(function () {
	                elegido = $(this).val();
	                estado = <%=Datos.IDEstado%>;
	                $("#cmbPoligono option").remove();
	                $.ajaxSetup({
	                    async: false
	                });
	                console.log("estado: " + estado + ", municipio: " + elegido);
	                $.getJSON('sfrmSeccionesCmb.aspx?municipio=' + elegido, function (data) {
	                    $("#cmbPoligono").append('<option value="">&nbsp;</option>');
	                    $.each(data, function (key, value) {
	                        $("#cmbPoligono").append('<option value="' + value.IDSeccion + '">' + value.seccionDesc + '</option>');
	                    });
                    });
	                $("#cmbPoligono").trigger('change.select2');
	                // Set the global configs back to asynchronous 
	                $.ajaxSetup({
	                    async: true
	                });
	            })
	        });
            $("#cmbPoligono").change(function () {
                $("#cmbPoligono option:selected").each(function () {
	                elegido = $(this).val();
	                
	                $("#cmbSeccion option").remove();
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

            
	        $("#btnFiltrar").click(function (event) {
	            console.log("1");
	            event.preventDefault();

	            //Si no hay nada seleccionado, el mapa se inicializa con los datos de geolocalización
	            //if (!(selectedEstado.text.trim() === '' && selectedMunicipio.text.trim() === '' && selectedPoligono.text.trim() === ''))
	            //{
	            //}
                
	            Maps.init(<%=Datos.IDEstado%>,'<%=Datos.Estado%>');
	        });
	    });
	</script>
</asp:Content>
