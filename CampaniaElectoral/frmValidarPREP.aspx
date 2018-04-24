<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmValidarPREP.aspx.cs" Inherits="CampaniaElectoral.frmValidarPREP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">


    
                                <div class="col-md-12 space20">
                            <a href="FrmConteoPREP.aspx" class="btn btn-green">
                                Nuevo
                                <i class="fa fa-plus"></i>
                            </a>
						</div>
    <div class="row">
	    <div class="col-md-12">
                               
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title">Últimas capturas <span class="text-bold"></span></h4>
				</div>
				<div class="panel-body">
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="TablaEncuestas">
							<thead>
								<tr>

									<th>Casilla</th>
									<th>Colaborador</th>
                                    <th>Fecha y hora de captura</th>
									<th>Acciones</th>
								</tr>
							</thead>
							<tbody>                  
                               
								 <% foreach (var Item in lista)
                                    { %>
								<tr>
									<td><%=Item.Casilla%></td>
									<td><%=Item.Colaborador %></td>
                                    <td><%=Item.SFechaHora %></td>
                                    
                                    <td>
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmValidarPREP.aspx?id=" + Item.IDCaptura + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                           
									    </div>

										<div class="visible-xs visible-sm hidden-md hidden-lg">
											<div class="btn-group">
												<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
													<i class="fa fa-cog"></i> <span class="caret"></span>
												</a>
												<ul role="menu" class="dropdown-menu pull-right dropdown-dark">
													<li>
                                                        <%Response.Write("<a href='FrmConteoPREP.aspx?id=" + Item.IDCaptura + "' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Activar'><i class='fa fa-edit'></i>Activar</a>"); %>
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
</asp:Content>
