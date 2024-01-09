<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="speaker_edit.aspx.cs" Inherits="MpConsoleWebSite.home.mobile_agenda.speaker_edit" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
    <title>修改个人基本信息</title>
    <link href="/style/user_edit.css" rel="stylesheet" type="text/css" />    

    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no, minimal-ui" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no, email=no" />
    <link href="/style/piccutstyle.css" rel="stylesheet" type="text/css" />

    <!--[if IE]>
    <script src="/js/piccut/html5shiv.min.js"></script>
    <![endif]-->

</head>
<body>
    
        <div class="divtable" id="user_edit_content">
            <input type="hidden" name="mid" value="<%=mid %>" />
            <input type="hidden" name="mtype_id" value="<%=mtype_id %>" />
            <input type="hidden" id="puid" name="puid" value="<%=puid %>" />
            <input type="hidden" id="img_urlpath" name="img_urlpath" value="<%=img_urlpath %>" />

            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th colspan="2" th="th">个人信息</th>
                </tr>
                <tr>
                    <th>
                        <span>*</span>姓氏
                    </th>
                    <th>
                        <span>*</span>名字
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="family_name" name="family_name" value="<%=family_name %>" />
                    </td>
                    <td>
                        <input type="text" id="given_name" name="given_name" value="<%=given_name %>" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>姓氏拼音
                    </th>
                    <th>
                        <span>*</span>名字拼音
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="family_name_pinyin" name="family_name_pinyin" value="<%=family_name_pinyin %>" />
                    </td>
                    <td>
                        <input type="text" id="given_name_pinyin" name="given_name_pinyin" value="<%=given_name_pinyin %>" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>手机号码
                    </th>
                    <th>
                        <span>*</span>电子邮箱
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="mobile" name="mobile" value="<%=mobile %>" />
                    </td>
                    <td>
                        <input type="text" id="email" name="email" value="<%=email %>" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2"><span>*</span>学会职称（多职称请用“|”单竖线隔开）</th>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="text" id="learnpost" name="learnpost" value="<%=learnpost %>" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2">
                        <span>*</span>工作单位
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="text" id="unit" name="unit" value="<%=unit %>" />
                    </td>
                </tr>
            
                <tr>
                    <th>
                        <span>*</span>头像
                    </th>
                    <th>
                        <span>*</span>个人简历
                    </th>
                </tr>
                <tr>
                    <td>
                        <section class="logo-license">
                            <div class="half">
	                            <a class="logo" id="logox">
		                            <img id="bgl" src="<%=img_urlpath %>" />
	                            </a>
                                <p>点击上传</p>
                            </div>
                            <div class="clear"></div>
                        </section>
                    </td>
                    <td>
                        <textarea id="penintro" name="penintro"><%=penintro %></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <input type="button" id="save_edit" value="保  存" class="true" />
                    </td>
                </tr>
            </table>

            <article class="htmleaf-container">                
                <div id="clipArea"></div>
                <div class="foot-use">
	                <div class="uploader1 blue">
		                <input type="button" name="file" class="button" value="打开">
		                <input id="file" type="file" onchange="javascript:setImagePreview();" accept="image/*" multiple  />
	                </div>
	                <button id="clipBtn">截取</button>   
                    <button id="closeBtn" style="float:right;height:100%;width:8rem;background:#18b4ed;border:0;outline:none;color:#fff;font-size:2rem;z-index:999;">关闭</button>
                </div>
                <div id="view"></div>                  
            </article>

        </div>

    
    <div id="waiting_div" style="display:none; margin:0px auto; padding:0px; text-align:center;">
        <img src="/image/waiting_03.gif" alt="" style="margin-top: 210px; width: 50px; height: auto;" />
    </div>

    <script src="/js/piccut/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/artDialog.js?skin=black"></script>
    <script type="text/javascript" src="/js/artDialog.source.js"></script>
    <script type="text/javascript" src="/js/iframeTools.source.js"></script>
    <script type="text/javascript" src="/js/techmaxJS.js" charset="gb2312"></script>
    <script type="text/javascript" src="/js/speaker_edit.js"></script>
    <script>window.jQuery || document.write('<script src="/js/piccut/jquery-2.1.1.min.js"><\/script>')</script>
    <script src="/js/piccut/iscroll-zoom.js"></script>
    <script src="/js/piccut/hammer.js"></script>
    <script src="/js/piccut/jquery.photoClip.js"></script>

    <script type="text/javascript">
        var obUrl = ''
        //document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
        $("#clipArea").photoClip({
            width: 200,
            height: 200,
            file: "#file",
            view: "#view",
            ok: "#clipBtn",
            loadStart: function () {
                console.log("照片读取中");
            },
            loadComplete: function () {
                console.log("照片读取完成");
            },
            clipFinish: function (dataURL) {
                console.log(dataURL);
            }
        });

        $(function () {
            $("#logox").click(function () {
                $(".htmleaf-container").show();
            })
            $("#clipBtn").click(function () {
                $("#logox").empty();
                $('#logox').append('<img src="' + imgsource + '" align="absmiddle" style="width:8rem; height:8rem;">');
                $(".htmleaf-container").hide();
                $("#img_urlpath").val(imgsource);
            })
            $("#closeBtn").click(function () {
                $(".htmleaf-container").hide();
            })
        });

        $(function () {
            jQuery.divselect = function (divselectid, inputselectid) {
                var inputselect = $(inputselectid);
                $(divselectid + " small").click(function () {
                    $("#divselect ul").toggle();
                    $(".mask").show();
                });
                $(divselectid + " ul li a").click(function () {
                    var txt = $(this).text();
                    $(divselectid + " small").html(txt);
                    var value = $(this).attr("selectid");
                    inputselect.val(value);
                    $(divselectid + " ul").hide();
                    $(".mask").hide();
                    $("#divselect small").css("color", "#333")
                });
            };
            $.divselect("#divselect", "#inputselect");
        });

        $(function () {
            jQuery.divselectx = function (divselectxid, inputselectxid) {
                var inputselectx = $(inputselectxid);
                $(divselectxid + " small").click(function () {
                    $("#divselectx ul").toggle();
                    $(".mask").show();
                });
                $(divselectxid + " ul li a").click(function () {
                    var txt = $(this).text();
                    $(divselectxid + " small").html(txt);
                    var value = $(this).attr("selectidx");
                    inputselectx.val(value);
                    $(divselectxid + " ul").hide();
                    $(".mask").hide();
                    $("#divselectx small").css("color", "#333")
                });
            };
            $.divselectx("#divselectx", "#inputselectx");
        });

        $(function () {
            jQuery.divselecty = function (divselectyid, inputselectyid) {
                var inputselecty = $(inputselectyid);
                $(divselectyid + " small").click(function () {
                    $("#divselecty ul").toggle();
                    $(".mask").show();
                });
                $(divselectyid + " ul li a").click(function () {
                    var txt = $(this).text();
                    $(divselectyid + " small").html(txt);
                    var value = $(this).attr("selectyid");
                    inputselecty.val(value);
                    $(divselectyid + " ul").hide();
                    $(".mask").hide();
                    $("#divselecty small").css("color", "#333")
                });
            };
            $.divselecty("#divselecty", "#inputselecty");
        });

        $(function () {
            $(".mask").click(function () {
                $(".mask").hide();
                $(".all").hide();
            })
            $(".right input").blur(function () {
                if ($.trim($(this).val()) == '') {
                    $(this).addClass("place").html();
                }
                else {
                    $(this).removeClass("place");
                }
            })
        });

        $("#file0").change(function () {
            var objUrl = getObjectURL(this.files[0]);
            obUrl = objUrl;
            console.log("objUrl = " + objUrl);
            if (objUrl) {
                $("#img0").attr("src", objUrl).show();
            }
            else {
                $("#img0").hide();
            }
        });
        function qd() {
            var objUrl = getObjectURL(this.files[0]);
            obUrl = objUrl;
            console.log("objUrl = " + objUrl);
            if (objUrl) {
                $("#img0").attr("src", objUrl).show();
            }
            else {
                $("#img0").hide();
            }
        }
        function getObjectURL(file) {
            var url = null;
            if (window.createObjectURL != undefined) { // basic
                url = window.createObjectURL(file);
            } else if (window.URL != undefined) { // mozilla(firefox)
                url = window.URL.createObjectURL(file);
            } else if (window.webkitURL != undefined) { // webkit or chrome
                url = window.webkitURL.createObjectURL(file);
            }
            return url;
        }

        function setImagePreview() {
            var preview, img_txt, localImag, file_head = document.getElementById("file_head"),
                picture = file_head.value;
            if (!picture.match(/.jpg|.gif|.png|.bmp/i)) return alert("您上传的图片格式不正确，请重新选择！"),
                !1;
            if (preview = document.getElementById("preview"), file_head.files && file_head.files[0]) preview.style.display = "block",
                preview.style.width = "63px",
                preview.style.height = "63px",
                preview.src = window.navigator.userAgent.indexOf("Chrome") >= 1 || window.navigator.userAgent.indexOf("Safari") >= 1 ? window.webkitURL.createObjectURL(file_head.files[0]) : window.URL.createObjectURL(file_head.files[0]);
            else {
                file_head.select(),
                    file_head.blur(),
                    img_txt = document.selection.createRange().text,
                    localImag = document.getElementById("localImag"),
                    localImag.style.width = "63px",
                    localImag.style.height = "63px";
                try {
                    localImag.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)",
                        localImag.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = img_txt
                } catch (f) {
                    return alert("您上传的图片格式不正确，请重新选择！"),
                        !1
                }
                preview.style.display = "none",
                    document.selection.empty()
            }
            return document.getElementById("DivUp").style.display = "block",
                !0
        }
    </script>
</body>
</html>

