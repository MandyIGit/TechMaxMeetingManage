<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="email_template_add.aspx.cs" Inherits="WebSite.Admin.EmailTemplatePage.email_template_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var mid = $(".ddl_mid").val();
                var tp_name = $(".txt_tp_name").val();
                var tp_content = $(".txt_tp_content").val();
                var tel = $(".txt_tel").val();
                var fax = $(".txt_fax").val();
                var email = $(".txt_email").val();
                var web_url = $(".txt_web_url").val();
                var m_p_content_ch = $(".txt_m_p_content_ch").val();
                var m_p_content_en = $(".txt_m_p_content_en").val();
                var h_p_content_ch = $(".txt_h_p_content_ch").val();
                var h_p_content_en = $(".txt_h_p_content_en").val();

                if (mid == "") {
                    alert('会议编码不能为空！');
                    $(".ddl_mid").focus();
                    return false;
                }
                if (tp_name == "") {
                    alert('模板名称不能为空！');
                    $(".txt_tp_name").focus();
                    return false;
                }
                if (tel == "") {
                    alert('秘书处电话不能为空！');
                    $(".txt_tel").focus();
                    return false;
                }
                if (email == "") {
                    alert('秘书处邮箱不能为空！');
                    $(".txt_email").focus();
                    return false;
                }
                if (web_url == "") {
                    alert('大会网址不能为空！');
                    $(".txt_web_url").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/email_templateHandler.ashx?type=add",
                    data: {
                        mid: mid,
                        tp_name: tp_name,
                        tp_content: tp_content,
                        tel: tel,
                        fax: fax,
                        email: email,
                        web_url: web_url,
                        m_p_content_ch: m_p_content_ch,
                        m_p_content_en: m_p_content_en,
                        h_p_content_ch: h_p_content_ch,
                        h_p_content_en: h_p_content_en
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'email_template_list.aspx';
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
    添加邮件模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Email Template
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
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
        <label class="col-sm-2 control-label" for="txt_tp_name">模板名称</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tp_name" runat="server" Width="300px" CssClass="form-control txt_tp_name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tp_content">模板内容</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tp_content" runat="server" Width="600px" CssClass="form-control txt_tp_content" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_tel">秘书处电话</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_tel" runat="server" Width="300px" CssClass="form-control txt_tel"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_fax">秘书处传真</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_fax" runat="server" Width="300px" CssClass="form-control txt_fax"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_email">秘书处邮箱</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_email" runat="server" Width="300px" CssClass="form-control txt_email"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_web_url">大会网址</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_web_url" runat="server" Width="300px" CssClass="form-control txt_web_url"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_m_p_content_ch">中宾参会缴费确认模板温馨提示内容</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_m_p_content_ch" runat="server" Width="600px" CssClass="form-control txt_m_p_content_ch" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_m_p_content_en">外宾参会缴费确认模板温馨提示内容</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_m_p_content_en" runat="server" Width="600px" CssClass="form-control txt_m_p_content_en" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_h_p_content_ch">中宾酒店缴费确认模板温馨提示内容</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_h_p_content_ch" runat="server" Width="600px" CssClass="form-control txt_h_p_content_ch" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_h_p_content_en">外宾酒店缴费确认模板温馨提示内容</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_h_p_content_en" runat="server" Width="600px" CssClass="form-control txt_h_p_content_en" Height="200px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
