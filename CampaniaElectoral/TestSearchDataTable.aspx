<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestSearchDataTable.aspx.cs" Inherits="CampaniaElectoral.TestSearchDataTable" %>

<asp:Content ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: INBOX PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4>Búsqueda de afiliados</h4>
                    <%--<div class="panel-body buttons-widget">--%>
                        <a class="btn btn-primary right" href="frmNuevoAfiliado.aspx"><i class="fa fa-plus"></i> Nuevo Afiliado</a>
                    <%--</div>--%>
                </div>
                <div class="panel-body pbBusqueda">
                    <div class="row">
                        <div class="col-md-4">
                             <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por nombre
                                </label>--%>
                                <div class="input-group">
                                    <input type="text" id="txtBuscar" placeholder="Nombre de afiliado" class="form-control tooltips" maxlength="200" data-original-title="Ingrese nombre" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" id="atxtBuscar" style="color:white; text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por fechas
                                </label>--%>
                                <div class="input-group">
                                     <span class="input-group-addon"> <i class="fa fa-calendar"></i> </span>
                                    <input type="text" id="fecha" placeholder="Fecha de afiliación" class="form-control date-range" readonly style="cursor:pointer;">
                                    <span class="input-group-addon">
                                        <a href="#" id="afecha" style="color: white; text-decoration: none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por estatus
                                </label>--%>
                                <div class="input-group">
                                     <select id="form-field-select-3" name="form-field-select-3" class="form-control search-select">
                                         <option value="">-- Seleccione --</option>
                                        <option value="0">No Ratificado</option>
                                        <option value="1">Ratificado</option>
                                    </select>
                                    <span class="input-group-addon">
                                        <a href="#" id="aform-field-select-3" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    
                         <div class="col-md-4">
                             <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por seccion
                                </label>--%>
                                <div class="input-group">
                                    <input type="text" id="seccion"  placeholder="Número de sección" class="form-control tooltips" maxlength="200" data-original-title="Ingrese clave de seccion" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" id="aseccion" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por Clave de Elector
                                </label>--%>
                                <div class="input-group">
                                    <input type="text" id="clvElector" placeholder="Clave de elector" class="form-control tooltips" maxlength="200" data-original-title="Ingrese Clave de Elector" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" id="aclvElector" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                             <div class="form-group">
                                <%--<label class="control-label">
                                    Buscar por Operador
                                </label>--%>
                                <div class="input-group">
                                    <input type="text" id="operador" placeholder="Operador" class="form-control tooltips" maxlength="200" data-original-title="Ingrese nombre de operador" data-rel="tooltip"  title="" data-placement="top" />
                                    <span class="input-group-addon">
                                       <a href="#" id="aoperador" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <table class="table table-striped table-bordered table-hover" id="tblafiliados">
                        <thead>
                        <tr>
                            <th>Nombre Completo</th>
                            <th>Fecha Afiliación</th>
                            <th>Estatus</th>
                            <th>Sección</th>
                            <th>Clave de elector</th>
                            <th>Operador</th>
                            <th>Opciones</th>
                        </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    
     
</asp:Content>

<asp:Content ContentPlaceHolderID="cphScripts" runat="server">
    <script>
        $(document).ready(function () {

            var table = $('#tblafiliados').DataTable({
                "processing": true,
                "serverSide": true,
                "searching": false,
                "language": {
                    "url": "/assets/json/Spanish.json"
                },
                "ajax": {
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/afiliadosService.asmx/Data",
                    data: function (d) {
                        return JSON.stringify({ parameters: d });
                    }
                }
            });

            table.columns().flatten().each(function (colIdx) {
                // Create the select list and search operation
                var select = $('<select />')
                    .appendTo(
                        table.column(colIdx).footer()
                    )
                    .on('change', function () {

                        table.search('').columns()
                         .search('');

                        table
                            .column(colIdx)
                            .search($(this).val())
                            .draw();
                    });

                // Get the search data for the first column and add to the select list
                table
                    .column(colIdx)
                    .cache('search')
                    .sort()
                    .unique()
                    .each(function (d) {
                        select.append($('<option value="' + d + '">' + d + '</option>'));
                    });
            });

         });
    </script> 
</asp:Content>