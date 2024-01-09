 $(document).ready(function(){
       appbody();
       $('.theme-login').click(function(){    showlogin(); })
	   $('.theme-poptit .close').click(function(){    hidelogin();	     })
	   $('#input_login').click(function(){   postlogin();	     })
 });        
 function showlogin(){     
    $('#form_login').slideDown(200);
  }
 function hidelogin(){
     $("#password").val("");    
     $('#form_login').slideUp(200);
  }
  
  function appbody(){
     var $item="<div id=\"form_login\" class=\"theme-popover\" style=\" position: absolute; z-index: 9999; \">";
     $item+="<div class=\"theme-poptit\">";
     $item+=" <a href=\"javascript:;\" title=\"关闭\" class=\"close\">×</a>";
     $item+="<h3>医视界</h3>";
     $item+="</div>";
     $item+="<div class=\"theme-popbod dform\">";
     $item+="<form class=\"theme-signin\" id=\"loginform\" name=\"loginform\" onkeydown=\"return CheckEnterKey(event)\">";
     $item+="<ol>";
     $item+="<li><h4 id=\"s_msg\">你必须先登录！</h4></li>";
     $item+="<li><strong>用户名：</strong><input class=\"ipt\" type=\"text\" id=\"loginname\" name=\"loginname\"  size=\"20\" tabindex=\"1\" /><a href=\"/web/regist.aspx\">没有帐号？</a></li>";
     $item+="<li><strong>密码：</strong><input class=\"ipt\" type=\"password\" id=\"password\" name=\"password\"  size=\"20\"  tabindex=\"2\"/><a href=\"/web/user/forget_passwd.aspx\" target=\"_blank\">忘记密码</a></li>";
     $item+="<li><strong>验证码：</strong><input class=\"ipt1\" type=\"text\" id=\"vcode\" name=\"vcode\"  size=\"4\" tabindex=\"3\" /><img id=\"img_code\" style=\"width: 65px;margin-left:5px; height: 25px; cursor: pointer;\" src=\"/CommonPage/Vcode.aspx\" onclick=\"this.src='/CommonPage/Vcode.aspx?t='+(new Date()).valueOf()\" /></li> ";
     $item+="<li><input class=\"login_btn login_btn-primary\" type=\"button\" id=\"input_login\" value=\" 登 录\"/ tabindex=\"4\"></li>";
     $item+="</ol>";
     $item+="</form>";
     $item+="</div>";
     $item+="</div>";     
     $("body").append($item);

 }
function search_video(){ 
   if (event.keyCode == 13){      
        var keyname=$("#txt_search").val();
        if(keyname=='请输入搜索内容'||keyname==''){}else{window.open("v_list.aspx?keyname="+escape(keyname),'_blank');}
  }
}
//登陆后的动作
function alaction(){
  
}
function CheckEnterKey(evt) { if(evt.keyCode == 13) { postlogin(); } } 

function postlogin(){
      $.ajax({ 
        type: "post", 
        url: "/AjaxResponse/tv_userHandler.ashx?type=Login",
        data:$("#loginform").serialize(), 
        beforeSend:function(XMLHttpRequest, textStatus){ $("#input_login").val("登录中..."); },                                                                 
        success: function (data) { 
               var objJSON = eval("(" + data + ")"); 
               doresult(objJSON);
        },
        complete:function(XMLHttpRequest, textStatus){ $("#input_login").val("登 录");},        
        error: function (XMLHttpRequest, textStatus, errorThrown) {  $("#s_msg").html("发生错误，请重试");      } 
       });  
 }
 
 function doresult(objJSON){
   if(objJSON.result=='disactive'){ window.location.href="/web/Active_Account.aspx?loginname="+$("#loginname").val(); }
   else if(objJSON.result=='succ'){  hidelogin();alaction();
          $("#p_login").html("<a style=\"margin:20px 20px 0 0; float:left;\" ><img src=\"/image/user/xiaoxi.gif\" width=\"28\" height=\"28\" /> </a><a href=\"/web/user/user_index.aspx\"  style=\"margin-top:20px; float:left;\"><img src=\""+objJSON.minihead+"\" width=\"28\" height=\"28\" /></a>");
   }else{$("#s_msg").html(objJSON.msg);}
 }