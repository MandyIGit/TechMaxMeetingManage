<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="WordAdd.aspx.cs" Inherits="WebSite.Admin.ForbiddenWord.WordAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSave").click(function () {

                var word = $(".txt_word").val();

                if (word == "") {
                    alert('严禁词不能为空！');
                    $(".txt_word").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_forbidden_wordHandler.ashx?type=add",
                    data: {
                        word: word
                    },
                    beforeSend: function (XMLHttpRequest, textStatus) { },
                    success: function (data) {
                        var r = eval("(" + data + ")");
                        if (r.result == 'succ') {
                            window.location.href = 'WordList.aspx';
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
    添加严禁词
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Add Word
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">
    
    <div class="form-group">
        <label class="col-sm-2 control-label" for="txt_mcontactmblie">添加严禁词</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txt_word" runat="server" Width="300px" CssClass="form-control txt_word"></asp:TextBox>
        </div>
    </div>
    <div class="form-group-separator">
    </div>

    <div class="form-group" style="padding-left:200px;">
        <input id="btnSave" type="button" value="保存" class="btn btn-blue btnset" />
    </div>

</asp:Content>
