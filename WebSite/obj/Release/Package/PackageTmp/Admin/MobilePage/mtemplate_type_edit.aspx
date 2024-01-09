<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="mtemplate_type_edit.aspx.cs" Inherits="WebSite.Admin.MobilePage.mtemplate_type_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function () {
                if ($("#mtype_name").val() == "") {
                    alert('会议类型名称不能为空！');
                    $("#mtype_name").focus();
                    return false;
                }
                if ($("#mtype_memo").val() == "") {
                    alert('会议类型描述不能为空！');
                    $("#mtype_memo").focus();
                    return false;
                }
                if ($("#mtype_memo").val() != "" && $("#mtype_memo").length > 200) {
                    alert('会议类型描述字数不能大于200字！');
                    $("#mtype_memo").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobile_typeHandler.ashx?type=edit",
                    data: $("#aspnetForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'mtemplate_type_list.aspx';
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
    编辑会议类型
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Mobile Template Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <input type="hidden" id="mtype_id" name="mtype_id" value="<%=mtype_id %>" />

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtype_name">会议类型名称</label>
        <div class="col-sm-10">
            <input id="mtype_name" name="mtype_name" type="text" class="form-control" style="width:300px;" value="<%=mtype_name %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="mtype_memo">会议类型描述</label>
        <div class="col-sm-10">
            <textarea id="mtype_memo" name="mtype_memo" class="form-control" style="width:300px; height:80px;"><%=mtype_memo %></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:220px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>
</asp:Content>
