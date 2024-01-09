<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="tech_meeting_add.aspx.cs" Inherits="WebSite.Admin.MeetingPage.tech_meeting_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var mtype_id = $(".ddl_mtype_id").val();
                var mid = $(".txt_mid").val();
                var mname = $(".txt_mname").val();
                var address = $(".txt_address").val();
                var begindate = $(".txt_begindate").val();
                var enddate = $(".txt_enddate").val();
                //var mcontact = $(".txt_mcontact").val();
                //var mcontactmblie = $(".txt_mcontactmblie").val();
                var project_manager_id = $(".project_manager_id").val();
                var reguser = $(".ddl_reguser").val();
                var reguserdate = $(".txt_reguserdate").val();
                var article = $(".ddl_article").val();
                var articledate = $(".txt_articledate").val();
                var lodging = $(".ddl_lodging").val();
                var lodgingdate = $(".txt_lodgingdate").val();
                var reviewers = $(".ddl_reviewers").val();
                var reviewersdate = $(".txt_reviewersdate").val();
                var meetingcheckin_date = $(".txt_meetingcheckin_date").val();
                var regenddate = $(".txt_regenddate").val();
                var m_website = $(".txt_m_website").val();

                var is_live = $(".ddl_is_live").val();
                var is_playBack = $(".ddl_is_playBack").val();
                var is_recommend = $(".ddl_is_recommend").val();
                var is_xsh_show = $(".ddl_is_xsh_show").val();

                if (mid == "") {
                    alert('会议编码不能为空！');
                    $(".txt_mid").focus();
                    return false;
                }
                if (mname == "") {
                    alert('会议名称不能为空！');
                    $(".txt_mname").focus();
                    return false;
                }
                if (address == "") {
                    alert('开会地点不能为空！');
                    $(".txt_address").focus();
                    return false;
                }
                if (begindate == "") {
                    alert('会议开始时间不能为空！');
                    $(".txt_begindate").focus();
                    return false;
                }
                if (enddate == "") {
                    alert('会议结束时间不能为空！');
                    $(".txt_enddate").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_meetingHandler.ashx?type=add",
                    data: {
                        mtype_id: mtype_id,
                        mid: mid,
                        mname: mname,
                        address: address,
                        begindate: begindate,
                        enddate: enddate,
                        //mcontact: mcontact,
                        //mcontactmblie: mcontactmblie,
                        project_manager_id: project_manager_id,
                        reguser: reguser,
                        reguserdate: reguserdate,
                        article: article,
                        articledate: articledate,
                        lodging: lodging,
                        lodgingdate: lodgingdate,
                        reviewers: reviewers,
                        reviewersdate: reviewersdate,
                        meetingcheckin_date: meetingcheckin_date,
                        regenddate: regenddate,
                        m_website: m_website,
                        is_live: is_live,
                        is_playBack: is_playBack,
                        is_recommend: is_recommend,
                        is_xsh_show: is_xsh_show
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'tech_meeting_list.aspx';
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
    添加会议
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Meeting
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label">选择会议类型</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_mtype_id" runat="server" Width="300px" CssClass="form-control ddl_mtype_id"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mid">会议编码</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mid" runat="server" Width="300px" CssClass="form-control txt_mid" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mname">会议名称</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mname" runat="server" Width="300px" CssClass="form-control txt_mname"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_address">开会地点</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_address" runat="server" Width="300px" CssClass="form-control txt_address"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_begindate">会议开始时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_begindate" runat="server" Width="300px" CssClass="form-control datepicker txt_begindate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_enddate">会议结束时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_enddate" runat="server" Width="300px" CssClass="form-control datepicker txt_enddate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mcontact">会议负责人</label>
        <div class="col-sm-10">
            <%--<asp:TextBox ID="txt_mcontact" runat="server" Width="300px" CssClass="form-control txt_mcontact"></asp:TextBox>--%>
            <asp:DropDownList ID="ddl_project_manager_id" runat="server" Width="300px" CssClass="form-control project_manager_id"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <%--<div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mcontactmblie">会议负责人电话</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_mcontactmblie" runat="server" Width="300px" CssClass="form-control txt_mcontactmblie"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>--%>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否开启会员注册</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_reguser" runat="server" Width="300px" CssClass="form-control ddl_reguser">
                <asp:ListItem Value="1">开启</asp:ListItem>
                <asp:ListItem Value="2">关闭</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">前期注册截止时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_reguserdate" runat="server" Width="300px" CssClass="form-control datepicker txt_reguserdate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否开放征文</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_article" runat="server" Width="300px" CssClass="form-control ddl_article">
                <asp:ListItem Value="1">开启</asp:ListItem>
                <asp:ListItem Value="2">关闭</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">开放征文截止时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_articledate" runat="server" Width="300px" CssClass="form-control datepicker txt_articledate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否开放住宿预订</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_lodging" runat="server" Width="300px" CssClass="form-control ddl_lodging">
                <asp:ListItem Value="1">开启</asp:ListItem>
                <asp:ListItem Value="2">关闭</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">开放住宿截止时间</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_lodgingdate" runat="server" Width="300px" CssClass="form-control datepicker txt_lodgingdate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否开启审稿</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_reviewers" runat="server" Width="300px" CssClass="form-control ddl_reviewers">
                <asp:ListItem Value="1">开启</asp:ListItem>
                <asp:ListItem Value="2">关闭</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">审稿日期</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_reviewersdate" runat="server" Width="300px" CssClass="form-control datepicker txt_reviewersdate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">大会报到日期</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_meetingcheckin_date" runat="server" Width="300px" CssClass="form-control datepicker txt_meetingcheckin_date" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">注册缴费截止日期</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_regenddate" runat="server" Width="300px" CssClass="form-control datepicker txt_regenddate" data-format="yyyy-mm-dd"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">大会网址</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_m_website" runat="server" Width="300px" CssClass="form-control txt_m_website">http://</asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否有直播</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_is_live" runat="server" Width="300px" CssClass="form-control ddl_is_live">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="2">否</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否开回放</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_is_playBack" runat="server" Width="300px" CssClass="form-control ddl_is_playBack">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="2">否</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否推荐到学术号首页</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_is_recommend" runat="server" Width="300px" CssClass="form-control ddl_is_recommend">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="2">否</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label">是否在学术号会议显示</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddl_is_xsh_show" runat="server" Width="300px" CssClass="form-control ddl_is_xsh_show">
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
