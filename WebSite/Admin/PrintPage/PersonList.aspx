<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="WebSite.Admin.PrintPage.PersonList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/js/uploadify/swfobject.js"></script>
    <script type="text/javascript" src="/js/uploadify/jquery.uploadify.v2.1.0.js"></script>

    <script type="text/javascript" src="/js/Print_Badge.js"></script>
    <object id="ArgoxWebPrint" classid="clsid:AEFC7183-44DE-463c-ACEF-8CAF33B96701" style="display: none;" codebase="ArgoxWebPrint.cab"></object>

    <script type="text/javascript">
        $(document).ready(function ()
        {

            LoadImportControls()

            $('.mydel').click(function () {

                var deviceid = $(this).attr('deviceid');

                if (confirm('您确认要删除吗？')) {
                    $.ajax({

                        type: 'GET',
                        url: '/AjaxResponse/PrintPersonHandler.ashx?type=del&id=' + deviceid,
                        success: function (data) {
                            var r = eval("(" + data + ")");
                            if (r.result == 'succ') {
                                alert(r.msg);
                                window.location.href = 'PersonList.aspx?page=<%=mypager.CurrentPageIndex%>';
                            }
                            else {
                                alert(r.msg);
                            }
                        }

                    });
                }

            });
        });


        function LoadImportControls() {

            $("#uploadify").uploadify({
                'uploader': '/js/uploadify/uploadify.swf',
                'script': '/AjaxResponse/PrintPersonHandler.ashx?type=uploadExcel',
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
                url: "/AjaxResponse/PrintPersonHandler.ashx?type=saveData&postvalue=" + escape($("#excelFile").val()),
                success: function (data) {
                    if (data != "") {
                        alert(data);
                        window.location.href = 'PersonList.aspx';
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('获取数据失败');
                }
            });
        }

        function setPrint(id) {
            var page=<%=mypager.CurrentPageIndex%>;
            $.ajax({
                type: "get",
                url: "/AjaxResponse/PrintPersonHandler.ashx?type=setPrint&postvalue=" + id,
                success: function (data) {
                    var r = eval("(" + data + ")");
                    if (r.result == 'succ') {
                        window.location.href = 'PersonList.aspx?page='+page;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('更新数据失败');
                }
            });
        }


        function dayin(code, name, id) {            
            print_badge_ch(code, name);
            setPrint(id);            
        }

    </script>

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelTitle" runat="server">
    管理人员
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanelTitleDesc" runat="server">
    Person List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PanelHeader" runat="server">

    <div style="font-size:12px">
        <span style="float:left; padding:5px 5px 0 0;">编码</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="person_code" name="person_code" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">姓名</span>
        <span style="float:left; padding:0 5px 0 0;"><input id="person_name" name="person_name" type="text" class="form-control" /></span>
        <span style="float:left; padding:5px 5px 0 0;">类型</span>
        <span style="float:left; padding:0 5px 0 0;">
            <select id="person_group" name="person_group" class="form-control">
                <option value="0">--全部--</option>
                <option value="1">医师领导及工作人员</option>
                <option value="2">中宾专家</option>
                <option value="3">外宾专家</option>
            </select></span>
        <span style="float:left; padding:5px 5px 0 0;">打印状态</span>
        <span style="float:left; padding:0 5px 0 0;">
            <select id="is_print" name="is_print" class="form-control">
                <option value="0">--全部--</option>
                <option value="1">已打印</option>
                <option value="2">未打印</option>
            </select></span>
        <span style="float:left; padding:0 5px 0 0;">
            <input id="btn_search" type="submit" value="搜索" class="btn btn-blue" /></span>
        <span style="float:left; padding:0 5px 0 0;">
            <input type="file" name="uploadify" id="uploadify" />
            <input type="hidden" id="excelFile" name="excelFile" />
            <b style="display:none;" id="lb_loading"><P style="text-align:center;">文件上传中,请稍候...</P></b>            
            </span>
        <span style="float:left; padding:5px 5px 0 0;">
            <a href="/Upload/胸牌模板.xlsx">模板下载</a>
            </span>
    </div>
    

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PanelBody" runat="server">

    <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="false" data-add-display-all-btn="false" data-add-focus-btn="false">
        <table cellspacing="0" class="table table-small-font table-bordered table-striped">
            <thead>
                <tr>
                    <th data-priority="1">
                        人员编码
                    </th>
                    <th data-priority="2">
                        人员姓名
                    </th>
                    <th data-priority="2">
                        类型
                    </th>
                    <th data-priority="2">
                        打印状态
                    </th>
                    <th data-priority="5">
                        添加时间
                    </th>
                    <th data-priority="5">
                        操作
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="rpt_list" runat="server">                
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("person_code").ToString() %></td>
                        <td><%#Eval("person_name").ToString() %></td>
                        <td><%#getGroupStr(Eval("person_group").ToString()) %></td>
                        <td><%#getPrintState(Eval("is_print").ToString()) %></td>
                        <td><%#DateTime.Parse(Eval("inputtime").ToString()).ToString("yy年MM月dd日 HH:mm") %></td>
                        <td>
                            <a onclick="dayin('<%#Eval("person_code").ToString() %>','<%#Eval("person_name").ToString() %>','<%#Eval("id").ToString() %>')" class="btn btn-blue btn-xs">打印</a>
                            <a href="<%#"PersonEdit.aspx?id="+Eval("id") %>&page=<%=mypager.CurrentPageIndex %>" class="btn btn-secondary btn-xs">编辑</a>
                            <a deviceid='<%#Eval("id") %>' class="btn btn-red btn-xs mydel" href="#">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tbody>
            </tbody>
        </table>
    </div>
    <div class="dataTables_paginate paging_simple_numbers">
        <webdiyer:AspNetPager ID="mypager" runat="server" CssClass="anpager" OnPageChanged="mypager_PageChanged" UrlPaging="True">
        </webdiyer:AspNetPager>
    </div>

</asp:Content>
