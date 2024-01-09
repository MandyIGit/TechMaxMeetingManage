<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin_list.aspx.cs" Inherits="WebSite.Admin.AdminPage.admin_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $('.mydel').click(function () {

                var deviceID = $(this).attr('deviceID');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({
                        type: 'GET',
                        url: '/AjaxResponse/tech_adminHandler.ashx?type=AdminDel&deviceID=' + deviceID,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert(r.msg);
                                window.location.href = 'admin_list.aspx?page=<%=mypager.CurrentPageIndex%>';
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
    管理员列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Manager List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control" Placeholder="请输入关键字" style="width:200px; float: left; margin-right: 5px;"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="btn btn-blue" Style="float: left; margin-right: 5px;" OnClick="btnSearch_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">
    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="2">
                        会议名称
                    </th>
                    <th data-priority="2">
                        管理员姓名
                    </th>
                    <th data-priority="2">
                        登录ID
                    </th>
                    <th data-priority="2">
                        性别
                    </th>
                    <th data-priority="6">
                        联系电话
                    </th>
                    <th data-priority="6">
                        状态
                    </th>
                    <th data-priority="6">
                        类型
                    </th>
                    <th data-priority="5">
                        操作
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="rpt_list" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("mname") %></td>
                        <td><%#Eval("admin_name") %></td>
                        <td><%#Eval("login_name") %></td>
                        <td><%#getGender(Eval("gender").ToString()) %></td>
                        <td><%#Eval("phone") %></td>
                        <td><%#getStatus(Eval("status").ToString()) %></td>
                        <td><%#getAdminType(Eval("admin_type").ToString()) %></td>
                        <td>
                            <a href="<%#"admin_edit.aspx?id="+Eval("admin_code") %>&page=<%=mypager.CurrentPageIndex %>" class="btn btn-secondary btn-xs">编辑</a>
                            <%#(Eval("admin_type").ToString()=="2")?("<a deviceID='"+Eval("admin_code")+"' class=\"btn btn-red btn-xs mydel\" href=\"#\">删除</a>"):"" %>
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
