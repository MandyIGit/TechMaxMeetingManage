<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobile_skin_edit.aspx.cs" Inherits="MpConsoleWebSite.home.base_setting.mobile_skin_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑网站模板</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/uploadifive/jquery.min.js"></script>
    <script type="text/javascript" src="/js/uploadifive/jquery.uploadifive.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/uploadifive/uploadifive.css" />
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {
            window.parent.document.getElementById('function_1').innerHTML = '后台管理';
            window.parent.document.getElementById('function_2').innerHTML = '微站模板编辑';            
        });
        //加载
        function LoadTable() {
            location.reload();
        }
        function SaveData() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveSiteTemplate&postvalue=<%=mid %>",
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
        <input type="hidden" name="id" value="<%=id %>" />
        <input type="hidden" name="mid" value="<%=mid %>" />
        <div class="Content">
            <div class="listtable" id="system_data">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                    <tr>
                        <td colspan="2">微站模板编辑</td>
                    </tr>
                    <tr>
                        <th scope="row">一级页面内容模板</th>
                        <td>
                            <textarea id="first_content" name="first_content" style="width:600px; height:200px;"><%=Common.TechMaxClass.Decompress(first_content) %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">二级页面内容模板</th>
                        <td>
                            <textarea id="second_content" name="second_content" style="width:600px; height:200px;"><%=Common.TechMaxClass.Decompress(second_content) %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">底部导航内容模板</th>
                        <td>
                            <textarea id="footer_content" name="footer_content" style="width:600px; height:200px;"><%=Common.TechMaxClass.Decompress(footer_content) %></textarea>
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
</body>
</html>
