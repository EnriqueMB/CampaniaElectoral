<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmConteoPREP.aspx.cs" Inherits="CampaniaElectoral.FrmConteoPREP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    
    <h1>
        Captura PRE 
    </h1>
                                
    <div class="row bootstrap-switch-container">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" for="CmbPoligonos">
                                    Poligono
                                </label>
                                <select id="CmbPoligonos"  name="CmbPoligonos" class="form-control search-select" required>
                                    
                                    <%
                                        foreach(var item in poligonos)
                                            {
                                                 Response.Write("<option  value='" + item.IDPoligono + "' > " + item.Nombre + "</option>");
                                             }
                                        %>
                                    
                                </select>
                               
                            </div>
					</div>
                    </div>
                        
                      <div class="form-group">
                        <label for="exampleFormControlFile1">Selecionar Imagen</label>
                         <asp:FileUpload ID="fuploadImagen" runat="server" CssClass="form-control" />
                         <br />
                         <br />
                      </div>
                    
         

    <div class="panel-body">
					<div class="table-responsive">
						<table class="table table-striped table-bordered table-hover table-full-width" id="TablaEncuestas">
							<thead>
								<tr>
									<th>Casilla</th>
									<th>Partido</th>
                                    <th>Siglas</th>
                                    <th>Votos</th>
									
								</tr>
							</thead>
							<tbody>  
                                <%  foreach(var item in partidos)
                                    {
                                 %>
                                 <tr>
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
                        <div class="col-md-6 space20">
                            <input type="submit" formaction="FrmConteoPREP.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar"  />
						</div>
                        <div class="col-md-6 space20">
                            <a href="frmNuevaZonaRiesgo.aspx" class="btn btn-danger btn-block">
                               Cancelar 
                            </a>
						</div>
                    </div>
                    
				</div>
        
        
   
   
                            
</asp:Content>
