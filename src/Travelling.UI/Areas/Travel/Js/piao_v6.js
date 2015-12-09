$(function(){
	// 详情页浮动菜单
	if ($('#tab_nav').length > 0) {
	    
		var toTopHeight = $("#tab_nav").offset().top;
		$(window).scroll(function() {
			if( $(document).scrollTop() > toTopHeight){
				$("#tab_nav").addClass("fxd");
				$("#tab_nav_bg").show();
			}else{
				$("#tab_nav").removeClass("fxd");
				$("#tab_nav_bg").hide();
			}
		});
		// 滚动定位
		function h(id) {
		    var arr = [];
		    id.each(function (i) {
		        arr.push(id.eq(i).offset().top - $("#tab_nav").height() - 1);
		    });
		    for (var i = 0; i < arr.length; i++) {
		        if ($(document).scrollTop() > arr[i]) {
		            tab1(i, 'on');
		        }
		    }
		};
		function tab1(index, clas) {
		    $('#tab_nav span').removeClass(clas).eq(index).addClass(clas);
		};
		$(window).scroll(function(){
			h($('#sectionBox .section'));
		});
		$("#tab_nav span").click(function(e){
			e.preventDefault();
			var index = ($("#tab_nav span")).index($(this));
			var goTo = $('#sectionBox .section').eq(index).offset().top-$("#tab_nav").height();
			$("html, body").animate({
				scrollTop: goTo
			}, 500);
		});
	}

	$('.order_list_con ul .must').click(function(){
		if($(this).parents('li').hasClass('open')){
			$(this).parents('li').removeClass('open');
		}else{
			$(this).parents('li').addClass('open');
		}
	});
	$('.order_list .more_type span').click(function(){
		if($(this).parents('.order_list').find('.order_list_con').slice(2).css('display') == 'none'){
			$(this).parents('.order_list').find('.order_list_con').slice(2).show();
			$(this).html('缩起更多门票类型' + '<i></i>')
		}else{
			$(this).parents('.order_list').find('.order_list_con').slice(2).hide();
			$(this).html('查看更多门票类型' + '<i class="close"></i>')
		}
	});

	$(".much_more").click(function(){
		if($(this).hasClass("open")){
			$(this).html('<a href="#?">查看详情</a>').removeClass('open');
			$(this).parent().find(".simple").show();
			$(this).parent().find(".all").hide();		
		}else{
			$(this).html('<a href="#?">收起</a>').addClass('open');
			$(this).parent().find(".simple").hide();
			$(this).parent().find(".all").show();
		}
	})

})


$(".tjxl_tag_top a").hover(function(index){
	var cur = $(this).attr('data-id')
	var content = $(".tjxl_tag_top").data(cur)
	var that = $(this);
	if(content){
		$(this).parents(".tit").siblings(".tjxl_tag_con").children(".txt").html(content);
	}else{
		$(this).parents(".tit").siblings(".tjxl_tag_con").children(".txt").html('<img src="http://s.cncnimg.cn/css/img_v5/loading.gif" style="display:block;width:28px;height:28px;margin:160px auto 157px auto;">');
		$.get("/piao/piao_ajax.php", {cur:cur,inajax:1}, function(data) {
			$(that).parents(".tit").siblings(".tjxl_tag_con").children(".txt").html(data);
			$(".tjxl_tag_top").data(cur,data);
		});		
	}
});

$(".tjxl_tag_top").each(function(){
	$(this).children("a:first").trigger("mouseover");
})

$(function(){
	$.CNCN_focus = function(slide,numNav,prev,next,num){
		var curr = 0;
		$(numNav + "> a").each(function(i){
			$(this).click(function(){
				curr = i;
				$(slide + "> .pic_con .pic").eq(i).fadeIn("slow").siblings(".pic").hide();
				$(this).siblings("a").removeClass("on").end().addClass("on");
				return false;
			});
		});
		
		var pg = function(flag){
			if (flag) {
				if (curr == 0) {
					todo = num-1;
				} else {
					todo = (curr - 1) % num;
				}
			} else {
				todo = (curr + 1) % num;
			}
			$(numNav + "> a").eq(todo).click();
		};
		
		//前
		$(prev).click(function(){
			pg(true);
			return false;
		});
		
		//后
		$(next).click(function(){
			pg(false);
			return false;
		});
		
		
		//鼠标滑过停止
		$(slide+','+prev+','+next).hover(function(){
				clearInterval(timer);
			}
		);
	}
});
$(document).ready(function(){
	$(".wan_con").hover(function(){
		$(this).find(".btn").show(100);}
		,function(){
			$(this).find(".btn").hide(100);
	});
	var _len = $('.pic_con').find('.pic').length;
	$.CNCN_focus(".slide_con",".num1",".prevBtn",".nextBtn",_len);
});