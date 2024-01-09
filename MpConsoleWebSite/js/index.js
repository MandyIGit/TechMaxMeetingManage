var B=BigNews={current:0,next:0,scrollInterval:0,autoScroller:0,s:{},OnScrolling:false,currentBegin:0};

(function(){

	function $g(item){
		return document.getElementById(item);
	}

	ScrollCrossLeft={interval:0,count:0,duration:0,step:0,srcObj:null,callback:null};
	ScrollCrossLeft.doit=function(obj,b,c,d){
		var s=ScrollCrossLeft;
		var srollL=cpu(s.count,b,c,d);
		obj.style.marginLeft=srollL+'px';
		BigNews.currentBegin=srollL;
		s.count++;
		if(s.count==d){
			clearInterval(s.interval);
			s.count=0;
			obj.style.marginLeft=b+c+'px';
			BigNews.currentBegin=b+c;
			s.callback();
		}
		function cpu(t,b,c,d) {return c*((t=t/d-1)*t*t+1)+b;};
	}

	var B=BigNews={
		current:0,
		next:0,
		scrollInterval:0,
		autoScroller:0,
		s:{},
		f:{},
		t:{},
		OnScrolling:false,
		preCss:"",
		currentBegin:0
	};
	BigNews.turn=function(index,obj){
		if (index==BigNews.current) {
			return false ;
		}
		//clearInterval(BigNews.autoScroller);
		//BigNews.scroll(index,obj);*/
		$g("showDiv_"+BigNews.current).style.display = "none";
		$g("showDiv_"+index).style.zIndex++;
		//$g("showDiv_"+index).style.display="block";
		if ($g("bigpic_"+index).src == 'http://images.movie.xunlei.com/img_default.gif') {
				try {

				setTimeout('$g("bigpic_'+index+'").src = ScrollBigPic['+index+'] ;' , 50) ;
					//$g("bigpic_"+index).onload=function(){$g("loading_"+index).style.display="none";}
					//alert('$g("bigpic_'+index+'").src = ScrollBigPic['+index+'] ;') ;
					//$g("bigpic_"+index).src = ScrollBigPic[index] ;
				}
				catch (e) {}

				
		}
		$g("bigHover").style.marginLeft=(obj.step)*(index%8)+"px";
		BigNews.fadeIn("showDiv_"+index,index,50,obj);
		//BigNews.scroll(index,obj);
		for (var i = 0; i < obj.totalcount; ++i) {
			if (i == index) {
				$g(obj.smallpic + '_on_' + i).className = "on";
			} else {
				$g(obj.smallpic + '_on_' + i).className = "";
			}
		}

		if(index >= 8) {
			 jQuery('#bigNew-left').removeClass('stb1_false');
             jQuery('#bigNew-right').addClass('stb2_false');
		}else{
			 jQuery('#bigNew-left').addClass('stb1_false');
             jQuery('#bigNew-right').removeClass('stb2_false');
		}
        
        if(index == 7){
            if(typeof configs_2062 === 'undefined'){
                return false;
            }
            if(configs_2062.thirdlink){
                sendkkpv(configs_2062.thirdlink);
            }
            if(Math.round(Math.random()*10) == 1){
                sendkkpv(configs_2062.pvLink);
            }
        }
        
        if(index == 8){
            if(typeof configs_2063 === 'undefined'){
                return false;
            }
            if(configs_2063.thirdlink){
                sendkkpv(configs_2063.thirdlink);
            }
            if(Math.round(Math.random()*10) == 1){
                sendkkpv(configs_2063.pvLink);
            }
        }
        
        if(index == 9){
            if(typeof configs_2064 === 'undefined'){
                return false;
            }
            if(configs_2064.thirdlink){
                sendkkpv(configs_2064.thirdlink);
            }
            if(Math.round(Math.random()*10) == 1){
                sendkkpv(configs_2064.pvLink);
            }
        }
        
        if(index == 10){
            if(typeof configs_2065 === 'undefined'){
                return false;
            }
            if(configs_2065.thirdlink){
                sendkkpv(configs_2065.thirdlink);
            }
            if(Math.round(Math.random()*10) == 1){
                sendkkpv(configs_2065.pvLink);
            }
        }
		
	}
	BigNews.fadeIn=function(objid,index,itime,movieObj){ 
			try { clearInterval(BigNews.f.interval);}catch(e){}
			var obj=$g(objid);
			var i = 0; 
			BigNews.f.interval = setInterval(function(){ 
				i+=20; 
				obj.style.filter="alpha(opacity=" + i + ")";
				obj.style.cssText=obj.style.cssText.replace(/;-moz-opacity:.*?;/gi, "") + ";-moz-opacity:" + i*0.01;
				obj.style.cssText=obj.style.cssText.replace(/;opacity:.*?;/gi, "") + ";opacity:" + i*0.01;
				obj.style.display="block"; 
				if(i ==100){
					for(var kk=0;kk<movieObj.totalcount;kk++)
					{
						$g("showDiv_"+kk).style.cssText=BigNews.preCss;
						if(kk==index)
						{
							$g("showDiv_"+kk).style.display="block";
							BigNews.showTitles(index,movieObj);
						}
						else
						{
							$g("showDiv_"+kk).style.display="none";
						}
						$g("showDiv_"+index).style.zIndex=0; 
					}

					BigNews.current=index;
					clearInterval(BigNews.f.interval);
				} 
			},itime); 
	} 
	BigNews.showTitles=function(index,movieObj) {
			for (var j = 0; j < movieObj.totalcount; j++) {
				if (j == index) {
					$g("title_bg_"+j).style.display = "block";
					$g("title_"+j).style.display = "block";
				} else {
					$g("title_bg_"+j).style.display = "none";
					$g("title_"+j).style.display = "none";
				}
			}
	}
	BigNews.scroll=function(index,obj){
		
		var count=0;
		var step=obj.step;
		var duration=16;
		var b=BigNews;
		b.next=index;
		if(index!=b.current&&count>duration/8){
			return;
		}
		try { clearInterval(BigNews.s.interval);}catch(e){}
		
		
		var begin_value=$g(obj.hover).scrollLeft;
		var chang_in_value=span*step+(b.current*step-begin_value);


		BigNews.s.duration=duration;
		BigNews.s.callback=cb;
		var beign = parseInt(BigNews.currentBegin);
		var span=index*step-beign;

		BigNews.s.interval=setInterval(function(){BigNews.s.doit($g(obj.hover),beign,span,duration)},8);
		//b.current=index;
		function cb() {
			
		}
	}
	BigNews.auto=function(obj){
		
		clearInterval(BigNews.autoScroller);
		BigNews.autoScroller=setInterval(function(){
			if(BigNews.current == 15){
				jQuery('#scrollimg_tigger_img').animate({ marginLeft:0 },1000);
				jQuery('#scrollimg_tigger_link').animate({ marginLeft:0 },1000);
			}else if(BigNews.current == 7){
				jQuery('#scrollimg_tigger_img').animate({ marginLeft:"-664px" },1000);
				jQuery('#scrollimg_tigger_link').animate({ marginLeft:"-664px" },1000);
			}
			BigNews.turn(BigNews.current==(obj.totalcount-1)?0:BigNews.current+1,obj);
		},obj.autotimeintval);
	}
	BigNews.pauseSwitch = function() {	
		clearTimeout(BigNews.autoScroller);
	}
	BigNews.showNext = function(current,obj) {	
		if (current >=  MovieRecom.totalcount -1) {
			BigNews.pauseSwitch();
			BigNews.turn(0,obj);
			BigNews.auto(obj);
			return false ;
		}
		else {
			BigNews.pauseSwitch();
			BigNews.turn(current+1,obj);
			BigNews.auto(obj);
			//document.body.focus();
		}
		
	}
	BigNews.showPre = function(current,obj) {
		if (current <=  0) {
			BigNews.pauseSwitch();
			BigNews.turn(MovieRecom.totalcount -1,obj);
			BigNews.auto(obj);
			return false ;
		}
		else {
			BigNews.pauseSwitch();
			BigNews.turn(current-1,obj);
			BigNews.auto(obj);
			//document.body.focus();
		}
		
	}
	BigNews.init=function(obj){
		BigNews.s=ScrollCrossLeft;
		//$g(obj.bigpic).onmouseover = new Function("BigNews.pauseSwitch();") ;		
		//$g(obj.bigpic).onmouseout = new Function("BigNews.auto("+obj.objname+");") ;	
		BigNews.preCss=obj.css;

		EventUtil.addEventHandler($g(obj.bigpic),'mouseover',new Function("BigNews.pauseSwitch();"));
		EventUtil.addEventHandler($g(obj.bigpic),'mouseout',new Function("BigNews.auto("+obj.objname+");"));


		for (i=0;i<obj.totalcount;i++) {
			if(obj.smallpic!=null && obj.smallpic!="") {		
			 EventUtil.addEventHandler($g(obj.smallpic+"_"+i),'mouseover',new Function("BigNews.pauseSwitch();BigNews.turn("+i+","+obj.objname+");"));
			 EventUtil.addEventHandler($g(obj.smallpic+"_"+i),'mouseout',new Function("BigNews.auto("+obj.objname+");"));
			}
		}
		BigNews.showTitles(0,obj);
		BigNews.auto(obj);
	}

})();


