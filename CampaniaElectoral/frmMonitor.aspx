<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMonitor.aspx.cs" Inherits="CampaniaElectoral.frmMonitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

      <div class="row">
							<div class="col-md-12">
								<!-- start: INBOX PANEL -->
								<div class="panel panel-white">
                                    <div class="panel-heading">
										<h4>Datos de Proyectos</h4>
                                     </div>
                                   
									 <div class="panel-body">

                                     


                                         <div class="row">
							<div class="col-md-7 col-lg-4">
								<div class="panel panel-bricky">
									<div class="panel-heading border-light">
										<h4 class="panel-title">Proyectos <span class="text-bold">Total : 1000</span></h4>
										<div class="panel-tools">
											
										</div>
									</div>
									<div class="panel-body">
                                        
										<div class="row">
											<div class="col-md-5">
												<div id='chart3'>
													<svg></svg>
												</div>
											</div>
											<div class="col-md-7">
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">500</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Concluido (CN)</span>
												</div>
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">400</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Tramite (Tr)</span>
												</div>
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">100</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Cancelado (CL)</span>
												</div>
											</div>
										</div>
									</div>
									<div class="panel-footer partition-white">
										<div class="clearfix padding-5 space5">
											<br/><br/>
										
										</div>
									</div>
								</div>
							</div>

							<div class="col-lg-4 col-md-5">
								<div class="panel panel-red panel-calendar">
									<div class="panel-heading border-light">
										<h4 class="panel-title">Actividades Recientes</h4>
									
									</div>
									<div class="panel-body">
										<div class="height-300">
											<div class="row">
												<div class="col-xs-6">
													<div class="actual-date">
														<span class="actual-day"></span>
														<span class="actual-month"></span>
													</div>
												</div>
												<div class="col-xs-6">
													<div class="row">
														<div class="col-xs-12">
															<div class="clock-wrapper">
																<div class="clock">
																	<div class="circle">
																		<div class="face">
																			<div id="hour"></div>
																			<div id="minute"></div>
																			<div id="second"></div>
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
													<div class="row">
														<div class="col-xs-12">
															<div class="weather text-light">
																<i class="wi-day-sunny"></i>
																25°
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="row">
												<div class="col-xs-12">
													<div class="row">
														<div class="appointments border-top border-bottom border-light space15">
															<a class="btn btn-sm owl-prev text-light">
																<i class="fa fa-chevron-left"></i>
															</a>
															<div class="e-slider owl-carousel owl-theme" data-plugin-options='{"transitionStyle": "goDown", "pagination": false}'>
																<div class="item">
																	<div class="inline-block padding-10 border-right border-light">
																		<span class="bold-text text-small"><i class="fa fa-clock-o"></i> 17:00</span>
																		<span class="text-light text-extra-small">1 Hora</span>
																	</div>
																	<div class="inline-block padding-10">
																		<span class="bold-text text-small">Reparación de Equipos</span>
																		<span class="text-light text-small">Concluido Correctamente</span>
																	</div>
																</div>
																<div class="item">
																	<div class="inline-block padding-10 border-right border-light">
																		<span class="bold-text text-small"><i class="fa fa-clock-o"></i> 18:30</span>
																		<span class="text-light text-extra-small">30 minutoss</span>
																	</div>
																	<div class="inline-block padding-10">
																		<span class="bold-text text-small">Compra de Alimentos</span>
																		<span class="text-light text-small">Concluida Correctamente</span>
																	</div>
																</div>
																<div class="item">
																	<div class="inline-block padding-10 border-right border-light">
																		<span class="bold-text text-small"><i class="fa fa-clock-o"></i> 20:00</span>
																		<span class="text-light text-extra-small">2 houras</span>
																	</div>
																	<div class="inline-block padding-10">
																		<span class="bold-text text-small">Formateo de PC del Director</span>
																		<span class="text-light text-small">Concluido Correctamente</span>
																	</div>
																</div>
															</div>
															<a class="btn btn-sm owl-next text-light"><i class="fa fa-chevron-right"></i> </a>
														</div>
													</div>
												</div>
											</div>
											
										</div>
									</div>
								</div>
							</div>
							<div class="col-lg-4 col-md-5">
							<div class="panel panel-white">
									<div class="panel-heading border-light">
										<h4 class="panel-title">Mejor Encargado de Proyectos</h4>
										<div class="panel-tools">
											
											
										</div>
									</div>
									<div class="panel-body no-padding">
										<div class="padding-10">
											<img width="50" height="50" alt="" class="img-circle pull-left" src="assets/images/avatar-1-big.jpg">
											<h4 class="no-margin inline-block padding-5">William Nuñez <span class="block text-small text-left">Ing. Sistemas</span></h4>
											<div class="pull-right padding-15">
												<span class="text-small text-bold text-green"><i class="fa fa-dot-circle-o"></i> </span>
											</div>
										</div>
										<div class="clearfix padding-5 space5">
											<div class="col-xs-4 text-center no-padding">
												<div class="border-right border-dark">
													<a href="#" class="text-dark">
														<i class="fa fa-heart-o text-red"></i> 250
													</a>
												</div>
											</div>
											<div class="col-xs-4 text-center no-padding">
												<div class="border-right border-dark">
													<a href="#" class="text-dark">
														<i class="fa fa-bookmark-o text-green"></i> 30
													</a>
												</div>
											</div>
											<div class="col-xs-4 text-center no-padding">
												<a href="#" class="text-dark"><i class="fa fa-comment-o text-azure"></i> 280</a>
											</div>
										</div>
										<div class="tabbable no-margin no-padding partition-dark">
											<ul class="nav nav-tabs" id="myTab">
												<li class="active">
													<a data-toggle="tab" href="#users_tab_example1">
														Los mejores
													</a>
												</li>
                                                <li class="">
													<a data-toggle="tab" href="#users_tab_example2">
														Los peores
													</a>
												</li>
											
											</ul>
											<div class="tab-content partition-white">
												<div id="users_tab_example1" class="tab-pane padding-bottom-5 active">
													<div class="panel-scroll height-200">
														<table class="table table-striped table-hover">
															<tbody>
																
																<tr>
																	<td class="center"><img src="assets/images/avatar-2.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Content Designer</span><span class="text-large">Nicole Bell</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">2</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
																<tr>
																	<td class="center"><img src="assets/images/avatar-3.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Visual Designer</span><span class="text-large">Steven Thompson</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">3</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
																<tr>
																	<td class="center"><img src="assets/images/avatar-5.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Senior Designer</span><span class="text-large">Kenneth Ross</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">4</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
																<tr>
																	<td class="center"><img src="assets/images/avatar-4.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Web Editor</span><span class="text-large">Ella Patterson</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">5</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
															</tbody>
														</table>
													</div>
												</div>
												<div id="users_tab_example2" class="tab-pane padding-bottom-5">
													<div class="panel-scroll height-200">
														<table class="table table-striped table-hover">
															<tbody>
																<tr>
																	<td class="center"><img src="assets/images/avatar-3.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Visual Designer</span><span class="text-large">Steven Thompson</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">3</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
																<tr>
																	<td class="center"><img src="assets/images/avatar-5.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Senior Designer</span><span class="text-large">Kenneth Ross</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">2</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
																<tr>
																	<td class="center"><img src="assets/images/avatar-4.jpg" class="img-circle" alt="image"/></td>
																	<td><span class="text-small block text-light">Web Editor</span><span class="text-large">Ella Patterson</span></td>
																	<td class="center">
																	<div>
																		<div class="btn-group">
																			
																				 <span class="caret" style="font-size:large;">1</span>
																			
																			
																		</div>
																	</div></td>
																</tr>
															</tbody>
														</table>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>


                                     
                                     
                                     </div>
                                    </div>
                                </div>
          </div>


    <div class="row">
							<div class="col-md-12">
								<!-- start: INBOX PANEL -->
								<div class="panel panel-white">
                                    <div class="panel-heading">
										<h4>Datos de Actividades</h4>
                                     </div>
                                   
									 <div class="panel-body">

                                     <div class="row">


                          <div class="col-md-7 col-lg-4">
								<div class="panel panel-bricky">
									<div class="panel-heading border-light">
										<h4 class="panel-title">Actividaes <span class="text-bold">Total : 10000</span></h4>
										
									</div>
									<div class="panel-body">
                                        
								        <div class="row">
											<div class="col-md-5">
												<div id='chart33'>
													<svg></svg>
												</div>
											</div>
											<div class="col-md-7">
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">5000</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Concluido (CN)</span>
												</div>
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">4000</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Tramite (Tr)</span>
												</div>
												<div class="space20 padding-5 border-bottom border-light">
													<h4 class="pull-left no-margin space5">1000</h4>
													
													<div class="clearfix"></div>
													<span class="text-light">Cancelado (CL)</span>
												</div>
											</div>
										</div>
									</div>
									<div class="panel-footer partition-white">
										<div class="clearfix padding-5 space5">
											<div class="col-xs-6 text-center no-padding">
												<div class="border-right border-dark">
													<span class="text-bold block text-extra-large">90%</span>
													<span class="text-light">Correcto</span>
												</div>
											</div>
											<div class="col-xs-6 text-center no-padding">
												
													<span class="text-bold block text-extra-large">10%</span>
													<span class="text-light">Incorrecto</span>
												
											</div>
										
										</div>
									</div>






                                   
								</div>
							</div>


                            <div class="col-lg-8 col-md-7">
								<div class="panel panel-white">
									<div class="panel-heading border-light">
										<h4 class="panel-title">Actividades Semanales</h4>
										<ul class="panel-heading-tabs border-light">
											<li>
												<div id="reportrange" class="pull-right">
													<span>Está Semana </span><i class="fa fa-angle-down"></i>
												</div>
											</li>
											<li>
												<div class="rate">
													<i class="fa fa-caret-up text-green"></i><span class="value">15</span><span class="percentage">%</span>
												</div>
											</li>
											
										</ul>
									</div>
									<div class="panel-body no-padding partition-green">
										<div class="col-md-3 col-lg-2 no-padding">
											<div class="partition-body padding-15">
												<ul class="mini-stats">
													<li class="col-md-12 col-sm-4 col-xs-4 no-padding">
														<div class="sparkline-bar sparkline-1">
															<span></span>
														</div>
														<div class="values">
															<strong>1,235</strong>
															Concluidas
														</div>
													</li>
													<li class="col-md-12 col-sm-4 col-xs-4 no-padding">
														<div class="sparkline-bar sparkline-2">
															<span></span>
														</div>
														<div class="values">
															<strong>2,833</strong>
															Solicitadas
														</div>
													</li>
													<li class="col-md-12 col-sm-4 col-xs-4 no-padding">
														<div class="sparkline-bar sparkline-3">
															<span></span>
														</div>
														<div class="values">
															<strong>268</strong>
															Canceladas
														</div>
													</li>
												</ul>
											</div>
										</div>
										<div class="col-md-9 col-lg-10 no-padding partition-white">
											<div class="partition">
												<div class="partition-body padding-15">
													<div class="height-300">
														<div id="chart1" class='with-3d-shadow with-transitions'>
															<svg></svg>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>




                                     </div>
                                     
                                     
                                     </div>
                                    </div>
                                </div>
          </div>


    <div class="row">
							<div class="col-md-12">
								<!-- start: INBOX PANEL -->
								<div class="panel panel-white">
                                    <div class="panel-heading">
										<h4>Datos de Equipos</h4>
                                     </div>
                                   
									 <div class="panel-body">

                                     
                                     
                                     
                                     </div>
                                    </div>
                                </div>
          </div>
</asp:Content>