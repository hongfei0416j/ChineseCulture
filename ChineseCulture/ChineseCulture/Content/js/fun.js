$(function() {
	var video=document.getElementById('video');
	$('.col1-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col1-item').css('display','none').eq($('.col1-tab > p').index(this)).css('display','block');
		video.pause();
	});	
	$('.col2-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col2-item').css('display','none').eq($('.col2-tab > p').index(this)).css('display','block');
	});	
	$('.col3-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col3-item').css('display','none').eq($('.col3-tab > p').index(this)).css('display','block');
	});	
	$('.col4-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col4-item').css('display','none').eq($('.col4-tab > p').index(this)).css('display','block');
	});	
	$('.col5-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col5-item').css('display','none').eq($('.col5-tab > p').index(this)).css('display','block');
	});	
	$('.col6-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.col6-item').css('display','none').eq($('.col6-tab > p').index(this)).css('display','block');
	});	
	$('.jobs-tabs > ul > li > p > span').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		
	});	
	
	$('.baoming-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		if($('.baoming-tab > p').index(this)==1){
			$('.school-form,.scholl-user').css('display','block');
		}else{
			$('.school-form,.scholl-user').css('display','none');
		}
		$('.bm-form').css('display','none').eq($('.baoming-tab > p').index(this)).css('display','block');
	});	
	$('.bm-item-sellist > p').on('click',function(){
		//alert($(this).find('span').text());
		$(this).parent().parent().find('input').val($(this).find('span').text());
		$(this).parent().parent().find('h3').html($(this).html());
		$(this).parent().css('display','none');
	});
	
	$('.jl-tabs > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.jlc-item').css('display','none').eq($('.jl-tabs > p').index(this)).css('display','block');
	});	
	$('#selAll').on('change',function(){
		//$("#selAll2").prop("checked",this.checked);
		if ($("#selAll").prop("checked")) { 
			//console.log(2);           
			$(".chkitem").prop("checked",true);//全选
			$("#selAll2").prop("checked",true);
		} else { 
			//console.log(3);               
			$(".chkitem").prop("checked",false);  //取消全选
			$("#selAll2").prop("checked",false);
		}
	})
	$('#selAll2').on('change',function(){
		//$("#selAll2").prop("checked",this.checked);
		if ($("#selAll2").prop("checked")) { 
			//console.log(2);           
			$(".chkitem").prop("checked",true);//全选
			$("#selAll").prop("checked",true);
		} else { 
			//console.log(3);               
			$(".chkitem").prop("checked",false);  //取消全选
			$("#selAll").prop("checked",false);
		}
	})
	$(".chkitem").click(function(){
		//console.log(this.checked);
		var flag=true;
		if(!this.checked){
			$("#selAll").prop("checked",false);
			$("#selAll2").prop("checked",false);
		}else{
			//console.log($('.chkitem').length)
			for(var i=0; i<$('.chkitem').length; i++){
				//console.log(i+':'+$('.chkitem:eq('+i+')').prop('checked'));
				if($('.chkitem:eq('+i+')').prop('checked')==false){
					flag=false;
				}
			}
			$("#selAll").prop("checked",flag);
			$("#selAll2").prop("checked",flag);
		}
	});
	
	$('#selAllq').on('change',function(){
		//$("#selAll2").prop("checked",this.checked);
		if ($("#selAllq").prop("checked")) { 
			//console.log(2);           
			$(".chkitemq").prop("checked",true);//全选
			$("#selAll2q").prop("checked",true);
		} else { 
			//console.log(3);               
			$(".chkitemq").prop("checked",false);  //取消全选
			$("#selAll2q").prop("checked",false);
		}
	})
	$('#selAll2q').on('change',function(){
		//$("#selAll2").prop("checked",this.checked);
		if ($("#selAll2").prop("checked")) { 
			//console.log(2);           
			$(".chkitemq").prop("checked",true);//全选
			$("#selAllq").prop("checked",true);
		} else { 
			//console.log(3);               
			$(".chkitemq").prop("checked",false);  //取消全选
			$("#selAllq").prop("checked",false);
		}
	})
	$(".chkitemq").click(function(){
		//console.log(this.checked);
		var flag=true;
		if(!this.checked){
			$("#selAllq").prop("checked",false);
			$("#selAll2q").prop("checked",false);
		}else{
			//console.log($('.chkitem').length)
			for(var i=0; i<$('.chkitemq').length; i++){
				//console.log(i+':'+$('.chkitem:eq('+i+')').prop('checked'));
				if($('.chkitemq:eq('+i+')').prop('checked')==false){
					flag=false;
				}
			}
			$("#selAllq").prop("checked",flag);
			$("#selAll2q").prop("checked",flag);
		}
	});
	
	$('.dasai-location > h4 > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		var num=$('.dasai-location > h4 > p').index(this);
		$('.submenu-item > ul > li').removeClass('on');
		if(num==0){
			$('.submenu-item > ul > li.li_1').addClass('on');
		}else if(num==1){
			$('.submenu-item > ul > li.li_2').addClass('on');		
		}else if(num==2){
			$('.submenu-item > ul > li.li_3').addClass('on');
		}else if(num==3){
			$('.submenu-item > ul > li.li_4').addClass('on');
		}else if(num==4){
			$('.submenu-item > ul > li.li_5').addClass('on');		
		}else if(num==5){
			$('.submenu-item > ul > li.li_6').addClass('on');		
		}else if(num==6){
			$('.submenu-item > ul > li.li_7').addClass('on');		
		}else if(num==7){
			$('.submenu-item > ul > li.li_8').addClass('on');		
		}
	});	
	$('.wyzz-location > h4 > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		var num=$('.wyzz-location > h4 > p').index(this);
		$('.wyzzmenu-item > ul > li').removeClass('on');
		if(num==0){
			$('.wyzzmenu-item > ul > li.li_1').addClass('on');
		}else if(num==1){
			$('.wyzzmenu-item > ul > li.li_2').addClass('on');
		
		}else if(num==2){
			$('.wyzzmenu-item > ul > li.li_3').addClass('on');
		
		}else if(num==3){
			$('.wyzzmenu-item > ul > li.li_4').addClass('on');		
		}else if(num==4){
			$('.wyzzmenu-item > ul > li.li_5').addClass('on');		
		}else if(num==5){
			$('.wyzzmenu-item > ul > li.li_6').addClass('on');
		
		}
	});	
	$('#reg-phone').on('mouseout',function(){
		var phoneVal=$(this).val();
		if(phoneVal!=''){
			$(this).parent().find('h3').removeClass('on');
		}else{
			$(this).parent().find('h3').addClass('on');
		}
	});
	$('#reg-code').on('mouseout',function(){
		var phoneVal=$(this).val();
		if(phoneVal!=''){
			$(this).parent().find('h3').removeClass('on');
		}else{
			$(this).parent().find('h3').addClass('on');
		}
	});
	$('#login-user').on('mouseout',function(){
		var phoneVal=$(this).val();
		if(phoneVal!=''){
			$(this).parent().find('h3').removeClass('on');
		}else{
			$(this).parent().find('h3').addClass('on');
		}
	});
	$('#login-pwd').on('mouseout',function(){
		var phoneVal=$(this).val();
		if(phoneVal!=''){
			$(this).parent().find('h3').removeClass('on');
		}else{
			$(this).parent().find('h3').addClass('on');
		}
	});
	$('.login-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.login').css('display','none').eq($('.login-tab > p').index(this)).css('display','block');
	});
})

function clearDefault(el)
{
  if (el.defaultValue==el.value) el.value = "";
}
function resetDefault(el)
{
  if (isEmpty(el.value)) el.value=el.defaultValue;
}
