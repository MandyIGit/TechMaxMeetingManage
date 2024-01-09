
typeof window.kkList == "undefined" && (window.kkList = {});

kkList.$ = function(id){
	return document.getElementById(id);
}

Array.prototype.in_array = function(e){   
	for(i=0;i<this.length;i++){   
		if(this[i].name == e)   
		return true;   
	}   
	return false;   
} 

kkList.TagList={
	switchMore : function(id){
		try{
			var classname = kkList.$("taglist_div_"+id).className;
			if(classname == "taglist_outer"){
				kkList.TagList.showMore(id);
			}else{
				kkList.TagList.hideMore(id);
			}
			kkList.pv.send("u=sum&u1=type&u2=screen-"+kkList.channel_type+"&u3="+id);
			return true;
		}catch(e){
			return false;
		}
	},
	showMore : function(id){
		kkList.$("taglist_div_"+id).className = "taglist_outer taglist_show";
		kkList.$("taglist_switch_"+id).className = "more_tag more_tag_on";
		kkList.TagList.recordId(id,1);
		return true;
	},
	hideMore : function(id){
		kkList.$("taglist_div_"+id).className = "taglist_outer";
		kkList.$("taglist_switch_"+id).className = "more_tag";
		kkList.TagList.recordId(id,0);
		return true;
	},
	switchAll : function(){
		try{
			var display = kkList.$("taglist_more_div").style.display;
			if(display == 'none'){
				kkList.TagList.showAll();
			}else{
				kkList.TagList.hideAll();
			}
			kkList.scroll.height = kkList.scroll.getTop(kkList.$("results_big_box"));
			kkList.pv.send("u=sum&u1=type&u2=screen-"+kkList.channel_type+"&u3=0");
			return true;
		}catch(e){
			return false;
		}
	},
	showAll : function(){
		kkList.$("taglist_more_div").style.display='';
		kkList.$("taglist_more_switch").className = "tagtigger tagtigger_on";
		kkList.$("taglist_more_switch_inner").innerHTML = "收起更多<b></b>";
		kkList.TagList.recordId(0,1);
		return true;
	},
	hideAll : function(){
		kkList.$("taglist_more_div").style.display='none';
		kkList.$("taglist_more_switch").className = "tagtigger";
		kkList.$("taglist_more_switch_inner").innerHTML = "展开更多<b></b>";
		kkList.TagList.recordId(0,0);
		return true;
	},
	recordId : function(id,status){
		var ids = kkList.TagList.getId();
		var len = ids.length;
		if(status){
			if(len <= 0){
				kkList.TagList.setId([id]);
				return;
			} 
			while(len--){
				if(ids[len] == id){
					kkList.TagList.setId(ids);
					return;
				}
			}
			ids.push(id);
			kkList.TagList.setId(ids);
			return;
		}else{
			if(len <= 0){
				kkList.TagList.setId('');
				return;
			}
			while(len--){
				if(ids[len] == id){
					ids.splice(len,1);
				}
			}
			kkList.TagList.setId(ids);
			return;
		}
	},
	setId : function(ids){
		if(ids == '' || ids.length <1){
			var idstr = '';
		}else{
			var idstr = ids.join(',')
		}
		return kkTool.Cookie.set('kklist_taglist_status',idstr);
	},
	getId : function(){
		var ids = [];
		var idstr = kkTool.Cookie.get('kklist_taglist_status');
		if(idstr != ''){
			ids = idstr.split(',');
		}
		return ids;
	},
	setType : function(type){
		return kkTool.Cookie.set('kklist_channel_type',type);
	},
	getType : function(){
		return kkTool.Cookie.get('kklist_channel_type');
	},
	init : function(){
		if(kkList.TagList.getType() != kkList.channel_type){
			kkList.TagList.setId('');
			kkList.TagList.setType(kkList.channel_type);
		}else{
			var ids = kkList.TagList.getId();
			for(var i=0; i<ids.length; i++){
				var id=ids[i];
				if(id == 0){
					kkList.TagList.showAll();
				}else{
					try{
						kkList.TagList.showMore(id);
					}catch(e){
						kkList.TagList.recordId(id,0);
					}
					
				}
				
			}
		}
	}
};

kkList.movieList = {
	curid : 0,
	display : 0,
	handler : null,
	height : -86,
	over : function(id){
			this.display = 1;
			if(this.curid == id){
				return;
			}else{
				this.curid = id;
				setTimeout(function(){kkList.movieList.show(id)},600);
			}
			
	},
	out : function(id){
		if(this.curid != id && this.display){
			this.display = 0;
			this.hide(id);
		}else{
			this.display = 0;
			setTimeout(function(){kkList.movieList.show(id)},100);
		}
	},
	show : function(id){
		if(id==this.curid && this.display ==1){
			if(this.handler == null){
				kkList.$("movie_list_li_"+id).className = "on"
				try{
					var t = parseInt(kkList.$("movie_list_div_"+id).style.bottom.replace('px',''));
					if(t<-86){t=-86}
				}catch(e){
					var t = -86;
				}
				this.height = t;
				this.handler = setInterval(function(){kkList.movieList.grow(id)},10)
			}
		}else{
			clearInterval(this.handler);
			this.handler = null;
			this.hide(id);
		}
	},
	hide : function(id){
		kkList.$("movie_list_li_"+id).className = ""
		kkList.$("movie_list_div_"+id).style.bottom = "-109px";
	},
	grow : function(id){
		this.height = parseInt(this.height);
		if(this.height >0) this.height =0;
		kkList.$("movie_list_div_"+id).style.bottom = this.height + "px";
		if(this.height>=0){
			clearInterval(this.handler);
			this.handler = null;
			this.height = -86;
		}
		this.height += 5;
	}

};

