// JavaScript Document

// Distributed by http://www.hypergurl.com // Scrollers width here (in pixels) 
var scrollerwidth="220px"; // Scrollers height here 
var scrollerheight="100px" ;
// Scrollers speed here (larger is faster 1-10) 
var scrollerspeed=0.25;
 // Scrollers content goes here! Keep all of the message on the same line! 
 var scrollercontent='<p><a href="#">In his speech greeting the delegates of the 20th CPI-M party congress which began in Kozhikode</a></p>'+
 '<p><a href="#">In his speech greeting the delegates of the 20th CPI-M party congress which began in Kozhikode1</a></p>'+

 '<p><a href="#">In his speech greeting the delegates of the 20th CPI-M party congress which began in Kozhikode2</a></p>'+

 '<p><a href="#">In his speech greeting the delegates of the 20th CPI-M party congress which began in Kozhikode3</a></p>'+

 '<p><a href="#">In his speech greeting the delegates of the 20th CPI-M party congress which began in Kozhikode4</a></p>' ;
 
 var pauseit=1; // Change nothing below! 
 scrollerspeed=(document.all)? scrollerspeed : Math.max(1, scrollerspeed-1); //slow speed down by 1 for NS 
 var copyspeed=scrollerspeed ;
 var iedom=document.all||document.getElementById ;
 var actualheight='' ;
var cross_scroller, ns_scroller ;
var pausespeed=(pauseit==0)? copyspeed: 0 ;
function populate()
{ 
	if (iedom){
		cross_scroller = document.getElementById ? document.getElementById("iescroller") : document.all.iescroller;
		cross_scroller.style.top=parseInt(scrollerheight)+8+"px"; 
		cross_scroller.innerHTML=scrollercontent;
		actualheight=cross_scroller.offsetHeight; 
	} else if (document.layers){ 
		ns_scroller=document.ns_scroller.document.ns_scroller2 ;
		ns_scroller.top=parseInt(scrollerheight)+2 ;
		ns_scroller.document.write(scrollercontent) ;
		ns_scroller.document.close();
		actualheight=ns_scroller.document.height;
	} lefttime=setInterval("scrollscroller()",50) ;
} window.onload=populate;
 function scrollscroller(){ 
 if (iedom){ 
 	if ( parseInt(cross_scroller.style.top)>(actualheight*(-1)+8) )
		cross_scroller.style.top=parseInt(cross_scroller.style.top)-copyspeed+"px" ;
		else cross_scroller.style.top=parseInt(scrollerheight)+8+"px";
	 } else 
		if (document.layers){ 
			if (ns_scroller.top>(actualheight*(-1)+8))
				ns_scroller.top-=copyspeed ;
			else ns_scroller.top=parseInt(scrollerheight)+8;
			 } 
		} if (iedom||document.layers){ 
		with (document){ if (iedom){ 
		write('<div style="position:relative;width:'+scrollerwidth+';height:'+scrollerheight+';overflow:hidden"	onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=scrollerspeed">') ;
write('<div id="iescroller" style="position:absolute;left:0px;top:0px;width:100%;">'); 
write('</div></div>');
 } else if (document.layers){ write('<ilayer width='+scrollerwidth+' height='+scrollerheight+' name="ns_scroller">') ;
write('<layer name="ns_scroller" width='+scrollerwidth+' height='+scrollerheight+' left=0 top=0 onMouseover="copyspeed=pausespeed" onMouseout="copyspeed=scrollerspeed"></layer>') ;
write('</ilayer>'); } } }