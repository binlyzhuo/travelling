using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Setting;
using Travelling.TravelInterface.Data.Setting;

namespace Travelling.DataProvider.Setting
{
    /// <summary>
    /// 联盟相关信息
    /// </summary>
    public class UnionDetailInfoDataProvider:BaseRecord<T_UnionDetailInfo>,IUnionDetailInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnionDetailInfoDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }
    }
}
