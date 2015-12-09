using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Ctrip.User;
using Travelling.OpenApiSDK;

namespace Travelling.OpenApiLogic
{
    public class OTAUserServiceLogic
    {
        static CtripUserOTAService userOTAService;
        static OTAUserServiceLogic()
        {
            userOTAService = new CtripUserOTAService();
        }

        public static void OTA_UserUniqueID(string userKey,string telphone)
        {
            var callEntity = new UserUniqueIDCallEntity() { UidKey = userKey,TelphoneNumber = telphone };
            userOTAService.OTA_UserUniqueID(callEntity);
        }
    }
}
