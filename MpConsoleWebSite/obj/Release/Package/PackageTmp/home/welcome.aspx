<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="MpConsoleWebSite.home.welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎页</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />    
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/My97DatePicker/skin/WdatePicker.css" />

    <style type="text/css">
        .TabWrap {
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
            background: #f5f5f5;
            border-bottom: 3px solid #ccc;
            height: 50px;
            line-height: 50px;
            margin-top: 30px;
        }

        .TabListWrap {
            float: left;
        }

        .TabList {
            float: left;
            width: 100%;
        }

            .TabList li {
                float: left;
                padding-right: 1px;
                height: 50px;
            }

                .TabList li a {
                    color: #2b3033;
                    font-size: 14px;
                    line-height: 50px;
                    display: inline-block;
                    padding: 0 25px;
                    cursor: default;
                }

                .TabList li .on {
                    color: #fff;
                    background: #BF0000;
                }
        input[type=button] {
            width: 60px;
            height: 28px;
            background: #84c810;
            cursor: pointer;
            text-align: center;
            line-height: 28px;
            padding: 0px;
            margin-right: 10px;
            margin-bottom: 20px;
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
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '欢迎';

            var iskt = '<%=isKaitong%>';

            $("#kaitonged").hide();
            $("#kaitonging").hide();

            if (iskt == '1') {
                $("#kaitonged").show();
                $("#kaitonging").hide();
            } else {
                $("#kaitonged").hide();
                $("#kaitonging").show();
                $("#kaitonging_1").show();
                $("#kaitonging_2").hide();
                $("#kaitonging_3").hide();
            }

        });

        function click_one() {

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
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveMeeting&postvalue=<%=tm.mid %>",
                    data: $("#form1").serialize(),
                    success: function (data) {
                        if (data == "OK") {
                            $("#kaitonging_1").hide();
                            $("#kaitonging_2").show();
                            $("#kaitonging_3").hide();
                            LoadTable();
                        }
                        else {
                            dialogTime('' + data + '', '');
                        }
                    }
                });
            }
        }
        function click_two() {

            if ($("#mtemplate_id").val() == '0') {
                alert('请选中一个模板！');
            } else {

                $("#kaitonging_1").hide();
                $("#kaitonging_2").hide();
                $("#kaitonging_3").show();
            }
        }

        function click_back_one() {
            $("#kaitonging_1").show();
            $("#kaitonging_2").hide();
            $("#kaitonging_3").hide();
        }
        function click_back_two() {
            $("#kaitonging_1").hide();
            $("#kaitonging_2").show();
            $("#kaitonging_3").hide();
        }
        function click_back_three() {
            $("#kaitonging_1").hide();
            $("#kaitonging_2").hide();
            $("#kaitonging_3").show();
        }

        function set_version_id(v_id) {
            $("#version_id").val(v_id);
            $("#version_id_ a").attr("class", "btn btnwhite");
            $("#version_id_" + v_id).attr("class", "btn btnblue");
            LoadTable();
        }

        //加载
        function LoadTable() {
            var pageindex = 1;
            if ($('#txtpageIndex').length > 0) {
                pageindex = $('#txtpageIndex').val();
            }
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=2&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>12</pageSize></msg_data>",
                data: $("#form2").serialize(),
                success: function (data) {
                    $('#tb_Content').html(data);
                    dlSelector();
                }
            });
        }

        function SelectLoadTable() {
            $('#txtpageIndex').val("1");
            LoadTable();
        }

        function dlSelector() {

            $("#tb_Content dl").mouseover(function () {
                $(this).css("border", "1px solid #FF0000");
            })

            $("#tb_Content dl").mouseout(function () {
                $("#tb_Content dl").css("border", "1px solid #DBDBEA");
                if ($("#mtemplate_id").val() != 0) {
                    $("#" + $("#mtemplate_id").val() + "").css("border", "2px solid #FF0000");
                }
            })
        }

        function ChangeMT(m_id) {
            $("#" + m_id + "").css("border", "2px solid #FF0000");
            $("#mtemplate_id").val(m_id);
        }

        function save_data() {
            if (confirm("微站开通后，网站模板不可更改，确认开通吗？")) {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveSkinAndSiteImg&postvalue=",
                    data: $("#form2").serialize(),
                    success: function (str) {
                        if (str == "OK") {
                            alert("微站已经开通成功，请继续完善网站各板块内容！");
                            location.href = '/home/mobile_menu/menu_content.aspx';
                        }
                        else {
                            alert("微站开通失败，请联系管理员！");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { alert('发生错误，请联系客服！'); }
                });
            }
        }
    </script>
