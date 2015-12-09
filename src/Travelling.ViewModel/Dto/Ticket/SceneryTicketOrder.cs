using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Ticket
{
    public class SceneryTicketOrder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set;
            get;
        }
        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryID
        {
            set;
            get;
        }
        /// <summary>
        /// 门票价格策络
        /// </summary>
        public int PolicyID
        {
            set;
            get;
        }
        /// <summary>
        /// 订单流水号
        /// </summary>
        public string SerialNo
        {
            set;
            get;
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int State
        {
            set;
            get;
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set;
            get;
        }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LinkTel
        {
            set;
            get;
        }
        /// <summary>
        /// 门票张数
        /// </summary>
        public int TicketCount
        {
            set;
            get;
        }
        /// <summary>
        /// 实付金额
        /// </summary>
        public int TotalAmount
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set;
            get;
        }
        /// <summary>
        /// 景区名称
        /// </summary>
        public string SceneryName
        {
            set;
            get;
        }

        /// <summary>
        /// 游玩日期
        /// </summary>
        public DateTime TravelDate
        {
            set;
            get;
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayMode
        {
            set;
            get;
        }
    }
}
