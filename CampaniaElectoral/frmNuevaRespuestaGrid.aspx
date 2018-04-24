<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmNuevaRespuestaGrid.aspx.cs" Inherits="CampaniaElectoral.frmNuevaRespuestaGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: DYNAMIC TABLE PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title">Lista de  <span class="text-bold">Respuestas</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12 space20">
                            <%Response.Write("<a href='frmNuevaRespuestas.aspx?op=1&id=" + IDPregunta.ToString() + "&id2=" + IDEncuesta.ToString() + "&id3=" + IDTipoPregunta + "' class='btn btn-green'> Nueva Respuesta <i class='fa fa-plus'> </i> </a>"); %>
                            <%Response.Write("<a href='frmPreguntas.aspx?op=0&id=" + IDEncuesta.ToString() + "' class='btn btn-red'> Regresar a Preguntas <i class='fa fa-reply'> </i> </a>"); %>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <% if(this.IDTipoPregunta == 1) 
                           {%>
                        <table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
                            <thead>
                                <tr>
                                    <th>Clave</th>
                                    <th>Respuesta</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var Item in Lista)
                                   { %>
                                <tr>
                                    <td><%=Item.ClvRespuesta %></td>
                                    <td><%=Item.Respuesta %></td>
                                    <td>
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmNuevaRespuestas.aspx?op=2&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDRespuesta.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                                        </div>
                                        <div class="visible-xs visible-sm hidden-md hidden-lg">
                                            <div class="btn-group">
                                                <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                                    <i class="fa fa-cog"></i><span class="caret"></span>
                                                </a>
                                                <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                                    <li>
                                                        <%Response.Write("<a href='frmNuevaRespuestas.aspx?op=2&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                                    </li>
                                                    <li>
                                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDRespuesta.ToString() +"' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="modal fade bs-example-modal-sm<% = Item.IDRespuesta  %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                                            Response.Write("<a  href='frmNuevaRespuestaGrid.aspx?op=3&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                                        %>
                                                    </div>
                                                </div>
                                                <!-- /.modal-content -->
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                          <% } 
                             else {%>
                        <table class="table table-striped table-bordered table-hover table-full-width" id="Table1">
                            <thead>
                                <tr>
                                    <%--<th>Clave</th>--%>
                                    <th>Respuesta</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var Item in Lista)
                                   { %>
                                <tr>
                                    <%-- <td><%=Item.ClvRespuesta %></td>--%>
                                    <td><%=Item.Respuesta %></td>
                                    <td>
                                        <div class="visible-md visible-lg hidden-sm hidden-xs">
                                            <%Response.Write("<a href='frmNuevaRespuestas.aspx?op=2&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                            <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDRespuesta.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                                        </div>
                                        <div class="visible-xs visible-sm hidden-md hidden-lg">
                                            <div class="btn-group">
                                                <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                                    <i class="fa fa-cog"></i><span class="caret"></span>
                                                </a>
                                                <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                                    <li>
                                                        <%Response.Write("<a href='frmNuevaRespuestas.aspx?op=2&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                                                    </li>
                                                    <li>
                                                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDRespuesta.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="modal fade bs-example-modal-sm<% = Item.IDRespuesta %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-sm">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                                                            ×
                                                        </button>
                                                        <h4 id="H1" class="modal-title">Confirmación</h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <p>
                                                            ¿Está seguro de eliminar el registro seleccionado?
                                                        </p>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button data-dismiss="modal" class="btn btn-red" type="button">No</button>
                                                        <%
                                                         Response.Write("<a  href='frmNuevaRespuestaGrid.aspx?op=3&id=" + Item.IDRespuesta.ToString() + "&id2=" + IDPregunta.ToString() + "&id3=" + IDEncuesta.ToString() + "&id4=" + IDTipoPregunta + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                                        %>
                                                    </div>
                                                </div>
                                                <!-- /.modal-content -->
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                        <%} %>
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