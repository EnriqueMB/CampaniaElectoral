<%@ Page Language="C#" MasterPageFile="~/siteEstadisticos.Master" AutoEventWireup="true" CodeBehind="frmEvaluacionRepresentantes.aspx.cs" Inherits="CampaniaElectoralEstadistica.frmEvaluacionRepresentantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_ScriptUp" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">

    <div class="row">
        <div class="wrapper-md">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Lista de representantes con <%=Texto%>
                </div>       
                <div class="panel-body">
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
                            <thead>
                              <tr>
                                <th></th>
                                <th data-breakpoints="xs">Sección</th>
                                <th>Encargado</th>
                                <th data-breakpoints="xs">Avance</th>
                              </tr>
                            </thead>
                            <tbody>                            
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_ScriptDown" runat="server">
    <script src="assets/plugins/DataTables/media/js/jquery.dataTables.min.js"></script>
    <script src="js/representantes.js"></script>
    <script>
        jQuery(document).ready(function () {
            Representantes.init('<%=CssClass%>', <%=Tipo%>);
        });
    </script>
</asp:Content>
