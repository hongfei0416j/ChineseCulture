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
	/*var $container = $('.notic-cen'),
    $text = $('.nc-list');
  var direction = 2, // 1为从左进入，2为从右进入
    speed = 100000; // 数值越小速度越快

  var textMove = function (obj, container, direction, speed) {
    // 定义文字初始位置
    var initMarginLeft = '-' + obj.width() + 'px';
    obj.css({"margin-left": initMarginLeft});
    // 定义动画
    var move = function () {
      // 定义暂停后的速度
      var allDistance = obj.width() + container.width(),
        remainedDistance = container.width() - parseInt(obj.css('margin-left')),
        currentSpeed = (speed * remainedDistance ) / allDistance;
      // 移动效果
      obj.animate({"margin-left": container.width() + 'px'}, currentSpeed, 'linear', function () {
        obj.stop(true, true);
        obj.css({"margin-left": initMarginLeft});
        move();
      });
    };
    move();
    //  定义容器的暂停、恢复效果
    container.on("mouseenter", function () {obj.stop(true)})
      .on('mouseleave', function () {move()})
  };

  textMove($text, $container, direction, speed);*/
  
	/*$(".nc-list").clone().appendTo('.nc-list > p');
	var height=$(".nc-list").innerHeight();
	console.log(-(height/2)-30);
	var num=0;
	var timer = null;
	timer=setInterval(function(){
		num-=1;
		if(num<=(-(height/2)-0)){			
			num=0;	
			$(".nc-list").css('top',num+'px');		
		}else{
		$(".nc-list").css('top',num+'px');}
		
	},100);*/
	/*
	$(".nc-list").clone().appendTo('.nc-list > p');
	var height=$(".nc-list").innerHeight();
	console.log(-(height/2)-30);
	var num=0;
	var timer = null;
	timer=setInterval(function(){
		num-=1;
		if(num<=(-(height/2)-0)){			
			num=0;	
			$(".nc-list").css('top',num+'px');		
		}else{
		$(".nc-list").css('top',num+'px');}
		
	},100);
	$(".nc-list").on('mouseover',function(){
		clearInterval(timer);
	});
	$(".nc-list").on('mouseout',function(){
		clearInterval(timer);
		timer=setInterval(function(){
			num-=1;
			if(num<=(-(height/2)-0)){			
				num=0;	
				$(".nc-list").css('top',num+'px');		
			}else{
			$(".nc-list").css('top',num+'px');}
			
		},100);
	});*/
	
})
function clearDefault(el)
{
  if (el.defaultValue==el.value) el.value = "";
}
function resetDefault(el)
{
  if (isEmpty(el.value)) el.value=el.defaultValue;
}
