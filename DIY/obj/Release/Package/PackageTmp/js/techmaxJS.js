//��ʱ������,contentsΪ����������,urlΪ������رպ���ת��ҳ��,�粻�������ʹ���
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
                that.title(i + '���ر�');
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
                that.title(i + '���ر�');
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
                that.title(i + '���ر�');
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
 
//��������
function getID(id)
{
    return $("#"+id+"");
}
//ajax post����,������ȡ��Ϣ
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
       var dataObj=eval("("+data+")");//ת��Ϊjson����
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
//ִ��AJAX��Ϣ���֮����ִ����������
function ajaxPostFun(url,type,postvalue,id,funname)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
        getID(id).html(data);
        eval(funname+"();");//�ص�
    });
}
function ajaxPostText(url,type,postvalue,id)
{ 
    $.post(url,{'type':type,'datetiem':new Date().getTime(),'postvalue':postvalue},function (data)
    {
       getID(id).val(data);
    });
}
 //ȫѡ
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
//�½��б���Ŀ�ֵ
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
 //��ȡҳ�����
     function GetRequest() {

    var url = location.search; //��ȡurl��"?"������ִ�

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

//�ж�ע����Ϣ������
function CheckRegist()
{
    if($("#loginid").val()=="")
    {
        $("#tips_loginid").html("�û�������Ϊ��");
        return false;
    }
    else
    {
        $("#tips_loginid").html("");
    } 
    //-----
    if($("#loginpwd").val()=="")
    {
        $("#tips_loginpwd").html("���벻��Ϊ��");
        return false;
    }
    else
    {
        $("#tips_loginpwd").html("");
    }
    //------
    if($("#loginpwd2").val()=="")
    {
        $("#tips_loginpwd2").html("�������벻һ��");
        return false;
    }
    else
    {
        $("#tips_loginpwd2").html("");
    }
    //----
    if($("#loginpwd2").val()!=$("#loginpwd").val())
    {
        $("#tips_loginpwd2").html("�������벻һ��");
        return false;
    }    
    else
    {
        $("#tips_loginpwd2").html("");
    }
    //----
    if($("#uname").val()=="")
    {
        $("#tips_uname").html("��������Ϊ��");
        return false;
    }
    else
    {
        $("#tips_uname").html("");
    }
    //----
    if($("input[name='gender']:checked").val()==null)
    {
        $("#tips_gender").html("��ѡ���Ա�");
        return false;
    }
    else
    {
        $("#tips_gender").html("");
    }
    //----
    if($("#datebirth").val()=="")
    {
        $("#tips_datebirth").html("�������²���Ϊ��");
        return false;
    }
    else
    {
        $("#tips_datebirth").html("");
    }
    //----
    if($("#address").val()=="")
    {
        $("#tips_address").html("��ַ����Ϊ��");
        return false;
    }
    else
    {
        $("#tips_address").html("");
    }
    //----
    if($("#mobilephone").val()=="")
    {
        $("#tips_mobilephone").html("�ֻ����벻��Ϊ��");
        return false;
    }
    else
    {
        $("#tips_mobilephone").html("");
    }
    //----
    if($("#mail").val()=="")
    {
        $("#tips_mail").html("�����ʼ�����Ϊ��");
        return false;
    }
    else
    {
        $("#tips_mail").html("");
    }
    //----
    if($("#auth").val()=="")
    {
        $("#tips_auth").html("��֤�벻��Ϊ��");
        return false;
    }
    else
    {
        $("#tips_auth").html("");
    }
    //----
    return true;
}

//AJAX�����ύ������ʾ��
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
                        dialogTime('���ݲ����ύ�ɹ���',reurl); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('���ݲ����ύʧ�ܣ�����ϵϵͳ����Ա��',reurl);
                    }
                    else
                    {
                        dialogTime(data,reurl);
                    }
              }
      });
}

