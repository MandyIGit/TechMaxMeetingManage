<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_edit.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_menu.menu_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目管理</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />
    <link href="/style/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/main.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '导航菜单管理';
            getContent();

            preview();
        });

        //加载
        function LoadTable() {
            location.reload();
        }

        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=GetMenu",
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
                    json += "{'sort':'" + $("#sort_" + i).val() + "','menu_id':'" + $("#temp_id_" + i).val() + "','menu_name':'" + $("#menu_name_" + i).val() + "','menu_icon':'" + $("#menu_icon_" + i).val() + "','menu_url':'" + $("#menu_url_" + i).val() + "','mtype_id':'" + $("#mtype_id").val() + "'}";
                } else {
                    json += ",{'sort':'" + $("#sort_" + i).val() + "','menu_id':'" + $("#temp_id_" + i).val() + "','menu_name':'" + $("#menu_name_" + i).val() + "','menu_icon':'" + $("#menu_icon_" + i).val() + "','menu_url':'" + $("#menu_url_" + i).val() + "','mtype_id':'" + $("#mtype_id").val() + "'}";
                }
            })
            json += "]"
            $("#JsonStr").val(json);
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=ModiMenu",
                data: $("#myform").serializeArray(),
                success: function (data) {
                    dialogTimeClose('保存成功！', '', "yes");

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); }
            });
        }

        function addtop() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=AddTopMenu",
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
                    url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=DeleteMenu&menu_id=" + i,
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
        function dismenu(i) {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=DisMenu&menu_id=" + i,
                data: $("#myform").serialize(),
                success: function (data) {
                    getContent();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

        function preview() {
            var murl = '<%=m_website%>';
            $("#preview-html").attr('src', murl);
        }

        function menu_up(menu_id, sort) {
            
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=menu_up",
                data: {
                    "menu_id": menu_id,
                    "sort": sort
                },
                success: function (data) {
                    if (data > 1) {
                        getContent();
                    } else {
                        dialogTimeClose('操作失败！', '', "");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

        function menu_down(menu_id, sort) {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=menu_down",
                data: {
                    "menu_id": menu_id,
                    "sort": sort
                },
                success: function (data) {
                    if (data > 1) {
                        getContent();
                    } else {
                        dialogTimeClose('操作失败！', '', "");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

    </script>

    <style type="text/css">
        div.preview-layer{
            display: block;
            position: relative;
            left:50%;
        }
        div.preview-layer .preview-phone{
            position: fixed;
            width: 410px;
            height: 840px;
            background: url(/image/iphone-bg.png) no-repeat no-repeat;
            z-index: 1000;
        }
        .preview-html{
            position: absolute;
            width:361px !important;
            height: 638px !important;
            top:98px;
            left:24px;
            border:2px solid #000;
            border-radius: 5px;
            outline: none;
            background-color: #fff;
        }
    </style>
</head>

<body>
    <div class="Content" style="float: left">
        <form id="myform">
            <input type="hidden" id="mid" name="mid" value="<%=mid %>" />
            <input type="hidden" id="JsonStr" name="JsonStr" />
            <div class="p10">
                <div class="table_list">
                    <table width="660" border="0" cellspacing="0" cellpadding="0" id="tbContent" class="info_table">
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

                        <a href="javascript:void(0)" onclick="dosave()" class="btn btn-primary">保存预览</a>
                        <a class="btnblue" onclick="addtop()">添加顶级菜单</a>

                        <div class="clear"></div>
                    </div>
                    <table>
                        <tr>
                            <td style="height:30px;"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </div>

    <div style="float: left">

        <div class="preview-layer">
            <div class="preview-phone">
                <iframe id="preview-html" name="preview-html" class="preview-html" src=""></iframe>
            </div>
        </div>

    </div>

    <div class="clear"></div>
</body>
</html>
