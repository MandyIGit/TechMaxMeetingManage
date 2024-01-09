function CheckEnterKey(evt) { if (evt.keyCode == 13) { $("#save_edit").click(); } }

$(document).ready(function () {

    //同步显示姓氏拼音
    $("#family_name").bind("blur", function () {
        if ($("#family_name").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的姓氏！");
        }
        else {
            var word = $("#family_name").val();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/meeting_user_pptHandler.ashx?type=1&postvalue=" + escape(word),
                success: function (data) {
                    $("#family_name_pinyin").val(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }
    });

    //同步显示名字拼音
    $("#given_name").bind("blur", function () {
        if ($("#given_name").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的名字！");
        }
        else {
            var word = $("#given_name").val();
            $.ajax({
                type: "post",
                url: "/AjaxResponse/meeting_user_pptHandler.ashx?type=1&postvalue=" + escape(word),                
                success: function (data) {
                    $("#given_name_pinyin").val(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { },
                complete: function (XMLHttpRequest, textStatus) { }
            });
        }
    });

    //保存修改信息
    $("#save_edit").bind("click", function () {

        /*alert($("#penintro").val());*/

        
        if ($("#family_name").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的姓氏！");
        }
        else if ($("#given_name").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的名字！");
        }
        else if ($("#family_name_pinyin").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的姓氏拼音！");
        }
        else if ($("#given_name_pinyin").val().replace(/(^\s*)|(\s*$)/g, "") == "") {
            alert("请输入您的名字拼音！");
        }
        else {
            $.ajax({
                type: "post",
                url: "/AjaxResponse/meeting_user_pptHandler.ashx?type=SaveUser_edit_msg&postvalue=" + escape($("#puid").val()),
                data: {
                    "img_urlpath": $("#img_urlpath").val(),
                    "family_name": $("#family_name").val(),
                    "given_name": $("#given_name").val(),
                    "family_name_pinyin": $("#family_name_pinyin").val(),
                    "given_name_pinyin": $("#given_name_pinyin").val(),
                    "mobile": $("#mobile").val(),
                    "email": $("#email").val(),
                    "learnpost": $("#learnpost").val(),
                    "unit": $("#unit").val(),
                    "penintro": $("#penintro").val()
                },
                beforeSend: function () {
                    $("#user_edit_content").hide();
                    $("#waiting_div").show();
                },
                complete: function () {
                    $("#user_edit_content").show();
                    $("#waiting_div").hide();
                },
                success: function (str) {
                    if (str == "OK") {
                        dialogTimeClose('保存成功！', '', "yes");
                    }
                    else {
                        dialogTime("操作失败，请联系管理员！");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { }
            });
        }
    });

});