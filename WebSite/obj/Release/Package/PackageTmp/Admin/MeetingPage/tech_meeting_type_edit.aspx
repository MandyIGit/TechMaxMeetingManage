<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="tech_meeting_type_edit.aspx.cs" Inherits="WebSite.Admin.MeetingPage.tech_meeting_type_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function () {
                if ($(".txt_mtype_id").val() == "") {
                    alert('会议类型编码不能为空！');
                    $(".txt_mtype_id").focus();
                    return false;
                }
                if ($(".txt_mtype_name").val() == "") {
                    alert('会议类型名称不能为空！');
                    $(".txt_mtype_name").focus();
                    return false;
                }
                if ($(".txt_mtype_memo").val() != "" && $(".txt_mtype_memo").length > 200) {
                    alert('会议类型描述字数不能大于200字！');
                    $(".txt_mtype_memo").focus();
                    return false;
                }
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_meeting_typeHandler.ashx?type=edit",
                    data: {
                        mtype_id: $(".txt_mtype_id").val(),
                        mtype_name: $(".txt_mtype_name").val(),
                        mtype_memo: $(".txt_mtype_memo").val(),
                        v_sid: $(".ddl_v_sid").val()
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'tech_meeting_type_list.aspx?page=<%=page%>';
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
    Edit Meeting Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mtype_id">会议类型编码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mtype_id" runat="server" Width="300px" CssClass="form-control txt_mtype_id" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mtype_name">会议类型名称</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mtype_name" runat="server" Width="300px" CssClass="form-control txt_mtype_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mtype_memo">会议类型描述</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mtype_memo" runat="server" Width="300px" CssClass="form-control txt_mtype_memo" Height="80px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mtype_memo">所属学科类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_v_sid" runat="server" Width="300px" CssClass="form-control ddl_v_sid">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
