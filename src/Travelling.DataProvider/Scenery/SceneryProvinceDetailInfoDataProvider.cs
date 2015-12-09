using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Scenery;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.DataLayer;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider.Scenery
{
    public class SceneryProvinceDetailInfoDataProvider : BaseRecord<T_SceneryProvinceDetailInfo>, ISceneryProvinceDetailInfoDataProvider
    {
        public SceneryProvinceDetailInfoDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

        public Page<T_SceneryProvinceDetailInfo> TicketProvinceInfoPageResult(TicketProvinceInfoSearchModel searchModel)
        {
            Sql where = Sql.Builder.Where("1=1");
            if (searchModel.AreaType == 0) // provinces
            {
                if (searchModel.ProvinceID != null)
                {
                    where.Where("ID=@0", searchModel.ProvinceID);
                }

            }
            else // city
            {
                //where.Where("ParentID=@0");
                if (searchModel.ProvinceID != null)
                {
                    where.Where("ParentID=@0", searchModel.ProvinceID);
                }
            }



            //if(!string.IsNullOrEmpty(searchModel.ProvinceName))
            //{
            //    where.Where("Name like @0","%"+searchModel.ProvinceName+"%");
            //}

            //if(!string.IsNullOrEmpty(searchModel.CityName))
            //{
            //    where.Where("Name like @0", "%" + searchModel.CityName + "%");
            //}
            var pageResult = defaultDatabase.Page<T_SceneryProvinceDetailInfo>(searchModel.PageIndex, searchModel.PageSize, where);
            return pageResult;
        }

        public T_SceneryProvinceDetailInfo GetCityRecordToSearchSync()
        {
            Sql where = Sql.Builder.Where("ParentID>0 and SyncState=0");
            return Top(1, where).SingleOrDefault();
        }

        public int GetCityCountToSearchSync()
        {
            Sql where = Sql.Builder.Where("ParentID>0 and SyncState=0");
            return Count(where);
        }

        public int InitScenerySearchState()
        {
            string sql = "update T_SceneryProvinceDetailInfo SET SyncState=0";
            return defaultDatabase.Execute(sql);
        }
    }
}
