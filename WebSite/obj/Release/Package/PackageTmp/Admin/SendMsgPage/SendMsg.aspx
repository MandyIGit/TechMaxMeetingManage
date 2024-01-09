<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SendMsg.aspx.cs" Inherits="WebSite.Admin.SendMsgPage.SendMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>发送消息</title>
    <script type="text/javascript">
        function SendMsg() {
            if ($("#keyword1").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("会议主题不能为空！");
                $("#keyword1").focus();
                return;
            }
            else if ($("#keyword2").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("会议日期不能为空！");
                $("#keyword2").focus();
                return;
            }
            else if ($("#keyword3").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("会议地点不能为空！");
                $("#keyword3").focus();
                return;
            }
            else if ($("#keyword4").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("发起人不能为空！");
                $("#keyword4").focus();
                return;
            }
            else if ($("#keyword5").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                alert("备注不能为空！");
                $("#keyword5").focus();
                return;
            }
            else if ($("#weburl").val().replace(/(^\s*)|(\s*$)/g, "") == "" || $("#weburl").val().replace(/(^\s*)|(\s*$)/g, "") == "http://") {
                alert("网址不能为空！");
                $("#weburl").focus();
                return;
            }
            else {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/WeiXinAPI.ashx",
                    data: $("#aspnetForm").serialize(),
                    beforeSend: function () {
                        $("#group_send").hide();
                        $("#waiting_div").show();
                    },
                    complete: function () {
                        $("#group_send").show();
                        $("#waiting_div").hide();
                    },
                    success: function (data) {
                        if (data == "OK") {
                            alert("发送完毕！");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { alert(' 发生错误，请联系客服！ '); }
                });
            }
        }
    </script>
    <style type="text/css">
    .div{width:850px; height:auto; margin:auto;}
    .div table{width:100%; height:auto; line-height:30px; font:14px/150% "Microsoft YaHei", "微软雅黑", sans-serif,Arial, Helvetica; color:#333; background-color:aliceblue}
    .div table th{text-align:right;}
    .div table td{text-align:left; line-height:30px;}
    .div table td select{width:600px; height:auto; text-align:left; border:1px solid #d1d1d1; margin:8px 5px; display:block; height:30px; outline:medium;}
    .div table td input{width:600px; cursor:pointer; height:30px; border:1px solid #CCC; line-height:30px; overflow:hidden; margin:3px 6px; padding:0 6px; outline:medium; border-bottom-left-radius:5px; border-top-left-radius:5px; border-bottom-right-radius:5px; border-top-right-radius:5px; -webkit-border-top-left-radius:5px; -webkit-border-bottom-left-radius:5px; -webkit-border-top-right-radius:5px; -webkit-border-bottom-right-radius:5px;}
    a{
        text-decoration:none;
    }
    a.btnblue {
        display: inline-block;
        color: #FFFFFF;
        border-radius: 3px;
        background: url(../images/ablue.gif) repeat-x;
        border: 1px solid #3171B5;
        line-height: 24px;
        padding: 1px 20px;
        font-size: 14px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    发送消息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Send Message
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

        <div class="div" id="group_send">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <th width="20%">会议主题：</th>
                    <td width="80%">
                        <input name="keyword1" id="keyword1" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>会议日期：</th>
                    <td>
                        <input name="keyword2" id="keyword2" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>会议地点：</th>
                    <td>
                        <input name="keyword3" id="keyword3" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>发起人：</th>
                    <td>
                        <input name="keyword4" id="keyword4" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>备注：</th>
                    <td>
                        <input name="keyword5" id="keyword5" type="text" />
                    </td>
                </tr>
                <tr>
                    <th>链接网址：</th>
                    <td>
                        <input name="weburl" id="weburl" type="text" value="http://" />
                    </td>
                </tr>
                <tr>
                    <th>用户组：</th>
                    <td style="text-align:left">
                        <select name="tagGroup">
                            <option value="-2">全部用户</option>
                            <option value="2">星标用户</option>
                            <option value="127">麻醉科</option>
                            <option value="134">儿科</option>
                            <option value="108">耳鼻喉</option>
                            <option value="110">放射 Accra</option>
                            <option value="129">妇产科</option>
                            <option value="117">肛肠 Cscp</option>
                            <option value="136">供应商</option>
                            <option value="132">骨科</option>
							<option value="137">罕见病</option>
                            <option value="121">会展公司</option>
                            <option value="133">急诊科</option>
                            <option value="116">精神CPA</option>
                            <option value="118">临床药学</option>
                            <option value="120">曼迪</option>
                            <option value="109">媒体</option>
                            <option value="107">免疫LMNH</option>
                            <option value="123">皮肤科</option>
                            <option value="111">疝 Hernia</option>
                            <option value="125">烧伤整形科</option>
                            <option value="115">肾CNA</option>
							<option value="138">糖尿病</option>
                            <option value="130">疼痛科</option>
                            <option value="103">外科CCS</option>
                            <option value="114">消化CAGH</option>
                            <option value="119">协会工作人员</option>
                            <option value="113">血管外科</option>
                            <option value="126">眼科</option>
                            <option value="135">医药企业</option>
                            <option value="124">中西医结合科</option>
                            <option value="128">中医</option>
                            <option value="122">肿瘤</option>
                            <option value="131">重症医学科</option>
                            <option value="106" selected>tech max</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <a class="btnblue" href="javascript:void(0)" onclick="SendMsg()">发送</a>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="waiting_div" style="display:none; margin:0px auto; padding:0px; text-align:center;">
            <img src="../images/waiting_03.gif" alt="" style="margin-top: 19%; width: 50px; height: auto;" />
        </div>
</asp:Content>
