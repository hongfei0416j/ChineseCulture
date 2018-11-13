// JavaScript Document
$('#selAll_A').on('change',function(){
	if ($("#selAll_A").prop("checked")) { 
		$(".itemA").prop("checked",true);//全选
	} else {      
		$(".itemA").prop("checked",false);  //取消全选
	}
})
$(".itemA").click(function(){
	var flag=true;
	if(!this.checked){
		$("#selAll_A").prop("checked",false);
	}else{
		for(var i=0; i<$('.itemA').length; i++){
			if($('.itemA:eq('+i+')').prop('checked')==false){
				flag=false;
			}
		}
		$("#selAll_A").prop("checked",flag);
	}
});
$('#selAll_B').on('change',function(){
	if ($("#selAll_B").prop("checked")) { 
		$(".itemB").prop("checked",true);//全选
	} else {      
		$(".itemB").prop("checked",false);  //取消全选
	}
})
$(".itemB").click(function(){
	var flag=true;
	if(!this.checked){
		$("#selAll_B").prop("checked",false);
	}else{
		for(var i=0; i<$('.itemB').length; i++){
			if($('.itemB:eq('+i+')').prop('checked')==false){
				flag=false;
			}
		}
		$("#selAll_B").prop("checked",flag);
	}
});
$('#selAll_C').on('change',function(){
	if ($("#selAll_C").prop("checked")) { 
		$(".itemC").prop("checked",true);//全选
	} else {      
		$(".itemC").prop("checked",false);  //取消全选
	}
})
$(".itemC").click(function(){
	var flag=true;
	if(!this.checked){
		$("#selAll_C").prop("checked",false);
	}else{
		for(var i=0; i<$('.itemC').length; i++){
			if($('.itemC:eq('+i+')').prop('checked')==false){
				flag=false;
			}
		}
		$("#selAll_C").prop("checked",flag);
	}
});
$('#selAll_D').on('change',function(){
	if ($("#selAll_D").prop("checked")) { 
		$(".itemD").prop("checked",true);//全选
	} else {      
		$(".itemD").prop("checked",false);  //取消全选
	}
})
$(".itemD").click(function(){
	var flag=true;
	if(!this.checked){
		$("#selAll_D").prop("checked",false);
	}else{
		for(var i=0; i<$('.itemD').length; i++){
			if($('.itemD:eq('+i+')').prop('checked')==false){
				flag=false;
			}
		}
		$("#selAll_D").prop("checked",flag);
	}
});