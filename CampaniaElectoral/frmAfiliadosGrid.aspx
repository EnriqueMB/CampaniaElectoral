<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAfiliadosGrid.aspx.cs" Inherits="CampaniaElectoral.frmAfiliadosGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: INBOX PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4>Buscar Afiliados</h4>
                </div>
                <div class="panel-body pbBusqueda">
                    <div class="row">
                        <div class="col-md-4">
                             <div class="form-group">
                                <label class="control-label">
                                    Buscar por nombre
                                </label>
                                <div class="input-group">
                                    <input type="text" id="txtBuscar" class="form-control tooltips" maxlength="200" data-original-title="Ingrese nombre" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="frmAfiliadosGrid.aspx?op=8" id="atxtBuscar" <%--onclick="javascript:SubmitFrm()"--%> style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">
                                    Buscar por fechas
                                </label>
                                <div class="input-group">
                                     <span class="input-group-addon"> <i class="fa fa-calendar"></i> </span>
                                    <input type="text" id="fecha" class="form-control date-range" readonly style="cursor:pointer;">
                                    <span class="input-group-addon">
                                        <a href="frmAfiliadosGrid.aspx?op=10" id="afecha" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label">
                                    Buscar por estatus
                                </label>
                                <div class="input-group">
                                     <select id="form-field-select-3" name="form-field-select-3" class="form-control search-select">
                                        <option value="0">No Ratificado</option>
                                        <option value="1">Ratificado</option>
                                    </select>
                                    <span class="input-group-addon">
                                        <a href="frmAfiliadosGrid.aspx?op=9" id="aform-field-select-3" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col-md-4">
                             <div class="form-group">
                                <label class="control-label">
                                    Buscar por seccion
                                </label>
                                <div class="input-group">
                                    <input type="text" id="seccion" class="form-control tooltips" maxlength="200" data-original-title="Ingrese clave de seccion" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="frmAfiliadosGrid.aspx?op=11" id="aseccion" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group">
                                <label class="control-label">
                                    Buscar por Clave de Elector
                                </label>
                                <div class="input-group">
                                    <input type="text" id="clvElector" class="form-control tooltips" maxlength="200" data-original-title="Ingrese Clave de Elector" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="frmAfiliadosGrid.aspx?op=12" id="aclvElector" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group">
                                <label class="control-label">
                                    Buscar por Operador
                                </label>
                                <div class="input-group">
                                    <input type="text" id="operador" class="form-control tooltips" maxlength="200" data-original-title="Ingrese nombre de operador" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="frmAfiliadosGrid.aspx?op=13" id="aoperador" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
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
        <a class="btn btn-primary" href="frmNuevoAfiliado.aspx"><i class="fa fa-plus"></i> Nuevo Afiliado</a>
    </div>
    <table class="table table-striped table-bordered table-hover" id="projects">
        <thead>
        <tr>
            <th>Nombre Completo</th>
            <th class="hidden-xs">Fecha Afiliación</th>
            <th class="hidden-xs center">Estatus</th>
            <th>Opciones</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (var Item in Lista)
           { %>
            <tr>
                <td ><%=Item.Nombre %></td>
                <td class="center hidden-xs"><%=Item.FechaAfiliacion.ToShortDateString() %></td>
                <td class="center hidden-xs"><% if (Item.Ratificacion == false)
                                                {%><% 
                              Response.Write("<span class='label label-primary'> No Ratificado </span>"); 
                       }%>
                    <% else %>
                    <%
                        {
                            Response.Write("<span class='label label-primary'> Ratificado </span>"); 
                        }%>  </td>
                <td class="center hidden-xs">
                    <div class="visible-md visible-lg hidden-sm hidden-xs">
                        <%Response.Write("<a href= 'frmNuevoAfiliado.aspx?op=2&id=" + Item.IDAfiliado.ToString() + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smdel" + Item.IDAfiliado.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smrt" + Item.IDAfiliado + "' data-toggle='modal'  class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Ratificar'> <i class='fa fa-check'> </i> </a>");%>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smimp" + Item.IDAfiliado + "' data-toggle='modal'  class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Imprimir Ficha'> <i class='fa fa-print'> </i> </a>");%>
                        <%Response.Write("<a href='frmAfiliadosImagenesGrid.aspx?id=" + Item.IDAfiliado.ToString() + "' class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Agregar foto'> <i class='fa fa-camera'> </i> </a>");%>
                        
                    </div>
                    <div class="visible-xs visible-sm hidden-md hidden-lg">
                        <div class="btn-group">
                            <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                <i class="fa fa-cog"></i> <span class="caret"></span>
                            </a>
                            <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                <li>
                                    <%Response.Write("<a href='frmNuevoAfiliado.aspx?op=2&id=" + Item.IDAfiliado.ToString() + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-edit'></i>Editar</a>"); %>
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smdel" + Item.IDAfiliado.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smrt" + Item.IDAfiliado + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Ratificar'><i class='fa fa-check'></i>Compartir</a>");%>
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smimp" + Item.IDAfiliado + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Imprimir Ficha'><i class='fa fa-print'></i>Compartir</a>");%>
                                </li>
                                <li>
                                    <%Response.Write("<a href='frmAfiliadosImagenesGrid.aspx?id=" + Item.IDAfiliado.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Agregar foto'><i class='fa fa-camera'></i>Agregar foto</a>");%>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-smdel<% = Item.IDAfiliado %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                        Response.Write("<a href='frmAfiliadosGrid.aspx?op=3&id=" + Item.IDAfiliado.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                    %>                                          
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-smrt<% = Item.IDAfiliado %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                        ¿Está seguro de querer ratificar el elemento seleccionando?
                                    </p>
                                </div>
                                <div class="modal-footer">                     
                                    <button data-dismiss="modal" class="btn btn-red" type="button">No</button>
                                    <%
                                        Response.Write("<a href='frmAfiliadosGrid.aspx?op=6&id=" + Item.IDAfiliado.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                    %>                                          
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-smimp<% = Item.IDAfiliado %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                        ¿Imprimir Ficha?
                                    </p>
                                </div>
                                <div class="modal-footer">                     
                                    <button data-dismiss="modal" class="btn btn-red" type="button">No</button>
                                    <%
                                        Response.Write("<a href='frmAfiliadosGrid.aspx?op=7&id=" + Item.IDAfiliado.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
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
     
</asp:Content>

<asp:Content ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {
            $(".pbBusqueda a").click(function () {
             //$(".panel-body").on("click", "a", function (event) {
                 event.preventDefault();
                 var aux = $(this).attr('id');
                 var url = $(this).attr('href');
                 var Searchtxt = '';
                 switch(aux)
                 {
                     case 'atxtBuscar':
                         Searchtxt = document.getElementById("txtBuscar").value;
                         break;
                     case 'aform-field-select-3':
                         Searchtxt = document.getElementById("form-field-select-3").value;
                         break;
                     case 'afecha':
                         Searchtxt = document.getElementById("fecha").value;
                         break;
                     case 'aseccion':
                         Searchtxt = document.getElementById("seccion").value;
                         break;
                     case 'aclvElector':
                         Searchtxt = document.getElementById("clvElector").value;
                         break;
                     case 'aoperador':
                         Searchtxt = document.getElementById("operador").value;
                         break;
                 }
                 url = url + "&Buscar=" + Searchtxt
                 console.log(url);
                 //window.location = url;
             });
         });
    </script>   
</asp:Content>