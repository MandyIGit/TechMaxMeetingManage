<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hall_list.aspx.cs" Inherits="DIY.HYManager.mobile_agenda.hall_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改会议厅会场</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script language="javascript" type="text/javascript">     
        $(document).ready(function () {
            GetHallList();
        });
        function GetHallList() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetHallLists",
                data: $("#Myform").serialize(),
                success: function (data) {
                    $("#tbContent").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
        function deletehall(hallid) {
            art.dialog.confirm("<font size='2px'>您确定要删除吗？</font>", function () {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/mobile_agendaHandler.ashx?type=DeleteHall&Hallid=" + hallid,
                    success: function (data) {
                        GetHallList();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        dialogTime(' 发生错误，请联系客服！ ', '');
                    }
                });
            });
        }

    </script>
</head>

<body>
    <form id="Myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
        <div class="p10">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotable" id="tbContent">
            </table>
        </div>
    </form>
</body>
</html>
