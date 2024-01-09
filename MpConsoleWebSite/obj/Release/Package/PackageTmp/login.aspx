<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MpConsoleWebSite.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/admin_main.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js" charset="utf-8"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript"> 

        function mLogin() {
            if ($("#mmid").val() == '') {
                alert('会议编码不能为空！');
                return;
            } else if ($("#mpwd").val() == '') {
                alert('会议密码不能为空！');
                return;
            } else if ($("#mcode").val() == '') {
                alert('验证码不能为空！');
                return;
            } else {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_LoginHandler.ashx?type=mlogin",
                    data: $("#mForm").serialize(),
                    success: function (data) {
                        var objJSON = eval("(" + data + ")");
                        var result = objJSON.result;
                        if (result == '0') {
                            dialogTime('登录成功！', '');
                            window.location.href = "/home/index.aspx";
                        }
                        else if (result == '-1') { dialogTime('帐号或者密码错误！', ''); }
                        else if (result == '-2') { $('#m_img_code').attr("src", "/CommonPage/Vecode.aspx?t='+(new Date()).valueOf()"); dialogTime('验证码错误！', ''); }
                        else if (result == '-3') { dialogTime('验证码无效，请刷新验证码！', ''); }
                    }
                });
            }
        }

        function uLogin() {
            if ($("#login_name").val() == '') {
                alert('用户名不能为空！');
                return;
            } else if ($("#login_pwd").val() == '') {
                alert('密码不能为空！');
                return;
            } else if ($("#code").val() == '') {
                alert('验证码不能为空！');
                return;
            } else {
                $.ajax({
                    type: "post",
                    url: '/AjaxResponse/tech_LoginHandler.ashx?type=ulogin',
                    data: $("#uForm").serialize(),
                    success: function (data) {
                        if (data == "OK") {
                            dialogTime('登录成功！', '');
                            window.location.href = "/ProjectManager/index.aspx";
                        }
                        else if (data == "code_error") {
                            $('#img_code').attr("src", "/CommonPage/Vecode.aspx?t='+(new Date()).valueOf()");
                            dialogTime('验证码错误！', '');
                        }
                        else {
                            dialogTime('' + data + '', '');
                        }
                    }
                });
            }
        }

        function mloginbox() {
            $('#m_tab').css('color', '#246af4');
            $('#u_tab').css('color', '#2D3745');
            $('#mForm').show();
            $('#uForm').hide();
        }

        function uloginbox() {
            $('#u_tab').css('color', '#246af4');
            $('#m_tab').css('color', '#2D3745');
            $('#uForm').show();
            $('#mForm').hide();
        }

        $(document).ready(function () {
            $('#m_tab').css('color', '#246af4');
            $('#u_tab').css('color', '#2D3745');
            $('#mForm').hide();
            $('#uForm').show();
        });

    </script>
</head>

<body scroll="no" class="indexbody">

    <div class="Login">
        <div class="Header_login">
        </div>
        <div class="Login_box">
            <div class="Login_box_cont">
                <div class="Login_box_cont_left">
                    <img src="/image/S_login_10.png" width="200" height="40" alt="" />
                    <p>版权所有:TECH MAX 京ICP备13020642号</p>
                </div>
                <div class="Login_box_cont_right">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="L_infotablel">
                        <tr>
                            <td colspan="2">
                                <img src="/image/l_Txt.gif" alt="" /></td>
                        </tr>
                    </table>

                    <table border="0" cellspacing="0" cellpadding="0" class="L_infotablel">
                        <tr>                            
                            <td style="font-size: 14px;"><a href="javascript:void(0);" id="u_tab" onclick="uloginbox()">用户登录</a></td>
                            <td style="font-size: 14px;"><a href="javascript:void(0);" id="m_tab" onclick="mloginbox()">会议编码登录</a></td>
                        </tr>
                    </table>

                    <form id="uForm">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="L_infotablel">
                            <tr>
                                <td>用户名：</td>
                                <td>
                                    <input type="text" id="login_name" name="login_name" class="txt txt200 fl" /></td>
                            </tr>
                            <tr>
                                <td>密&nbsp;&nbsp;&nbsp;码：</td>
                                <td>
                                    <input type="password" id="login_pwd" name="login_pwd" class="txt txt200 fl" /></td>
                            </tr>
                            <tr>
                                <td>验证码：</td>
                                <td>
                                    <input type="text" id="code" name="code" class="txt txt60 fl" />&#160;
                                <img id="img_code" style="width: 55px; height: 25px; cursor: pointer;" src="/CommonPage/VeCode.aspx" onclick="this.src='/CommonPage/VeCode.aspx?t='+(new Date()).valueOf()" alt="验证码" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td><a class="Login_bj" href="javascript:void(0)" onclick="uLogin()">登录</a></td>
                            </tr>
                        </table>
                    </form>

                    <form id="mForm">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="L_infotablel">
                            <tr>
                                <td>会议编码：</td>
                                <td>
                                    <input type="text" id="mmid" name="mmid" class="txt txt200 fl" /></td>
                            </tr>
                            <tr>
                                <td>会议密码：</td>
                                <td>
                                    <input type="password" id="mpwd" name="mpwd" class="txt txt200 fl" /></td>
                            </tr>
                            <tr>
                                <td>验证码：</td>
                                <td>
                                    <input type="text" id="mcode" name="mcode" class="txt txt60 fl" />&#160;
                                    <img id="m_img_code" style="width: 55px; height: 25px; cursor: pointer;" src="/CommonPage/VeCode.aspx" onclick="this.src='/CommonPage/VeCode.aspx?t='+(new Date()).valueOf()" alt="验证码" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td><a class="Login_bj" href="javascript:void(0)" onclick="mLogin()">登录</a></td>
                            </tr>
                        </table>
                    </form>

                    
                </div>
            </div>
        </div>
    </div>
</body>
</html>
