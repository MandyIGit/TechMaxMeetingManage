<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="schedule_list.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_agenda.schedule_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>日程顺序修改</title>
    <link href="/style/main.css" rel="stylesheet" type="text/css" />
    <link href="/js/jquery-pager-plugin-master/Pager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>

    <script type="text/javascript" src="/js/artDialog.source.js"></script>

    <script type="text/javascript" src="/js/iframeTools.source.js"></script>

    <script type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>

    <script src="/js/jquery-pager-plugin-master/jquery.pager.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>

    <script type="text/javascript">
   
    $(document).ready(function(){ 
        GetMsgDetail();          
        LoadTable();
     });       
    function LoadTable(){        
         $.ajax({
            type: "post",
            url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetScheduleList",
            data: $("#Myform").serialize(),
            beforeSend:function(XMLHttpRequest, textStatus){
                // $("#tbContent").html("<tr><td colspan=\"5\"> 加载中...</td> </tr>");
              },
            success: function(data) {     
              $("#tbContent").html(data);
        },
        error: function(XMLHttpRequest, textStatus, errorThrown) {
            dialogTime(' 发生错误，请联系客服！ ', '');
        }
       });       
      } 
      function GetMsgDetail(){        
         $.ajax({
            type: "post",
            url: "/AjaxResponse/mobile_agendaHandler.ashx?type=GetSession",
            data: $("#Myform").serialize(),
            beforeSend:function(XMLHttpRequest, textStatus){  },
            success: function(data) {     
                var objJSON = eval("(" + data + ")");                 
                $("#meetingname").html("会议主题："+objJSON.session_name);
                $("#meetinghall").html("会议场厅："+objJSON.hall_name);
                $("#meetingtime").html("会议日期："+objJSON.session_date);
                $("#timespan").html("时间段："+objJSON.session_btime+"-"+objJSON.session_etime);                  
                 
        },
        error: function(XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
       });       
      }   
     function DeleteSch(obj){  
         art.dialog.confirm("<font size='2px'>您确定要删除吗？</font>", function () { 
            $.ajax({
              type: "post",
              url: "/AjaxResponse/mobile_agendaHandler.ashx?type=DeleteSchedule&sch_id="+obj,
              data: $("#Myform").serialize(),
              beforeSend:function(XMLHttpRequest, textStatus){  },
              success: function(data) {     
                 var r = eval("(" + data + ")");  
                 if(r.result==1){ LoadTable();}else{dialogTime(r.msg,''); }          
              },
              error: function(XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ', ''); }
             });  
         });    
     }
     
    </script>

</head>
<body>
    <form id="Myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
        <input type="hidden" id="session_id" name="session_id" value="<%=session_id%>" />
        <div class="p10">
            <div class="topmenu">
                <h3>
                    <span id="meetingname">会议主题：加载中</span><br />
                    <span id="meetinghall">会议场厅：加载中</span> <span id="meetingtime">会议日期：加载中</span> <span
                        id="timespan">时间段：加载中</span></h3>
            </div>
            <div class="h10">
            </div>
            <div class="listtable">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotable"
                    id="tbContent">
                    <tr>
                        <td colspan="7">
                            加载中...</td>
                    </tr>
                </table>
                <div class="h10">
                </div>
                <div class="listmenu">
                    <div class="clear">
                    </div>
                </div>
            </div>
    </form>
</body>
</html>