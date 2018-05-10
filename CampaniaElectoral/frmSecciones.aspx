<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSecciones.aspx.cs" Inherits="CampaniaElectoral.frmSecciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
	    <div class="col-md-12">
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title">Lista de <span class="text-bold">Secciones</span></h4>
				</div>
				<div class="panel-body">
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
							<thead>
								<tr>
									<th>Sección</th>
									<th>Tipo de sección</th>
									<th>Acciones</th>
								</tr>
							</thead>
							<tbody>                  
                                <% foreach (var Item in Lista)
                                    { %>
								<tr>
									<td><%=Item.IDSeccion %></td>
									<td><%=Item.TipoSeccion %></td>
                                    <td>
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmSeccionDetalle.aspx?id=" + Item.IDSeccion + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Ver'> <i class='fa fa-edit'> </i> </a>"); %>
									    </div>

										<div class="visible-xs visible-sm hidden-md hidden-lg">
											<div class="btn-group">
												<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
													<i class="fa fa-cog"></i> <span class="caret"></span>
												</a>
												<ul role="menu" class="dropdown-menu pull-right dropdown-dark">
													<li>														
                                                        <%Response.Write("<a href='frmSeccionDetalle.aspx?id=" + Item.IDSeccion + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Ver'><i class='fa fa-edit'></i>Ver</a>"); %>
													</li>
												</ul>
											</div>
										</div>
                                    </td>
								</tr>
                                <% } %>
							</tbody>
						</table>
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
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
    <script src="assets/js/secciones.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
	<script src="assets/js/main.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
            Secciones.init();
		});
	</script>
</asp:Content>