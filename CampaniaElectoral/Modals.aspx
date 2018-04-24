<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modals.aspx.cs" Inherits="CampaniaElectoral.Modals" %>

									<div class="row">
							<div class="col-md-12">
								<div class="panel panel-white">
									<div class="panel-heading">
										<h4 class="panel-title">Bootstrap <span class="text-bold">Native Modals</span> indicator</h4>
									</div>
									<div class="panel-body">
										<p>
											Modals are streamlined, but flexible, dialog prompts with the minimum required functionality and smart defaults.
										</p>
										<table class="table table-hover table-striped table-bordered">
											<tbody>
												<tr>
													<td class="col-xs-6"><h5><span class="text-bold">Basic</span> Example</h5>
													<p>
														Toggle a modal via JavaScript by clicking the button on the right. It will slide down and fade in from the top of the page.
													</p></td>
													<td class="col-xs-6">
													<button data-target=".bs-example-modal-basic" data-toggle="modal" class="btn btn-blue">
														View Demo
													</button></td>
												</tr>
												<tr>
													<td class="col-xs-6"><h5><span class="text-bold">Large Width</span> Example </h5>
													<p>
														Large Modal Size vailable by adding <code> .modal-lg </code>
														on a <code> .modal-dialog </code>
														.
													</p></td>
													<td class="col-xs-6">
													<button data-target=".bs-example-modal-lg" data-toggle="modal" class="btn btn-blue">
														View Demo
													</button></td>
												</tr>
												<tr>
													<td class="col-xs-6"><h5><span class="text-bold">Small Width</span> Example </h5>
													<p>
														Small Modal Size vailable by adding <code> .modal-sm </code>
														on a <code> .modal-dialog </code>
														.
													</p></td>
													<td class="col-xs-6">
													<button data-target=".bs-example-modal-sm" data-toggle="modal" class="btn btn-blue">
														View Demo
													</button></td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
							</div>
						</div>

    <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal bs-example-modal-basic fade">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
								×
							</button>
							<h4 id="myModalLabel" class="modal-title">Modal Heading</h4>
						</div>
						<div class="modal-body">
							<h4>Text in a modal</h4>
							<p>
								Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
							</p>
							<h4>Popover in a modal</h4>
							<p>
								This <a data-content="And here's some amazing content. It's very engaging. right?" title="" class="btn btn-default popovers" role="button" href="#" data-original-title="A Title">
									button</a>
								should trigger a popover on click.
							</p>
							<h4>Tooltips in a modal</h4>
							<p>
								<a title="" class="tooltips" href="#" data-original-title="Tooltip">
									This link</a>
								and <a title="" class="tooltips" href="#" data-original-title="Tooltip">
									that link</a>
								should have tooltips on hover.
							</p>
							<hr>
							<h4>Overflowing text to show scroll behavior</h4>
							<p>
								Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
							</p>
							<p>
								Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.
							</p>
							<p>
								Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.
							</p>
							<p>
								Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
							</p>
							<p>
								Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.
							</p>
							<p>
								Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.
							</p>
							<p>
								Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
							</p>
							<p>
								Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.
							</p>
							<p>
								Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.
							</p>
						</div>
						<div class="modal-footer">
							<button data-dismiss="modal" class="btn btn-default" type="button">
								Close
							</button>
							<button class="btn btn-primary" type="button">
								Save changes
							</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- Large modal -->
			<div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<div class="modal-header">
							<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
								×
							</button>
							<h4 id="myLargeModalLabel" class="modal-title">Modal Heading</h4>
						</div>
						<div class="modal-body">
							<p>
								Your content here.
							</p>
						</div>
						<div class="modal-footer">
							<button data-dismiss="modal" class="btn btn-default" type="button">
								Close
							</button>
							<button class="btn btn-primary" type="button">
								Save changes
							</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
			</div>
			<!-- Small modal -->
			<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
				<div class="modal-dialog modal-sm">
					<div class="modal-content">
						<div class="modal-header">
							<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
								×
							</button>
							<h4 id="mySmallModalLabel" class="modal-title">Modal Heading</h4>
						</div>
						<div class="modal-body">
							<p>
								Your content here.
							</p>
						</div>
						<div class="modal-footer">
							<button data-dismiss="modal" class="btn btn-default" type="button">
								Close
							</button>
							<button class="btn btn-primary" type="button">
								Save changes
							</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
			</div>
