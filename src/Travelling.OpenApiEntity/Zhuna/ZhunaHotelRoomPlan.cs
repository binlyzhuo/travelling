using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelRoomPlan
    {
        public int planid { set; get; }
        public string planname { set; get; }
        public int totalprice { set; get; }
        public string priceCode { set; get; }
        public int iscard { set; get; }
        public int menshi { set; get; }
        public int status { set; get; }

        public string carddesc { set; get; }

        public int jiangjin { set; get; }

        //public List<ZhunaHotelRoomPlanAddValue> AddValues { set; get; }
        public ZhunaHotelRoomPlanCardRule cardrule { set; get; }

        public List<PlanDate> date { set; get; }
        public PlanDescription description { set; get; }
    }

    public class PlanDescription
    {
        public string AddValues { set; get; }
        public string Promotion { set; get; }
        public string GaranteeRule { set; get; }
    }

    public class PlanDate
    {
        public string day { set; get; }
        public string week { set; get; }
        public string menshi { set; get; }
        public string price { set; get; }
        public string jiangjin { set; get; }
    }
}
