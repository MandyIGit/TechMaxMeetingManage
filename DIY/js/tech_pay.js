//@charset "gb2312";
function payRequest() {
    $.ajax({
        type: "post",
        url: "/AjaxResponse/Pay_Handler.ashx?type=2",
        data: $("#pay_form").serialize(),
        beforeSend: function (XMLHttpRequest, textStatus) {
        },
        success: function (data) {
            var objJSON = eval("(" + data + ")");
            dopay(objJSON);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(' 发生错误，请联系客服！ '); }
    });
}

function dopay(info) {
    if (info.status == '0') { alert(info.msg); window.location.href = '/web/user/user_index.aspx'; }
    if (info.status == '1') { showlogin(); }
    if (info.status == '2') { window.location.href = "/web/user/payment/payment.aspx?info=" + info.msg; }
}

function LoadTable() { }

function checkform() {
    $(".errorspan").html("");
    var result = true;
    if ($("input:radio[name='ctype']:checked").val() == null) {
        $("#errorspan").html("请选择套餐类型");
        return false;
    }
    if ($("input:radio[name='ptype']:checked").val() == null) {
        $("#errorspan").html("请选择支付类型");
        return false;
    }
    return result;
}

function showtip() {
    $('#form_pay').slideDown(200);
}
function hidetip() {
    $('#form_pay').slideUp(200);
}

function ChargeTip() {
    var $item = "<div id=\"form_pay\" class=\"theme-popover\" style=\" position: absolute; z-index: 9999; \">";
    $item += "<div class=\"theme-poptit\">";
    $item += " <a href=\"javascript:;\" title=\"关闭\" class=\"close\">×</a>";
    $item += "<h3>医视界</h3>";
    $item += "</div>";
    $item += "<div class=\"theme-popbod dform\">";
    $item += "<form class=\"theme-signin\" id=\"loginform\" name=\"loginform\">";
    $item += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"infotablel\">";
    $item += "<tr><td><div align=\"left\"><p style=\" font-weight:bold ; font-size:medium;\">请在新打开的页面上完成支付。</p> </div></td></tr>";
    $item += "<tr><td style=\"border: none;\">完成支付前请不要关闭此窗口!</td></tr>";
    $item += "<tr><td style=\"border: none;\">完成支付后请根据支付情况点击下面的按钮。</td></tr>";
    $item += "<tr><td style=\"border: none;\"><a class=\"ZhiFu_ok\" id=\"btnPaySuccess\" href=\"javascript:chargesucc()\">已完成支付</a> <a class=\"ZhiFu_no\" id=\"btnPayFaile\" href=\"javascript:void()\">遇到问题，重新付款</a></td></tr>";
    $item += "</table>"
    $item += "</form>";
    $item += "</div>";
    $item += "</div>";
    $("body").append($item);
}

function ActionWX(){
    $.ajax({
        type: "post",
        url: "/AjaxResponse/tv_orderHandler.ashx?type=8",
        data: $("#pay_form").serialize(),
        beforeSend: function () {
            
        },
        complete: function () {
            
        },
        success: function (str) {
            if(!isNaN(str)){ 
                //$("#pay_form").attr("action","/WXPay/pay_jump_url.aspx?o=" + escape(str));
                //$("#pay_form").submit(); 
                layer.open({
                    type: 2,
                    title: false,
                    maxmin: false,
                    fix: true,
                    shade: 0.7,
                    shadeClose: false, //点击遮罩关闭层
                    area: ['650px', '400px'],
                    skin: 'layui-layer-rim',
                    content: ['/WXPay/pay_jump_url.aspx?o=' + escape(str),'no']
                });
            }
            else if(str == "is_login"){ showlogin(); }
            else if(str == "is_ctype"){ alert("套餐类型出错"); window.location.href="/web/user/user_index.aspx"; }
            else if(str == "is_ptype"){ alert("支付类型出错"); window.location.href="/web/user/user_index.aspx"; }
            else if(str == "is_have"){ alert("您的套餐未使用完毕，暂无法充值"); window.location.href="/web/user/user_index.aspx"; }
            else if(str == "is_error"){ alert("系统错误"); window.location.href="/web/user/user_index.aspx"; }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(' 发生错误，请联系客服！ '); }
    });
}

$(document).ready(function () {
    ChargeTip();
    $('.theme-poptit .close').click(function () { hidetip(); })
    $('#btnPayFaile').click(function () { hidetip(); })
    $("#bt_ljfk").click(function () {
        if (checkform()) {
            if($("input:radio[name='ptype']:checked").val() == "1"){
                showtip();
                $("#pay_form").submit();
            }
            else if($("input:radio[name='ptype']:checked").val() == "4"){
                showtip();
                ActionWX();
            }
        }
    });
});