var LAZY = LAZY || {};
LAZY=(function(){
	var pResizeTimer = null;
	var imgs={};
	function resize(){
		if(pResizeTimer) return '';
		resize_run();
	}
	function resize_run(){
		var min={};
		var max={};
		//min.Top=document.documentElement.scrollTop;
        min.Top = document.body.scrollTop + document.documentElement.scrollTop;
		min.Left=document.documentElement.scrollLeft;
		max.Top=min.Top+document.documentElement.clientHeight;
		max.Left=min.Left+document.documentElement.clientWidth;

		for(var i in imgs){
			if(imgs[i]){
				var _img=imgs[i];
				var img=document.getElementById(i);
				var width = img.clientWidth;
				var height = img.clientHeight;
				var wh=position(img);
				if(
					(wh.Top>=min.Top && wh.Top<=max.Top && wh.Left>=min.Left && wh.Left<=max.Left)
					||
					((wh.Top+height)>=min.Top && wh.Top<=max.Top && (wh.Left+width)>=min.Left && wh.Left<=max.Left))
				{
					//img.src=_img.src;
					//alert("document.getElementById(\""+i+"\").src=\""+_img.src+"\";") ;
					//setTimeout("document.getElementById(\""+i+"\").src=\""+_img.src+"\";",100) ;

					(function(imgobj,realsrc){
						setTimeout(
							function() {imgobj.src = realsrc ;}, 100
							) ;
					})(img,_img.src) ;
					delete imgs[i];
				}

			}
		}
	}

	function position(o){
		var p={Top:0,Left:0};
		while(!!o){
			p.Top+=o.offsetTop;
			p.Left+=o.offsetLeft;
			o=o.offsetParent;
		}
		return p;
	}
	
	return {
		init:function(){
			for(var i=0;i<document.images.length;i++){
				var img = document.images[i];
				var config={};
				config.id = img.id;
				config.src = img.getAttribute('_src');
				if(config.src && !config.id){
					config.id = encodeURIComponent(config.src) + Math.random();
					img.id = config.id;
				}
				if(!config.id || !config.src) continue;
				LAZY.push(config);
			}
			var ttiframes=document.body.getElementsByTagName("iframe");
			for(var i=0;i<ttiframes.length;i++){
				var config={};
				config.id = ttiframes[i].id;
				config.src = ttiframes[i].getAttribute('_src');
				if(config.src && !config.id){
					config.id = encodeURIComponent(config.src) + Math.random();
					ttiframes[i].id = config.id;
				}
				if(!config.id || !config.src) continue;
				LAZY.push(config);
			}
		},
		push:function(config){
			imgs[config.id] = config;
		},
		run:function(){
			EventUtil.addEventHandler(window,'scroll',resize);
			resize_run();
			//addEventHandler(window,'resize',resize);
		}
	};
})();

