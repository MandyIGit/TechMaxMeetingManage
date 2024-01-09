<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="WebSite.AdminLog.show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录后的首页面</title>
    <link href="/Admin/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Admin/Xenon/assets/js/jquery-1.11.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">首页</a></li>
        </ul>
        </div>
    
        <div class="mainindex">
    
    
        <div class="welinfo">
        <span><img src="/Admin/images/sun.png" alt="天气" /></span>
        <b><asp:Label ID="lblLoginName" runat="server" Text=""></asp:Label>您好！欢迎使用iConference学术会议管理系统</b>
    
        </div>
    
        <div class="welinfo">
        <span><img src="/Admin/images/time.png" alt="时间" /></span>
        <i>您上次登录的时间：<asp:Literal ID="ltlDateAndTime" runat="server"></asp:Literal></i> 
        </div>
    
        <div class="xline"></div>
    
 
    
    
        </div>

    </form>
</body>
</html>