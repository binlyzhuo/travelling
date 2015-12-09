using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelComment
    {
        public string cityid { set; get; }
        public int hotelid { set; get; }
        public string hotelname { set; get; }
        public string time { set; get; }
        public string username { set; get; }
        public string content { set; get; }
        public string df_haoping { set; get; }
        public string df_jiangjin { set; get; }
        public string yinxiang { set; get; }
        public string renqun { set; get; }
    }
}
