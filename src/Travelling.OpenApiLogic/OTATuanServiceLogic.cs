using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Ctrip.Tuan;
using Travelling.OpenApiSDK;

namespace Travelling.OpenApiLogic
{
    public class OTATuanServiceLogic
    {
        static CtripTuanOTAService tuanService;
        static OTATuanServiceLogic()
        {
            tuanService = new CtripTuanOTAService();
        }

        //37796
        public static Product_DetailReturnEntity Product_Detail()
        {
            Product_DetailCallEntity callEntity = new Product_DetailCallEntity();
            callEntity.Products = new List<int>() { 37796 };
            tuanService.Product_Detail(callEntity);
            return null;
        }

        public static GroupProductChangeReturnEntity GroupProductChange()
        {
            GroupProductChangeCallEntity callEntity = new GroupProductChangeCallEntity();
            callEntity.ChangeTime = DateTime.Now.AddDays(7).Date;
            callEntity.ProductType = 1;
            tuanService.GroupProductChange(callEntity);
            return null;
        }

        /// <summary>
        /// 酒店团购信息查询
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public static Product_GetReturnEntity Product_Get(Product_GetCallEntity callEntity)
        {
            return tuanService.Product_Get(callEntity);
        }
    }
}
