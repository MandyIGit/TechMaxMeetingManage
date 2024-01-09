//打开弹出层
//n：URL
//t：title
function OpenWindowUrl_Two(n, t, w, h) {
    window.parent.OpenWindowUrl(n, t, w, h);
}

function CloseWindwoUrl_Two() {
    window.parent.CloseTheWindow();
}

//定时弹出框,contents为弹出框内容,url为弹出框关闭后跳转的页面,如不需跳传就传空
var timer;
var myDialog; 
function airDialogOpenURL(title,url,width,height,zIndex)
{
//    myDialog = art.dialog({
//        title : ""+title+"",
//        top : "0%",
//        left : "0%",
//        lock : true,
//        drag : false,
//        resize : false,
//        esc : false,
//        zIndex : ""+zIndex+"",
//        content : '<iframe src="'+url+'" height="'+height+'" width="'+width+'" frameborder="0"></iframe>'
//    });
    myDialog = art.dialog.open(url, { 
        top : "10%",
        title: title, 
        width: width, 
        height: height, 
        lock: true,
        drag : false,
        closeFn: function () {
            location.reload();
        }
    });
}

function JackyCloseDialog()
{
    window.close();
}

//创建对象
function getID(id)
{
    return $("#"+id+"");
}
//ajax post方法,用来获取信息
function ajaxPost(url,type,postvalue,id)
{  
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
        if(id.length>0)
            getID(id).html(data);
    });
}
function ajaxPostJSON(url,type,postvalue,id)
{  
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
       var dataObj=eval("("+data+")");//转换为json对象
        $.each(dataObj.root, function(idx,item)
        {
            if(getID(item.name).length>0)
                getID(item.name).attr({'value':item.value});
        });
     });
}
function ajaxPostLoad(url,type,postvalue,id)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
        getID(id).html(data);
        htmlbox();
        htmlResult();
    });
}

function DialogOkClose(contents, url, isDialog) {
    var values = "<font size='2'>" + contents + "</font>"
    art.dialog({
        fixed: true,
        content: values,
        init: function () {
            var that = this, i = 0;
            var fn = function () {
                that.title(i);
                !i && that.close();
                i--;
            };
            timer = setInterval(fn, 1000);
            fn();
        },
        close: function () {
            clearInterval(timer);
            if (url.length > 0)
                top.location.href = url;
            if (isDialog == "yes") {
                art.dialog.close();
            }
        }
    });
}

//执行AJAX信息输出之后在执行其它方法
function ajaxPostFun(url,type,postvalue,id,funname)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
        getID(id).html(data);
        if(funname.length>0)
            eval(funname+"();");//回调
    });
}
function ajaxPostText(url,type,postvalue,id)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
       getID(id).val(data);
    });
}
 //全选
function getAll(chkname){
    var checkboxs=document.getElementsByName(chkname);
    for (var i=0;i<checkboxs.length;i++)
    {
        var e=checkboxs[i];
        e.checked=!e.checked;
    }
}
function htmlskip(linkname)
{
    getID("mainhtml").attr("src",linkname+".aspx");
}
//下接列表给文框赋值
function GetSel(txtname,selname)
{
        getID(txtname).attr({'value':''});
        getID(txtname).attr({'value':getID(selname).val()});
}
function GetSelMeeting(txtname,selname,txtdate)
{
        getID(txtname).attr({'value':''});
        getID(txtname).attr({'value':getID(selname).val()});
        if(getID(selname).val()=="2" || getID(selname).val()=="9999")
        {
            //getID(txtdate).attr({'disabled':'disabled'});
            getID(txtdate).attr({'readonly':'readonly'});
        }
        else if(getID(selname).val()=="1")
        {
            //getID(txtdate).removeAttr("disabled");
            getID(txtdate).removeAttr("readonly");
        }
}
function GetSelTemple(txtname,selname)
{
     if(getID(selname).val()!='9999')
     {
        getID(txtname).attr({'value':''});
        getID(txtname).attr({'value':getID(selname).val()});
     }
     else
     {
        getID(txtname).attr({'value':''});
     }
}
 //获取页面参数
     function GetRequest() {

    var url = location.search; //获取url中"?"符后的字串

    var theRequest = new Object();

    if (url.indexOf("?") != -1) {

      var str = url.substr(1);

      strs = str.split("&");

      for(var i = 0; i < strs.length; i ++) {

         theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]);

      }

   }

   return theRequest;

}
//AJAX数据提交返回提示框
function AjaxSubmit(url,type,postvalue,formname)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
//              contentType: "application/x-www-form-urlencoded; charset=gb2312",
              success:function(data){
                    if(data=="suc_ok")
                    {
                        dialogTime('数据操作提交成功！',''); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('数据操作提交失败，请联系系统管理员！','');
                    }
              }
      });
}
//AJAX数据提交根据返回数据填充内容
function AjaxSubmitDiv(url,type,postvalue,formname,id)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
                    getID(id).html(data);
              }
      });
}
//AJAX数据提交根据返回数据填充内容,并调用相应的函数
function AjaxSubmitDivLoad(url,type,postvalue,formname,id,funname)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
                    getID(id).html(data);
              },
              complete: function(msg){
                 eval(funname+"();");//回调
                }
      });
}
//AJAX数据提交根据结果执行相应的函数 funname为要执行的方法名称
function AjaxSubmitLoad(url,type,postvalue,formname,funname)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
              },
              complete: function(msg){
                 eval(funname+"();");//回调
                }
      });
}
//AJAX数据提交返回提示框
function AjaxSubmitUrl(url,type,postvalue,formname)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
                    if(data=="suc_ok")
                    {
                         dialogTimeClose('数据操作提交成功！','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('数据操作提交失败，请联系系统管理员！',''); 
                    }
                    else
                    {
                        dialogTime(data,''); 
                    }
              }
      });
}
//AJAX数据提交，发送邮件使用
function AjaxSubmitMailNote(url,type,postvalue,formname,id)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
                    if(data=="suc_ok")
                    {
                        getID(id).removeClass('i-zhuangtai2');
                        getID(id).addClass('i-zhuangtai1');
                        dialogTimeClose('发送成功！','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('发送失败，请联系系统管理员！',''); 
                    }
              }
      });
}
//AJAX数据提交，发送短信使用
function AjaxSubmitNote(url,type,postvalue,formname,id)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
              success:function(data){
                    if(data=="suc_ok")
                    {
                        dialogTimeClose('发送成功！','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('发送失败，请联系系统管理员！',''); 
                    }
              }
      });
}
//打开页面
function OpenUrl(url,title,width,height)
{
    art.dialog.open(url,{title:title,width:width,height:height,drag: true,resize:true,fixed:true});
}
//只能输入整数和小数
function txtKeyUpDecimal(txtName)
{
    getID(txtName).keyup(function(){  //keyup事件处理 
        $(this).val($(this).val().replace(/[^0-9\.]/g,''));  
    }).bind("paste",function(){  //CTR+V事件处理 
        $(this).val($(this).val().replace(/[^0-9\.]/g,''));  
    }).css("ime-mode", "disabled");  //CSS设置输入法不可用
}
//只能输入整数
function txtKeyUp(txtName)
{
     getID(txtName).keyup(function(){  //keyup事件处理 
        $(this).val($(this).val().replace(/^0{2}|\D|/g,''));  
    }).bind("paste",function(){  //CTR+V事件处理 
        $(this).val($(this).val().replace(/^0{2}|\D|/g,''));  
    }).css("ime-mode", "disabled");  //CSS设置输入法不可用
}
//只能输入数字跟英文逗号
function txtphone(txtName)
{
    getID(txtName).keyup(function(){  //keyup事件处理 
        $(this).val($(this).val().replace(/[^0-9\,]/g,''));  
    }).bind("paste",function(){  //CTR+V事件处理 
        $(this).val($(this).val().replace(/[^0-9\,]/g,''));  
    }).css("ime-mode", "disabled");  //CSS设置输入法不可用
}
//动态输出下拉列表内容
function AjaxPostSelect(url,typevalue,postvalue,id,funname)
{

    var objM1=getID(id)
    var varluse="";
    objM1.empty();
    if(objM1.length>0)
    {
        $.post(url,{'type':typevalue,'postvalue':postvalue,'datetiem':new Date().getTime()},function (data){
            var obj=data.split("#");
            for(var i = 0;i <obj.length-1;i++) { 
                    varluse="";
                    varluse=obj[i].split("_");
                    if(varluse[0]=='9999')
                        $("<option value='"+varluse[0]+"' selected='selected'>"+varluse[1]+"</option>").appendTo(objM1);     
                    else
                        $("<option value='"+varluse[0]+"'>"+varluse[1]+"</option>").appendTo(objM1);          
            }
        });
        if(funname.length>0)
        {
            eval(funname+"();");//回调
        }
    }
}
function chkChecked(chkname,txtname)
{
   
    if(getID(chkname).attr("checked"))
    {       
        getID(txtname).attr({"value":"1"});
    }
    else
    {
        getID(txtname).attr({"value":"2"});
    }
}
//气泡提示
function ATitle()
{
 $("a[title]").poshytip({
        className: 'tip-green',
        offsetX: -7,
        offsetY: 16,
        allowTipHover: false
        });
}

