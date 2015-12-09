using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaQuestionlistReturnEntity:ZhunaBaseReturnEntity
    {
        public List<ZhunaQuestionInfo> reqdata { set; get; }
    }
}
