<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="article_type_list.aspx.cs" Inherits="WebSite.Admin.OtherPage.article_type_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.mydel').click(function () {

                var deviceid = $(this).attr('deviceid');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({

                        type: 'GET',
                        url: '/AjaxResponse/tech_article_typeHandler.ashx?type=del&id=' + deviceid,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert(r.msg);
                                window.location.href = 'article_type_list.aspx';
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
    管理学术论文类别
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Article Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
    <span style="float:left; padding:5px 5px 0 0;">选择会议</span>
    <span style="float:left; padding:0 5px 0 0;"><asp:DropDownList ID="ddl_mid" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList></span>
    <span style="float:left"><asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" /></span>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="1">
                        类型名称
                    </th>
                    <th data-priority="1">
                        所属大会编码
                    </th>
                    <th data-priority="2">
                        应用类型
                    </th>
                    <th data-priority="2">
                        录入时间
                    </th>
                    <th data-priority="5">
                        操作
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="rpt_list" runat="server">                
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("type_name") %></td>
                        <td><%#Eval("mid") %></td>
                        <td><%#getAppType(Eval("app_type").ToString()) %></td>
                        <td><%#DateTime.Parse(Eval("inputtime").ToString()).ToString("yy年MM月dd日 HH:mm") %></td>
                        <td>
                            <a href="article_type_edit.aspx?id=<%#Eval("type_id") %>" class="btn btn-secondary btn-xs">编辑</a>
                            <a deviceid='<%#Eval("type_id") %>' class="btn btn-red btn-xs mydel" href="#">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tbody>
            </tbody>
        </table>
    </div>

</asp:Content>
