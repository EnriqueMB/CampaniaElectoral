<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmPreguntasRespuestas.aspx.cs" Inherits="CampaniaElectoral.frmPreguntasRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- start: DYNAMIC TABLE PANEL -->
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title">Lista de  <span class="text-bold">Preguntas con Respuestas</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                    </div>
                    <label class="control-label" for="cph_MasterBody_txtFolioEncuesta">
                        Folio Automatico de encuesta<span class="symbol required"></span>
                    </label>
                    <span class="input-icon">
                        <input type="text" class="form-control tooltips" runat="server" id="txtFolioEncuesta" name="txtFolioEncuesta" placeholder="" maxlength="100" data-original-title="Ingrese lel folio del encuesta" data-rel="tooltip" title="" data-placement="top" readonly />
                        <i class="fa fa-keyboard-o"></i>
                    </span>
                    <br />
                    <br />
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover table-full-width" id="sample_1">
                            <thead>
                                <tr>
                                    <th>Pregunta</th>
                                    <th>Respuestas</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% int i = 1; %>
                                <% foreach (var Item in ListaPregunta)
                                   { %>
                                <tr>
                                    <td><%= Item.NombrePregunta %></td>
                                    <% if (Item.IDTipoPregunta == 1)
                                       {%>
                                    <td class="col-md-6" id="IDTIPO<%= Item.IDTipoPregunta %>">
                                        <div class="form-group">
                                            <label class="control-label" for="cmb<%= Item.IDPreguntas %>">
                                            </label>
                                            <select id="cmb<%= Item.IDPreguntas %>" name="cmb<%= Item.IDPreguntas %>"" class="form-control search-select" required>
                                                <option value=""></option>
                                                <% foreach (var Items in Item.ListaRespuesta)
                                                   {
                                                       if (Item.IDRespuestaContestada == Items.IDRespuesta)
                                                       {
                                                           Response.Write("<option value='" + Items.IDRespuesta.ToString() + "' selected>" + Items.ClvRespuesta + " " + Items.Respuesta.ToString() + "</option>");
                                                       }
                                                       else
                                                       {
                                                           Response.Write("<option value='" + Items.IDRespuesta.ToString() + "'>" + Items.ClvRespuesta + " " + Items.Respuesta.ToString() + "</option>");
                                                       }
                                                   }
                                                %>
                                            </select>
                                        </div>
                                    </td>
                                    <%}
                                       else
                                       {%>
                                    <td class="col-md-6">
                                        <div class="form-group">
                                            <span class="input-icon">
                                                <textarea maxlength="1000" id="txt<%= Item.IDPreguntas %>" name="txt<%= Item.IDPreguntas %>" class="form-control limited" required><%=Item.IDRespuestaContestada %></textarea>
                                            </span>
                                        </div>
                                    </td>
                                    <%} %>
                                </tr>
                                <% i++; %>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                    <br />
                     <div class="row ">
                        <%--<div class="col-md-12"></div>--%>
                        <div class="col-md-12">
                            <div class="form-group pull-right">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmPreguntasRespuestas.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmRespuestaEncuestaGrid.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
	<!-- start: MAIN JAVASCRIPTS -->
	<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!-- end: MAIN JAVASCRIPTS -->
	<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
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