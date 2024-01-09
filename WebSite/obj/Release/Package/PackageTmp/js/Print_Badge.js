var timer;
var myDialog;
var f_type = "方正宋黑简体";
var f_size = 90; //字体大小
//外宾个人用户打印胸卡
//code:用户ID  1106
//given_name:名字
//family_name:姓氏
//country:国籍（英文）
//type_name:注册类型
function name_strong(zhi, shu, fonty, fontcuxi) {  //100的字体 加粗（700）位置
    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"widthli\" style=\"font-family:" + fonty + "; padding:0px; margin:0px; font-weight:" + fontcuxi + "; font-size:" + shu + "px; float:left;\">" + zhi + "</div></div>");
    var zong_px = 800;
    var font_px = parseInt(document.getElementById("widthli").offsetWidth);
    var ce_x = (zong_px - font_px) / 2 + 30;
    if (ce_x < 30) {
        alert("数据过长！打印可能会出错！！！");
        return 0;
    } else {
        $("#width").html("");
        $("#div_one").remove();
        return ce_x-10;
    }

}

function name_nostrong(zhi, shu, fonty, fontcuxi) {
    $(document.body).append("<div id=\"div_one\" style=\"visibility:; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"widthli\" style=\"font-family:" + fonty + "; padding:0px; margin:0px; font-weight:" + fontcuxi + "; font-size:" + shu + "px; float:left;\">" + zhi + "</div></div>");
    var zong_px = 800;
    var font_px = parseInt(document.getElementById("widthli").offsetWidth);
    var ce_x = (zong_px - font_px) / 2 + 30;
    if (ce_x < 30) {
        alert("数据过长！打印可能会出错！！！");
        return 0;
    } else {
        $("#width").html("");
        $("#div_one").remove();
        return ce_x-5;
    }
}

function OpationWord(word, size) {
    var c_word = "";
    if (name_strong(word, size) <= 0) {
        var will = word.split(' ');
        for (var i = 0; i < will.length; i++) {
            if (i == 0) {
                c_word += will[i].substring(0, 1).toUpperCase() + will[i].substring(1).toLowerCase() + " ";
            }
            else if (i == will.length + 1) {
                c_word += will[i].substring(0, 1) + ".";
            }
            else {
                c_word += will[i].substring(0, 1) + ". ";
            }
        }
    }
    else {
        var will = word.split(' ');
        for (var i = 0; i < will.length; i++) {
            if (i == will.length + 1) {
                c_word += will[i].substring(0, 1).toUpperCase() + will[i].substring(1).toLowerCase();
            }
            else {
                c_word += will[i].substring(0, 1).toUpperCase() + will[i].substring(1).toLowerCase() + " ";
            }
        }
    }
    return c_word;
}

