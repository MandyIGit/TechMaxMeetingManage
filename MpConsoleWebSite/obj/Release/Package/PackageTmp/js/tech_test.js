  $(document).ready(function(){     
     appbody2();
     appcontent();
      $('.theme-poptit .close').click(function(){    testhide();	     })
  });        
  function tesshow(){   
    $('#form_test').slideDown(200);
  }
  function testhide(){         
     $('#form_test').slideUp(200);
  }
  
  function appbody2(){
     var $item="<div id=\"form_test\" class=\"theme-popover\" style=\" position: absolute; z-index: 9999; \">";
     $item+="<div class=\"theme-poptit\">";
     $item+=" <a href=\"javascript:;\" title=\"关闭\" class=\"close\">×</a>";
     $item+="<h3>医视界</h3>";
     $item+="</div>";
     $item+="<div class=\"theme-popbod dform\">";
     $item+="<p>1/2</p>";
     $item+="<form class=\"theme-signin\" id=\"testform\" name=\"testform\" onkeydown=\"return CheckEnterKey(event)\">";    
     $item+="</form>";
     $item+="</div>";
     $item+="</div>";     
     $("body").append($item);     
  }

  function appcontent(){
    $.ajax({
        type: "post",
        url: "/AjaxResponse/tv_packageHandler.ashx?type=GetPackageList",
        data: $("#testform").serialize(),
        beforeSend:function(XMLHttpRequest, textStatus){},                  
        success: function(data) {alert(data); },//$("#testform").html(data);
        error: function(XMLHttpRequest, textStatus, errorThrown) {}
        }); 
  }
 
 function test(){
    tesshow();
 }