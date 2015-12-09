using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaBaseReturnEntity
    {
        public string retmsg { set; get; }
        public string retcode { set; get; }

        public ReturnHeader retHeader { set; get; }

        public class ReturnHeader
        {
            public int totalput { set; get; }
            public int totalpg { set; get; }
            public int PageSize { set; get; }
            public int pg { set; get; }
        }
    }
}
