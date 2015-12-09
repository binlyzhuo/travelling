using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.DataLayer;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider.Hotel
{
    public class XC_HotelBrandDetailInfoDataProvider : BaseRecord<T_XC_HotelBrandDetailInfo>, IXC_HotelBrandDetailInfoDataProvider
    {
        public XC_HotelBrandDetailInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }

        public new List<T_XC_HotelBrandDetailInfo> All()
        {
            Sql sql = Sql.Builder.From("T_XC_HotelBrandDetailInfo").Where("1=1").OrderBy("OrderIndex asc");
            return defaultDatabase.Fetch<T_XC_HotelBrandDetailInfo>(sql);
        }

        public Page<T_XC_HotelBrandDetailInfo> GetHotelBrandInfos(HotelBrandInfoSearchModel searchModel)
        {
            Sql whereSql = Sql.Builder.Where("1=1");
            if(searchModel.BrandType>0)
            {
                whereSql.Where("BrandType=@0",searchModel.BrandType);
            }
            if(searchModel.isHot!=null)
            {
                whereSql.Where("IsHotBrand=@0", searchModel.isHot);
            }
            if(searchModel.isSearchRecommend!=null)
            {
                whereSql.Where("IsSearchRecommend=@0", searchModel.isSearchRecommend);
            }
            if(!string.IsNullOrEmpty(searchModel.brandName))
            {
                whereSql.Where("BrandName like @0", "%"+searchModel.brandName+"%");
            }
            whereSql.OrderBy("OrderIndex asc");
            var pageResult = defaultDatabase.Page<T_XC_HotelBrandDetailInfo>(searchModel.PageIndex, searchModel.PageSize, whereSql);
            return pageResult;
        }

        
    }
}
