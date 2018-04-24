<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAfiliadosImagenesGrid.aspx.cs" Inherits="CampaniaElectoral.frmAfiliadosImagenesGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: INBOX PANEL -->
            <div class="panel panel-white">
                
            </div>
        </div>
    </div>
    
    <div class="panel-body buttons-widget">
        <% Response.Write(" <a class='btn btn-red btn-block' href='frmAfiliadosGrid.aspx?op=1' style='width: 100px;'>Regresar</a> "); %> 
       <% Response.Write(" <a class='btn btn-primary' href='frmNuevaImagen.aspx?id="+frmafiliadosimagenesgrid_aspx.IdAfiliado+"'><i class='fa fa-plus'></i> Agregar Imagen</a> "); %> 
    </div>
    <table class="table table-striped table-bordered table-hover" id="projects">
        <thead>
        <tr>
            <th>Titulo de Imagen</th>
            <th class="hidden-xs">Fecha Afiliación</th>
            <th>Opciones</th>
        </tr>
        </thead>
        <tbody>
        <% foreach (var Item in Lista)
           { %>
            <tr>
                <td ><%=Item.Titulo %></td>
                <td class="center hidden-xs"><%=Item.FechaImagen.ToShortDateString() %></td>
                
                <td class="center hidden-xs">
                    <div class="visible-md visible-lg hidden-sm hidden-xs">
                        
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smvi" + Item.IdImagenAfiliado.ToString() + "' data-toggle='modal'   class='btn btn-xs btn-green tooltips' data-placement='top' data-original-title='Ver'><i class='fa fa-eye fa fa-white'></i></a>");%>
                        <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smdel" + Item.IdImagenAfiliado.ToString() + "' data-toggle='modal'  class='btn btn-xs btn-red tooltips' data-placement='top' data-original-title='Eliminar'> <i class='fa fa-times fa fa-white'> </i> </a>");%>
                       

                    </div>
                    <div class="visible-xs visible-sm hidden-md hidden-lg">
                        <div class="btn-group">
                            <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                <i class="fa fa-cog"></i> <span class="caret"></span>
                            </a>
                            <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smvi" + Item.IdImagenAfiliado.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Ver'><i class='fa fa-eye fa fa-white'></i>Ver</a>");%>
                                    
                                </li>
                                <li>
                                    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-smdel" + Item.IdImagenAfiliado.ToString() + "' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-times fa fa-white'></i>Eliminar</a>");%>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-smdel<% = Item.IdImagenAfiliado %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                                        Response.Write("<a href='frmAfiliadosImagenesGrid.aspx?op=3&id=" + Item.IdImagenAfiliado.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
                                    %>                                          
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                    </div>
                    <div class="modal fade bs-example-modal-smvi<% = Item.IdImagenAfiliado %>" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-md">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                                        ×
                                    </button>
                                    <h4 id="myLargeModalLabel" class="modal-title"><% Item.Titulo.ToString(); %></h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                                <div class="col-12">
                            
                                                    <img class="img-responsive" src="data:image/jpg;base64,
                                                        <% = Item.Imagen %>
                                                        "                                
                                                        />
                            
                                                    <br />
                                                </div>
                                    </div>
                                </div>
                                <div class="modal-footer">    
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                                                          
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