﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MpConsoleWebSite.home.index" %>
<%@ Register Src="/CommonPage/pop_up.ascx" TagName="pop_up" TagPrefix="pop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>iConference自助建站控制台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/style/main.css"/>
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black" charset="utf-8"></script>
    <script type="text/javascript" src="/js/artDialog.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js" charset="utf-8"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            htmlbox();
            LoadTable();
        });
        //加载
        function LoadTable() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tv_menuHandler.ashx?type=1&postvalue=',
                success: function (data) {
                    $('#sidebar').html(data);
                    htmlResult();
                }
            });
        }
        //退出登陆
        function Out_login() {
            art.dialog.confirm("<font size='2px'>您确定要退出登录吗？</font>", function () {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_LoginHandler.ashx?type=LogOut",
                    success: function (data) {
                        window.location.href = "/login.aspx";
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        dialogTime(' 发生错误，请联系客服！ ', '');
                    }
                });
            });
        }
        function ShowLayer() {
            showDiv();
        }
        function CloseLayer() {
            closeDiv();
        }
        function OpenMSite(m_website) {
            window.open(m_website);
        }
    </script>
    
</head>
<body scroll="no" class="indexbody">
<pop:pop_up ID="pop_up" runat="server" />
<div class="header">
    <div class="header-left"><img src="/image/admin/logo.png" alt="" /></div>
    <div class="header-right">
        <div class="header-nav">
            <ul>
                <li><a href="javascript:void(0);">欢迎您，<%=login_id %></a></li>                
                <li><a href="javascript:void(0);" onclick="OpenMSite('<%=m_website %>')">预览网站</a></li>
                <li style="float:right"><a href="javascript:void(0);" onclick="Out_login()">退出登录</a></li>
            </ul>
            <div class="clearit"></div>
        </div>
    </div>
    <div class="clear"></div>
</div>
<div class="clearit"></div>
<div class="box">
    <div class="box-left">
        <div id="sidebar" style="height: 148px; ">
        
        </div>
        <div class="copyright">
            <p>Powered by TechMax</p>
            <p>© 2022 TechMax Inc.</p>
        </div>
    </div>
    <div class="box-right">
        <div class="header-seat">
            <ul>
                <li class="homeicon"><a href="javascript:void(0);" id="function_1">后台管理</a>>></li>
                <li><a href="javascript:void(0);" id="function_2">欢迎</a></li>
                <%--<div class="clearit"></div>--%>
            </ul>
        </div>
        <div class="box-main">
            <iframe id="mainhtml" name="mainhtml" scrolling="auto" frameborder="0" src="welcome.aspx" width="100%"></iframe>
        </div>
    </div>
    <div class="clear"></div>
</div>
</body>
</html>