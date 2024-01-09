<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Admin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎登录后台管理系统</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Xenon/assets/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="Xenon/assets/js/cloud.js"></script>
    <script type="text/javascript">
        if (window != top) top.location.href = location.href;
        function CheckEnterKey(evt) { if (evt.keyCode == 13) { $(".loginbtn").click(); } }
        $(function () {

            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () {
                $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            });

            $('.loginbtn').click(function () {

                var loginuser = $('.loginuser').val();
                var loginpwd = $('.loginpwd').val();

                if (loginuser == '' || loginpwd == '') {
                    alert('用户或密码都不能为空！');
                    return false;
                }
                
                $.ajax({
                    type: 'post',
                    url: '/AjaxResponse/tech_adminHandler.ashx?type=AdminLogin',
                    data: $("#loginForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) {  },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == '1') {
                            window.location.href = "index.aspx";
                        } else {
                            alert(r.msg);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {  },
                    complete: function (XMLHttpRequest, textStatus) {  }
                });

            });

        });
    </script>
</head>
<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
    
    <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div> 
     
    <div class="logintop">
        <span>欢迎登录后台管理界面平台</span>    
        <ul>
            <li><a href="#">回首页</a></li>
            <li><a href="#">帮助</a></li>
            <li><a href="#">关于</a></li>
        </ul>    
    </div>

    <form id="loginForm" class="loginbody" method="post" onkeydown="return CheckEnterKey(event)">
    
        <span class="systemlogo"></span> 
       
        <div class="loginbox">
   
        <ul>

            <li><input name="loginName" type="text" class="loginuser" value="" placeholder="用户名" /></li>
            <li><input name="loginPwd" type="password" class="loginpwd" value="" placeholder="密码" /></li>
            <li>
                <table>
                    <tr>
                        <td><input name="vcode" type="text" class="vcode" value="" placeholder="验证码" /></td>
                        <td>&nbsp;</td>
                        <td><img style="width: 120px; height:40px; cursor: pointer;" src="/commonPage/vecode.aspx" onclick="this.src='/commonPage/vecode.aspx?t='+(new Date()).valueOf()" alt="换一个" /></td>
                    </tr>
                </table>
            </li>
            <li><input name="" type="button" class="loginbtn" value="登录" /></li>
        </ul> 
    
        </div>

    </form>

    <div class="loginbm">版权所有:TECH MAX <a href="http://www.miitbeian.gov.cn/">京ICP备13020642号</a></div>
	
</body>
</html>
