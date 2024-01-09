<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="competence_site.aspx.cs" Inherits="MpConsoleWebSite.home.system_manager.competence_site" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript">
        var sys_code = '<%=sys_code %>';
        $(document).ready(function () {
            LoadTable();
        });
        //加载
        function LoadTable() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tv_competenceHandler.ashx?type=6',
                data: $("#form1").serialize(),
                success: function (data) {
                    $('#competence_data').html(data);
                    HiddenElement();
                    SystemCompetence();
                }
            });
        }
        //管理员所属权限
        function SystemCompetence() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tv_competenceHandler.ashx?type=7&postvalue=' + sys_code,
                data: $("#form1").serialize(),
                success: function (data) {
                    var objJSON = eval("(" + data + ")");
                    $.each(objJSON.ids, function (index, d) {
                        $("input[name=checkfunction][value=" + d.id + "]").attr("checked", 'checked');
                    })
                }
            });
        }
        //全选
        function CheckAll(data) {
            var checkboxs = $("#li_" + data + " input[name='checkfunction']");
            for (var i = 0; i < checkboxs.length; i++) {
                var e = checkboxs[i];
                e.checked = !e.checked;
            }
        }
        //显示或隐藏元素
        function HiddenElement() {
            if ($("#quanxian li ul ul").is(":hidden")) {
                $(this).parents("li").find("a").addClass("current");
            }
            $("#quanxian li ul ul").hide();
            $("#quanxian li a").click(function () {
                $(this).next("ul").slideToggle("normal");
                return false;
            });
            $("#quanxian li a.no-submenu").click(function () {
                $("#mainhtml").href = (this.href)
                return false;
            });
            $(".quanxianall").click(function () {
                $("#quanxian li ul").slideUp().animate({ height: 'toggle', opacity: 'hide' }, "fast");
            }, function () {
                $("#quanxian li ul").animate({ height: 'toggle', opacity: 'show' }, "fast");
            });
        }
        //保存数据
        function SaveData() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tv_competenceHandler.ashx?type=8&postvalue=' + sys_code,
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
    </script>
</head>
<body>
    <form id="form1">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <div class="p10">
            <div id="quanxian">
                <ul class="ulul" id="competence_data">
                    <!--权限内容信息-->
                </ul>
            </div>
            <div class="listmenu">
                <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">保存</a>
                <div class="clear"></div>
            </div>
        </div>
    </form>
</body>
</html>
