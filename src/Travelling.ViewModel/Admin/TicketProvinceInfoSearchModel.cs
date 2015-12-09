using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    public class TicketProvinceInfoSearchModel:BasePageQuery
    {
        public int AreaType { set; get; }
        public int? ProvinceID { set; get; }
        public string AreaName { set; get; }
    }
}
