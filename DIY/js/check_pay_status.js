function CheckPayStatus(){
    $.ajax({
        type: "post",
        url: "/AjaxResponse/tv_orderHandler.ashx?type=9&postvalue="+escape($("#order_id").val()),
        complete: function () {

        },
        success: function (str) {
            if (str == "2") {
                window.parent.location.href="/web/user/user_paylist.aspx";
                CloseLayer();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert('������������ϵ�ͷ���'); }
    });
}

setInterval(function(){CheckPayStatus();}, 1500);
