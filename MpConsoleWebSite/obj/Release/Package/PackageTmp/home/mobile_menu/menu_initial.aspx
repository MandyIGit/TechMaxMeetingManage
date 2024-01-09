<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_initial.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_menu.menu_initial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航初始化</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '初始导航';
        });

        function GetPreMenu(obj) {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_type_menuHandler.ashx?type=GetMenu&postvalue=" + parseInt($(obj).val()),
                success: function (data) {
                    $('#menu_list').html(data);
                }
            });
        }

        function SaveData() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=SaveMenu&postvalue=",
                data: $("#form1").serialize(),
                success: function (data) {
                    
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <div class="Content">
            <div class="listtable" id="system_data">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                    <tr>
                        <td colspan="2">导航初始化</td>
                    </tr>
                    <tr>
                        <th scope="row">导航模板类型</th>
                        <td>
                            <select id="menu_type" name="menu_type" onchange="GetPreMenu(this)">
                                <option value="0">请选择</option>
                                <%=type_menu_select %>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">选择导航</th>
                        <td id="menu_list">

                        </td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <input type="hidden" id="sys_code" name="sys_code" />
                            <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">保存初始化</a>
                        </td>
                    </tr>
                </table>
                <div class="h10"></div>
            </div>
        </div>
    </form>
</body>
</html>
