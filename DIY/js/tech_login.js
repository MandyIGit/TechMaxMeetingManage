 $(document).ready(function(){
       appbody();
       $('.theme-login').click(function(){    showlogin(); })
	   $('.theme-poptit .close').click(function(){    hidelogin();	     })
	   $('#input_login').click(function(){   postlogin();	     })
 });        
 function showlogin(){  
    $("#login_code").attr("src",'/CommonPage/Vcode.aspx?t='+(new Date()).valueOf());    
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
     $item+="<form class=\"theme-signin formbox\" id=\"loginform\" name=\"loginform\" onkeydown=\"return CheckEnterKey(event)\">";
     $item+="<ol>";
     $item+="<li><h4 id=\"s_msg\">你必须先登录！</h4></li>";
     $item+="<li><strong>用户名：</strong><label><span>请输入用户名</span><input class=\"ipt\" type=\"text\" autocomplete=\"off\" id=\"loginname\" name=\"loginname\"  size=\"20\" tabindex=\"1\" /><a href=\"/web/regist.aspx\">&nbsp;&nbsp;没有帐号？</a></label></li>";
     $item+="<li><strong>密码：</strong> <label><span>请输入密码</span><input class=\"ipt\" type=\"password\" id=\"password\" name=\"password\"  size=\"20\"  tabindex=\"2\"/><a href=\"/web/user/forget_passwd.aspx\" target=\"_blank\">&nbsp;&nbsp;忘记密码</a></label></li>";
     $item+="<li><strong>验证码：</strong><label><span>请输验证码</span><input class=\"ipt1\" type=\"text\" id=\"vcode\" name=\"vcode\"  size=\"4\" tabindex=\"3\" /><img id=\"login_code\" style=\"width: 82px;margin:-5px 0 0 5px; height: 30px; cursor: pointer;\" src=\"/CommonPage/Vcode.aspx\" onclick=\"this.src='/CommonPage/Vcode.aspx?t='+(new Date()).valueOf()\" /></label></li> ";
     $item+="<li><input class=\"login_btn login_btn-primary\" style=\"width:190px;height:34px;\" type=\"button\" id=\"input_login\" value=\" 登 录\"/ tabindex=\"4\"></li>";
     $item+="<li><span style=\" float:left; margin-left:-85px; font-size:12px; color:#555;line-height:25px;\">其他方式登陆：</span>";
     $item+="<div class=\"logo_icon\"><a title=\"QQ登录\" class=\"iqq\" href=\"javascript:;\" onclick=\"PlatformLogOn('QQ')\"></a>";
     $item+="<a title=\"新浪登录\" class=\"isina\" href=\"javascript:;\" onclick=\"PlatformLogOn('Sina')\"></a>";//<a title=\"QQ登录\" class=\"iweixin\" href=\"javascript:;\" onclick=\"PlatformLogOn('Weixin')\"></a><a title=\"新浪登录\" class=\"ibaidu\" href=\"javascript:;\" onclick=\"PlatformLogOn('Sina')\"></a>";
     //$item+="<a title=\"QQ登录\" class=\"iqqweibo\" href=\"javascript:;\" onclick=\"PlatformLogOn('Weixin')\"></a>";
     $item+="</div>";
     $item+="</li>";
     $item+="</ol>";
     $item+="</form>";
     $item+="</div>";
     $item+="</div>"; 
     
     $("body").append($item);

 }
 
 function PlatformLogOn(m){
     $.ajax({ 
        type: "post", 
        url: "/AjaxResponse/tv_userHandler.ashx?type=PlatformLogOn&m="+m,        
        beforeSend:function(XMLHttpRequest, textStatus){  },                                                                 
        success: function (data) {                
              window.location.href=data;
              //window.open(data);
        },
        complete:function(XMLHttpRequest, textStatus){},        
        error: function (XMLHttpRequest, textStatus, errorThrown) {    } 
       });  
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
          $("#p_login").html("<a style=\"margin:20px 20px 0 0; float:left;\" ><img src=\"/image/user/xiaoxi.gif\" width=\"28\" height=\"28\"  href=\"/web/user/user_message.aspx\"/> </a><a href=\"/web/user/user_index.aspx\"  style=\"margin-top:20px; float:left;\"><img src=\""+objJSON.minihead+"\" width=\"28\" height=\"28\" /></a><a onclick=\"loginout()\"  style=\"margin-top: 15px; margin-left:15px; float: left; height: 38px; line-height: 38px; font-size:15px; color:Black;\">[退出]</a>");
   }else{$("#s_msg").html(objJSON.msg);}
 }
 $(document).ready(function(){		
	$("#loginform .ipt,.ipt1 ").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		$(this).keyup(function(){
			var val=$(this).val();
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			}
		})
	});
	 
})	
	
	 

