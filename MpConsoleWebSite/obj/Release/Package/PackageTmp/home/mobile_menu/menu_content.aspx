<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_content.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_menu.menu_content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目内容管理</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/main.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '菜单内容管理';
            getContent();
        });
        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=GetMenuContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    $("#tbContent").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }
    </script>
</head>
<body>
    <form id="myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" id="JsonStr" name="JsonStr" />
        <div class="p10">
            <div class="table_list">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbContent">
                    <colgroup>
                        <col width="30">
                        <col>
                        <col width="200">
                        <col width="200">
                    </colgroup>
                    <thead>
                        <tr>
                            <td width="20"></td>
                            <td>顺序</td>
                            <td width="200">链接</td>
                            <td width="200">操作</td>
                        </tr>
                    </thead>


                </table>
                <div class="h10"></div>

            </div>
        </div>
    </form>
    <table>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="h10"></div>
</body>
</html>
