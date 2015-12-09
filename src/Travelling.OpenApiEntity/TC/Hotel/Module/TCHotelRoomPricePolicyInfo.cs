using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 价格策略详情
    /// </summary>
    public class TCHotelRoomPricePolicyInfo
    {
        /// <summary>
        /// 策略Id
        /// </summary>
        public int policyId { set; get; }

        /// <summary>
        /// 策略名称
        /// </summary>
        public string policyName { set; get; }

        /// <summary>
        /// 房型价格
        /// 英文分号分隔多天价格
        /// 例如:300;100
        /// </summary>
        public string roomAdviceAmount { set; get; }

        /// <summary>
        /// 房型奖金
        /// 英文分号分隔多天价格，例如:300;100
        /// </summary>
        public string roomPrize { set; get; }

        /// <summary>
        /// 房型早餐
        /// 英文分号分隔多天价格，例如:无早;含早餐
        /// </summary>
        public string roomBreakfast { set; get; }

        /// <summary>
        /// 房型状态
        /// 多天分号分隔，0-房型确定，大于零满房
        /// </summary>
        public int roomStatus { set; get; }

        /// <summary>
        /// 房型未定
        /// 多天分号分隔，0-价格确定，大于零价格未定
        /// </summary>
        public int roomUndetermined { set; get; }

        /// <summary>
        /// 房型未定和
        /// 大于零说明房型包含未定价格
        /// </summary>
        public int roomuUndeterminedTotal { set; get; }

        /// <summary>
        /// 房态和
        /// 大于零说明房型包含满房
        /// </summary>
        public int roomStatusTotal { set; get; }

        /// <summary>
        /// 均价
        /// </summary>
        public int avgAmount { set; get; }

        /// <summary>
        /// 预订码
        /// </summary>
        public string bookingCode { set; get; }

        /// <summary>
        /// 提前天数
        /// 如出现3，则代表需要提前3天
        /// </summary>
        public int advDays { set; get; }

        /// <summary>
        /// 连住类别
        /// 0-不含连住，1-固定连住，2-更多连住，3-连住倍数
        /// “固定连住”：设置了特定连住，则只能填写连住N天，那么客人在前台就必须连住N天及以上才能下单！
        ///“更多连住”：设置了更多连住，则可以填写连住N天免费M天，那么客人在前台就必须连住N天极以上才能下单，但是满足连住的天数，我们还会赠送M天！
        ///“连住倍数”：设置了连住倍数，则可以填写连住N天，那么客人前台下单连住的天数只能是N的倍数！
        /// </summary>
        public int continuousType { set; get; }

        /// <summary>
        /// 连住免费天数
        /// 比如住5送2，那用户必须住满5天，才可以送两天
        /// </summary>
        public int continuousDays { set; get; }

        /// <summary>
        /// 连住免费天数
        /// 比如住5送2，那用户必须住满5天，才可以送两天
        /// </summary>
        public int continuousFreeDays { set; get; }

        /// <summary>
        /// 担保信息
        /// 供cct使用{预订政策说明#担保1或预付2,首日1或全额0,比率,峰时开始时间,峰时结束时间,最晚到店时间,房间超量,星期|取消变更政策}
        ///# 前面是预订政策简单说明
        ///| 后面是取消变更政策说明
        ///中间是用逗号分隔的预订政策具体信息
        /// </summary>
        public string guaranteeInfo { set; get; }

        /// <summary>
        /// 担保类型
        /// 0-无担保；1-担保冻结；2-担保预付；3-代收代付
        /// </summary>
        public int guaranteeType { set; get; }

        /// <summary>
        /// 政策备注
        /// </summary>
        public string policyRemark { set; get; }

        /// <summary>
        /// 担保标示
        /// 0-非担保，1-担保
        /// </summary>
        public int guaranteeFlag { set; get; }

        /// <summary>
        /// 预定标示
        /// 0-可预订,
        /// 1-价格全部未定
        /// 2-	全部满房
        /// 3-	部分价格未定
        /// 4-	部分满房
        /// 5-	提前入住
        /// 6-	连住
        /// </summary>
        public int bookingFlag { set; get; }

        /// <summary>
        /// ？？
        /// </summary>
        public string packageBrief { set; get; }

        /// <summary>
        /// 剩余房间数
        /// N代表剩余房间量，N=0表示有房，N>0:表示有几间房
        /// </summary>
        public int surplusRooms { set; get; }

        /// <summary>
        /// ??
        /// </summary>
        public int deductAmount { set; get; }

        /// <summary>
        /// ??
        /// </summary>
        public int policyType { set; get; }

        /// <summary>
        /// 货币类型
        /// 0人民币，1 港币
        /// </summary>
        public int currency { set;get; }

        /// <summary>
        /// 汇率
        /// </summary>
        public int exchangeRate { set; get; }

        /// <summary>
        /// 政策因数标识
        /// FactorMark&1024>0 代表新出特惠
        /// </summary>
        public int factorMark { set; get; }

        public TCHotelPresent Present { set; get; }
    }
}
