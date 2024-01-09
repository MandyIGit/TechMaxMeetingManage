<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_content_edit_bak.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_menu.menu_content_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>栏目内容管理</title>
    <link rel="stylesheet" type="text/css" href="/style/main.css" />
    <script type="text/javascript" src="/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="/js/admin_main.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="/kindeditor/plugins/code/prettify.js" type="text/javascript"></script>

    <script type="text/javascript">
        tinymce.init({
            selector: '#mc_msg',
            language: 'zh_CN',
            menubar: false,
            branding: false,
            width: 400,
            height: 1000,
            min_height: 1000,
            icons: 'custom',
            images_upload_url: '/tinymce/upload.ashx',
            fontsize_formats: "10px 11px 12px 13px 14px 15px 16px 18px 20px 24px 30px 36px",
            plugins: 'code advlist autolink link image lists preview searchreplace autolink directionality visualblocks visualchars fullscreen image link media template codesample table charmap pagebreak nonbreaking anchor insertdatetime advlist lists wordcount help emoticons autosave autoresize',
            toolbar: ['undo redo removeformat forecolor backcolor bold italic underline strikethrough link alignleft aligncenter alignright indent blockquote subscript superscript bullist numlist lineheight',
                'formatselect fontselect fontsizeselect',
                'table image media charmap emoticons hr pagebreak insertdatetime print preview fullscreen bdmap indent2em formatpainter axupimgs importword kityformula-editor code'],//anchor restoredraft | cut copy paste pastetext alignjustify outdent styleselect
            font_formats: '微软雅黑=Microsoft YaHei,Helvetica Neue,PingFang SC,sans-serif;苹果苹方=PingFang SC,Microsoft YaHei,sans-serif;宋体=simsun,serif;仿宋=FangSong,serif;黑体=SimHei,sans-serif;Arial=arial,helvetica,sans-serif;Arial Black=arial black,avant garde;Book Antiqua=book antiqua,palatino;Comic Sans MS=comic sans ms,sans-serif;Courier New=courier new,courier;Georgia=georgia,palatino;Helvetica=helvetica;Impact=impact,chicago;Symbol=symbol;Tahoma=tahoma,arial,helvetica,sans-serif;Terminal=terminal,monaco;Times New Roman=times new roman,times;Verdana=verdana,geneva;Webdings=webdings;Wingdings=wingdings,zapf dingbats;知乎配置=BlinkMacSystemFont, Helvetica Neue, PingFang SC, Microsoft YaHei, Source Han Sans SC, Noto Sans CJK SC, WenQuanYi Micro Hei, sans-serif;小米配置=Helvetica Neue,Helvetica,Arial,Microsoft Yahei,Hiragino Sans GB,Heiti SC,WenQuanYi Micro Hei,sans-serif',

            init_instance_callback: function (editor) {
                editor.on('SelectionChange', function (e) {
                    editor.save();
                    $('#preview').html(tinyMCE.activeEditor.getContent());
                    //console.log(tinyMCE.activeEditor.getContent());
                });
            }

        });

        var vmc_msg;
        //KindEditor.ready(function (K) {
        //    vmc_msg = CreateKindEditor("mc_msg", K, '846px', '400px');
        //    prettyPrint();
        //});
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
                    $("#mc_msg").val($("#divmc_msg").html());
                    tinyMCE.activeEditor.setContent($("#divmc_msg").html());
                    //vmc_msg.html($("#divmc_msg").html());
                    //$('#mc_msg').html($("#divmc_msg").html());

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
            //vmc_msg.sync();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/tech_mobile_menuHandler.ashx?type=ModifyContent",
                data: $("#myform").serialize(),
                success: function (data) {
                    if (data == "sur_ok") {
                        dialogTimeClose('操作成功！', 'javascript:history.back();', 'no');
                    }
                    else if (data == "sur_err") {
                        dialogTime('操作失败！', '');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    dialogTime('发生错误，请联系客服！', '');
                }
            });

        }
    </script>
</head>
<body>
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
            <div class="listtable">
                <div class="listmenu">
                    <a class="btnblue" onclick="history.back();" style="float: ;">返回</a> <a class="btnblue" onclick="DoPost()" style="float: ;">确认提交</a>
                    <div class="clear">
                    </div>
                </div>
                <div class="h10">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="h10">
        </div>
        <div class="web_muban">
            <div class="web_muban_border">
                <h3>添加内容</h3>
                <div style="width: 850px; margin: 15px;">
                    <div id="preview" style="width: 351px; height: 708px; background: url(/image/iphone-bg.png) no-repeat no-repeat; float: right; padding: 130px 30px 0 30px; margin: 0px;"></div>
                    <textarea id="mc_msg" name="mc_msg" rows="20" cols="200" style="width: 100%;"></textarea>
                </div>
            </div>
            <div class="h10"></div>
        </div>

        <div id="divcontent" style="display: none">
        </div>
    </form>
	<table>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</body>
</html>
