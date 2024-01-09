<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="mtemplate_list.aspx.cs" Inherits="WebSite.Admin.MobilePage.mtemplate_list" %>
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
                url: "/AjaxResponse/tech_mobile_templateHandler.ashx?type=1&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>10</pageSize></msg_data>",
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
                    url: '/AjaxResponse/tech_mobile_typeHandler.ashx?type=del&id=' + deviceid,
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

        function open_css(mtemplate_id) {
            window.open('mt_open_css.aspx?mtemplate_id='+mtemplate_id, 'newwindow', 'width=800, height=560, top=90, left=220, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')
        }

        function open_thumbnail(mtemplate_id) {
            window.open('mt_open_thumbnail.aspx?mtemplate_id='+mtemplate_id, 'newwindow', 'width=800, height=560, top=90, left=220, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    管理模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Mobile Template List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

    <div style="font-size:12px">

        <span style="float:left; padding:5px 5px 0 0;">版本类型</span>
        <span style="float:left; padding:0 5px 0 0;">
            <select id="version_id" name="version_id" class="form-control">
                <option value="0">请选择</option>
                <%=version_select_str %>
            </select>
        </span>
        <span style="float:left; padding:5px 5px 0 0;">模板名称</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="mtemplate_name" name="mtemplate_name" type="text" class="form-control" /></span>
        
        <span style="float:left; padding:0 5px 0 0;">
            <input id="btn_search" type="button" value="搜索" class="btn btn-blue" onclick="SelectLoadTable()" />
        </span>
        
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">
    <div id="tb_Content">
        
    </div>
</asp:Content>
