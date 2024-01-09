function b(){
	h = $(window).height();
	t = $(document).scrollTop();	
	if(t > h/2){	   
		$('#gotop').show();
	}else{
		$('#gotop').hide();
	}
}
$(document).ready(function(e) {
	b();
	$('#gotop').click(function(){
		$(document).scrollTop(0);	
	})
	$('#code').hover(function(){
			$(this).attr('id','code_hover');
			$('#code_img').show();
		},function(){
			$(this).attr('id','code');
			$('#code_img').hide();
	})
	
});

$(window).scroll(function(e){
	b();		
})

function c(){
	h = $(window).height();
	t = $(document).scrollTop();
	if(t > h){
		$('#gotop1').show();
	}else{
		$('#gotop1').hide();
	}
}
$(document).ready(function(e) {
	b();
	$('#gotop1').click(function(){
		$(document).scrollTop(0);	
	})
	$('#code1').hover(function(){
			$(this).attr('id','code_hover1');
			$('#code_img1').show();
		},function(){
			$(this).attr('id','code1');
			$('#code_img1').hide();
	})
	
});