//下接列表给文框赋值并联动城市下拉列表
function GetSelChangeCity(txtname,selname)
{
    getID(txtname).attr({'value':''});
    getID(txtname).attr({'value':getID(selname).val()});
    ajaxPost("/AjaxResponse/tech_userHandler.ashx","18",getID(selname).val(),"city_select");
}

//AJAX数据提交返回提示框,并跳转到指定页面
function AjaxSubmitSkip(url,type,postvalue,formname)
{
    var pathurl="/AjaxResponse/"+url+""+"?type="+type+""+"&random="+Math.round(Math.random()*100)+"&postvalue="+postvalue+"";
    $.ajax({
              type:"post",
              url:pathurl,
              data:$("#"+formname+"").serialize(),
//              contentType: "application/x-www-form-urlencoded; charset=gb2312",
              success:function(data){
                    if(data=="suc_ok")
                    {
                         window.location.href="order_pay.aspx";
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('您已注册过本次会议，请不要重复注册！',''); 
                    }
              }
      });
}
//广告轮播
function lunbo()
{
    var wrap = $('.hotdoing-img');
    var imgs = wrap.find('.hotdoing-photo li');		
    var len = imgs.length;
    var tabTime = 1000;
    var outTime = 4000;
    var special = 'ntwon';	
    var num = 0;
    var interval;
    var type = 'click';
    imgs.each(function(i){
	    $('<li>'+(i+1)+'</li>').appendTo(wrap.find('.hotdoing-button'))
    });
    var btns = wrap.find('.hotdoing-button li');
    btns.eq(num).addClass(special);
    btns.bind(type,function(){
	    var _this = $(this);
	    _this.addClass(special).siblings().removeClass(special);
	    num = _this.prevAll().length;
	    imgs.stop().eq(num).fadeTo(tabTime,1);
	    imgs.not(':eq('+num+')').filter(':visible').fadeOut(tabTime);
	    return false;
    });
    var interFunc = function(){
	    num = (num+1)%len;
	    btns.eq(num).triggerHandler(type);		
    }	
    wrap.bind('mouseover',function(){
	    clearInterval(interval);
    }).bind('mouseout',function(){
	    interval = setInterval(interFunc,outTime);
    });	
    imgs.not(':eq('+num+')').hide();	
    interval = setInterval(interFunc,outTime);
}
//tab窗格
function tabmenu()
{
    //淡隐淡现选项卡切换
    $("#fadetab").tabso({
	    cntSelect:"#fadecon",
	    tabEvent:"mouseover",
	    tabStyle:"fade"
    });
}

function CreateKindEditor(textareaid,K,width,height)
    {
        var editor = K.create('#'+textareaid+'', {
            //上传管理
            uploadJson: '/kindeditor/asp.net/upload_json.ashx',
            //文件管理
            fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
            allowFileManager: true,
            filterMode:false,
            //设置编辑器创建后执行的回调函数
            afterCreate: function () {
                var self = this;
                K.ctrl(document, 13, function () {
                    self.sync();
                    K('form[name=form1]')[0].submit();
                });
                K.ctrl(self.edit.doc, 13, function () {
                    self.sync();
                    K('form[name=form1]')[0].submit();
                });
            },
            //上传文件后执行的回调函数,获取上传图片的路径
            afterUpload : function(url) {
                    //alert(url);
            },
            //编辑器高度
            width: width,
            //编辑器宽度
            height: height,
            //配置编辑器的工具栏
            items: [
            'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'cut', 'copy', 'paste',
            'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
            'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 
            'flash',  'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak'
            ]
        });
        return editor;
    }
    