function switchItem(str,total,t){
	for(var i=0;i<total;i++){
		if(i==t){
			document.getElementById(str+"_L_"+i).style.display="";
			document.getElementById(str+"_S_"+i).style.display="none";
			try{
				if(document.getElementById(str+"_pic_"+i).getAttribute('src')!=document.getElementById(str+"_pic_"+i).getAttribute('_src')){
					document.getElementById(str+"_pic_"+i).setAttribute("src",document.getElementById(str+"_pic_"+i).getAttribute('_src'))
				}
			}catch(e){}
			
		}else{
			document.getElementById(str+"_L_"+i).style.display="none";
			document.getElementById(str+"_S_"+i).style.display="";
		}
	}
}

var $ = jQuery;
function switchTab2(identify,index,count,cnon,cnout) {
	try{
		for(i=0;i<count;i++) {
			var CurTabObj = document.getElementById("Tab_"+identify+"_"+i) ;
			var CurListObj = document.getElementById("List_"+identify+"_"+i) ;
			if (i != index) {
				CurTabObj.className=cnout ;
				CurListObj.style.display="none" ;
			}
		}
		try {
			$("#List_"+identify+"_"+index + " img").each(function(index,item){
						if($(item).attr('src') != $(item).attr('_src')){
							$(item).attr('src',$(item).attr('_src'));
						}
			});

		}
		catch (e) {}
		
		document.getElementById("Tab_"+identify+"_"+index).className=cnon ;
		document.getElementById("List_"+identify+"_"+index).style.display="";
	}catch (ee) {}
}

