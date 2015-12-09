using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 景区同步相关接口
    /// </summary>
    public interface ISceneryInfoSyncRecordDataProvider : IDataProvider<T_SceneryInfoSyncRecord>
    {
        List<SceneryRecommendViewModel> SceneryHotForProvinces();

        List<T_SceneryInfoSyncRecord> GetRecordForSceneryDetailSync(int count = 5);

        List<T_SceneryInfoSyncRecord> GetRecordForPriceSync(int count = 5);

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<T_SceneryInfoSyncRecord> GetRecordForSceneryImgsSync(int topCount = 5);

        /// <summary>
        /// 初始化景区详细信息同步状态
        /// </summary>
        void UpdateSceneryDetailInfoSyncState();

        void UpdateSceneryPriceInfoSyncState();

        void UpdateSceneryImgInfoSyncState();

        int SceneryInfoCountToSyncPrice();
    }
}