//外宾个人用户打印胸卡
//code:用户ID
//given_name:名字
//family_name:姓氏
//country:国籍（英文）
//type_name:注册类型
function Foreign_Personal(code, given_name, family_name, country, type_name)
{
    var g_name = given_name.substring(0,1).toUpperCase()+given_name.substring(1).toLowerCase();
    var f_name = family_name.substring(0,1).toUpperCase()+family_name.substring(1).toLowerCase();

    var name = g_name + " " + f_name;
    var ce_x = 390;
    var ce_y = 180;
    var tn_x = 0;
    var tn_y = 100;
    var f_size = 90;
    var f_type = "ITC Avant Garde Gothic Book";
    var o_type = "HelveticaNeueLT Std Lt Cn";
    var f_bold = 700;
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(640, 350, 50,o_type, 3, 400, 0, 0, 0, "AB","" + code + "");
     
    if(name.length >= 16)
    {
        ce_y = 130;
        tn_y = 60;
        
        //given_name
        if(g_name == "Masahiro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Kolltis")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Krissada")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Peter")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(310, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Clifford")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(330, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(280, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(150, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(90, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(360, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        
        //family_name
        if(f_name == "Alejandro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Silva castro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Carrillo")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Pongmorakot")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(190, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Meemook")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Krucoff")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(280, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Fitzgerald")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Rigatelli")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "King iii")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Buckley")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(230, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(210, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(140, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 18)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 19)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 22)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(10, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
    }
    if(name == "Mohammad Namazi")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(30, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Pham Loc")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(240, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Halil Kisacik")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Vira Luvira")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(230, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Elias Sisu")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(250, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Nico Pijls")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(240, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Buckley")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(320, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 5)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 6)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 8)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(260, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 9)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 10)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 11)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(180, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 12)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(160, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 13)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(140, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 14)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(130, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 15)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(120, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length < 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(340, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    
    //country
    if(country.length == 3)
    {
        ce_x = 380;
    }
    else if(country.length == 4)
    {
        ce_x -= 10;
    }
    else if(country.length == 5)
    {
        ce_x -= 20;
    }
    else if(country.length == 6)
    {
        ce_x -= 30;
    }
    else if(country.length == 7)
    {
        ce_x -= 40;
    }
    else if(country.length == 8)
    {
        ce_x -= 40;
    }
    else if(country.length == 9)
    {
        ce_x -= 40;
    }
    else if(country.length == 10)
    {
        ce_x -= 70;
    }
    else if(country.length == 11)
    {
        ce_x -= 80;
    }
    else if(country.length == 12)
    {
        ce_x -= 90;
    }
    else if(country.length == 13)
    {
        ce_x -= 100;
    }
    else if(country.length == 14)
    {
        ce_x -= 110;
    }
    else if(country.length == 15)
    {
        ce_x -= 120;
    }
    else if(country.length == 16)
    {
        ce_x -= 130;
    }
    else if(country.length == 17)
    {
        ce_x -= 140;
    }
    else if(country.length == 18)
    {
        ce_x -= 150;
    }
    else if(country.length == 19)
    {
        ce_x -= 160;
    }
    else if(country.length == 20)
    {
        ce_x -= 170;
    }
    else if(country.length == 21)
    {
        ce_x -= 180;
    }
    else if(country.length == 22)
    {
        ce_x -= 190;
    }
    else if(country.length == 23)
    {
        ce_x -= 200;
    }
    else if(country.length == 24)
    {
        ce_x -= 210;
    }
    else if(country.length == 25)
    {
        ce_x -= 220;
    }
    else if(country.length == 26)
    {
        ce_x -= 230;
    }
    
    if(type_name.substring(0,type_name.lastIndexOf("(")).replace(/(^\s*)|(\s*$)/g,"") == "")
    {
        type_name = type_name;
    }
    else
    {
        type_name = type_name.substring(0,type_name.lastIndexOf("("));
    }
    
    switch(type_name)
    {
        case "Poster Presenter":
            tn_x = 280;
            break;
        case "Faculty":
            tn_x = 360;
            break;
        case "Regular Participant":
            tn_x = 260;
            break;
        case "Distributor":
            tn_x = 320;
            break;
    }
    
    ArgoxWebPrint.B_Prn_Text_TrueType(ce_x, ce_y, 50,o_type, 3, 200, 0, 0, 0, "AD","" + country + "");
    ArgoxWebPrint.B_Prn_Text_TrueType(tn_x, tn_y, 50,o_type, 3, 200, 0, 0, 0, "AE","" + type_name + "");
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

//外宾陪同人员打印胸卡
//name:名字
//country:国籍
//type_name:注册类型
function Escort_Personal(name,country,type_name)
{
    var ce_x = 390;
    var ce_y = 180;
    var tn_x = 0;
    var tn_y = 100;
    var f_size = 90;
    var f_type = "ITC Avant Garde Gothic Book";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var f_bold = 700;
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);

    if(name.length >= 16)
    {
        ce_y = 130;
        tn_y = 60;
        
        var name_array = name.split(' ');
        var g_name = name_array[0];
        var f_name = "";
        for(var i=0;i<name_array.length;i++)
        {
            if(i == name_array.length-1)
            {
                f_name = name_array[i];
            }
        }
        
        //given_name
        if(g_name == "Masahiro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Kolltis")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name == "Krissada")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(330, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(260, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(150, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(90, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else if(g_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(360, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + g_name + "");
        }
        
        //family_name
        if(f_name == "Alejandro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Silva castro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Carrillo")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Pongmorakot")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(190, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name == "Meemook")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(230, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(210, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(140, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 18)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 19)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else if(f_name.length == 22)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(10, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AF","" + f_name + "");
        }
    }
    else if(name == "Pham Loc")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(240, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Halil Kisacik")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Vira Luvira")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(230, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name == "Elias Sisu")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(250, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 6)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 8)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(260, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 9)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 10)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 11)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(180, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 12)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(160, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 13)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(140, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 14)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(130, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length == 15)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(120, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    else if(name.length < 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(340, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + name + "");
    }
    
    
    //country
    if(country.length == 3)
    {
        ce_x = ce_x;
    }
    else if(country.length == 4)
    {
        ce_x -= 10;
    }
    else if(country.length == 5)
    {
        ce_x -= 20;
    }
    else if(country.length == 6)
    {
        ce_x -= 30;
    }
    else if(country.length == 7)
    {
        ce_x -= 40;
    }
    else if(country.length == 8)
    {
        ce_x -= 50;
    }
    else if(country.length == 9)
    {
        ce_x -= 60;
    }
    else if(country.length == 10)
    {
        ce_x -= 70;
    }
    else if(country.length == 11)
    {
        ce_x -= 80;
    }
    else if(country.length == 12)
    {
        ce_x -= 90;
    }
    else if(country.length == 13)
    {
        ce_x -= 100;
    }
    else if(country.length == 14)
    {
        ce_x -= 110;
    }
    else if(country.length == 15)
    {
        ce_x -= 120;
    }
    else if(country.length == 16)
    {
        ce_x -= 130;
    }
    else if(country.length == 17)
    {
        ce_x -= 140;
    }
    else if(country.length == 18)
    {
        ce_x -= 150;
    }
    else if(country.length == 19)
    {
        ce_x -= 160;
    }
    else if(country.length == 20)
    {
        ce_x -= 170;
    }
    else if(country.length == 21)
    {
        ce_x -= 180;
    }
    else if(country.length == 22)
    {
        ce_x -= 190;
    }
    else if(country.length == 23)
    {
        ce_x -= 200;
    }
    else if(country.length == 24)
    {
        ce_x -= 210;
    }
    else if(country.length == 25)
    {
        ce_x -= 220;
    }
    else if(country.length == 26)
    {
        ce_x -= 230;
    }
    
    switch(type_name)
    {
        case "Accompanying Person":
            tn_x = 240;
            break;
    }
    ArgoxWebPrint.B_Prn_Text_TrueType(ce_x, ce_y, 50, t_type, 3, 200, 0, 0, 0, "AD","" + country + "");
    ArgoxWebPrint.B_Prn_Text_TrueType(tn_x, tn_y, 50, t_type, 3, 200, 0, 0, 0, "AE","" + type_name + "");
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
    
}

