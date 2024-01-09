<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_roles.aspx.cs" Inherits="DIY.HYManager.mobile_agenda.add_roles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加会议厅会场</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>

    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>

    <script type="text/javascript" src="/js/artDialog.source.js"></script>

    <script type="text/javascript" src="/js/iframeTools.source.js"></script>

    <style type="text/css">
        .span_error {
            color: red;
        }
    </style>

    <script type="text/javascript">

        function addRole() {
            if (panduan()) {

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/mobile_agendaHandler.ashx?type=selectuser",
                    data: $("#Myform").serialize(),
                    beforeSend: function (XMLHttpRequest) { },
                    success: function (data) {
                        var obj = eval("(" + data + ")");
                        if (obj.result == "no") {
                            alert("姓名不能为空！");
                        } else if (obj.result == "yes") {
                            var roleid = obj.id;
                            var roleName = obj.name;
                            art.dialog.opener.showRoleName(roleid, roleName,'<%=type%>');
                            art.dialog.close();
                        } else { alert("发生错误，请联系客服！"); }
                    },
                    complete: function (XMLHttpRequest, textStatus) { },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
                });

            }
        }


        function panduan() {

            if ($("#rolefullname").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("姓名不能为空！");
                return false;
            }
            return true;
        }

    </script>

</head>
<body>
    <form id="Myform">

        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />

        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
            <tr>
                <th>角色名称</th>
                <td>
                    <!--<select name="roleName" class="txt" id="roleName">
                    <option value="0">请选择</option>
                    </select>-->
                    <!--姓氏：<input name="rolefamilyname" type="text" class="txt" id="rolefamilyname" placeholder="姓氏" value="" style="width: 80px;" />
                    名字：<input name="rolegivenname" type="text" class="txt" id="rolegivenname" placeholder="名字" value="" style="width: 150px;" />-->
                    姓名：<input name="rolefullname" type="text" class="txt" id="rolefullname" placeholder="姓名" value="" style="width:230px;" />
                    <br />
                    <span class="span_error" id="errormeetinghall"></span>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <a class="btnblue" style="margin-left: 36px;" href="javascript:addRole()">确定</a></td>
            </tr>
        </table>

    </form>
</body>
</html>
