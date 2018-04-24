<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmResultadoPregunta.aspx.cs" Inherits="CampaniaElectoral.frmResultadoPregunta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title">Mapa <span class="text-bold">Tem&aacute;tico</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hfIDEncuesta" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p><%=DatosAux.Explicacion %></p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="panel-body">							    
										<table class="table" id="sample-table-1">
											<thead>
												<tr>
													<th colspan="2" class="center"><%=DatosAux.TituloRespuesta %> <br /> <%=DatosAux.TituloPorcentaje %> <br /><%=DatosAux.PeriodoDatos %></th>
												</tr>
                                                
											</thead>
											<tbody>
                                                <% foreach (var Item in DatosAux.ListaValoresRespuesta){ %>
												<tr>
													<td><%=Item.DescripcionPorcentaje %></td>
													<% Response.Write("<td class=''><div style=' background-color: " + Item.Color + "'>&nbsp" + "</div></td>");%>
												</tr>
                                                <%} %>
											</tbody>
										</table>
									</div>



                        </div>
                        <div class="col-md-9">
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
    <script src="assets/js/mapsResultado.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
            
	    });
	</script>
</asp:Content>
