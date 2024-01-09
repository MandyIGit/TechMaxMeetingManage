function LoadPager(handlername,functionname,formname,targetname){        
    $.ajax({
         type: "post",
         url: "/AjaxResponse/tv_videoHandler.ashx?type=GetVideoList",
         data: $("#search_form").serialize(),
         success: function(data) {     
           $("#tbContent").html(data);
     },
     error: function(XMLHttpRequest, textStatus, errorThrown) {
         dialogTime(' 发生错误，请联系客服！ ', '');
     }
   });
   getCount(handlername,functionname,formname);
}    
PageClick = function(pageclickednumber) {       
     $("#pageindex").val(pageclickednumber);
     LoadTable();  
}      
function getCount(handlername,functionname,formname){ 
     $.ajax({ 
         type: "post", 
         url: "/AjaxResponse/tv_videoHandler.ashx?type=GetVideoListCount",
         data:$("#search_form").serialize(),                        
         success: function (data) { 
              if(data=='1'||data=='0'){                                                     
                $("#pager").empty(); }else{ $("#pager").pager({  pagenumber:$("#pageindex").val(), pagecount:data, buttonClickCallback: PageClick });}
         }, 
         error: function (XMLHttpRequest, textStatus, errorThrown) { 
                  dialogTime(' 发生错误，请联系客服！ ','');
         } 
            });                                
       }   
function topage(){
    var p= $("#topage").val();
    $("#pager").pager({  pagenumber:p, pagecount:15, buttonClickCallback: PageClick });     
} 
    
        
