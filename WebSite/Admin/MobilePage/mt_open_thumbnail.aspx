<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mt_open_thumbnail.aspx.cs" Inherits="WebSite.Admin.MobilePage.mt_open_thumbnail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>上传缩略图</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="/js/uploadifive/jquery.min.js"></script>
    <script type="text/javascript" src="/js/uploadifive/jquery.uploadifive.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/uploadifive/uploadifive.css" />
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
    </style>
    <script type="text/javascript">

        var mtemplate_id = '<%=mtemplate_id %>';

        $(document).ready(function () {

            uploadiFive();

        });

        function ThisCLoseWindow() {
            window.close();
        }

        function uploadiFive() {
            $('#file_upload').uploadifive({
                'auto': true,
                //'checkScript'      : '/AjaxResponse/userHandler.ashx?type=checkExists',
                'formData': {
                    'timestamp': '<%=timestamp%>',
                    'token': '<%=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("unique_salt" + timestamp, "md5")%>'
                },
                'queueID': 'queue',
                'uploadScript': '/AjaxResponse/UploadFileHandler.ashx?type=UploadFile&postvalue=skins_' + mtemplate_id,
                'buttonText': '上传',
                'buttonClass': 'uploadBtn',
                'onSelect': function (queue) {
                    $("#queue").show();
                },
                'onUploadComplete': function (file, data) {
                    if (data.indexOf("仅支持") == -1) {
                        $("#mtemplate_thumbnail").attr("value", $("#ftp_upload_url").val() + data);
                        $("#queue").hide();
                        UpdateThumbnail();
                    }
                    else {
                        alert(data);
                    }
                }
            });
        }

        function UpdateThumbnail() {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_templateHandler.ashx?type=edit",
                data: $("#MyForm").serialize(),
                beforeSend: function (XMLHttpRequest, textStatus) {

                },
                success: function (data) {
                    var r = eval("(" + data + ")");
                    if (r.result == 'succ') {
                        ThisCLoseWindow();
                    } else { alert(r.msg); }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }
    </script>
</head>
<body>
    <form id="MyForm">
        <div style="margin: auto;">
            <input type="hidden" id="ftp_upload_url" value="<%=Common.ConfigHelper.GetConfigString("ftp_upload_url")%>" />
            <input type="hidden" name="mtemplate_id" value="<%=mtemplate_id%>" />
            <input type="hidden" name="mtype_id" value="<%=mtype_id%>" />
            <table>
                <tr>
                    <td>
                        <input id="mtemplate_thumbnail" name="mtemplate_thumbnail" type="text" value="<%=mtemplate_thumbnail %>" style="width: 500px; height: 28px; line-height: 28px; padding: 0; color: #111; font-size: 14px;" readonly="readonly" /></td>
                    <td>
                        <input id="file_upload" name="file_upload" type="file" style="width: 28px; height: 28px; line-height: 28px; color: #111; font-size: 14px;" /></td>
                </tr>
            </table>
            <div id="queue"></div>
            <%if (!string.IsNullOrWhiteSpace(mtemplate_thumbnail))
                {%>
            <table>
                <tr>
                    <td><img src="<%=mtemplate_thumbnail %>" /></td>
                </tr>
            </table>
            <%} %>
        </div>
    </form>
</body>
</html>
