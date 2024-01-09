<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="session_list.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_agenda.session_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学术会议日程设置管理</title>
    <link href="/style/main.css" rel="stylesheet" type="text/css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script language="javascript" type="text/javascript">     
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '日程管理';
            LoadTable();
        });


        function LoadTable() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetMeetingTime",
                data: $("#Myform").serialize(),
                success: function (data) {
                    $("#session_date").html("");
                    var objJSON = eval("(" + data + ")");
                    $.each(objJSON.plist, function (index, d) {
                        $("#session_date").append($("<option/>").html(d.name).val(d.value));
                    })
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { getList(); }
            });
        }
        function getList() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSchedule_HallListByTime",
                data: $("#Myform").serialize(),
                beforeSend: function () { $("#span_loading").show(); },
                success: function (data) { $("#tbContent").html(data); },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { $("#span_loading").hide(); }
            });
        }

        function research() {
            $("#pageindex").val(1);
            getList();
        }

        function getAllValue(chkname) {
            var re = $("#" + chkname).attr("checked");
            var checkboxs = document.getElementsByName("s_" + chkname);
            for (var i = 0; i < checkboxs.length; i++) {
                var e = checkboxs[i]; e.checked = re;
            }
        }
        //获取选择的ids
        function getIds() {
            var allVals = [];
            var arrChk = $("input[type='checkbox'].check_class:checked");
            $(arrChk).each(function () {
                allVals.push(this.id);
            });
            $("#IDs").val(allVals);
        }
        function Delete() {
            getIds();
            if ($("input[type='checkbox'].check_class:checked").length) {
                art.dialog.confirm("<font size='2px'>您确定要删除吗？</font>", function () {
                    $.ajax({
                        type: "post",
                        url: "/AjaxResponse/mobile_agendaHandler.ashx?type=DeleteMsg",
                        data: $("#Myform").serialize(),
                        success: function (data) {
                            getList();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            dialogTime(' 发生错误，请联系客服！ ', '');
                        }
                    });

                });
            } else { dialogTime(' 没有任何选中项！ ', ''); }
        }

    </script>

</head>
<body>
    <form id="Myform">

        <input type="hidden" name="IDs" id="IDs" />
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />

        <div class="topmenu">
            <ul style="float: left;">
                <li><span>会议日期：</span>
                    <select name="session_date" id="session_date">
                        <option value="0">加载中...</option>
                    </select>
                </li>
                <li><span style="width: 50px;"></span><a class="btnblue" onclick="research()">查询</a>
                    <span id="span_loading" style="display: none;">
                        <img alt="加载中" src="/image/loading.gif" />加载中</span>
                </li>
            </ul>

            <div class="clear">
            </div>
        </div>
        <div class="h10">
        </div>
        <div class="listtable">
            <div id="tbContent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotable">
                    <tr>
                        <td rowspan="7">加载中..
                        </td>
                    </tr>
                </table>

            </div>
            <div class="h10">
            </div>
            <div class="listmenu">
                <%-- <a class="btnwhite" href="javascript:ExportExcel()">导出数据</a> --%>
                <a class="btnwhite" onclick="updatehall()">修改会议厅</a>
                <a class="btnwhite" onclick="Delete()">删除会议单元</a>
                <a class="btnwhite" onclick="OpenUrl('/home/mobile_agenda/add_session.aspx','增加会议单元',980,600)">增加会议单元</a>

                <div class="clear"></div>
                <script type="text/javascript">                 
                    function addhall() {
                        OpenUrl('/home/mobile_agenda/modifyhall.aspx?hid=0', '增加会议厅会场', 450, 200);
                    }
                    function updatehall() {
                        OpenUrl('/home/mobile_agenda/hall_list.aspx', '修改会议厅会场', 450, 300);
                    }

                </script>
                <div class="clear">
                </div>
            </div>
            <div class="h10">
            </div>
            <input type="hidden" name="pageindex" id="pageindex" value="1" />
            <div id="pager">
            </div>
            <div class="h10">
            </div>
        </div>
    </form>
    <table>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</body>
</html>