function print_badge_en(id, xing, ming, guoji, model) {
    var a = xing.trim();
    var b = ming.trim();
    var jiahe = a + " " + b;
    var f_type = "Arno Pro"; //字体 (Arno Pro)
    var size_one = 100;
    var size_two = 100;
    var size_three = 80;

    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);



    $("#width").html("");
    $("#div_one").remove();

    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:" + f_type + "; padding:0px; margin:0px; font-weight:700; font-size:" + size_one + "pt; float:left;\">" + jiahe + "</div></div>");
    var font_px = parseInt(document.getElementById("width").offsetWidth);
    $("#width").html("");
    $("#div_one").remove();
    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:" + f_type + "; padding:0px; margin:0px; font-weight:700; font-size:" + size_two + "pt; float:left;\">" + jiahe + "</div></div>");
    var font_px_two = parseInt(document.getElementById("width").offsetWidth);
    $("#width").html("");
    $("#div_one").remove();
    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:" + f_type + "; padding:0px; margin:0px; font-weight:700; font-size:" + size_three + "pt; float:left;\">" + jiahe + "</div></div>");
    var font_px_three = parseInt(document.getElementById("width").offsetWidth);
    $("#width").html("");
    $("#div_one").remove();

    //ArgoxWebPrint.B_Prn_Text_TrueType(620, 450, 50, "Microsoft Yahei", 3, 500, 0, 0, 0, "AB", id);  //打印编号
    alert(font_px);
    alert(font_px_two);
    alert(font_px_three);
    //alert(name_strong(OpationWord(a,size_two),size_two));
    if (font_px < 830 && font_px_two < 830 && font_px_three < 830) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(jiahe, size_one), size_one, f_type,700), 390, size_one, f_type, 3, 700, 0, 0, 0, "AC", OpationWord(jiahe, size_one));
        if (model == "Faculty") {
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(guoji, 40), 50,f_type,400), 210, 60, f_type, 3, 400, 0, 0, 0, "AD", OpationWord(guoji, 40));
        }
        else {
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(guoji, 40), 50,f_type,400), 235, 60, f_type, 3, 400, 0, 0, 0, "AD", OpationWord(guoji, 40));
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(model, 60), 60,f_type,400), 160, 60, f_type, 3, 400, 0, 0, 0, "AE", OpationWord(model, 60));
        }

    } else {
        if (model == "Faculty") {
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(a, size_two), size_two, f_type,700)+20, 460, size_two, f_type, 3, 700, 0, 0, 0, "AC", OpationWord(a, size_two));
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(b, size_two), size_two, f_type, 700)+20, 370, size_two, f_type, 3, 700, 0, 0, 0, "AD", OpationWord(b, size_two));
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(guoji, 50), 50) - 40, 200, 60, f_type, 3, 400, 0, 0, 0, "AE", OpationWord(guoji, 50));
        }
        else {
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(a, size_two), size_two, f_type, 700)-20, 440, size_two, f_type, 3, 700, 0, 0, 0, "AC", OpationWord(a, size_two));
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(b, size_two), size_two, f_type, 700)+10, 320, size_two, f_type, 3, 700, 0, 0, 0, "AD", OpationWord(b, size_two));
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(guoji, 50), 50) - 40, 215, 60, f_type, 3, 400, 0, 0, 0, "AE", OpationWord(guoji, 50));
            //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(model, 60), 60) - 20, 160, 60, f_type, 3, 400, 0, 0, 0, "AF", OpationWord(model, 60));
        }
    }
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
    //    var f_type = "Arno Pro"; //字体
    //    var size_one = [80,60,60];
    //    var font_y = [460,380,300,240,180];
    //    ArgoxWebPrint.B_EnumUSB();
    //    ArgoxWebPrint.B_CreateUSBPort(1);
    //    ArgoxWebPrint.B_Prn_Text_TrueType(650, font_y[0], 50,f_type, 3, 400, 0, 0, 0, "AB",a);
    //    var given_x = 0;
    //    if(name_strong(OpationWord(c,size_one[0]),size_one[0])-30<=10){
    //        given_x = 10;
    //    }else{
    //        given_x = name_strong(OpationWord(c,size_one[0]),size_one[0])-10;
    //    }
    //    var family_x = 0;
    //    if(name_strong(OpationWord(d,size_one[0]),size_one[0])-30<=10){
    //        family_x = 10;
    //    }
    //    else{
    //        family_x = name_strong(OpationWord(d,size_one[0]),size_one[0])-10;
    //    }
    //    if(f=="Faculty"){
    //        ArgoxWebPrint.B_Prn_Text_TrueType(given_x, 360, size_one[0],f_type, 3, 700, 0, 0, 0, "AC",OpationWord(c,size_one[0]));
    //	    ArgoxWebPrint.B_Prn_Text_TrueType(family_x, 260, size_one[0],f_type, 3, 700, 0, 0, 0, "AD",OpationWord(d,size_one[0]));
    //	    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e,size_one[1]),size_one[1])-20, 180, size_one[1],f_type, 3, 400, 0, 0, 0, "AE",OpationWord(e,size_one[1]));
    //    }
    //    else{
    //        ArgoxWebPrint.B_Prn_Text_TrueType(given_x, font_y[1], size_one[0],f_type, 3, 700, 0, 0, 0, "AC",OpationWord(c,size_one[0]));
    //	    ArgoxWebPrint.B_Prn_Text_TrueType(family_x, font_y[2], size_one[0],f_type, 3, 700, 0, 0, 0, "AD",OpationWord(d,size_one[0]));
    //	    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e,size_one[1]),size_one[1])-20, font_y[3], size_one[1],f_type, 3, 400, 0, 0, 0, "AE",OpationWord(e,size_one[1]));
    //	    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(f,size_one[2]),size_one[2])-20, font_y[4], size_one[2],f_type, 3, 400, 0, 0, 0, "AF",OpationWord(f,size_one[2]));
    //    }
    //	ArgoxWebPrint.B_Print_Out(1);
    //    ArgoxWebPrint.B_ClosePrn();
}

