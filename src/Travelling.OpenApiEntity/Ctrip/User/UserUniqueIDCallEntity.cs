using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.User
{
    public class UserUniqueIDCallEntity:CtripBaseAPICallEntity
    {
        public UserUniqueIDCallEntity()
            : base("OTA_UserUniqueID")
        {
           
        }

        public string UidKey { set; get; }
        public string TelphoneNumber { set; get; }
    }
}
