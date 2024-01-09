<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="DIY.HYManager.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>提示</title>
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript">
    $(window).resize(function(){ 
        $("#mydiv").css({ 
            position:"absolute", 
            left:($(window).width() - $("#mydiv").outerWidth())/2, 
            top:($(window).height() - $("#mydiv").outerHeight())/2 
        });    
    }); 
    </script>
</head>
<body style="background-color:#FFF;">
    <form id="form1" runat="server">
    <div id="mydiv" style="margin:0px auto; width:460px; height:231px; ">
        <img src="/image/admin/Error.jpg" alt="出错啦" />
    </div>
    
    </form>
</body>
</html>