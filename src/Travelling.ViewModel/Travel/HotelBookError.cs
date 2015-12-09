using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    public class HotelBookError
    {
        public int Type { set; get; }
        public string ShortText
        { set; get; }

        public int Code { set; get; }
        public string Content { set; get; }
    }
}
