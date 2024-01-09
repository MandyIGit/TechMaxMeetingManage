<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HYManager.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DIY.HYManager.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .TabWrap {
            width: 100%;
            margin: 0 auto;
            overflow: hidden;
            background: #f5f5f5;
            border-bottom: 3px solid #ccc;
            height: 50px;
            line-height: 50px;
            margin-top: 30px;
        }

        .TabListWrap {
            float: left;
        }

        .TabList {
            float: left;
            width: 100%;
        }

            .TabList li {
                float: left;
                padding-right: 1px;
                height: 50px;
            }

                .TabList li a {
                    color: #2b3033;
                    font-size: 14px;
                    line-height: 50px;
                    display: inline-block;
                    padding: 0 25px;
                    cursor: default;
                }

                .TabList li .on {
                    color: #fff;
                    background: #BF0000;
                }

        input[type=button] {
            width: 60px;
            height: 28px;
            background: #84c810;
            cursor: pointer;
            text-align: center;
            line-height: 28px;
            padding: 0px;
            margin-right: 10px;
            margin-bottom: 20px;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            border: none;
            border-bottom-left-radius: 5px;
            border-top-left-radius: 5px;
            border-bottom-right-radius: 5px;
            border-top-right-radius: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
        }

        .fenye {
            width: 100%;
            height: 24px;
            line-height: 24px;
            padding: 2px 0px;
            font-family: "Microsoft YaHei", "微软雅黑", sans-serif !important;
            font-size: 12px;
            color: #666;
            text-align: center;
        }

            .fenye a {
                border: 1px solid #ccc;
                padding: 3px 7px;
                margin: 2px 3px;
                color: #666;
                text-decoration: none;
                -moz-border-radius: 5px;
                -webkit-border-radius: 5px;
                border-radius: 5px;
            }

                .fenye a:hover {
                    border: 1px solid #448bc9;
                    color: #FFF;
                    background: #448bc9;
                }

            .fenye .current {
                border: 1px solid #448bc9;
                color: #FFF;
                background: #448bc9;
            }

        .sortClass li {
            margin-left: 2rem;
        }

        .sortClass div {
            display: inline-block;
            margin-left: 1rem;
        }

        .blueClass {
            background-color: #3151b1;
            color: white;
            padding: 0.08rem 0.5rem;
            border-radius: 0.3rem;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            var isSC = '<%=isShengcheng%>';
            var isKT = '<%=isKaitong%>';

            $("#nokaitong").hide();
            $("#kaitonged").hide();
            $("#kaitonging").hide();

            if (isKT == '1') {

                $("#nokaitong").hide();

                if (isSC == '1') {
                    $("#kaitonged").show();
                    $("#kaitonging").hide();
                } else {
                    $("#kaitonged").hide();
                    $("#kaitonging").show();
                    $("#kaitonging_1").show();
                    $("#kaitonging_2").hide();
                    LoadTable();
                }
            }
            else if (isKT == '2') {
                $("#nokaitong").show();
            }

        });

        function click_two() {

            if ($("#mtemplate_id").val() == '0') {
                alert('请选中一个模板！');
            } else {

                $("#kaitonging_1").hide();
                $("#kaitonging_2").show();

                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=3&postvalue=" + $("#mtemplate_id").val(),
                    data: $("#form_kaitonging").serialize(),
                    success: function (data) {
                        $('#show_moban').html(data);
                    }
                });

            }
        }

        function click_back_one() {
            $("#kaitonging_1").show();
            $("#kaitonging_2").hide();
        }

        function set_version_id(v_id) {
            $("#version_id").val(v_id);
            $("#version_id_ a").attr("class", "btn btnwhite");
            $("#version_id_" + v_id).attr("class", "btn btnblue");
            LoadTable();
        }

        //加载
        function LoadTable() {
            var pageindex = 1;
            if ($('#txtpageIndex').length > 0) {
                pageindex = $('#txtpageIndex').val();
            }
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobileHandler.ashx?type=2&postvalue=<msg_data><pageIndex>" + pageindex + "</pageIndex><pageSize>14</pageSize></msg_data>",
                data: $("#form_kaitonging").serialize(),
                success: function (data) {
                    $('#tb_Content').html(data);
                    dlSelector();
                }
            });
        }

        function SelectLoadTable() {
            $('#txtpageIndex').val("1");
            LoadTable();
        }

        function dlSelector() {

            $("#tb_Content dl").mouseover(function () {
                $(this).css("border", "1px solid #FF0000");
            })

            $("#tb_Content dl").mouseout(function () {
                $("#tb_Content dl").css("border", "1px solid #DBDBEA");
                if ($("#mtemplate_id").val() != 0) {
                    $("#" + $("#mtemplate_id").val() + "").css("border", "2px solid #FF0000");
                }
            })
        }

        function ChangeMT(m_id) {
            $("#" + m_id + "").css("border", "2px solid #FF0000");
            $("#mtemplate_id").val(m_id);
        }

        function save_data() {
            if (confirm("微站开通后，网站模板不可更改，确认开通吗？")) {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveSkinAndSiteImg&postvalue=",
                    data: $("#form_kaitonging").serialize(),
                    success: function (str) {
                        if (str == "OK") {
                            dialogTimeClose('微站已经开通成功！', 'index.aspx', "no");
                        }
                        else {
                            dialogTimeClose('微站开通失败，请联系管理员！', '', "");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { alert('发生错误，请联系客服！'); }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="skin">
        <div class="p10">

            <div class="start_boxes">
                <ul>
                    <li>会议编码<span><%=tm.mid %></span></li>
                    <li>会议名称<span><%=tm.mname %></span></li>
                    <li>网站预览：<a href="<%=tm.m_website %>" target="_blank"><%=tm.m_website %></a></li>
                </ul>
            </div>
            <div class="h10"></div>
            <div class="listtable">

                <div id="nokaitong">
                    <div class="Content">

                        微站文件后台正在开通中，请稍后再试或联系后台人员！

                    </div>
                </div>

                <div id="kaitonged">
                    <div style="width: 700px; margin: auto;">
                        <div class="contenter_box">
                            <ul>
                                <a href="/HYManager/base_setting/mobile_imgs.aspx" target="_blank">
                                    <li>微站图片管理</li>
                                </a>
                                <a href="/HYManager/mobile_menu/menu_edit.aspx" target="_blank">
                                    <li>微站导航管理</li>
                                </a>
                                <a href="/HYManager/mobile_menu/menu_content.aspx" target="_blank">
                                    <li>微站内容管理</li>
                                </a>
                                <a href="/HYManager/mobile_agenda/session_list.aspx" target="_blank">
                                    <li>微站日程管理</li>
                                </a>
                            </ul>

                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div id="kaitonging">

                    <div class="Content">

                        <form id="form_kaitonging">
                            <div id="kaitonging_1">

                                <input type="hidden" name="mid" value="<%=tm.mid %>" />
                                <input type="hidden" id="version_id" name="version_id" value="0" />
                                <input type="hidden" id="mtemplate_id" name="mtemplate_id" value="0" />

                                <div class="TabWrap">
                                    <div class="TabListWrap">
                                        <ul class="TabList">
                                            <li><a href="javascript:void(0)" class="on">1.会议模板选择</a></li>
                                            <li><a href="javascript:void(0)">2.提交生成微站</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                    <tr>
                                        <th scope="row">会议版本</th>
                                        <td id="version_id_">
                                            <a href="javascript:void(0);" id="version_id_0" class="btn btnblue" onclick="set_version_id(0)">全部</a>
                                            <a href="javascript:void(0);" id="version_id_1" class="btn btnwhite" onclick="set_version_id(1)">经典版</a>
                                            <a href="javascript:void(0);" id="version_id_2" class="btn btnwhite" onclick="set_version_id(2)">时尚版</a>
                                            <a href="javascript:void(0);" id="version_id_3" class="btn btnwhite" onclick="set_version_id(3)">传统版</a>
                                            <a href="javascript:void(0);" id="version_id_4" class="btn btnwhite" onclick="set_version_id(4)">微软版</a>
                                        </td>
                                    </tr>
                                </table>
                                <div id="tb_Content">
                                </div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                    <tr>
                                        <td style="text-align: center;">
                                            <a class="btnblue" href="javascript:void(0)" onclick="click_two()">下一步</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="kaitonging_2">

                                <div class="TabWrap">
                                    <div class="TabListWrap">
                                        <ul class="TabList">
                                            <li><a href="javascript:void(0)">1.会议模板选择</a></li>
                                            <li><a href="javascript:void(0)" class="on">2.提交生成微站</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                                    <tr>
                                        <td id="show_moban" style="text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; font-size: 14px;">（模板预览效果）</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; color: red; font-size: 16px;">提示：网站一旦开通后，模板不可再次选择修改，请您确认好模板后再开通！！！</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <a class="btnblue" href="javascript:void(0)" onclick="click_back_one()">上一步</a>
                                            <a class="btnblue" href="javascript:void(0)" onclick="save_data()">提交确认开通</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
