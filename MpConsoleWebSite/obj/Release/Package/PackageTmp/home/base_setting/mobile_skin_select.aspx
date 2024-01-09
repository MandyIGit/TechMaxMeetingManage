<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobile_skin_select.aspx.cs" Inherits="MpConsoleWebSite.home.base_setting.mobile_skin_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>导航初始化</title>
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
            window.parent.document.getElementById('function_2').innerHTML = '皮肤样式选择';
            LoadTable();            
        });
        //加载
        function LoadTable() {
            var pageindex = 1;
            if ($('#txtpageIndex').length > 0) {
                pageindex = $('#txtpageIndex').val();
            }
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>12</pageSize></msg_data>",
                data: $("#form1").serialize(),
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
        function SaveData(mtemplate_id) {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveSkin&postvalue="+mtemplate_id,
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

        function set_version_id(v_id) {
            $("#version_id").val(v_id);
            $("#version_id_ a").attr("class", "btn btnwhite");
            $("#version_id_" + v_id).attr("class", "btn btnblue");
            LoadTable();
        }

        function dlSelector() {

            $("#tb_Content dl").mouseover(function () {
                $(this).css("border", "1px solid #FF0000");
            })

            $("#tb_Content dl").mouseout(function () {
                $("#tb_Content dl").css("border", "1px solid #DBDBEA");
            })
        }
    </script>
    <style type="text/css">
        .fenye { width: 100%; height: 24px; line-height: 24px; padding: 2px 0px; font-family: "Microsoft YaHei", "微软雅黑", sans-serif !important; font-size: 12px; color: #666; text-align: center; }
        .fenye a { border: 1px solid #ccc; padding: 3px 7px; margin: 2px 3px; color: #666; text-decoration: none; -moz-border-radius: 5px; -webkit-border-radius: 5px; border-radius: 5px; }
        .fenye a:hover { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .fenye .current { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .sortClass li { margin-left: 2rem; }
        .sortClass div { display: inline-block; margin-left: 1rem; }
        .blueClass { background-color: #3151b1; color: white; padding: 0.08rem 0.5rem; border-radius: 0.3rem; }
    </style>
</head>
<body class="skin">
    <form id="form1">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" id="version_id" name="version_id" value="0" />
        <div class="Content">
            <div class="listtable" id="system_data">
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
                    <%--<dl>
                        <dt><img src="http://resource.i-conference.cn/skins/skins_3/guojizhiliang.jpg" /></dt>
                        <dd class="clear">
                            <span>test模板</span>
                            <span style="float:right;"><a href="javascript:void(0);" class="btn btnyellow" onclick="SaveData('1')">使用</a></span>
                        </dd>
                    </dl>--%>
                    
                </div>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <div class="h10"></div>
            </div>
        </div>
    </form>
</body>
</html>
