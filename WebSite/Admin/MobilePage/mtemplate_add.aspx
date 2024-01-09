<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="mtemplate_add.aspx.cs" Inherits="WebSite.Admin.MobilePage.mtemplate_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function () {
                if ($("#mtemplate_name").val() == "") {
                    alert('模板名称不能为空！');
                    $("#mtemplate_name").focus();
                    return false;
                }
                //if ($("#mtemplate_css").val() == "") {
                //    alert('模板样式不能为空！');
                //    $("#mtype_memo").focus();
                //    return false;
                //}
                //if ($("#mtemplate_thumbnail").val() == "") {
                //    alert('模板缩略图不能为空！');
                //    $("#mtype_memo").focus();
                //    return false;
                //}
                if ($("#mtemplate_memo").val() != "" && $("#mtemplate_memo").length > 200) {
                    alert('模板类型描述字数不能大于200字！');
                    $("#mtemplate_memo").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobile_templateHandler.ashx?type=add",
                    data: $("#aspnetForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'mtemplate_list.aspx';
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
    添加模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Mobile Template
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtemplate_name">版本类型</label>
        <div class="col-sm-10">
            <select id="version_id" name="version_id" class="form-control" style="width:300px;">
                <%=version_select_str %>
            </select>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtemplate_name">模板名称</label>
        <div class="col-sm-10">
            <input id="mtemplate_name" name="mtemplate_name" type="text" class="form-control" style="width:300px;" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="display:none;">
        <label class="col-sm-2 control-label" for="mtemplate_css">模板样式</label>
        <div class="col-sm-10">
            <input id="mtemplate_css" name="mtemplate_css" type="text" class="form-control" style="width:300px;" />
        </div>
    </div>
    <div class="form-group-separator" style="display:none;">
    </div>

    <div class="form-group" style="display:none;">
        <label class="col-sm-2 control-label" for="mtemplate_thumbnail">模板缩略图</label>
        <div class="col-sm-10">
            <input id="mtemplate_thumbnail" name="mtemplate_thumbnail" type="text" class="form-control" style="width:300px;" />
        </div>
    </div>
    <div class="form-group-separator" style="display:none;">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtemplate_memo">模板描述</label>
        <div class="col-sm-10">
            <textarea id="mtemplate_memo" name="mtemplate_memo" class="form-control" style="width:300px; height:80px;"></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="first_content">一级页面内容模板</label>
        <div class="col-sm-10">
            <textarea id="first_content" name="first_content" class="form-control" style="width:600px; height:200px;"></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="second_content">二级页面内容模板</label>
        <div class="col-sm-10">
            <textarea id="second_content" name="second_content" class="form-control" style="width:600px; height:200px;"></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="footer_content">底部导航内容模板</label>
        <div class="col-sm-10">
            <textarea id="footer_content" name="footer_content" class="form-control" style="width:600px; height:200px;"></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <%--<div class="form-group">
        <label class="col-sm-2 control-label" for="footer_content">首页导航菜单类型</label>
        <div class="col-sm-10">

            <input type="radio" name="menu_type" id="menu_type_1" value="1" checked="checked" />
            <label for="menu_type_1">经典型</label>

            <input type="radio" name="menu_type" id="menu_type_2" value="2" />
            <label for="menu_type_2">时尚型</label>

        </div>
    </div>
    <div class="form-group-separator">
    </div>--%>

    <div class="form-group" style="padding-left:220px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>
</asp:Content>
