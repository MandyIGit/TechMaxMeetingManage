<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="WebSite.AdminLog.left" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
  <head>

    
    <title>left框架</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="pragma" content="no-cache">
	<meta http-equiv="cache-control" content="no-cache">
	<meta http-equiv="expires" content="0">    
	<meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
	<meta http-equiv="description" content="This is my page">
    <link href="/Admin/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Admin/Xenon/assets/js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active");
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('ul').slideUp();
                } else {
                    $(this).next('ul').slideDown();
                }
            });
        });
    </script>


</head>

<body style="background:#f0f9fd;">

	<div class="lefttop"><span></span>功能菜单</div>
    
    <dl class="leftmenu">        
   	
        <dd>
        <div class="title">
        <span><img src="/Admin/images/leftico02.png" /></span>系统设置
        </div>
          <ul class="menuson">
              <li><cite></cite><a href="tech_log_list.aspx" target="rightFrame">查看本站日志</a><i></i></li>
              <li><cite></cite><a href="tech_log_list_all.aspx" target="rightFrame">查看所有日志</a><i></i></li>
              <li><cite></cite><a href="editPasswd.aspx" target="rightFrame">修改密码</a><i></i></li>
          </ul>
        </dd>
    
    </dl>
    
</body>
</html>