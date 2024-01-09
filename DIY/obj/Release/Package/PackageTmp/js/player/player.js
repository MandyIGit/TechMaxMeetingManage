function play(v)
{
	video_index = v;
	getPlayList(v);
	getMyPlayer(videos[v].url);	
}

function getPlayList(step)
{
    for(var i=0; i<count; i++)
    {
        document.getElementById('current_' + i).className = '';
        if (step == i)
        {
            document.getElementById('current_' + i).className = 'current';
        }
    }
	document.getElementById('playing').innerHTML = videos[step].title;
	document.getElementById('descript').innerHTML = videos[step].des;

}

function getMyPlayer(v)
{
	var swf = v +'&auto=1&r='+ Math.random(); 
	var id = 'vplayer';
	var width = 615;
	var height = 400;
	var JcScpStageW2= 615;
	var JcScpStageH2 = 400;
 
	var JcScpFile = 'CuSunV2set.asp';

	var _html = '';
		_html += '<object id="'+id+'" name="'+id+'" width="'+width+'" height="'+height+'" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0">';
		_html += '<param name="movie" value="'+swf+'"/>';
		_html += '<param name="allowFullScreen" value="true" />';
		_html += '<param name="allowScriptAccess" value="always" />';
		_html += '<param name="salign" value="lt"/>';
		_html += '<param name="quality" value="high"/>';
		_html += '<param name="bgcolor" value="#000000"/>';
		//_html += '<param name="wmode" value="transparent"/>';
		_html += '<param name="FlashVars" value="&JcScpFile='+JcScpFile+'"/>';
		_html += '<embed src="'+swf+'" flashvars="&JcScpFile='+JcScpFile+'" quality="high" scale="noscale" width="'+width+'" height="'+height+'" id="'+id+'" name="'+id+'" bgcolor="#000000" wmode="transparent" salign="LT" type="application/x-shockwave-flash" allowFullScreen="true" pluginspage="http://www.macromedia.com/go/getflashplayer"/>'+'</object>';
		document.getElementById('CuPlayer').innerHTML = _html;
}

play(0);