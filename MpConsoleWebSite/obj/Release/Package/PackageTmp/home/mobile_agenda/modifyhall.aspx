<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifyhall.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_agenda.modifyhall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加会议厅会场</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>

    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>

    <script type="text/javascript" src="/js/artDialog.source.js"></script>

    <script type="text/javascript" src="/js/iframeTools.source.js"></script>

    <style type="text/css">
        .span_error {
            color: red;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            LoadTable();
        });

        function LoadTable() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetHall",
                data: $("#Myform").serialize(),
                success: function (data) {
                    var objJSON = eval("(" + data + ")");
                    $("#meetinghall").val(objJSON.hallname);
                    $("#en_meetinghall").val(objJSON.en_hallname);
                    $("#orders").val(objJSON.orders);
                    $("#channelId").val(objJSON.channelId);
                    $("#secretkey").val(objJSON.secretkey);
                    $("#zhibo_url").val(objJSON.zhibo_url);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }

        function postDate() {
            if (checktext()) {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/mobile_agendaHandler.ashx?type=ModefyHall",
                    data: $("#Myform").serialize(),
                    success: function (data) {
                        var ting = $("#meetinghall").val();
                        art.dialog.close();
                        art.dialog.opener.GetHallList();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        dialogTimeClose("操作失败，请联系客服");
                    }
                });
            }
        }

        function checktext() {
            $(".span_error").html("");
            if ($("#meetinghall").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#errormeetinghall").html(" 请填写会议厅名称");
                return false;
            }
            if ($("#en_meetinghall").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#errorenmeetinghall").html(" 请填写会议厅英文名称");
                return false;
            }
            return true;
        }

    </script>

</head>
<body>
    <form id="Myform">
        <input type="hidden" id="hallid" name="hallid" value="<%=hallid %>" />
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
            <tr>
                <th colspan="2">会议厅信息</th>
            </tr>
            <tr>
                <th>会议厅名称</th>
                <td>
                    <input name="meetinghall" type="text" class="txt" id="meetinghall" />
                    <span class="span_error" id="errormeetinghall"></span>
                </td>
            </tr>
            <tr>
                <th>会议厅英文名称</th>
                <td>
                    <input name="en_meetinghall" type="text" class="txt" id="en_meetinghall" />
                    <span class="span_error" id="errorenmeetinghall"></span>
                </td>
            </tr>
            <tr>
                <th>
                    排序（只能填数字）</th>
                <td>
                    <input name="orders" type="text" class="txt" id="orders" />
                    <span class="span_error" id="errororders"></span>
                </td>
            </tr>
            <%if (hallid != "0")
                { %>
            <tr>
                <th colspan="2">直播链接设置</th>
            </tr>
            <tr>
                <th>
                    保利威频道号</th>
                <td>
                    <input name="channelId" type="text" class="txt" id="channelId" />
                </td>
            </tr>
            <tr>
                <th>
                    频道独立授权（SecretKey）</th>
                <td>
                    <input name="secretkey" type="text" class="txt" id="secretkey" />
                </td>
            </tr>
            <tr>
                <th>
                    其它平台直播链接</th>
                <td>
                    <input name="zhibo_url" type="text" class="txt" id="zhibo_url" />
                </td>
            </tr>
            <%} %>
            <tr>
                <th></th>
                <td>
                    <a class="btnblue" href="javascript:postDate()">确定</a></td>
            </tr>
        </table>
    </form>

</body>
</html>
