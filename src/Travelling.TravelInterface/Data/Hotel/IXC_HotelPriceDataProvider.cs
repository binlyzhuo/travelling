using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 酒店最低价格相关数据
    /// </summary>
    public interface IXC_HotelPriceDataProvider : IDataProvider<T_XC_HotelPrice>
    {
        List<HotelPrimaryInfo> RecommendHotels();

        List<HotelPrimaryInfo> HotHotels();

        /// <summary>
        /// 导入酒店最低价格数据
        /// </summary>
        /// <param name="cityIdList"></param>
        void HotelLowestPriceImport(List<int> cityIdList);

        /// <summary>
        /// 导入酒店最低价格到详情表
        /// </summary>
        void ImportHotelMinPriceToDescription();
    }
}
