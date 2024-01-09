<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="tech_meeting_list.aspx.cs" Inherits="WebSite.Admin.MeetingPage.tech_meeting_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.mydel').click(function () {

                var deviceid = $(this).attr('deviceid');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({

                        type: 'GET',
                        url: '/AjaxResponse/tech_meetingHandler.ashx?type=del&id=' + deviceid,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert(r.msg);
                                window.location.href = 'tech_meeting_list.aspx?page=<%=mypager.CurrentPageIndex%>';
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
    管理会议
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Meeting List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="1">
                        会议类型编码
                    </th>
                    <th data-priority="2">
                        会议类型名称
                    </th>
                    <th data-priority="1">
                        会议编码
                    </th>
                    <th data-priority="1">
                        建站密码
                    </th>
                    <th data-priority="2">
                        会议名称
                    </th>
                    <th data-priority="5">
                        开会地点
                    </th>
                    <th data-priority="5">
                        会议开始时间
                    </th>
                    <th data-priority="5">
                        会议结束时间
                    </th>
                    <th data-priority="5">
                        会议负责人
                    </th>
                    <th data-priority="5">
                        是否开通自助建站
                    </th>
                    <th data-priority="5">
                        是否直播
                    </th>
                    <th data-priority="5">
                        是否推荐
                    </th>
                    <th data-priority="5">
                        是否在学术号会议显示
                    </th>
                    <th data-priority="5">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rpt_listNews" runat="server">                
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("mtype_id") %></td>
                        <td><%#getMtypeName(Eval("mtype_id").ToString()) %></td>
                        <td><%#Eval("mid") %></td>
                        <td><%#Eval("zzjzpasswd") %></td>
                        <td><a href="<%#Eval("m_website") %>" target="_blank"><%#Eval("mname") %></a></td>
                        <td><%#Eval("address") %></td>
                        <td><%#DateTime.Parse(Eval("begindate").ToString()).ToString("yy年MM月dd日") %></td>
                        <td><%#DateTime.Parse(Eval("enddate").ToString()).ToString("yy年MM月dd日") %></td>
                        <td><%#getProjectManager(Eval("project_manager_id").ToString()) %></td>
                        <td><%#getTrueFalseStr(Eval("is_weizhankaitong").ToString()) %></td>
                        <td><%#getTrueFalseStr(Eval("is_live").ToString()) %></td>
                        <td><%#getTrueFalseStr(Eval("is_recommend").ToString()) %></td>
                        <td><%#getTrueFalseStr(Eval("is_xsh_show").ToString()) %></td>
                        <td>
                            <a href="<%#Eval("m_website") %>/admin/login.aspx" target="_blank" class="btn btn-blue btn-xs">进入后台</a>
                            <a href="<%#"tech_meeting_edit.aspx?mid="+Eval("mid") %>&page=<%=mypager.CurrentPageIndex %>" class="btn btn-secondary btn-xs">编辑</a>
                            <!--<a deviceid='<%#Eval("mid") %>' class="btn btn-red btn-xs mydel" href="#">删除</a>-->
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
