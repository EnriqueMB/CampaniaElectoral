<%@ Page Language="C#"  MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="frmCompletarAfiliadosGrid.aspx.cs" Inherits="CampaniaElectoral.frmCompletarAfiliadosGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: INBOX PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4>Buscar Afiliados</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                             <div class="form-group">
                                <label class="control-label">
                                    Buscar por nombre
                                </label>
                                <div class="input-group">
                                    <input type="text" id="txtBuscar" class="form-control tooltips" maxlength="200" data-original-title="Ingrese nombre" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" onclick="javascript:SubmitFrm()" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
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
                                        <a href="#" onclick="javascript:SubminFecha()" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
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
                                    <span class="input-group-addon"><a href="#" onclick="javascript:SubminSt()" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                        <%Response.Write("<a href= 'frmCompletarAfiliado.aspx?op=2&id=" + Item.IDAfiliado.ToString() + "' class='btn btn-xs btn-blue tooltips' data-placement='top' data-original-title='Editar'> <i class='fa fa-edit'> </i> </a>"); %>
                        
                    </div>
                    <div class="visible-xs visible-sm hidden-md hidden-lg">
                        <div class="btn-group">
                            <a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
                                <i class="fa fa-cog"></i> <span class="caret"></span>
                            </a>
                            <ul role="menu" class="dropdown-menu pull-right dropdown-dark">
                                <li>
                                    <%Response.Write("<a href='frmCompletarAfiliado.aspx?op=2&id=" + Item.IDAfiliado.ToString() + "' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-edit'></i>Editar</a>"); %>
                                </li>
                                
                            </ul>
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
            window.location = "frmCompletarAfiliadosGrid.aspx?op=8&Buscar=" + Searchtxt;
        }

        function SubminSt() {
            var Searchtxt = document.getElementById("form-field-select-3").value;
            window.location = "frmCompletarAfiliadosGrid.aspx?op=9&Buscar=" + Searchtxt;
        }

        function SubminFecha() {
            var Searchtxt = document.getElementById("fecha").value;
            window.location = "frmCompletarAfiliadosGrid.aspx?op=10&Buscar=" + Searchtxt;
        }
    </script>
</asp:Content>