var D=Detail={};


Detail.show = function (name,desc,director,actors,focus){
	if(D.len(focus)>46){
		focus=focus.substr(0,23)+'...';
	}
	/*if(D.len(actors)>26){
		actors=actors.substr(0,12)+'...';
	}*/
	var html='' ;
	html += '<h4>'+name+'<span>('+desc+')</span></h4>';
	html += '<ul>';
	html += '<li>导演:<span>'+director+'</span></li>';
	var actortext="";
	for(var k=0;k<actors.length;k++){
		if(actors[k]!=""){
			actortext+=actors[k]+" "
		}
	}
	html += '<li class="li_2">主演:'+actortext+'</li>';
	html += '</ul>';
	html += '<p>'+focus+'</p>';
	
	$g('div_tip_detail').innerHTML=html;
	var p=KK.position(event.srcElement);
	var tip=$g('div_tip_detail');
	tip.style.zIndex='99';
	tip.style.display='';

	tip.style.top=p.Top+'px';
	if (p.Left > 1000) {
		tip.style.left=p.Left-226+'px';
	}else {
		tip.style.left=p.Left+102+'px';
	}
	
}
Detail.actor=function (str,len,spliter){
	spliter=spliter||'|';
	var arr=str.split(spliter);
	var temp='';
	for(var i=0;i<arr.length;i++){
		temp+=arr[i]+'&nbsp;';
		if(D.len(temp)<len){
			str=temp;
		}else{
			break;
		}
	}
	return str;
}
Detail.ac_search=function (str,len,spliter){
	spliter=spliter||'|';
	var arr=str.split(spliter);
	var temp=html='';
	var l=Math.min(2,arr.length);
	for(var i=0;i<l;i++){
		temp=arr[i]+'&nbsp;';
		html+='<a style="color:#007EBC" href="http://video.gougou.com/search?s='+arr[i]+'&id=35&fr=2" title="'+arr[i]+'" target="_blank">'+arr[i]+'</a>'+'&nbsp;';
		if(D.len(temp)<30){
			str=html;
		}else{
			break;
		}
	}
	return str;
}
Detail.hide=function (){
	$g('div_tip_detail').style.display='none';
}
Detail.len=function (str){
	var l=0;
	var sl=str.length
	for(var i=0;i<sl;i++){
		l++;
   		if (str.charCodeAt(i)>256) l++;
	}
	return l;
}