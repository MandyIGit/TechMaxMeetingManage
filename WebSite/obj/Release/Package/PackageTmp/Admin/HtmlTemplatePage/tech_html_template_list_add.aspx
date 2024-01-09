﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="tech_html_template_list_add.aspx.cs" Inherits="WebSite.Admin.HtmlTemplatePage.tech_html_template_list_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var mid = $(".ddl_mid").val();
                var tm_id = $(".txt_tm_id").val();
                var tm_name = $(".txt_tm_name").val();
                var tm_img = $(".txt_tm_img").val();
                var first_content = $(".txt_first_content").val();
                var en_first_content = $(".txt_en_first_content").val();
                var second_content = $(".txt_second_content").val();
                var en_second_content = $(".txt_en_second_content").val();
                var third_content = $(".txt_third_content").val();
                var en_third_content = $(".txt_en_third_content").val();
                var person_content = $(".txt_person_content").val();
                var en_person_content = $(".txt_en_person_content").val();
                var tm_type = $(".ddl_tm_type").val();
                var tm_css = $(".txt_tm_css").val();

                if (mid == "") {
                    alert('会议编码不能为空！');
                    $(".ddl_mid").focus();
                    return false;
                }
                if (tm_id == "") {
                    alert('模板编码不能为空！');
                    $(".txt_tm_id").focus();
                    return false;
                }
                if (tm_name == "") {
                    alert('模板名称不能为空！');
                    $(".txt_tm_name").focus();
                    return false;
                }
                if (tm_img == "") {
                    alert('模板缩略图地址不能为空！');
                    $(".txt_tm_img").focus();
                    return false;
                }
                if (first_content == "") {
                    alert('一级页面内容信息不能为空！');
                    $(".txt_first_content").focus();
                    return false;
                }
                if (second_content == "") {
                    alert('二级页面内容信息不能为空！');
                    $(".txt_second_content").focus();
                    return false;
                }                

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_html_template_listHandler.ashx?type=add",
                    data: {
                        mid: mid,
                        tm_id: tm_id,
                        tm_name: tm_name,
                        tm_img: tm_img,
                        first_content: first_content,
                        en_first_content: en_first_content,
                        second_content: second_content,
                        en_second_content: en_second_content,
                        third_content: third_content,
                        en_third_content: en_third_content,
                        person_content: person_content,
                        en_person_content: en_person_content,
                        tm_type: tm_type,
                        tm_css: tm_css
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'tech_html_template_list_list.aspx';
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
    添加样式模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Style Template
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">    

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tm_id">模板编号</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tm_id" runat="server" Width="300px" CssClass="form-control txt_tm_id" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">选择会议</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_mid" runat="server" Width="300px" CssClass="form-control ddl_mid"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tm_name">模板名称</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tm_name" runat="server" Width="300px" CssClass="form-control txt_tm_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tm_img">模板缩略图地址</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tm_img" runat="server" Width="300px" CssClass="form-control txt_tm_img"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="ddl_tm_type">模板类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_tm_type" runat="server" Width="300px" CssClass="form-control ddl_tm_type">
                <asp:ListItem Value="TMY001">TMY001</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tm_css">模板样式路径</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tm_css" runat="server" Width="300px" CssClass="form-control txt_tm_css"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_first_content">一级页面内容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_first_content" runat="server" Width="600px" CssClass="form-control txt_first_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_en_first_content">一级页面英文内容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_en_first_content" runat="server" Width="600px" CssClass="form-control txt_en_first_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_second_content">二级页面内容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_second_content" runat="server" Width="600px" CssClass="form-control txt_second_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_en_second_content">二级页面内英文容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_en_second_content" runat="server" Width="600px" CssClass="form-control txt_en_second_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_third_content">三级页面内容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_third_content" runat="server" Width="600px" CssClass="form-control txt_third_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_en_third_content">三级页面英文内容信息</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_en_third_content" runat="server" Width="600px" CssClass="form-control txt_en_third_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_person_content">会员中心中文模板</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_person_content" runat="server" Width="600px" CssClass="form-control txt_person_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_en_person_content">会员中心英文模板</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_en_person_content" runat="server" Width="600px" CssClass="form-control txt_en_person_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
