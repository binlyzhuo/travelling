using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.User
{
    public class UserUniqueIDReturnEntity:CtripBaseAPIReturnEntity
    {
        public string UniqueUID { set; get; }
        public int OperationType { set; get; }
        public int RetCode { set; get; }
    }
}
