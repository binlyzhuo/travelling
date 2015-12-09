using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    public class OrderInfoSearchModel
    {
        public int OrderType { set; get; }

        [Required]
        public string OrderNo { set; get; }
        public string Telphone { set; get; }
    }
}