//中宾胸卡
//a: ID号
//c: 姓名
//d: 拼音
//e: 省份
//f: 类型
//(大数向左, 大数向上, 字体大小,字体, 横向打字, 字体粗细, 0, 0, 0, "AC",""+打印+"")
function print_badge_ch(a, c) {
    var f_type = "方正宋黑简体"; //字体
    var f_type_en = "Arno Pro";  //"Microsoft YaHei"; //字体
    var size_one = [80, 90];
    var font_y = [180, 80];  

    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    //ArgoxWebPrint.B_Prn_Text_TrueType(580, font_y[0], 50, "Microsoft Yahei", 3, 500, 0, 0, 0, "AB", a);

    ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(a, size_one[1]), size_one[1], f_type, 400) - 30, font_y[0], size_one[1], f_type, 3, 400, 0, 0, 0, "AE", OpationWord(a, size_one[1]));

    if (c.length == 2) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700)-30, font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c.substring(0, 1) + " " + c.substring(1));
    }
    else if (c.length == 3) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 4) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 5) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 6) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 7) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 8) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    } else {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[3], f_type, 700)+20, font_y[1], size_one[3], f_type, 3, 700, 0, 0, 0, "AC", c);
    }

    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

//工作人员胸卡打印
function print_badge_staff(c, b, d, f) {
    var f_type = "方正宋黑简体"; //字体  (宋体)
    var f_type_en = "Arno Pro"; //字体
    var size_one = [110, 60, 40, 40];
    var font_y = [540, 350, 270, 280, 210];
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    //ArgoxWebPrint.B_Prn_Text_TrueType(650, font_y[0], 50,"Microsoft Yahei", 3, 500, 0, 0, 0, "AB",a);
    if (c.length == 2) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c.substring(0, 1) + " " + c.substring(1));
    }
    else if (c.length == 3) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 4) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 5) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 6) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 7) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    else if (c.length == 8) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(c, size_one[0], f_type, 700), font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", c);
    }
    //ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(d, size_one[1]), size_one[1]) + 10, font_y[2], size_one[1], f_type_en, 3, 400, 0, 0, 0, "AD", OpationWord(d, size_one[1]));
                                                    //name_nostrong(zhi, shu, fonty, fontcuxi)
    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(d, size_one[1]), size_one[1], f_type_en, 400)-30, font_y[2], size_one[1], f_type_en, 3, 200, 0, 0, 0, "AD", OpationWord(d, size_one[1]));
    //ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e,size_one[2]),size_one[2])-30, font_y[3], size_one[2],f_type, 3, 400, 0, 0, 0, "AE",OpationWord(e,size_one[2]));
//    if (f == "") {
//        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(b, size_one[3]), size_one[3]) - 20, font_y[4], size_one[3], f_type_en, 3, 400, 0, 0, 0, "AF", OpationWord(b, size_one[3]));
//    }
//    else {
//        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(b + "(" + f + ")", size_one[3]), size_one[3]), font_y[4], size_one[3], f_type_en, 3, 400, 0, 0, 0, "AF", OpationWord(b + "(" + f + ")", size_one[3]));
//    }
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

