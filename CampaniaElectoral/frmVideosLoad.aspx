<%@ Page Language="C#" Title="Videos" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVideosLoad.aspx.cs" Inherits="CampaniaElectoral.frmVideosLoad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
  <div class="row">
     <div class="col-md-12">
     </div>
	   <div class="col-sm-12">
		  <div class="panel panel-white">
			 <div class="panel-heading">
					<h4 class="panel-title"><i class="fa fa-file-video-o" aria-hidden="true"></i><span class="text-bold">  Nuevo video</span></h4>
	            </div>
	            <div class="panel-body">
	               <div class="row">
	                  <asp:HiddenField ID="hf" runat="server" />
	               </div>
                     <div class="row">
                        <div class="col-md-12">
						    <div class="errorHandler alert alert-danger no-display">
							    <i class="fa fa-times-sign"></i> Hay errores en la captura de información. Revise las especificaciones de los campos.
						    </div>  
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
						    <div class="success alert alert-success no-display">
							    <i class="fa fa-check-circle"></i> Datos guardados exitosamente.
						    </div>  
                        </div>
                    </div>

                     <div class="row">       
                      <div class="col-md-12">
                           <div class="form-group">
                               <label class="control-label" for="cph_MasterBody_txtUrl">    
                               </label>
                               <span class="input-icon input-icon-left">
                                     <input type="text" class="form-control tooltips" runat="server" id="txtUrl" name="txtUrl" placeholder="https://www.youtube.com/" maxlength="150" data-original-title="Enter the url."  data-rel="tooltip" title="Url" data-placement="top" />
                                     <i class="fa fa-search"></i>
                               </span>  
                           </div>
                       </div>
                   </div>
                    <div class="form-horizontal"> 
                       <div class="row">                   
                       <div class="form-group">
                          <div class="col-sm-1">
                          </div>
                          <div class="col-sm-8">
                              <div class ="embed-responsive embed-responsive-16by9">
                                <iframe class="embed-responsive-item" name="frameName" id="frameName" >
                                </iframe>
                              </div>
                              <div class="col-sm-3"> 
                                 <div class="video-responsive">
                                    <div style="text-align:center;">
                                    </div>
                                 </div>            
                              </div>
                           </div>
                        </div>
                       </div>
                              
                       <div class="row">
                        <div class="form-group">
                            <label class="col-sm-1 control-label" for="cph_MasterBody_txtAlt">
                               Alt<span class="symbol required"> </span>
                            </label>
                            <div class="col-sm-9">
                              <span class="input-icon input-icon-left">
                                <input type="text"  placeholder="" id="txtAlt" runat="server" name="txtAlt" class="form-control" required >
                                <i class=""></i> </span>
                            </div>
                         </div>
                        </div> 
                          
                       <div class="row">    
                           <div class="form-group">
                              <label class="col-sm-1 control-label" for="cph_MasterBody_txtTitle">
                                 Title<span class="symbol required"> </span>
                              </label>
                              <div class="col-sm-9">
                                 <input type="text" placeholder="" id="txtTitle" runat="server" name="txtTitle" class="form-control input-lg" >
                              </div>
                           </div>
                       </div>

                       <div class ="row">
                           <div class="form-group">
                              <label class="col-sm-1 control-label" for="cph_MasterBody_txtDescription">
                                   Description<span class="symbol required"> </span>
                              </label>
                              <div class="col-sm-9">
                                <span class="input-icon input-icon-right">
                                    <textarea placeholder="" id="txtDescription" runat="server" name="txtDescription" class="form-control" ></textarea>
                                    <i class="fa fa-pencil"></i>
                                </span>
                            </div>
                         </div>
                      </div>
                    </div>
	                   <div class="row">
					  <div class="col-md-12">
						 <div>
							<span class="symbol required">
							</span>
								Datos requeridos
								<hr>
						 </div>
					   </div>
					</div>
					
                       <div class="row">
                          <div class="from-group">
						    <div class="col-md-6">
						    </div>
						    <div class="col-md-3">
	                            <a href="frmVideosView.aspx" class ="btn btn-red btn-block"  ><i class="fa fa-arrow-circle-left"></i>
                                    Cancelar
                    		    </a>
						    </div>
						    <div class="col-md-3">
                                <input type="submit" formaction="frmVideosLoad.aspx" class="btn btn-blue btn-block" name="btnGuardar" value="Guardar" />						
						    </div>
                          </div>
                       </div>
                   
	    		 </div>
             </div>
         </div>
      </div>
    
    <script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<script src="assets/js/form-validation2.js"></script>
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
	<script src="assets/js/main.js"></script>
	<script>
	    jQuery(document).ready(function () {
	        FormValidator.init(13);
	    });
	</script>
           
	</asp:Content>