//中宾个人用户打印胸卡
//user_code:用户ID
//user_name:名字
//province:省份
//type_name:注册类型
//py_1:姓氏拼音
//py_2:名字拼音
function Ch_Personal(user_code,user_name,province,type_name,py_1,py_2)
{
    var f_size = 120;
    var f_type = "方正宋黑简体";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var p_x = 320;
    var tn_x = 320;
    var py_name = py_1 + " " + py_2;
    var py_x = 400;
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(600, 350, 45,t_type, 3, 300, 0, 0, 0, "AB","" + user_code + "");
    if(user_name.length == 2)
    {
        var name_1 = user_name.substring(0,1);
        var name_2 = user_name.substring(1);
        ArgoxWebPrint.B_Prn_Text_TrueType(260, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+name_1+"    "+name_2+"");
    }
    else if(user_name.length == 4)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(180, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length == 3)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(250, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length ==6)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(280, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length ==7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length ==8)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length == 9)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(60, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length == 10)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length > 10)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(20, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    
    if(province.length == 2)
    {
        var province_1 = province.substring(0,1);
        var province_2 = province.substring(1);
        province = province_1+"    "+province_2;
        p_x = 360;
    }
    else if(province.length == 3)
    {
        p_x = 360;
    }
    
    if(type_name == "Faculty")
    {
        tn_x = 370;
    }
    else if(type_name == "Regular Participant")
    {
        tn_x = 300;
    }
    else if(type_name == "听课证代表")
    {
        tn_x = 320;
    }
    
    //姓名拼音
    if(py_name.length == 3)
    {
        py_x = py_x;
    }
    else if(py_name.length == 4)
    {
        py_x -= 10;
    }
    else if(py_name.length == 5)
    {
        py_x -= 30;
    }
    else if(py_name.length == 6)
    {
        py_x -= 30;
    }
    else if(py_name.length == 7)
    {
        py_x -= 40;
    }
    else if(py_name.length == 8)
    {
        py_x -= 50;
    }
    else if(py_name.length == 9)
    {
        py_x -= 60;
    }
    else if(py_name.length == 10)
    {
        py_x -= 70;
    }
    else if(py_name.length == 11)
    {
        py_x -= 80;
    }
    else if(py_name.length == 12)
    {
        py_x -= 90;
    }
    else if(py_name.length == 13)
    {
        py_x -= 100;
    }
    else if(py_name.length == 14)
    {
        py_x -= 110;
    }
    else if(py_name.length == 15)
    {
        py_x -= 140;
    }
    else if(py_name.length == 16)
    {
        py_x -= 130;
    }
    else if(py_name.length == 17)
    {
        py_x -= 140;
    }
    else if(py_name.length == 18)
    {
        py_x -= 150;
    }
    else if(py_name.length == 19)
    {
        py_x -= 160;
    }
    else if(py_name.length == 20)
    {
        py_x -= 170;
    }
    else if(py_name.length == 21)
    {
        py_x -= 180;
    }
    else if(py_name.length == 22)
    {
        py_x -= 190;
    }
    else if(py_name.length == 23)
    {
        py_x -= 200;
    }
    else if(py_name.length == 24)
    {
        py_x -= 210;
    }
    else if(py_name.length == 25)
    {
        py_x -= 220;
    }
    else if(py_name.length == 26)
    {
        py_x -= 230;
    }
    if(py_name != "undefined undefined")
    {
        
        ArgoxWebPrint.B_Prn_Text_TrueType(py_x, 150, 50,t_type, 3, 100, 0, 0, 0, "AD",""+py_name+"");
    }
    
    ArgoxWebPrint.B_Prn_Text_TrueType(p_x, 100, 40,f_size, 3, 100, 0, 0, 0, "AE",""+province+"");
    ArgoxWebPrint.B_Prn_Text_TrueType(tn_x, 50, 40,t_type, 3, 200, 0, 0, 0, "AF",""+type_name+"");
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

//中宾团队用户打印胸卡
//user_code:用户ID
//user_name:名字
//type_name:注册类型
//py_1:姓氏拼音
//py_2:名字拼音
function Ch_Team(user_code,user_name,type_name,py_1,py_2)
{
    var f_size = 120;
    var f_type = "方正宋黑简体";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var tn_x = 320;
    var py_name = py_1 + " " + py_2;
    var py_x = 400;
    
    if(user_name.replace(/[^\u4E00-\u9FA5]/g,"") != "")
    {
        ArgoxWebPrint.B_EnumUSB();
        ArgoxWebPrint.B_CreateUSBPort(1);
        ArgoxWebPrint.B_Prn_Text_TrueType(580, 330, 45,t_type, 3, 300, 0, 0, 0, "AB","" + user_code + "");
        if(user_name.length == 2)
        {
            var name_1 = user_name.substring(0,1);
            var name_2 = user_name.substring(1);
            ArgoxWebPrint.B_Prn_Text_TrueType(260, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+name_1+"    "+name_2+"");
        }
        else if(user_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(180, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length == 3)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 200, f_size, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(180, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(60, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(10, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        else if(user_name.length > 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(20, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
        }
        
        if(type_name == "Faculty")
        {
            tn_x = 360;
        }
        else if(type_name == "Regular Participant")
        {
            tn_x = 260;
        }
        
        //姓名拼音
        if(py_name.length == 3)
        {
            py_x = py_x;
        }
        else if(py_name.length == 4)
        {
            py_x -= 10;
        }
        else if(py_name.length == 5)
        {
            py_x -= 20;
        }
        else if(py_name.length == 6)
        {
            py_x -= 30;
        }
        else if(py_name.length == 7)
        {
            py_x -= 40;
        }
        else if(py_name.length == 8)
        {
            py_x -= 50;
        }
        else if(py_name.length == 9)
        {
            py_x -= 60;
        }
        else if(py_name.length == 10)
        {
            py_x -= 70;
        }
        else if(py_name.length == 11)
        {
            py_x -= 80;
        }
        else if(py_name.length == 12)
        {
            py_x -= 90;
        }
        else if(py_name.length == 13)
        {
            py_x -= 100;
        }
        else if(py_name.length == 14)
        {
            py_x -= 110;
        }
        else if(py_name.length == 15)
        {
            py_x -= 120;
        }
        else if(py_name.length == 16)
        {
            py_x -= 130;
        }
        else if(py_name.length == 17)
        {
            py_x -= 140;
        }
        else if(py_name.length == 18)
        {
            py_x -= 150;
        }
        else if(py_name.length == 19)
        {
            py_x -= 160;
        }
        else if(py_name.length == 20)
        {
            py_x -= 170;
        }
        else if(py_name.length == 21)
        {
            py_x -= 180;
        }
        else if(py_name.length == 22)
        {
            py_x -= 190;
        }
        else if(py_name.length == 23)
        {
            py_x -= 200;
        }
        else if(py_name.length == 24)
        {
            py_x -= 210;
        }
        else if(py_name.length == 25)
        {
            py_x -= 220;
        }
        else if(py_name.length == 26)
        {
            py_x -= 230;
        }
        
        if(py_name != "undefined undefined")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(py_x, 140, 50,t_type, 3, 100, 0, 0, 0, "AD",""+py_name+"");
        }
        ArgoxWebPrint.B_Prn_Text_TrueType(tn_x, 60, 50,t_type, 3, 100, 0, 0, 0, "AE",""+type_name+"");
        ArgoxWebPrint.B_Print_Out(1);
        ArgoxWebPrint.B_ClosePrn();
    }
    else
    {
        var all_name = user_name.split(' ');
        var given_name = all_name[0];
        var family_name = all_name[all_name.length - 1];
        Foreign_Personal(user_code, given_name, family_name, "", type_name);
    }
}

//快速打印
//count:打印份数
//content:打印内容
//type_name:打印类型（媒体-Media,工作人员-Staff）
function Print_Card(count,content,type_name)
{
    var f_type = "方正宋黑简体";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var tn_x = 320;
    
    switch(type_name)
    {
        case "Staff":
            tn_x = 340;
            break;
        case "Media":
            tn_x = 350;
            break;
        case "Working Pass":
            tn_x = 240;
            break;
        case "听课证代表":
            tn_x = 270;
            break;
    }
    
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    if(content.length == 2)
    {
        var content_1 = content.substring(0,1);
        var content_2 = content.substring(1);
        ArgoxWebPrint.B_Prn_Text_TrueType(190, 190, 150,f_type, 3, 500, 0, 0, 0, "AB",""+content_1+"    "+content_2+"");
    }
    else if(content.length == 4)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(150, 190, 150,f_type, 3, 500, 0, 0, 0, "AB",""+content+"");
    }
    else if(content.length == 3)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(190, 190, 150,f_type, 3, 500, 0, 0, 0, "AB",""+content+"");
    }
    ArgoxWebPrint.B_Prn_Text_TrueType(tn_x, 90, 50,t_type, 3, 400, 0, 0, 0, "AC",""+type_name+"");
    ArgoxWebPrint.B_Print_Out(parseInt(count));
    ArgoxWebPrint.B_ClosePrn();
}

//快速打印参展商胸卡
//count:数量
//enterprise:公司名称(英文)
function Print_exhibitors_count(count,enterprise)
{
    var f_type = "方正宋黑简体";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var ce_x = 400;
    
    //enterprise
    if(enterprise.length == 3)
    {
        ce_x = 360;
    }
    else if(enterprise.length == 4)
    {
        ce_x -= 40;
    }
    else if(enterprise.length == 5)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 6)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 7)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 8)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 9)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 10)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 11)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 12)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 13)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 14)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 15)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 16)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 17)
    {
        ce_x -= 100;
    }
    else if(enterprise.length == 18)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 19)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 20)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 21)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 22)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 23)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 24)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 25)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 26)
    {
        ce_x -= 160;
    }
    else if(enterprise.length == 27)
    {
        ce_x -= 180;
    }
    else if(enterprise.length == 28)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 29)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 30)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 31)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 32)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 33)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 34)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 35)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 36)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 37)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 38)
    {
        ce_x -= 270;
    }
    else if(enterprise.length == 39)
    {
        ce_x -= 280;
    }
    else if(enterprise.length == 40)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 41)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 42)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 43)
    {
        ce_x = 90;
    }
    else if(enterprise.length == 44)
    {
        ce_x = 90;
    }
    else if(enterprise.length == 45)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 46)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 47)
    {
        ce_x = 60;
    }
    else
    {
        ce_x = 60;
    }
    
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, 150,f_type, 3, 500, 0, 0, 0, "AB","参展商");
    ArgoxWebPrint.B_Prn_Text_TrueType(ce_x, 120, 40,t_type, 3, 100, 0, 0, 0, "AD",enterprise);
    ArgoxWebPrint.B_Prn_Text_TrueType(340, 50, 40,t_type, 3, 100, 0, 0, 0, "AE","Exhibitor");
    ArgoxWebPrint.B_Print_Out(parseInt(count));
    ArgoxWebPrint.B_ClosePrn();
}

