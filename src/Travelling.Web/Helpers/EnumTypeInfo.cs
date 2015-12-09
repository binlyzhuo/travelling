using System;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Ctrip.Enums;

namespace Travelling.Web.Helpers
{
    public class EnumTypeInfo
    {
        public static string GetBedType(string bedTypeCode)
        {
            try
            {
                if (string.IsNullOrEmpty(bedTypeCode))
                {
                    return "";
                }
                return EnumHelper.GetDescriptionFromEnumValue((BedType)Convert.ToInt32(bedTypeCode));
            }
            catch (Exception ex)
            {
                return bedTypeCode;
            }
        }
    }
}