<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tech_meeting_list.aspx.cs" Inherits="DIY.ProjectManager.tech_meeting_list" %>

<%@ Register Src="~/CommonPage/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/CommonPage/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>iConference自助建站控制台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link type="text/css" href="/style/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/admin_main.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <link type="text/css" href="/user/css/style.css" rel="stylesheet" />
    <style type="text/css">
        .fenye { width: 100%; height: 24px; line-height: 24px; padding: 2px 0px; font-family: "Microsoft YaHei", "微软雅黑", sans-serif !important; font-size: 12px; color: #666; text-align: center; }
        .fenye a { border: 1px solid #ccc; padding: 3px 7px; margin: 2px 3px; color: #666; text-decoration: none; -moz-border-radius: 5px; -webkit-border-radius: 5px; border-radius: 5px; }
        .fenye a:hover { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .fenye .current { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .sortClass li { margin-left: 2rem; }
        .sortClass div { display: inline-block; margin-left: 1rem; }
        .blueClass { background-color: #3151b1; color: white; padding: 0.08rem 0.5rem; border-radius: 0.3rem; }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            LoadTable();
        });
        //加载
        function LoadTable() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tech_meetingHandler.ashx?type=1',
                data: $("#form1").serialize(),
                success: function (data) {
                    $('#meeting_data').html(data);
                }
            });
        }
        //搜索
        function SelectLoadTable() {
            $('#txtpageIndex').val("1");
            LoadTable();
        }
        function ManageMeeting(info) {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_meetingHandler.ashx?type=ManageMeeting&postvalue=" + info,
                data: $("#form1").serialize(),
                success: function (data) {
                    if (data == 'succ') {
                        window.open("/HYManager/index.aspx");
                    }
                    else {
                        dialogTime('帐号或者密码错误！', '');
                    }
                }
            });
        }
    </script>
</head>
<body>

    <uc1:header runat="server" ID="header" />

    <form id="form1">
        <input type="hidden" name="project_manager_id" value="<%=project_manager_id %>" />
        <div class="Content">
            <div class="topmenu">
                <ul>
                    <li>
                        <span>会议名称：</span>
                        <input type="text" id="mname" name="mname" />
                    </li>
                    <li>
                        <span>会议状态：</span>
                        <select id="huiyi_status" name="huiyi_status">
                            <option value="0">全部</option>
                            <option value="1">即将召开</option>
                            <option value="2">正在召开</option>
                            <option value="3">已结束</option>
                        </select>
                    </li>
                    <li>
                        <span>后台开通状态：</span>
                        <select id="is_weizhankaitong" name="is_weizhankaitong">
                            <option value="0">全部</option>
                            <option value="1">已开通</option>
                            <option value="2">申请中</option>
                        </select>
                    </li>
                    <li>
                        <a class="btn btn-primary" onclick="SelectLoadTable()">查询</a>
                    </li>
                </ul>
                <div class="clear"></div>
            </div>
            <div class="listtable" id="meeting_data">
            </div>
        </div>
    </form>

    <uc1:footer runat="server" ID="footer" />

</body>
</html>
