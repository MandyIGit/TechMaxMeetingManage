<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin_add.aspx.cs" Inherits="WebSite.Admin.AdminPage.admin_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    添加管理员
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Manager
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var mid = $(".ddl_mid").val();
                var admin_name = $(".txt_admin_name").val();
                var login_name = $(".txt_login_name").val();
                var login_pwd = $(".txt_login_pwd").val();
                var login_pwdre = $(".txt_login_pwdre").val();
                var gender = $(".ddl_gender").val();
                var phone = $(".txt_phone").val();
                var address = $(".txt_address").val();
                var admin_type = $(".ddl_admin_type").val();
                var remark = $(".txt_remark").val();

                if (admin_name == "") {
                    alert('姓名不能为空！');
                    $(".txt_admin_name").focus();
                    return false;
                }
                if (login_name == "") {
                    alert('登录ID不能为空！');
                    $(".txt_login_name").focus();
                    return false;
                }
                if (login_pwd == "") {
                    alert('密码不能为空！');
                    $(".txt_login_pwd").focus();
                    return false;
                }

                var patten = /^(?![a-zA-Z]+$)(?![A-Z0-9]+$)(?![A-Z\\W_!@#$%^&*`~()-+=]+$)(?![a-z0-9]+$)(?![a-z\\W_!@#$%^&*`~()-+=]+$)(?![0-9\\W_!@#$%^&*`~()-+=]+$)[a-zA-Z0-9\\W_!@#$%^&*`~()-+=]{8,30}$/;

                if (!patten.test(login_pwd)) {
                    alert('密码必须是大写字母，小写字母，数字，特殊字符”四项中的至少三项且不少于8位！');
                    $(".txt_login_pwd").focus();
                    return false;
                }

                if (login_pwdre == "") {
                    alert('确认密码不能为空！');
                    $(".txt_login_pwdre").focus();
                    return false;
                }
                if (login_pwd != login_pwdre) {
                    alert('两次密码不一致！');
                    $(".txt_login_pwdre").focus();
                    return false;
                }
                if (phone == "") {
                    alert('联系电话不能为空！');
                    $(".txt_phone").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_adminHandler.ashx?type=AddAdmin",
                    data: {
                        mid: mid,
                        admin_name: admin_name,
                        login_name: login_name,
                        login_pwd: login_pwd,
                        gender: gender,
                        phone: phone,
                        address: address,
                        admin_type: admin_type,
                        remark: remark
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'admin_list.aspx';
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

<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label">选择会议</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_mid" runat="server" Width="300px" CssClass="form-control ddl_mid"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_admin_name">姓名</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_admin_name" runat="server" Width="300px" CssClass="form-control txt_admin_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_login_name">登录ID</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_login_name" runat="server" Width="300px" CssClass="form-control txt_login_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_login_pwd">密码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_login_pwd" runat="server" Width="300px" CssClass="form-control txt_login_pwd" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_login_pwdre">确认密码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_login_pwdre" runat="server" Width="300px" CssClass="form-control txt_login_pwdre" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_gender">性别</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_gender" runat="server" Width="300px" CssClass="form-control ddl_gender">
                <asp:ListItem Value="1">男</asp:ListItem>
                <asp:ListItem Value="2">女</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_phone">联系电话</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_phone" runat="server" Width="300px" CssClass="form-control txt_phone"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_address">地址</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_address" runat="server" Width="300px" CssClass="form-control txt_address"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_admin_type">管理员类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_admin_type" runat="server" Width="300px" CssClass="form-control ddl_admin_type">
                <asp:ListItem Value="1">超级管理员</asp:ListItem>
                <asp:ListItem Value="2">普通管理员</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_remark">备注信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_remark" runat="server" Width="300px" CssClass="form-control txt_remark"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
