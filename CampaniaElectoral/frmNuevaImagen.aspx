<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevaImagen.aspx.cs" Inherits="CampaniaElectoral.frmNuevaImagen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <div class="container">
            <div class="row">
                <div class="col-md-12 ">
                    

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
                                             <asp:FileUpload CssClass="form-control fileupload" name="imgLogo" ID="fuploadImagen" runat="server" accept="image/jpeg" />
                                        </span>
                                        <a href="#" class="btn fileupload-exists btn-light-grey" data-dismiss="fileupload">
                                            <i class="fa fa-times"></i> Quitar
                                        </a>
                                    </div>
                                </div>
                            </div>                                    
                        </div>
                    </div>

                    Titulo de Imagen:
                    
                    
                    <asp:TextBox ID="txtTituloImagenViewA" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    
                    <div class="col-md-12">
                        <asp:Button ID="btnSubir" runat="server" Text="Subir foto" CssClass="btn btn-success" OnClick="btnSubir_Click" />
                        <a class="btn btn-primary" href="frmAfiliadosImagenesGrid.aspx"><i class="fa fa-close"></i>Cancelar</a>
                    </div>

                    
                    
                </div>
                
            </div>
       
          
        </div>

</asp:Content>