<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="meeting_reg_type_edit.aspx.cs" Inherits="WebSite.Admin.OtherPage.meeting_reg_type_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var id = $("#ctl00_PanelBody_hid_id").val();
                var mid = $(".ddl_mid").val();
                var ch_name = $(".txt_ch_name").val();
                var en_name = $(".txt_en_name").val();
                var begin_time = $(".txt_begin_time").val();
                var end_time = $(".txt_end_time").val();
                var money = $(".txt_money").val();
                var use_type = $(".ddl_use_type").val();
                var use_location = $(".ddl_use_location").val();
                var isupload = $(".ddl_isupload").val();
                
                if (id == "") {
                    alert('ID不能为空！');
                    return false;
                }
                if (mid == "") {
                    alert('会议编码不能为空！');
                    $(".ddl_mid").focus();
                    return false;
                }
                if (ch_name == "") {
                    alert('类型名称(中文)不能为空！');
                    $(".txt_ch_name").focus();
                    return false;
                }
                if (begin_time == "") {
                    alert('开始时间不能为空！');
                    $(".txt_begin_time").focus();
                    return false;
                }
                if (end_time == "") {
                    alert('结束时间不能为空！');
                    $(".txt_end_time").focus();
                    return false;
                }
                if (money == "") {
                    alert('价格不能为空！');
                    $(".txt_money").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_meeting_reg_typeHandler.ashx?type=edit",
                    data: {
                        id: id,
                        mid: mid,
                        ch_name: ch_name,
                        en_name: en_name,
                        begin_time: begin_time,
                        end_time: end_time,
                        money: money,
                        use_type: use_type,
                        use_location: use_location,
                        isupload: isupload
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'meeting_reg_type_list.aspx';
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
    编辑参会类型
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Meeting Reg Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <asp:HiddenField ID="hid_id" runat="server" />

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_mid">选择会议</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_mid" runat="server" Width="300px" CssClass="form-control ddl_mid"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_ch_name">类型名称(中文)</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_ch_name" runat="server" Width="300px" CssClass="form-control txt_ch_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_en_name">类型名称(英文)</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_en_name" runat="server" Width="300px" CssClass="form-control txt_en_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_begin_time">开始时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_begin_time" runat="server" Width="300px" CssClass="form-control datepicker txt_begin_time" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_end_time">结束时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_end_time" runat="server" Width="300px" CssClass="form-control datepicker txt_end_time" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_money">价格</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_money" runat="server" Width="300px" CssClass="form-control txt_money"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_use_type">作用类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_use_type" runat="server" Width="300px" CssClass="form-control ddl_use_type">
                <asp:ListItem Value="1">中宾个人</asp:ListItem>
                <asp:ListItem Value="2">外宾个人</asp:ListItem>
                <asp:ListItem Value="3">中宾团队</asp:ListItem>
                <asp:ListItem Value="4">外宾团队</asp:ListItem>
                <asp:ListItem Value="5">晚宴</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_use_location">作用位置</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_use_location" runat="server" Width="300px" CssClass="form-control ddl_use_location">
                <asp:ListItem Value="1">前台</asp:ListItem>
                <asp:ListItem Value="2">后台</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_use_location">是否需要上传凭证</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_isupload" runat="server" Width="300px" CssClass="form-control ddl_isupload">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="2">否</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
