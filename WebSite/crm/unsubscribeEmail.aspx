<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unsubscribeEmail.aspx.cs" Inherits="WebSite.crm.unsubscribeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>直邮退订页</title>
    
    <script type="text/javascript" src="/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        function sumbitGuest() {
            if ($("#account").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#account").focus();
                alert('邮箱帐号不能为空！');
                return false;
            }
            else if ($("#account").val().match("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$") == null) {
                $("#account").focus();
                alert('邮箱格式不正确！');
                return false;
            }
            else if ($("input:checkbox:checked").length == 0) {
                alert('请至少选择一个退订原因！');
                return false;
            }
            else {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/unsubscribeEmail.ashx?type=Send",
                    data: $("#ContactForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'true') {
                            alert(r.msg);
                        } else {
                            alert(r.msg);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { }
                });
            }
        }

        $(document).ready(function () {
            $('#btnCancel').click(function () {
                $('#tb_Content').hide();
                $('#tb_Content2').show();
            });
        });
    </script>

    <style>
        body{
            margin:0;
            padding:0;
            font-size:14px;
            line-height:28px;
            outline: 0;
            font: 12px/1.5 "Microsoft Yahei","微软雅黑",verdana;
        }
        * {
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }
        div {
            display: block;
        }        
        .g-bd {
            height: 1080px;
            padding-top: 240px;
        }
        .g-bd-list {
            padding-bottom: 80px;
            background-color: #f5f5f5;
        }
        .g-bd, .g-bd-list {
            z-index: 1;
            position: relative;
        }
        .m-app {
            width: 470px;
            height: 540px;
            background: #fff;
            margin: 0 auto;
            border: 1px solid #ddd;
            border-radius: 13px;
            overflow: hidden;
        }
        .m-app .header {
            font-size: 17px;
            height: 195px;
            line-height: 26px;
            padding: 50px 0 0 40px;
            font-weight: 900;
            background: url(/img/unemailheader.png);
        }
        .m-userEdit {
            padding: 20px 40px 0;
        }
        .f-fz14{
            font-size:14px;
        }
        .m-userEdit .accountContent {
            margin-top: 10px;
            line-height: 1;
        }
        .m-userEdit .reasonsWrap {
            margin-top: 20px;
            line-height: 1;
        }
        .m-userEdit .reasonsWrap td {
            line-height:28px;
        }
        .m-userEdit .buttonWrap {
            margin-top: 24px;
        }
        .m-userEdit .buttonWrap a {
            font-size: 14px!important;
        }
        .w-button {
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            width: 96px;
            height: 28px;
            padding: 5px;
            letter-spacing: normal;
            line-height: 26px;
            font-size: 12px;
            text-align: center;
            color: #333;
            border: 1px solid #ccc;
            background-color: #f5f5f5;
            text-decoration:none;
        }
        .w-button-primary {
            color: #fff;
            border: 1px solid #b4a078;
            background-color: #b4a078;
        }        
        .w-button, .w-linkicon:hover .txt {
            cursor: pointer;
        }
    </style>

</head>
<body>
    <form id="ContactForm">
        <div class="g-bd g-bd-list">

            <div class="m-app">

                <div class="header">
                    很抱歉让您来到这个页面，
                    <br />
                    iConference一直致力于打造好的生活理念，
                    <br />
                    提供给您最舒适的生活，希望您能留下退订原因，
                    <br />
                    帮助iConference越做越好！
                </div>

                <div class="m-userEdit f-fz14">

                    <div class="reasonsWrap">

                        <div id="tb_Content">

                            <div class="accountWrap">
                                请选择退订帐号:
                                <div class="accountContent">
                                    <div class="f-ib">
                                        <input name="account" id="account" placeholder="如：111111@qq.com" maxlength="30" value="" type="text" />
                                    </div>
                                </div>
                            </div>
                        
                            <table>
                                <tr>
                                    <td>请选择退订原因（可多选）：</td>
                                </tr>
                                <tr>
                                    <td><input name="reason" type="checkbox" value="对内容不感兴趣" /><span class="checkDesc">对内容不感兴趣</span></td>
                                </tr>
                                <tr>
                                    <td><input name="reason" type="checkbox" value="发送频率太高" /><span class="checkDesc">发送频率太高</span></td>
                                </tr>
                                <tr>
                                    <td><input name="reason" type="checkbox" value="标题与内容不符" /><span class="checkDesc">标题与内容不符</span></td>
                                </tr>
                                <tr>
                                    <td><input name="reason" type="checkbox" value="邮件不能正常显示" /><span class="checkDesc">邮件不能正常显示</span></td>
                                </tr>
                                <tr>
                                    <td><input name="reason" type="checkbox" value="要求注销账户" /><span class="checkDesc">要求注销账户</span></td>
                                </tr>
                            </table>
                        
                            <div class="buttonWrap">
                                <a class="w-button w-button-primary f-fz14" id="btnCancel" href="javascript:;">取消退订</a>
                                <a class="w-button f-fz14" id="btnSend" href="javascript:;" style="margin-left:10px;" onclick="sumbitGuest()">确认退订</a>
                            </div>

                        </div>

                        <table id="tb_Content2" style="display:none">
                            <tr>
                                <td>感谢您的信任，我们会努力越做越好！</td>
                            </tr>
                        </table>

                    </div>                    

                </div>

            </div>

        </div>
        
    </form>
</body>
</html>
