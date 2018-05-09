<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPartidoPoliticoAlianzaEdit.aspx.cs" Inherits="CampaniaElectoral.frmPartidoPoliticoAlianzaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

<div class="row"> 
    <div class="col-sm-12">
        <div class="panel panel-white">
            <div class="panel-heading">
			    <h4 class="panel-title">Cat&aacute;logo <span class="text-bold"> Partidos Pol&iacute;ticos </span></h4>
			</div>
            <div class="panel-body">
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
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
					                <div class="form-group">
						                <label class="control-label" for="cph_MasterBody_txtNombre">
							                Nombre <span class="symbol required"></span>				
						                </label>
						                <span class="input-icon">
                                            <asp:TextBox ID="txtNombre" runat="server" class="form-control tooltips" data-original-title="Ingrese el nombre del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top" maxlength="150"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valNombre" runat="server" 
                                                ErrorMessage="Por favor, ingrese un nombre de la alianza." 
                                                ControlToValidate="txtNombre" 
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
							                <i class="fa fa-building-o"></i>
                                        </span>
                                    </div>
					            </div>
                            </div>                            
                            <div class="row">
                                <div class="col-md-12">
				                    <div class="form-group">
				                        <label class="control-label" for="cph_MasterBody_txtSigla">
						                    Sigla <span class="symbol required"></span>
					                    </label>
                                        <span class="input-icon">
                                            <asp:TextBox ID="txtSigla" runat="server" class="form-control tooltips" maxlength="20" data-original-title="Ingrese la sigla del partido pol&iacute;tico" data-rel="tooltip"  title="" data-placement="top"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valSigla" runat="server" 
                                                ErrorMessage="Por favor, ingrese unas siglas para la alianza." 
                                                ControlToValidate="txtSigla" 
                                                ForeColor="Red">
                                            </asp:RequiredFieldValidator>
							                <i class="fa fa-file-text"></i>
                                        </span>
					                </div>
                                </div>
                            </div>
                        </div>
                               <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
								        <label class="control-label">
									        Logo de la alianza <span class="symbol required"></span>
								        </label>
								        <div class="fileupload fileupload-new" data-provides="fileupload">
									        <div class="fileupload-new thumbnail">
                                                <img src="assets/images/NoImage.png" alt="" id="Logo" runat="server" />
									        </div>                                            
									        <div class="fileupload-preview fileupload-exists thumbnail"></div>
									        <div>
										        <span class="btn btn-light-grey btn-file"><span class="fileupload-new"><i class="fa fa-picture-o"></i> Seleccione una imagen</span><span class="fileupload-exists"><i class="fa fa-picture-o"></i> Cambiar</span>
                                                    <asp:FileUpload CssClass="fileupload form-control" name="imgLogo" accept=".png, .jpg, .jpeg, .PNG, .JPG, .JPEG" ID="imgLogo" runat="server" />
                                                    <asp:CustomValidator id="valExtensionLogo" runat="server" 
                                                        OnServerValidate="ValidarImagenExtension" 
                                                        ControlToValidate="imgLogo"
                                                        ValidateEmptyText ="true"
                                                        ErrorMessage = ""
                                                    >
                                                    </asp:CustomValidator>
										        </span>
										        <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
											        <i class="fa fa-times"></i> Quitar
										        </a>
									        </div>
								        </div>
						            </div>                                    
                                </div>
                            </div>
                        </div>
                </div>
                  <div class="row">
                        <div class="col-md-12" id="divPartidoPolitico" runat="server">
                            <div class="form-group">
                                <label class="control-label" for="cmbPartidosPoliticos">
                                    Partidos Políticos <span class="symbol required"></span>
                                </label>
                                <asp:ListBox SelectionMode="Multiple" ID="cmbPartidosPoliticos" runat="server"  class="form-control selectpicker" multiple data-live-search="true" data-none-selected-text="--Seleccione--"></asp:ListBox>
                                 <asp:RequiredFieldValidator ID="valPartidoPolitico" runat="server" 
                                    ErrorMessage="Por favor, seleccione un partido político." 
                                    ControlToValidate="cmbPartidosPoliticos" 
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
					    <div class="col-md-12">
						    <div>
							    <span class="symbol required"></span> Campos Requeridos
							    <hr>
						    </div>
					    </div>
				    </div>
                    <div class="row">
                        <div class="col-md-6"></div>
                        <div class="col-md-6">
                            <div class="form-group">
				                <div class="col-md-6">
                                    <input type="submit" formaction="frmPartidoPoliticoAlianzaCrear.aspx" class="btn btn-green btn-block" name ="btnGuardar" value="Guardar" />
                                </div>
                                <div class="col-md-6">
                                    <a href="frmPartidosPoliticosAlianzasGrid.aspx" class ="btn btn-red btn-block" name ="btnCancelar" >Cancelar</a>
                                </div>
					        </div>
                        </div>
                    </div>
                   
            </div>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
