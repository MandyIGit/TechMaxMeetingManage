<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="edit_msg.aspx.cs" Inherits="WebSite.Admin.MessagePage.edit_msg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function CheckEmpty() {
            
            if ($("#Contacts").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#Contacts").focus();
                alert('联系人不能为空');
                return false;
            }
            if ($("#UnitName").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#UnitName").focus();
                alert('单位名称不能为空');
                return false;
            }
            if ($("#Email").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#Email").focus();
                alert('电子邮件不能为空');
                return false;
            }
            if ($("#Email").val().match("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$") == null) {
                $("#Email").focus();
                alert('电子邮件格式不正确');
                return false;
            }
            if ($("#Phone").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#Phone").focus();
                alert('联系电话不能为空');
                return false;
            }
            if ($("#Phone").val().match("(^(/d{3,4}-)?/d{7,8})$|(1[0-9]{10})") == null) {
                $("#Phone").focus();
                alert('电话号格式不正确');
                return false;
            }
            //if ($("input:checkbox:checked").length == 0) {
            //    alert('请至少选择一个意向服务！');
            //    return false;
            //}
            //if ($("#datebirth").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            //    $("#datebirth").focus();
            //    alert('出生日期不能为空');
            //    return false;
            //}
            
            return true;
        }

        $(document).ready(function () {
            
            $("#btnSave").click(function () {
                if (CheckEmpty()) {
                    $.ajax({
                        type: "post",
                        url: "/AjaxResponse/tech_messageHandler.ashx?type=editMsg",
                        data: $("#aspnetForm").serialize(),
                        beforeSend: function () {
                        },
                        complete: function () {
                        },
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert("信息保存成功！");
                                window.close();
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
    编辑反馈信息
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Edit Message
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Contacts">联系人</label>
        <div class="col-sm-10">
            <input type="text" id="Contacts" name="Contacts" class="form-control" value="<%=info.Contacts %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="UnitName">单位名称</label>
        <div class="col-sm-10">
            <input type="text" id="UnitName" name="UnitName" class="form-control" value="<%=info.UnitName %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Email">邮箱</label>
        <div class="col-sm-10">
            <input type="text" id="Email" name="Email" class="form-control" value="<%=info.Email %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Phone">电话</label>
        <div class="col-sm-10">
            <input type="text" id="Phone" name="Phone" class="form-control" value="<%=info.Phone %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Intention">意向</label>
        <div class="col-sm-10">
            <input type="checkbox" id="cbPhonecall" name="cbPhonecall" class="checkbox-row" />
            <label for="cbPhonecall">我希望电话沟通</label>
            <input type="checkbox" id="cbMeeting" name="cbMeeting" class="checkbox-row" />
            <label for="cbMeeting">我希望会议面谈</label>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Content">留言内容</label>
        <div class="col-sm-10">
            <textarea name="Content" id="Content" rows="5" class="form-control"><%=info.Content %></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Content">处理状态</label>
        <div class="col-sm-10">
            <select name="Status" id="Status" class="form-control">
                <option value="1">已处理</option>
                <option value="2">未处理</option>
                <option value="3">无效信息</option>
            </select>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Content">单位类型</label>
        <div class="col-sm-10">
            <select name="UnitType" id="UnitType" class="form-control">
                <option value="1">会务公司</option>
                <option value="2">医院</option>
                <option value="3">企业</option>
                <option value="4">其他</option>
            </select>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Content">会议需求</label>
        <div class="col-sm-10">
            <input type="checkbox" id="cbMeetingNeed1" name="cbMeetingNeed1" class="checkbox-row">
            <label for="cbMeetingNeed1">网站</label>
            <input type="checkbox" id="cbMeetingNeed2" name="cbMeetingNeed2" class="checkbox-row">
            <label for="cbMeetingNeed2">注册</label>
            <input type="checkbox" id="cbMeetingNeed3" name="cbMeetingNeed3" class="checkbox-row">
            <label for="cbMeetingNeed3">直播平台</label>
            <input type="checkbox" id="cbMeetingNeed4" name="cbMeetingNeed4" class="checkbox-row">
            <label for="cbMeetingNeed4">展商</label>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="MeetingScale">会议规模</label>
        <div class="col-sm-10">
            <input type="text" id="MeetingScale" name="MeetingScale" class="form-control" value="<%=info.MeetingScale %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="MeetingStartTime">会议开始时间</label>
        <div class="col-sm-10">
            <input type="text" id="MeetingStartTime" name="MeetingStartTime" class="form-control datepicker" data-format="yyyy-mm-dd" value="<%=info.MeetingStartTime %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>
    
    <div class="form-group">
        <label class="col-sm-2 control-label" for="Content">是否沟通</label>
        <div class="col-sm-10">
            <select name="isComm" id="isComm" class="form-control">
                <option value="1">是</option>
                <option value="2">否</option>
            </select>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Phone">沟通进度</label>
        <div class="col-sm-10">
            <input type="text" id="CommProgress" name="CommProgress" class="form-control" value="<%=info.CommProgress %>" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="Remark">备注</label>
        <div class="col-sm-10">
            <textarea name="Remark" id="Remark" rows="5" class="form-control"><%=info.Remark %></textarea>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label"></label>
        <div class="col-sm-10">
            <input type="hidden" name="id" value="<%=id %>" />
            <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
            <input type="button" value="关闭" class="btn btn-info btnset" onclick="window.close();" />
        </div>
    </div>
    
    <%=script_html %>
   
</asp:Content>
