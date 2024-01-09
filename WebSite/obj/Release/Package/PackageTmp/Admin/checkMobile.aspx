<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkMobile.aspx.cs" Inherits="WebSite.Admin.checkMobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Xenon Boostrap Admin Panel" />
    <meta name="author" content="" />
    <title>手机号码验证</title>
    <link href="css/style.css" rel="stylesheet" />
    <style type="text/css">
        .divtable {
            width: 380px;
            height: auto;
            margin: 100px auto 0 auto;
            overflow: hidden;
        }

        .divtable table {
            width: 100%;
            height: auto;
            border: solid 1px #ddd;
        }

        .divtable table th {
            padding: 5px 10px;
            text-align: left;
            min-height: 24px;
            overflow: hidden;
            color: #333;
            font-size: 13px;
            width: 11%;
        }

            .divtable table th[th="th"] {
                text-align: center;
                font-size: 16px;
                color: #333;
                font-weight: bold;
                line-height: 35px;
                background: #f1f1f1;
            }

        .divtable table td {
            padding: 5px 3px;
            min-height: 24px;
            overflow: hidden;
            width: 50%;
        }

        .divtable table span {
            color: #F00;
            margin: 1px;
        }

        .divtable table input {
            width: 95%;
            padding-left: 3px;
            height: 26px;
            border: 1px solid #dcdcdc;
            margin: 3px 5px;
            color: #333;
            outline: medium;
        }
        .divtable table textarea {
            width: 95%;
            padding-left: 3px;
            height: 300px;
            border: 1px solid #dcdcdc;
            margin: 3px 5px;
            color: #333;
            outline: medium;
        }

        .divtable table label {
            float: left;
            margin-top: 7px;
            margin-right:10px;
        }

            .divtable table label[fontsize="fontsize"] {
                margin-left: 8px;
                font-size: 14px;
            }

            .divtable table label[ff="ff"] {
                margin-top: 8px;
            }

        .divtable table input[type=radio] {
            width: 14px;
            height: 14px;
            margin: 10px 5px 0px;
            float: left;
            border: none !important;
        }

        .divtable table input[type=checkbox] {
            width: 14px;
            height: 14px;
            margin: 10px 5px 0px;
            float: left;
        }

        .divtable table select {
            width: 96.5%;
            padding-left: 5px;
            height: 28px;
            border: 1px solid #dcdcdc;
            margin: 3px 5px;
            float: left;
            color: #333;
            outline: medium;
        }

            .divtable table select.chang {
                width: 98.5%;
            }

        .divtable table .radiohang {
            width: 100%;
            height: auto;
            margin: 3px 5px;
        }

            .divtable table .radiohang input {
                width: 14px;
                height: 14px;
                border: none;
                float: left;
                margin: 3px 3px;
            }

        .divtable table .radio {
            width: auto;
            height: auto;
            float: left;
            margin: 3px 25px 3px 5px;
            overflow: hidden;
        }

            .divtable table .radio input {
                width: 14px;
                height: 14px;
                border: none;
                float: left;
                margin: 3px 3px;
            }

        .divtable table input.duan {
            width: 14.67%;
        }

        .divtable table input.chang {
            width: 28.65%;
        }

        .divtable table input[type=button] {
            width: 120px;
            height: 28px;
            background: #050C40;
            cursor: pointer;
            text-align: center;
            line-height: 28px;
            padding: 0px;
            margin-right: 10px;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            border: none;
            border-bottom-left-radius: 5px;
            border-top-left-radius: 5px;
            border-bottom-right-radius: 5px;
            border-top-right-radius: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
        }

        .divtable table td .nofind {
            font-size: 12px;
            line-height: 28px;
            color: #333;
            clear: both;
        }

            .divtable table td .nofind p {
                margin: auto 5px;
            }

                .divtable table td .nofind p span {
                    font-size: 12px;
                    color: #999;
                }
    </style>
    <script src="/Admin/Xenon/assets/js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">

        function CheckEnterKey(evt) { if (evt.keyCode == 13) { $("#save_edit").click(); } }

        function SmsSend() {

            if ($("#mobile").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#mobile").focus();
                alert('手机号不能为空');
                return false;
            }
            else if ($("#mobile").val().match('^[1][0-9]{10}$') == null) {
                $("#mobile").focus();
                alert('手机号格式不正确');
                return false;
            }
            else {
                
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_adminHandler.ashx?type=GetYanZhengMa",
                    data: $("#MyForm").serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        $("#getCode").removeAttr("disabled");
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            time(this);
                        } else {
                            alert(r.msg)
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { },
                    complete: function (XMLHttpRequest, textStatus) { }
                });
                
            }
            
        }

        //验证码倒计时
        var wait = 120;
        function time(obj) {
            if(wait==0) {
                $("#getCode").removeAttr("disabled");
                $("#getCode").val("获取验证码");
                wait = 120;
            }else {
                $("#getCode").attr("disabled","true");
                $("#getCode").val(wait+"秒后重试");
                wait--;
                setTimeout(function() {     //倒计时方法
                    time(obj);
                },1000);    //间隔为1s
            }
        }

        $(document).ready(function () {
            var tel = '<%=mobile %>';
            $("#phone").html(tel.substr(0, 3) + '****' + tel.substr(7));

            //取消关闭窗口
            $("#cancel_but").bind("click", function () {
                window.parent.CloseTheWindow();
            });

            $("#excute_but").bind("click", function () {
                if ($("#mobile").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                    $("#mobile").focus();
                    alert('手机号不能为空');
                    return false;
                }
                else if ($("#mobile").val().match('^[1][0-9]{10}$') == null) {
                    $("#mobile").focus();
                    alert('手机号格式不正确');
                    return false;
                }
                else if ($("#yanzhengma").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                    $("#yanzhengma").focus();
                    alert('手机验证码不能为空');
                    return false;
                }
                else if ($("#yanzhengma").val().length != 4) {
                    $("#yanzhengma").focus();
                    alert('手机验证码不少于4位');
                    return false;
                }
                else {
                    $.ajax({
                        type: "post",
                        url: "/AjaxResponse/tech_adminHandler.ashx?type=CheckYanZhengMa",
                        data: $("#MyForm").serialize(),
                        beforeSend: function (XMLHttpRequest, textStatus) { },
                        success: function (data) {
                            if (data == "success") {
                                alert('登录成功！');
                                location.href = 'index.aspx';
                            } else {
                                alert('登录失败！');
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { },
                        complete: function (XMLHttpRequest, textStatus) { }
                    });
                }
            })

        })

    </script>
</head>
<body>
    <form id="MyForm">
        <input id="mobile" name="mobile" type="hidden" value="<%=mobile %>" />
        <div class="divtable" id="tab_content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th th="th" colspan="2">
                        手机验证码验证
                    </th>
                </tr>                
                <tr>
                    <th colspan="2"><span>*</span>手机号码</th>
                </tr>
                <tr>
                    <td colspan="2" id="phone" style="padding-left: 18px;">
                        
                    </td>
                </tr>

                <tr>
                    <th colspan="2">
                        <span>*</span>手机验证码
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="yanzhengma" name="yanzhengma" maxlength="4" />
                    </td>
                    <td>                        
                        <input id="getCode" type="button" value="获取手机验证码" onclick="SmsSend()" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <input type="button" id="excute_but" value="确  定" class="true" />
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>

    </form>

    <div id="waiting_div" style="display:none; margin:0px auto; padding:0px; text-align:center;">
        <img src="images/waiting_03.gif" alt="" style="margin-top: 210px; width: 50px; height: auto;" />
    </div>

</body>
</html>
