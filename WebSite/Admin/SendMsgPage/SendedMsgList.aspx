<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SendedMsgList.aspx.cs" Inherits="WebSite.Admin.SendMsgPage.SendedMsgList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fenye { width: 100%; height: 24px; line-height: 24px; padding: 2px 0px; font-family: "Microsoft YaHei", "微软雅黑", sans-serif !important; font-size: 12px; color: #666; text-align: center; }
        .fenye a { border: 1px solid #ccc; padding: 3px 7px; margin: 2px 3px; color: #666; text-decoration: none; -moz-border-radius: 5px; -webkit-border-radius: 5px; border-radius: 5px; }
        .fenye a:hover { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .fenye .ahover { border: 1px solid #448bc9; color: #FFF; background: #448bc9; }
        .sortClass li { margin-left: 2rem; }
        .sortClass div { display: inline-block; margin-left: 1rem; }
        .blueClass { background-color: #3151b1; color: white; padding: 0.08rem 0.5rem; border-radius: 0.3rem; }
    </style>
    <script src="/js/techmaxJS.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            LoadTable();

        });

        function SelectLoadTable() {
            $('#txtpageIndex').val("1");
            LoadTable();
        }

        function LoadTable() {
            var pageindex = 1;
            if ($('#txtpageIndex').length > 0) {
                pageindex = $('#txtpageIndex').val();
            }
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_send_wx_messageHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>10</pageSize></msg_data>",
                data: $("#aspnetForm").serialize(),
                success: function (data) {
                    $('#tb_Content').html(data);
                }
            });
        }

        function mydelete(deviceid) {

            if (confirm('您确认要删除吗？')) {
                $.ajax({

                    type: 'GET',
                    url: '/AjaxResponse/tech_send_wx_messageHandler.ashx?type=delMsg&id=' + deviceid,
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            alert(r.msg);
                            LoadTable();
                        }
                        else {
                            alert(r.msg);
                        }
                    }

                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    发送记录
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Send Message
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    <div style="font-size:12px">

        <span style="float:left; padding:5px 5px 0 0;">会议主题</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="keyword1" name="keyword1" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">会议日期</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="keyword2" name="keyword2" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">会议地点</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="keyword3" name="keyword3" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">发起人</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="keyword4" name="keyword4" type="text" class="form-control" /></span>
        
        <span style="float:left; padding:0 5px 0 0;">
            <input id="btn_search" type="button" value="搜索" class="btn btn-blue" onclick="SelectLoadTable()" />
        </span>
        
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">
    <div id="tb_Content">
        
    </div>
</asp:Content>
