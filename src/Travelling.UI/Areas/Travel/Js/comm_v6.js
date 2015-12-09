$.CNCN = {
	hover_tag : function(control, show, class1) {
		$(control + "> a").hover(function() {
			var c = $(control + "> a").index($(this));
/*			if (c == i || $(this).hasClass("more")) {
				return false;
			}*/
			$(this).addClass(class1).siblings().removeClass(class1);
			$(show + "> div").eq(c).show().siblings().hide();
		});
	},
	click_tag : function(control, show, class1) {
		$(control + "> a").click(function() {
			var c = $(control + "> a").index($(this));
			$(this).addClass(class1).siblings().removeClass(class1);
			$(show + "> div").eq(c).show().siblings().hide();
		});
	},
	hover_tag_li : function(control, show, class1) {
		var time = null;
		$(control + " li").hover(function() {
			if($(this).hasClass('more')){
				clearTimeout(time);
				var c = $(control + " li").index($(this));
				$(this).addClass(class1).siblings().removeClass(class1);
				$(show).show();
				$(show + " .hide_box").eq(c).show().siblings().hide();
			}
		},function(){
			if($(this).hasClass('more')){
				time = setTimeout(function(){
			        $(control + " li").removeClass(class1);
					$(show + " .hide_box").hide();
		    		$(show).hide();
		    	},10);
	    	}
		});
		$(show).hover(function(){
		    clearTimeout(time);
		    $(this).show();
		    },function(){
		    time = setTimeout(function(){
		        $(show + " .hide_box").hide();
		        $(control + " li").removeClass(class1);
	    		$(show).hide();
		    },10);
		});

	},
	hover_show : function(control, hideBox) {
		$(control).hover(function() {
			$(this).find(hideBox).show();
		}, function() {
			$(this).find(hideBox).hide();
		});
	},
	hover_class : function(control, class1) {
		$(control).hover(function() {
			$(this).addClass(class1)
		}, function() {
			$(this).removeClass(class1)
		});
	},
	hover_class_show : function(control, hoverBox, class1, hideBox) {
		$(control).hover(function() {
			$(this).find(hoverBox).addClass(class1);
			$(this).find(hideBox).show();
		}, function() {
			$(this).find(hoverBox).removelass(class1);
			$(this).find(hideBox).hide();
		});
	},
	hover_load : function(control, hover, class1) {
		$(control).on("mouseenter", hover, function() {
			$(this).addClass(class1);
		})
		$(control).on("mouseleave", hover, function() {
			$(this).removeClass(class1);
		});
	}
}
// $.CNCN.hover_tag("#tag_top", "#tag_con", "on", 4);
// $.CNCN.hover_show("#box", ".show");
// $.CNCN.hover_class(".quick_menu li", "hov");
// $.CNCN.hover_class_show(".quick_menu li","b","more_bg",".more")
// $.CNCN.hover_load("#box", ".tag_top", "hov");
//$.CNCN.hover_tag_li("#tag_top_nav", "#tag_con_nav", "hover");


// 输入框焦点事件
$.fn.focusEffect = function() {
	var $input = this;
	$input.focus(function() {
		if ($input.val() == '' || $input.val() == this.defaultValue) {
			$input.val('');
			$input.css({
				color : '#333'
			});
		}
	});
	$input.blur(function() {
		if ($input.val() == '') {
			$input.val(this.defaultValue);
			$input.css({
				color : '#aaa'
			});
		}
	})
}

if ($(window).width() < 1180) {
	$('body').addClass('warp1000');
}
$(window).resize(function() {
	if ($(window).width() < 1180 && $(window).width() > 0) {
		$('body').addClass('warp1000')
	} else {
		$('body').removeClass('warp1000')
	}
});

//add by jeffy.woo
function nav_on(num){
	$('#nav_'+num).addClass('on');
}

$.CNCN.hover_class(".t_nav .my_order", "hover");
$.CNCN.hover_class(".t_nav .web_nav", "hover");
$.CNCN.hover_class(".nav_tag_con dl", "hover");
$.CNCN.hover_class(".nav_tag_con dl", "hover");


var e = null;
$('.J_more_tip').hover(function() {
	var self = $(this);
	self.addClass('hover');
	$('#' + self.data('tip_id')).show().off().hover(function() {
		if (e) {
			clearTimeout(e);
		}
	}, function() {
		if (e) {
			clearTimeout(e);
		}
		$('#' + self.data('tip_id')).hide();
		self.removeClass('hover');
	});
}, function() {
	var self = $(this);
	e = setTimeout(function() {
		$('#' + self.data('tip_id')).hide();
		self.removeClass('hover');
	}, 200);
});

