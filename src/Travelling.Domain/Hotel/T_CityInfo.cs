using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Hotel
{
    /// <summary>
	///  城市信息
	/// </summary>
	[Serializable]
	public partial class T_CityInfo
	{
		public T_CityInfo()
		{}
		#region Model
		private int _id;
		private int _cityid=0;
		private string _cityname="";
		private string _pinyin="";
		private string _suoxie="";
		private string _abcd="";
		private int _hotelcount=0;
		private string _baidulat="";
		private string _baidulng="";
		private string _zhunacityid="";
		private int _provinceid=0;
		private string _provincename="";
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 城市ID
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 城市名称
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 拼音
		/// </summary>
		public string PinYin
		{
			set{ _pinyin=value;}
			get{return _pinyin;}
		}
		/// <summary>
		/// 缩写
		/// </summary>
		public string SuoXie
		{
			set{ _suoxie=value;}
			get{return _suoxie;}
		}
		/// <summary>
		/// 首字母
		/// </summary>
		public string ABCD
		{
			set{ _abcd=value;}
			get{return _abcd;}
		}
		/// <summary>
		/// 酒店个数
		/// </summary>
		public int HotelCount
		{
			set{ _hotelcount=value;}
			get{return _hotelcount;}
		}
		/// <summary>
		/// 百度lat
		/// </summary>
		public string BaiDuLat
		{
			set{ _baidulat=value;}
			get{return _baidulat;}
		}
		/// <summary>
		/// 百度lng
		/// </summary>
		public string BaiDuLng
		{
			set{ _baidulng=value;}
			get{return _baidulng;}
		}
		/// <summary>
		/// 住哪cityID
		/// </summary>
		public string ZhunaCityID
		{
			set{ _zhunacityid=value;}
			get{return _zhunacityid;}
		}
		/// <summary>
		/// 省份ID
		/// </summary>
		public int ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 省份名称
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}
		#endregion Model

	}
}
