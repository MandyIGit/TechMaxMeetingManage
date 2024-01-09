      
 function show_msgdetail(){
    $('#form_msg').slideDown(200);
  }
 function hidemsg(){ 
     $('#form_msg').slideUp(200);
  }  
  
 function appmsg(title,senduname,sendtime,contenet){     
     var $item="<div id=\"form_msg\" class=\"theme-popover\" style=\" position: absolute; z-index: 9999; \" id=\"msgtable\">";
     $item+="<div class=\"theme-poptit\">";
     $item+=" <a href=\"javascript:hidemsg();\" title=\"关闭\" class=\"close\">×</a>";
     $item+="<h3>"+title+"</h3>";
     $item+="</div>";    
     $item+="<div class=\"dform1\">";
     $item+="<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotablel\">";
     $item+="<tr>";
     $item+="<td width=\"20%\" height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">标题</td>";
     $item+="<td width=\"80%\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">"+title+"</td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\"> 发送者 </td>";
     $item+="<td nowrap=\"nowrap\" bgcolor=\"#FFFFFF\"><font color=\"#FF0000\">"+senduname+"</font></td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">时间</td>";
     $item+="<td nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">"+sendtime+"</td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">内容</td>";
     $item+="<td bgcolor=\"#FFFFFF\" >"+contenet+"</td>";
     $item+="</tr>";
     $item+="</table>";  
     $item+="</div>";
     $item+="</div>"; 
     $("body").append($item);
 }
 
 function Get_Msg(msgid){ 
       if($("#msgtable").length){$("#msgtable").remove();}              
       $.ajax({
          type: "post",
          url: "/AjaxResponse/tv_userHandler.ashx?type=GetReciveMsg&msg_id="+msgid,            
          beforeSend:function(XMLHttpRequest, textStatus){ },                  
          success: function(data) { 
               var objJSON = eval("(" + data + ")"); 
               appmsg(objJSON.title,objJSON.send_uname,objJSON.send_time,objJSON.content);
               show_msgdetail();
       },
       error: function(XMLHttpRequest, textStatus, errorThrown) {alert(' 发生错误，请联系客服！ ');},
       complete:function(XMLHttpRequest, textStatus){MakeItRead(msgid);}
       });
 }
function MakeItRead(msgid){
   $.ajax({
       type: "post",
       url: "/AjaxResponse/tv_userHandler.ashx?type=MakeMsgRead&msg_id="+msgid,            
       beforeSend:function(XMLHttpRequest, textStatus){ },                  
       success: function(data) { },
       error: function(XMLHttpRequest, textStatus, errorThrown) {alert(' 发生错误，请联系客服！ ');},
       complete:function(XMLHttpRequest, textStatus){LoadTable();}
       });
 }
 
  function appsendmsg(title,senduname,sendtime,contenet){     
     var $item="<div class=\"theme-popover\" style=\" position: absolute; z-index: 9999; \" id=\"msgtable\">";
     $item+="<div class=\"theme-poptit\">";
     $item+=" <a href=\"javascript:hidemsg();\" title=\"关闭\" class=\"close\">×</a>";
     $item+="<h3>"+title+"</h3>";
     $item+="</div>";    
     $item+="<div class=\"dform1\">";
     $item+="<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotablel\">";
     $item+="<tr>";
     $item+="<td width=\"20%\" height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">标题</td>";
     $item+="<td width=\"80%\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">"+title+"</td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\"> 收件人 </td>";
     $item+="<td nowrap=\"nowrap\" bgcolor=\"#FFFFFF\"><font color=\"#FF0000\">"+senduname+"</font></td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">时间</td>";
     $item+="<td nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">"+sendtime+"</td>";
     $item+="</tr>";
     $item+="<tr>";
     $item+="<td height=\"22\" align=\"center\" nowrap=\"nowrap\" bgcolor=\"#FFFFFF\">内容</td>";
     $item+="<td bgcolor=\"#FFFFFF\" >"+contenet+"</td>";
     $item+="</tr>";
     $item+="</table>";  
     $item+="</div>";
     $item+="</div>"; 
     $("body").append($item);
 }
 
 function Get_SendMsg(msgid){ 
       if($("#msgtable").length){$("#msgtable").remove();}              
       $.ajax({
          type: "post",
          url: "/AjaxResponse/tv_userHandler.ashx?type=GetSendMsg&msg_id="+msgid,            
          beforeSend:function(XMLHttpRequest, textStatus){ },                  
          success: function(data) { 
               var objJSON = eval("(" + data + ")"); 
               appsendmsg(objJSON.title,objJSON.send_uname,objJSON.send_time,objJSON.content);
               show_msgdetail();
       },
       error: function(XMLHttpRequest, textStatus, errorThrown) {alert(' 发生错误，请联系客服！ ');}     
       });
 }