//AJAX�����ύ���ݷ��������������
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
//AJAX�����ύ���ݷ��������������,��������Ӧ�ĺ���
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
                 eval(funname+"();");//�ص�
                }
      });
}
//AJAX�����ύ���ݽ��ִ����Ӧ�ĺ��� funnameΪҪִ�еķ�������
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
                 eval(funname+"();");//�ص�
                }
      });
}
//AJAX�����ύ������ʾ��
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
                         dialogTimeClose('���ݲ����ύ�ɹ���','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('���ݲ����ύʧ�ܣ�����ϵϵͳ����Ա��',''); 
                    }
              }
      });
}
//AJAX�����ύ�������ʼ�ʹ��
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
                        dialogTimeClose('���ͳɹ���','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('����ʧ�ܣ�����ϵϵͳ����Ա��',''); 
                    }
              }
      });
}
//AJAX�����ύ�����Ͷ���ʹ��
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
                        dialogTimeClose('���ͳɹ���','',"yes"); 
                    }
                    else if(data=="suc_err")
                    {
                        dialogTime('����ʧ�ܣ�����ϵϵͳ����Ա��',''); 
                    }
              }
      });
}
//��ҳ��
function OpenUrl(url,title,width,height)
{
    art.dialog.open(url,{title:title,width:width,height:height,drag: true,resize:true,fixed:true});
}
//ֻ������������С��
function txtKeyUpDecimal(txtName)
{
    getID(txtName).keyup(function(){  //keyup�¼����� 
        $(this).val($(this).val().replace(/[^0-9\.]/g,''));  
    }).bind("paste",function(){  //CTR+V�¼����� 
        $(this).val($(this).val().replace(/[^0-9\.]/g,''));  
    }).css("ime-mode", "disabled");  //CSS�������뷨������
}
//ֻ����������
function txtKeyUp(txtName)
{
     getID(txtName).keyup(function(){  //keyup�¼����� 
        $(this).val($(this).val().replace(/^0{2}|\D|/g,''));  
    }).bind("paste",function(){  //CTR+V�¼����� 
        $(this).val($(this).val().replace(/^0{2}|\D|/g,''));  
    }).css("ime-mode", "disabled");  //CSS�������뷨������
}
//ֻ���������ָ�Ӣ�Ķ���
function txtphone(txtName)
{
    getID(txtName).keyup(function(){  //keyup�¼����� 
        $(this).val($(this).val().replace(/[^0-9\,]/g,''));  
    }).bind("paste",function(){  //CTR+V�¼����� 
        $(this).val($(this).val().replace(/[^0-9\,]/g,''));  
    }).css("ime-mode", "disabled");  //CSS�������뷨������
}
//��̬��������б�����
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
            eval(funname+"();");//�ص�
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
//������ʾ
function ATitle()
{
 $("a[title]").poshytip({
        className: 'tip-green',
        offsetX: -7,
        offsetY: 16,
        allowTipHover: false
        });
}

//�½��б���Ŀ�ֵ���������������б�
function GetSelChangeCity(txtname,selname)
{
    getID(txtname).attr({'value':''});
    getID(txtname).attr({'value':getID(selname).val()});
    ajaxPost("/AjaxResponse/tech_userHandler.ashx","18",getID(selname).val(),"city_select");
}

function showlogin(){
   OpenUrl('/commonpage/login_mini.aspx','��¼',480,350);   
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
                                  dialogTime(' ������������ϵ�ͷ��� ',''); } 
         });  
  }
  
   function backtoTop(){
         var $backToTopTxt = "���ض���", $backToTopEle = $('<div class="backToTop"></div>').appendTo($("body"))
		.text($backToTopTxt).attr("title", $backToTopTxt).click(function() {
			$("html, body").animate({ scrollTop: 0 }, 120);
	    }), $backToTopFun = function() {
		var st = $(document).scrollTop(), winh = $(window).height();
		(st > 0)? $backToTopEle.show(): $backToTopEle.hide();	
		//IE6�µĶ�λ
		if (!window.XMLHttpRequest) {
			$backToTopEle.css("top", st + winh - 166);	
	    	}
	    };
	    $(window).bind("scroll", $backToTopFun);
	    $(function() { $backToTopFun(); });   
      } 
/*
 * ����DIV��
 */
function showDiv()
{
    var Idiv = document.getElementById("Idiv");
    var mou_head = document.getElementById('mou_head');
    Idiv.style.display = "block";
    //���²���Ҫ�������������ʾ
    Idiv.style.left=(document.documentElement.clientWidth-Idiv.clientWidth-160)/2+document.documentElement.scrollLeft+"px";
    Idiv.style.top =(document.documentElement.clientHeight-Idiv.clientHeight-40)/2+document.documentElement.scrollTop-50+"px";

    //���²���ʹ����ҳ�����Ҳ��ɵ��
    var procbg = document.createElement("div"); //���ȴ���һ��div
    procbg.setAttribute("id","mybg"); //�����div��id
    procbg.style.background = "#000000";
    procbg.style.width = "100%";
    procbg.style.height = "100%";
    procbg.style.position = "fixed";
    procbg.style.top = "0";
    procbg.style.left = "0";
    procbg.style.zIndex = "2147479999";
    procbg.style.opacity = "0.6";
    procbg.style.filter = "Alpha(opacity=50)";
    //���������ҳ��
    document.body.appendChild(procbg);
    document.body.style.overflow = "hidden"; //ȡ��������

}
 
function closeDiv() //�رյ�����
{
    var Idiv=document.getElementById("Idiv");
    Idiv.style.display="none";
    document.body.style.overflow = "auto"; //�ָ�ҳ�������
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
        //�ϴ�����
        uploadJson: '/kindeditor/asp.net/upload_json.ashx',
        //�ļ�����
        fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx',
        allowFileManager: true,
        filterMode: false,
        //���ñ༭��������ִ�еĻص�����
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
        //�ϴ��ļ���ִ�еĻص�����,��ȡ�ϴ�ͼƬ��·��
        afterUpload: function (url) {
            //alert(url);
        },
        //�༭���߶�
        width: width,
        //�༭�����
        height: height,
        //���ñ༭���Ĺ�����
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