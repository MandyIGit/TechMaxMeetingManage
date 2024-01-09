<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="mtemplate_version_add.aspx.cs" Inherits="WebSite.Admin.MobilePage.mtemplate_version_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function () {
                if ($("#v_name").val() == "") {
                    alert('会议版本名称不能为空！');
                    $("#v_name").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobile_versionHandler.ashx?type=add",
                    data: $("#aspnetForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.close();
                            window.opener.location.reload();
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
    添加会议版本
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Mobile Template Version
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtype_name">会议版本名称</label>
        <div class="col-sm-10">
            <input id="v_name" name="v_name" type="text" class="form-control" style="width:300px;" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="footer_content">导航菜单类型</label>
        <div class="col-sm-10">

            <input type="radio" name="menu_type" id="menu_type_1" value="1" checked="checked" />
            <label for="menu_type_1">经典型（九宫格）</label>

            <input type="radio" name="menu_type" id="menu_type_2" value="2" />
            <label for="menu_type_2">时尚型（上三下六）</label>

            <input type="radio" name="menu_type" id="menu_type_3" value="3" />
            <label for="menu_type_3">微软型（不规则型）</label>

            <input type="radio" name="menu_type" id="menu_type_4" value="4" />
            <label for="menu_type_4">八宫格（第四个横向占两格）</label>

        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:350px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
