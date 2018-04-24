<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCalendario.aspx.cs" Inherits="CampaniaElectoral.frmCalendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_MasterBody" runat="server">

    <!-- start: PAGE CONTENT -->
						<div class="row">
							<div class="col-sm-12">
								<!-- start: FULL CALENDAR PANEL -->
								<div class="panel panel-white">
									<div class="panel-heading">
										<i class="fa fa-calendar"></i>
										Agenda personal
									</div>
									<div class="panel-body">
										<%--<div class="col-sm-12 space20">
											<a href="#newFullEvent" class="btn btn-green add-event"><i class="fa fa-plus"></i> Agregar evento </a>
										</div>--%>
										<div class="col-sm-12">
											<div id='full-calendar'></div>
										</div>
										<div class="col-sm-3">
											<%--<h4 class="space20">Draggable categories</h4>
											<div id="event-categories">
												<div class="event-category event-generic" data-class="event-generic">
													Generic
												</div>
												<div class="event-category event-home" data-class="event-home">
													Home
												</div>
												<div class="event-category event-overtime" data-class="event-overtime">
													Overtime
												</div>
												<div class="event-category event-job" data-class="event-job">
													Job
												</div>
												<div class="event-category event-offsite" data-class="event-offsite">
													Off-site work
												</div>
												<div class="event-category event-todo" data-class="event-todo">
													To Do
												</div>
												<div class="event-category event-cancelled" data-class="event-cancelled">
													Cancelled
												</div>
												<div class="checkbox">
													<label>
														<input type="checkbox" class="grey" id="drop-remove" />
														Remove after drop
													</label>
												</div>
											</div>--%>
										</div>
									</div>
								</div>
								<!-- end: FULL CALENDAR PANEL -->
							</div>
						</div>
						<!-- end: PAGE CONTENT-->

    <!-- start: MAIN JAVASCRIPTS -->
	<!--[if lt IE 9]>
	<script src="assets/plugins/respond.min.js"></script>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script type="text/javascript" src="assets/plugins/jQuery/jquery-1.11.1.min.js"></script>
	<![endif]-->
	<!--[if gte IE 9]><!-->
	<script src="assets/plugins/jQuery/jquery-2.1.1.min.js"></script>
	<!--<![endif]-->
    
    
    <script>
			jQuery(document).ready(function() {
                Calendar.init();
			});
		</script>
</asp:Content>
