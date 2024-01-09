<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tech_project_manager_edit.aspx.cs" Inherits="DIY.ProjectManager.tech_project_manager_edit" %>

<%@ Register Src="~/CommonPage/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/CommonPage/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人资料修改</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <link type="text/css" href="/user/css/style.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '个人资料修改';
        });
        //加载
        function LoadTable() {
            location.reload();
        }

        function SaveData() {
            if ($("#full_name").val() == "") {
                alert('姓名不能为空！');
                $("#full_name").focus();
                return false;
            }
            if ($("#mobile").val() == "") {
                alert('手机号不能为空！');
                $("#mobile").focus();
                return false;
            }
            if ($("#login_name").val() == "") {
                alert('登录名称不能为空！');
                $("#login_name").focus();
                return false;
            }
            if ($("#login_pwd").val() == "") {
                alert('登录密码不能为空！');
                $("#login_pwd").focus();
                return false;
            }

            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=pmSaveEdit",
                data: $("#form1").serialize(),
                beforeSend: function (XMLHttpRequest, textStatus) { },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    if (r.result == 'succ') {
                        dialogTimeClose('操作成功！', '', "yes");
                    } else {
                        dialogTime('' + r.msg + '', '');
                    }
                },
                complete: function (XMLHttpRequest, textStatus) { },
                error: function (XMLHttpRequest, textStatus, errorThrown) { }
            });
        }
    </script>
</head>
<body>

    <uc1:header runat="server" ID="header" />

    <form id="form1">
        <input type="hidden" id="id" name="id" value="<%=id %>" />
        <div class="Content">
            <div class="listtable" id="system_data">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                    <tr>
                        <td colspan="2">个人信息编辑</td>
                    </tr>
                    <tr>
                        <th scope="row">姓名</th>
                        <td>
                            <input class="txt" id="full_name" name="full_name" type="text" style="width:300px;" value="<%=info.full_name %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">手机号</th>
                        <td>
                            <input class="txt" id="mobile" name="mobile" type="text" style="width:300px;" value="<%=info.mobile %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">登录名称</th>
                        <td>
                            <input class="txt" id="login_name" name="login_name" type="text" style="width:300px;" value="<%=info.login_name %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">登录密码</th>
                        <td>
                            <input class="txt" id="login_pwd" name="login_pwd" type="text" style="width:300px;" value="<%= Common.DEncrypt.DESEncrypt.Decrypt(info.login_pwd) %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">保存</a>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </form>

    <uc1:footer runat="server" ID="footer" />

</body>
</html>
