﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/HYManager.Master" AutoEventWireup="true" CodeBehind="mobile_imgs.aspx.cs" Inherits="DIY.HYManager.base_setting.mobile_imgs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/uploadifive/jquery.min.js"></script>
    <script type="text/javascript" src="/js/uploadifive/jquery.uploadifive.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/uploadifive/uploadifive.css" />
    <link rel="stylesheet" href="/style/colorPicker.css" />
    <style type="text/css">
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

        .uploadBtn {
            width: 60px;
            height: 28px;
            background: #1D8382;
            cursor: pointer;
            text-align: center;
            line-height: 28px;
            padding: 0px;
            font-weight: bold;
            color: #FFF;
            font-size: 14px;
            border: none;
        }

        div.preview-layer{
            display: block;
            position: relative;
            left:50%;
        }
        div.preview-layer .preview-phone{
            width: 331px;
            height: 668px;
            background: url(/image/iphoneX.png) no-repeat no-repeat;
            z-index: 1000;
        }
        .preview-html{
            position: absolute;
            width:296px !important;
            height: 616px !important;
            top:38px;
            left:21px;
            border:0px solid #000;
            border-radius: 10px 10px 25px 25px;
            outline: none;
            background-color: #fff;

            
        }
    </style>

    <script type="text/javascript">
        var mid = '<%=mid %>';
        $(document).ready(function () {
            uploadiFive();
            preview();
        });
        //加载
        function LoadTable() {
            location.reload();
        }

        function preview() {
            var murl = '<%=m_website%>';
            $("#preview-html").attr('src', murl);
        }

        function uploadiFive() {
            $('#upload_logo').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue1',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=' + mid,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue1").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#logo").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue1").hide();
                    }
                    else {
                        //dialogTime('' + data + '', '');
                        alert('' + data + '');
                    }
                }
            });

            $('#upload_mainImgPc').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue2',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=' + mid,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue2").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#main_img_pc").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue2").hide();
                    }
                    else {
                        //dialogTime('' + data + '', '');
                        alert('' + data + '');
                    }
                }
            });

            $('#upload_mainImgMobile').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue3',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=' + mid,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue3").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#main_img_mobile").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue3").hide();
                    }
                    else {
                        //dialogTime('' + data + '', '');
                        alert('' + data + '');
                    }
                }
            });

            $('#upload_contentBg').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue4',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=' + mid,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue4").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#first_content_bg").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue4").hide();
                    }
                    else {
                        //dialogTime('' + data + '', '');
                        alert('' + data + '');
                    }
                }
            });

            $('#upload_scend_top_bg').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue5',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=' + mid,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue5").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#scend_top_bg").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue5").hide();
                    }
                    else {
                        //dialogTime('' + data + '', '');
                        alert('' + data + '');
                    }
                }
            });

        }
        function SaveData() {
            if ($("#logo").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
                $("#logo").focus();
                alert('logo不能为空');
            } else {
                $.ajax({
                    type: "post",
                    url: "/AjaxResponse/tech_mobileHandler.ashx?type=SaveMobileImgs&postvalue=<%=mid %>",
                    data: {
                        "ftp_upload_url": $("#ftp_upload_url").val(),
                        "id": $("#id").val(),
                        "mid": $("#mid").val(),
                        "logo": $("#logo").val(),
                        "main_img_pc": $("#main_img_pc").val(),
                        "main_img_mobile": $("#main_img_mobile").val(),
                        "first_content_bg": $("#first_content_bg").val(),
                        "scend_top_bg": $("#scend_top_bg").val(),
                        "web_back_color": $("#web_back_color").val()
                    },
                    success: function (data) {
                        if (data == "OK") {
                            dialogTimeClose('操作成功！', '', "yes");
                        }
                        else {
                            dialogTime('' + data + '', '');
                        }
                    }
                });
            }
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

    <input type="hidden" id="ftp_upload_url" value="<%=Common.ConfigHelper.GetConfigString("ftp_upload_url")%>" />
    <input type="hidden" id="id" name="id" value="<%=id %>" />
    <input type="hidden" id="mid" name="mid" value="<%=mid %>" />
    <div class="Content" style="float: left">
        <div class="listtable" id="system_data">
            <table width="660" border="0" cellspacing="0" cellpadding="0" class="infotablel">
                <tr>
                    <td colspan="2">网站图片信息编辑</td>
                </tr>
                <tr>
                    <th scope="row">二级页Logo</th>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td><input class="txt" id="logo" name="logo" type="text" style="width: 350px;" value="<%=logo %>" /></td>
                                <td><input id="upload_logo" name="upload_logo" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                            </tr>
                            <tr>
                         宽：900像素；高：210像素</td>
                            </tr>
                        </table>
                        <div id="queue1"></div>
                    </td>
                </tr>
                <tr>
                    <th scope="row">首页主形象PC端</th>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td><input class="txt" id="main_img_pc" name="main_img_pc" type="text" style="width: 350px;" value="<%=main_img_pc %>" /></td>
                                <td><input id="upload_mainImgPc" name="upload_mainImgPc" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">4:3 没有具体宽高要求</td>
                            </tr>
                        </table>
                        <div id="queue2"></div>
                    </td>
                </tr>
                <tr>
                    <th scope="row">首页主形象手机端</th>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td><input class="txt" id="main_img_mobile" name="main_img_mobile" type="text" style="width: 350px;" value="<%=main_img_mobile %>" /></td>
                                <td><input id="upload_mainImgMobile" name="upload_mainImgMobile" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">宽：1000像素；高：700像素an="2">宽：1000像素；高：700像素</td>
                            </tr>
                        </table>
                        <div id="queue3"></div>
                    </td>
                </tr>
                <tr>
                    <th scope="row">首页背景图</th>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td><input class="txt" id="first_content_bg" name="first_content_bg" type="text" style="width: 350px;" value="<%=first_content_bg %>" /></td>
                                <td><input id="upload_contentBg" name="upload_contentBg" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">宽：1000像素；高：1730像素</td>
                            </tr>
                        </table>
                        <div id="queue4"></div>
                    </td>
                </tr>
                <tr>
                    <th scope="row">二级页面顶部背景图</th>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td><input class="txt" id="scend_top_bg" name="scend_top_bg" type="text" style="width: 350px;" value="<%=scend_top_bg %>" /></td>
                                <td><input id="upload_scend_top_bg" name="upload_scend_top_bg" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">宽：1600像素；高：80像素</td>
                            </tr>
                        </table>
                        <div id="queue5"></div>
                    </td>
                </tr>

                <tr>
                    <th scope="row">二级页面背景色</th>
                    <td>
                        <input class="txt" id="web_back_color" name="web_back_color" type="text" style="width: 120px; float: left;" value="<%=web_back_color %>" />
                        <div id="chooseColor"></div>
                        <div id="pickBox" style="display: none">
                            <div class="colorBox">
                                <div class="color" style="background-color: rgb(255, 0, 0);">
                                    <div class="white"></div>
                                    <div class="black"></div>
                                    <div class="point">
                                        <div class="p"></div>
                                    </div>
                                </div>
                                <div class="colorSelect">
                                    <div class="colorBar"></div>
                                    <div class="thumb bar"></div>
                                </div>
                            </div>
                            <div class="transparency" style="background-color: rgb(255, 255, 255);">
                                <div class="transparencyBar"></div>
                                <div class="thumb trans"></div>
                            </div>
                            <div class="operate">
                                <input autocomplete="off" class="rgbaText" type="text" value="rgba(255,255,255,1)" />
                                <button id="confirm">确认</button>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr>
                    <th scope="row"></th>
                    <td>
                        <input type="hidden" id="sys_code" name="sys_code" />
                        <a class="btnblue" href="javascript:void(0)" onclick="SaveData()">保存</a>
                        <br />
                        图片上传成功后，点击“保存”按钮即可在右侧预览效果！
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <div class="h10"></div>
        </div>

    </div>

    <div style="float: left">

        <div class="preview-layer">
            <div class="preview-phone">
                <iframe id="preview-html" name="preview-html" class="preview-html" src=""></iframe>
            </div>
        </div>

    </div>

    <div class="clear"></div>

    <script type="text/javascript" src="/js/colorPicker.js"></script>
</asp:Content>