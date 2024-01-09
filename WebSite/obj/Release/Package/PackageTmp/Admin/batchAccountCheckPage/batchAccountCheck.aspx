<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="batchAccountCheck.aspx.cs" Inherits="WebSite.Admin.batchAccountCheckPage.batchAccountCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    批量对账
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Batch Account Check
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

    <script type="text/javascript" src="/js/uploadify/swfobject.js"></script>
    <script type="text/javascript" src="/js/uploadify/jquery.uploadify.v2.1.0.js"></script>
    <style>
        #order_box {
            width:100%;
        }
    </style>

    <script type="text/javascript">

        $(document).ready(function () {
            
            LoadImportControls();
            LoadTable();
            excBatchAccount();
            dalAll();

        });

        function LoadImportControls() {

            $("#uploadify").uploadify({
                'uploader': '/js/uploadify/uploadify.swf',
                'script': '/AjaxResponse/tech_batchHandler.ashx?type=uploadExcel',
                'cancelImg': '/js/uploadify/cls.png',
                'folder': "/Upload/excelFile",
                'queueID': 'fileQueue',
                'fileExt': '*.xls;*.xlsx',
                'fileDesc': '支持格式:xls/xlsx',
                'buttonImg': '/js/uploadify/Up_file.jpg',
                'auto': true,
                'multi': false,
                'width': 78,
                'height': 38,
                'onSelect': function (e, queueId, fileObj) {  //文件上传时
                    $("#lb_loading").show();
                },
                'onComplete': function (event, ID, fileObj, response, data) {  //文件上传后
                    $("#lb_loading").hide();
                    $("#excelFile").val(response);
                    ImportData();
                }
            });

            
        }


        function ImportData() {
            $.ajax({
                type: "get",
                url: "/AjaxResponse/tech_batchHandler.ashx?type=saveData&postvalue=" + escape($("#excelFile").val()),
                success: function (data) {
                    if (data != "") {
                        alert(data);
                        LoadTable();
                    } 
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('获取数据失败');
                }
            });
        }

        function LoadTable() {
            $.ajax({
                type: "get",
                url: "/AjaxResponse/tech_batchHandler.ashx?type=loadTable",
                success: function (data) {
                    if(data!=""){
                        $("#order_box").html(data);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('获取数据失败');
                }
            });
        }

        function excBatchAccount() {
            $("#btnExc").click(function () {

                $.ajax({
                    type: "get",
                    url: "/AjaxResponse/tech_batchHandler.ashx?type=excBatchAccount",
                    success: function (data) {
                        if (data != "") {
                            alert("对账完成，共有" + data + "条不符！");
                            $('#error_count').html(data);
                            $('#message_box').css('display', 'block');
                            LoadTable();
                        }
                    }
                })

            });
        }

        function dalAll(){
            $("#btnClear").click(function () {
            
                $.ajax({
                    type: "get",
                    url: "/AjaxResponse/tech_batchHandler.ashx?type=delAll",
                    success: function (data) {
                        if (data != "") {
                            $('#message_box').css('display', 'none');
                            LoadTable();
                        } 
                    }
                })

            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <b style="display:none;" id="lb_loading"><P style="text-align:center;">文件上传中,请稍候...</P></b>

    <table>
        <tr>
            <td>
                <input type="file" name="uploadify" id="uploadify" />
                <input type="hidden" id="excelFile" name="excelFile" />
            </td>
            <td><input id="btnExc" type="button" value="开始对账" class="btn btn-purple btnset" /></td>
            <td><input id="btnClear" type="button" value="清除数据" class="btn btn-red btnset" /></td>
            <td><a href="/Upload/批量对账单.xlsx">（模板下载）</a></td>
        </tr>
    </table>

    <table class="table table-small-font table-bordered table-striped" id="message_box" style="display:none">
        <tr>
            <td>对账完成，其中有<span id="error_count" style="color:red; font-weight:bold;">0</span>条不符！</td>
        </tr>
    </table>
    
    <div id="order_box"></div>

</asp:Content>