//参展商中宾胸卡打印
//content:名称
//type_name:打印类型(Exhibitor)
//enterprise:公司名称(英文)
//py_1:姓氏拼音
//py_2:名字拼音
function Print_exhibitors_ch(content,type_name,enterprise,py_1,py_2)
{
    var py_name = py_1 + " " + py_2;
    var f_type = "方正宋黑简体";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var name = "";
    var AB_x = 0;
    var AB_y = 0;
    var ce_x = 400;
    var ce_y = 100;
    var py_x = 390;
    var f_size = 150;
    
    if(content == "参展商")
    {
        name = content;
        AB_x = 150;
        AB_y = 210;
        ce_y = 150;
    }
    else if(content.length == 2)
    {
        var content_1 = content.substring(0,1);
        var content_2 = content.substring(1);
        name = content_1+"    "+content_2;
        AB_x = 200;
        AB_y = 210;        
    }
    else if(content.length == 4)
    {
        name = content;
        AB_x = 150;
        AB_y = 210; 
        //ArgoxWebPrint.B_Prn_Text_TrueType(150, 190, 150,f_type, 3, 500, 0, 0, 0, "AB",""+content+"");
    }
    else if(content.length == 3)
    {
        name = content;
        AB_x = 200;
        AB_y = 210; 
        //ArgoxWebPrint.B_Prn_Text_TrueType(220, 190, 150,f_type, 3, 500, 0, 0, 0, "AB",""+content+"");
    }
    else if(user_name.length == 9)
    {
        name = content;
        AB_x = 60;
        AB_y = 200;
        f_size = 90;
        //ArgoxWebPrint.B_Prn_Text_TrueType(60, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length == 10)
    {
        name = content;
        AB_x = 40;
        AB_y = 200;
        f_size = 90;
        //ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    else if(user_name.length > 10)
    {
        name = content;
        AB_x = 20;
        AB_y = 200;
        f_size = 90;
        //ArgoxWebPrint.B_Prn_Text_TrueType(20, 200, 90, f_type, 3, 500, 0, 0, 0, "AC",""+user_name+"");
    }
    
    //姓名拼音
    if(py_name == "Xie Li")
    {
        py_x -= 30;
    }
    else if(py_name.length == 3)
    {
        py_x -= 20;
    }
    else if(py_name.length == 4)
    {
        py_x -= 30;
    }
    else if(py_name.length == 5)
    {
        py_x -= 40;
    }
    else if(py_name.length == 6)
    {
        py_x -= 50;
    }
    else if(py_name.length == 7)
    {
        py_x -= 60;
    }
    else if(py_name.length == 8)
    {
        py_x -= 70;
    }
    else if(py_name.length == 9)
    {
        py_x -= 80;
    }
    else if(py_name.length == 10)
    {
        py_x -= 80;
    }
    else if(py_name.length == 11)
    {
        py_x -= 90;
    }
    else if(py_name.length == 12)
    {
        py_x -= 90;
    }
    else if(py_name.length == 13)
    {
        py_x -= 100;
    }
    else if(py_name.length == 14)
    {
        py_x -= 110;
    }
    else if(py_name.length == 15)
    {
        py_x -= 120;
    }
    else if(py_name.length == 16)
    {
        py_x -= 130;
    }
    else if(py_name.length == 17)
    {
        py_x -= 140;
    }
    else if(py_name.length == 18)
    {
        py_x -= 150;
    }
    else if(py_name.length == 19)
    {
        py_x -= 160;
    }
    else if(py_name.length == 20)
    {
        py_x -= 170;
    }
    else if(py_name.length == 21)
    {
        py_x -= 180;
    }
    else if(py_name.length == 22)
    {
        py_x -= 190;
    }
    else if(py_name.length == 23)
    {
        py_x -= 200;
    }
    else if(py_name.length == 24)
    {
        py_x -= 210;
    }
    else if(py_name.length == 25)
    {
        py_x -= 220;
    }
    else if(py_name.length == 26)
    {
        py_x -= 230;
    }
    
    //enterprise
    if(enterprise.length == 3)
    {
        ce_x = ce_x;
    }
    else if(enterprise.length == 4)
    {
        ce_x -= 40;
    }
    else if(enterprise.length == 5)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 6)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 7)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 8)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 9)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 10)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 11)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 12)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 13)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 14)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 15)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 16)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 17)
    {
        ce_x -= 100;
    }
    else if(enterprise.length == 18)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 19)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 20)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 21)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 22)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 23)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 24)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 25)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 26)
    {
        ce_x -= 160;
    }
    else if(enterprise.length == 27)
    {
        ce_x -= 180;
    }
    else if(enterprise.length == 28)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 29)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 30)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 31)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 32)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 33)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 34)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 35)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 36)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 37)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 38)
    {
        ce_x -= 270;
    }
    else if(enterprise.length == 39)
    {
        ce_x -= 280;
    }
    else if(enterprise.length == 40)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 41)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 42)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 43)
    {
        ce_x = 90;
    }
    else if(enterprise.length == 44)
    {
        ce_x = 90;
    }
    else if(enterprise.length == 45)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 46)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 47)
    {
        ce_x = 60;
    }
    else
    {
        ce_x = 60;
    }
    
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    ArgoxWebPrint.B_Prn_Text_TrueType(AB_x, AB_y, f_size,f_type, 3, 500, 0, 0, 0, "AB",name);
    
    if(content != "参展商")
    {
        if(py_name != "NULL NULL")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(py_x, 160, 50,t_type, 3, 200, 0, 0, 0, "AC",py_name);
        }
        
    }
    
    ArgoxWebPrint.B_Prn_Text_TrueType(ce_x, ce_y, 40,t_type, 3, 100, 0, 0, 0, "AD",enterprise);
    ArgoxWebPrint.B_Prn_Text_TrueType(340, 50, 40,t_type, 3, 100, 0, 0, 0, "AE",type_name);
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}

