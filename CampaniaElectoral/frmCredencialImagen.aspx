<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCredencialImagen.aspx.cs"MasterPageFile="~/Site.Master" Inherits="CampaniaElectoral.frmCredencialImagen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     
        <div class="modal-body">
              <div class="row">
                     <div class="col-12">
                         <img class="img-responsive" src="data:image/jpg;base64,<% = img.Imagen %>"/>
                                <br />
                              </div>
                            </div>
                         </div>
          <div class="row">
         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="txtTexto">
                                    Texto<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <input type="text" class="form-control tooltips" runat="server" id="txtTexto" name="txtTexto" placeholder="" maxlength="300"  data-rel="tooltip" title="" data-placement="top" readonly/>
                                    <i class="fa fa-keyboard-o"></i>
                                </span>
                            </div>
                        </div>
         </div>

 </asp:Content>
