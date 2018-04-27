<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmConteoPREP.aspx.cs" Inherits="CampaniaElectoral.FrmConteoPREP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Captura PRE </span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label" for="CmbPoligonos">
                                            Poligono
                                        </label>
                                        <select id="CmbPoligonos" name="CmbPoligonos" class="form-control search-select" required>
                                             <option value="">&nbsp;</option>
                                            <%
                                                foreach (var item in poligonos)
                                                {
                                                    Response.Write("<option  value='" + item.IDPoligono + "' > " + item.Nombre + "</option>");
                                                }
                                            %>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="control-label" for="CmbCasilla">
                                            Casilla
                                        </label>
                                        <select id="CmbCasilla" name="CmbCasilla" class="form-control search-select" required>
                                             <option value="">&nbsp;</option>
                                            <%
                                                foreach (var item in poligonos)
                                                {
                                                    Response.Write("<option  value='" + item.IDPoligono + "' > " + item.Nombre + "</option>");
                                                }
                                            %>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label" for="cmbColaboradores">
                                            Colaboradores
                                        </label>
                                        <select id="cmbColaboradores" name="cmbColaboradores" class="form-control search-select" required>
                                                  <option value="">&nbsp;</option>
                                                <% foreach (var TipoUser in DatosGlobales.DatosAuxColab.ListaUsers)
                                                    {
                                                        Response.Write("<optgroup label='" + TipoUser.Descripcion + "'>");

                                                        foreach(var ItemColab in DatosGlobales.DatosAuxColab.ListaColaboradores.Where(x => x.IDTipoUsuario == TipoUser.IDTUsuario ))
                                                        {
                                                                Response.Write("<option value='" + ItemColab.IDColaborador + "'>" + ItemColab.Nombre+ "</option>");
                                                        }
                                                        Response.Write("</optgroup>");
                                                    } %>
                                        </select>
                                    </div>
                                     </div>
                                  <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">
                                            Foto <span class="symbol required"></span>
                                        </label>
                                        <div class="fileupload fileupload-new" data-provides="fileupload">
                                            <div class="fileupload-new thumbnail">
                                                <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
                                            </div>
                                            <div class="fileupload-preview fileupload-exists thumbnail"></div>
                                            <div>
                                                <span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i>Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                                    <%--<input type="file" class="fileupload" id="imgLogo" name="imgLogo" runat="server"/>--%>
                                                    <asp:FileUpload CssClass="fileupload" name="fuploadImagen" ID="fuploadImagen" runat="server" />
                                                </span>
                                                <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
                                                    <i class="fa fa-times"></i>Quitar
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                           </div>
                        </div>

                        <%--<div class="form-group">
                        <label for="exampleFormControlFile1">Selecionar Imagen</label>
                         <asp:FileUpload ID="fuploadImagen" runat="server" CssClass="form-control" />
                         <br />
                         <br />
                      </div>--%>
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover table-full-width" id="TablaEncuestas">
                                <thead>
                                    <tr>
                                        <th>Logo</th>
                                        <th>Casilla</th>
                                        <th>Partido</th>
                                        <th>Siglas</th>
                                        <th>Votos</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%  foreach (var item in partidos)
                                        {
                                    %>
                                    <tr>
                                        <td>
                                            <% if (!string.IsNullOrEmpty(item.Logo))
                                                {
                                                    Response.Write("<img class='img-responsive' style='width: 50px; height: 50px;' src='data:image/jpg;base64," + item.Logo + "' />");
                                                }
                                                else
                                                {
                                                    Response.Write("<img class='img-responsive' style='width: 50px; height: 50px;' src='assets/images/por-definir.png' />");
                                                }
                                           %>
                                        </td>
                                        <td>
                                            <%= item.IDPartido%>
                                        </td>
                                        <td>
                                            <%= item.Nombre%>
                                        </td>
                                        <td>
                                            <%= item.Siglas%>
                                        </td>
                                        <td>
                                            <input type="number" id="<%= item.Siglas%>" value="0" name="<%= item.Siglas%>" required />
                                        </td>
                                    </tr>
                                    <% } %>
                                </tbody>
                            </table>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <input type="submit" formaction="FrmConteoPREP.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                                    </div>
                                    <div class="col-md-6">
                                        <a href="frmNuevaZonaRiesgo.aspx" class="btn btn-danger btn-block" name="btnCancelar">Cancelar</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--<div class="row">
                        <div class="col-md-6 space20">
                            <input type="submit" formaction="FrmConteoPREP.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar" />
                        </div>
                        <div class="col-md-6 space20">
                            <a href="frmNuevaZonaRiesgo.aspx" class="btn btn-danger btn-block">Cancelar 
                            </a>
                        </div>
                    </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>   
     <script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
		<!--<![endif]-->
		<!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
		<script src="assets/js/form-validation2.js"></script>
        <script src="assets/js/ui-notifications.js"></script>
        <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
		<!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
		<!-- start: CORE JAVASCRIPTS  -->
		<script src="assets/js/main.js"></script>
		<!-- end: CORE JAVASCRIPTS  -->
		<script>
		    jQuery(document).ready(function () {
		        FormValidator.init(100);
		    });
		</script>            
</asp:Content>
