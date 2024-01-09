<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PersonAdd.aspx.cs" Inherits="WebSite.Admin.PrintPage.PersonAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var person_code = $("#person_code").val();
                var person_name = $("#person_name").val();
                var person_group = $("#person_group").val();
                
                if (person_code == "") {
                    alert('人员编码不能为空！');
                    $("#person_code").focus();
                    return false;
                }
                if (person_name == "") {
                    alert('人员姓名不能为空！');
                    $("#person_name").focus();
                    return false;
                }
                if (person_group == "0") {
                    alert('请选择一个分组！');
                    $("#person_group").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/PrintPersonHandler.ashx?type=add",
                    data:$('#aspnetForm').serialize(),
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            alert(r.msg);
                        } else {
                            alert(r.msg);
                        }
                    },
                    complete: function (XMLHttpRequest, textStatus) { },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    添加人员
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Person
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_person_code">人员编码</label>
        <div class="col-sm-10">
            <input id="person_code" name="person_code" type="text" style="width:300px;" class="form-control" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_person_name">人员姓名</label>
        <div class="col-sm-10">
            <input id="person_name" name="person_name" type="text" style="width:300px;" class="form-control" />
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_person_name">选择分组</label>
        <div class="col-sm-10">
            <select id="person_group" name="person_group" style="width:300px;" class="form-control">
                <option value="0">--请选择分组--</option>
                <option value="1">医师领导及工作人员</option>
                <option value="2">中宾专家</option>
                <option value="3">外宾专家</option>
            </select>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_person_name"></label>
        <div class="col-sm-10">
            <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
        </div>
    </div>

</asp:Content>
