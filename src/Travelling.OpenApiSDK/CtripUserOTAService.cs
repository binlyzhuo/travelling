using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Travelling.OpenApiEntity.Ctrip.User;

namespace Travelling.OpenApiSDK
{
    public class CtripUserOTAService : CtripBaseApiCall
    {
        public UserUniqueIDReturnEntity OTA_UserUniqueID(UserUniqueIDCallEntity callEntity)
        {
            //callEntity.RequestType = "OTA_UserUniqueID";

            StringBuilder reqXml = new StringBuilder("<UserRequest>");
            reqXml.AppendFormat("<AllianceID>{0}</AllianceID>",this.AllianceID);
            reqXml.AppendFormat("<SID>{0}</SID>",this.SID);
            reqXml.AppendFormat("<UidKey>{0}</UidKey>",callEntity.UidKey);
            reqXml.AppendFormat("<TelphoneNumber>{0}</TelphoneNumber>",callEntity.TelphoneNumber);
            reqXml.Append("</UserRequest>");
            callEntity.RequestContent = reqXml.ToString();
            var repXml = UserApiCall(callEntity);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(repXml);
            UserUniqueIDReturnEntity returnEntity = new UserUniqueIDReturnEntity();
            GetHeaderResult(xmlDoc,returnEntity);

            returnEntity.UniqueUID = xmlDoc.SelectSingleNode("Response/UserResponse/UniqueUID").InnerText;
            returnEntity.OperationType = xmlDoc.SelectSingleNode("Response/UserResponse/OperationType").InnerText.ToInt32();
            returnEntity.RetCode = xmlDoc.SelectSingleNode("Response/UserResponse/RetCode").InnerText.ToInt32();
            return returnEntity;
        }
    }
}