</head>
<body class="skin">
    <div class="p10">

        <div class="start_boxes">
            <ul>
                <li>会议编码<span><%=tm.mid %></span></li>
            </ul>
        </div>
        <div class="h10"></div>
        <div class="listtable">

            <div id="kaitonged">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="start_table">
                    <tr>
                        <td>
                            <div class="start_tongji">
                                <h3>会议基本信息</h3>
                                <div class="start_tongji_main">
                                    <ul>
                                        <li>会议名称：<%=tm.mname %></li>
                                        <li>会议地点：<%=tm.address %></li>
                                        <li>会议开始时间：<%=tm.begindate.ToString("yy-MM-dd") %></li>
                                        <li>会议结束时间：<%=tm.enddate.ToString("yy-MM-dd") %></li>
                                        <li>会议负责人：<%=tm.mcontact %></li>
                                        <li>负责人电话：<%=tm.mcontactmblie %></li>
                                        <li>会议网址：<%=tm.m_website %> <span><a href="<%=tm.m_website %>" target="_blank">点击跳转</a></span></li>
                                    </ul>
                                    <table align="right">
                                        <tr>
                                            <td><span>
                                                <img src="<%=imagePath %>" width="120" height="120" /></span></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="kaitonging">

                <div id="kaitonging_1">
                    <form id="form1">
                        <input type="hidden" name="mid" value="<%=tm.mid %>" />
                        <div class="TabWrap">
                            <div class="TabListWrap">
                                <ul class="TabList">
                                    <li><a href="javascript:void(0)" class="on">1.会议信息编辑</a></li>
                                    <li><a href="javascript:void(0)">2.会议模板选择</a></li>
                                    <li><a href="javascript:void(0)">3.提交生成微站</a></li>
                                </ul>
                            </div>
                        </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                            <tr>
                                <th scope="row">会议名称</th>
                                <td>
                                    <input class="txt" id="mname" name="mname" type="text" style="width: 300px;" value="<%=tm.mname %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">开会地点</th>
                                <td>
                                    <input class="txt" id="address" name="address" type="text" style="width: 150px;" value="<%=tm.address %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">会议开始日期</th>
                                <td>
                                    <input class="txt Wdate" id="begindate" name="begindate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.begindate.ToString("yyyy-MM-dd") %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">会议结束日期</th>
                                <td>
                                    <input class="txt Wdate" id="enddate" name="enddate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.enddate.ToString("yyyy-MM-dd") %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">会议负责人</th>
                                <td>
                                    <%=getProjectManager(tm.project_manager_id.ToString()) %>
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
                                    <input class="txt Wdate" id="reguserdate" name="reguserdate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.reguserdate.ToString("yyyy-MM-dd") %>" />
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
                                    <input class="txt Wdate" id="articledate" name="articledate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.articledate.ToString("yyyy-MM-dd") %>" />
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
                                    <input class="txt Wdate" id="lodgingdate" name="lodgingdate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.lodgingdate.ToString("yyyy-MM-dd") %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">大会报到日期</th>
                                <td>
                                    <input class="txt Wdate" id="meetingcheckin_date" name="meetingcheckin_date" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.meetingcheckin_date.ToString("yyyy-MM-dd") %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">注册缴费截止日期</th>
                                <td>
                                    <input class="txt Wdate" id="regenddate" name="regenddate" type="text" onclick="WdatePicker({skin:'blue',readOnly:true})" readonly="true" style="width: 150px;" value="<%=tm.regenddate.ToString("yyyy-MM-dd") %>" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">大会网址</th>
                                <td>
                                    <a href="<%=tm.m_website %>" target="_blank"><%=tm.m_website %></a>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row"></th>
                                <td>
                                    <input type="hidden" id="sys_code" name="sys_code" />
                                    <a class="btnblue" href="javascript:void(0)" onclick="click_one()">下一步</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>

                <div class="Content">
                    <style type="text/css">
                        .fenye { width: 100%; height: 24px; line-height: 24px; padding: 2px 0px; font-family: "Microsoft YaHei", "微软雅黑", sans-serif !important; font-size: 12px; color: #666; text-align: center; }
                        .fenye a { border: 1px solid #ccc; padding: 3px 7px; margin: 2px 3px; color: #666; text-decoration: none; -moz-border-radius: 5px; -webkit-border-radius: 5px; border-radius: 5px; }
                        .fenye a:hover { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
                        .fenye .current { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
                        .sortClass li { margin-left: 2rem; }
                        .sortClass div { display: inline-block; margin-left: 1rem; }
                        .blueClass { background-color: #3151b1; color: white; padding: 0.08rem 0.5rem; border-radius: 0.3rem; }
                    </style>
                    <form id="form2">
                        <div id="kaitonging_2">

                            <input type="hidden" name="mid" value="<%=tm.mid %>" />
                            <input type="hidden" id="version_id" name="version_id" value="0" />
                            <input type="hidden" id="mtemplate_id" name="mtemplate_id" value="0" />

                            <div class="TabWrap">
                                <div class="TabListWrap">
                                    <ul class="TabList">
                                        <li><a href="javascript:void(0)">1.会议信息编辑</a></li>
                                        <li><a href="javascript:void(0)" class="on">2.会议模板选择</a></li>
                                        <li><a href="javascript:void(0)">3.提交生成微站</a></li>
                                    </ul>
                                </div>
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                <tr>
                                    <th scope="row">会议版本</th>
                                    <td id="version_id_">
                                        <a href="javascript:void(0);" id="version_id_0" class="btn btnblue" onclick="set_version_id(0)">全部</a>
                                        <a href="javascript:void(0);" id="version_id_1" class="btn btnwhite" onclick="set_version_id(1)">经典九宫格</a>
                                        <a href="javascript:void(0);" id="version_id_5" class="btn btnwhite" onclick="set_version_id(5)">经典八宫格</a>
                                        <a href="javascript:void(0);" id="version_id_2" class="btn btnwhite" onclick="set_version_id(2)">时尚版</a>
                                        <a href="javascript:void(0);" id="version_id_3" class="btn btnwhite" onclick="set_version_id(3)">传统版</a>
                                        <a href="javascript:void(0);" id="version_id_4" class="btn btnwhite" onclick="set_version_id(4)">微软版</a>
                                    </td>
                                </tr>
                            </table>
                            <div id="tb_Content">
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                <tr>
                                    <td style="text-align:center;">
                                        <a class="btnblue" href="javascript:void(0)" onclick="click_back_one()">上一步</a>
                                        <a class="btnblue" href="javascript:void(0)" onclick="click_two()">下一步</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="kaitonging_3">

                            <div class="TabWrap">
                                <div class="TabListWrap">
                                    <ul class="TabList">
                                        <li><a href="javascript:void(0)">1.会议信息编辑</a></li>
                                        <li><a href="javascript:void(0)">2.会议模板选择</a></li>
                                        <li><a href="javascript:void(0)" class="on">3.提交生成微站</a></li>
                                    </ul>
                                </div>
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                <tr>
                                    <th scope="row">提示：</th>
                                    <td>
                                        网站一旦开通后，模板不可再次选择修改，请您确认好模板后再开通！！！
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row"></th>
                                    <td>
                                        <a class="btnblue" href="javascript:void(0)" onclick="click_back_two()">上一步</a>
                                        <a class="btnblue" href="javascript:void(0)" onclick="save_data()">提交确认开通</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
