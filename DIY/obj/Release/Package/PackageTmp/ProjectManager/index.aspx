<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DIY.ProjectManager.index" %>

<%@ Register Src="~/CommonPage/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/CommonPage/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>项目管理中心</title>
    <script type="text/javascript" src="/js/jquery-1.9.1.min.js"></script>
    <link type="text/css" href="/user/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="/user/js/iConference.min.js"></script>
    <script type="text/javascript" src="/js/jquery.SuperSlide.2.1.js"></script>
    <script type="text/javascript" src="/js/layer/layer.js"></script>
    <link rel="stylesheet" href="/js/layer/skin/layer.css" id="layui_layer_skinlayercss" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-pager-plugin-master/jquery.pager.js"></script>

    <script type="text/javascript" src="/js/artDialog.js?skin=black" charset="utf-8"></script>
    <script type="text/javascript" src="/js/artDialog.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js" charset="utf-8"></script>
</head>
<body>
    
    <uc1:header runat="server" id="header" />
   
   	<div id="content_warp" class="clear">
    
   	  <div class="contenter">
        
        	<div class="contenter_box">
            	<ul>
                	<a href="tech_meeting_add.aspx" target="_blank"><li>申请会议</li></a>
                    <a href="tech_meeting_list.aspx" target="_blank"><li>管理会议</li></a>
                    <a href="tech_project_manager_edit.aspx" target="_blank"><li>修改资料</li></a>
                </ul>
                
                <div class="clearfix"></div>
            </div>
            
            
      </div>
    
    </div>   

    <uc1:footer runat="server" id="footer" />

</body>
</html>
