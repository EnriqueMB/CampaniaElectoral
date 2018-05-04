<%@ Page Language="C#" Title="Catálogo de Colaboradores" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmColaboradores.aspx.cs" Inherits="CampaniaElectoral.frmColaboradores" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <%  //Validamos el op
            int op = 0; bool valido;
            valido = int.TryParse(Request.QueryString["op"].ToString(), out op);
            if (!valido)
                Response.Redirect("ErrorPage.aspx", false);
        %>
	    <div class="col-md-12">
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title"><span class="text-bold">
                        <%  if(op == 1)
                                Response.Write("Administrador y Capturista");
                            else
                            if(op == 100)
                                Response.Write("Representante General");
                            else

                            if(op == 200)
                                Response.Write("Representante de Sección");
                            else

                            if(op == 300)
                                Response.Write("Representante de Casilla");

                            else
                            if(op == 400)
                                Response.Write("Operadores Políticos");
                            else


                                Response.Write("Colaboradores");

                         %>

				                            </span></h4>
				</div>
				<div class="panel-body">
					<div class="row">
						<div class="col-md-12 space20">

                             <%  //Nuevo
                                 if (op == 200 || op == 201 || op == 300 || op == 301 || op == 400 )
                                 {

                                     if(op == 201 || op == 301)
                                     {

                                         op = op - 1;
                                     }
                              %>
                                    <a href="frmNuevoColaborador.aspx?op=<%Response.Write(op);%>" class="btn btn-green">
                                    Nuevo
                                    <i class="fa fa-plus"></i>
                                    </a>
                            <%      
                                } %>

                            <%  //Suplente
                                if (op == 100 || op == 101 || op == 200 || op == 201 || op == 300 || op == 301)
                                {
                                    if(op == 100 || op == 200 || op == 300)
                                     {

                                         op = op + 1;
                                     }
                                %>
                                    <a href="frmNuevoColaborador.aspx?op=<%Response.Write(op);%>" class="btn btn-green">
                                    Nuevo Suplente
                                    <i class="fa fa-plus"></i>
                                    </a>
                                
                            <% } %>
                             
						</div>
					</div>
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
							<thead>
								<tr>
									<th>Nombre</th>
									<th>Apellido Paterno</th>
                                    <th>Apellido Materno</th>
                                    <th class="hidden-xs center">Perfil</th>
                                    <th>Opciones</th>
								</tr>
							</thead>
							<tbody>                  
                                <% foreach (var Item in ListaColaboradores)
                                    { %>
								<tr>
									<td><%=Item.Nombre %></td>
                                    <td><%=Item.ApPaterno %></td>
                                    <td><%=Item.ApMaterno%></td>
                                    <%Response.Write("<th class= 'center hidden-xs'><span style=' background-color: " + Item.ColorPerfil + "' class='label label-primary' >&nbsp" + " " + Item.TipoUsuario + " </span></td>");%>
                                    <td>
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmNuevoColaborador.aspx?op=" + Item.IDTipoUsu.ToString() +"&opW=2&id=" + Item.IDColaborador.ToString() + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>");%>
                                            <% if(Item.IDTipoUsu != 100)
                                                Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDColaborador.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");
                                            %>
									    </div>
										<div class="visible-xs visible-sm hidden-md hidden-lg">
											<div class="btn-group">
												<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
													<i class="fa fa-cog"></i> <span class="caret"></span>
												</a>
												<ul role="menu" class="dropdown-menu pull-right dropdown-dark">
													<li>
                                                        <%Response.Write("<a href='frmNuevoColaborador.aspx?opW=2&id=" + Item.IDColaborador.ToString() + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-edit'></i>Editar</a>"); %>
													</li>
                                                    <%if (Item.IDTipoUsu != 100)
                                                    {%>
													    <li>
                                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDColaborador.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
													    </li>
                                                    <%} %>
												</ul>
											</div>
										</div>
                                        <%if (Item.IDTipoUsu != 100)
                                        {%>
                                             <div class="modal fade bs-example-modal-sm<% = Item.IDColaborador %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                                              <%
                                                        Response.Write("<a  href='frmColaboradores.aspx?opW=3&id=" + Item.IDColaborador.ToString() + "&op=" + Item.IDTipoUsu.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                                              %>
			                                            </div>
		                                            </div>
		                                            <!-- /.modal-content -->
	                                            </div>
                                             </div>
                                        <%} %>
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
	<script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
	<script type="text/javascript" src="assets/js/table-data.js"></script>
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
	<!-- start: CORE JAVASCRIPTS  -->
    
	<script src="assets/js/main.js"></script>
	<!-- end: CORE JAVASCRIPTS  -->
	<script>
	    jQuery(document).ready(function () {
	        TableData.init();
	    });
	</script>
</asp:Content>