<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HYManager.Master" AutoEventWireup="true" CodeBehind="menu_content_edit.aspx.cs" Inherits="DIY.HYManager.mobile_menu.menu_content_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="/kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript">
        var vmc_msg;
        KindEditor.ready(function (K) {
            vmc_msg = CreateKindEditor("mc_msg", K, '846px', '400px');
            prettyPrint();
        });
        $(document).ready(function () {
            getContent();
        });

        function getContent() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=GetContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    $("#divcontent").html(data);
                    //var objJSON = eval("(" + data + ")");         

                    $("#mc_title").val($("#divmc_title").html());
                    vmc_msg.html($("#divmc_msg").html());

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTimeClose("获取数据失败");
                }
            });
        }
        function clears() {
            $("#mc_title").val('');
            vmc_msg.html("");
        }
        function DoPost() {
            if ($("#mc_title").val() == "") {
                alert('标题不能为空！');
                return;
            }
            vmc_msg.sync();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=ModifyContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    if (data == "sur_ok") {
                        dialogTimeClose('操作成功！','','no');
                    }
                    else if (data == "sur_err") {
						dialogTime('操作失败！','');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTime('发生错误，请联系客服！','');
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
        <input type="hidden" name="mid" id="mid" value="<%=mid %>" />
        <input type="hidden" name="mc_id" id="mc_id" value="<%=mc_id %>" />
        <input type="hidden" name="menuid" id="menuid" value="<%=menuid %>" />
        <div class="topmenu">
            <ul>
                <li><span>标题名称：</span>
                    <input class="txt txt200" name="mc_title" id="mc_title" type="text" />
                </li>
            </ul>

            <div class="clear">
            </div>
        </div>
        <div class="h10">
        </div>
        <div class="web_muban">
            <div class="web_muban_border">
                <h3>添加内容</h3>
                <textarea id="mc_msg" name="mc_msg" rows="20" cols="200" style="width: 100%;"></textarea>
            </div>
            <div class="h10"></div>
            <div class="listtable">
                <div class="listmenu">
                    <a class="btnblue" onclick="clears();">清除重写</a> <a class="btnblue" onclick="DoPost()">确认提交</a>
                    <div class="clear">
                    </div>
                </div>
                <div class="h10">
                </div>
            </div>
        </div>

        <div id="divcontent" style="display:none">
                
        </div>
    </form>
</asp:Content>
