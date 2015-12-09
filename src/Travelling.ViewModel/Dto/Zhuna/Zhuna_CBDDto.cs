using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Zhuna
{
    public class Zhuna_CBDDto
    {
        /// <summary>
		/// 主键
		/// </summary>
        public int id
        {
            get;
            set;
        }
		/// <summary>
		/// cbdid
		/// </summary>
		public string cbdid
		{
            get;
            set;
		}
		/// <summary>
		/// 住哪城市id
		/// </summary>
		public string cityid
		{
            get;
            set;
		}
		/// <summary>
		/// cbdname
		/// </summary>
		public string cbdname
		{
            get;
            set;
		}
		/// <summary>
		/// 酒店个数
		/// </summary>
		public int hotelcount
		{
            get;
            set;
		}
		/// <summary>
		/// 城市名称
		/// </summary>
		public string cityname
		{
            get;
            set;
		}
		/// <summary>
		/// 商圈周边酒店
		/// </summary>
		public string hotelidstring
		{
            get;
            set;
		}
		
    }
}
