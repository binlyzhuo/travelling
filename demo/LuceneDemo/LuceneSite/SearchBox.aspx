<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.aspx.cs" Inherits="LuceneSite.SearchBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/hhDrop.js" type="text/javascript"></script>
    <link type="text/css" href="Styles/StyleSheet1.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#hhDrop00').hhDrop({});
            $('#hhDrop01').hhDrop({});
        });
        
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="lineSearch">
    <input type="text" id="hhDrop00" class="thRelative"/>
        <div style="display:none;" class="search_form_suggest">
				<h3><a item="close" class="ico btn_close thRight">关闭</a>热门出发城市</h3>
				<dl class="search_hotList">
					<dd class="clr_after">
						<a href="#">北京</a>
						<a href="#">上海</a>
						<a href="#">广州</a>
						<a href="#">成都</a>
						<a href="#">杭州</a>
						<a href="#">南京</a>
						<a href="#">深圳</a>
						<a href="#">济南</a>
						<a href="#">石家庄</a>
						<a href="#">武汉</a>
						<a href="#">郑州</a>
						<a href="#">重庆</a>
						<a href="#">福州</a>
						<a href="#">西安</a>
						<a href="#">长沙</a>
						<a href="#">沈阳</a>
						<a href="#">天津</a>
						<a href="#">哈尔滨</a>
						<a href="#">苏州</a>
						<a href="#">南宁</a>
					</dd>
				</dl>
			
				<div class="clear"></div>
			
				<div item="dep-search" class="select_city_box">
					<span>输入出发城市</span>
					<input type="text" item="key" class="input_city">
					<button item="commit" type="button" class="btn">添加</button>
					<div style="display:;" item="result" class="search_city_result">
						<a href="javascript:void();">广州</a> 没有匹配城市
					</div>
				</div>
			
				<div class="thLeft thPadT5 tab_select">
					<dl class="clrfix">
						<dt>A-G</dt>
						<dd class="clr_after">
							<a href="#">北京</a>
							<a href="#">长沙</a>
							<a href="#">成都</a>
							<a href="#">重庆</a>
							<a href="#">福州</a>
							<a href="#">广州</a>
							<a href="#">贵阳</a>
						</dd>
					</dl>
					<dl class="clrfix">
						<dt>H-L</dt>
						<dd class="clr_after">
							<a href="#">哈尔滨</a>
							<a href="#">杭州</a>
							<a href="#">合肥</a>
							<a href="#">济南</a>
							<a href="#">昆明</a>
						</dd>
					</dl>
					<dl class="clrfix">
						<dt>M-T</dt>
						<dd class="clr_after">
							<a href="#">南昌</a>
							<a href="#">南京</a>
							<a href="#">南宁</a>
							<a href="#">宁波</a>
							<a href="#">青岛</a>
							<a href="#">三亚</a>
							<a href="#">上海</a>
							<a href="#">沈阳</a>
							<a href="#">深圳</a>
							<a href="#">石家庄</a>
							<a href="#">苏州</a>
							<a href="#">太原</a>
							<a href="#">天津</a>
						</dd>
					</dl>
					<dl class="clrfix">
						<dt>W-Z</dt>
						<dd class="clr_after">
							<a href="#">武汉</a>
							<a href="#">厦门</a>
							<a href="#">西安</a>
							<a href="#">郑州</a>
							<a href="#">中山</a>
						</dd>
					</dl>
				</div>  
			</div>
            </div>
    </form>
</body>
</html>
