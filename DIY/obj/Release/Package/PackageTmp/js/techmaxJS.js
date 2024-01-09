//定时弹出框,contents为弹出框内容,url为弹出框关闭后跳转的页面,如不需跳传就传空
var timer;
function dialogTime(contents,url)
   {
      var values="<font size='2'>"+contents+"</font>"
      art.dialog({
        fixed: true,
	    content:values,
	    init: function () {
    	    var that = this, i = 2;
            var fn = function () {
                that.title(i + '秒后关闭');
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
 function dialogTimeClose(contents,url,isDialog)
   {
    var values="<font size='2'>"+contents+"</font>"
      art.dialog({
       fixed: true,
	    content:values,
	    init: function () {
    	    var that = this, i = 2;
            var fn = function () {
                that.title(i + '秒后关闭');
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
    	    if(isDialog=="yes")
    	    {
    	        art.dialog.opener.LoadTable();
    	        art.dialog.close(); 
    	    }
			else{
				art.dialog.close(); 
			}
        }
    });
 }

function dialogTimeFunClose(contents,url,funname)
{
    var values="<font size='2'>"+contents+"</font>"
      art.dialog({
       fixed: true,
	    content:values,
	    init: function () {
    	    var that = this, i = 2;
            var fn = function () {
                that.title(i + '秒后关闭');
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
    	    art.dialog.opener.eval(funname+"();");
    	    art.dialog.close();
        }
    });
}

function DialogOkClose(contents, url, isDialog) {
    var values = "<font size='2'>" + contents + "</font>"
    art.dialog({
        fixed: true,
        content: values,
        init: function () {
            var that = this, i = 2;
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
//执行AJAX信息输出之后在执行其它方法
function ajaxPostFun(url,type,postvalue,id,funname)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
        getID(id).html(data);
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

//判断注册信息完整度
function CheckRegist()
{
    if($("#loginid").val()=="")
    {
        $("#tips_loginid").html("用户名不能为空");
        return false;
    }
    else
    {
        $("#tips_loginid").html("");
    } 
    //-----
    if($("#loginpwd").val()=="")
    {
        $("#tips_loginpwd").html("密码不能为空");
        return false;
    }
    else
    {
        $("#tips_loginpwd").html("");
    }
    //------
    if($("#loginpwd2").val()=="")
    {
        $("#tips_loginpwd2").html("两次密码不一致");
        return false;
    }
    else
    {
        $("#tips_loginpwd2").html("");
    }
    //----
    if($("#loginpwd2").val()!=$("#loginpwd").val())
    {
        $("#tips_loginpwd2").html("两次密码不一致");
        return false;
    }    
    else
    {
        $("#tips_loginpwd2").html("");
    }
    //----
    if($("#uname").val()=="")
    {
        $("#tips_uname").html("姓名不能为空");
        return false;
    }
    else
    {
        $("#tips_uname").html("");
    }
    //----
    if($("input[name='gender']:checked").val()==null)
    {
        $("#tips_gender").html("请选择性别");
        return false;
    }
    else
    {
        $("#tips_gender").html("");
    }
    //----
    if($("#datebirth").val()=="")
    {
        $("#tips_datebirth").html("出生年月不能为空");
        return false;
    }
    else
    {
        $("#tips_datebirth").html("");
    }
    //----
    if($("#address").val()=="")
    {
        $("#tips_address").html("地址不能为空");
        return false;
    }
    else
    {
        $("#tips_address").html("");
    }
    //----
    if($("#mobilephone").val()=="")
    {
        $("#tips_mobilephone").html("手机号码不能为空");
        return false;
    }
    else
    {
        $("#tips_mobilephone").html("");
    }
    //----
    if($("#mail").val()=="")
    {
        $("#tips_mail").html("电子邮件不能为空");
        return false;
    }
    else
    {
        $("#tips_mail").html("");
    }
    //----
    if($("#auth").val()=="")
    {
        $("#tips_auth").html("验证码不能为空");
        return false;
    }
    else
    {
        $("#tips_auth").html("");
    }
    //----
    return true;
}

//AJAX数据提交返回提示框
function AjaxSubmit(url,type,postvalue,formname,reurl)
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
                        dialogTime('数据操作提交成功！',reurl); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('数据操作提交失败，请联系系统管理员！',reurl);
                    }
                    else
                    {
                        dialogTime(data,reurl);
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

function showlogin(){
   OpenUrl('/commonpage/login_mini.aspx','登录',480,350);   
}

function makeRequest(url, functionName, httpType, sendData,postname) {
    
         $.ajax({ 
               type: httpType, 
               url: url+"?type="+functionName+"&sendData="+sendData,  
                data:$("#v_form").serialize(),                                                       
               success: function (data) { 
                       var objJSON = eval("(" + data + ")");
                       alert(objJSON.msg);
                       if(objJSON.result=='login'){showlogin();}
               }, 
               error: function (XMLHttpRequest, textStatus, errorThrown) { 
                                  dialogTime(' 发生错误，请联系客服！ ',''); } 
         });  
  }
  
   function backtoTop(){
         var $backToTopTxt = "返回顶部", $backToTopEle = $('<div class="backToTop"></div>').appendTo($("body"))
		.text($backToTopTxt).attr("title", $backToTopTxt).click(function() {
			$("html, body").animate({ scrollTop: 0 }, 120);
	    }), $backToTopFun = function() {
		var st = $(document).scrollTop(), winh = $(window).height();
		(st > 0)? $backToTopEle.show(): $backToTopEle.hide();	
		//IE6下的定位
		if (!window.XMLHttpRequest) {
			$backToTopEle.css("top", st + winh - 166);	
	    	}
	    };
	    $(window).bind("scroll", $backToTopFun);
	    $(function() { $backToTopFun(); });   
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
    Idiv.style.left=(document.documentElement.clientWidth-Idiv.clientWidth-160)/2+document.documentElement.scrollLeft+"px";
    Idiv.style.top =(document.documentElement.clientHeight-Idiv.clientHeight-40)/2+document.documentElement.scrollTop-50+"px";

    //以下部分使整个页面至灰不可点击
    var procbg = document.createElement("div"); //首先创建一个div
    procbg.setAttribute("id","mybg"); //定义该div的id
    procbg.style.background = "#000000";
    procbg.style.width = "100%";
    procbg.style.height = "100%";
    procbg.style.position = "fixed";
    procbg.style.top = "0";
    procbg.style.left = "0";
    procbg.style.zIndex = "2147479999";
    procbg.style.opacity = "0.6";
    procbg.style.filter = "Alpha(opacity=50)";
    //背景层加入页面
    document.body.appendChild(procbg);
    document.body.style.overflow = "hidden"; //取消滚动条

}
 
function closeDiv() //关闭弹出层
{
    var Idiv=document.getElementById("Idiv");
    Idiv.style.display="none";
    document.body.style.overflow = "auto"; //恢复页面滚动条
    var body = document.getElementsByTagName("body");
    var mybg = document.getElementById("mybg");
    try
    {
        body[0].removeChild(mybg);
    }
    catch(err)
    {}
}

function CreateKindEditor(textareaid, K, width, height) {
    var editor = K.create('#' + textareaid + '', {
        //上传管理
        uploadJson: '/kindeditor/asp.net/upload_json.ashx',
        //文件管理
        fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
        allowFileManager: true,
        filterMode: false,
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
        afterUpload: function (url) {
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
            'flash', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak'
        ]
    });
    return editor;
}