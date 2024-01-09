// JavaScript Document
function htmlResult(){
    $("#main-nav li ul").hide();
    $("#main-nav li a.nav-top-item:first").addClass("current").parent().find("ul").slideToggle("slow"); // Slide down the current menu item's sub menu
    $("#main-nav li a.nav-top-item").click(  // When a top menu item is clicked...
        function () {
            $(this).parents("#main-nav").children("li").children("a.nav-top-item").removeClass("current")
            $(this).addClass("current")
            $(this).parent().siblings().find("ul").slideUp("normal"); // Slide up all sub menus except the one clicked
            $(this).next().slideToggle("normal"); // Slide down the clicked sub menu
            return false;
        }
    );
    $("#sidebar li a.no-submenu").click( // When a menu item with no sub menu is clicked...  
        function () {
	        $("#mainhtml").href=(this.href) // Just open the link instead of a sub menu
	        return false;
        }
    );
}
//////////////////////////////////////////
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
    /////////////////////////////
$(".main-info .tags a").eq(0).addClass("on");
$(".main-info .tagContent").eq(0).css({"display":"block"});
$(".main-info .tags a").click(function(){
    $(".main-info .tags a").removeClass("on");
    $(this).addClass("on");
    $(".main-info .tagContent").hide();
    var $yumingtell=$(".main-info .tagContent").eq($(this).index());
    $yumingtell.show();
})

	$("div.more").hover(function () {
	$(this).children("span").stop(true, true).slideDown("fast");
	}, function () {
	$(this).children("span").stop(true, true).slideUp("fast");
	})