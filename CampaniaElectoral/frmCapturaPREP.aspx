<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="frmCapturaPREP.aspx.cs" Inherits="CampaniaElectoral.frmCapturaPREP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
	    <div class="col-md-12">
		    <!-- start: INBOX PANEL -->
		    <div class="panel panel-white">
			    <div class="panel-heading">
				    <h4>Captura de Casillas</h4>
                </div>
                <div class="panel-body">
                    <%-- Hidden field, para guardar el ID de la foto reportada por la app --%>
                    <div class="row">
						<asp:HiddenField ID="hf" runat="server" />
					</div>
                    <%-- Divs para mostrar errores de validacion --%>
					<div class="row">
						<div class="col-md-12">
							<div class="errorHandler alert alert-danger no-display">
								<i class="fa fa-times-sign"></i> Hay errores en la captura de información. Revise las especificaciones de los campos.
							</div>
							<div class="successHandler alert alert-success no-display">
								<i class="fa fa-ok"></i> Your form validation is successful!
							</div>
						</div>
                    </div>

                    <div class="row">
                        <div class="col-md-1"></div>
				        <div class="col-md-3">
                            <div class="row">
                                <fieldset>
                                    <legend>CASILLA </legend>
                                    <span class="text-bold text-uppercase"><%=Datos.Casilla %> </span>
                                </fieldset>
                            </div>
                            <br />
                            <div class="row">
                                <fieldset>
                                    <legend>COLABORADOR </legend>
                                    <span class="text-bold text-uppercase"><%=Datos.Colaborador %> </span>
                                    <br />
                                </fieldset>
                            </div>
                            <br />
                            <div class="row">
                                <fieldset>
                                    <legend>COMENTARIOS </legend>
                                    <span class="text-bold text-uppercase"><%=Datos.Comentarios %> </span>
                                </fieldset>
                            </div>
                        </div>
                        <div class="col-md-7 center">
							<div class="">
                                <% Response.Write("<div class='thumbnail'><img src='" + Datos.UrlImagen + "' alt=''></div>"); %>								
							</div>
                        </div>
                        <div class="col-md-1"></div>
				    </div>

                    <div class="row">
                        <table class="table table-striped table-hover" id="sample-table-2">
					        <thead>
						        <tr>
							        <th class="center">Logo</th>
							        <th>Partido</th>
							        <th>Votos</th>
						        </tr>
					        </thead>
					        <tbody>
                                <% foreach (var Item in Datos.ListaPartidos){ %>
						        <tr>
							        <td class="center"><% Response.Write("<img src='" + Item.UrlLogo + "' style='max-width:50px; max-height:50px;' alt='image'/>"); %></td>
							        <td><%=Item.Nombre %></td>
                                    <td>
                                        <span class="input-icon">
                                            <% Response.Write("<input type='number' class='form-control tooltips requiredInput' id='txtPartido" + Item.IDPartido + "' name='txtPartido" + Item.IDPartido + "' placeholder='' maxlength='5' data-original-title='Ingrese la cantidad de votos obtenidos' data-rel='tooltip' title='' data-placement='top' value='" + Item.Votos + "' />"); %>
                                            <i class="fa fa-keyboard-o"></i>
                                        </span>
                                    </td>
						        </tr>
                                <% } %>
					        </tbody>
				        </table>
                    </div>

                    <br />

                    <div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<div class="col-md-6">
								    <input type="submit" formaction="frmCapturaPREP.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
								</div>
								<div class="col-md-6">
									<a href="frmCapturas.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Regresar</a>
								</div>
							</div>
						</div>
						<div class="col-md-6"></div>
					</div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

