<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_sch.aspx.cs" Inherits="DIY.HYManager.mobile_agenda.edit_sch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改日程</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>

    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>

    <script type="text/javascript" src="/js/artDialog.source.js"></script>

    <script type="text/javascript" src="/js/iframeTools.source.js"></script>

    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>

    <style type="text/css">
        .span_error {
            color: red;
        }

        .renming {
            width: 100%;
            height: auto;
            overflow: hidden;
            list-style: none;
        }

            .renming li {
                list-style: none;
                width: auto;
                display: inline-block;
                *display: inline;
                zoom: 1;
                padding: 1px 4px;
                border: 1px solid #ccc;
                margin: 5px;
                font-size: 12px;
                color: #000;
            }

                .renming li span {
                    margin-right: 5px;
                    font-size: 12px;
                }

                .renming li a {
                    color: #000;
                    display: inline-block;
                    *display: inline;
                    zoom: 1;
                    width: 12px;
                    height: 20px;
                    font-size: 14px;
                    background: url(/image/btn_close_02.jpg) center no-repeat;
                    background-size: 12px 12px;
                }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            getSession(); getSchedule();
        });

        function checkform() {
            $(".span_error").html("");
            var result = true;
            if ($("#schedulename").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#s_schedulename").html("请填写中文题目")
                return false;
            }
            return result;
        }


        function addRole(type) {
            OpenUrl('add_roles.aspx?type=' + type, '添加角色', 650, 250);
        }

        function showRoleName(fanid, name, type) {
            $("#td_" + type + " ul").append("<li ff=\"" + fanid + "\"><span>" + name + "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>");
        }

        function deleteRole(t) {
            $(t).parent().remove();

        }

        function getSession() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSession",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    $("#session_date").val(r.session_date);
                    $("#session_time").val(r.session_btime + "-" + r.session_etime);
                    $("#hall_name").val(r.hall_name);
                    $("#session_name").val(r.session_name);

                },
                complete: function (XMLHttpRequest, textStatus) { },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
            });
        }

        function getSchedule() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSchedule",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    $("#sch_name").val(r.sch_name);
                    $("#btime").val(r.sch_btime);
                    $("#etime").val(r.sch_etime);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { renyuan(); }
            });
        }

        function renyuan() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetScheduleUser",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var users = data.split("+");
                    $("#td_holder").children("ul").html(users[0]);
                    $("#td_reviewer").children("ul").html(users[1]);
                    $("#td_transfer").children("ul").html(users[2]);
                    $("#td_speaker").children("ul").html(users[3]);
                    $("#td_discusser").children("ul").html(users[4]);
                    $("#td_shuzhe").children("ul").html(users[5]);
                },
                complete: function (XMLHttpRequest, textStatus) { },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
            });
        }


        function getSpeaker() {
            $("#speaker").val($("#td_speaker ul li").eq(0).attr("ff"));
        }

        function eidtSession() {
            getRole();
            //getSpeaker();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=UpdateSchedule",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    if (r.result == 1) {
                        art.dialog.opener.LoadTable();
                        DialogOkClose('修改成功！', '', "yes");

                    } else {
                        dialogTime(r.msg, '');
                    }
                },
                complete: function (XMLHttpRequest, textStatus) { },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
            });
        }

        function getRole() {
            var holders = "";
            var transfers = "";
            var reviewers = "";
            var discussers = "";
            var shuzhe = "";
            var speaker = "";
            var index = 0;
            $("#td_holder ul li").each(function (index, d) {
                if (index == 0) {
                    //holders+=$(d).find("span").html();
                    //alert($(d).attr("ff"));
                    holders += $(d).attr("ff");
                } else {
                    holders += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_transfer ul li").each(function (index, d) {
                if (index == 0) {
                    transfers += $(d).attr("ff");
                } else {
                    transfers += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_reviewer ul li").each(function (index, d) {
                if (index == 0) {
                    reviewers += $(d).attr("ff");
                } else {
                    reviewers += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_discusser ul li").each(function (index, d) {
                if (index == 0) {
                    discussers += $(d).attr("ff");
                } else {
                    discussers += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_shuzhe ul li").each(function (index, d) {
                if (index == 0) {
                    shuzhe += $(d).attr("ff");
                } else {
                    shuzhe += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_speaker ul li").each(function (index, d) {
                if (index == 0) {
                    speaker += $(d).attr("ff");
                } else {
                    speaker += "," + $(d).attr("ff");
                }
            });

            $("#holders").val(holders);
            $("#transfers").val(transfers);
            $("#reviewers").val(reviewers);
            $("#discussers").val(discussers);
            $("#shuzhe").val(shuzhe);
            $("#speaker").val(speaker);
        }
    </script>

</head>
<body>
    <form id="Myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
        <input type="hidden" id="session_id" name="session_id" value="<%=session_id %>" />
        <input type="hidden" id="sch_id" name="sch_id" value="<%=sch_id %>" />
        <input type="hidden" id="speaker" name="speaker" value="" />
        <input type="hidden" name="holders" value="" id="holders" />
        <input type="hidden" name="transfers" value="" id="transfers" />
        <input type="hidden" name="reviewers" value="" id="reviewers" />
        <input type="hidden" name="discussers" value="" id="discussers" />
        <input type="hidden" name="shuzhe" value="" id="shuzhe" />
        <div class="p10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                <tr>
                    <th style="width: 80px;">会议日期</th>
                    <td>
                        <input type="text" id="session_date" name="session_date" class="txt txt300" style="background: #f1f1f1;"
                            readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <th>会议厅场</th>
                    <td>
                        <input type="text" id="hall_name" name="hall_name" class="txt txt300" readonly="readonly"
                            style="background: #f1f1f1;" />
                    </td>
                </tr>
                <tr>
                    <th>会议单元</th>
                    <td>
                        <input type="text" id="session_name" name="session_name" class="txt txt300" readonly="readonly"
                            style="background: #f1f1f1;" />
                    </td>
                </tr>
                <tr>
                    <th>单元时间</th>
                    <td>
                        <input type="text" id="session_time" name="session_time" class="txt txt300" readonly="readonly"
                            style="background: #f1f1f1;" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('holder')">主持人</a></th>
                    <td id="td_holder">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('transfer')">翻译</a></th>
                    <td id="td_transfer">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('reviewer')">点评</a></th>
                    <td id="td_reviewer">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('discusser')">讨论</a></th>
                    <td id="td_discusser">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('shuzhe')">术者</a></th>
                    <td id="td_shuzhe">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>讲题题目</th>
                    <td>
                        <input name="sch_name" id="sch_name" type="text" class="txt txt300" />
                        <span class="span_error" id="s_sch_name"></span>
                    </td>
                </tr>
                <tr>
                    <th>时间区间</th>
                    <td>
                        <input name="btime" id="btime" type="text" class="txt txt60" value="08:00" maxlength="5"
                            onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" />
                        -
                        <input name="etime" id="etime" type="text" class="txt txt60" value="18:00" maxlength="5"
                            onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" />
                        <span class="span_error" id="s_date"></span>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('speaker')">主讲人</a></th>
                    <td id="td_speaker">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <a class="btnblue" onclick="eidtSession()">确定</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
