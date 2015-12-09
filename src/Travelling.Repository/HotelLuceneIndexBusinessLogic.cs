using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.ViewModel.Lucene;
using Travelling.Lucene;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.Repository
{
    /// <summary>
    /// 酒店lucene查询相关
    /// </summary>
    public class HotelLuceneIndexBusinessLogic : BaseLogic,IHotelLuceneIndexBusinessLogic
    {

        private readonly IXC_HotelDescriptionDataProvider hotelDescSyncData;
        private readonly IZhuna_HotelInfoDataProvider zhunaHotelData;
        private readonly IHotelInfoDataProvider hotelData;

        /// <summary>
        /// 构造函数
        /// </summary>
        public HotelLuceneIndexBusinessLogic()
        {
            zhunaHotelData = ketnelZhuna.Get<IZhuna_HotelInfoDataProvider>();
            hotelDescSyncData = kernel.Get<IXC_HotelDescriptionDataProvider>();
            hotelData = kernel.Get<IHotelInfoDataProvider>();
        }

        /// <summary>
        /// 创建lucene索引
        /// </summary>
        /// <param name="action"></param>
        public void IndexHotelDescriptionCreate(Action<string> action)
        {

            CtripHotelInfoLuceneIndex(action);

            ZhunaHotelCreateLuceneIndex(action);
        }

        private void CtripHotelInfoLuceneIndex(Action<string> action)
        {
            var records = hotelDescSyncData.GetHotelInfoByIndexState();
            while (records != null && records.Count > 0)
            {
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd.fff") + ",剩余:" + hotelDescSyncData.WaitIndexRecordCount());
                HotelSearchLucene.GetInstance().HotelInfoIndex(records);
                hotelDescSyncData.UpdateIndexState(records.Select(u => { return u.HotelID; }).ToList());

                records = hotelDescSyncData.GetHotelInfoByIndexState();
            }
            action("同步完成");
        }

        private void ZhunaHotelCreateLuceneIndex(Action<string> action)
        {
            action("住哪酒店开始");
            var zhunaRecords = zhunaHotelData.HotelInfoToLucene();
            while (zhunaRecords != null && zhunaRecords.Count > 0)
            {
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd.fff") + ",剩余:" + zhunaHotelData.GetHotelLuceneStateCount(0));
                HotelSearchLucene.GetInstance().HotelInfoIndex(zhunaRecords);
                zhunaHotelData.UpdateHotelLuceneIndexState(zhunaRecords.Select(u => { return u.HotelID; }).ToList());

                zhunaRecords = zhunaHotelData.HotelInfoToLucene();
            }
            action("住哪酒店完成");
        }

        [Obsolete("废弃")]
        public void InitHotelInfoLuceneIndex()
        {
            hotelDescSyncData.InitHotelInfoLuceneIndexRecord();
            zhunaHotelData.UpdateHotelLuceneIndexStateInit();
        }

        public void InitHotelIndexState()
        {
            hotelData.InitHotelInfoIndexState();
        }

        public void HotelInfoLuceneIndexAction(Action<string> action)
        {
            action("酒店lucene索引开始");
            var records = hotelData.HotelsToLucene();
            while (records != null && records.Count>0)
            {
                action(string.Format("已索引:{0},剩余:{1}", hotelData.GetHotelIndexCount(true), hotelData.GetHotelIndexCount(false)));
                HotelSearchLucene.GetInstance().HotelInfoIndex(records);
                hotelData.UpdateIndexState(records.Select(u=>u.ID).ToList());
                records = hotelData.HotelsToLucene();
            }
            action("酒店lucene索引完成");
        }
    }
}