function print_badge_media(a, b, c) {
    var f_type = "宋体"; //字体
    var f_type_en = "Arno Pro"; //字体
    var size_one = [100, 80];
    var font_y = [300, 160];
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(180, font_y[0], size_one[0], f_type, 3, 700, 0, 0, 0, "AD", OpationWord(a, size_one[0]));
    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(b, size_one[1]), size_one[1]) - 50, font_y[1], size_one[1], f_type_en, 3, 400, 0, 0, 0, "AF", OpationWord(b, size_one[1]));
    ArgoxWebPrint.B_Print_Out(parseInt(c));
    ArgoxWebPrint.B_ClosePrn();
}

//快速打印胸卡（中宾）
function print_badge_ch_fast(c, d, e, f) {
    var f_type = "宋体"; //字体
    var f_type_en = "Arno Pro"; //字体
    var size_one = [100, 50, 40, 40];
    var font_y = [460, 340, 260, 180, 120];
    if (f == "Faculty") {
        font_y = [460, 320, 240, 160];
    }
    else {
        font_y = [460, 340, 260, 180, 120];
    }
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    //ArgoxWebPrint.B_Prn_Text_TrueType(650, font_y[0], 50,"Microsoft Yahei", 3, 500, 0, 0, 0, "AB",a);
    if (c.length == 2) {
        ArgoxWebPrint.B_Prn_Text_TrueType(280, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c.substring(0, 1) + " " + c.substring(1));
    }
    else if (c.length == 3) {
        ArgoxWebPrint.B_Prn_Text_TrueType(260, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    else if (c.length == 4) {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    else if (c.length == 5) {
        ArgoxWebPrint.B_Prn_Text_TrueType(160, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    else if (c.length == 6) {
        ArgoxWebPrint.B_Prn_Text_TrueType(110, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    else if (c.length == 7) {
        ArgoxWebPrint.B_Prn_Text_TrueType(60, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    else if (c.length == 8) {
        ArgoxWebPrint.B_Prn_Text_TrueType(5, font_y[1], size_one[0], f_type, 3, 400, 0, 0, 0, "AC", c);
    }
    ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(d, size_one[1]), size_one[1]), font_y[2], size_one[1], f_type_en, 3, 400, 0, 0, 0, "AD", OpationWord(d, size_one[1]));
    ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e, size_one[2]), size_one[2]) - 30, font_y[3], size_one[2], f_type, 3, 400, 0, 0, 0, "AE", OpationWord(e, size_one[2]));
    if (f != "Faculty") {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(f, size_one[3]), size_one[3]) - 10, font_y[4], size_one[3], f_type_en, 3, 400, 0, 0, 0, "AF", OpationWord(f, size_one[3]));
    }
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

//快速打印胸卡（外宾）
function print_badge_en_fast(c, d, e, f) {
    var f_type = "Arno Pro"; //字体
    var size_one = [80, 60, 60];
    var font_y = [460, 380, 300, 240, 180];
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    if (f == "Faculty") {
        var given_x = 0;
        if (name_strong(OpationWord(c, size_one[0]), size_one[0]) - 30 <= 10) {
            given_x = 10;
        } else {
            given_x = name_strong(OpationWord(c, size_one[0]), size_one[0]) - 30;
        }
        var family_x = 0;
        if (name_strong(OpationWord(d, size_one[0]), size_one[0]) - 30 <= 10) {
            family_x = 10;
        }
        else {
            family_x = name_strong(OpationWord(d, size_one[0]), size_one[0]) - 30;
        }
        ArgoxWebPrint.B_Prn_Text_TrueType(given_x, 360, size_one[0], f_type, 3, 700, 0, 0, 0, "AC", OpationWord(c, size_one[0]));
        ArgoxWebPrint.B_Prn_Text_TrueType(family_x, 260, size_one[0], f_type, 3, 700, 0, 0, 0, "AD", OpationWord(d, size_one[0]));
        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e, size_one[1]), size_one[1]) - 20, 180, size_one[1], f_type, 3, 400, 0, 0, 0, "AE", OpationWord(e, size_one[1]));
    }
    else {
        var given_x = 0;
        if (name_strong(OpationWord(c, size_one[0]), size_one[0]) - 30 <= 10) {
            given_x = 10;
        } else {
            given_x = name_strong(OpationWord(c, size_one[0]), size_one[0]) - 30;
        }
        var family_x = 0;
        if (name_strong(OpationWord(d, size_one[0]), size_one[0]) - 30 <= 10) {
            family_x = 10;
        }
        else {
            family_x = name_strong(OpationWord(d, size_one[0]), size_one[0]) - 30;
        }
        ArgoxWebPrint.B_Prn_Text_TrueType(given_x, font_y[1], size_one[0], f_type, 3, 700, 0, 0, 0, "AC", OpationWord(c, size_one[0]));
        ArgoxWebPrint.B_Prn_Text_TrueType(family_x, font_y[2], size_one[0], f_type, 3, 700, 0, 0, 0, "AD", OpationWord(d, size_one[0]));
        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(e, size_one[1]), size_one[1]) - 20, font_y[3], size_one[1], f_type, 3, 400, 0, 0, 0, "AE", OpationWord(e, size_one[1]));
        ArgoxWebPrint.B_Prn_Text_TrueType(name_nostrong(OpationWord(f, size_one[2]), size_one[2]) - 20, font_y[4], size_one[2], f_type, 3, 400, 0, 0, 0, "AF", OpationWord(f, size_one[2]));
    }
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

