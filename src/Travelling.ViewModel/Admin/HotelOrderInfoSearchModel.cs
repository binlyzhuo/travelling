using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    public class HotelOrderInfoSearchModel:BasePageQuery
    {
        public DateTime? InRoomDate { set; get; }
        public DateTime? OffRoomDate { set; get; }
        public string ContractPerson { set; get; }
        public string ContractTel { set; get; }
        public int? HotelOrderFlag { set; get; }
    }
}
