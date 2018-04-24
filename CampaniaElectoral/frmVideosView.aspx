<%@ Page Language="C#" Title="Visualizar videos" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVideosView.aspx.cs" Inherits="CampaniaElectoral.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
  <div class="row">
     <div class="col-md-12">
     </div>
	   <div class="col-sm-12">
		  <div class="panel panel-white">
			 <div class="panel-heading">
					<h4 class="panel-title"><i class="fa fa-video-camera" aria-hidden="true"></i><span class="text-bold">  Visualizar Videos</span></h4>
	            </div>
               <div class="controls" style="padding-left:10px;">
                    <a href="frmVideosLoad.aspx" class="btn btn-green">Agregar <i class="fa fa-plus"></i></a>
                </div>
	            <div class="panel-body">
	               <div class="row">
	                  <asp:HiddenField ID="hf" runat="server" />
	               </div>
					<div class="row">
                       <% foreach (var ItView in Lista)
						{ %>
							 <div class="col-sm-6 col-md-3">
								 <div class="thumbnail">
                                     <img  src="<%=ItView.Url %>" alt="">Link
                                      <div class="from-group">    
                                        <div class="caption">
                                            <div class="visible-md visible-lg hidden-sm hidden-xs">
											   <%Response.Write("<a href='frmVideosLoad.aspx?op=2&id=" + ItView.IDVideo.ToString() + "'class='btn btn-blue' role='menuitem' tabindex='-1' class='tooltips' data-placement='top' data-original-title='Editar'><i class='fa fa-cog fa-fw' ></i></a>"); %>
											
											    <%Response.Write("<a data-placement='top' data-target='.bs-example-modal-sm" + ItView.IDVideo.ToString() + "'class='btn btn-red' role='menuitem' tabindex='-1' data-toggle='modal'  class='tooltips' data-placement='top' data-original-title='Eliminar'><i class='fa fa-trash'></i></a>");%>
                                            </div> 
                                            </div>                                    
									   </div>
								   </div>
							   </div>
                               
                              <div class="modal fade bs-example-modal-sm<% = ItView.IDVideo %>" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
												Response.Write("<a  href='frmVideosView.aspx?op=3&id=" + ItView.IDVideo.ToString() + "' class='btn btn-green add-row' runat='server'>Si</a>");
												%>                                          
											 </div>
										</div>
									</div>
							    </div>
                               <% } %>
                            </div>
                        </div>
                     </div>
                  </div>
               </div>
    </asp:Content>
