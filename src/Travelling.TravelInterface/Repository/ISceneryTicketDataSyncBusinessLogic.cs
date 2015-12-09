using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.TravelInterface.Repository
{
    public interface ISceneryTicketDataSyncBusinessLogic
    {
        void SceneryInfoDetailSync(Action<string> action);

        void SceneryTicketPriceSync(Action<string> action);

        void SceneryInfoSync(Action<string> action, bool all = false);

        //==================================================

        /// <summary>
        /// 获取景区城市同步记录个数
        /// </summary>
        /// <param name="syncState"></param>
        /// <returns></returns>
        int GetSceneryCitySyncRecordCount(bool? syncState);

        /// <summary>
        /// 初始化景区城市数据
        /// </summary>
        void InitSceneryCitySyncRecord();

        void InitSceneryInfoSyncRecord();

        void InitSceneryDetailInfoSyncRecord();

        void InitSceneryTicketPriceSyncData();

        void InitSceneryImgsSyncDate();

        void SceneryImgSyncRecord(Action<string> action);
    }
}
