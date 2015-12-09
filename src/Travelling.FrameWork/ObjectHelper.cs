using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    public static class ObjectHelper
    {
        public static string SubString(this string source, int len)
        {
            if (string.IsNullOrEmpty(source))
            {
                return "";
            }
            if (source.Trim().Length > len)
            {
                return source.Substring(0, len);
            }
            else
            {
                return source.Trim();
            }
        }

       

        public static string IntToZHState(this int intVal)
        {
            return intVal == 0 ? "否" : "是";
        }

    }
}
