
	$.CNCN = {
		hover_class : function(control, class1) {
			$(control).hover(function() {
				$(this).addClass(class1)
			}, function() {
				$(this).removeClass(class1)
			});
		}
	}
	$.CNCN.hover_class(".quick_menu li.web_nav", "hov");


	$(function(){

		if($('.insert_list').find('dl').length<1){
			$('.insert_list').hide();
		}else{
			$('.insert_list').show();
		}

	    var _input = $(".operate_num input.text");
	    $(".operate_num").on('click','.add',function(){
	        var input =  _input.val();
	        /*if(input >= 99){
	            _input.val(99);
	        }else{
	        }*/
	        _input.val(math_floor(1));
	        
	        if($(this).parent().hasClass('plus')){
		        if($(this).parent().hasClass('need_credit_no')){var need_credit_no = 1}else{var need_credit_no = 0}
		        var _len = parseInt(input)+1;
		        if(need_credit_no==1){
			        $(".insert_list").append('<div class="insert_con"><dl>'
							+'<dt>取票人'+_len+'：<em>*</em></dt>'
							+'<dd><input type="text" class="text" name="other_man[]"></dd>'
						+'</dl>'
			        	+'<dl>'
			        	+'<dt>证件号码'+_len+'：<em>*</em></dt>'
						+'<dd><select class="select" name="other_credit_type[]">'
							+'<option value="身份证">身份证</option>'
							+'<option value="学生证">学生证</option>'
							+'<option value="军官证">军官证</option>'
							+'<option value="护照">护照</option>'
							+'<option value="户口本(儿童请选择此项)">户口本(儿童请选择此项)</option>'
							+'<option value="港澳通行证">港澳通行证</option>'
							+'<option value="台胞证">台胞证</option>'
						+'</select>'
						+'<input type="text" class="text text200" name="other_credit_no[]"></dd>'
					+'</dl></div>');
		        }else{
			        $(".insert_list").append('<div class="insert_con"><dl>'
							+'<dt>取票人'+_len+'：<em>*</em></dt>'
							+'<dd><input type="text" class="text" name="other_man[]"></dd>'
					+'</dl></div>');
		        }
	        }
	        
			if($('.insert_list').find('dl').length>0){
				$('.insert_list').show();
			}else{
				$('.insert_list').hide();
			}
			
	        refreshTotal('tickit_num_hid','tickit_num',1, 'total_price_s');
	    });
	    $(".operate_num").on('click','.sub',function(){
	        var input = _input.val();
	        if(input <= 2){
	            _input.val(math_floor(-1));
	            $('.operate_num .sub').addClass('disabled'); 
	        }else{
	            _input.val(math_floor(-1));
	            $('.operate_num .sub').removeClass('disabled');
	        }


			var _len = $(".insert_con").length;
			$(".insert_con").last().remove();

			if($('.insert_list').find('dl').length>0){
				$('.insert_list').show();
			}else{
				$('.insert_list').hide();
			}
	        refreshTotal('tickit_num_hid','tickit_num',1, 'total_price_s');
	    });

	    function math_floor(num) {
	        var value = parseInt(parseFloat($(".operate_num input.text").val())) + num;
	        value = value;
	        if(value> 1){
	            // if(value>=99){
	            //     $('.operate_num .add').addClass('disabled');
	            //     return 99;
	            // }else{
	            // }
	                $('.operate_num .add').removeClass('disabled');
	                $('.operate_num .sub').removeClass('disabled');
	                return value;
	        }else{
	            $('.operate_num .sub').addClass('disabled');
	            return 1;
	        }
	    }
	    math_floor(0);
	    $(".operate_num input").on('blur',function(){
	    	var self = this;
	    	setTimeout(function(){
		    	var num = $('.insert_con').length+1;
		    	var input = $(self).val();
		    	//input = parseInt(input,10);
		    	if(num - input > 0){
		    		$(self).val(num);
		    		for(var i = 0; i < num-input; i++) {
				    	$(".operate_num .sub").trigger('click');
				    }
		    	}
		    	if(num - input < 0){
		    		$(self).val(num);
			    	for(var i = 0; i < Math.abs(num - input); i++) {
				    	$(".operate_num .add").trigger('click');
				    }
				}
			},100);
	    })
	    
	    
	    function filter_digit(value){
	        var t_value = value.replace(/[^0-9.]/g,'');//剔除非数字字符
	        if(t_value.length>1){
	            t_value = t_value.replace(/^0+/g,'');//剔除首位为0的数字
	        }
	        return t_value;
	    }

	    var time = null;
		$("a.lxs").hover(function(){
		    clearTimeout(time);
		    $(".lxs_info").show();
		    console.log("show");
		},function(){
		    time = setTimeout(function(){
		        $(".lxs_info").hide();
		        console.log("hide");
		    },1000);
		});
		$(".lxs_info").hover(function(){
		    clearTimeout(time);
		    $(this).show();
		    console.log("show");
		    },function(){
		    time = setTimeout(function(){
		        $(".lxs_info").hide();
		        console.log("hide");
		    },1000);
		});

		$(".much_more").click(function(){
			if($(this).hasClass("hide")){
				$(this).html('<a href="#?">查看详情</a>').removeClass("hide")
				$(this).siblings(".less").show();
				$(this).siblings(".full").hide();		
			}else{
				$(this).html('<a href="#?">收起</a>').addClass("hide")
				$(this).siblings(".less").hide();
				$(this).siblings(".full").show();
			}
		});
	});
	
	function gt(o){return document.getElementById(o);}
	
	function refreshTotal(priceElement,quantityElement,quantity, targetElement){
		
		var _price = parseInt($("#"+priceElement).attr("sellPriceYuan"));
		var _quantity = parseInt($("#" + quantityElement).val());
		$("#" + targetElement).html(_price * _quantity * quantity);
		gt('total_price').value = _price * _quantity * quantity;	
	}
