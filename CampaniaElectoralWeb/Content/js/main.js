(function ($) {
 "use strict";
 
    /*----------------------------
    jQuery MeanMenu
    ------------------------------ */
    $('nav#dropdown').meanmenu({
        meanScreenWidth: "991",
        meanMenuContainer: ".mobile-menu",
    });
    
    /*----------------------------
     counter js active
    ------------------------------ */
    $('.counter').counterUp({
        delay: 10,
        time: 2000
    });
    
    /*----------------------------
     owl active
    ------------------------------ */  
    $('.slider-active').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 4,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [980,2],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
     owl active
    ------------------------------ */  
    $('.slider-active2').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 3,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [980,2],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
     owl active
    ------------------------------ */  
    $('.slider-active3').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 1,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,1],
        itemsDesktopSmall : [980,1],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
     owl active
    ------------------------------ */  
    $('.slider-active4').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 3,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [980,2],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
     owl active
    ------------------------------ */  
    $('.slider-active5').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 4,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,4],
        itemsDesktopSmall : [980,2],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
    owl active brand-logo
    ------------------------------ */  
    $('.slider-active6').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:true,
        navigation:false,	  
        items : 1,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        itemsDesktop : [1199,1],
        itemsDesktopSmall : [980,1],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });
    
    /*----------------------------
    owl active brand-logo
    ------------------------------ */  
    $('.three-tab2').owlCarousel({
        autoPlay: false, 
        slideSpeed:2000,
        pagination:false,
        navigation:true,	  
        items : 4,
        /* transitionStyle : "fade", */    /* [This code for animation ] */
        navigationText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
        itemsDesktop : [1199,4],
        itemsDesktopSmall : [980,3],
        itemsTablet: [767,1],
        itemsMobile : [479,1],
    });

    /*--------------------------
    scrollUp
    ---------------------------- */	
    $(window).on('scroll',function () {
        if($(window).scrollTop()>200) {
            $("#toTop").fadeIn();
        } else {
            $("#toTop").fadeOut();
        }
    });
    $('#toTop').on('click', function() {
        $("html,body").animate({
            scrollTop:0
        }, 500)
    });   
    
    /*--
    Magnific Popup
    ------------------------*/
    $('.video-popup').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        zoom: {
            enabled: true,
        }
    });
    
    /*---------------------
    countdown
    --------------------- */
    $('[data-countdown]').each(function() {
		var $this = $(this), finalDate = $(this).data('countdown');
		$this.countdown(finalDate, function(event) {
            $this.html(event.strftime('<span class="cdown day">%-D <p>Days</p></span> <span class="cdown hour">%-H <p>Hour</p></span> <span class="cdown minutes">%M <p>Min</p></span class="cdown second"> <span>%S <p>Sec</p></span>'));
		});
    });
    
    //venbox start
    $('.venobox').venobox({
        numeratio: true,
        infinigall: true,
        titleattr: 'data-title'
    })
    //venbox end
    
    /*---------------------
    chosen
    --------------------- */
    jQuery('.orderby').chosen({disable_search: true, width: "auto"});
    
    /*----------------------------
     sticky active
    ------------------------------ */  
    $(window).on('scroll',function() {    
        var scroll = $(window).scrollTop();
        if (scroll < 245) {
            $('.stick-h2').removeClass('stick');
        }else{
            $('.stick-h2').addClass('stick');
        }
    }); 
    
    
    /*----------------------------
     wow js active
    ------------------------------ */
	new WOW().init();
    
    
    
    
 
 
})(jQuery); 