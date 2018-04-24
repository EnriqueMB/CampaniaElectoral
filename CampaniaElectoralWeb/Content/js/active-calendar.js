   $('#calendar').fullCalendar({
               header: {
                    
				        left: 'today,prev,next',
				        center: 'title',
				        right: 'month,agendaWeek,agendaDay'
                },
                    
			        //defaultDate: '2017-09-01',
			        navLinks: true, // can click day/week names to navigate views

			        weekNumbers: false,
			        weekNumbersWithinDays: true,
			        weekNumberCalculation: 'ISO',

			        editable: false,
			        eventLimit: false, // allow "more" link when too many events
			        eventSources: [
                           {
                               url: '/sfrmCalendar.aspx',
                               type: 'POST',
                               data: { TypeEvent: '1' },
                               error: function () {
                                   alert('Ocurrió un error al cargar eventos.');
                               },
                               cache: false
                           }],
        });