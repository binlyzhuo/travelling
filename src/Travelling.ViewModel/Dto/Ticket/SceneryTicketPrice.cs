using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Ticket
{
    /// <summary>
    /// 景区价格信息
    /// </summary>
    public class SceneryTicketPrice
    {
        /// <summary>
        /// ?主键
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 景区ID
        /// </summary>
        public int? SceneryID
        {
            get;
            set;
        }
        /// <summary>
        /// 价格策略ID
        /// </summary>
        public int PolicyID
        {
            get;
            set;
        }
        /// <summary>
        /// 价格策略名称
        /// </summary>
        public string PolicyName
        {
            get;
            set;
        }
        /// <summary>
        /// 门市价格
        /// </summary>
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// 同程价格
        /// </summary>
        public int TCPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 门票类型Id
        /// </summary>
        public int TicketId
        {
            get;
            set;
        }
        /// <summary>
        /// 门票类型名称
        /// </summary>
        public string TicketName
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            get;
            set;
        }

        /// <summary>
        /// 门票说明
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayMode
        {
            get;
            set;
        }
        /// <summary>
        /// 取票方式
        /// </summary>
        public string GetMode
        {
            get;
            set;
        }
        /// <summary>
        /// 预定跳转
        /// </summary>
        public string OrderUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 是否实名制
        /// </summary>
        public int RealName
        {
            get;
            set;
        }
        /// <summary>
        /// 是否使用二代身份证
        /// </summary>
        public int UseCard
        {
            get;
            set;
        }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Notes
        {
            get;
            set;
        }
        /// <summary>
        /// 最小票数
        /// </summary>
        public int MinTickets
        {
            get;
            set;
        }
        /// <summary>
        /// 最大票数
        /// </summary>
        public int MaxTickets
        {
            get;
            set;
        }
    }
}
