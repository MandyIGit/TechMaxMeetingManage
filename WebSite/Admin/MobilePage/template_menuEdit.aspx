<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template_menuEdit.aspx.cs" Inherits="WebSite.Admin.MobilePage.template_menuEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目管理</title>
    <link rel="stylesheet" type="text/css" href="/css/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/main.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var Request = new Object();
            Request = GetRequest();
            var mtemplate_id = Request['mtemplate_id'];
            $("#mtemplate_id").val(mtemplate_id);            
            getContent();
        });
        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_template_menuHandler.ashx?type=GetMenu",
                data: $("#myform").serialize(),
                success: function (data) {
                    $("#tbContent").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }
        function dosave() {
            var json = "[";
            $("input[name=temp_id]").each(function (index) {
                var i = $(this).val();
                if (index == 0) {
                    json += "{'sort':'" + $("#sort_" + i).val() + "','menu_id':'" + $("#temp_id_" + i).val() + "','menu_name':'" + $("#menu_name_" + i).val() + "','menu_icon':'" + $("#menu_icon_" + i).val() + "','menu_url':'" + $("#menu_url_" + i).val() + "','mtemplate_id':'" + $("#mtemplate_id").val() + "'}";
                } else {
                    json += ",{'sort':'" + $("#sort_" + i).val() + "','menu_id':'" + $("#temp_id_" + i).val() + "','menu_name':'" + $("#menu_name_" + i).val() + "','menu_icon':'" + $("#menu_icon_" + i).val() + "','menu_url':'" + $("#menu_url_" + i).val() + "','mtemplate_id':'" + $("#mtemplate_id").val() + "'}";
                }
            })
            json += "]"
            $("#JsonStr").val(json);
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_template_menuHandler.ashx?type=ModiMenu",
                data: $("#myform").serializeArray(),
                success: function (data) {
                    alert('更新成功！');
                    getContent();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); }
            });
        }

        function addtop() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_template_menuHandler.ashx?type=AddTopMenu",
                data: $("#myform").serializeArray(),
                success: function (data) {
                    $("#gettmplace").after(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
        function removechild(i) {
            $("#tr_" + i).remove();
        }
        function removetop(i) {
            $("#tbody_" + i).remove();
        }
        function deletemenu(i) {
            art.dialog.confirm("<font size='2px'>您确定要删除吗？</font>", function () {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobile_template_menuHandler.ashx?type=DeleteMenu&menu_id=" + i,
                    data: $("#myform").serialize(),
                    success: function (data) {
                        getContent();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            });
        }

    </script>
</head>
<body>
    <form id="myform">
        <input type="hidden" id="mtemplate_id" name="mtemplate_id" value="0" />
        <input type="hidden" id="JsonStr" name="JsonStr" />
        <div class="p10">
            <div class="table_list">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbContent" class="info_table">
                    <colgroup>
                        <col width="30">
                        <col>
                        <col width="200">
                        <col width="200">
                    </colgroup>
                    <thead>
                        <tr>
                            <td width="20"></td>
                            <td>顺序</td>
                            <td width="200">链接</td>
                            <td width="200">操作</td>
                        </tr>
                    </thead>
                </table>
                <div class="h10"></div>
                <div class="listmenu">
                    <a href="javascript:void(0)" onclick="dosave()" class="btnblue">保存</a><a class="btnblue" onclick="addtop()">添加顶级菜单</a>
                    <div class="clear"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
