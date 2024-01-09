<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="editPasswd.aspx.cs" Inherits="WebSite.Admin.AdminPage.editPasswd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $('#btnSave').click(function () {

                if ($(".OldPwd").val() == "") {
                    alert('原登录密码不能为空！');
                    $(".OldPwd").focus();
                    return false;
                }

                if ($(".LoginPwd").val() == "") {
                    alert('新密码不能为空！');
                    $(".LoginPwd").focus();
                    return false;
                }

                var patten = /^(?![a-zA-Z]+$)(?![A-Z0-9]+$)(?![A-Z\\W_!@#$%^&*`~()-+=]+$)(?![a-z0-9]+$)(?![a-z\\W_!@#$%^&*`~()-+=]+$)(?![0-9\\W_!@#$%^&*`~()-+=]+$)[a-zA-Z0-9\\W_!@#$%^&*`~()-+=]{8,30}$/;

                if (!patten.test($(".LoginPwd").val())) {
                    alert('密码必须是大写字母，小写字母，数字，特殊字符”四项中的至少三项且不少于8位！');
                    $(".LoginPwd").focus();
                    return false;
                }

                if ($(".LoginPwdRe").val() == "") {
                    alert('确认登录密码不能为空！');
                    $(".LoginPwdRe").focus();
                    return false;
                }

                if ($(".LoginPwdRe").val() != $(".LoginPwd").val()) {
                    alert('两次密码不一致！');
                    $(".LoginPwdRe").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_adminHandler.ashx?type=editPwd",
                    data: {
                        admin_code: $("#admin_code").val(),
                        login_name: $("#LoginName").val(),
                        oldPwd: $(".OldPwd").val(),
                        newPwd: $(".LoginPwd").val()
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            alert(r.msg);
                            window.location.href = '../loginOut.aspx';
                        } else {
                            alert(r.msg);
                        }
                    },
                    complete: function (XMLHttpRequest, textStatus) { },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { }
                });

            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    修改密码
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Password
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <input id="admin_code" type="hidden" value="<%=admin_code %>" />

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txtAdminName">管理员姓名</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtAdminName" runat="server" Width="300px" CssClass="form-control AdminName" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txtLoginName">登录ID</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtLoginName" runat="server" Width="300px" CssClass="form-control LoginName" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txtOldPwd">原登录密码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtOldPwd" runat="server" Width="300px" CssClass="form-control OldPwd" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txtLoginPwd">新登录密码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtLoginPwd" runat="server" Width="300px" CssClass="form-control LoginPwd" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txtLoginPwdRe">确认新密码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtLoginPwdRe" runat="server" Width="300px" CssClass="form-control LoginPwdRe" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
