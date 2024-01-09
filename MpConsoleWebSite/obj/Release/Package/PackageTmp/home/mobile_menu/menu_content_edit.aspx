<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_content_edit.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_menu.menu_content_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目内容管理</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="/kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript">
        var vmc_msg;
        KindEditor.ready(function (K) {
            vmc_msg = CreateKindEditor("mc_msg", K, '846px', '400px');
            prettyPrint();
        });
        $(document).ready(function () {
            getContent();
        });

        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=GetContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    $("#divcontent").html(data);
                    //var objJSON = eval("(" + data + ")");         

                    $("#mc_title").val($("#divmc_title").html());
                    vmc_msg.html($("#divmc_msg").html());

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }
        function clears() {
            $("#mc_title").val('');
            vmc_msg.html("");
        }
        function DoPost() {
            if ($("#mc_title").val() == "") {
                alert('标题不能为空！');
                return;
            }
            vmc_msg.sync();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=ModifyContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    if (data == "sur_ok") {
                        dialogTimeClose('操作成功！','','no');
                    }
                    else if (data == "sur_err") {
						dialogTime('操作失败！','');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTime('发生错误，请联系客服！','');
                }
            });

        }
    </script>

</head>
<body>
    <form id="myform">
        <input type="hidden" name="mid" id="mid" value="<%=mid %>" />
        <input type="hidden" name="mc_id" id="mc_id" value="<%=mc_id %>" />
        <input type="hidden" name="menuid" id="menuid" value="<%=menuid %>" />
        <div class="topmenu">
            <ul>
                <li><span>标题名称：</span>
                    <input class="txt txt200" name="mc_title" id="mc_title" type="text" />
                </li>
            </ul>

            <div class="clear">
            </div>
        </div>
        <div class="h10">
        </div>
        <div class="web_muban">
            <div class="web_muban_border">
                <h3>添加内容</h3>
                <textarea id="mc_msg" name="mc_msg" rows="20" cols="200" style="width: 100%;"></textarea>
            </div>
            <div class="h10"></div>
            <div class="listtable">
                <div class="listmenu">
                    <a class="btnblue" onclick="clears();">清除重写</a> <a class="btnblue" onclick="DoPost()">确认提交</a>
                    <div class="clear">
                    </div>
                </div>
                <div class="h10">
                </div>
            </div>
        </div>

        <div id="divcontent" style="display:none">
                
        </div>
    </form>
</body>
</html>
