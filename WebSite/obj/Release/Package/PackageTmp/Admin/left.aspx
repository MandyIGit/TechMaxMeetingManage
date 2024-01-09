<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="WebSite.Admin.left" %>

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
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Xenon/assets/js/jquery-1.11.1.min.js"></script>

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
        <span><img src="images/leftico01.png" /></span>会议管理
        </div>
          <ul class="menuson">
              <li><cite></cite><a href="MeetingPage/tech_meeting_type_add.aspx" target="rightFrame">添加会议类型</a><i></i></li>
              <li><cite></cite><a href="MeetingPage/tech_meeting_type_list.aspx" target="rightFrame">管理会议类型</a><i></i></li>
              <li><cite></cite><a href="MeetingPage/tech_meeting_add.aspx" target="rightFrame">添加会议</a><i></i></li>
              <li><cite></cite><a href="MeetingPage/tech_meeting_list.aspx" target="rightFrame">管理会议</a><i></i></li>
          </ul>
        </dd> 

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>模板样式管理
        </div>
          <ul class="menuson">
              <li><cite></cite><a href="HtmlTemplatePage/tech_html_template_list_add.aspx" target="rightFrame">添加样式模板</a><i></i></li>
              <li><cite></cite><a href="HtmlTemplatePage/tech_html_template_list_list.aspx" target="rightFrame">管理样式模板</a><i></i></li>
              <%--<li><cite></cite><a href="HtmlTemplatePage/tech_html_template_add.aspx" target="rightFrame">添加会议模板</a><i></i></li>
              <li><cite></cite><a href="HtmlTemplatePage/tech_html_template_list.aspx" target="rightFrame">管理会议模板</a><i></i></li>--%>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>邮件模板管理
        </div>
          <ul class="menuson">
              <li><cite></cite><a href="EmailTemplatePage/email_template_add.aspx" target="rightFrame">添加邮件模板</a><i></i></li>
              <li><cite></cite><a href="EmailTemplatePage/email_template_list.aspx" target="rightFrame">管理邮件模板</a><i></i></li>
          </ul>
        </dd> 

	    <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>参会类型管理
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="OtherPage/meeting_reg_type_add.aspx" target="rightFrame">添加参会类型</a><i></i></li>
            <li><cite></cite><a href="OtherPage/meeting_reg_type_list.aspx" target="rightFrame">管理参会类型</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>学术论文发表形式管理
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="OtherPage/published_form_add.aspx" target="rightFrame">添加学术论文发表形式</a><i></i></li>
            <li><cite></cite><a href="OtherPage/published_form_list.aspx" target="rightFrame">管理学术论文发表形式</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>学术论文类别管理
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="OtherPage/article_type_add.aspx" target="rightFrame">添加学术论文类别</a><i></i></li>
            <li><cite></cite><a href="OtherPage/article_type_list.aspx" target="rightFrame">管理学术论文发表形式</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>微站模板管理
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="MobilePage/mtemplate_version_list.aspx" target="rightFrame">管理微站会议版本</a><i></i></li>
            <li><cite></cite><a href="MobilePage/mtemplate_add.aspx" target="rightFrame">添加微站模板</a><i></i></li>
            <li><cite></cite><a href="MobilePage/mtemplate_list.aspx" target="rightFrame">管理微站模板</a><i></i></li>
            <li><cite></cite><a href="MobilePage/project_manager.aspx" target="rightFrame">项目经理管理</a><i></i></li>
          </ul>
        </dd>
        
        <dd style="display:none;">
        <div class="title">
        <span><img src="images/leftico01.png" /></span>批量对账查询
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="batchAccountCheckPage/batchAccountCheck.aspx" target="rightFrame">批量对账</a><i></i></li>
          </ul>
        </dd>

        <dd style="display:none;">
        <div class="title">
        <span><img src="images/leftico01.png" /></span>标签贴打印</div>
          <ul class="menuson">
            <li><cite></cite><a href="PrintPage/PersonAdd.aspx" target="rightFrame">人员添加</a><i></i></li>
            <li><cite></cite><a href="PrintPage/PersonList.aspx" target="rightFrame">人员列表</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>反馈信息管理
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="MessagePage/add_msg.aspx" target="rightFrame">添加信息</a><i></i></li>
            <li><cite></cite><a href="MessagePage/msg_list.aspx" target="rightFrame">信息列表</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>公众号发送消息
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="SendMsgPage/SendMsg.aspx" target="rightFrame">发送消息</a><i></i></li>
              <li><cite></cite><a href="SendMsgPage/SendedMsgList.aspx" target="rightFrame">发送记录</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>发布信息严禁词
        </div>
          <ul class="menuson">
              <li><cite></cite><a href="ForbiddenWord/WordAdd.aspx" target="rightFrame">添加严禁词</a><i></i></li>
              <li><cite></cite><a href="ForbiddenWord/WordList.aspx" target="rightFrame">严禁词列表</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>用户查询
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="TechUserAllPage/tech_user_all_list.aspx" target="rightFrame">查询用户</a><i></i></li>
          </ul>
        </dd>

        <dd>
        <div class="title">
        <span><img src="images/leftico01.png" /></span>管理员设置
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="AdminPage/admin_add.aspx" target="rightFrame">添加管理员</a><i></i></li>
            <li><cite></cite><a href="AdminPage/admin_list.aspx" target="rightFrame">管理员列表</a><i></i></li>
          </ul>     
        </dd> 
	
        <dd>
        <div class="title">
        <span><img src="images/leftico02.png" /></span>系统设置
        </div>
          <ul class="menuson">
            <li><cite></cite><a href="AdminPage/editPasswd.aspx" target="rightFrame">修改密码</a><i></i></li>
          </ul>
        </dd>   
    
    </dl>
    
</body>
</html>