//参展商外宾胸卡打印
//content:名称
//type_name:打印类型(Exhibitor)
//enterprise:公司名称(英文)
function Print_exhibitors_en(content,type_name,enterprise)
{
    var f_type = "ITC Avant Garde Gothic Book";
    var t_type = "HelveticaNeueLT Std Lt Cn";
    var f_bold = 600;
    var f_size = 100;
    var ce_x = 400;
    var ce_y = 180;
    var name = content;
    
    ArgoxWebPrint.B_EnumUSB();
    ArgoxWebPrint.B_CreateUSBPort(1);
    if(name.length >= 16)
    {
        ce_y = 130;
        tn_y = 60;
        
        var name_array = name.split(' ');
        var g_name = name_array[0];
        var f_name = "";
        for(var i=0;i<name_array.length;i++)
        {
            if(i == name_array.length-1)
            {
                f_name = name_array[i];
            }
        }
        
        //given_name
        if(g_name == "Masahiro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name == "Maria")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(310, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name == "Kolltis")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name == "Krissada")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(330, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(270, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(260, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(150, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(90, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else if(g_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(360, 280, f_size,f_type, 3, f_bold, 0, 0, 0, "AB","" + g_name + "");
        }
        
        //family_name
        if(f_name == "Alejandro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name == "Silva castro")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name == "Olivero")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name == "Carrillo")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name == "Pongmorakot")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(190, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name == "Meemook")
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 4)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(320, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 5)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(300, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 6)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(290, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 7)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(250, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 8)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(240, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 9)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(230, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 10)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(220, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 11)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(210, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 12)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(200, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 13)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(160, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 14)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(140, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 15)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 16)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(100, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 17)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(80, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 18)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(70, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 19)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(40, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else if(f_name.length == 22)
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(10, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
        else
        {
            ArgoxWebPrint.B_Prn_Text_TrueType(340, 200, f_size,f_type, 3, f_bold, 0, 0, 0, "AC","" + f_name + "");
        }
    }
    else if(name == "Pham Loc")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(240, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name == "Halil Kisacik")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name == "Vira Luvira")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(230, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name == "Elias Sisu")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(250, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name == "William Lim")
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 6)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(300, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 8)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(260, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 9)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(220, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 10)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(200, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 11)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(180, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 12)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(160, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 13)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(140, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 14)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(130, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length == 15)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(120, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    else if(name.length < 7)
    {
        ArgoxWebPrint.B_Prn_Text_TrueType(340, 260, f_size,f_type, 3, f_bold, 0, 0, 0, "AD","" + name + "");
    }
    
    //enterprise
    if(enterprise.length == 3)
    {
        ce_x = ce_x;
    }
    else if(enterprise.length == 4)
    {
        ce_x -= 40;
    }
    else if(enterprise.length == 5)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 6)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 7)
    {
        ce_x -= 50;
    }
    else if(enterprise.length == 8)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 9)
    {
        ce_x -= 60;
    }
    else if(enterprise.length == 10)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 11)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 12)
    {
        ce_x -= 70;
    }
    else if(enterprise.length == 13)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 14)
    {
        ce_x -= 80;
    }
    else if(enterprise.length == 15)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 16)
    {
        ce_x -= 90;
    }
    else if(enterprise.length == 17)
    {
        ce_x -= 100;
    }
    else if(enterprise.length == 18)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 19)
    {
        ce_x -= 120;
    }
    else if(enterprise.length == 20)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 21)
    {
        ce_x -= 130;
    }
    else if(enterprise.length == 22)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 23)
    {
        ce_x -= 140;
    }
    else if(enterprise.length == 24)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 25)
    {
        ce_x -= 150;
    }
    else if(enterprise.length == 26)
    {
        ce_x -= 160;
    }
    else if(enterprise.length == 27)
    {
        ce_x -= 170;
    }
    else if(enterprise.length == 28)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 29)
    {
        ce_x -= 200;
    }
    else if(enterprise.length == 30)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 31)
    {
        ce_x -= 210;
    }
    else if(enterprise.length == 32)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 33)
    {
        ce_x -= 220;
    }
    else if(enterprise.length == 34)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 35)
    {
        ce_x -= 230;
    }
    else if(enterprise.length == 36)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 37)
    {
        ce_x -= 260;
    }
    else if(enterprise.length == 38)
    {
        ce_x -= 270;
    }
    else if(enterprise.length == 39)
    {
        ce_x -= 280;
    }
    else if(enterprise.length == 40)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 41)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 42)
    {
        ce_x = 120;
    }
    else if(enterprise.length == 43)
    {
        ce_x = 80;
    }
    else if(enterprise.length == 44)
    {
        ce_x = 80;
    }
    else if(enterprise.length == 45)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 46)
    {
        ce_x = 60;
    }
    else if(enterprise.length == 47)
    {
        ce_x = 60;
    }
    else
    {
        ce_x = 60;
    }
    
    ArgoxWebPrint.B_Prn_Text_TrueType(ce_x, ce_y, 40,t_type, 3, 100, 0, 0, 0, "AE",enterprise);
    ArgoxWebPrint.B_Prn_Text_TrueType(340, 80, 50,t_type, 3, 100, 0, 0, 0, "AF",type_name);
    ArgoxWebPrint.B_Print_Out(1);
    ArgoxWebPrint.B_ClosePrn();
}


