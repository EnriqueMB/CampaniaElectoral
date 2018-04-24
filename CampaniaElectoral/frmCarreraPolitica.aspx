<%@ Page Language="C#" Title="Carrera Politíca" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCarreraPolitica.aspx.cs" Inherits="CampaniaElectoral.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
 <div class="row">
     <div class="col-md-12">
     </div>
	   <div class="col-sm-12">
		  <div class="panel panel-white">
			 <div class="panel-heading">
					<h4 class="panel-title"><i aria-hidden="true"></i><span class="text-bold">Cargar Carrera Politíca</span></h4>
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
                         <div class="col-md-8">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtTitulo">
							        Titulo<span class="symbol required"></span>				
						        </label>
						        <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtTitulo" name="txtTitulo" placeholder="" maxlength="150" data-original-title="Ingrese el titulo que se le asignará." data-rel="tooltip"  title="" data-placement="top" />
							        <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
                           <div class="col-lg-4">
                             <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_txtFechaRealizado" >
                                    Fecha de inicio <span class="symbol required"></span>
                                </label>
                                <div class="input-group input-append bootstrap-datepicker">
                                    <input id="txtFechaRealizado" name="txtFechaRealizado" runat="server" type="text" data-date-format="dd-mm-yyyy" data-date-viewmode="years" class="form-control date-picker" readonly>
                                    <span class="input-group-addon add-on"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                          </div>
                      </div> 
                       <div class="row">
                           <div class="col-md-12">
                             <div class="form-group">
                              <label class="control-label" for="cph_MasterBody_txtDescription">
                                   Description<span class="symbol required"> </span>
                              </label>
                                <span class="input-icon">
                                    <textarea placeholder="" id="txtDescription" runat="server" name="txtDescription" class="form-control" ></textarea>
                                    <i class="fa fa-pencil"></i>
                                </span>
                              </div>
                          </div>
                       </div>
                      <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
								<label class="control-label">
									Fotograf&iacute;a a subir <span class="symbol required"></span>
								</label>
								<div class="fileupload fileupload-new" data-provides="fileupload">
									<div class="fileupload-new thumbnail">
                                        <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
									</div>                                            
									<div class="fileupload-preview fileupload-exists thumbnail"></div>
									<div>
										<span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i> Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                            <asp:FileUpload CssClass="fileupload" name="imgLogo" ID="imgLogo" runat="server" accept="image/jpeg" />
										</span>
										<a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
											<i class="fa fa-times"></i> Quitar
										</a>
									</div>
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
	                          <a href="frmViewCarreraPolitica.aspx" class ="btn btn-red btn-block"  ><i class="fa fa-arrow-circle-left"></i>
                                Cancelar
                    		  </a>
						  </div>
						  <div class="col-md-3">
                             <input type="submit" formaction="frmCarreraPolitica.aspx" class="btn btn-blue btn-block" name="btnGuardar" value="Guardar" />						
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
	        FormValidator.init(42);
	    });
	</script>
  </asp:Content>