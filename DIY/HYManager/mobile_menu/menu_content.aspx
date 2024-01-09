<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HYManager.Master" AutoEventWireup="true" CodeBehind="menu_content.aspx.cs" Inherits="DIY.HYManager.mobile_menu.menu_content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            getContent();
        });
        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=GetMenuContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    $("#tbContent").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="start_boxes">
        <ul>
            <li>会议编码<span><%=mid %></span></li>
            <li>会议名称<span><%=mname %></span></li>
            <li>网站预览：<a href="<%=m_website %>" target="_blank"><%=m_website %></a></li>
        </ul>
    </div>
    <div class="h10"></div>

    <form id="myform">
        <input type="hidden" name="mid" value="<%=mid %>" />
        <input type="hidden" id="JsonStr" name="JsonStr" />
        <div class="p10">
            <div class="table_list">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tbContent">
                    <colgroup>
                        <col width="30">
                        <col>
                        <col width="200">
                        <col width="200">
                    </colgroup>
                    <thead>
                        <tr>
                            <td width="20"></td>
                            <td>顺序</td>
                            <td width="200">链接</td>
                            <td width="200">操作</td>
                        </tr>
                    </thead>


                </table>
                <div class="h10"></div>

            </div>
        </div>
    </form>
    <table>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="h10"></div>
</asp:Content>