function dialogRedrict(contents,url){
      var values="<font size='2'>"+contents+"</font>"
      values+="<br/><font size='2'>如未跳转，<a href=\""+url+"\">点击</a>跳转</font>"
      art.dialog({
        fixed: true,
	    content:values,
	    init: function () {
    	    var that = this, i = 2;
            var fn = function () {
                that.title(i + '秒后跳转');
                !i && that.close();
                i --;
            };
		    timer = setInterval(fn, 1000);
            fn();
	    },
        close:function()
        {
    	   clearInterval(timer);
    	   if(url.length>0)
    	    top.location.href=url;
        }
    });
 }
 function setemail()
    {
        var flag=true;
        if($("#Email").val()=="cacagca@126.com")
         {
            $("#Email").val("");
         }
        if ($("#Email").val().replace(/(^\s*)|(\s*$)/g, "") == "") 
        {
            dialogTime("电子邮件不能为空","");
            flag= false;
        }
        else if($("#Email").val().match("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$") == null) 
        {
            dialogTime("Email格式不正确！（如：vip@i-conference.org）","");
            flag= false;
        }
        if(flag)
            AjaxSubmitUrl('tech_mail_subscriptionHandler.ashx','1',"1",'form1');
    }
    function setemailen()
    {
        var flag=true;
        if($("#Email").val()=="cacagca@126.com")
         {
            $("#Email").val("");
         }
        if ($("#Email").val().replace(/(^\s*)|(\s*$)/g, "") == "") 
        {
            dialogTime("Please enter the email!","");
            flag= false;
        }
        else if($("#Email").val().match("^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$") == null) 
        {
            dialogTime("Incorrect email format such as: vip@i-conference.org!","");
            flag= false;
        }
        if(flag)
            AjaxSubmitUrl('tech_mail_subscriptionHandler.ashx','1',"2",'form1');
    }