function ZhanShang(a, b, c) {              //中文赞助商
    var f_type = "宋体";
    var size_one = 60;
    var char_zi, zi_one, zi_two, zi_four, zi_three;
    var print_num = parseInt(c);
    if (c == "") {
        print_num = 1;
    }
    //1030指纸的pt宽度
    //730 x轴一个字从右面到左面的距离

    // (大数向左, 大数向上, 字体大小,字体, 横向打字, 字体粗细, 0, 0, 0, "AC",""+打印+"")
    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + a + "</div></div>");
    var font_px = parseInt(document.getElementById("width").offsetWidth);

    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(650, 440, 50, "Microsoft Yahei", 3, 500, 0, 0, 0, "AB", b);
    //if(a.length*size_one <730){
    if (font_px < 1030) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(a, size_one), size_one) - 40, 270, size_one, f_type, 3, 400, 0, 0, 0, "AC", a);
        ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AD", 'Exhibitor');

    } else {
        char_zi = parseInt((a.length * size_one - 730) / size_one) + 1;
        $("#width").html("");
        $("#div_one").remove();
        zi_two = a.substring(a.length - char_zi, a.length);
        $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + zi_two + "</div></div>");
        var font_px = parseInt(document.getElementById("width").offsetWidth);

        if (font_px < 1030) {
            zi_one = a.substring(0, a.length - char_zi);
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(zi_one, size_one), size_one) - 40, 320, size_one, f_type, 3, 400, 0, 0, 0, "AC", zi_one);
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(zi_two, size_one), size_one) - 10, 230, size_one, f_type, 3, 400, 0, 0, 0, "AD", zi_two);
            ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AE", 'Exhibitor');

        } else {
            zi_three = parseInt((char_zi * size_one - 730) / size_one) + 1;
            $("#width").html("");
            $("#div_one").remove();
            zi_four = a.substring(a.length - zi_three, a.length);
            $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + zi_four + "</div></div>");
            var font_px = parseInt(document.getElementById("width").offsetWidth);

            if (font_px < 1030) {

                zi_one = a.substring(0, a.length - char_zi);
                zi_two = a.substring(a.length - char_zi, a.length - zi_three);
                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(zi_one, size_one), size_one) - 40, 330, size_one, f_type, 3, 400, 0, 0, 0, "AC", zi_one);
                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(zi_two, size_one), size_one) - 40, 260, size_one, f_type, 3, 400, 0, 0, 0, "AD", zi_two);
                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(zi_four, size_one), size_one) - 20, 190, size_one, f_type, 3, 400, 0, 0, 0, "AE", zi_four);
                ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AF", 'Exhibitor');
            } else {
                alert("错误！！！");
                return;
            }
        }
    }
    ArgoxWebPrint.B_Print_Out(print_num);
    ArgoxWebPrint.B_ClosePrn();
    $("#width").html("");
    $("#div_one").remove();
}
function ZhanShangEn(a, b, c) {         //英文赞助商
    var b = a.trim();
    var f_type = "Arno Pro";
    var size_one = 80;
    var width_en = 0;
    var one, two, three;
    var str = new Array();
    var str_one = new Array();
    var str_two = new Array();
    var str_three = new Array();
    var str_four = new Array();
    var print_num = parseInt(c);
    if (c == "") {
        print_num = 1;
    }
    $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + b + "</div></div>");
    var font_px = parseInt(document.getElementById("width").offsetWidth);

    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(650, 440, 50, "Microsoft Yahei", 3, 500, 0, 0, 0, "AB", b);  //打印编号

    if (font_px < 1030) {
        ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(a, size_one), size_one), 270, size_one, f_type, 3, 700, 0, 0, 0, "AC", b);
        ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AD", 'Exhibitor');
    } else {
        str = b.split(" ");
        for (var i = 0; i < str.length; i++) {

            $("#width").html("");
            $("#div_one").remove();

            $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + str[i] + "</div></div>");
            var font_px = parseInt(document.getElementById("width").offsetWidth);
            width_en += font_px;
            if (width_en <= 1030) {
                str_one.push(str[i]);
            } else {
                str_two.push(str[i])
            }

        }
        var print_one = str_one.join(" ");
        var print_two = str_two.join(" ");

        $("#width").html("");
        $("#div_one").remove();

        $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + print_two + "</div></div>");
        var font_px = parseInt(document.getElementById("width").offsetWidth);

        if (font_px < 1030) {

            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(print_one, size_one), size_one), 320, size_one, f_type, 3, 700, 0, 0, 0, "AC", OpationWord(print_one, size_one));
            ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(print_two, size_one), size_one), 230, size_one, f_type, 3, 700, 0, 0, 0, "AD", OpationWord(print_two, size_one));
            ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AE", 'Exhibitor');

        } else {
            width_en = 0;
            str = print_two.split(" ");
            for (var i = 0; i < str.length; i++) {

                $("#width").html("");
                $("#div_one").remove();

                $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + str[i] + "</div></div>");
                var font_px = parseInt(document.getElementById("width").offsetWidth);
                width_en += font_px;

                if (width_en <= 1030) {
                    str_four.push(str[i]);
                } else {
                    str_three.push(str[i])
                }
            }
            var print_two = str_four.join(" ");
            var print_three = str_three.join(" ");
            $("#width").html("");
            $("#div_one").remove();

            $(document.body).append("<div id=\"div_one\" style=\"visibility:hidden; overflow:hidden; position:absolute; z-index:10; left:0px; bottom:0px;\"><div id=\"width\" style=\"font-family:Arno Pro; padding:0px; margin:0px; font-weight:bold; font-size:" + size_one + "pt; float:left;\">" + print_three + "</div></div>");
            var font_px = parseInt(document.getElementById("width").offsetWidth);

            if (font_px <= 1030) {

                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(print_one, size_one), size_one), 340, size_one, f_type, 3, 700, 0, 0, 0, "AC", OpationWord(print_one, size_one));
                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(print_two, size_one), size_one), 260, size_one, f_type, 3, 700, 0, 0, 0, "AD", OpationWord(print_two, size_one));
                ArgoxWebPrint.B_Prn_Text_TrueType(name_strong(OpationWord(print_three, size_one), size_one), 180, size_one, f_type, 3, 700, 0, 0, 0, "AE", OpationWord(print_three, size_one));
                ArgoxWebPrint.B_Prn_Text_TrueType(315, 110, 60, 'Arno Pro', 3, 400, 0, 0, 0, "AF", 'Exhibitor');

            } else {
                alert("错误！");
                return;
            }


        }
    }

    ArgoxWebPrint.B_Print_Out(parseInt);
    ArgoxWebPrint.B_ClosePrn();

    $("#width").html("");
    $("#div_one").remove();

}