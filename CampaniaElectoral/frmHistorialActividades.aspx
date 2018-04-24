<%@ Page Language="C#" Title="Historial de actividades" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHistorialActividades.aspx.cs" Inherits="CampaniaElectoral.frmHistorialActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
	    <div class="col-md-12">
		    <!-- start: DYNAMIC TABLE PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4 class="panel-title">Catálogo <span class="text-bold">Historial de actividades</span></h4>
				</div>
				<div class="panel-body">
					<%--<div class="row">
						<div class="col-md-12 space20">
                            <a href="frmActividadComercial.aspx" class="btn btn-green">
                                Nuevo
                                <i class="fa fa-plus"></i>
                            </a>
						</div>
					</div>--%>
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
							<thead>
								<tr>
									 <th>Evento</th>
                                    <th class="hidden-xs">Encargado</th>
                                    <th>Entrega</th>
                                    <th class="hidden-xs">Objetivo</th>
                                    <th class="hidden-xs">Avance</th>
                                    <th class="hidden-xs center">Estatus</th>
                                    <th class="hidden-xs center">Visto</th>
                                   <%-- <th>Opciones</th>--%>
								</tr>
							</thead>
                            <tbody>
                                <% foreach (var Item in ListaActividad)
                                   { %>
                                <tr>
                                    <td><%=Item.NombreActividad %></td>
                                    <td class="center hidden-xs"><%=Item.EncargadoActividad %></td>
                                    <td class="center hidden-xs"><%=Item.FechaTermino.ToShortDateString() %></td>
                                    <td class="center hidden-xs">
                                        <% 
                                        if (Item.MetaEstablecida == 0)
                                        {%><% 
                                            Response.Write("<span class='label label-primary'>CONCLUIR</span>");
                                        }%>
                                        <% else %>
                                        <%
                                        {
                                            Response.Write("<span class='label label-purple'>" + Item.MetaEstablecida + "</span>");
                                        }%>  
                                    </td>
                                    <%Response.Write("<td class='center hidden-xs'> <div style='margin:0px !important' class='progress transparent-black no-radius'><div aria-valuetransitiongoal=" + 50 + " class='progress-bar partition-azure animate-progress-bar'></div></div></td>");%>
                                    <%Response.Write("<td class='center hidden-xs'> <span class='label " + Item.EstatusGeneral + "'> " + Item.DescEstatusGrnl + "</span></td>"); %>
                                    <%Response.Write("<td class='center hidden-xs'> <span class='label " + Item.EstatusVisto + "'> <i class= 'fa " + Item.DescEstatusVisto + "'></i></span></td>"); %>
                                    <%--<td class="center hidden-xs">
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmNuevaActividad.aspx?op=2&id=" + Item.IDNuevaAct.ToString() + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Compartir'> <i class='fa fa-share'> </i> </a>");%>
                                        </div>
                                        <div class="visible-xs visible-sm hidden-md hidden-lg">
                                            <div class="btn-group">
                                                <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                                    <i class="fa fa-cog"></i><span class="caret"></span>
                                                </a>
                                                <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                                    <li>
                                                        <%Response.Write("<a href=''frmNuevaActividad.aspx?op=2&id=" + Item.IDNuevaAct.ToString() + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-edit'></i>Editar</a>"); %>
                                                    </li>
                                                    <li>
                                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                                    </li>
                                                    <li>
                                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-share'></i>Compartir</a>");%>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="modal fade bs-example-modal-sm<% = Item.IDNuevaAct %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                                            Response.Write("<a  href=''frmNuevaActividad.aspx?op=3&id=" + Item.IDNuevaAct.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                                        %>
                                                    </div>
                                                </div>
                                                <!-- /.modal-content -->
                                            </div>
                                        </div>
                                    </td>--%>
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