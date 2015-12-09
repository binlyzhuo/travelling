/**

 * jquery.hhDrop ç‚¹å‡»æ˜¾ç¤ºä¸‹æ‹‰æ¡†ï¼Œç‚¹å‡»å…¶ä»–åœ°æ–¹éšè—ï¼
 * Powered By huanhuan
 * QQ 651471385
 * E-mail 651471385@qq.com
 * Data 2013-07-04
 * Dependence jquery-1.7.2.min.js
 
 **/


$(function () {

    $.fn.hhDrop = function (options) {
        var options = jQuery.extend({
            preLoadSrc: "images/loading.gif"
        }, options || {});


        var defaults = {};

        return this.each(function () {

            //é»˜è®¤
            var options = $.extend(defaults, options);
            var $this = $(this);

            var $boxSearch = $this.find('.boxSearch');
            var $lineSearchbg = $this.nextAll().find('.lineSearchbg');



            
            $boxSearch.click(function () {
                var _this = $(this);
                
                if (_this.hasClass('boxSearchHover')) {
                    _this.removeClass('boxSearchHover');
                    _this.children('.btn_search').removeClass('btn_search_current');
                    _this.parent().find('.search_form_suggest').hide();

                } else {
                    _this.addClass('boxSearchHover');
                    _this.children('.btn_search').addClass('btn_search_current');
                    _this.parent().find('.search_form_suggest').show();
                }

                _this.next().find('.clr_after a').click(function () {

                    _this.find('span.key_word b').text($(this).text());

                });


                _this.next().find('.search_city_result a').click(function () {

                    _this.find('span.key_word b').text($(this).text());

                });

                
                $(document).bind('click', function (event) {
                    if (!$(event.target).parent().hasClass('boxSearch') && !$(event.target).hasClass('boxSearch') && !$(event.target).parent().parent().hasClass('boxSearch') && !$(event.target).hasClass('input_city')) {
                        _this.children('.btn_search').removeClass('btn_search_current');
                        _this.removeClass('boxSearchHover');
                        _this.parent().find('.search_form_suggest').hide();
                    }
                });

            });

            $lineSearchbg.each(function () {
                
                $(this).find('#arriveSearchText').focus(function () {
                    var arrive = $(this).val();
                    if (arrive == 'è¯·è¾“å…¥ç›®çš„åœ°ã€ä¸»é¢˜æˆ–å…³é”®è¯') {
                        $(this).val('').css('color', '#000');
                    }
                });
                $(this).find('#arriveSearchText').blur(function () {
                    var arrive = $(this).val();
                    if (arrive == '') {
                        $(this).val('è¯·è¾“å…¥ç›®çš„åœ°ã€ä¸»é¢˜æˆ–å…³é”®è¯').css('color', '#b5b5b5');
                    }
                });

               
                $(this).find('#btn_delete').click(function () {
                    $(this).prev('#arriveSearchText').focus().val('').css('color', '#000');
                });

            });
        });

    }

});