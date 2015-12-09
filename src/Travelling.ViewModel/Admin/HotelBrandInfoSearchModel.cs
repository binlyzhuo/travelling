using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    public class HotelBrandInfoSearchModel:BasePageQuery
    {
        public int BrandType { set; get; }
        public string brandName { set; get; }

        public int? isHot { set; get; }

        public int? isSearchRecommend { set; get; }
    }
}
