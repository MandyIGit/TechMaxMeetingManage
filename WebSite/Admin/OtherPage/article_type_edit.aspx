<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="article_type_edit.aspx.cs" Inherits="WebSite.Admin.OtherPage.article_type_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var type_id = $("#ctl00_PanelBody_hid_type_id").val();
                var mid = $(".ddl_mid").val();
                var type_name = $(".txt_type_name").val();
                var app_type = $(".ddl_app_type").val();

                if (mid == "") {
                    alert('会议编码不能为空！');
                    $(".ddl_mid").focus();
                    return false;
                }
                if (type_name == "") {
                    alert('类型名称不能为空！');
                    $(".txt_p_name").focus();
                    return false;
                }                

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_article_typeHandler.ashx?type=edit",
                    data: {
                        type_id: type_id,
                        mid: mid,
                        type_name: type_name,
                        app_type: app_type
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'article_type_list.aspx';
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
    编辑学术论文类别
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Article Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <asp:HiddenField ID="hid_type_id" runat="server" />

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_mid">选择会议</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_mid" runat="server" Width="300px" CssClass="form-control ddl_mid"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_type_name">类型名称</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_type_name" runat="server" Width="300px" CssClass="form-control txt_type_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_app_type">应用类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_app_type" runat="server" Width="300px" CssClass="form-control ddl_app_type">
                <asp:ListItem Value="1">中宾</asp:ListItem>
                <asp:ListItem Value="2">外宾</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
