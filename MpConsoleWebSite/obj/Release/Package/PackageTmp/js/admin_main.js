// JavaScript Document

function htmlResult(){

    $("#main-nav li ul").hide();
    $("#main-nav li a.nav-top-item:first").addClass("current").parent().find("ul").slideToggle("slow"); 
    $("#main-nav li a.nav-top-item").click(
	    function () {
		    $(this).parents("#main-nav").children("li").children("a.nav-top-item").removeClass("current");
		    $(this).addClass("current");
		    $(this).parent().siblings().find("ul").slideUp("normal");
		    $(this).next().slideToggle("normal");
		    return false;
	    }
    );
    $("#sidebar li a.no-submenu").click(
	    function () {
		    $("#mainhtml").href=(this.href)
		    return false;
	    }
    )
}
//定义浏览器宽高
function htmlbox(){
	jQuery(".header-right").width(jQuery(window).width()-220);
	jQuery("#sidebar").height(jQuery(window).height()-119);
	jQuery(".box-right").width(jQuery(window).width()-220);		
	jQuery(".box-right").height(jQuery(window).height()-78);
	jQuery("#mainhtml").width("100%");
	jQuery("#mainhtml").height(jQuery(window).height()-78);
}

jQuery(window).resize(function(){
    htmlbox();
});
	
///////////////////////////////标签
$(".main-info .tags a").eq(0).addClass("on");
$(".main-info .tagContent").eq(0).css({"display":"block"});
$(".main-info .tags a").click(function(){
    $(".main-info .tags a").removeClass("on");
    $(this).addClass("on");
    $(".main-info .tagContent").hide();
    var $yumingtell=$(".main-info .tagContent").eq($(this).index());
    $yumingtell.show();
})
	  
//下拉菜单显示	  
$("div.more").hover(function () {
$(this).children("span").stop(true, true).slideDown("fast");
}, function () {
$(this).children("span").stop(true, true).slideUp("fast");
})