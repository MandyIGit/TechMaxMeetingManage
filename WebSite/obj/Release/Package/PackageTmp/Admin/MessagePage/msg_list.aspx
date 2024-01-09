<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="msg_list.aspx.cs" Inherits="WebSite.Admin.MessagePage.msg_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
                url: "/AjaxResponse/tech_messageHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>10</pageSize></msg_data>",
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
                    url: '/AjaxResponse/tech_messageHandler.ashx?type=delMsg&id=' + deviceid,
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
    管理信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Message List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    <div style="font-size:12px">

        <span style="float:left; padding:5px 5px 0 0;">联系人</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="Contacts" name="Contacts" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">单位名称</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="UnitName" name="UnitName" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">电话</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="Phone" name="Phone" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">单位类型</span>
        <span style="float:left; padding:0 5px 0 0;">
            <select id="UnitType" name="UnitType" class="form-control">
                <option value="0">--全部--</option>
                <option value="1">会务公司</option>
                <option value="2">医院</option>
                <option value="3">企业</option>
                <option value="4">其他</option>
            </select>
        </span>
        <span style="float:left; padding:5px 5px 0 0;">处理状态</span>
        <span style="float:left; padding:0 5px 0 0;">
            <select id="Status" name="Status" class="form-control">
                <option value="0">--全部--</option>
                <option value="1">已处理</option>
                <option value="2">未处理</option>
                <option value="3">无效信息</option>
            </select>
        </span>
        <span style="float:left; padding:0 5px 0 0;">
            <input id="btn_search" type="button" value="搜索" class="btn btn-blue" onclick="SelectLoadTable()" />
        </span>
        
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div id="tb_Content">
        
    </div>

</asp:Content>
