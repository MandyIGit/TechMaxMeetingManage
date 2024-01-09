
 function settex(id,value){
    $("#"+id).val(value);
 }
 
 function Setcheckbox(i){
   $("input:checkbox "+i).val(i);
 }
 function setradio(name,value){
    $("input:radio[name="+name+"][value="+value+"]").atrr("checked","checked");
 }
 
 function setselect(id,value){
    $("#"+id).find("option[value='"+value+"']").attr("selected",true);    
 }
 
 function getAll(checkallid,checksname){
    var r=$("#checkallid").attr("checked");
    var checkboxs=$("checksname");
    for (var i=0;i<checkboxs.length;i++){ var e=checkboxs[i]; e.checked=r;}
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
                                  } 
         });  
  }
  