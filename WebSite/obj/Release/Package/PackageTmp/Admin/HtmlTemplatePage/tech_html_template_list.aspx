<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="tech_html_template_list.aspx.cs" Inherits="WebSite.Admin.HtmlTemplatePage.tech_html_template_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.mydel').click(function () {

                var deviceid = $(this).attr('deviceid');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({

                        type: 'GET',
                        url: '/AjaxResponse/tech_html_templateHandler.ashx?type=del&id=' + deviceid,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert(r.msg);
                                window.location.href = 'tech_html_template_list.aspx?page=<%=mypager.CurrentPageIndex%>';
                            }
                            else {
                                alert(r.msg);
                            }
                        }

                    });
                }

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    管理会议模板
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Meeting Template List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="1">
                        模板编码
                    </th>
                    <th data-priority="1">
                        所属大会编码
                    </th>
                    <th data-priority="2">
                        模板名称
                    </th>
                    <th data-priority="2">
                        模板缩略图地址
                    </th>
                    <th data-priority="2">
                        录入时间
                    </th>
                    <th data-priority="5">
                        操作
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="rpt_listNews" runat="server">                
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("tm_id") %></td>
                        <td><%#Eval("mid") %></td>
                        <td><%#Eval("tm_name") %></td>
                        <td><%#Eval("tm_img") %></td>
                        <td><%#DateTime.Parse(Eval("inputtime").ToString()).ToString("yy年MM月dd日 HH:mm") %></td>
                        <td>
                            <a href="<%#"tech_html_template_edit.aspx?mid="+Eval("mid") %>&page=<%=mypager.CurrentPageIndex %>" class="btn btn-secondary btn-xs">编辑</a>
                            <a deviceid='<%#Eval("t_id") %>' class="btn btn-red btn-xs mydel" href="#">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tbody>
            </tbody>
        </table>
    </div>
    <div class="dataTables_paginate paging_simple_numbers">
        <webdiyer:AspNetPager ID="mypager" runat="server" CssClass="anpager" OnPageChanged="mypager_PageChanged" UrlPaging="True">
        </webdiyer:AspNetPager>
    </div>

</asp:Content>
