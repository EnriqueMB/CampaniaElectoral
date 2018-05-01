<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPuntosPoligono.aspx.cs" Inherits="CampaniaElectoral.frmPuntosPoligono" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
	    <div class="col-md-12">
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title">Puntos de <span class="text-bold">Pol&iacute;gonos</span></h4>
				</div>
				<div class="panel-body">
					<div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:HiddenField ID="hf2" runat="server" />
                    </div>
                    <%-- Nombre y clave del polígono --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtNombrePoligono">
							        Nombre del pol&iacute;gono
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control" readonly runat="server" id="txtNombrePoligono" name="txtNombrePoligono" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtClave">
                                    Clave del pol&iacute;gono
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control" readonly runat="server" id="txtClave" name="txtClave" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <%-- Estado y municipio --%>
                    <div class="row">
                        <div class="col-md-6">
                             <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtEstado">
							        Estado
						        </label>
						        <span class="input-icon">
                                    <input type="text" readonly class="form-control" runat="server" id="txtEstado" name="txtEstado" />
							        <i class="fa fa-map-marker"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtMunicipio">
							        Municipio
						        </label>
						        <span class="input-icon">
                                    <input type="text" readonly class="form-control" runat="server" id="txtMunicipio" name="txtMunicipio" />
							        <i class="fa fa-map-marker"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <%-- Colonia --%>
                    <div class="row">            
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtColonia">
							        Colonia
						        </label>
						        <span class="input-icon">
                                    <input type="text" readonly class="form-control" runat="server" id="txtColonia" name="txtColonia"  />
							        <i class="fa fa-map-marker"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <span class="activities">LISTA DE PUNTOS </span>
                            <div class="table-responsive">
						        <table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
							<thead>
								<tr>
									<th>Orden</th>
									<th>Latitud</th>
                                    <th>Longitud</th>
									<th>Acciones</th>
								</tr>
							</thead>
							<tbody>                  
                                <% foreach (var Item in Lista)
                                    { %>
                                <tr>
									<td><%=Item.OrdenPunto %></td>
									<td><%=Item.Latidud %></td>
                                    <td><%=Item.Longitud %></td>                                  
                                    <td class="center">
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDPunto + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
									    </div>
										<div class="visible-xs visible-sm hidden-md hidden-lg">
											<div class="btn-group">
												<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
													<i class="fa fa-cog"></i> <span class="caret"></span>
												</a>
												<ul role="menu" class="dropdown-menu pull-right dropdown-dark">
													<li>
                                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDPunto + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
													</li>
												</ul>
											</div>
										</div>
                                         <div class="modal fade bs-example-modal-sm<% = Item.IDPunto %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
	                                     <div class="modal-dialog modal-sm">
		                                    <div class="modal-content">
			                                    <div class="modal-header">
				                                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
					                                    ×
				                                    </button>
				                                    <h4 id="mySmallModalLabel" class="modal-title">Confirmación</h4>
			                                    </div>
			                                    <div class="modal-body">
				                                    <p>
					                                    ¿Está seguro de eliminar el registro seleccionado?
				                                    </p>
			                                    </div>
			                                    <div class="modal-footer">                     
				                                    <button data-dismiss="modal" class="btn btn-red" type="button">No</button>
                                                      <% Response.Write("<a  href='frmPuntosPoligono.aspx?op=3&id=" + Item.IDPunto + "&idP=" + IDPoligono + "'class='btn btn-green add-row' runat='server'>Si</a>");%>
                                                </div>
		                                    </div>
	                                    </div>
                                      </div>
                                    </td>
								</tr>
                                <% } %>
							</tbody>
						</table>
					        </div>
                        </div>
                        <div class="col-md-6">
                            <span class="activities">CLIC PARA SELECCIONAR UN PUNTO </span>
                            <input type="hidden" value="" id="hfLatitud" name="hfLatitud" />
                            <input type="hidden" value="" id="hfLongitud" name="hfLongitud" />
                            <button type="submit" class="btn btn-green" name="btnAgregar" id="btnAgregar" value="Agregar">Agregar
                                <i class="fa fa-plus"></i>
                            </button> 
                            <div class="map" id="map1"></div>
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
	<script type="text/javascript" src="assets/js/table-data.js"></script>
    <script src="assets/js/form-validation2.js"></script>   
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>     
    <script src="assets/js/mapsPuntos.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        //Maps.init(16.7807937830878, -93.0996894836426);
	        FormValidator.init(32);
	        TableData.init();
		});
	</script>
        
</asp:Content>    