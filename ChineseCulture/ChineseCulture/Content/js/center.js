$(function() {
	$('.center-tab > ul > li').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.center-item').css('display','none').eq($('.center-tab > ul > li').index(this)).css('display','block');
	});	
	$(".user-r-btn").on('click',function(){
		console.log('ajax调用刷新列表数据');
	});
	//
	
	$('.form-submit').on('click',function(){
		console.log('提交表单，保存信息！')
	});
	$('.jlgk-set > h3 > span').on('click',function(){
		//$('.float').css('display','none');
		$('.float').css('display','none');
	});
	$('.jlgk-btn').on('click',function(){
		$('.float').css('display','block');
		
	});
	$('.userzw-tab > p').on('click',function(){
		$(this).addClass('on').siblings().removeClass('on');
		$('.userzw-list').css('display','none').eq($('.userzw-tab > p').index(this)).css('display','block');
	});
	$('.zwform-list > p').on('click',function(){
		//alert($(this).parent().parent().find('h3').html());
		$(this).parent().parent().find('h3').html($(this).html());
		$(this).parent().parent().find('input').val($(this).find('span').html());
	});
	$(".zwf-fuli-list > p").click(function(){
	  if($(this).hasClass('on')){
		$(this).removeClass('on');
	  }else{
		$(this).addClass('on');
	  }
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
