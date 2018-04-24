<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmActividadesEventosGrid.aspx.cs" Inherits="CampaniaElectoral.frmActividadesEventosGrid" %>
<%@ Import Namespace="System.ComponentModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: INBOX PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4>Buscar Actividades</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="cph_MasterBody_txtBuscar">
                                    Buscar por Encargado
                                </label>
                                <div class="input-group">
                                    <input type="text" class="form-control tooltips" id="txtBuscar" name="txtBuscar"  maxlength="200" data-original-title="Ingrese nombre del encargado" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" onclick="javascript:SubmitFrm()" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Buscar por Fechas
                                </label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <input type="text" id="Fecha" name="Fecha" class="form-control date-range" readonly style="cursor: pointer;">
                                    <span class="input-group-addon">
                                        <a href="#" onclick="javascript:SubminFecha()" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                     Buscar por Tipo
                                </label>
                                <div class="input-group">
                                    <select id="form-field-select-3" name="form-field-select-3" class="form-control search-select">
                                        <% foreach (var Item in ListaEventoAgenda)
                                           {
                                               Response.Write("<option value='" + Item.IDTipoEventoAgenda + "'>" + Item.Descripcion + "</option>");
                                           } %>
                                    </select>
                                    <span class="input-group-addon">
                                        <a href="#" onclick="javascript:SubminTipo()" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                       <%-- <input type="submit" name="btnSearch" value="" id="Submit1" class="btn" onclick="javascript: SubminTipo()" />--%>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Buscar por Status
                                </label>
                                <div class="input-group">
                                    <select id="form-field-select-2" name="form-field-select-2" class="form-control search-select">
                                        <% foreach (var Item in ListaStatusGeneral)
                                           {
                                               Response.Write("<option value='" + Item.IDStatusGeneralEvento + "'>" + Item.Descripcion + "</option>");
                                           } %>
                                    </select>
                                    <span class="input-group-addon">
                                        <a href="#" onclick="javascript:SubminSt()" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body buttons-widget">
        <a class="btn btn-primary" href="frmNuevaActividad.aspx"><i class="fa fa-plus"></i> Nueva Actividad</a>
    </div>
    <table class="table table-striped table-bordered table-hover" id="projects">
        <thead>
        <tr>
            <th>Evento</th>
            <th class="hidden-xs">Encargado</th>
            <th>Entrega</th>
            <th class="hidden-xs">Objetivo</th>
            <th class="hidden-xs">Avance</th>
            <th class="hidden-xs center">Estatus</th>
            <th class="hidden-xs center">Visto</th>
            <th>Opciones</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (var Item in Lista)
            { %>
            <tr>
                <td ><%=Item.NombreActividad %></td>
                <td class="center hidden-xs"><%=Item.EncargadoActividad %></td>
                <td class="center hidden-xs"><%=Item.FechaTermino.ToShortDateString() %></td>
                <td class="center hidden-xs"><% if (Item.MetaEstablecida == 0)
                       {%><% 
                              Response.Write("<span class='label label-primary'> Concluir </span>"); 
                       }%>
                       <% else %>
                      <%
                       {
                           Response.Write("<span class='label label-purple'> "+Convert.ToInt32(Item.MetaEstablecida)+"</span>");
                       }%>  </td>
                <%Response.Write("<th class='center hidden-xs'> <div class='progress transparent-black no-radius'><div aria-valuetransitiongoal=" + 100 + " class='progress-bar partition-azure animate-progress-bar'>&nbsp</div></div></td>");%>
                <%Response.Write("<th class='center hidden-xs'> <span class='label " +Item.EstatusGeneral+"'> "+Item.DescEstatusGrnl+"</span></td>"); %>
                <%Response.Write("<th class='center hidden-xs'> <span class='label "+ Item.EstatusVisto+"'> <i class= 'fa "+Item.DescEstatusVisto+"'></i></span></td>"); %>
                <td class="center hidden-xs">
                    <div class="visible-md visible-lg hidden-sm hidden-xs">
                        <%Response.Write("<a href= 'frmNuevaActividad.aspx?op=2&id=" + Item.IDNuevaAct.ToString() + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct + "' data-toggle='modal'  class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Compartir'> <i class='fa fa-share'> </i> </a>");%>
                    </div>
                    <div class="visible-xs visible-sm hidden-md hidden-lg">
                        <div class="btn-group">
                            <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                <i class="fa fa-cog"></i> <span class="caret"></span>
                            </a>
                            <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                <li>
                                    <%Response.Write("<a href='frmNuevaActividad.aspx?op=2&id=" + Item.IDNuevaAct.ToString() + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-edit'></i>Editar</a>"); %>
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + Item.IDNuevaAct + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Compartir'><i class='fa fa-share'></i>Compartir</a>");%>
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
                                        Response.Write("<a href='frmActividadesEventosGrid.aspx?op=3&id=" + Item.IDNuevaAct.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
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
    <script>
        $("panel-body").on("click", "a", function (event) {
            event.preventDefault();
        });

        $("frmMaster").on("a", function (event) {
            event.preventDefault();
        });
    </script>
   
    <script type="text/javascript">
    	function SubmitFrm() {
    	    var Searchtxt = document.getElementById("txtBuscar").value;
    	    window.location = "frmActividadesEventosGrid.aspx?op=4&Buscar=" + Searchtxt;
    	}

    	function SubminTipo() {
    	    var Searchtxt = document.getElementById("form-field-select-3").value;
    	    window.location = "frmActividadesEventosGrid.aspx?op=5&Buscar=" + Searchtxt;
    	}

    	function SubminSt() {
    	    var Searchtxt = document.getElementById("form-field-select-2").value;
    	    window.location = "frmActividadesEventosGrid.aspx?op=6&Buscar=" + Searchtxt;
    	}

    	function SubminFecha() {
    	    var Searchtxt = document.getElementById("Fecha").value;
    	    window.location = "frmActividadesEventosGrid.aspx?op=7&Buscar=" + Searchtxt;
    	}
    </script>
     <script type="text/javascript">
         
    </script>

</asp:Content>