function facultyLeftMenu(Lindex)
{
    for(var i=1;i<=5;i++)
    {
        var liID="li"+i;
        var aID="a"+i;
        var vclass=getID(aID).attr('class');
        if(Lindex==i)
        {
            getID(liID).removeClass('thisclass').addClass('thisclass');
            getID(aID).removeClass(vclass).addClass(vclass+'_hover');
        }
        else
        {
            getID(liID).removeClass('thisclass');
        }
    }
}

/*
 * 弹出DIV层
 */
function showDiv()
{
    var Idiv = document.getElementById("Idiv");
    var mou_head = document.getElementById('mou_head');
    Idiv.style.display = "block";
    //以下部分要将弹出层居中显示
    Idiv.style.left=(document.documentElement.clientWidth-Idiv.clientWidth)/2+document.documentElement.scrollLeft+"px";
    Idiv.style.top =(document.documentElement.clientHeight-Idiv.clientHeight)/2+document.documentElement.scrollTop-50+"px";
    
    //以下部分使整个页面至灰不可点击
    var procbg = document.createElement("div"); //首先创建一个div
    procbg.setAttribute("id","mybg"); //定义该div的id
    procbg.style.background = "#000000";
    procbg.style.width = "100%";
    procbg.style.height = "100%";
    procbg.style.position = "fixed";
    procbg.style.top = "0";
    procbg.style.left = "0";
    procbg.style.zIndex = "80000";
    procbg.style.opacity = "0.7";
    procbg.style.filter = "Alpha(opacity=70)";
    //背景层加入页面
    document.body.appendChild(procbg);
    //document.body.style.overflow = "hidden"; //取消滚动条
}
 
function closeDiv() //关闭弹出层
{
    var Idiv=document.getElementById("Idiv");
    Idiv.style.display="none";
    //document.body.style.overflow = "auto"; //恢复页面滚动条
    var body = document.getElementsByTagName("body");
    var mybg = document.getElementById("mybg");
    try
    {
        body[0].removeChild(mybg);
    }
    catch(err)
    {}
}
function ShowDivById(div_id)
{
    var Idiv = document.getElementById(div_id);
    var mou_head = document.getElementById('mou_head');
    Idiv.style.display = "block";
    //以下部分要将弹出层居中显示
    Idiv.style.left=(document.documentElement.clientWidth-Idiv.clientWidth)/2+document.documentElement.scrollLeft+"px";
    Idiv.style.top =(document.documentElement.clientHeight-Idiv.clientHeight)/2+document.documentElement.scrollTop-50+"px";

    //以下部分使整个页面至灰不可点击
    var procbg = document.createElement("div"); //首先创建一个div
    procbg.setAttribute("id","mybg"); //定义该div的id
    procbg.style.background = "#000000";
    procbg.style.width = "100%";
    procbg.style.height = "100%";
    procbg.style.position = "fixed";
    procbg.style.top = "0";
    procbg.style.left = "0";
    procbg.style.zIndex = "80000";
    procbg.style.opacity = "0.7";
    procbg.style.filter = "Alpha(opacity=70)";
    //背景层加入页面
    document.body.appendChild(procbg);
    //document.body.style.overflow = "hidden"; //取消滚动条
}
 
function CloseDivById(div_id) //关闭弹出层
{
    var Idiv=document.getElementById(div_id);
    Idiv.style.display="none";
    //document.body.style.overflow = "auto"; //恢复页面滚动条
    var body = document.getElementsByTagName("body");
    var mybg = document.getElementById("mybg");
    try
    {
        body[0].removeChild(mybg);
    }
    catch(err)
    {}
}
//天数倒计时
function GetRTime(vdata)
{
   var EndTime= new Date(vdata); //截止时间 年/月/日
   var NowTime = new Date();
   var t =EndTime.getTime() - NowTime.getTime();
   var d=Math.floor(t/1000/60/60/24);
   document.getElementById("t_d").innerHTML = d + "";
}
//返回登录状态
function GetCHUserCookie(type){    
// type:1为中宾 2为外宾
   $.ajax({ 
         type: "post", 
         url: "/TechMaxWeb/AjaxResponse/tech_commonHandler.ashx?type=GetCookieResult&parm="+type,                   
         success: function (data) 
         {    
            if(type==1)
            {                                            
                if(data=='yes')
		        {
		            window.location.href="/TechMaxWeb/ch_user/user_index.aspx";
                }
		        else
		        {
	               window.location.href="/TechMaxWeb/ch_user/user_login.aspx";
                }
            }
            else if(type==2)
            {
                if(data=='yes')
		        {
		            window.location.href="/TechMaxWeb/en_user/user_index.aspx";
                }
		        else
		        {
	               window.location.href="/TechMaxWeb/en_user/user_login.aspx";
                }
            }
         }, 
         error: function (XMLHttpRequest, textStatus, errorThrown) { dialogTime(' 发生错误，请联系客服！ ',''); } 
   });
 }

 //展开工具栏
 function mclick(n) {
     $(n).next("ul").show('slide');
 }

 //收起工具栏
 function mclickhide(n) {
     $(".dropdish").hover(function () { }, function () {
         $(".dropdish").hide('slide');
     });
 }

 //格式化银行卡号
 function BankCordFormat(id) {
     var str = $('#' + id).val().trim().replace(/\D/g, "");
     var c = "";
     if (str.length > 4) {
         for (var i = 0; i < str.length; i++) {
             if (i == 4 || i == 8 || i == 12) {
                 c += " " + str[i];
             }
             else {
                 c += str[i];
             }
         }
     }
     else {
         c = $('#' + id).val().trim().replace(/\D/g, "");
     }
     $('#' + id).val(c.trim());
 }