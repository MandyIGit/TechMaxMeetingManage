<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="DIY.CommonPage.header" %>
<script type="text/javascript">
    function Out_login() {
        art.dialog.confirm("<font size='2px'>您确定要退出登录吗？</font>", function () {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_LoginHandler.ashx?type=LogOutManager",
                success: function (data) {
                    window.location.href = "/login.aspx";
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTime(' 发生错误，请联系客服！ ', '');
                }
            });
        });
    }
    function LogOut() {
        art.dialog.confirm("<font size='2px'>您确定要退出登录吗？</font>", function () {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_LoginHandler.ashx?type=LogOut",
                success: function (data) {
                    window.location.href = "/login.aspx";
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTime(' 发生错误，请联系客服！ ', '');
                }
            });
        });
    }
</script>
<div id="head">
    <div id="head_top">
        <div class="page_logo">
            <img src="/user/img/smalllogo.png" />
        </div>
        <ul class="user_login">
            <%if (Request.Cookies[Common.WebCommon.MANAGER_KEY] != null)
            { %>
                <li><a href="/ProjectManager/index.aspx"><%=PMFullName %></a></li>
                <li class="right_none"><a href="javascript:;" onclick="Out_login()">退出登录</a></li>
            <%} else { %>
                <li><a href="javascript:;"><%=PMFullName %></a></li>
                <li class="right_none"><a href="javascript:;" onclick="LogOut()">退出登录</a></li>
            <%} %>
        </ul>
    </div>
</div>

<div class="clear"></div>

<div id="hot_warp">
    <div class="hot">

        <div class="hot_msm" id="con">
        </div>

    </div>
</div>
