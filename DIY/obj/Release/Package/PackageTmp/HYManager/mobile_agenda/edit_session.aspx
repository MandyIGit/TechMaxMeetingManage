<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_session.aspx.cs" Inherits="DIY.HYManager.mobile_agenda.edit_session" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加修改会议单元</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />

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

    <script language="javascript" type="text/javascript"> 

        $(document).ready(function () {
            GetHallList();
        });

        function GetHallList() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetHallList",
                data: $("#Myform").serialize(),
                success: function (data) {
                    $("#hall_id").html("");
                    var objJSON = eval("(" + data + ")");
                    $.each(objJSON.plist, function (index, d) {
                        $("#hall_id").append($("<option/>").html(d.name).val(d.value));
                    });
                    GetMeetingTime();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }

        function GetMeetingTime() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetMeetingTime",
                data: $("#Myform").serialize(),
                success: function (data) {
                    $("#session_date").html("");
                    var objJSON = eval("(" + data + ")");
                    $.each(objJSON.plist, function (index, d) {
                        $("#session_date").append($("<option/>").html(d.name).val(d.value));
                    });
                    getSession();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { }
            });
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

        function addSession() {
            if (panduan()) {
                getRole();
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/mobile_agendaHandler.ashx?type=UpdateSession",
                    data: $("#Myform").serialize(),
                    beforeSend: function (XMLHttpRequest) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 1) {
                            art.dialog.opener.getList();
                            DialogOkClose('修改成功！', '', "yes");

                        } else {
                            dialogTime(r.msg, '');
                        }
                    },
                    complete: function (XMLHttpRequest, textStatus) { },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
                });
            }
        }


        function getRole() {
            var holders = "";
            var transfers = "";
            var reviewers = "";
            var discussers = "";
            var meetingusers = "";

            var zhuxi = "";
            var zhixingzhuxi = "";
            var huiyizhuxi = "";
            var teyaodianpingjiabin = "";
            var pingwei = "";
            var dianpingtaolun = "";
            var shuzhe = "";
            var shoushuzhuchi = "";
            var dianpingjiabin = "";

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
            $("#td_meetinguser ul li").each(function (index, d) {
                if (index == 0) {
                    meetingusers += $(d).attr("ff");
                } else {
                    meetingusers += "," + $(d).attr("ff");
                }
            });

            index = 0;
            $("#td_zhuxi ul li").each(function (index, d) {
                if (index == 0) {
                    zhuxi += $(d).attr("ff");
                } else {
                    zhuxi += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_zhixingzhuxi ul li").each(function (index, d) {
                if (index == 0) {
                    zhixingzhuxi += $(d).attr("ff");
                } else {
                    zhixingzhuxi += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_huiyizhuxi ul li").each(function (index, d) {
                if (index == 0) {
                    huiyizhuxi += $(d).attr("ff");
                } else {
                    huiyizhuxi += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_teyaodianpingjiabin ul li").each(function (index, d) {
                if (index == 0) {
                    teyaodianpingjiabin += $(d).attr("ff");
                } else {
                    teyaodianpingjiabin += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_pingwei ul li").each(function (index, d) {
                if (index == 0) {
                    pingwei += $(d).attr("ff");
                } else {
                    pingwei += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_dianpingtaolun ul li").each(function (index, d) {
                if (index == 0) {
                    dianpingtaolun += $(d).attr("ff");
                } else {
                    dianpingtaolun += "," + $(d).attr("ff");
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
            $("#td_shoushuzhuchi ul li").each(function (index, d) {
                if (index == 0) {
                    shoushuzhuchi += $(d).attr("ff");
                } else {
                    shoushuzhuchi += "," + $(d).attr("ff");
                }
            });
            index = 0;
            $("#td_dianpingjiabin ul li").each(function (index, d) {
                if (index == 0) {
                    dianpingjiabin += $(d).attr("ff");
                } else {
                    dianpingjiabin += "," + $(d).attr("ff");
                }
            });

            $("#holders").val(holders);
            $("#transfers").val(transfers);
            $("#reviewers").val(reviewers);
            $("#discussers").val(discussers);
            $("#meetingusers").val(meetingusers);

            $("#zhuxi").val(zhuxi);
            $("#zhixingzhuxi").val(zhixingzhuxi);
            $("#huiyizhuxi").val(huiyizhuxi);
            $("#teyaodianpingjiabin").val(teyaodianpingjiabin);
            $("#pingwei").val(pingwei);
            $("#dianpingtaolun").val(dianpingtaolun);
            $("#shuzhe").val(shuzhe);
            $("#shoushuzhuchi").val(shoushuzhuchi);
            $("#dianpingjiabin").val(dianpingjiabin);

        }

        function getSession() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSession",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    if (r.result == 1) {
                        $("#session_date").find("[value='" + r.session_date + "']").attr("selected", true);
                        $("#session_btime").val(r.session_btime);
                        $("#session_etime").val(r.session_etime);
                        $("#hall_id").val(r.hall_id).attr("selected", true);
                        $("#session_name").val(r.session_name);
                        renuser();
                        //$("#td_holder").children("ul").html(r.holders);
                        //$("#td_transfer").children("ul").html(r.transfers);
                        //$("#td_reviewer").children("ul").html(r.reviewers);


                        //                       var holders=r.holders.split(",");
                        //                       var transfers=r.transfers.split(",");
                        //                       var reviewers=r.reviewers.split(",");
                        //                       if(r.holders.length!=0){
                        //                         $(holders).each(function(i,d){
                        //                            $("#td_holder ul").append("<li><span>"+d+"</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>");
                        //                         })
                        //                       }
                        //                       if(r.transfers.length!=0){
                        //                          $(transfers).each(function(i,d){                     
                        //                            $("#td_transfer ul").append("<li><span>"+d+"</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>");
                        //                         })
                        //                       }
                        //                       if(r.reviewers.length!=0){
                        //                         $(reviewers).each(function(i,d){                     
                        //                            $("#td_reviewer ul").append("<li><span>"+d+"</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>");
                        //                         })
                        //                       }
                    } else { alert("暂无数据"); }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }

        function renuser() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSessionUser",
                data: $("#Myform").serialize(),
                beforeSend: function (XMLHttpRequest) { },
                success: function (data) {
                    var users = data.split("+");
                    $("#td_holder").children("ul").html(users[0]);
                    $("#td_reviewer").children("ul").html(users[1]);
                    $("#td_transfer").children("ul").html(users[2]);
                    $("#td_discusser").children("ul").html(users[3]);
                    $("#td_meetinguser").children("ul").html(users[4]);

                    $("#td_zhuxi").children("ul").html(users[5]);
                    $("#td_zhixingzhuxi").children("ul").html(users[6]);
                    $("#td_huiyizhuxi").children("ul").html(users[7]);
                    $("#td_teyaodianpingjiabin").children("ul").html(users[8]);
                    $("#td_pingwei").children("ul").html(users[9]);
                    $("#td_dianpingtaolun").children("ul").html(users[10]);
                    $("#td_shuzhe").children("ul").html(users[11]);
                    $("#td_shoushuzhuchi").children("ul").html(users[12]);
                    $("#td_dianpingjiabin").children("ul").html(users[13]);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }

        function panduan() {
            if ($("#session_btime").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("时间区间不能为空！");
                return false;
            } else if ($("#session_etime").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("时间区间不能为空！");
                return false;
            } else if ($("#hall_id").val() == "0") {
                alert("请选择会议厅场！");
                return false;
            } else if ($("#session_name").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("单元名称不能为空！");
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <form id="Myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />

        <input type="hidden" name="holders" value="" id="holders" />
        <input type="hidden" name="transfers" value="" id="transfers" />
        <input type="hidden" name="reviewers" value="" id="reviewers" />
        <input type="hidden" name="discussers" value="" id="discussers" />
        <input type="hidden" name="meetingusers" value="" id="meetingusers" />

        <input type="hidden" name="zhuxi" value="" id="zhuxi" />
        <input type="hidden" name="zhixingzhuxi" value="" id="zhixingzhuxi" />
        <input type="hidden" name="huiyizhuxi" value="" id="huiyizhuxi" />
        <input type="hidden" name="teyaodianpingjiabin" value="" id="teyaodianpingjiabin" />
        <input type="hidden" name="pingwei" value="" id="pingwei" />
        <input type="hidden" name="dianpingtaolun" value="" id="dianpingtaolun" />
        <input type="hidden" name="shuzhe" value="" id="shuzhe" />
        <input type="hidden" name="shoushuzhuchi" value="" id="shoushuzhuchi" />
        <input type="hidden" name="dianpingjiabin" value="" id="dianpingjiabin" />

        <input type="hidden" name="session_id" id="session_id" value="<%=session_id%>" />
        <div class="p10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                <tr>
                    <th style="width: 200px;">会议日期</th>
                    <td>
                        <select id="session_date" name="session_date" class="s300">
                            <option value="0">加载中</option>
                        </select>
                        <span class="span_error" id="s_meetingtime"></span>
                    </td>
                </tr>
                <tr>
                    <th>时间区间</th>
                    <td>
                        <input name="session_btime" id="session_btime" type="text" class="txt txt60" value="08:00"
                            maxlength="5" onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" />
                        -
                        <input name="session_etime" id="session_etime" type="text" class="txt txt60" value="18:00"
                            maxlength="5" onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" /></td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:OpenUrl('modifyhall.aspx?hid=0','增加会议厅会场',450,200);"
                            class="u">会议厅场</a></th>
                    <td>
                        <select id="hall_id" name="hall_id" class="s300">
                            <option value="0">加载中</option>
                        </select>
                        <span class="span_error" id="s_meetinghall"></span>
                    </td>
                </tr>
                <tr>
                    <th>单元名称</th>
                    <td>
                        <input type="text" class="txt txt300" name="session_name" id="session_name" />
                        <span class="span_error" id="s_meetingname"></span>
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
                        <a href="javascript:void(0);" class="u" onclick="addRole('reviewer')">点评专家</a></th>
                    <td id="td_reviewer">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('discusser')">讨论嘉宾</a></th>
                    <td id="td_discusser">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('meetinguser')">参会</a></th>
                    <td id="td_meetinguser">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>

                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('zhuxi')">主席</a></th>
                    <td id="td_zhuxi">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('zhixingzhuxi')">执行主席</a></th>
                    <td id="td_zhixingzhuxi">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('huiyizhuxi')">分会场主席</a></th>
                    <td id="td_huiyizhuxi">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('pingwei')">共同主席</a></th>
                    <td id="td_pingwei">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('teyaodianpingjiabin')">特邀点评嘉宾</a></th>
                    <td id="td_teyaodianpingjiabin">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('dianpingtaolun')">点评讨论</a></th>
                    <td id="td_dianpingtaolun">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('dianpingjiabin')">名家观点</a></th>
                    <td id="td_dianpingjiabin">
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
                    <th>
                        <a href="javascript:void(0);" class="u" onclick="addRole('shoushuzhuchi')">手术主持及解说专家</a></th>
                    <td id="td_shoushuzhuchi">
                        <ul class="renming">
                        </ul>
                    </td>
                </tr>

                <tr>
                    <th>&nbsp;</th>
                    <td>
                        <a class="btnblue" onclick="addSession()">确定</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
