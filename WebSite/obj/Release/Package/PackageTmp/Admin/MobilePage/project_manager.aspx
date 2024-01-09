<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="project_manager.aspx.cs" Inherits="WebSite.Admin.MobilePage.project_manager" %>
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
                url: "/AjaxResponse/tech_project_managerHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>10</pageSize></msg_data>",
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
                    url: '/AjaxResponse/tech_project_managerHandler.ashx?type=del&id=' + deviceid,
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

        function open_add_manager() {
            window.open('project_manager_add.aspx', 'newwindow', 'width=800, height=560, top=90, left=220, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    项目经理管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Project Manager
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    <div style="font-size:12px">

        <span style="float:left; padding:5px 5px 0 0;">姓名</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="full_name" name="full_name" type="text" class="form-control" /></span>

        <span style="float:left; padding:5px 5px 0 0;">登录名</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="login_name" name="login_name" type="text" class="form-control" /></span>

        <span style="float:left; padding:5px 5px 0 0;">手机号</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="mobile" name="mobile" type="text" class="form-control" /></span>
        
        <span style="float:left; padding:0 5px 0 0;">
            <input id="btn_search" type="button" value="搜索" class="btn btn-blue" onclick="SelectLoadTable()" />
        </span>

        <span style="float:left; padding:0 5px 0 0;">
            <input type="button" value="添加" class="btn btn-danger" onclick="open_add_manager()" />
        </span>
        
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">
    <div id="tb_Content">
        
    </div>
</asp:Content>
