$(document).ready(function () {
	//navShow();
	//sidebar();

	
});

function navShow() {
	$("#nav_all li").hover(function () {
		$(this).children("ul").stop(true, true).slideDown("fast");
	}, function () {
		$(this).children("ul").stop(true, true).slideUp("fast");
	})
}
function sidebar() {
	$(".sidebar li").hover(function () {
		$(this).children("ul").stop(true, true).slideDown("fast");
	}, function () {
		$(this).children("ul").stop(true, true).slideUp("fast");
	})
}
/****Ê×Ò³Í¼Æ¬ÂÖ²¥Æ÷****/
function showimage(){
  var wrap = $('.hotdoing-img');
	var imgs = wrap.find('.hotdoing-photo li');		
	var len = imgs.length;
	var tabTime = 1000;
	var outTime = 4000;
	var special = 'ntwon';	
	var num = 0;
	var interval;
	var type = 'click';
	imgs.each(function(i){
		$('<li>'+(i+1)+'</li>').appendTo(wrap.find('.hotdoing-button'))
	});
	var btns = wrap.find('.hotdoing-button li');
	btns.eq(num).addClass(special);
	btns.bind(type,function(){
		var _this = $(this);
		_this.addClass(special).siblings().removeClass(special);
		num = _this.prevAll().length;
		imgs.stop().eq(num).fadeTo(tabTime,1);
		imgs.not(':eq('+num+')').filter(':visible').fadeOut(tabTime);
		return false;
	});
	var interFunc = function(){
		num = (num+1)%len;
		btns.eq(num).triggerHandler(type);		
	}	
	wrap.bind('mouseover',function(){
		clearInterval(interval);
	}).bind('mouseout',function(){
		interval = setInterval(interFunc,outTime);
	});	
	imgs.not(':eq('+num+')').hide();	
	interval = setInterval(interFunc,outTime);
}
/****Ê×Ò³Í¼Æ¬ÂÖ²¥Æ÷End****/
function search() {
	var kw = document.getElementById("txtKeyword");
	if (kw.value == "") {
		alert("ÇëÌîÈëËÑË÷¹Ø¼ü´Ê£¡");
		kw.focus();
		return false;
	}
	else {
		document.location = document.location.href.replace(location.search, "") + "?kw=" + kw.value;
	}
}