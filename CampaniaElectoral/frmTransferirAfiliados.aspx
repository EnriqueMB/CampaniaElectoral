<%@ Page Language="C#"  Title="Transferir Afiliados" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTransferirAfiliados.aspx.cs" Inherits="CampaniaElectoral.frmTransferirAfiliados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-white">
                <div class="panel-heading">
                    <h4 class="panel-title"><span class="text-bold">Transferir Afiliados</span></h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <asp:HiddenField ID="hf" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="errorHandler alert alert-danger no-display">
                                <i class="fa fa-times-sign"></i>Hay errores en la captura de información. Revise las especificaciones de los campos.
                            </div>
                            <div class="successHandler alert alert-success no-display">
                                <i class="fa fa-ok"></i>Your form validation is successful!
                            </div>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbSeccion">
                                    Seccion<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <asp:DropDownList runat="server" ID="cmbSeccion" AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" Width="250" OnSelectedIndexChanged="cmbSeccion_SelectedIndexChanged" CssClass="required">
                                        <%--<asp:ListItem Text="--SELLECCIONE--" Value="0" Selected="True"/>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ErrorMessage=" Seleccione una seccion" ControlToValidate="cmbSeccion" runat="server" ForeColor="Red" InitialValue=""/>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbOperadorOrigen">
                                    Operador Origen<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <asp:DropDownList runat="server" ID="cmbOperadorOrigen" AutoPostBack="true" Width="250" OnSelectedIndexChanged="cmbOperadorOrigen_SelectedIndexChanged">
                                    <asp:ListItem Text="--SELLECCIONE--" Value="0" Selected="True"/>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ErrorMessage=" Seleccion un operador origen" ControlToValidate="cmbOperadorOrigen" runat="server" ForeColor="Red" InitialValue="0"/>
                                </span>
                            </div>
                        </div>
   
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" for="cph_MasterBody_cmbOperadorDestino">
                                   Opedaro destino<span class="symbol required"></span>
                                </label>
                                <span class="input-icon">
                                    <asp:DropDownList runat="server" ID="cmbOperadorDestino" ViewStateMode="Enabled" EnableViewState="true" Width="250">
                                    <asp:ListItem Text="--SELLECCIONE--" Value="0" Selected="True"/>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ErrorMessage=" Seleccione un operador destino" ControlToValidate="cmbOperadorDestino" runat="server" InitialValue="0" ForeColor="Red"/>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">       
                        <div class="col-md-6">
                            <div class="panel panel-body">
                                <%foreach (var item in afiliados)
                                    {
                                    %>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="control-label" for="cph_MasterBody_cmbOperadorDestino">
                                            <%=item.Nombre %>
                                        </label>
                                    </div>
                                    <div class="col-md-6">
                                        <%Response.Write("<input type='checkbox' name='check"+item.IDAfiliado.ToString()+"' id='check"+item.IDAfiliado.ToString()+"' runat='server' class='checkbox fa-check' checked='checked'/>"); %>
                                        <%--<input type="checkbox" name="check" id="check" runat="server" aria-atomic="true" checked="checked"/>--%>
                                    </div>
                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                    <div class="row ">
                        <%--<div class="col-md-12"></div>--%>
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="form-group pull-left">  
                                    <div class="col-md-6">
                                    <input type="button" class="btn btn-dark-grey btn-block" name="btnMarcar" value="Marcar todos" onclick="marcar();"/>
                                </div>
                                <div class="col-md-6">
                                    <input type="button" class="btn btn-dark-grey btn-block" name="btnDesmarcar" value="Desmarcar todos" onclick="desmarcar();"/>
                                </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <span class="symbol required"></span>Campos Requeridos
                                <hr>
                            </div>
                        </div>
                    </div>
                    <div class="row ">
                        <%--<div class="col-md-12"></div>--%>
                        <div class="col-md-12">
                            <div class="form-group pull-right">
                                <div class="col-md-6">
                                    <input type="submit" formaction="frmTransferirAfiliados.aspx" class="btn btn-green btn-block" name="btnGuardar" value="Guardar"/>
                                </div>
                                <div class="col-md-6">
                                    <a href="frmEjemplo.aspx" class="btn btn-red btn-block" name="btnCancelar">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- start: MAIN JAVASCRIPTS -->
    <!--[if lt IE 9]>
        <script src="assets/plugins/respond.min.js"></script>
        <script src="assets/plugins/excanvas.min.js"></script>
        <script type="text/javascript" src="assets/plugins/jQuery/jquery-1.11.1.min.js"></script>
    <![endif]-->
    <!--[if gte IE 9]><!-->
    <script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
    <!--<![endif]-->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="assets/js/form-validation2.js"></script>
    <script src="assets/js/ui-notifications.js"></script>
    <script src="assets/plugins/sweetalert/lib/sweet-alert.min.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <!-- start: CORE JAVASCRIPTS  -->
    <script src="assets/js/main.js"></script>
    <script src="assets/js/maps.js"></script>
    <!-- end: CORE JAVASCRIPTS  -->
    <script type="text/javascript">
        
        function marcar() 
	    {
		    checkboxes=document.getElementsByTagName('input'); //obtenemos todos los controles del tipo Input
		    for(i=0;i<checkboxes.length;i++) //recoremos todos los controles
		    {
			    if(checkboxes[i].type == "checkbox") //solo si es un checkbox entramos
			    
				    checkboxes[i].checked=1; //si es un checkbox le damos el valor del checkbox que lo llamó (Marcar/Desmarcar Todos)
			    
		    }
	    }

        function desmarcar() 
	    {
		    checkboxes=document.getElementsByTagName('input'); //obtenemos todos los controles del tipo Input
		    for(i=0;i<checkboxes.length;i++) //recoremos todos los controles
		    {
			    if(checkboxes[i].type == "checkbox") //solo si es un checkbox entramos
			    
				    checkboxes[i].checked=0; //si es un checkbox le damos el valor del checkbox que lo llamó (Marcar/Desmarcar Todos)
			    
		    }
	    }
    </script>
    <script>
        jquery(document).ready(function () {
            formvalidator.init(46);
        });
    </script>

</asp:Content>