// 头部搜索
var arr_txt = [ '请输入景点名称'];
var $curtInput = $('#curtInput');
var m;
var $curtlist = $('#curtlist');
$curtInput.mouseover(function() {
	clearInterval(m);
	$curtlist.show();
	$curtInput.addClass('hover');
});
$curtInput.mouseout(function() {
	clearInterval(m);
	m = setInterval(function() {
		$curtlist.hide();
		$curtInput.removeClass('hover')
	}, 100);
})
$curtlist.find('li').hover(function() {
	$(this).css({
		background : '#f0f0f0'
	});
}, function() {
	$(this).css({
		background : '#fff'
	});
});

/*if($(document).find("#tn")){
	if($(".onName").text()=='门票'){
		$('#tn').val('menpiao');
	}else{
		$('#tn').val('line');
	}
}*/

$curtlist.find('li').click(function() {
	$curtlist.hide();
	var n = $.trim($(this).text());
	$curtInput.find('.onName').text(n);
	var ts = $('#so_input');
	var ts_val = ts.val();
	if (n == '景点') {
		$('#tn').val('jd');
		if (ts_val && $.inArray(ts_val, arr_txt) > -1) {
			ts.val(arr_txt[1]);
			ts[0].defaultValue = arr_txt[1];
			ts.css({
				color : '#aaa'
			});
		}
	} else if (n == '旅行社') {
		$('#tn').val('lxs');
		if (ts_val && $.inArray(ts_val, arr_txt) > -1) {
			ts.val(arr_txt[2]);
			ts[0].defaultValue = arr_txt[2];
			ts.css({
				color : '#aaa'
			});
		}
	} else if (n == '综合') {
		$('#tn').val('all');
		if (ts_val && $.inArray(ts_val, arr_txt) > -1) {
			ts.val(arr_txt[3]);
			ts[0].defaultValue = arr_txt[3];
			ts.css({
				color : '#aaa'
			});
			document.soform.target = "blank";
		}
	} else if (n == '门票') {
		$('#tn').val('piao');
		if (ts_val && $.inArray(ts_val, arr_txt) > -1) {
			ts.val(arr_txt[4]);
			ts[0].defaultValue = arr_txt[4];
			ts.css({
				color : '#aaa'
			});
		}
	} else {
		$('#tn').val('line');
		if (ts_val && $.inArray(ts_val, arr_txt) > -1) {
			ts.val(arr_txt[0]);
			ts[0].defaultValue = arr_txt[0];
			ts.css({
				color : '#aaa'
			});
		}
	}
});
$("#xianlu_so").bind(
		"submit",
		function() {
			if ($("#so_input").val() == '请输入目的地名称或线路关键词'
					|| $("#so_input").val() == '请输入景点名称'
					|| $("#so_input").val() == '请输入旅行社名称'
					|| $("#so_input").val() == '请输入关键词') {
				$("#so_input").parent(".search_top");
				return false;
			}
		});

$.CNCN.click_tag(".city_tag_top", ".city_tag_con", "on");
$.CNCN.hover_tag(".tjxl_tag_top", ".tjxl_tag_con", "on");

$('#so_input').focusEffect();

var uri = $("#city_tip .city_tag_con").attr("uri");


jQuery.cachedScript = function(url, options) {

	// Allow user to set any option except for dataType, cache, and url
	options = $.extend(options || {}, {
		dataType : "script",
		scriptCharset: 'utf8',
		cache : true,
		url : url
	});

	// Use $.ajax() since it is more flexible than $.getScript
	// Return the jqXHR object so we can chain callbacks
	return jQuery.ajax(options);
};

$(".on_city").mouseover(function(){
	var city_nav_cache = $("body").data("city_nav_cache");
	if(!city_nav_cache){
		// Usage
		$.cachedScript(uri+"/data/city_nav.php").done(function(script, textStatus) {
			$("#city_tip .city_tag_con").html(city_nav);
			$("body").data("city_nav_cache",1);
		});		
	}
})

if (!$(".side_menu s").hasClass("hide")) {
	$.CNCN.hover_class(".side_menu", "hover");
	var _city_en = $(".side_menu").attr("city_en");

	$(".side_menu").mouseover(function(){
		var side_menu_cache = $("body").data("side_menu_cache");
		if(!side_menu_cache){
			// Usage
			$.cachedScript(uri+"/menu.php?city_en="+_city_en).done(function(script, textStatus) {
				$(".side_menu").append(data);
				$.CNCN.hover_tag_li("#tag_top_nav", "#tag_con_nav", "hover");
				$("body").data("side_menu_cache",1);
			});
		}
	})	
	
}else{
	$.CNCN.hover_tag_li("#tag_top_nav", "#tag_con_nav", "hover");
}

$.CNCN.hover_show(".t_nav .weixin", ".weixin_tip");

function xx_event(n) {
    var xx = document.createElement('script');xx.async = true;
    xx.src = 'http://stat.cncn.com/event.php?n='+n;
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(xx, s);
}
