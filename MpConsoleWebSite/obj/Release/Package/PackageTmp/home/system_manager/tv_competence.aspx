<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tv_competence.aspx.cs" Inherits="MpConsoleWebSite.home.system_manager.tv_competence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '系统管理';
            window.parent.document.getElementById('function_2').innerHTML = '权限管理';
            LoadTable();
        });
        //加载
        function LoadTable() {
            $.ajax({
                type: "post",
                url: '/AjaxResponse/tv_competenceHandler.ashx?type=1',
                data: $("#form1").serialize(),
                success: function (data) {
                    $('#system_data').html(data);
                }
            });
        }
        //全选
        function getAll() {
            var checkboxs = document.getElementsByName("sys_check");
            for (var i = 0; i < checkboxs.length; i++) {
                var e = checkboxs[i];
                e.checked = !e.checked;
            }
        }
        //获取选择的ID
        function getIds() {
            var allVals = [];
            var arrChk = $("input[name='sys_check']:checked");
            $(arrChk).each(function () {
                allVals.push(this.id);
            });
            $("#id_array").val(allVals);
        }
        //执行删除
        function DeleteData() {
            getIds();
            if ($("input[name='sys_check']:checked").length) {
                art.dialog.confirm("<font size='2px'>您确定要删除吗？</font>", function () {
                    $.ajax({
                        type: "post",
                        url: '/AjaxResponse/tv_competenceHandler.ashx?type=2&postvalue=' + $('#id_array').val(),
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
                });
            }
            else {
                dialogTime('未选中任何管理用户 ！', '');
            }
        }
    </script>
</head>
<body>
    <form id="form1">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <div class="Content">
            <div class="topmenu">
                <ul>
                    <li>
                        <span>姓名：</span>
                        <input type="text" id="sys_name" name="sys_name" />
                    </li>
                    <li>
                        <input type="hidden" id="id_array" name="id_array" />
                        <a class="btnblue" onclick="LoadTable()">查询</a>
                    </li>
                </ul>
                <div class="clear"></div>
            </div>
            <div class="listtable" id="system_data">
            </div>
        </div>
    </form>
</body>
</html>
