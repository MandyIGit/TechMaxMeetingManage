<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tech_meeting_edit.aspx.cs" Inherits="MpConsoleWebSite.ProjectManager.tech_meeting_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会议信息</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/My97DatePicker/skin/WdatePicker.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '会议信息';
        });
        //加载
        function LoadTable() {
            location.reload();
        }
        function SaveData() {
            if ($("#mname").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#mname").focus();
                alert('会议名称不能为空');
            }
            else if ($("#address").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#address").focus();
                alert('开会地点不能为空');
            }
            else if ($("#begindate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#begindate").focus();
                alert('会议开始日期不能为空');
            }
            else if ($("#enddate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#enddate").focus();
                alert('会议结束日期不能为空');
            }
            else if ($("#reguserdate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#reguserdate").focus();
                alert('前期注册截止时间不能为空');
            }
            else if ($("#articledate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#articledate").focus();
                alert('开放征文截止时间不能为空');
            }
            else if ($("#lodgingdate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#lodgingdate").focus();
                alert('开放住宿截止时间不能为空');
            }
            else if ($("#meetingcheckin_date").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#meetingcheckin_date").focus();
                alert('大会报到日期不能为空');
            }
            else if ($("#regenddate").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#regenddate").focus();
                alert('注册缴费截止日期不能为空');
            }
            else {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveMeeting&postvalue=<%=mid %>",
                    data: $("#form1").serialize(),
                    success: function (data) {
                        if (data == "OK") {
                            dialogTimeClose('操作成功！', '', "yes");
                        }
                        else {
                            dialogTime('' + data + '', '');
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1">

        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" id="project_manager_id" name="project_manager_id" value="<%=tm.project_manager_id %>" />

        <div class="Content">
            <div class="listtable" id="system_data">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                    <tr>
                        <td colspan="2">会议信息编辑</td>
                    </tr>
                    <tr>
                        <th scope="row">会议编码</th>
                        <td>
                            <%=mid %>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">会议名称</th>
                        <td>
                            <input class="txt" id="mname" name="mname" type="text" style="width:300px;" value="<%=tm.mname %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">开会地点</th>
                        <td>
                            <input class="txt" id="address" name="address" type="text" style="width:150px;" value="<%=tm.address %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">会议开始日期</th>
                        <td>
                            <input class="txt Wdate" id="begindate" name="begindate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.begindate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">会议结束日期</th>
                        <td>
                            <input class="txt Wdate" id="enddate" name="enddate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.enddate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">是否开启会员注册</th>
                        <td>
                            <select name="reguser" id="reguser">
	                            <option selected="selected" value="1">开启</option>
	                            <option value="2">关闭</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">前期注册截止时间</th>
                        <td>
                            <input class="txt Wdate" id="reguserdate" name="reguserdate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.reguserdate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">是否开放征文</th>
                        <td>
                            <select name="article" id="article">
	                            <option selected="selected" value="1">开启</option>
	                            <option value="2">关闭</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">开放征文截止时间</th>
                        <td>
                            <input class="txt Wdate" id="articledate" name="articledate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.articledate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">是否开放住宿预订</th>
                        <td>
                            <select name="lodging" id="lodging">
	                            <option selected="selected" value="1">开启</option>
	                            <option value="2">关闭</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">开放住宿截止时间</th>
                        <td>
                            <input class="txt Wdate" id="lodgingdate" name="lodgingdate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.lodgingdate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">大会报到日期</th>
                        <td>
                            <input class="txt Wdate" id="meetingcheckin_date" name="meetingcheckin_date" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.meetingcheckin_date.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">注册缴费截止日期</th>
                        <td>
                            <input class="txt Wdate" id="regenddate" name="regenddate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width:150px;" value="<%=tm.regenddate.ToString("yyyy-MM-dd") %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">大会网址</th>
                        <td>
                            <input class="txt" id="m_website" name="m_website" type="text" style="width:150px;" value="<%=tm.m_website %>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td>
                            <input type="hidden" id="sys_code" name="sys_code" />
                            <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">保存</a>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <div class="h10"></div>
            </div>
        </div>
    </form>
    <%=script_html %>
</body>
</html>