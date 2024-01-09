<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="WordList.aspx.cs" Inherits="WebSite.Admin.ForbiddenWord.WordList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.mydel').click(function () {

                var deviceid = $(this).attr('deviceid');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({

                        type: 'GET',
                        url: '/AjaxResponse/tech_forbidden_wordHandler.ashx?type=del&postvalue=' + deviceid,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                window.location.href = 'WordList.aspx?page=<%=mypager.CurrentPageIndex%>';
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
    管理严禁词
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Word List
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

    <span style="float:left; padding:0 5px 0 0;"><asp:TextBox ID="txt_word" runat="server" Width="300px" CssClass="form-control txt_word"></asp:TextBox></span>
    <span style="float:left"><asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" /></span>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="1">
                        严禁词
                    </th>
                    <th data-priority="1">
                        添加时间
                    </th>
                    <th data-priority="1">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rpt_listNews" runat="server">                
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("word") %></td>
                        <td><%#DateTime.Parse(Eval("inputtime").ToString()).ToString("yy年MM月dd日 HH:mm") %></td>
                        <td>
                            <a href="<%#"WordEdit.aspx?id="+Eval("id") %>&page=<%=mypager.CurrentPageIndex %>" class="btn btn-secondary btn-xs">编辑</a>
                            <a deviceid='<%#Eval("id") %>' class="btn btn-red btn-xs mydel" href="#">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>            
            </tbody>
        </table>
    </div>
    <div class="dataTables_paginate paging_simple_numbers">
        <webdiyer:AspNetPager ID="mypager" runat="server" CssClass="anpager" OnPageChanged="mypager_PageChanged" UrlPaging="True">
        </webdiyer:AspNetPager>
    </div>

</asp:Content>
