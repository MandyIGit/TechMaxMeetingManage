<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="schedule_search.aspx.cs" Inherits="DIY.HYManager.mobile_agenda.schedule_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学术会议日程设置管理</title>
    <link href="/style/main.css" rel="stylesheet" type="text/css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript">
        function GetMeetingTime() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetMeetingTime",
                data: $("#Myform").serialize(),
                success: function (data) {
                    $("#select_mt").html("");
                    var objJSON = eval("(" + data + ")");
                    $.each(objJSON.plist, function (index, d) {
                        $("#select_mt").append($("<option/>").html(d.name).val(d.value));
                    })
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
            });
        }

        function LoadTable() {
            var pageindex = 1;
            if ($('#txtpageIndex').length > 0) {
                pageindex = $('#txtpageIndex').val();
            }
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_schedule_searchHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>50</pageSize></msg_data>",
                data: $("#Myform").serialize(),
                beforeSend: function () { $("#span_loading").show(); },
                success: function (data) { $("#tbContent").html(data); },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { $("#span_loading").hide(); }
            });
        }

        function research() {
            $('#txtpageIndex').val("1");
            LoadTable();
        }

        function select_having() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_schedule_searchHandler.ashx?type=select_having",
                data: $("#Myform").serialize(),
                beforeSend: function () { $("#span_loading").show(); },
                success: function (data) { $("#tbContent").html(data); },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { $("#span_loading").hide(); }
            });
        }

        function ImportSchedule() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_schedule_searchHandler.ashx?type=ImportSchedule&postvalue=",
                data: $("#Myform").serialize(),
                beforeSend: function () { $("#span_loading").show(); },
                success: function (data) {
                    if (data == "OK") {
                        alert('导入成功');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); },
                complete: function (XMLHttpRequest, textStatus) { $("#span_loading").hide(); }
            });
        }

        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '日程查重';
            GetMeetingTime();
        });
    </script>
</head>
<body id="content_body">
    <form id="Myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
        <div class="topmenu">
            <ul>
                <li>
                    <span>会议日期：</span>
                    <select name="select_mt" id="select_mt">
                        <option value="0">加载中...</option>
                    </select>
                </li>
                <li><span>时间区间：</span>
                    <input name="btime" id="btime" type="text" class="txt txt60" value="08:00" maxlength="5"
                        onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" />
                    -
                    <input name="etime" id="etime" type="text" class="txt txt60" value="18:00" maxlength="5"
                        onclick="WdatePicker({ skin: 'blue', readOnly: false, dateFmt: 'HH:mm' })" />
                </li>
                <li>
                    <span>专家姓名</span>
                    <input name="full_name" id="full_name" type="text" class="txt" />
                </li>
                <li>
                    <span style="width: 50px;"></span><a class="btnblue" onclick="research()">查询</a>                    
                </li>
                <li>
                    <span style="width: 50px;"></span><a class="btnblue" onclick="select_having()">查重</a>                    
                </li>
                <li>
                    <span style="width: 50px;"></span><a class="btnblue" onclick="ImportSchedule()">将录好的日程导入至查询库</a>
                    <span id="span_loading" style="display: none;"><img alt="加载中" src="/image/loading.gif" />加载中</span>
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
