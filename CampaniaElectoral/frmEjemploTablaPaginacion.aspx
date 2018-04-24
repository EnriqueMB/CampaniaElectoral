<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEjemploTablaPaginacion.aspx.cs" Inherits="CampaniaElectoral.frmEjemploTablaPaginacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
    <div class="row">
							<div class="col-sm-6">
								<!-- start: COLOR PICKER PANEL -->
								<div class="panel panel-white">
									<div class="panel-heading">
										<h4 class="panel-title">Color <span class="text-bold">Picker</span></h4>
										<div class="panel-tools">
											<div class="dropdown">
												<a data-toggle="dropdown" class="btn btn-xs dropdown-toggle btn-transparent-grey">
													<i class="fa fa-cog"></i>
												</a>
												<ul class="dropdown-menu dropdown-light pull-right" role="menu">
													<li>
														<a class="panel-collapse collapses" href="#"><i class="fa fa-angle-up"></i> <span>Collapse</span> </a>
													</li>
													<li>
														<a class="panel-refresh" href="#">
															<i class="fa fa-refresh"></i> <span>Refresh</span>
														</a>
													</li>
													<li>
														<a class="panel-config" href="#panel-config" data-toggle="modal">
															<i class="fa fa-wrench"></i> <span>Configurations</span>
														</a>
													</li>
													<li>
														<a class="panel-expand" href="#">
															<i class="fa fa-expand"></i> <span>Fullscreen</span>
														</a>
													</li>
												</ul>
											</div>
											<a class="btn btn-xs btn-link panel-close" href="#">
												<i class="fa fa-times"></i>
											</a>
										</div>
									</div>
									<div class="panel-body">
										<div class="form-group">
											<label>
												Default
											</label>
											<div>
												<input type="text" value="#8fff00" class="form-control color-picker">
											</div>
										</div>
										<div class="form-group">
											<label>
												RGBA
											</label>
											<div>
												<input type="text" value="rgb(0,194,255,0.78)" class="form-control color-picker-rgba">
											</div>
										</div>
										<div class="form-group">
											<label>
												As Component
											</label>
											<div class="input-group colorpicker-component" data-color="rgb(81, 145, 185)" data-color-format="rgb">
												<input type="text" value="" readonly class="form-control">
												<span class="input-group-addon"><i></i></span>
											</div>
										</div>
										<div class="form-group">
											<label>
												Color Palette
											</label>
											<div class="input-group">
												<input type="text" value="" class="form-control" id="selectedcolor1">
												<span class="btn input-group-addon btn-azure" data-toggle="dropdown">color</span>
												<ul class="dropdown-menu pull-right center">
													<li>
														<div class="color-palette"></div>
													</li>
												</ul>
											</div>
										</div>
									</div>
								</div>
								<!-- end: COLOR PICKER PANEL -->
							</div>
							<div class="col-sm-6">
								<!-- start: TAGS PANEL -->
								<div class="panel panel-white">
									<div class="panel-heading">
										<h4 class="panel-title">Tags</h4>
										<div class="panel-tools">
											<div class="dropdown">
												<a data-toggle="dropdown" class="btn btn-xs dropdown-toggle btn-transparent-grey">
													<i class="fa fa-cog"></i>
												</a>
												<ul class="dropdown-menu dropdown-light pull-right" role="menu">
													<li>
														<a class="panel-collapse collapses" href="#"><i class="fa fa-angle-up"></i> <span>Collapse</span> </a>
													</li>
													<li>
														<a class="panel-refresh" href="#">
															<i class="fa fa-refresh"></i> <span>Refresh</span>
														</a>
													</li>
													<li>
														<a class="panel-config" href="#panel-config" data-toggle="modal">
															<i class="fa fa-wrench"></i> <span>Configurations</span>
														</a>
													</li>
													<li>
														<a class="panel-expand" href="#">
															<i class="fa fa-expand"></i> <span>Fullscreen</span>
														</a>
													</li>
												</ul>
											</div>
											<a class="btn btn-xs btn-link panel-close" href="#">
												<i class="fa fa-times"></i>
											</a>
										</div>
									</div>
									<div class="panel-body">
										<label>
											Defaults:
										</label>
										<input id="tags_1" type="text" class="tags" value="foo,bar,baz,roffle">
									</div>
								</div>
								<!-- end: TAGS PANEL -->
							</div>
						</div>
</asp:Content>
