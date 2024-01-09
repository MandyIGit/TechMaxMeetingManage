<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="project_manager_edit.aspx.cs" Inherits="WebSite.Admin.MobilePage.project_manager_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function () {
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
                    url: "/AjaxResponse/tech_project_managerHandler.ashx?type=edit",
                    data: $("#aspnetForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'project_manager.aspx';
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
    编辑项目经理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Project Manager
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <input type="hidden" id="id" name="id" value="<%=id %>" />
    <div class="form-group">
        <label class="col-sm-2 control-label" for="full_name">姓名</label>
        <div class="col-sm-10">
            <input id="full_name" name="full_name" type="text" class="form-control" style="width:300px;" value="<%=info.full_name %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mobile">手机号</label>
        <div class="col-sm-10">
            <input id="mobile" name="mobile" type="text" class="form-control" style="width:300px;" value="<%=info.mobile %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="login_name">登录名称</label>
        <div class="col-sm-10">
            <input id="login_name" name="login_name" type="text" class="form-control" style="width:300px;" readonly="readonly" value="<%=info.login_name %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="login_pwd">登录密码</label>
        <div class="col-sm-10">
            <input id="login_pwd" name="login_pwd" type="text" class="form-control" style="width:300px;" value="<%= Common.DEncrypt.DESEncrypt.Decrypt(info.login_pwd) %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:220px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>
</asp:Content>
