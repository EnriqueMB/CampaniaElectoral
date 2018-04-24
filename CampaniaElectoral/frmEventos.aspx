<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos.aspx.cs" Inherits="CampaniaElectoral.frmEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">
     	
   

     <div class="row">
							<div class="col-md-12">
								<!-- start: INBOX PANEL -->
								<div class="panel panel-white">
									<div class="panel-heading">
										<h4>Buscar Actividades</h4>
                                     </div>
                                    <div class="panel-body">
                                         <div class="row">
							                <div class="col-md-6">

                                                <div class="form-group">
												<label class="col-sm-2 control-label">
													Buscar por Encargado
												</label>
												
												
													<div class="input-group">
														<input type="text" class="form-control">
														<span class="input-group-addon"><a href="#" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a></span>
													</div>
												
											
											</div>

                                            </div>
                                             <div class="col-md-6">
                                                 <div class="form-group">
												<label class="col-sm-2 control-label">
													Buscar por Fechas
												</label>
												
												
													<div class="input-group">
											       
											        <input type="text" class="form-control date-range" readonly style="cursor:pointer;">
                                                         <span class="input-group-addon"> <i class="fa fa-calendar"></i> </span>
										        </div>
												
											
											    </div>
                                            </div>
                                         </div>

                                    
                              
                                         <div class="row">
							                <div class="col-md-6">

                                                <div class="form-group">
												<label class="col-sm-2 control-label">
													Buscar por Tipo
												</label>
												
												
													<div class="input-group">
														<select id="form-field-select-1" class="form-control">
                                                    <option value="">&nbsp;</option>
                                                    <option value="AL">Proceso de Afiliación</option>
                                                    <option value="AK">Recorrido Zona Afiliación</option>
                                                    <option value="AZ">Entrega de Viveres</option>

                                                </select>
														<span class="input-group-addon"><a href="#" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a></span>
													</div>
												
											
											</div>

                                            </div>
                                             <div class="col-md-6">
                                                 <div class="form-group">
												<label class="col-sm-2 control-label">
													Buscar por Status
												</label>
												
												
													<div class="input-group">
											       <select id="form-field-select-1" class="form-control">
                                                    <option value="">&nbsp;</option>
                                                    <option value="AL">Status 1</option>
                                                    <option value="AK">Status 2</option>
                                                    <option value="AZ">Status 3</option>

                                                </select>
											       
                                                         <span class="input-group-addon"><a href="#" style="color:white;text-decoration:none;"><i class="fa fa-search"></i></a></span>
										        </div>
												
											
											    </div>
                                            </div>
                                         </div>

                                   </div>
                                    </div>
                                  
                                </div>
        </div>
    
     <div class="panel-body buttons-widget">
                                        <a class="btn btn-primary" href="frmNuevoEvento.aspx"><i class="fa fa-plus"></i> Nueva Actividad</a>
                                    </div>

    <table class="table table-striped table-bordered table-hover" id="projects">
												<thead>
													<tr>
														
														<th>Actividad</th>
														<th class="hidden-xs">Encargado</th>
														<th>Entrega</th>
                                                        <th class="hidden-xs">Objetivo</th>
                                                        <th class="hidden-xs">Avance</th>
                                                        <th class="hidden-xs center">Status</th>
														<th class="hidden-xs center">Visto</th>
														<th>Opciones</th>
													</tr>
												</thead>
												<tbody>
													<tr>

                                                        


														
														<td><span class="label label-orange">T1</span>Reparar Equipo de Computo X1 </td>
														<td class="hidden-xs">Gustavo Gómez</td>
														<td>11/11/2017 - 12:00</td>
														<td class="center hidden-xs"><span class="label label-primary">CONCLUIR</span></td>
                                                        <td class="center hidden-xs">-</td>
                                                        <td class="center hidden-xs"><span class="label label-info">TRAMITE</span></td>
														<td class="center hidden-xs"><span class="label label-warning"><i class="fa fa-share"></i></span></td>
														<td class="center">
														<div class="visible-md visible-lg hidden-sm hidden-xs">
															<a href="#" class="btn btn-light-blue tooltips" data-placement="top" data-original-title="Edit"><i class="fa fa-edit"></i></a>
															<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="fa fa-share"></i></a>
															<a href="#" class="btn btn-red tooltips" data-placement="top" data-original-title="Remove"><i class="fa fa-times fa fa-white"></i></a>
														</div>
														<div class="visible-xs visible-sm hidden-md hidden-lg">
															<div class="btn-group">
																<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
																	<i class="fa fa-cog"></i> <span class="caret"></span>
																</a>
																<ul role="menu" class="dropdown-menu dropdown-dark pull-right">
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-edit"></i> Editar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-share"></i> Archivar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-times"></i> Cancelar
																		</a>
																	</li>
																</ul>
															</div>
														</div></td>
													</tr>
													<tr>
														
														<td><span class="label label-orange">T2</span>Mantenimiento al Servidor Web </td>
														<td class="hidden-xs">José Gómez</td>
														<td>01/10/2017 - 12:00</td>
														<td class="center hidden-xs"><span class="label label-purple">1000</span></td>
                                                        <td class="center hidden-xs">
                                                            <div class="progress transparent-black no-radius">
                                                                <div aria-valuetransitiongoal="50" class="progress-bar partition-azure animate-progress-bar"></div>
                                                            </div>
                                                        </td>
														<td class="center hidden-xs"><span class="label label-danger">TRAMITE</span></td>
                                                        <td class="center hidden-xs"><span class="label label-primary"><i class="fa fa-thumbs-up"></i></span></td>
														<td class="center">
														<div class="visible-md visible-lg hidden-sm hidden-xs">
															<a href="#" class="btn btn-light-blue tooltips" data-placement="top" data-original-title="Edit"><i class="fa fa-edit"></i></a>
															<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="fa fa-share"></i></a>
															<a href="#" class="btn btn-red tooltips" data-placement="top" data-original-title="Remove"><i class="fa fa-times fa fa-white"></i></a>
														</div>
														<div class="visible-xs visible-sm hidden-md hidden-lg">
															<div class="btn-group">
																<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
																	<i class="fa fa-cog"></i> <span class="caret"></span>
																</a>
																<ul role="menu" class="dropdown-menu dropdown-dark pull-right">
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-edit"></i> Editar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-share"></i> Archivar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-times"></i> Cancelar
																		</a>
																	</li>
																</ul>
															</div>
														</div></td>
													</tr>
                                                    <tr>
														
														<td><span class="label label-orange">T3</span>Formatear Equipo de Computo</td>
														<td class="hidden-xs">William Núñez</td>
														<td>20/12/2017 - 11:00</td>
														<td class="center hidden-xs"><span class="label label-primary">CONCLUIR</span></td>
                                                        <td class="center hidden-xs">-</td>
														<td class="center hidden-xs"><span class="label label-success">CONCLUIDO</span></td>
                                                       <td class="center hidden-xs"><span class="label label-primary"><i class="fa fa-thumbs-up"></i></span></td>
														<td class="center">
														<div class="visible-md visible-lg hidden-sm hidden-xs">
															<a href="#" class="btn btn-light-blue tooltips" data-placement="top" data-original-title="Edit"><i class="fa fa-edit"></i></a>
															<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="fa fa-share"></i></a>
															<a href="#" class="btn btn-red tooltips" data-placement="top" data-original-title="Remove"><i class="fa fa-times fa fa-white"></i></a>
														</div>
														<div class="visible-xs visible-sm hidden-md hidden-lg">
															<div class="btn-group">
																<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
																	<i class="fa fa-cog"></i> <span class="caret"></span>
																</a>
																<ul role="menu" class="dropdown-menu dropdown-dark pull-right">
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-edit"></i> Editar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-share"></i> Archivar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-times"></i> Cancelar
																		</a>
																	</li>
																</ul>
															</div>
														</div></td>
													</tr>
                                                    <tr>
														
														<td><span class="label label-orange">T1</span>Instalar Disco Duro al servidor de Datos </td>
														<td class="hidden-xs">William Núñez</td>
														<td>01/09/2017 - 10:00</td>
														<td class="center hidden-xs"><span class="label label-primary">CONCLUIR</span></td>
                                                        <td class="center hidden-xs">-</td>
														<td class="center hidden-xs"><span class="label label-danger">TRAMITE</span></td>
                                                         <td class="center hidden-xs"><span class="label label-danger"><i class="fa fa-minus"></i></span></td>
                                                        
														<td class="center">
														<div class="visible-md visible-lg hidden-sm hidden-xs">
															<a href="#" class="btn btn-light-blue tooltips" data-placement="top" data-original-title="Edit"><i class="fa fa-edit"></i></a>
															<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="fa fa-share"></i></a>
															<a href="#" class="btn btn-red tooltips" data-placement="top" data-original-title="Remove"><i class="fa fa-times fa fa-white"></i></a>
														</div>
														<div class="visible-xs visible-sm hidden-md hidden-lg">
															<div class="btn-group">
																<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
																	<i class="fa fa-cog"></i> <span class="caret"></span>
																</a>
																<ul role="menu" class="dropdown-menu dropdown-dark pull-right">
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-edit"></i> Editar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-share"></i> Archivar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-times"></i> Cancelar
																		</a>
																	</li>
																</ul>
															</div>
														</div></td>
													</tr>
                                                    <tr>
														
														<td><span class="label label-orange">T2</span>Intalar Office 2016 Equipos de Recursos Humanos </td>
														<td class="hidden-xs">Martin Flores</td>
														<td>15/11/2017 - 12:00</td>
													    <td class="center hidden-xs"><span class="label label-primary">CONCLUIR</span></td>
                                                        <td class="center hidden-xs">-</td>
														<td class="center hidden-xs"><span class="label label-danger">TRAMITE</span></td>
                                                        <td class="center hidden-xs"><span class="label label-primary"><i class="fa fa-thumbs-up"></i></span></td>
														<td class="center">
														<div class="visible-md visible-lg hidden-sm hidden-xs">
															<a href="#" class="btn btn-light-blue tooltips" data-placement="top" data-original-title="Edit"><i class="fa fa-edit"></i></a>
															<a href="#" class="btn btn-green tooltips" data-placement="top" data-original-title="Share"><i class="fa fa-share"></i></a>
															<a href="#" class="btn btn-red tooltips" data-placement="top" data-original-title="Remove"><i class="fa fa-times fa fa-white"></i></a>
														</div>
														<div class="visible-xs visible-sm hidden-md hidden-lg">
															<div class="btn-group">
																<a class="btn btn-green dropdown-toggle btn-sm" data-toggle="dropdown" href="#">
																	<i class="fa fa-cog"></i> <span class="caret"></span>
																</a>
																<ul role="menu" class="dropdown-menu dropdown-dark pull-right">
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-edit"></i> Editar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-share"></i> Archivar
																		</a>
																	</li>
																	<li role="presentation">
																		<a role="menuitem" tabindex="-1" href="#">
																			<i class="fa fa-times"></i> Cancelar
																		</a>
																	</li>
																</ul>
															</div>
														</div></td>
													</tr>
												</tbody>
											</table>

</asp:Content>
