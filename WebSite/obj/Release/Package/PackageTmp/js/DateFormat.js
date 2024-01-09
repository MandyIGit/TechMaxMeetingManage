Date.prototype.format = function (format) {
    if (isNaN(this)) return '';
    var o = {
        'm+': this.getMonth() + 1,
        'd+': this.getDate(),
        'h+': this.getHours(),
        'n+': this.getMinutes(),
        's+': this.getSeconds(),
        'S': this.getMilliseconds(),
        'W': ["日", "一", "二", "三", "四", "五", "六"][this.getDay()],
        'q+': Math.floor((this.getMonth() + 3) / 3)
    };
    if (format.indexOf('am/pm') >= 0) {
        format = format.replace('am/pm', (o['h+'] >= 12) ? '下午' : '上午');
        if (o['h+'] >= 12) o['h+'] -= 12;
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}