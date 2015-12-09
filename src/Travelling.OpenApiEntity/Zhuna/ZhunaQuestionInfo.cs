using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaQuestionInfo
    {
        public string cityid { set; get; }
        public int hotelid { set; get; }
        public string hotelname { set; get; }
        public string time { set; get; }
        public string username { set; get; }
        public string question { set; get; }
        public string question_text { set; get; }
        public string answercontent { set; get; }
    }
}
