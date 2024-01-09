<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="WebSite.AdminLog.top" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
  <head>
          
    <title>top框架</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="pragma" content="no-cache">
	<meta http-equiv="cache-control" content="no-cache">
	<meta http-equiv="expires" content="0">    
	<meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
	<meta http-equiv="description" content="This is my page">
    <link href="/Admin/css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="/Admin/Xenon/assets/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //顶部导航切换
            $(".nav li a").click(function () {
                $(".nav li a.selected").removeClass("selected");
                $(this).addClass("selected");
            });
        });
    </script>
  </head>
  
<body style="background:url(/Admin/images/topbg.gif) repeat-x;">

    <div class="topleft">
    <a href="javascript:;" target="_parent"><img src="/Admin/images/logo.png" title="系统首页" /></a>
    </div>
        

            
    <div class="topright">    
    <ul>
    <li><span><img src="/Admin/images/help.png" title="帮助"  class="helpimg"/></span><a href="#">帮助</a></li>
    <li><a href="#">关于</a></li>
    <li><a href="loginOut.aspx" target="_parent">退出</a></li>
    </ul>
     
    <%--<div class="user">
    <span><asp:Literal ID="ltlLoginName" runat="server"></asp:Literal></span>
    <i>消息</i>
    <b><asp:Literal ID="ltlMessage" runat="server"></asp:Literal></b>
    </div>--%>  
    
    </div>

</body>
</html>
